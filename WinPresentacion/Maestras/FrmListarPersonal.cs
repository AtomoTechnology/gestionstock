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
    public partial class FrmListarPersonal : Form
    {

        CtrlPersonal CtrlPersonal = new CtrlPersonal();
        Validar val = new Validar();
        public FrmListarPersonal()
        {
            InitializeComponent();
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
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]

        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        private void FrmListarPersonal_Load(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void FrmListarPersonal_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        private void OcultarColumnas()
        {
            this.dataListado.Columns[18].Visible = false;
            this.dataListado.Columns[8].Visible = false;
            this.dataListado.Columns[6].Visible = false;
            this.dataListado.Columns[19].Visible = false;
            this.dataListado.Columns[20].Visible = false;
            this.dataListado.Columns[21].Visible = false;
            this.dataListado.Columns[22].Visible = false;
            this.dataListado.Columns[17].Visible = false;
            this.dataListado.Columns[18].Visible = false;

        }
        public void anchogrid()
        {
            this.dataListado.Columns[0].Width = 80;
            this.dataListado.Columns[1].Width = 150;
            this.dataListado.Columns[2].Width = 150;
            this.dataListado.Columns[3].Width = 150;
            this.dataListado.Columns[4].Width = 150;
            this.dataListado.Columns[5].Width = 160;
            this.dataListado.Columns[7].Width = 100;
            this.dataListado.Columns[9].Width = 90;
            this.dataListado.Columns[10].Width = 130;
            this.dataListado.Columns[11].Width = 150;
            this.dataListado.Columns[12].Width = 150;
            this.dataListado.Columns[13].Width = 160;
            this.dataListado.Columns[14].Width = 150;
            this.dataListado.Columns[15].Width = 130;
            this.dataListado.Columns[16].Width = 120;
        }

        private void CargarDatos()
        {
            dataListado.DataSource = CtrlPersonal.ListarOperacionesTodos();
            this.dataListado.Columns.Cast<DataGridViewColumn>().ToList().ForEach(c => c.HeaderText = c.HeaderText.ToUpper());
            anchogrid();
            OcultarColumnas();
            lblCantidad.Text = "Total de Registros " + dataListado.Rows.Count;

        }
        private void CargarDatosNom()
        {
            dataListado.DataSource = CtrlPersonal.ListarOperacionesPersonalApPaterno(txtApPaterno.Text);
            this.dataListado.Columns.Cast<DataGridViewColumn>().ToList().ForEach(c => c.HeaderText = c.HeaderText.ToUpper());
            anchogrid();
            OcultarColumnas();
            lblCantidad.Text = "Total de Registros " + dataListado.Rows.Count;

        }
        private void CargarDatosNro()
        {
            dataListado.DataSource = CtrlPersonal.ListarOperacionesPersonalDNI(txtDNI.Text);

            this.dataListado.Columns.Cast<DataGridViewColumn>().ToList().ForEach(c => c.HeaderText = c.HeaderText.ToUpper());
            anchogrid();
            OcultarColumnas();
            lblCantidad.Text = "Total de Registros " + dataListado.Rows.Count;

        }

        private void txtApPaterno_TextChanged(object sender, EventArgs e)
        {
            CargarDatosNom();
        }

        private void txtDNI_KeyPress(object sender, KeyPressEventArgs e)
        {
            val.SoloNumeros(e);
            if (e.KeyChar == Convert.ToChar(Keys.Enter)) ;
            {
                CargarDatosNro();
            }
        }
        public void EliminarRegistros()
        {
            try
            {
                DialogResult Opcion;
                Opcion = MessageBox.Show("Realmente Desea elimnar los Registro", "Sistema de Ventas", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (Opcion == DialogResult.OK)
                {
                    string Codigo = Convert.ToString(dataListado.CurrentRow.Cells["DNI"].Value);
                    string Rpta = "";

                    Rpta = CtrlPersonal.Eliminar(Codigo);
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

        private void dataListado_DoubleClick(object sender, EventArgs e)
        {
            FrmPersonal frm = FrmPersonal.GetInstancia();
            int sexo, telefono, movil, iddistrito, idprovincia, idregion, idpais, idcargo;
            string Numero, ApPaterno, ApMaterno, pN, SN, email, direccion;
            byte[] foto;
            DateTime fecha;
            Numero = Convert.ToString(this.dataListado.CurrentRow.Cells["DNI"].Value);
            ApPaterno = Convert.ToString(this.dataListado.CurrentRow.Cells["A. Paterno"].Value);
            ApMaterno = Convert.ToString(this.dataListado.CurrentRow.Cells["A. MATERNO"].Value);
            pN = Convert.ToString(this.dataListado.CurrentRow.Cells["P. Nombre"].Value);
            SN = Convert.ToString(this.dataListado.CurrentRow.Cells["S. Nombre"].Value);
            fecha = Convert.ToDateTime(this.dataListado.CurrentRow.Cells["F. Nacimiento"].Value);
            sexo = Convert.ToInt32(this.dataListado.CurrentRow.Cells["IdSexo"].Value);
            telefono = Convert.ToInt32(this.dataListado.CurrentRow.Cells["Teléfono"].Value);
            movil = Convert.ToInt32(this.dataListado.CurrentRow.Cells["Movil"].Value);
            email = Convert.ToString(this.dataListado.CurrentRow.Cells["Email"].Value);
            direccion = Convert.ToString(this.dataListado.CurrentRow.Cells["dirección"].Value);
            iddistrito = Convert.ToInt32(this.dataListado.CurrentRow.Cells["IdDistrito"].Value);
            idprovincia = Convert.ToInt32(this.dataListado.CurrentRow.Cells["IdProvincia"].Value);
            idregion = Convert.ToInt32(this.dataListado.CurrentRow.Cells["IdRegion"].Value);
            idpais = Convert.ToInt32(this.dataListado.CurrentRow.Cells["IdPais"].Value);
            foto = (byte[])this.dataListado.CurrentRow.Cells["Foto"].Value;
            idcargo = Convert.ToInt32(this.dataListado.CurrentRow.Cells["IdCargo"].Value);
            frm.setCliente(Numero, ApPaterno, ApMaterno, pN, SN, fecha, sexo, telefono, movil, email, direccion, iddistrito, idprovincia, idregion, idpais, idcargo, foto);
            this.Close();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
