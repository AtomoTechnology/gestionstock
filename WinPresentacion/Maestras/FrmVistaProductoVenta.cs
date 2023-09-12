using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Negocio;
using System.Runtime.InteropServices;
namespace WinPresentacion.Maestras
{
    public partial class FrmVistaProductoVenta : Form
    {
        CtrlProductos Productos = new CtrlProductos();
        public int IdAlmacen;
        Validar val = new Validar();
        public FrmVistaProductoVenta()
        {
            InitializeComponent();
        }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]

        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void OcultarColumnas()
        {
            this.dataListado.Columns[0].Visible = false;
            this.dataListado.Columns[2].Visible = false;
            this.dataListado.Columns[3].Visible = false;
            this.dataListado.Columns[6].Visible = false;
            this.dataListado.Columns[7].Visible = false;
            this.dataListado.Columns[8].Visible = false;
            this.dataListado.Columns[9].Visible = false;
            this.dataListado.Columns[11].Visible = false;
            this.dataListado.Columns[12].Visible = false;
        }
        public void anchogrid()
        {
            //this.dataListado.Columns[0].Width = 90;
            this.dataListado.Columns[1].Width = 300;
            this.dataListado.Columns[4].Width = 190;
            this.dataListado.Columns[5].Width = 190;
            this.dataListado.Columns[10].Width = 190;


        }

        private void CargarDatos()
        {
            dataListado.DataSource = Productos.BuscarProductosTodos(IdAlmacen);
            this.dataListado.Columns.Cast<DataGridViewColumn>().ToList().ForEach(c => c.HeaderText = c.HeaderText.ToUpper());
            anchogrid();
            OcultarColumnas();


        }
        private void CargarMarca()
        {
            dataListado.DataSource = Productos.BuscarProDuctoMarca(IdAlmacen, txtMarca.Text);
            this.dataListado.Columns.Cast<DataGridViewColumn>().ToList().ForEach(c => c.HeaderText = c.HeaderText.ToUpper());
            anchogrid();
            OcultarColumnas();
        }
        private void CargarNombre()
        {
            dataListado.DataSource = Productos.BuscarProDuctoNombre(IdAlmacen, txtNombre.Text);
            this.dataListado.Columns.Cast<DataGridViewColumn>().ToList().ForEach(c => c.HeaderText = c.HeaderText.ToUpper());
            anchogrid();
            OcultarColumnas();
        }
        private void FrmVistaProductoVenta_Load(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void FrmVistaProductoVenta_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
            CargarNombre();
        }

        private void txtMarca_TextChanged(object sender, EventArgs e)
        {
            CargarMarca();
        }

        private void dataListado_Click(object sender, EventArgs e)
        {
            txtDesc.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Descripcion"].Value);
            txtUbicacion.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Ubicacion"].Value);
            txtStock.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["StockXAlacen"].Value);
        }

        private void dataListado_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                FrmVentas form = FrmVentas.GetInstancia();
                string par2;
                decimal par3, par4;
                int par5, par1, par7;

                par1 = Convert.ToInt32(this.dataListado.CurrentRow.Cells["IdProducto"].Value);
                par2 = Convert.ToString(this.dataListado.CurrentRow.Cells["PRODUCTO"].Value);
                par3 = Convert.ToDecimal(this.dataListado.CurrentRow.Cells["PrecioUnitarioCompra"].Value);
                par4 = Convert.ToDecimal(this.dataListado.CurrentRow.Cells["P. VENTA"].Value);
                par5 = Convert.ToInt32(this.dataListado.CurrentRow.Cells["STOCK COMPRA"].Value);

                par7 = Convert.ToInt32(this.dataListado.CurrentRow.Cells["IdDetaleCompra"].Value);
                form.setArticulo(par1, par2, par3, par4, par5, par7);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            val.SoloLetras(e);
        }

        private void txtMarca_KeyPress(object sender, KeyPressEventArgs e)
        {
            val.SoloLetras(e);
        }
    }
}
