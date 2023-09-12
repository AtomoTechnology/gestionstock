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
using Datos;
using Negocio;
namespace WinPresentacion
{
    public partial class FrmLogin : Form
    {
        CtrlUsuario CtrlUsuario = new CtrlUsuario();
        DTUsuario CDUsuario = new DTUsuario();
        MDIContenedor MDI = MDIContenedor.GetInstancia();
        Maestras.Seguridad encri = new Maestras.Seguridad();
        public FrmLogin()
        {
            InitializeComponent();
        }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]

        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        private void FrmLogin_Load(object sender, EventArgs e)
        {

        }
        public void Ingresar()
        {
            try
            {

                if (txtUser.TextLength > 0 && txtClave.TextLength > 0)
                {
                    var Usuario = txtUser.Text;
                    var Clave = txtClave.Text;


                    DataTable Datos = CtrlUsuario.Login(Usuario, encri.EncryptKey(Clave));
                    //Evaluar si existe el Usuario
                    //Evaluar si existe el Usuario
                    if (Datos.Rows.Count == 0)
                    {
                        MessageBox.Show("NO Tiene Acceso al Sistema", "Sistema de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {

                        MDI.DNI = Datos.Rows[0][0].ToString();
                        MDI.Cargo = Datos.Rows[0][3].ToString();
                        MDI.lblCargo.Text = Datos.Rows[0][3].ToString();
                        MDI.lblUsuario.Text = "USUARIO: " + Datos.Rows[0][1].ToString() + " " + Datos.Rows[0][2].ToString(); ;

                        byte[] imagenBuffer = (byte[])Datos.Rows[0][4];
                        System.IO.MemoryStream ms = new System.IO.MemoryStream(imagenBuffer);

                        MDI.pbFoto.Image = Image.FromStream(ms);
                        MDI.pbFoto.SizeMode = PictureBoxSizeMode.StretchImage;
                        MDI.Show();
                        this.Hide();

                    }

                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }
        private void FrmLogin_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnmin_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void btncerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            Ingresar();
        }
    }
}
