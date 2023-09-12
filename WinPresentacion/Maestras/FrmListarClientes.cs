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
    public partial class FrmListarClientes : Form
    {
        Validar val = new Validar();
        CtrlCliente CtrlCliente = new CtrlCliente();
        public FrmListarClientes()
        {
            InitializeComponent();
        }
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
        private void FrmListarClientes_Load(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void FrmListarClientes_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        private void OcultarColumnas()
        {
            this.dataListado.Columns[15].Visible = false;
            this.dataListado.Columns[16].Visible = false;
            this.dataListado.Columns[17].Visible = false;
            this.dataListado.Columns[18].Visible = false;
            this.dataListado.Columns[19].Visible = false;
            this.dataListado.Columns[20].Visible = false;
            this.dataListado.Columns[8].Visible = false;
            this.dataListado.Columns[0].Visible = false;
        }
        public void anchogrid()
        {

            this.dataListado.Columns[1].Width = 100;
            this.dataListado.Columns[2].Width = 148;
            this.dataListado.Columns[3].Width = 148;
            this.dataListado.Columns[4].Width = 130;
            this.dataListado.Columns[5].Width = 130;
            this.dataListado.Columns[6].Width = 110;
            this.dataListado.Columns[7].Width = 110;
            this.dataListado.Columns[9].Width = 150;
            this.dataListado.Columns[10].Width = 150;
            this.dataListado.Columns[11].Width = 150;
            this.dataListado.Columns[12].Width = 150;
            this.dataListado.Columns[13].Width = 150;
            this.dataListado.Columns[14].Width = 120;

        }

        private void CargarDatos()
        {
            dataListado.DataSource = CtrlCliente.ListarOperacionesTodos();
            this.dataListado.Columns.Cast<DataGridViewColumn>().ToList().ForEach(c => c.HeaderText = c.HeaderText.ToUpper());
            anchogrid();
            OcultarColumnas();
            lblCantidad.Text = "Total de Registros " + dataListado.Rows.Count;

        }
        private void CargarDatosNom()
        {
            dataListado.DataSource = CtrlCliente.ListarOperacionesClienteApPaterno(txtApPaterno.Text);
            this.dataListado.Columns.Cast<DataGridViewColumn>().ToList().ForEach(c => c.HeaderText = c.HeaderText.ToUpper());
            anchogrid();
            OcultarColumnas();
            lblCantidad.Text = "Total de Registros " + dataListado.Rows.Count;

        }
        private void CargarDatosNro()
        {
            dataListado.DataSource = CtrlCliente.ListarOperacionesClientesDNI(txtNumero.Text);

            this.dataListado.Columns.Cast<DataGridViewColumn>().ToList().ForEach(c => c.HeaderText = c.HeaderText.ToUpper());
            anchogrid();
            OcultarColumnas();
            lblCantidad.Text = "Total de Registros " + dataListado.Rows.Count;

        }

        private void dataListado_DoubleClick(object sender, EventArgs e)
        {
            FrmClientes frm = FrmClientes.GetInstancia();
            int IdTipoDoc, sexo, telefono, movil, iddistrito, idprovincia, idregion, idpais;
            string Numero, ApPaterno, ApMaterno, pN, SN, email, direccion;
            IdTipoDoc = Convert.ToInt32(this.dataListado.CurrentRow.Cells["IdTipoDoc"].Value);
            Numero = Convert.ToString(this.dataListado.CurrentRow.Cells["NÚMERO"].Value);
            ApPaterno = Convert.ToString(this.dataListado.CurrentRow.Cells["A. Paterno"].Value);
            ApMaterno = Convert.ToString(this.dataListado.CurrentRow.Cells["A. Materno"].Value);
            pN = Convert.ToString(this.dataListado.CurrentRow.Cells["P. Nombre"].Value);
            SN = Convert.ToString(this.dataListado.CurrentRow.Cells["S. Nombre"].Value);
            sexo = Convert.ToInt32(this.dataListado.CurrentRow.Cells["IdSexo"].Value);
            telefono = Convert.ToInt32(this.dataListado.CurrentRow.Cells["TELÉFONO"].Value);
            movil = Convert.ToInt32(this.dataListado.CurrentRow.Cells["CEL"].Value);
            email = Convert.ToString(this.dataListado.CurrentRow.Cells["Email"].Value);
            direccion = Convert.ToString(this.dataListado.CurrentRow.Cells["dirección"].Value);
            iddistrito = Convert.ToInt32(this.dataListado.CurrentRow.Cells["IdDistrito"].Value);
            idprovincia = Convert.ToInt32(this.dataListado.CurrentRow.Cells["IdProvincia"].Value);
            idregion = Convert.ToInt32(this.dataListado.CurrentRow.Cells["IdRegion"].Value);
            idpais = Convert.ToInt32(this.dataListado.CurrentRow.Cells["IdPais"].Value);
            frm.setCliente(IdTipoDoc, Numero, ApPaterno, ApMaterno, pN, SN, sexo, telefono, movil, email, direccion, iddistrito, idprovincia, idregion, idpais);
            this.Close();
        }

        private void txtNumero_KeyPress(object sender, KeyPressEventArgs e)
        {
            val.SoloNumeros(e);
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                CargarDatosNro();
            }
        }

        private void txtApPaterno_TextChanged(object sender, EventArgs e)
        {
            
            CargarDatosNom();
        }

        private void txtApPaterno_KeyPress(object sender, KeyPressEventArgs e)
        {
            val.SoloLetras(e);
        }
        public void EliminarRegistros()
        {
            try
            {
                DialogResult Opcion;
                Opcion = MessageBox.Show("Realmente Desea Eliminar los Registros", "Sistema de Ventas", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (Opcion == DialogResult.OK)
                {
                    string Codigo = Convert.ToString(dataListado.CurrentRow.Cells["NÚMERO"].Value);
                    string Rpta = "";

                    Rpta = CtrlCliente.Eliminar(Codigo);
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

        private void dataListado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
