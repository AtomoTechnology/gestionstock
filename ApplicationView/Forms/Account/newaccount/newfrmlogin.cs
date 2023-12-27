using ApplicationView;
using ApplicationView.BusnessEntities.BE;
using ApplicationView.Forms.Account;
using ApplicationView.Forms.Loading;
using ApplicationView.Forms.MsgBox;
using ApplicationView.Patern.singleton;
using ApplicationView.Resolver.HelperError.IExceptions;
using ApplicationView.VariableSeesion;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PlayerUI.Forms
{
    public partial class newfrmlogin : Form
    {
        SplashForm loading;
        public newfrmlogin()
        {
            InitializeComponent();
            Shown += Newfrmlogin_Shown;
        }

        private void Newfrmlogin_Shown(object sender, EventArgs e)
        {
            txtuser.Focus();
        }

        #region Drag Form/ Mover Arrastrar Formulario
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);
        private void frmlogin_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        #endregion

        #region  Placeholder or WaterMark
        private void txtuser_Enter(object sender, EventArgs e)
        {
            if (txtuser.Text == "Usuario")
            {
                txtuser.Text = "";
                //txtuser.ForeColor = Color.LightGray;
            }
        }
        private void txtuser_Leave(object sender, EventArgs e)
        {
            if (txtuser.Text == "")
            {
                txtuser.Text = "Usuario";
                //txtuser.ForeColor = Color.Silver;
            }
        }
        private void txtpass_Enter(object sender, EventArgs e)
        {
            if (txtpass.Text == "Contraseña")
            {
                txtpass.Text = "";
                //txtpass.ForeColor = Color.LightGray;
                txtpass.UseSystemPasswordChar = true;
            }
        }

        private void txtpass_Leave(object sender, EventArgs e)
        {
            if (txtpass.Text == "")
            {
                txtpass.Text = "Contraseña";
                //txtpass.ForeColor = Color.Silver;
                txtpass.UseSystemPasswordChar = false;
            }
        }
        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (Form frmlog in Application.OpenForms)
            {
                if (frmlog.GetType() == typeof(frmprincipal))
                {
                    frmlog.Close();
                    break;
                }
                else
                {
                    frmlog.Close();
                    break;
                }
            }
        }

        private async void btnlogin_Click(object sender, EventArgs e)
        {
            try
            {
                loading = new SplashForm();
                loading.Show();

                string usuario = this.txtuser.Text;
                string password = this.txtpass.Text;

                if (string.IsNullOrEmpty(usuario))
                {
                    if (this.loading != null)
                        this.loading.Close();
                    RJMessageBox.Show("Ingrese el nombre de usuario", "Sistema de ventas", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.txtuser.Text = String.Empty;
                    this.txtuser.Focus();
                }
                else if (string.IsNullOrEmpty(password))
                {
                    if (this.loading != null)
                        this.loading.Close();
                    RJMessageBox.Show("Ingresa la contraseña", "Sistema de ventas", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.txtpass.Text = String.Empty;
                    this.txtpass.Focus();

                }
                else
                {
                    AccountBE Datos = await RepoPathern.AccountService.Login(usuario, password);
                    if (Datos == null)
                    {
                        if (this.loading != null)
                            this.loading.Close();
                        RJMessageBox.Show("Usuario y/o contraseña incorrecto", "Sistema de ventas", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.txtuser.Text = String.Empty;
                        this.txtpass.Text = String.Empty;
                        this.txtuser.Focus();

                    }
                    else if (Datos.Confirm == false)
                    {

                        LoginInfo.IdAccount = Datos.Id;
                        LoginInfo.IdUser = Datos.UserId;
                        LoginInfo.IdRole = Datos.RoleId;
                        LoginInfo.UserName = Datos.UserName;
                        LoginInfo.Pass = Datos.UserPass;
                        LoginInfo.Access = Datos.Role.RoleName;
                        LoginInfo.IdBusiness = Datos.User.BusinessId;

                        LoginInfo.FirstName = Datos.FirstName;
                        LoginInfo.LastName = Datos.LastName;

                        this.txtuser.Text = String.Empty;
                        this.txtpass.Text = String.Empty;
                        var openwornturn = RepoPathern.OpenWorkRepoService.GetOpenWorkTurnByAccountId(Datos.Id);
                        if (openwornturn != null)
                        {
                            LoginInfo.OpenWorkTurnId = openwornturn.Id;
                            LoginInfo.TurnId = openwornturn.TurnId;
                        }

                        LoginInfo.isChangeCancelPass = true;
                        if (this.loading != null)
                            this.loading.Close();

                        frmchangepass pass = new frmchangepass();
                        pass.Show();
                        this.Hide();
                    }
                    else
                    {
                        LoginInfo.IdAccount = Datos.Id;
                        LoginInfo.IdUser = Datos.UserId;
                        LoginInfo.IdRole = Datos.RoleId;
                        LoginInfo.UserName = Datos.UserName;
                        LoginInfo.Pass = Datos.UserPass;
                        LoginInfo.Access = Datos.Role.RoleName;
                        LoginInfo.Role = LoginInfo.Access;
                        LoginInfo.IdBusiness = Datos.User.BusinessId;
                        LoginInfo.isChangeCancelPass = false;

                        LoginInfo.FirstName = Datos.FirstName;
                        LoginInfo.LastName = Datos.LastName;

                        var openwornturn = RepoPathern.OpenWorkRepoService.GetOpenWorkTurnByAccountId(Datos.Id);
                        if (openwornturn != null)
                        {
                            LoginInfo.OpenWorkTurnId = openwornturn.Id;
                            LoginInfo.TurnId = openwornturn.TurnId;
                        }

                        this.txtuser.Text = String.Empty;
                        this.txtpass.Text = String.Empty;

                        if (this.loading != null)
                            this.loading.Close();

                        frmprincipal principal = new frmprincipal(Datos);
                        principal.Show();
                        this.Hide();

                    }
                }
            }
            catch (ApiBusinessException ex)
            {
                RJMessageBox.Show(ex.MessageError, "Sistema de ventas", MessageBoxButtons.OK, MessageBoxIcon.Error); if (this.loading != null)
                    this.loading.Close();
            }
            catch (Exception ex)
            {
                if (ex.Message.Equals("Object reference not set to an instance of an object."))
                    RJMessageBox.Show("No se encontró el servidor. Compruebe que el nombre de la instancia es correcto.", "Sistema de ventas", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                    RJMessageBox.Show("No se pudo conectar! Contacte al administrador.", "Sistema de ventas", MessageBoxButtons.OK, MessageBoxIcon.Error); 
                if (this.loading != null)
                    this.loading.Close();
            }
        }
    }
}
