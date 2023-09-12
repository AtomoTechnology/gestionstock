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
    public partial class FrmMarcas : Form
    {
        Validar Val = new Validar();

        private bool IsNuevo = false;
        private bool IsEditar = false;

        private static FrmMarcas _instancia;

        public static FrmMarcas GetInstancia()
        {
            if (_instancia == null)
            {
                _instancia = new FrmMarcas();
            }
            return _instancia;
        }
        public void setMarca(int IdMarca, string Marca)
        {
            txtIdMarca.Text = Convert.ToString(IdMarca);
            txtDescUnidad.Text = Marca;
        }
        public FrmMarcas()
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
            MessageBox.Show(mensaje, "Decor Mayo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        //Limpiar todos los controles del formulario
        private void Limpiar()
        {
            this.txtDescUnidad.Text = string.Empty;
            this.txtIdMarca.Text = string.Empty;


        }

        //Habilitar los controles del formulario
        private void Habilitar(bool valor)
        {
            //this.txtNumDocumento.ReadOnly = !valor;
            this.txtDescUnidad.ReadOnly = !valor;

        }

        //Habilitar los botones
        private void Botones()
        {
            if (this.IsNuevo || this.IsEditar) //Alt + 124
            {
                this.Habilitar(true);
                this.btnNuevo.Enabled = false;
                this.btnGuardar.Enabled = true;
                this.btnEditar.Enabled = false;
                this.btnCancelar.Enabled = true;
            }
            else
            {
                this.Habilitar(false);
                this.btnNuevo.Enabled = true;
                this.btnGuardar.Enabled = false;
                this.btnEditar.Enabled = true;
                this.btnCancelar.Enabled = false;
            }

        }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]

        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        private void FrmMarcas_Load(object sender, EventArgs e)
        {
            this.Top = 40;
            this.Left = 40;
            this.Habilitar(false);
            this.Botones();
        }
        public void Nuevo()
        {
            this.IsNuevo = true;
            this.IsEditar = false;
            this.Botones();
            this.Limpiar();
            this.Habilitar(true);
            this.txtDescUnidad.Focus();
        }
        public void Editar()
        {
            if (!this.txtIdMarca.Text.Equals(""))
            {
                this.IsEditar = true;
                this.Botones();
                this.Habilitar(true);
            }
            else
            {
                this.MensajeError("Busque Marca a Modificar");
            }
        }
        public void Guardar()
        {
            try
            {
                string rpta = "";
                if (this.txtDescUnidad.Text == string.Empty)
                {
                    MensajeError("Falta ingresar algunos datos, serán remarcados");
                    errorIcono.SetError(txtDescUnidad, "Ingrese un Valor");

                }
                else
                {
                    if (this.IsNuevo)
                    {
                        rpta = CtrlMarca.Insertar(this.txtDescUnidad.Text);

                    }
                    else
                    {
                        rpta = CtrlMarca.Editar(Convert.ToInt32(this.txtIdMarca.Text), txtDescUnidad.Text);
                    }

                    if (rpta.Equals("OK"))
                    {
                        if (this.IsNuevo)
                        {
                            this.MensajeOk("Se Insertó de forma correcta el registro");
                        }
                        else
                        {
                            this.MensajeOk("Se Actualizó de forma correcta el registro");
                        }
                    }
                    else
                    {
                        this.MensajeError(rpta);
                    }

                    this.IsNuevo = false;
                    this.IsEditar = false;
                    this.Botones();
                    this.Limpiar();



                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        public void Cancelar()
        {
            this.IsNuevo = false;
            this.IsEditar = false;
            this.Botones();
            this.Habilitar(false);
            this.Limpiar();
            //this.txtIdcliente.Text = string.Empty;
        }


        private void FrmMarcas_FormClosing(object sender, FormClosingEventArgs e)
        {
            _instancia = null;
        }

        private void FrmMarcas_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Nuevo();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            Editar();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Guardar();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Cancelar();
        }

        private void btnListar_Click(object sender, EventArgs e)
        {
            FrmListaMarcas vista = new FrmListaMarcas();
            vista.ShowDialog();
        }
    }
}
