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
    public partial class FrmVistaClienteVenta : Form
    {
        CtrlCliente Clietes = new CtrlCliente();
        Validar val = new Validar();
        public FrmVistaClienteVenta()
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
            this.dataListado.Columns[7].Visible = false;
            this.dataListado.Columns[8].Visible = false;
            this.dataListado.Columns[9].Visible = false;
            this.dataListado.Columns[13].Visible = false;
            this.dataListado.Columns[15].Visible = false;
            this.dataListado.Columns[17].Visible = false;
            this.dataListado.Columns[19].Visible = false;
        }
        public void anchogrid()
        {
            //this.dataListado.Columns[0].Width = 90;
            this.dataListado.Columns[1].Width = 100;
            this.dataListado.Columns[2].Width = 110;
            this.dataListado.Columns[3].Width = 150;
            this.dataListado.Columns[4].Width = 150;
            this.dataListado.Columns[5].Width = 150;
            this.dataListado.Columns[6].Width = 150;
            this.dataListado.Columns[10].Width = 100;
            this.dataListado.Columns[11].Width = 150;
            this.dataListado.Columns[12].Width = 150;
            this.dataListado.Columns[14].Width = 150;
            this.dataListado.Columns[16].Width = 150;
            this.dataListado.Columns[18].Width = 150;
            this.dataListado.Columns[20].Width = 150;

        }

        private void CargarDatos()
        {
            dataListado.DataSource = Clietes.MostarTodos();
            this.dataListado.Columns.Cast<DataGridViewColumn>().ToList().ForEach(c => c.HeaderText = c.HeaderText.ToUpper());
            anchogrid();
            OcultarColumnas();


        }
        private void CargarRUC()
        {
            dataListado.DataSource = Clietes.BuscarDNI(txtRuc.Text);
            this.dataListado.Columns.Cast<DataGridViewColumn>().ToList().ForEach(c => c.HeaderText = c.HeaderText.ToUpper());
            anchogrid();
            OcultarColumnas();
        }
        private void CargarRazonSocial()
        {
            dataListado.DataSource = Clietes.BuscarApPaterno(txtProducto.Text);
            this.dataListado.Columns.Cast<DataGridViewColumn>().ToList().ForEach(c => c.HeaderText = c.HeaderText.ToUpper());
            anchogrid();
            OcultarColumnas();
        }
        private void FrmVistaClienteVenta_Load(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void FrmVistaClienteVenta_MouseDown(object sender, MouseEventArgs e)
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

        private void txtRuc_TextChanged(object sender, EventArgs e)
        {
            CargarRUC();
        }

        private void dataListado_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                FrmVentas p = FrmVentas.GetInstancia();

                string Ruc, Nombre;
                Ruc = Convert.ToString(this.dataListado.CurrentRow.Cells["Número"].Value);
                Nombre = Convert.ToString(this.dataListado.CurrentRow.Cells["A. Paterno"].Value) + " " + Convert.ToString(this.dataListado.CurrentRow.Cells["A. Materno"].Value) + " " + Convert.ToString(this.dataListado.CurrentRow.Cells["P. NOMBRE"].Value) + " " + Convert.ToString(this.dataListado.CurrentRow.Cells["S. NOMBRE"].Value);

                p.setCliente(Ruc, Nombre);

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

        private void txtRuc_KeyPress(object sender, KeyPressEventArgs e)
        {
            val.SoloNumeros(e);
        }
    }
}
