using ApplicationView.BusnessEntities.BE;
using ApplicationView.BusnessEntities.Dtos;
using ApplicationView.Forms.MsgBox;
using ApplicationView.Patern.singleton;
using ApplicationView.Resolver.HelperError.IExceptions;
using ApplicationView.VariableSeesion;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ApplicationView.Forms.Sale
{
    public partial class frmautorizedeleteproductsale : Form
    {
        private  SaleDetailDto _saleDetail;
        private string _lotid;
        public Boolean isdeleteAdmin = false;
        public frmautorizedeleteproductsale(SaleDetailDto saleDetail, string lotid)
        {
            InitializeComponent();
            _saleDetail = saleDetail;
            this.isdeleteAdmin = false;
            this._lotid = lotid;
        }

        private async void btnacept_Click(object sender, EventArgs e)
        {
            try
            {
                string usuario, password;
                usuario = Convert.ToString(this.txtuser.Text);
                password = Convert.ToString(this.txtpass.Text);
                if (string.IsNullOrEmpty(usuario))
                {
                    RJMessageBox.Show("Ingrese el nombre de usuario", "Sistema de ventas", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.txtuser.Text = String.Empty;
                    this.txtuser.Focus();
                }
                else if (string.IsNullOrEmpty(password))
                {
                    RJMessageBox.Show("Ingresa la contraseña", "Sistema de ventas", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.txtpass.Text = String.Empty;
                    this.txtpass.Focus();

                }
                else
                {
                    AccountBE Datos = await RepoPathern.AccountService.Login(usuario, password);
                    if (Datos == null)
                    {
                        RJMessageBox.Show("Usuario y/o contraseña incorrecto", "Sistema de ventas", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    if (Datos.Role.RoleName.ToLower() == "Admin".ToLower())
                    {
                        try
                        {
                            RepoPathern.SaleService.RemoveNoneSale(_saleDetail, this._lotid, Datos.Id, Resolver.Enums.DeleteSaleEnum.Admin);
                            this.isdeleteAdmin = true;
                            this.Close();
                        }
                        catch (Exception)
                        {
                            this.isdeleteAdmin = false;
                            this.Close();
                        }                       
                    }
                    else
                    {
                        RJMessageBox.Show("No tiene acceso administrador", "Sistema de ventas", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
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
            this.isdeleteAdmin = false;
            this.Close();
        }

        private void frmautorizedeleteproductsale_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.isdeleteAdmin = false;
        }
    }
}
