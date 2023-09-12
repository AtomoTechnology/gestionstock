using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Negocio;
namespace WinPresentacion.Maestras
{
    public partial class FrmVistaProveedorCompra : Form
    {
        CtrlProveedor Proveedor = new CtrlProveedor();
        Validar val = new Validar();
        public FrmVistaProveedorCompra()
        {
            InitializeComponent();
        }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]

        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void OcultarColumnas()
        {
            this.dataListado.Columns[13].Visible = false;
            this.dataListado.Columns[14].Visible = false;
            this.dataListado.Columns[15].Visible = false;
            //this.dataListado.Columns[9].Visible = false;
            this.dataListado.Columns[10].Visible = false;
            this.dataListado.Columns[11].Visible = false;
            this.dataListado.Columns[12].Visible = false;
        }
        public void anchogrid()
        {
            this.dataListado.Columns[0].Width = 90;
            this.dataListado.Columns[1].Width = 180;
            this.dataListado.Columns[2].Width = 110;
            this.dataListado.Columns[3].Width = 110;
            this.dataListado.Columns[4].Width = 150;
            this.dataListado.Columns[5].Width = 160;
            this.dataListado.Columns[6].Width = 150;
            this.dataListado.Columns[7].Width = 150;
            this.dataListado.Columns[8].Width = 150;
            this.dataListado.Columns[9].Width = 120;

        }

        private void CargarDatos()
        {
            dataListado.DataSource = CtrlProveedor.MostrarTodos();
            anchogrid();
            OcultarColumnas();


        }
        private void CargarRUC()
        {
            dataListado.DataSource = CtrlProveedor.BuscarRuc(txtRuc.Text);
            anchogrid();
            OcultarColumnas();
        }
        private void CargarRazonSocial()
        {
            dataListado.DataSource = CtrlProveedor.BuscarRazonSocial(txtProducto.Text);
            anchogrid();
            OcultarColumnas();
        }
        private void FrmVistaProveedorCompra_Load(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void FrmVistaProveedorCompra_MouseDown(object sender, MouseEventArgs e)
        {

            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtProducto_TextChanged(object sender, EventArgs e)
        {
            CargarRazonSocial();
        }

        private void txtRuc_KeyPress(object sender, KeyPressEventArgs e)
        {
            val.SoloNumeros(e);
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                CargarRUC();
            }
        }

        private void dataListado_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                FrmCompras p = FrmCompras.GetInstancia();

                string Ruc, Nombre;
                Ruc = Convert.ToString(this.dataListado.CurrentRow.Cells["RUC"].Value);
                Nombre = Convert.ToString(this.dataListado.CurrentRow.Cells["RAZÓN SOCIAL"].Value);

                p.setProveedor(Ruc, Nombre);

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtProducto_KeyPress(object sender, KeyPressEventArgs e)
        {
            val.SoloLetras(e);
        }
    }
}
