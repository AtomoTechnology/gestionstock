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
using System.Data.SqlClient;
namespace WinPresentacion.Maestras
{
    public partial class FrmVistaProductoCompra : Form
    {
        CtrlProductos Productos = new CtrlProductos();
        public int IdAlmacen;
        Validar val = new Validar();
        public FrmVistaProductoCompra()
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
            this.dataListado.Columns[4].Visible = false;
            this.dataListado.Columns[8].Visible = false;
            this.dataListado.Columns[9].Visible = false;
            this.dataListado.Columns[10].Visible = false;
            this.dataListado.Columns[11].Visible = false;
            this.dataListado.Columns[12].Visible = false;
        }
        public void anchogrid()
        {
            //this.dataListado.Columns[0].Width = 80;
            this.dataListado.Columns[1].Width = 80;
            this.dataListado.Columns[2].Width = 150;
            this.dataListado.Columns[3].Width = 300;
            //this.dataListado.Columns[4].Width = 100;
            this.dataListado.Columns[5].Width = 120;
            this.dataListado.Columns[6].Width = 120;
            this.dataListado.Columns[7].Width = 120;

        }

        private void CargarDatos()
        {
            dataListado.DataSource = Productos.ListarProductos(IdAlmacen);
            anchogrid();
            OcultarColumnas();


        }
        private void CargarDatosNom()
        {
            dataListado.DataSource = Productos.ListarProductosNomProductos(IdAlmacen, txtProducto.Text);
            anchogrid();
            OcultarColumnas();


        }
        private void FrmVistaProductoCompra_Load(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataListado_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                FrmCompras p = FrmCompras.GetInstancia();
                int IdProducto;
                string Nombre;
                IdProducto = Convert.ToInt32(this.dataListado.CurrentRow.Cells["IdProducto"].Value);
                Nombre = Convert.ToString(this.dataListado.CurrentRow.Cells["PRODUCTO"].Value);

                p.setArticulo(IdProducto, Nombre);

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtProducto_TextChanged(object sender, EventArgs e)
        {
            CargarDatosNom();
        }

        private void FrmVistaProductoCompra_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void txtProducto_KeyPress(object sender, KeyPressEventArgs e)
        {
            val.SoloLetras(e);
        }
    }
}
