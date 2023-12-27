using ApplicationView.BusnessEntities.BE;
using ApplicationView.Forms.MsgBox;
using ApplicationView.Patern.singleton;
using ApplicationView.Resolver.HelperError.IExceptions;
using ApplicationView.Resolver.Security;
using ApplicationView.VariableSeesion;
using PlayerUI.Forms;
using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace ApplicationView.Forms.Account
{
    public partial class frmchangepass : Form
    {
        public frmchangepass()
        {
            InitializeComponent();
        }

        private void btnacept_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtoldpass.Text == String.Empty)
                {
                    RJMessageBox.Show("Ingresa la contraseña actual", "Sistema de ventas", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtoldpass.Text = String.Empty;
                    txtoldpass.Focus();
                }
                else if (txtoldpass.Text != PassValidation.GetInstance().Decrypt(LoginInfo.Pass))
                {
                    RJMessageBox.Show("Contraseña es diferente del actual", "Sistema de ventas", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtoldpass.Text = String.Empty;
                }
                else if (txtnewpass.Text == String.Empty)
                {
                    RJMessageBox.Show("Ingresa la nueva contraseña", "Sistema de ventas", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtnewpass.Text = String.Empty;
                    txtnewpass.Focus();
                }
                else if (txtnewpass.Text.Length >= 50)
                {
                    RJMessageBox.Show("la contraseña no puede tener mas de 50 caracteres", "Sistema de ventas", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtnewpass.Text = String.Empty;
                    txtnewpass.Focus();
                }
                else if (txtconfirmpass.Text == String.Empty)
                {
                    RJMessageBox.Show("Confirmar la nueva contraseña", "Sistema de ventas", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtconfirmpass.Text = String.Empty;
                    txtconfirmpass.Focus();
                }
                else if (txtnewpass.Text != txtconfirmpass.Text)
                {
                    RJMessageBox.Show("Contraseña confirmada es diferente de la nueva contraseña", "Sistema de ventas", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtconfirmpass.Text = String.Empty;
                    txtconfirmpass.Focus();
                }
                else
                {
                    var be = new AccountBE()
                    {
                        UserPass = PassValidation.GetInstance().Encypt(txtnewpass.Text.Trim()),
                        Confirm = true,
                        Id = LoginInfo.IdAccount,
                    };
                    var result = RepoPathern.AccountService.ChangePassword(be);
                    if (!string.IsNullOrEmpty(result))
                    {
                        LoginInfo.isChangePass = true;
                        RJMessageBox.Show(result+"\n Recuarda el proximo logueo, hay que usar la nueva contraseña.", "Sistema de ventas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    
                    //frmPrincipal frm = new frmPrincipal();
                    //frm.Close();

                    //newfrmlogin frmlog = new newfrmlogin();
                    this.Close();
                    //frmlog.ShowDialog();
                }
            }
            catch (ApiBusinessException ex)
            {
                RJMessageBox.Show(ex.MessageError, "Sistema de ventas", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception)
            {
                RJMessageBox.Show("No se encontró el servidor. Compruebe que el nombre de la instancia es correcto.", "Sistema de ventas", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btncancel_Click(object sender, EventArgs e)
        {
            Application.EnableVisualStyles();
            DialogResult result = new DialogResult();
            if (LoginInfo.isChangeCancelPass)
                result = RJMessageBox.Show("Debes cambiar la contraseña.\nEsta seguro que desees salir del sistema?", "Sistema de ventas", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            else
                result = RJMessageBox.Show("Esta seguro que desees salir sin cambiar la contraseña?", "Sistema de ventas", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                if (LoginInfo.isChangeCancelPass)
                    Application.Exit();
                this.Close();
            }
        }

        //Drag Form
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        //private void panelTitleBar_MouseDown(object sender, MouseEventArgs e)
        //{
        //    ReleaseCapture();
        //    SendMessage(this.Handle, 0x112, 0xf012, 0);
        //}

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.Style |= 0x20000; // <--- Minimize borderless form from taskbar
                return cp;
            }
        }

        private void frmchangepass_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
    }
}
