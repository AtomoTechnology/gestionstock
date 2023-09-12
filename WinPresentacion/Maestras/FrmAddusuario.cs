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
    public partial class FrmAddusuario : Form
    {
        CtrlUsuario CtrlUsuario = new CtrlUsuario();
        Seguridad encri = new Seguridad();
        CtrlPersonal CtrlPersonal = new CtrlPersonal();
        public FrmAddusuario()
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
        public void CargarUsuarios()
        {
            gvUsuarios.DataSource = CtrlUsuario.ListarUsuarios();
            gvUsuarios.Columns[0].Visible = false;
            gvUsuarios.Columns[4].Visible = false;
            gvUsuarios.Columns[1].Width = 400;
            gvUsuarios.Columns[2].Width = 169;
            gvUsuarios.Columns[3].Width = 220;
        }
        public void CargarUsuariosDNI()
        {
            gvUsuarios.DataSource = CtrlUsuario.ListarUsuariosDNI(txtDNI.Text);
            gvUsuarios.Columns[4].Visible = false;
            gvUsuarios.Columns[0].Visible = false;
            gvUsuarios.Columns[1].Width = 400;
            gvUsuarios.Columns[2].Width = 169;
            gvUsuarios.Columns[3].Width = 220;
        }
        public void Guardar()
        {
            try
            {
                string rpta = "";
                if (this.txtUsuario.Text == string.Empty || this.txtClave.Text == string.Empty)
                {
                    MensajeError("Falta ingresar algunos datos, serán remarcados");
                    errorIcono.SetError(txtClave, "Ingrese un Valor");
                    errorIcono.SetError(txtRepitaClave, "Ingrese un Valor");
                    errorIcono.SetError(txtUsuario, "Ingrese un Valor");

                }
                else
                {
                    if (txtClave.Text == txtRepitaClave.Text)
                    {

                        var Usuario = txtUsuario.Text;
                        var Clave = txtClave.Text;
                        rpta = CtrlUsuario.Insertar(Usuario, encri.EncryptKey(Clave), comboBox1.SelectedValue.ToString());

                        if (rpta.Equals("OK"))
                        {

                            this.MensajeOk("Cuenta Creada Correctamente");
                            CargarPersona();
                            txtUsuario.Text = string.Empty;
                            txtClave.Text = string.Empty;
                            txtRepitaClave.Text = string.Empty;
                            CargarUsuarios();

                        }
                        else
                        {
                            this.MensajeError(rpta);

                            txtUsuario.Text = string.Empty;
                            txtClave.Text = string.Empty;
                            txtRepitaClave.Text = string.Empty;
                        }

                    }



                    else
                    {
                        MessageBox.Show("Las Claves deben ser iguales", "Decor Mayo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }
        private void CargarPersona()
        {
            comboBox1.DataSource = CtrlPersonal.lsPersonaCrearCuenta();
            comboBox1.ValueMember = "DNI";
            comboBox1.DisplayMember = "Persona";


        }
        //metodo para cargar la coleccion de datos para el autocomplete
        public static AutoCompleteStringCollection Autocomplete()
        {
            CtrlPersonal cy = new CtrlPersonal();
            DataTable dt = cy.lsPersonaCrearCuenta();

            AutoCompleteStringCollection coleccion = new AutoCompleteStringCollection();
            //recorrer y cargar los items para el autocompletado
            foreach (DataRow row in dt.Rows)
            {
                coleccion.Add(Convert.ToString(row["Persona"]));
            }

            return coleccion;
        }
      
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]

        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void FrmAddusuario_Load(object sender, EventArgs e)
        {
            CargarUsuarios();
            Top = 40;
            Left = 40;
            CargarPersona();
            comboBox1.AutoCompleteCustomSource = Autocomplete();
            comboBox1.AutoCompleteMode = AutoCompleteMode.Suggest;
            comboBox1.AutoCompleteSource = AutoCompleteSource.CustomSource;
        }

        private void FrmAddusuario_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            comboBox1.Text = string.Empty;
            txtUsuario.Text = string.Empty;
            txtClave.Text = string.Empty;
            txtRepitaClave.Text = string.Empty;
        }

        private void btnCrearCuenta_Click(object sender, EventArgs e)
        {
            Guardar();
        }

        private void txtDNI_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                CargarUsuariosDNI();
            }
        }

        private void gvUsuarios_Click(object sender, EventArgs e)
        {
            lblClave.Text = encri.DecryptKey(gvUsuarios.CurrentRow.Cells["Clave"].Value.ToString());
            lblClave.Visible = true;
        }
        public void Actualizar()
        {
            try
            {
                string rpta = "";
                if (this.txtRepitaClave.Text == string.Empty || this.txtClave.Text == string.Empty)
                {
                    MensajeError("Falta ingresar algunos datos, serán remarcados");
                    errorIcono.SetError(txtClave, "Ingrese un Valor");
                    errorIcono.SetError(txtDNI, "Ingrese un Valor");
                    errorIcono.SetError(txtRepitaClave, "Ingrese un Valor");
                }
                else
                {
                    if (txtClave.Text == txtRepitaClave.Text)
                    {
                        var Clave = txtClave.Text;
                        rpta = CtrlUsuario.Actualizar(encri.EncryptKey(Clave), txtDNI.Text);

                        if (rpta.Equals("OK"))
                        {

                            this.MensajeOk("Cuenta Actualizada Correctamente");
                            txtDNI.Text = string.Empty;
                            txtUsuario.Text = string.Empty;
                            txtClave.Text = string.Empty;
                            txtRepitaClave.Text = string.Empty;
                            this.CargarUsuarios();

                        }
                        else
                        {
                            this.MensajeError(rpta);
                            txtDNI.Text = string.Empty;
                            txtUsuario.Text = string.Empty;
                            txtClave.Text = string.Empty;
                            txtRepitaClave.Text = string.Empty;
                        }

                    }




                    else
                    {
                        MessageBox.Show("Las Claves deben ser iguales", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            if (txtDNI.Text == "")
            {
                MessageBox.Show("Haga doble clic sobre el usuario que desea actualizar clave", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                Actualizar();

            }
        }

        private void gvUsuarios_DoubleClick(object sender, EventArgs e)
        {
            txtUsuario.Enabled = false;
            comboBox1.Enabled = false;
            try
            {

                this.txtDNI.Text = gvUsuarios.CurrentRow.Cells["DNI"].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
        }
    }
}
