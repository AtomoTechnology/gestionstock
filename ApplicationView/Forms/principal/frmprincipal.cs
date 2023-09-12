using ApplicationView.BusnessEntities.BE;
using ApplicationView.Forms.Account;
using ApplicationView.Forms.Business;
using ApplicationView.Forms.Category;
using ApplicationView.Forms.Configurations;
using ApplicationView.Forms.Loading;
using ApplicationView.Forms.MsgBox;
using ApplicationView.Forms.Product;
using ApplicationView.Forms.Provider;
using ApplicationView.Forms.Roles;
using ApplicationView.Forms.Sale;
using ApplicationView.Forms.turnswork;
using ApplicationView.Forms.User;
using ApplicationView.Patern.singleton;
using ApplicationView.Theme;
using ApplicationView.VariableSeesion;
using PlayerUI.Forms;
using System;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace ApplicationView
{
    public partial class frmprincipal : Form
    {
        private Random random;
        private Button currentButton;
        private int tempIndex;
        private Form activeForm;

        SplashForm loading;
        public frmprincipal(AccountBE Datos)
        {
            InitializeComponent();
            this.SegundVersion();

            random = new Random();
            btnCloseChildForm.Visible = false;
            btnCloseChildForm.Visible = false;
            this.ControlBox = false;
            //this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;

            hideSubMenu();
            this.GetPermission(Datos);
            showSubMenu(panelSaleSubMenu);
            //openChildForm(new frmsale(), btnstartsale, panelSaleSubMenu.Controls);
        }
        private void hideSubMenu()
        {
            panelSaleSubMenu.Visible = false;
            panelProductSubMenu.Visible = false;
            panelProviderSubMenu.Visible = false; 
            panelMovmentSubMenu.Visible = false;
            panelReportSubMenu.Visible = false;
            panelSeguridySubMenu.Visible = false;
            panelSysGesSubMenu.Visible = false;
            panelUserSubMenu.Visible = false;
            btnmodifyrol.Visible = false;


        }

        private void showSubMenu(Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                hideSubMenu();
                subMenu.Visible = true;
            }
            else
                subMenu.Visible = false;
        }

        private void btnMedia_Click(object sender, EventArgs e)
        {
            showSubMenu(panelSaleSubMenu);
        }

        #region MediaSubMenu
        private void button2_Click(object sender, EventArgs e)
        {
            this.ShowLoading();
            //DisableButton(panelSaleSubMenu.Controls);
            openChildForm(new frmsale(), sender, panelSaleSubMenu.Controls);
            this.CloseLoading();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.ShowLoading();
            //DisableButton(panelSaleSubMenu.Controls);
            openChildForm(new frmsalehistoric(), sender, panelSaleSubMenu.Controls);
            this.CloseLoading();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.ShowLoading();
            //DisableButton(panelSaleSubMenu.Controls);
            openChildForm(new frmcheckprice(), sender, panelSaleSubMenu.Controls);
            this.CloseLoading();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //..
            //your codes
            //..
            hideSubMenu();
        }
        #endregion

        private void btnPlaylist_Click(object sender, EventArgs e)
        {
            showSubMenu(panelProductSubMenu);
        }

        #region PlayListManagemetSubMenu
        private void button8_Click(object sender, EventArgs e)
        {
            this.ShowLoading();
            //DisableButton(panelProductSubMenu.Controls);
            openChildForm(new frmProduct(), sender, panelProductSubMenu.Controls);
            this.CloseLoading();
        }

        private void button7_Click(object sender, EventArgs e)
        {                       
            this.ShowLoading();
            //DisableButton(panelProductSubMenu.Controls);
            openChildForm(new frmiexpiredDate(), sender, panelProductSubMenu.Controls);
            this.CloseLoading();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //DisableButton(panelProductSubMenu.Controls);
            //hideSubMenu();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            hideSubMenu();
        }
        #endregion

        private void btnTools_Click(object sender, EventArgs e)
        {
            showSubMenu(panelProviderSubMenu);
        }
        #region ToolsSubMenu
        private void button13_Click(object sender, EventArgs e)
        {
            this.ShowLoading();
            //DisableButton(panelProviderSubMenu.Controls);
            openChildForm(new frmprovider(), sender, panelProviderSubMenu.Controls);
            this.CloseLoading();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            //..
            //your codes
            //..
            //hideSubMenu();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            //..
            //your codes
            //..
            hideSubMenu();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            //..
            //your codes
            //..
            hideSubMenu();
        }
        #endregion

        private void btnEqualizer_Click(object sender, EventArgs e)
        {
            hideSubMenu();
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            hideSubMenu();
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            showSubMenu(panelSysGesSubMenu);
        }
        private void openChildForm(Form childForm, object btnSender, Control.ControlCollection Controls)
        {
            try
            {
                if (activeForm != null)
                    activeForm.Close();

                if (!LoginInfo.IsSaleNoneClose)
                    return;

                ActivateButton(btnSender, Controls);
                activeForm = childForm;
                childForm.TopLevel = false;
                //childForm.FormBorderStyle = FormBorderStyle.None;
                //childForm.Dock = DockStyle.Fill;
                //panelChildForm.Controls.Add(childForm);
                //panelChildForm.Tag = childForm;
                childForm.BringToFront();
                childForm.MdiParent = this;
                childForm.Show();
                lblTItle.Text = childForm.Text;
            }
            catch (Exception ex)
            {
                RJMessageBox.Show(ex.Message, "Sistema de ventas", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnMovements_Click(object sender, EventArgs e)
        {

            showSubMenu(panelMovmentSubMenu);
        }

        private void btnReport_Click(object sender, EventArgs e)
        {

            showSubMenu(panelReportSubMenu);
        }

        private void btnUser_Click(object sender, EventArgs e)
        {
            showSubMenu(panelUserSubMenu);
        }

        private void btnSecurity_Click(object sender, EventArgs e)
        {
            showSubMenu(panelSeguridySubMenu);
        }

        private void frmprincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                this.ShowLoading();
                if (LoginInfo.ischange != true)
                {
                    String message = "Esta seguro que desees salir del sistema?";
                    String captacion = "Salir";
                    MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                    DialogResult result;

                    result = RJMessageBox.Show(message, captacion, buttons);

                    if (result == System.Windows.Forms.DialogResult.No)
                    {
                        this.CloseLoading();
                        e.Cancel = true;
                    }
                    else
                    {
                        LoginInfo.ischange = true;
                        LoginInfo.changesession = false;

                        #region Cerrar caja
                        RepoPathern.OpenWorkRepoService.CloseCashier(LoginInfo.IdAccount, LoginInfo.TurnId);
                        this.CloseLoading();
                        #endregion

                        Environment.Exit(0);
                        Application.Exit();
                    }
                }
                else if (LoginInfo.changesession == true && LoginInfo.ischange == true)
                {
                    if (string.IsNullOrEmpty(LoginInfo.messegeaftercreateturn))
                    {
                        String message = "Estas seguro quieres cambiar session";
                        String captacion = "Cambiar sessión";
                        MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                        DialogResult result;

                        result = RJMessageBox.Show(message, captacion, buttons);

                        if (result == System.Windows.Forms.DialogResult.No)
                        {
                            this.CloseLoading();
                            e.Cancel = true;
                        }
                        else
                        {
                            this.CloseLoading();
                            newfrmlogin frm = new newfrmlogin();
                            frm.label1.Text = "Cambiar sesión";
                            frm.Show();
                        }
                    }
                    else
                    {
                        RJMessageBox.Show(LoginInfo.messegeaftercreateturn, "Sistema de ventas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoginInfo.messegeaftercreateturn = string.Empty;
                        this.CloseLoading();
                        newfrmlogin frm = new newfrmlogin();
                        frm.label1.Text = "Iniciar sesión";
                        frm.Show();
                    }
                }
                this.CloseLoading();
            }
            catch (Exception)
            {
                Application.Exit();
                return;
            }

        }
        private void ShowLoading()
        {
            loading = new SplashForm();
            loading.Show();
        }

        private void CloseLoading()
        {
            if (this.loading != null)
                this.loading.Close();
        }

        private void button20_Click(object sender, EventArgs e)
        {
            this.ShowLoading();
            LoginInfo.ischange = true;
            LoginInfo.changesession = true;
            this.CloseLoading();
            this.Close();
        }

        private void button19_Click(object sender, EventArgs e)
        {
            this.ShowLoading();
            LoginInfo.ischange = false;
            LoginInfo.changesession = false;          
            String message = "Esta seguro que desees salir del sistema?";
            String captacion = "Salir";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result;

            result = RJMessageBox.Show(message, captacion, buttons);

            if (result == System.Windows.Forms.DialogResult.Yes)
            {

                #region Cerrar caja
                Boolean isOpen= RepoPathern.OpenWorkRepoService.ChechCashierOpen(LoginInfo.IdAccount, LoginInfo.TurnId);
                if (isOpen)
                {
                    String closemss = "Esta abierto el turno.\n¿Desee hacer cierre de caja?";
                    String closecaptacion = "Salir";
                    MessageBoxButtons closebuttons = MessageBoxButtons.YesNo;
                    DialogResult clossresult = RJMessageBox.Show(closemss, closecaptacion, closebuttons);
                    if (clossresult == System.Windows.Forms.DialogResult.Yes)
                    {
                        RepoPathern.OpenWorkRepoService.CloseCashier(LoginInfo.IdAccount, LoginInfo.TurnId);
                    }
                }
                #endregion
                this.CloseLoading();

                this.CloseLoading();
                Environment.Exit(0);
                Application.Exit();
            }            
            this.CloseLoading();
        }

        private void button23_Click(object sender, EventArgs e)
        {
            this.ShowLoading();
            //DisableButton(panelSeguridySubMenu.Controls);
            openChildForm(new frmrole(), sender, panelSeguridySubMenu.Controls);
            this.CloseLoading();            
        }

        private void button25_Click(object sender, EventArgs e)
        {
            this.ShowLoading();
            openChildForm(new frmturns(), sender, panelSeguridySubMenu.Controls);
            //hideSubMenu();
            this.CloseLoading();            
        }

        private void button28_Click(object sender, EventArgs e)
        {
            this.ShowLoading();
            openChildForm(new frmopenworkturns(), sender, panelSeguridySubMenu.Controls);
            //hideSubMenu();
            this.CloseLoading();            
        }

        private void button26_Click(object sender, EventArgs e)
        {
            this.ShowLoading();
            //DisableButton(panelSeguridySubMenu.Controls);
            openChildForm(new frmcategory(), sender, panelSeguridySubMenu.Controls);
            this.CloseLoading();            
        }

        private void button9_Click_1(object sender, EventArgs e)
        {
            this.ShowLoading();
            //DisableButton(panelSeguridySubMenu.Controls);
            openChildForm(new frmIncreasePriceAfterTwelve(), sender, panelSeguridySubMenu.Controls);
            this.CloseLoading();            
        }

        private void button27_Click(object sender, EventArgs e)
        {
            this.ShowLoading();
            //DisableButton(panelSeguridySubMenu.Controls);
            openChildForm(new frmupdateprice(), sender, panelSeguridySubMenu.Controls);
            this.CloseLoading();            
        }

        private void frmprincipal_Load(object sender, EventArgs e)
        {
            var isTurnOpenForUser = RepoPathern.OpenWorkRepoService.IsTurnOpenForUser(LoginInfo.IdAccount, LoginInfo.IdBusiness);
            if (isTurnOpenForUser != null)
            {
                LoginInfo.TurnId = isTurnOpenForUser.TurnId;
                openChildForm(new frmsale(), btnstartsale, panelSaleSubMenu.Controls);
            }
            else
            {
                if (isTurnOpenForUser == null && !LoginInfo.IdRole.ToLower().Equals("82a0bec6-8266-443a-84a2-af85ad69348b".ToLower()))
                {
                    this.btnstartsale.Enabled = false;
                    Color color = SelectThemeColor();
                    btnstartsale.BackColor = color;
                    RJMessageBox.Show("No tiene Caja abierto para esa cuenta.\n Contacte al administrador", "Contacte al administrador", MessageBoxButtons.OK);
                }
                else
                {
                    this.btnstartsale.Enabled = false;
                    Color color = SelectThemeColor();
                    btnstartsale.BackColor = color;
                    RJMessageBox.Show("No tiene Caja abierto para esa cuenta.\n Seguridad > Abrir turno > Abrir turno", "Contacte al administrador", MessageBoxButtons.OK);
                }
            }
        }

        private void button16_Click(object sender, EventArgs e)
        {
            this.ShowLoading();
            //DisableButton(panelProductSubMenu.Controls);
            openChildForm(new frmoffer(), sender, panelProductSubMenu.Controls);
            this.CloseLoading();
        }

        private void button10_Click_1(object sender, EventArgs e)
        {
            this.ShowLoading();
            //DisableButton(panelSaleSubMenu.Controls);            
            openChildForm(new frmdetailLegit(), sender, panelSaleSubMenu.Controls);
            this.CloseLoading();
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            //DisableButton(panelUserSubMenu.Controls);
            this.ShowLoading();
            openChildForm(new frmusr(), sender, panelUserSubMenu.Controls);
            this.CloseLoading();
        }

        private void GetPermission(AccountBE Login)
        {
            try
            {
                Color color = SelectThemeColor(); 
                panelTitleBar.BackColor = color;
                panelLogo.BackColor = ThemeColor.ChangeColorBrightness(color, -0.3);
                foreach (var pnlprincipal in panelSideMenu.Controls.OfType<Button>())
                {
                    if (!pnlprincipal.Text.ToLower().Equals("SysGes".ToLower()))
                    {
                        var modbe = Login.ModuleAccounts.Where(l => l.Module.Name.ToLower() == pnlprincipal.Text.ToLower());
                        if (modbe.Any())
                        {
                            foreach (var item in modbe)
                            {
                                switch (item.Module.Name)
                                {
                                    case "Productos":
                                        foreach (var item2 in panelProductSubMenu.Controls.OfType<Button>())
                                        {
                                            var btn = item.SubModuleAccounts.FirstOrDefault(l => l.SubModule.Name.ToLower() == item2.Text.ToLower());
                                            if (btn == null)
                                            {
                                                item2.Enabled = false;
                                                item2.BackColor = color;
                                            }
                                        }
                                        break;
                                    case "Ventas":
                                        foreach (var item2 in panelSaleSubMenu.Controls.OfType<Button>())
                                        {
                                            var btn = item.SubModuleAccounts.FirstOrDefault(l => l.SubModule.Name.ToLower() == item2.Text.ToLower());
                                            if (btn == null)
                                            {
                                                item2.Enabled = false;
                                                item2.BackColor = color;
                                            }
                                        }
                                        break;
                                    case "Proveedores":
                                        foreach (var item2 in panelProviderSubMenu.Controls.OfType<Button>())
                                        {
                                            var btn = item.SubModuleAccounts.FirstOrDefault(l => l.SubModule.Name.ToLower() == item2.Text.ToLower());
                                            if (btn == null)
                                            {
                                                item2.Enabled = false;
                                                item2.BackColor = color;
                                            }
                                        }
                                        break;
                                    case "Gestion de Usuarios":
                                        foreach (var item2 in panelUserSubMenu.Controls.OfType<Button>())
                                        {
                                            var btn = item.SubModuleAccounts.FirstOrDefault(l => l.SubModule.Name.ToLower() == item2.Text.ToLower());
                                            if (btn == null)
                                            {
                                                item2.Enabled = false;
                                                item2.BackColor = color;
                                            }
                                        }
                                        break;
                                    case "Reportes":
                                        foreach (var item2 in panelReportSubMenu.Controls.OfType<Button>())
                                        {
                                            var btn = item.SubModuleAccounts.FirstOrDefault(l => l.SubModule.Name.ToLower() == item2.Text.ToLower());
                                            if (btn == null)
                                            {
                                                item2.Enabled = false;
                                                item2.BackColor = color;
                                            }
                                        }
                                        break;
                                    case "Seguridades":
                                        foreach (var item2 in panelSeguridySubMenu.Controls.OfType<Button>())
                                        {
                                            var btn = item.SubModuleAccounts.FirstOrDefault(l => l.SubModule.Name.ToLower() == item2.Text.ToLower());
                                            if (btn == null)
                                            {
                                                item2.Enabled = false;
                                                item2.BackColor = color;
                                            }
                                        }
                                        break;
                                    default:
                                        foreach (var item2 in panelMovmentSubMenu.Controls.OfType<Button>())
                                        {
                                            var btn = item.SubModuleAccounts.FirstOrDefault(l => l.SubModule.Name.ToLower() == item2.Text.ToLower());
                                            if (btn == null)
                                            {
                                                item2.Enabled = false;
                                                item2.BackColor = color;
                                            }
                                        }
                                        break;
                                }
                            }
                        }
                        else
                        {
                            switch (pnlprincipal.Text)
                            {
                                case "Productos":
                                    foreach (var item2 in panelProductSubMenu.Controls.OfType<Button>())
                                    {
                                        item2.Enabled = false;
                                        panelProductSubMenu.BackColor = color;
                                    }
                                    break;
                                case "Ventas":
                                    foreach (var item2 in panelSaleSubMenu.Controls.OfType<Button>())
                                    {
                                        item2.Enabled = false;
                                        panelSaleSubMenu.BackColor = color;
                                    }
                                    break;
                                case "Proveedores":
                                    foreach (var item2 in panelProviderSubMenu.Controls.OfType<Button>())
                                    {
                                        item2.Enabled = false;
                                        panelProviderSubMenu.BackColor = color;
                                    }
                                    break;
                                case "Gestion de Usuarios":
                                    foreach (var item2 in panelUserSubMenu.Controls.OfType<Button>())
                                    {
                                        item2.Enabled = false;
                                        panelUserSubMenu.BackColor = color;
                                    }
                                    break;
                                case "Reportes":
                                    foreach (var item2 in panelReportSubMenu.Controls.OfType<Button>())
                                    {
                                        item2.Enabled = false;
                                        panelReportSubMenu.BackColor = color;
                                    }
                                    break;
                                case "Seguridades":
                                    foreach (var item2 in panelSeguridySubMenu.Controls.OfType<Button>())
                                    {
                                        item2.Enabled = false;
                                        panelSeguridySubMenu.BackColor = color;
                                    }
                                    break;
                                default:
                                    foreach (var item2 in panelMovmentSubMenu.Controls.OfType<Button>())
                                    {
                                        item2.Enabled = false;
                                        panelMovmentSubMenu.BackColor = color;
                                    }
                                    break;
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                RJMessageBox.Show("Contacte al administrador", "Sistema de ventas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }

        #region Private method
        private Color SelectThemeColor()
        {
            int index = random.Next(ThemeColor.ColorList.Count);
            while (tempIndex == index)
            {
                index = random.Next(ThemeColor.ColorList.Count);
            }
            tempIndex = index;
            string color = ThemeColor.ColorList[index];
            return ColorTranslator.FromHtml(color);
        }

        private void ActivateButton(object btnSender, Control.ControlCollection Controls)
        {
            if (btnSender != null)
            {
                if (currentButton != (Button)btnSender)
                {
                    this.DisableButton(Controls);
                    Color color = SelectThemeColor();
                    currentButton = (Button)btnSender;
                    currentButton.BackColor = color;
                    currentButton.ForeColor = Color.White;
                    currentButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    panelTitleBar.BackColor = color;
                    panelLogo.BackColor = ThemeColor.ChangeColorBrightness(color, -0.3);
                    ThemeColor.PrimaryColor = color;
                    ThemeColor.SecondaryColor = ThemeColor.ChangeColorBrightness(color, -0.3);
                    btnCloseChildForm.Visible = true;
                }
            }
        }
        private void DisableButton(Control.ControlCollection Controls)
        {
            foreach (Control previousBtn in Controls)
            {
                if (previousBtn!= null)
                {
                    previousBtn.BackColor = Color.FromArgb(51, 51, 76);
                    previousBtn.ForeColor = Color.Gainsboro;
                    previousBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));                   
                }               
            }
        }
        #endregion

        private void btnchangepassword_Click(object sender, EventArgs e)
        {
            //DisableButton(panelUserSubMenu.Controls);
            this.ShowLoading();
            openChildForm(new frmchangepass(), sender, panelUserSubMenu.Controls);
            LoginInfo.isChangeCancelPass = false;
            this.CloseLoading();
        }

        private void SegundVersion()
        {
            this.btndetailproduct.Visible = false;
            this.btnconsultantproducto.Visible = false;
            this.panelReportSubMenu.Visible = false;
            this.btnReport.Visible = false;
            this.btnMovements.Visible = false;
            this.panelMovmentSubMenu.Visible = false;
            this.button22.Visible = false;
            //this.button25.Visible = false;
            //this.button28.Visible = false;
            //this.button29.Visible = false;
            //this.button30.Visible = false;
        }

        private void btnmodifyrol_Click(object sender, EventArgs e)
        {            
            this.ShowLoading();
            //DisableButton(panelSeguridySubMenu.Controls);
            openChildForm(new frmmodifyrol(), sender, panelSeguridySubMenu.Controls);
            this.CloseLoading();
        }

        private void btnupdatestock_Click(object sender, EventArgs e)
        {
            this.ShowLoading();
            //DisableButton(panelProductSubMenu.Controls);
            openChildForm(new frmupdatestock(), sender, panelProductSubMenu.Controls);
            this.CloseLoading();
        }

        private void button20_Click_1(object sender, EventArgs e)
        {
            if (activeForm != null)
                activeForm.Close();
            Reset();
        }

        private void Reset()
        {
            //DisableButton(panelChildForm.Controls);
            lblTItle.Text = "Venta de producto";
            panelTitleBar.BackColor = Color.FromArgb(0, 150, 136);
            panelLogo.BackColor = Color.FromArgb(39, 39, 58);
            currentButton = null;

            showSubMenu(panelSaleSubMenu);
            openChildForm(new frmsale(), btnstartsale, panelSaleSubMenu.Controls);

            //btnCloseChildForm.Visible = false;
        }

        private void panelTitleBar_MouseDown(object sender, MouseEventArgs e)
        {
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnMaximize_Click(object sender, EventArgs e)
        {
            if(WindowState == FormWindowState.Normal)
                this.WindowState = FormWindowState.Maximized;
            else
                this.WindowState = FormWindowState.Normal;
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button29_Click(object sender, EventArgs e)
        {
            this.ShowLoading();
            //DisableButton(panelSeguridySubMenu.Controls);
            openChildForm(new frmopenworkturns(2), sender, panelSeguridySubMenu.Controls);
            this.CloseLoading();
        }

        private void button30_Click(object sender, EventArgs e)
        {
             this.ShowLoading();
            //DisableButton(panelSeguridySubMenu.Controls);
            openChildForm(new frmbusiness(), sender, panelSeguridySubMenu.Controls);
            this.CloseLoading();
        }
    }
}
