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
    public partial class FrmListaProveedor : Form
    {
        CtrlProveedor CtrlProveedor = new CtrlProveedor();

        Validar val = new Validar();
        public FrmListaProveedor()
        {
            InitializeComponent();
        }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]

        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        private void OcultarColumnas()
        {
            this.dataListado.Columns[15].Visible = false;
            this.dataListado.Columns[3].Visible = false;
            this.dataListado.Columns[5].Visible = false;
            this.dataListado.Columns[6].Visible = false;
            this.dataListado.Columns[14].Visible = false;
            this.dataListado.Columns[13].Visible = false;
            this.dataListado.Columns[12].Visible = false;
        }
        public void anchogrid()
        {
            this.dataListado.Columns[0].Width = 100;
            this.dataListado.Columns[1].Width = 160;
            this.dataListado.Columns[2].Width = 100;
            this.dataListado.Columns[4].Width = 150;
            this.dataListado.Columns[7].Width = 150;
            this.dataListado.Columns[8].Width = 150;
            this.dataListado.Columns[9].Width = 150;
            this.dataListado.Columns[10].Width = 150;
            this.dataListado.Columns[11].Width = 120;


        }

        private void CargarDatos()
        {
            dataListado.DataSource = CtrlProveedor.ListarOperacionesTodos();
            this.dataListado.Columns.Cast<DataGridViewColumn>().ToList().ForEach(c => c.HeaderText = c.HeaderText.ToUpper());
            anchogrid();
            OcultarColumnas();
            lblCantidad.Text = "Total de Registros " + dataListado.Rows.Count;

        }
        private void CargarDatosNom()
        {
            dataListado.DataSource = CtrlProveedor.ListarOperacionesProveedorRazonSocial(txtApPaterno.Text);
            this.dataListado.Columns.Cast<DataGridViewColumn>().ToList().ForEach(c => c.HeaderText = c.HeaderText.ToUpper());
            anchogrid();
            OcultarColumnas();
            lblCantidad.Text = "Total de Registros " + dataListado.Rows.Count;

        }
        private void CargarDatosNro()
        {
            dataListado.DataSource = CtrlProveedor.ListarOperacionesProveedorRUC(txtRuc.Text);

            this.dataListado.Columns.Cast<DataGridViewColumn>().ToList().ForEach(c => c.HeaderText = c.HeaderText.ToUpper());
            anchogrid();
            OcultarColumnas();
            lblCantidad.Text = "Total de Registros " + dataListado.Rows.Count;

        }
        private void FrmListaProveedor_Load(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void FrmListaProveedor_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void FrmListaProveedor_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtApPaterno_TextChanged(object sender, EventArgs e)
        {
            CargarDatosNom();
        }

        private void txtRuc_KeyPress(object sender, KeyPressEventArgs e)
        {
            val.SoloNumeros(e);
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                CargarDatosNro();
            }
        }

        private void txtApPaterno_KeyPress(object sender, KeyPressEventArgs e)
        {
            val.SoloLetras(e);
        }

        private void dataListado_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                FrmProveedor frm = FrmProveedor.GetInstancia();
                int telefono, movil, iddistrito, idprovincia, idregion, idpais;
                string ruc, razon, url, repre, email, direccion;

                ruc = Convert.ToString(this.dataListado.CurrentRow.Cells["RUC"].Value);
                razon = Convert.ToString(this.dataListado.CurrentRow.Cells["RAZÓN SOCIAL"].Value);
                url = Convert.ToString(this.dataListado.CurrentRow.Cells["Web"].Value);
                repre = Convert.ToString(this.dataListado.CurrentRow.Cells["REPRESENTANTE"].Value);
                telefono = Convert.ToInt32(this.dataListado.CurrentRow.Cells["TELÉFONO"].Value);
                movil = Convert.ToInt32(this.dataListado.CurrentRow.Cells["Movil"].Value);
                email = Convert.ToString(this.dataListado.CurrentRow.Cells["Email"].Value);
                direccion = Convert.ToString(this.dataListado.CurrentRow.Cells["dirección"].Value);
                iddistrito = Convert.ToInt32(this.dataListado.CurrentRow.Cells["IdDistrito"].Value);
                idprovincia = Convert.ToInt32(this.dataListado.CurrentRow.Cells["IdProvincia"].Value);
                idregion = Convert.ToInt32(this.dataListado.CurrentRow.Cells["IdRegion"].Value);
                idpais = Convert.ToInt32(this.dataListado.CurrentRow.Cells["IdPais"].Value);

                frm.setProveedor(ruc, razon, telefono, movil, email, url, repre, direccion, iddistrito, idprovincia, idregion, idpais);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);

            }
        }
        //Mostrar Mensaje de Confirmación
        private void MensajeOk(string mensaje)
        {
            MessageBox.Show(mensaje, "Sistema de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }


        //Mostrar Mensaje de Error
        private void MensajeError(string mensaje)
        {
            MessageBox.Show(mensaje, "Sistema de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        public void EliminarRegistros()
        {
            try
            {
                DialogResult Opcion;
                Opcion = MessageBox.Show("Realmente Desea elimnar los Registro", "Sistema de Ventas", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (Opcion == DialogResult.OK)
                {
                    string Codigo = Convert.ToString(dataListado.CurrentRow.Cells["RUC"].Value);
                    string Rpta = "";

                    Rpta = CtrlProveedor.Eliminar(Codigo);
                    if (Rpta.Equals("OK"))
                    {
                        this.MensajeOk("Se Eliminó Correctamente el registro");
                        CargarDatos();
                    }
                    else
                    {
                        this.MensajeError(Rpta);
                    }

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            EliminarRegistros();
        }
    }
}
