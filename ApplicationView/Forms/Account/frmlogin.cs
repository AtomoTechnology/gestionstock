using ApplicationView.BusnessEntities.BE;
using ApplicationView.Forms.Account;
using ApplicationView.Forms.Loading;
using ApplicationView.Forms.MsgBox;
using ApplicationView.Forms.turnswork;
using ApplicationView.Patern.singleton;
using ApplicationView.Resolver.HelperError.IExceptions;
using ApplicationView.VariableSeesion;
using System;
using System.Windows.Forms;

namespace ApplicationView
{
    public partial class frmlogin : Form
    {
        SplashForm loading;
        public frmlogin()
        {
            InitializeComponent();
            //_repopatern = repopatern;

            if (LoginInfo.ischange == true)
            {
                this.txtusername.Text = String.Empty;
                this.txtuserpass.Text = String.Empty;
            }
        }

        private async void timer1_Tick(object sender, EventArgs e)
        {
            label3.Text = DateTime.Now.ToLongTimeString(); // hora actual 
        }

        private async void frmlogin_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void btncancel_Click(object sender, EventArgs e)
        {
            foreach (Form frmlog in Application.OpenForms)
            {
                if (frmlog.GetType() == typeof(frmPrincipal))
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

        private async void btnacept_Click(object sender, EventArgs e)
        {
            try
            {
                loading = new SplashForm();
                loading.Show();

                string usuario = Convert.ToString(this.txtusername.Text);
                string password = Convert.ToString(this.txtuserpass.Text);

                if (string.IsNullOrEmpty(usuario))
                {
                    if (this.loading != null)
                        this.loading.Close();
                    RJMessageBox.Show("Ingrese el nombre de usuario", "Sistema de ventas", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.txtusername.Text = String.Empty;
                    this.txtusername.Focus();
                }
                else if (string.IsNullOrEmpty(password))
                {
                    if (this.loading != null)
                        this.loading.Close();
                    RJMessageBox.Show("Ingresa la contraseña", "Sistema de ventas", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.txtuserpass.Text = String.Empty;
                    this.txtuserpass.Focus();

                }
                else
                {
                    AccountBE Datos = await RepoPathern.AccountService.Login(usuario, password);
                    if (Datos == null)
                    {
                        if (this.loading != null)
                            this.loading.Close();
                        RJMessageBox.Show("Usuario y/o contraseña incorrecto", "Sistema de ventas", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.txtuserpass.Text = String.Empty;
                        this.txtuserpass.Focus();

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

                        LoginInfo.isChangeCancelPass = true;
                        if (this.loading != null)
                            this.loading.Close();

                        frmchangepass pass = new frmchangepass();
                        pass.Show();
                    }
                    else
                    {
                        LoginInfo.IdAccount = Datos.Id;
                        LoginInfo.IdUser = Datos.UserId;
                        LoginInfo.IdRole = Datos.RoleId;
                        LoginInfo.UserName = Datos.UserName;
                        LoginInfo.Pass = Datos.UserPass;
                        LoginInfo.Access = Datos.Role.RoleName;
                        LoginInfo.IdBusiness = Datos.User.BusinessId;
                        LoginInfo.isChangeCancelPass = false;

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
                RJMessageBox.Show(ex.MessageError, "Sistema de ventas", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                if (ex.Message.Equals("Object reference not set to an instance of an object."))
                    RJMessageBox.Show("No se encontró el servidor. Compruebe que el nombre de la instancia es correcto.", "Sistema de ventas", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                    RJMessageBox.Show("No se pudo conectar! Contacte al administrador.", "Sistema de ventas", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
