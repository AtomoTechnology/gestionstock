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
using ApplicationView.VariableSeesion;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace ApplicationView.Forms.Account
{
    public partial class frmPrincipal : Form
    {
        SplashForm loading;
        public frmPrincipal()
        {
            InitializeComponent();

            this.GetVisible();
            this.Text = ("Bienvenido al sistema de ventas y de gestiones de stock").PadLeft(140);
            this.BackColor = Color.AliceBlue;
            //Controls.OfType<MdiClient>().First().BackgroundImage = new Bitmap("Resources/software-de-gestion-de-stock.jpg");
        }

        private void crearUsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Show();
            frmusr frm = new frmusr();
            frm.MdiParent = this;
            frm.Show();
            this.HideLoading();
        }

        private void roleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Show();
            frmrole frm = new frmrole();
            frm.MdiParent = this;
            frm.Show();
            this.HideLoading();
        }

        private void gestionarNegocioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.ShowLoading();
            frmbusiness frm = new frmbusiness();
            frm.MdiParent = this;
            frm.Show();
            this.HideLoading();
        }

        private void categoriaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.ShowLoading();
            frmcategory frm = new frmcategory();
            frm.MdiParent = this;
            frm.Show();
            this.HideLoading();
        }

        private void proveedorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.ShowLoading();
            frmprovider frm = new frmprovider();
            frm.MdiParent = this;
            frm.Show();
            this.HideLoading();
        }

        private void salirDelSistemaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.ShowLoading();
            LoginInfo.ischange = false;
            LoginInfo.changesession = false;
            foreach (Form frmlog in Application.OpenForms)
            {
                if (frmlog.GetType() == typeof(frmPrincipal))
                {
                    frmlog.Close();
                    break;
                }
            }
            this.HideLoading();
        }

        private void productosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.ShowLoading();
            frmProduct frm = new frmProduct();
            frm.MdiParent = this;
            frm.Show();
            this.HideLoading();
        }

        private void produdosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.ShowLoading();
            frmsale frm = new frmsale();
            frm.MdiParent = this;
            frm.Show();
            this.HideLoading();
        }

        private void incrementoDespuesDeLas12PMToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.ShowLoading();
            frmIncreasePriceAfterTwelve frm = new frmIncreasePriceAfterTwelve();
            frm.MdiParent = this;
            frm.Show();
            this.HideLoading();
            
        }

        private void frmPrincipal_FormClosed(object sender, FormClosedEventArgs e)
        {
           
        }

        private void frmPrincipal_FormClosing(object sender, FormClosingEventArgs e)
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
                        this.HideLoading();
                        e.Cancel = true;
                    }
                    else
                    {
                        LoginInfo.ischange = true;
                        LoginInfo.changesession = false;
                        //#region Cerrar caja
                        //_repopatern.OpenWorkRepoService.CloseCashier(LoginInfo.IdAccount, LoginInfo.TurnId);
                        //#endregion
                        //this.HideLoading();
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
                            this.HideLoading();
                            e.Cancel = true;
                        }
                        else
                        {
                            this.HideLoading();
                            frmlogin frm = new frmlogin();
                            frm.groupBox1.Text = "Cambiar sesión";
                            frm.Show();
                        }
                    }
                    else
                    {
                        RJMessageBox.Show(LoginInfo.messegeaftercreateturn, "Sistema de ventas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoginInfo.messegeaftercreateturn = string.Empty;
                        this.HideLoading();
                        frmlogin frm = new frmlogin();
                        frm.groupBox1.Text = "Iniciar sesión";
                        frm.Show();
                    }
                }
                this.HideLoading();
            }
            catch (Exception)
            {
                Application.Exit();
                return;
            }
        }

        private void cambiarSessionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.ShowLoading();
            LoginInfo.ischange = true;
            LoginInfo.changesession = true;
            this.HideLoading();
            this.Close();
        }

        private void actualizarPrecioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.ShowLoading();
            frmupdateprice frm = new frmupdateprice();
            frm.MdiParent = this;
            frm.Show();
            this.HideLoading();
        }

        #region Permission
        private void GestionUser()
        {
            codigoToolStripMenuItem.Enabled = false;
            fechaToolStripMenuItem.Enabled = true;
            if (LoginInfo.Access.ToLower() == ("Admin").ToLower())
            {
                this.ingresoToolStripMenuItem.Enabled = true;
                this.saleToolStripMenuItem.Enabled = true;
                this.consultarStockToolStripMenuItem.Enabled = true;
                this.consultaToolStripMenuItem.Enabled = false;
                this.promoToolStripMenuItem.Enabled = false;
                this.egresoToolStripMenuItem.Enabled = true;
                this.productosToolStripMenuItem.Enabled = true;
                this.vencimientoToolStripMenuItem.Enabled = false;
                this.movimientoToolStripMenuItem.Enabled = false;
                this.reportesToolStripMenuItem.Enabled = false;
                this.gestionDeUsuarioToolStripMenuItem.Enabled = true;
                this.crearUsuarioToolStripMenuItem.Enabled = true;
                this.cambiarContraseñaToolStripMenuItem.Enabled = true;
                this.gestionarProveedorToolStripMenuItem.Enabled = true;
                this.proveedorToolStripMenuItem.Enabled = true;
                this.gestionDeCajaToolStripMenuItem.Enabled = false;
                this.abreCajaToolStripMenuItem.Enabled = false;
                this.seguridadToolStripMenuItem.Enabled = true;
                this.roleToolStripMenuItem.Enabled = false;
                this.backupToolStripMenuItem.Enabled = false;
                this.historialToolStripMenuItem.Enabled = false;
                this.formaDePagoToolStripMenuItem.Enabled = false;
                this.gestionarNegocioToolStripMenuItem.Enabled = true;
                this.categoriaToolStripMenuItem.Enabled = true;
                this.incrementoDespuesDeLas12PMToolStripMenuItem.Enabled = true;
                this.actualizarPrecioDeProductoToolStripMenuItem.Enabled = true;
            }
            else if (LoginInfo.Access.ToLower() == ("Empleado(a)").ToLower())
            {
                this.ingresoToolStripMenuItem.Enabled = true;
                this.saleToolStripMenuItem.Enabled = true;
                this.consultarStockToolStripMenuItem.Enabled = true;
                this.consultaToolStripMenuItem.Enabled = false;
                this.promoToolStripMenuItem.Enabled = false;
                this.egresoToolStripMenuItem.Enabled = false;
                this.productosToolStripMenuItem.Enabled = false;
                this.vencimientoToolStripMenuItem.Enabled = false;
                this.movimientoToolStripMenuItem.Enabled = false;
                this.reportesToolStripMenuItem.Enabled = false;
                this.gestionDeUsuarioToolStripMenuItem.Enabled = false;
                this.crearUsuarioToolStripMenuItem.Enabled = false;
                this.cambiarContraseñaToolStripMenuItem.Enabled = true;
                this.gestionarProveedorToolStripMenuItem.Enabled = false;
                this.proveedorToolStripMenuItem.Enabled = false;
                this.gestionDeCajaToolStripMenuItem.Enabled = false;
                this.abreCajaToolStripMenuItem.Enabled = false;
                this.seguridadToolStripMenuItem.Enabled = false;
                this.roleToolStripMenuItem.Enabled = false;
                this.backupToolStripMenuItem.Enabled = false;
                this.historialToolStripMenuItem.Enabled = false;
                this.formaDePagoToolStripMenuItem.Enabled = false;
                this.gestionarNegocioToolStripMenuItem.Enabled = false;
                this.categoriaToolStripMenuItem.Enabled = false;
                this.incrementoDespuesDeLas12PMToolStripMenuItem.Enabled = false;
                this.actualizarPrecioDeProductoToolStripMenuItem.Enabled = false;
            }
            else if (LoginInfo.Access.ToLower() == ("Almacenero(a)").ToLower())
            {
                this.ingresoToolStripMenuItem.Enabled = true;
                this.saleToolStripMenuItem.Enabled = true;
                this.consultarStockToolStripMenuItem.Enabled = true;
                this.consultaToolStripMenuItem.Enabled = false;
                this.promoToolStripMenuItem.Enabled = false;
                this.egresoToolStripMenuItem.Enabled = false;
                this.productosToolStripMenuItem.Enabled = false;
                this.vencimientoToolStripMenuItem.Enabled = false;
                this.movimientoToolStripMenuItem.Enabled = false;
                this.reportesToolStripMenuItem.Enabled = false;
                this.gestionDeUsuarioToolStripMenuItem.Enabled = false;
                this.crearUsuarioToolStripMenuItem.Enabled = false;
                this.cambiarContraseñaToolStripMenuItem.Enabled = true;
                this.gestionarProveedorToolStripMenuItem.Enabled = false;
                this.proveedorToolStripMenuItem.Enabled = false;
                this.gestionDeCajaToolStripMenuItem.Enabled = false;
                this.abreCajaToolStripMenuItem.Enabled = false;
                this.seguridadToolStripMenuItem.Enabled = false;
                this.roleToolStripMenuItem.Enabled = false;
                this.backupToolStripMenuItem.Enabled = false;
                this.historialToolStripMenuItem.Enabled = false;
                this.formaDePagoToolStripMenuItem.Enabled = false;
                this.gestionarNegocioToolStripMenuItem.Enabled = false;
                this.categoriaToolStripMenuItem.Enabled = false;
                this.incrementoDespuesDeLas12PMToolStripMenuItem.Enabled = false;
                this.actualizarPrecioDeProductoToolStripMenuItem.Enabled = false;
            }
        }
        
        private void DesaebledOpenTurn()
        {
            this.codigoToolStripMenuItem.Enabled = false;
            this.fechaToolStripMenuItem.Enabled = false;
            this.ingresoToolStripMenuItem.Enabled = false;
            this.saleToolStripMenuItem.Enabled = false;
            this.consultarStockToolStripMenuItem.Enabled = false;
            this.consultaToolStripMenuItem.Enabled = false;
            this.promoToolStripMenuItem.Enabled = false;
            this.egresoToolStripMenuItem.Enabled = false;
            this.productosToolStripMenuItem.Enabled = false;
            this.vencimientoToolStripMenuItem.Enabled = false;
            this.movimientoToolStripMenuItem.Enabled = false;
            this.reportesToolStripMenuItem.Enabled = false;
            this.gestionDeUsuarioToolStripMenuItem.Enabled = false;
            this.crearUsuarioToolStripMenuItem.Enabled = false;
            this.cambiarContraseñaToolStripMenuItem.Enabled = false;
            this.gestionarProveedorToolStripMenuItem.Enabled = false;
            this.proveedorToolStripMenuItem.Enabled = false;
            this.gestionDeCajaToolStripMenuItem.Enabled = false;
            this.abreCajaToolStripMenuItem.Enabled = false;
            this.seguridadToolStripMenuItem.Enabled = false;
            this.roleToolStripMenuItem.Enabled = false;
            this.backupToolStripMenuItem.Enabled = false;
            this.historialToolStripMenuItem.Enabled = false;
            this.formaDePagoToolStripMenuItem.Enabled = false;
            this.gestionarNegocioToolStripMenuItem.Enabled = false;
            this.categoriaToolStripMenuItem.Enabled = false;
            this.incrementoDespuesDeLas12PMToolStripMenuItem.Enabled = false;
            this.actualizarPrecioDeProductoToolStripMenuItem.Enabled = false;
        }

        private void DesaebledWitheOpenTurn()
        {
            this.ingresoToolStripMenuItem.Enabled = true;
            this.saleToolStripMenuItem.Enabled = false;
            this.consultarStockToolStripMenuItem.Enabled = true;
            this.consultaToolStripMenuItem.Enabled = false;
            this.promoToolStripMenuItem.Enabled = false;
            this.egresoToolStripMenuItem.Enabled = false;
            this.productosToolStripMenuItem.Enabled = false;
            this.vencimientoToolStripMenuItem.Enabled = false;
            this.movimientoToolStripMenuItem.Enabled = false;
            this.reportesToolStripMenuItem.Enabled = false;
            this.gestionDeUsuarioToolStripMenuItem.Enabled = false;
            this.crearUsuarioToolStripMenuItem.Enabled = false;
            this.cambiarContraseñaToolStripMenuItem.Enabled = true;
            this.gestionarProveedorToolStripMenuItem.Enabled = false;
            this.proveedorToolStripMenuItem.Enabled = false;
            this.gestionDeCajaToolStripMenuItem.Enabled = false;
            this.abreCajaToolStripMenuItem.Enabled = false;
            this.seguridadToolStripMenuItem.Enabled = false;
            this.roleToolStripMenuItem.Enabled = false;
            this.backupToolStripMenuItem.Enabled = false;
            this.historialToolStripMenuItem.Enabled = false;
            this.formaDePagoToolStripMenuItem.Enabled = false;
            this.gestionarNegocioToolStripMenuItem.Enabled = false;
            this.categoriaToolStripMenuItem.Enabled = false;
            this.incrementoDespuesDeLas12PMToolStripMenuItem.Enabled = false;
            this.actualizarPrecioDeProductoToolStripMenuItem.Enabled = false;
        }
        private void DesaebledSetting()
        {
            this.ingresoToolStripMenuItem.Enabled = false;
            this.saleToolStripMenuItem.Enabled = false;
            this.consultarStockToolStripMenuItem.Enabled = false;
            this.consultaToolStripMenuItem.Enabled = false;
            this.promoToolStripMenuItem.Enabled = false;
            this.egresoToolStripMenuItem.Enabled = false;
            this.productosToolStripMenuItem.Enabled = false;
            this.vencimientoToolStripMenuItem.Enabled = false;
            this.movimientoToolStripMenuItem.Enabled = false;
            this.reportesToolStripMenuItem.Enabled = false;
            this.gestionDeUsuarioToolStripMenuItem.Enabled = false;
            this.crearUsuarioToolStripMenuItem.Enabled = false;
            this.cambiarContraseñaToolStripMenuItem.Enabled = true;
            this.gestionarProveedorToolStripMenuItem.Enabled = false;
            this.proveedorToolStripMenuItem.Enabled = false;
            this.gestionDeCajaToolStripMenuItem.Enabled = false;
            this.abreCajaToolStripMenuItem.Enabled = false;
            this.seguridadToolStripMenuItem.Enabled = false;
            this.roleToolStripMenuItem.Enabled = false;
            this.backupToolStripMenuItem.Enabled = false;
            this.historialToolStripMenuItem.Enabled = false;
            this.formaDePagoToolStripMenuItem.Enabled = false;
            this.gestionarNegocioToolStripMenuItem.Enabled = false;
            this.categoriaToolStripMenuItem.Enabled = false;
            this.incrementoDespuesDeLas12PMToolStripMenuItem.Enabled = false;
            this.actualizarPrecioDeProductoToolStripMenuItem.Enabled = false;
        }
        private void DesaebledOlySale()
        {
            this.saleToolStripMenuItem.Enabled = false;            
        }
        #endregion

        private void actualizarPrecioDeProductoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.ShowLoading();
            frmupdateprice frm = new frmupdateprice();
            frm.MdiParent = this;
            frm.Show();
            this.HideLoading();
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            //var isTurnOpenForUser = _repopatern.OpenWorkRepoService.IsTurnOpenForUser(LoginInfo.IdAccount, LoginInfo.IdBusiness);
            //if (isTurnOpenForUser != null)
            //{ 
                //LoginInfo.TurnId = isTurnOpenForUser.TurnId;
                this.GestionUser(); 
            //}
            //else
            //{
            //    if (isTurnOpenForUser == null && !LoginInfo.IdRole.ToLower().Equals("82a0bec6-8266-443a-84a2-af85ad69348b".ToLower()))
            //    {
            //        this.DesaebledWitheOpenTurn();
            //        RJMessageBox.Show("No tiene Caja abierto para esa cuenta.\n Contacte al administrador", "Contacte al administrador", MessageBoxButtons.OK);
            //    }
            //    else
            //    {
            //        this.DesaebledOlySale();
            //        RJMessageBox.Show("No tiene Caja abierto para esa cuenta.\n Seguridad > Abrir turno > Abrir turno", "Contacte al administrador", MessageBoxButtons.OK);
            //    }
            //}
        }

        private void cambiarContraseñaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.ShowLoading();
            frmchangepass pass = new frmchangepass();
            LoginInfo.isChangeCancelPass = false;
            pass.MdiParent = this;
            pass.Show();
            this.HideLoading();
        }

        private void precioProductoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.ShowLoading();
            frmcheckprice frm = new frmcheckprice();
            frm.MdiParent = this;
            frm.Show();
            this.HideLoading();
        }

        private void codigoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.ShowLoading();
            frmiexpiredDate frm = new frmiexpiredDate();
            frm.MdiParent = this;
            frm.Show();
            this.HideLoading();
        }

        private void fechaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.ShowLoading();
            frmsalehistoric frm = new frmsalehistoric();
            this.HideLoading();
            frm.ShowDialog();
        }

        private void gestionarTurnoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.ShowLoading();
            frmturns frm = new frmturns();
            this.HideLoading();
            frm.ShowDialog();
        }

        private void abrirTurnoToolStripMenuItem_Click(object sender, EventArgs e)
        {            
        }

        private void abrirTurnoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.ShowLoading();
            frmopenworkturns frm = new frmopenworkturns();
            this.HideLoading();
            frm.ShowDialog();
        }

        private void verTurnoCerradoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.ShowLoading();
            frmopenworkturns frm = new frmopenworkturns();
            this.HideLoading();
            frm.ShowDialog();
        }   
        
        private void ShowLoading()
        {
            loading = new SplashForm();
            loading.Show();
        }

        private void HideLoading()
        {
            if (this.loading != null)
                this.loading.Close();
        }

        private void GetVisible()
        {
            this.roleToolStripMenuItem.Visible = false;
            this.formaDePagoToolStripMenuItem.Visible = false;
            this.backupToolStripMenuItem.Visible = false;
            this.historialToolStripMenuItem.Visible = false;
            this.formaDePagoToolStripMenuItem.Visible = false;
            this.gestionarNegocioToolStripMenuItem.Visible = false;
        }

        private void abreCajaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void cierreDeCajaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
