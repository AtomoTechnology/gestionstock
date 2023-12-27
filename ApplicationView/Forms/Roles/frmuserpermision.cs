using ApplicationView.BusnessEntities.BE;
using ApplicationView.Forms.MsgBox;
using ApplicationView.Forms.RedesignForm;
using ApplicationView.Patern.singleton;
using ApplicationView.Resolver.Enums;
using ApplicationView.Theme;
using ApplicationView.VariableSeesion;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ApplicationView.Forms.Roles
{
    public partial class frmuserpermision : Form
    {
        public List<ModuleAccountBE> mabe = null;
        public List<ModuleAccountBE> modacc;
        public RoleBE rolbe = null;
        int count = 0;
        //ModuleBE _be;
        List<ModuleBE> listbe;
        List<CheckBox> chkBox;

        private Random random;
        private int tempIndex;

        private string accountid;

        private int borderRadius = 20;
        private int borderSize = 2;
        private Color borderColor = Color.FromArgb(128, 128, 255);

        public frmuserpermision(List<ModuleBE> be, AccountBE account)
        {
            InitializeComponent();
            mabe = new List<ModuleAccountBE>();
            modacc = new List<ModuleAccountBE>();
            chkBox = new List<CheckBox>();
           
            this.lblfirstname.Text = account.FirstName;
            this.lbllastname.Text = account.LastName;
            this.lblusername.Text = account.UserName;
            this.lblrol.Text = account?.Role?.RoleName;
            this.GetFillCheck();

            this.EnablePermission();
            this.accountid = account.Id;
            AccountBE Login = RepoPathern.AccountService.GetPermisoAfterLogin(this.accountid);

            if (be.Any())
            {
                //_be = be.FirstOrDefault();
                mabe = Login.ModuleAccounts;
                modacc = mabe;
            }

            this.GetPermission(Login);
            random = new Random();
            LoginInfo.pageactual = 1;

            this.FormBorderStyle = FormBorderStyle.None;
            this.Padding = new Padding(borderSize);
            this.btnclose.FlatAppearance.BorderSize = 0;
        }

        private void GetActualRol(ModuleBE be)
        {
            Color color = SelectThemeColor();
            var mod = RepoPathern.ModuleService.GetAll(1, LoginInfo.pageactual, 1000, "Id", "asc", "", ref count);          
            if (mod.Any())
            {
                foreach (var item in mod)
                {
                    bool iscontent = true;
                        //be.ModuleAccounts.Where(u => u.ModuleId == item.Id).Count() > 0 ? true : false;
                    if (iscontent)
                    {
                        switch (item.Name)
                        {
                            case "Productos":
                                this.GetAllStatusProduct(item, iscontent);
                                this.WatchCheckBoxSelectAll(pnlproduct.Controls.OfType<CheckBox>(), this.chkselectallproduct, pnlproduct);
                                break;
                            case "Ventas":
                                this.GetAllStatusSale(item, iscontent);
                                this.WatchCheckBoxSelectAll(pnlsubsale.Controls.OfType<CheckBox>(), this.chkselectallsale, pnlsubsale);
                                break;
                            case "Proveedores":
                                this.GetAllStatusProvider(item, iscontent);
                                this.WatchCheckBoxSelectAll(pnlprovider.Controls.OfType<CheckBox>(), this.chkselectallprovider, pnlprovider);
                                break;
                            case "Gestion de Usuarios":
                                this.GetAllStatusUserManagement(item, iscontent);
                                this.WatchCheckBoxSelectAll(pnlgestionuser.Controls.OfType<CheckBox>(), this.chkselectallgestionuser, pnlgestionuser);
                                break;
                            case "Reportes":
                                this.GetAllStatusReport(item, iscontent);
                                this.WatchCheckBoxSelectAll(pnlreport.Controls.OfType<CheckBox>(), this.chkselectallreport, pnlreport);
                                break;
                            case "Seguridades":
                                this.GetAllStatusSecurity(item, iscontent);
                                this.WatchCheckBoxSelectAll(pnlsecurity.Controls.OfType<CheckBox>(), this.chkselectallsecurity, pnlsecurity);
                                break;
                            default:
                                this.GetAllStatusMouvement(item, iscontent);
                                this.WatchCheckBoxSelectAll(pnlmouvment.Controls.OfType<CheckBox>(), this.chkselectallmouvment, pnlmouvment);
                                break;
                        }
                    }
                    else
                    {
                        switch (item.Name)
                        {
                            case "Productos":
                                this.chkproduct.Tag = item.Id;
                                this.chkproduct.CheckedChanged += Chkproduct_CheckedChanged;
                                foreach (var item2 in pnlproduct.Controls.OfType<CheckBox>())
                                {
                                    //item2.Enabled = false;
                                    pnlproduct.Enabled = false;
                                }
                                break;
                            case "Ventas":
                                this.chksale.Tag = item.Id;
                                this.chksale.CheckedChanged += Chksale_CheckedChanged;
                                foreach (var item2 in pnlsubsale.Controls.OfType<CheckBox>())
                                {
                                    //item2.Enabled = false;
                                    pnlsubsale.Enabled = false;
                                }
                                break;
                            case "Proveedores":
                                this.chkprovider.Tag = item.Id;
                                this.chkprovider.CheckedChanged += Chkprovider_CheckedChanged;
                                foreach (var item2 in pnlprovider.Controls.OfType<CheckBox>())
                                {
                                    //item2.Enabled = false;
                                    pnlprovider.Enabled = false;
                                }
                                break;
                            case "Gestion de Usuarios":
                                this.chkgestionuser.Tag = item.Id;
                                this.chkgestionuser.CheckedChanged += Chkgestionuser_CheckedChanged;
                                foreach (var item2 in pnlgestionuser.Controls.OfType<CheckBox>())
                                {
                                    //item2.Enabled = false;
                                    pnlgestionuser.Enabled = false;
                                }
                                break;
                            case "Reportes":
                                this.chkreport.Tag = item.Id;
                                this.chkreport.CheckedChanged += Chkreport_CheckedChanged;
                                foreach (var item2 in pnlreport.Controls.OfType<CheckBox>())
                                {
                                    //item2.Enabled = false;
                                    pnlreport.Enabled = false;
                                }
                                break;
                            case "Seguridades":
                                this.chksecurity.Tag = item.Id;
                                this.chksecurity.CheckedChanged += Chksecurity_CheckedChanged;
                                foreach (var item2 in pnlsecurity.Controls.OfType<CheckBox>())
                                {
                                    //item2.Enabled = false;
                                    pnlsecurity.Enabled = false;
                                }
                                break;
                            default:
                                this.chkmouvement.Tag = item.Id;
                                this.chkmouvement.CheckedChanged += Chkmouvement_CheckedChanged;
                                foreach (var item2 in pnlmouvment.Controls.OfType<CheckBox>())
                                {
                                    //item2.Enabled = false;
                                    pnlmouvment.Enabled = false;
                                }
                                break;
                        }

                    }
                   
                }
            }

        }

        private void Chkmouvement_CheckedChanged(object sender, EventArgs e)
        {
            AddData(pnlmouvment, chkselectallsecurity, chkmouvement);
        }

        private void GetAllStatusProduct(ModuleBE item, bool iscontent)
        {
            this.chkproduct.Tag = item.Id;
            this.chkproduct.Checked = iscontent;
            this.chkproduct.CheckedChanged += Chkproduct_CheckedChanged;
            foreach (var submod in item.SubModules)
            {
                bool ischecksub = submod.ModuleId == item.Id;
                switch (submod.Name)
                {
                    case "ABM Producto":
                        this.chkabmproduct.Tag = submod.Id;
                        this.chkabmproduct.Checked = ischecksub;
                        this.chkabmproduct.CheckedChanged += Chkabmproduct_CheckedChanged;
                        break;
                    case "Consultar Vencimiento":
                        this.chkconsultantexpired.Tag = submod.Id;
                        this.chkconsultantexpired.Checked = ischecksub;
                        this.chkconsultantexpired.CheckedChanged += Chkconsultantexpired_CheckedChanged;
                        break;
                    case "Detalle Producto":
                        this.chkdetailproduct.Tag = submod.Id;
                        this.chkdetailproduct.Checked = ischecksub;
                        this.chkdetailproduct.CheckedChanged += Chkdetailproduct_CheckedChanged;
                        break;
                    case "Actualizar stock":
                        this.chkupdatestock.Tag = submod.Id;
                        this.chkupdatestock.Checked = ischecksub;
                        this.chkupdatestock.CheckedChanged += Chkupdatestock_CheckedChanged;
                        break;
                    default:
                        this.chkcreateoffer.Tag = submod.Id;
                        this.chkcreateoffer.Checked = ischecksub;
                        this.chkcreateoffer.CheckedChanged += Chkcreateoffer_CheckedChanged;
                        break;
                }
            }
        }

        private void GetAllStatusSale(ModuleBE item, bool iscontent)
        {
            this.chksale.Tag = item.Id;
            this.chksale.Checked = iscontent;
            this.chksale.CheckedChanged += Chksale_CheckedChanged;
            foreach (var submod in item.SubModules)
            {
                bool ischecksub = submod.ModuleId == item.Id;
                switch (submod.Name)
                {
                    case "Iniciar venta":
                        this.chkstartsale.Tag = submod.Id;
                        this.chkstartsale.Checked = ischecksub;
                        this.chkstartsale.CheckedChanged += Chkstartsale_CheckedChanged;
                        break;
                    case "Consultar precio":
                        this.chkconsultantsale.Tag = submod.Id;
                        this.chkconsultantsale.Checked = ischecksub;
                        this.chkconsultantsale.CheckedChanged += Chkconsultantsale_CheckedChanged;
                        break;
                    case "Consultar venta":
                        this.chkconsultantprice.Tag = submod.Id;
                        this.chkconsultantprice.Checked = ischecksub;
                        this.chkconsultantprice.CheckedChanged += Chkconsultantprice_CheckedChanged;
                        break;
                    default:
                        this.chkfiar.Tag = submod.Id;
                        this.chkfiar.Checked = ischecksub;
                        this.chkfiar.CheckedChanged += Chkfiar_CheckedChanged;
                        break;
                }
            }
        }

        private void GetAllStatusProvider(ModuleBE item, bool iscontent)
        {
            this.chkprovider.Tag = item.Id;
            this.chkprovider.Checked = iscontent;
            this.chkprovider.CheckedChanged += Chkprovider_CheckedChanged;
            foreach (var submod in item.SubModules)
            {
                bool ischecksub = submod.ModuleId == item.Id;
                switch (submod.Name)
                {
                    case "ABM Proveedor":
                        this.chkabmprovider.Tag = submod.Id;
                        this.chkabmprovider.Checked = ischecksub;
                        this.chkabmprovider.CheckedChanged += Chkabmprovider_CheckedChanged;
                        break;
                    default:
                        this.chkconsultantproviderproduct.Tag = submod.Id;
                        this.chkconsultantproviderproduct.Checked = ischecksub;
                        this.chkconsultantproviderproduct.CheckedChanged += Chkconsultantproviderproduct_CheckedChanged;
                        break;
                }
            }
        }

        private void GetAllStatusUserManagement(ModuleBE item, bool iscontent)
        {
            this.chkgestionuser.Tag = item.Id;
            this.chkgestionuser.Checked = iscontent;
            this.chkgestionuser.CheckedChanged += Chkgestionuser_CheckedChanged;
            foreach (var submod in item.SubModules)
            {
                bool ischecksub = submod.ModuleId == item.Id;
                switch (submod.Name)
                {
                    case "ABM Usuario":
                        this.chkambuser.Tag = submod.Id;
                        this.chkambuser.Checked = ischecksub;
                        this.chkambuser.CheckedChanged += Chkambuser_CheckedChanged;
                        break;
                    default:
                        this.chkchangepaass.Tag = submod.Id;
                        this.chkchangepaass.Checked = ischecksub;
                        this.chkchangepaass.CheckedChanged += Chkchangepaass_CheckedChanged; ;
                        break;
                }
            }
        }

        private void Chkchangepaass_CheckedChanged(object sender, EventArgs e)
        {
            var be = mabe.Find(u => u.ModuleId == chkgestionuser.Tag.ToString());
            this.WatchCheckBoxSelectAll(pnlgestionuser.Controls.OfType<CheckBox>(), this.chkselectallgestionuser);
            this.AddDataSubModel(this.chkchangepaass, be);
        }

        private void Chkambuser_CheckedChanged(object sender, EventArgs e)
        {
            var be = mabe.Find(u => u.ModuleId == chkgestionuser.Tag.ToString());
            this.WatchCheckBoxSelectAll(pnlgestionuser.Controls.OfType<CheckBox>(), this.chkselectallgestionuser);
            this.AddDataSubModel(this.chkambuser, be);
        }

        private void GetAllStatusReport(ModuleBE item, bool iscontent)
        {
            this.chkreport.Tag = item.Id;
            this.chkreport.Checked = iscontent;
            this.chkreport.CheckedChanged += Chkreport_CheckedChanged;
            foreach (var submod in item.SubModules)
            {
                bool ischecksub = submod.ModuleId == item.Id;
                switch (submod.Name)
                {
                    case "Ventas":
                        this.chksalereport.Tag = submod.Id;
                        this.chksalereport.Checked = ischecksub;
                        this.chksalereport.CheckedChanged += Chksalereport_CheckedChanged;
                        break;
                    case "Productos":
                        this.chkproductreport.Tag = submod.Id;
                        this.chkproductreport.Checked = ischecksub;
                        this.chkproductreport.CheckedChanged += Chkproductreport_CheckedChanged;
                        break;
                    default:
                        this.chkproviderreport.Tag = submod.Id;
                        this.chkproviderreport.Checked = ischecksub;
                        this.chkproviderreport.CheckedChanged += Chkproviderreport_CheckedChanged;
                        break;
                }
            }
        }

        private void GetAllStatusSecurity(ModuleBE item, bool iscontent)
        {
            this.chksecurity.Tag = item.Id;
            this.chksecurity.Checked = iscontent;
            this.chksecurity.CheckedChanged += Chksecurity_CheckedChanged;
            foreach (var submod in item.SubModules)
            {
                bool ischecksub = submod.ModuleId == item.Id;
                switch (submod.Name)
                {
                    case "ABM Permiso":
                        this.chkabmrol.Tag = submod.Id;
                        this.chkabmrol.Checked = ischecksub;
                        this.chkabmrol.CheckedChanged += Chkabmrol_CheckedChanged;
                        break;
                    case "ABM forma de pago":
                        this.chkpayform.Tag = submod.Id;
                        this.chkpayform.Checked = ischecksub;
                        this.chkpayform.CheckedChanged += Chkpayform_CheckedChanged;
                        break;
                    case "Gestionar turno":
                        this.chkgestionturn.Tag = submod.Id;
                        this.chkgestionturn.Checked = ischecksub;
                        this.chkgestionturn.CheckedChanged += Chkgestionturn_CheckedChanged;
                        break;
                    case "ABM categoria":
                        this.chkabtcategory.Tag = submod.Id;
                        this.chkabtcategory.Checked = ischecksub;
                        this.chkabtcategory.CheckedChanged += Chkabtcategory_CheckedChanged;
                        break;
                    case "Incremento nocturno":
                        this.chkincrementnigth.Tag = submod.Id;
                        this.chkincrementnigth.Checked = ischecksub;
                        this.chkincrementnigth.CheckedChanged += Chkincrementnigth_CheckedChanged;
                        break;
                    case "Actualizar precio":
                        this.chkupdateprice.Tag = submod.Id;
                        this.chkupdateprice.Checked = ischecksub;
                        this.chkupdateprice.CheckedChanged += Chkupdateprice_CheckedChanged;
                        break;
                    case "Abrir turno":
                        this.chkopenturn.Tag = submod.Id;
                        this.chkopenturn.Checked = ischecksub;
                        this.chkopenturn.CheckedChanged += Chkopenturn_CheckedChanged;
                        break;
                    case "Cerrar turno":
                        this.chkcloseturn.Tag = submod.Id;
                        this.chkcloseturn.Checked = ischecksub;
                        this.chkcloseturn.CheckedChanged += Chkcloseturn_CheckedChanged;
                        break;
                    //case "Modificar permiso":
                    //    this.chkmodifyrol.Tag = submod.Id;
                    //    this.chkmodifyrol.Checked = ischecksub;
                    //    this.chkmodifyrol.CheckedChanged += Chkmodifyrol_CheckedChanged;
                    //    break;
                    default:
                        //this.chkturnclose.Tag = submod.Id;
                        //this.chkturnclose.Checked = ischecksub;
                        //this.chkturnclose.CheckedChanged += Chkturnclose_CheckedChanged;
                        this.chkmodifyrol.Tag = submod.Id;
                        this.chkmodifyrol.Checked = ischecksub;
                        this.chkmodifyrol.CheckedChanged += Chkmodifyrol_CheckedChanged;
                        break;
                }
            }
        }

        private void GetAllStatusMouvement(ModuleBE item, bool iscontent)
        {
            this.chkmouvement.Tag = item.Id;
            this.chkmouvement.Checked = iscontent;
            this.chkmouvement.CheckedChanged += Chkmouvement_CheckedChanged;
            foreach (var submod in item.SubModules)
            {
                bool ischecksub = submod.ModuleId == item.Id;
                switch (submod.Name)
                {
                    case "ABM movimiento":
                        this.chkabmmouvement.Tag = submod.Id;
                        this.chkabmmouvement.Checked = ischecksub;
                        this.chkabmmouvement.CheckedChanged += Chkabmmouvement_CheckedChanged;
                        break;                    
                    default:
                        this.chktipomouv.Tag = submod.Id;
                        this.chktipomouv.Checked = ischecksub;
                        this.chktipomouv.CheckedChanged += Chktipomouv_CheckedChanged;
                        break;
                }
            }
        }
        private void Chktipomouv_CheckedChanged(object sender, EventArgs e)
        {
            var be = mabe.Find(u => u.ModuleId == chkmouvement.Tag.ToString());
            this.WatchCheckBoxSelectAll(pnlmouvment.Controls.OfType<CheckBox>(), this.chkselectallmouvment);
            this.AddDataSubModel(this.chktipomouv, be);
        }

        private void Chkabmmouvement_CheckedChanged(object sender, EventArgs e)
        {
            var be = mabe.Find(u => u.ModuleId == chkmouvement.Tag.ToString());
            this.WatchCheckBoxSelectAll(pnlmouvment.Controls.OfType<CheckBox>(), this.chkselectallmouvment);
            this.AddDataSubModel(this.chkabmmouvement, be);
        }

        private void Chkturnclose_CheckedChanged(object sender, EventArgs e)
        {
            var be = mabe.Find(u => u.ModuleId == chksecurity.Tag.ToString());
            this.WatchCheckBoxSelectAll(pnlsecurity.Controls.OfType<CheckBox>(), this.chkselectallsecurity);
            //this.AddDataSubModel(this.chkturnclose, be);
        }

        private void Chkmodifyrol_CheckedChanged(object sender, EventArgs e)
        {
            var be = mabe.Find(u => u.ModuleId == chksecurity.Tag.ToString());
            this.WatchCheckBoxSelectAll(pnlsecurity.Controls.OfType<CheckBox>(), this.chkselectallsecurity);
            this.AddDataSubModel(this.chkmodifyrol, be);
        }

        private void Chkcloseturn_CheckedChanged(object sender, EventArgs e)
        {
            var be = mabe.Find(u => u.ModuleId == chksecurity.Tag.ToString());
            this.WatchCheckBoxSelectAll(pnlsecurity.Controls.OfType<CheckBox>(), this.chkselectallsecurity);
            this.AddDataSubModel(this.chkcloseturn, be);
        }

        private void Chkopenturn_CheckedChanged(object sender, EventArgs e)
        {
            var be = mabe.Find(u => u.ModuleId == chksecurity.Tag.ToString());
            this.WatchCheckBoxSelectAll(pnlsecurity.Controls.OfType<CheckBox>(), this.chkselectallsecurity);
            this.AddDataSubModel(this.chkopenturn, be);
        }

        private void Chkupdateprice_CheckedChanged(object sender, EventArgs e)
        {
            var be = mabe.Find(u => u.ModuleId == chksecurity.Tag.ToString());
            this.WatchCheckBoxSelectAll(pnlsecurity.Controls.OfType<CheckBox>(), this.chkselectallsecurity);
            this.AddDataSubModel(this.chkupdateprice, be);
        }

        private void Chkincrementnigth_CheckedChanged(object sender, EventArgs e)
        {
            var be = mabe.Find(u => u.ModuleId == chksecurity.Tag.ToString());
            this.WatchCheckBoxSelectAll(pnlsecurity.Controls.OfType<CheckBox>(), this.chkselectallsecurity);
            this.AddDataSubModel(this.chkincrementnigth, be);
        }

        private void Chkabtcategory_CheckedChanged(object sender, EventArgs e)
        {
            var be = mabe.Find(u => u.ModuleId == chksecurity.Tag.ToString());
            this.WatchCheckBoxSelectAll(pnlsecurity.Controls.OfType<CheckBox>(), this.chkselectallsecurity);
            this.AddDataSubModel(this.chkabtcategory, be);
        }

        private void Chkgestionturn_CheckedChanged(object sender, EventArgs e)
        {
            var be = mabe.Find(u => u.ModuleId == chksecurity.Tag.ToString());
            this.WatchCheckBoxSelectAll(pnlsecurity.Controls.OfType<CheckBox>(), this.chkselectallsecurity);
            this.AddDataSubModel(this.chkgestionturn, be);
        }

        private void Chkpayform_CheckedChanged(object sender, EventArgs e)
        {
            var be = mabe.Find(u => u.ModuleId == chksecurity.Tag.ToString());
            this.WatchCheckBoxSelectAll(pnlsecurity.Controls.OfType<CheckBox>(), this.chkselectallsecurity);
            this.AddDataSubModel(this.chkpayform, be);
        }

        private void Chkabmrol_CheckedChanged(object sender, EventArgs e)
        {
            var be = mabe.Find(u => u.ModuleId == chksecurity.Tag.ToString());
            this.WatchCheckBoxSelectAll(pnlsecurity.Controls.OfType<CheckBox>(), this.chkselectallsecurity);
            this.AddDataSubModel(this.chkabmrol, be);
        }

        private void Chksecurity_CheckedChanged(object sender, EventArgs e)
        {
            AddData(pnlsecurity, chkselectallsecurity, chksecurity);
        }

        private void Chkproviderreport_CheckedChanged(object sender, EventArgs e)
        {
            var be = mabe.Find(u => u.ModuleId == chkreport.Tag.ToString());
            this.WatchCheckBoxSelectAll(pnlreport.Controls.OfType<CheckBox>(), this.chkselectallreport);
            this.AddDataSubModel(this.chkproviderreport, be);
        }

        private void Chkproductreport_CheckedChanged(object sender, EventArgs e)
        {
            var be = mabe.Find(u => u.ModuleId == chkreport.Tag.ToString());
            this.WatchCheckBoxSelectAll(pnlreport.Controls.OfType<CheckBox>(), this.chkselectallreport);
            this.AddDataSubModel(this.chkproductreport, be);
        }

        private void Chksalereport_CheckedChanged(object sender, EventArgs e)
        {
            var be = mabe.Find(u => u.ModuleId == chkreport.Tag.ToString());
            this.WatchCheckBoxSelectAll(pnlsubsale.Controls.OfType<CheckBox>(), this.chkselectallreport);
            this.AddDataSubModel(this.chksalereport, be);
        }

        private void Chkreport_CheckedChanged(object sender, EventArgs e)
        {
            AddData(pnlreport, chkselectallreport, chkreport);
        }

        private void Chkgestionuser_CheckedChanged(object sender, EventArgs e)
        {
            AddData(pnlgestionuser, chkselectallgestionuser, chkgestionuser);
        }

        private void Chkconsultantproviderproduct_CheckedChanged(object sender, EventArgs e)
        {
            var be = mabe.Find(u => u.ModuleId == chkprovider.Tag.ToString());
            this.WatchCheckBoxSelectAll(pnlprovider.Controls.OfType<CheckBox>(), this.chkselectallprovider);
            this.AddDataSubModel(this.chkconsultantproviderproduct, be);
        }

        private void Chkabmprovider_CheckedChanged(object sender, EventArgs e)
        {
            var be = mabe.Find(u => u.ModuleId == chkprovider.Tag.ToString());
            this.WatchCheckBoxSelectAll(pnlprovider.Controls.OfType<CheckBox>(), this.chkselectallprovider);
            this.AddDataSubModel(this.chkabmprovider, be);
        }

        private void Chkprovider_CheckedChanged(object sender, EventArgs e)
        {
            AddData(pnlprovider, chkselectallprovider, chkprovider);
        }

        private void Chkfiar_CheckedChanged(object sender, EventArgs e)
        {
            var be = mabe.Find(u => u.ModuleId == chksale.Tag.ToString());
            this.WatchCheckBoxSelectAll(pnlsubsale.Controls.OfType<CheckBox>(), this.chkselectallsale);
            this.AddDataSubModel(this.chkfiar, be);
        }

        private void Chkconsultantprice_CheckedChanged(object sender, EventArgs e)
        {
            var be = mabe.Find(u => u.ModuleId == chksale.Tag.ToString());
            this.WatchCheckBoxSelectAll(pnlsubsale.Controls.OfType<CheckBox>(), this.chkselectallsale);
            this.AddDataSubModel(this.chkconsultantprice, be);
        }

        private void Chkconsultantsale_CheckedChanged(object sender, EventArgs e)
        {
            var be = mabe.Find(u => u.ModuleId == chksale.Tag.ToString());
            this.WatchCheckBoxSelectAll(pnlsubsale.Controls.OfType<CheckBox>(), this.chkselectallsale);
            this.AddDataSubModel(this.chkconsultantsale, be);
        }

        private void Chkstartsale_CheckedChanged(object sender, EventArgs e)
        {
            var be = mabe.Where(u => u.ModuleId == chksale.Tag.ToString());
            this.WatchCheckBoxSelectAll(pnlsubsale.Controls.OfType<CheckBox>(), this.chkselectallsale);
            if (be.Any())
            {
                this.AddDataSubModel(this.chkstartsale, be.FirstOrDefault());
            }
           
        }
        //bool isfirstsale = false;
        private void Chksale_CheckedChanged(object sender, EventArgs e)
        {
            if (!chksale.Checked)
            {
                this.GetStatusSelect(chkselectallsale);
                chkselectallsale.Enabled = false;
                pnlsubsale.Enabled = false;
                //isfirstsale = true;
                foreach (var item in pnlsubsale.Controls.OfType<CheckBox>())
                {
                    chkselectallsale.Checked = chksale.Checked;
                    item.Checked = chksale.Checked;
                }
            }
            else
            {
                chkselectallsale.Enabled = true;
                pnlsubsale.Enabled = true;
            }
            //if (isfirstsale)
            //{
                AddData(pnlsubsale, chkselectallsale, chksale);
            //}
        }

        private void Chkproduct_CheckedChanged(object sender, EventArgs e)
        {
            AddData(pnlproduct, chkselectallproduct, chkproduct);
        }

        private void Chkcreateoffer_CheckedChanged(object sender, EventArgs e)
        {
            var be = mabe.Find(u => u.ModuleId == chkproduct.Tag.ToString());
            this.WatchCheckBoxSelectAll(pnlproduct.Controls.OfType<CheckBox>(), this.chkselectallproduct);
            this.AddDataSubModel(this.chkcreateoffer, be);
        }

        private void Chkupdatestock_CheckedChanged(object sender, EventArgs e)
        {
            var be = mabe.Find(u => u.ModuleId == chkproduct.Tag.ToString());
            this.WatchCheckBoxSelectAll(pnlproduct.Controls.OfType<CheckBox>(), this.chkselectallproduct);
            this.AddDataSubModel(this.chkupdatestock, be);
        }

        private void Chkdetailproduct_CheckedChanged(object sender, EventArgs e)
        {
            var be = mabe.Find(u => u.ModuleId == chkproduct.Tag.ToString());
            this.WatchCheckBoxSelectAll(pnlproduct.Controls.OfType<CheckBox>(), this.chkselectallproduct);
            this.AddDataSubModel(this.chkdetailproduct, be);
        }

        private void Chkconsultantexpired_CheckedChanged(object sender, EventArgs e)
        {
            var be = mabe.Find(u => u.ModuleId == chkproduct.Tag.ToString());
            this.WatchCheckBoxSelectAll(pnlproduct.Controls.OfType<CheckBox>(), this.chkselectallproduct);
            this.AddDataSubModel(this.chkconsultantexpired, be);
        }

        private void Chkabmproduct_CheckedChanged(object sender, EventArgs e)
        {
            var be = mabe.Find(u => u.ModuleId == chkproduct.Tag.ToString());
            this.WatchCheckBoxSelectAll(pnlproduct.Controls.OfType<CheckBox>(), this.chkselectallproduct);
            this.AddDataSubModel(this.chkabmproduct, be);
        }

        private void WatchCheckBoxSelectAll(IEnumerable<CheckBox> cklall, CheckBox chk, Panel pnl = null, CheckBox cklselectall = null)
        {
            var isallcheck = cklall.Where(u => u.Checked == true);
            if (!isallcheck.Any())
                chk.Checked = false;
            if (isallcheck.Count() == cklall.Count())
            {
                chk.Checked = true;
                if (pnl != null)
                {
                    pnl.Enabled = true;
                    chk.Enabled = true;
                }

            }

        }

        private void AddDataSubModel(CheckBox chk, ModuleAccountBE be)
        {
            if (be == null)
                return;

            if (chk.Checked)
            {
                var state = be.SubModuleAccounts.Find(u => u.SubModuleId == chk.Tag.ToString());
                if (state == null)
                {
                    be.SubModuleAccounts.Add(new SubModuleAccountBE()
                    {
                        SubModuleId = chk.Tag.ToString(),
                        CreatedDate = DateTime.Now,
                        state = (Int32)StateEnum.Activeted,
                    });
                }
                else
                {
                    if (state.state == 2)
                    {
                        state.state = 1;
                    }
                }
            }
            else
            {
                //be.SubModuleAccounts.RemoveAll(u => u.SubModuleId == chk.Tag.ToString());

                be.SubModuleAccounts.ForEach(u =>
                {
                    if (u.SubModuleId == chk.Tag.ToString())
                    {
                        u.state = 2;
                    }
                });
            }
        }
        private void AddData(Panel pnl, CheckBox chkselect, CheckBox chkaction)
        {
            pnl.Enabled = chkaction.Checked;
            chkselect.Enabled = chkaction.Checked;

            if (!chkaction.Checked)
            {
                chkselect.Checked = chkaction.Checked;
                foreach (var item in pnl.Controls.OfType<CheckBox>())
                {
                    item.Checked = chkaction.Checked;
                }
                //mabe.RemoveAll(u => u.ModuleId == chkaction.Tag.ToString());
                mabe.ForEach(u =>
                {
                    if (u.ModuleId == chkaction.Tag.ToString())
                    {
                        u.state = 2;
                    }
                });
            }
            else
            {
                var ModuleAccount = modacc.Find(u => u.AccountId == this.accountid && u.ModuleId == chkaction.Tag.ToString());
                var state = mabe.Find(u => u.AccountId == this.accountid && u.ModuleId == chkaction.Tag.ToString());
                if (state == null)
                {
                    mabe.Add(new ModuleAccountBE()
                    {
                        ModuleId = chkaction.Tag.ToString(),
                        Id = ModuleAccount.Id,
                        AccountId = this.accountid,
                        CreatedDate = DateTime.Now,
                        state = (Int32)StateEnum.Activeted
                    });
                }
                else
                {
                    if (state.state == 2)
                    {
                        state.state = 1;
                    }
                }
                
            }
        }
        private void GetStatusSelect(CheckBox chk)
        {
            if (chk.Checked)
                chk.Text = "Deseleccionar todos";
            else
                chk.Text = "Seleccionar todos";
        }
        private void EnablePermission()
        {
            pnlsubsale.Enabled = false;
            pnlproduct.Enabled = false;
            pnlprovider.Enabled = false;
            pnlreport.Enabled = false;
            pnlgestionuser.Enabled = false;
            pnlmouvment.Enabled = false;
            pnlsecurity.Enabled = false;


            chkselectallgestionuser.Enabled = false;
            chkselectallmouvment.Enabled = false;
            chkselectallproduct.Enabled = false;
            chkselectallprovider.Enabled = false;
            chkselectallreport.Enabled = false;
            chkselectallsale.Enabled = false;
            chkselectallsecurity.Enabled = false;
        }
        private void chkselectallproduct_CheckedChanged(object sender, EventArgs e)
        {
            this.GetStatusSelect(chkselectallproduct);
            foreach (var item in pnlproduct.Controls.OfType<CheckBox>())
            {
                item.Checked = chkselectallproduct.Checked;
            }
        }

        private void frmuserpermision_Load(object sender, EventArgs e)
        {
            //this.GetActualRol(_be);
        }

        private void chkselectallsale_CheckedChanged(object sender, EventArgs e)
        {
            this.GetStatusSelect(chkselectallsale);
            foreach (var item in pnlsubsale.Controls.OfType<CheckBox>())
            {
                item.Checked = chkselectallsale.Checked;
            }
        }
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

        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //Drag Form
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.Style |= 0x20000; // <--- Minimize borderless form from taskbar
                return cp;
            }
        }

        private void FormRegionAndBorder(Form form, float radius, Graphics graph, Color borderColor, float borderSize)
        {
            if (this.WindowState != FormWindowState.Minimized)
            {
                using (GraphicsPath roundPath = Redesign.GetInstancia().GetRoundedPath(form.ClientRectangle, radius))
                using (Pen penBorder = new Pen(borderColor, borderSize))
                using (Matrix transform = new Matrix())
                {
                    graph.SmoothingMode = SmoothingMode.AntiAlias;
                    form.Region = new Region(roundPath);
                    if (borderSize >= 1)
                    {
                        Rectangle rect = form.ClientRectangle;
                        float scaleX = 1.0F - ((borderSize + 1) / rect.Width);
                        float scaleY = 1.0F - ((borderSize + 1) / rect.Height);

                        transform.Scale(scaleX, scaleY);
                        transform.Translate(borderSize / 1.6F, borderSize / 1.6F);

                        graph.Transform = transform;
                        graph.DrawPath(penBorder, roundPath);
                    }
                }
            }
        }
        private FormBoundsColors GetFormBoundsColors()
        {
            var fbColor = new FormBoundsColors();
            using (var bmp = new Bitmap(1, 1))
            using (Graphics graph = Graphics.FromImage(bmp))
            {
                Rectangle rectBmp = new Rectangle(0, 0, 1, 1);

                //Top Left
                rectBmp.X = this.Bounds.X - 1;
                rectBmp.Y = this.Bounds.Y;
                graph.CopyFromScreen(rectBmp.Location, Point.Empty, rectBmp.Size);
                fbColor.TopLeftColor = bmp.GetPixel(0, 0);

                //Top Right
                rectBmp.X = this.Bounds.Right;
                rectBmp.Y = this.Bounds.Y;
                graph.CopyFromScreen(rectBmp.Location, Point.Empty, rectBmp.Size);
                fbColor.TopRightColor = bmp.GetPixel(0, 0);

                //Bottom Left
                rectBmp.X = this.Bounds.X;
                rectBmp.Y = this.Bounds.Bottom;
                graph.CopyFromScreen(rectBmp.Location, Point.Empty, rectBmp.Size);
                fbColor.BottomLeftColor = bmp.GetPixel(0, 0);

                //Bottom Right
                rectBmp.X = this.Bounds.Right;
                rectBmp.Y = this.Bounds.Bottom;
                graph.CopyFromScreen(rectBmp.Location, Point.Empty, rectBmp.Size);
                fbColor.BottomRightColor = bmp.GetPixel(0, 0);
            }
            return fbColor;
        }

        private void frmuserpermision_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            Rectangle rectForm = this.ClientRectangle;
            int mWidht = rectForm.Width / 2;
            int mHeight = rectForm.Height / 2;
            var fbColors = GetFormBoundsColors();
            //-> SET ROUNDED REGION AND BORDER
            FormRegionAndBorder(this, borderRadius, e.Graphics, borderColor, borderSize);
        }

        private void frmuserpermision_ResizeEnd(object sender, EventArgs e)
        {
            this.Invalidate();
        }

        private void frmuserpermision_SizeChanged(object sender, EventArgs e)
        {
            this.Invalidate();
        }

        private void frmuserpermision_Validated(object sender, EventArgs e)
        {
            this.Invalidate();
        }

        private void frmuserpermision_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void label5_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void panel4_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btncancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #region Permiso
        private void GetPermission(AccountBE Login)
        {
            try
            {
                //Color color = SelectThemeColor();
                Color color = Color.AliceBlue;
                foreach (var pnlprincipal in this.chkBox.ToList())
                {
                    IEnumerable<ModuleAccountBE> modbe = Login.ModuleAccounts.Where(l => l.Module.Name.ToLower() == pnlprincipal.Text.ToLower());
                    if (modbe.Any())
                    {
                        var list = modbe;
                        foreach (var item in modbe)
                        {
                            switch (item.Module.Name)
                            {
                                case "Productos":
                                    chkproduct.Tag = item.ModuleId;
                                    //chkproduct.CheckedChanged += Chkproduct_CheckedChanged;
                                    foreach (var item2 in pnlproduct.Controls.OfType<CheckBox>())
                                    {
                                        var btn = item.SubModuleAccounts.Find(l => l.SubModule.Name.ToLower() == item2.Text.ToLower());
                                        if (btn == null)
                                        {
                                            item2.Checked = false;
                                        }
                                        else
                                        {
                                            item2.Checked = true;
                                            item2.Enabled = true;
                                            item2.Enabled = true;
                                            this.chkselectallproduct.Enabled = true;
                                            this.pnlproduct.Enabled = true;
                                            chkproduct.Checked = true;

                                            switch (item2.Text)
                                            {
                                                case "ABM Producto":
                                                    this.chkabmproduct.Tag = btn.Id;
                                                    this.chkabmproduct.CheckedChanged += Chkabmproduct_CheckedChanged;
                                                    break;
                                                case "Consultar Vencimiento":
                                                    this.chkconsultantexpired.Tag = btn.Id;
                                                    this.chkconsultantexpired.CheckedChanged += Chkconsultantexpired_CheckedChanged;
                                                    break;
                                                case "Detalle Producto":
                                                    this.chkdetailproduct.Tag = btn.Id;
                                                    this.chkdetailproduct.CheckedChanged += Chkdetailproduct_CheckedChanged;
                                                    break;
                                                case "Actualizar stock":
                                                    this.chkupdatestock.Tag = btn.Id;
                                                    this.chkupdatestock.CheckedChanged += Chkupdatestock_CheckedChanged; ;
                                                    break;
                                                default:
                                                    this.chkcreateoffer.Tag = btn.Id;
                                                    this.chkcreateoffer.CheckedChanged += Chkcreateoffer_CheckedChanged;
                                                    break;
                                            }
                                        }
                                        
                                       
                                       
                                    }
                                    this.WatchCheckBoxSelectAll(pnlproduct.Controls.OfType<CheckBox>(), this.chkselectallproduct, this.pnlproduct);
                                    this.GetStatusSelect(chkselectallproduct);
                                    break;
                                case "Ventas":
                                    chksale.Tag = item.ModuleId;
                                    foreach (var item2 in pnlsubsale.Controls.OfType<CheckBox>())
                                    {
                                        var btn = item.SubModuleAccounts.Find(l => l.SubModule.Name.ToLower() == item2.Text.ToLower());
                                        if (btn == null)
                                        {
                                            item2.Checked = false;
                                        }
                                        else
                                        {
                                            chksale.Checked = true;
                                            item2.Checked = true;
                                            item2.Enabled = true;
                                            pnlsubsale.Enabled = true;
                                            this.chkselectallsale.Enabled = true;
                                        }
                                    }
                                    this.WatchCheckBoxSelectAll(pnlsubsale.Controls.OfType<CheckBox>(), this.chkselectallsale, this.pnlsubsale);
                                    this.GetStatusSelect(chkselectallsale);
                                    break;
                                case "Proveedores":
                                    chkprovider.Tag = item.ModuleId;
                                    foreach (var item2 in pnlprovider.Controls.OfType<CheckBox>())
                                    {
                                        var btn = item.SubModuleAccounts.FirstOrDefault(l => l.SubModule.Name.ToLower() == item2.Text.ToLower());
                                        if (btn == null)
                                        {
                                            item2.Checked = false;
                                        }
                                        else
                                        {
                                            chkprovider.Checked = true;
                                            item2.Checked = true;
                                            item2.Enabled = true;
                                            pnlprovider.Enabled = true;
                                            this.chkprovider.Enabled = true;
                                            chkselectallprovider.Enabled = true;
                                        }
                                    }
                                    this.WatchCheckBoxSelectAll(pnlprovider.Controls.OfType<CheckBox>(), this.chkselectallprovider, this.pnlprovider);
                                    this.GetStatusSelect(chkselectallprovider);
                                    break;
                                case "Gestion de Usuarios":
                                    chkgestionuser.Tag = item.ModuleId;
                                    foreach (var item2 in pnlgestionuser.Controls.OfType<CheckBox>())
                                    {
                                        var btn = item.SubModuleAccounts.Find(l => l.SubModule.Name.ToLower() == item2.Text.ToLower());
                                        if (btn == null)
                                        {
                                            item2.Checked = false;
                                        }
                                        else
                                        {
                                            chkgestionuser.Checked = true;
                                            item2.Checked = true;
                                            item2.Enabled = true;
                                            pnlgestionuser.Enabled = true;
                                            this.chkgestionuser.Enabled = true;
                                            chkselectallgestionuser.Enabled = true;
                                        }
                                    }
                                    this.WatchCheckBoxSelectAll(pnlgestionuser.Controls.OfType<CheckBox>(), this.chkselectallgestionuser, this.pnlgestionuser);
                                    this.GetStatusSelect(chkselectallgestionuser);
                                    break;
                                case "Reportes":
                                    chkreport.Tag = item.ModuleId;
                                    foreach (var item2 in pnlreport.Controls.OfType<CheckBox>())
                                    {
                                        var btn = item.SubModuleAccounts.Find(l => l.SubModule.Name.ToLower() == item2.Text.ToLower());
                                        if (btn == null)
                                        {
                                            item2.Checked = false;
                                        }
                                        else
                                        {
                                            chkreport.Checked = true;
                                            item2.Checked = true;
                                            item2.Enabled = true;
                                            pnlreport.Enabled = true;
                                            this.chkreport.Enabled = true;
                                            chkselectallreport.Enabled = true;
                                        }
                                    }
                                    this.WatchCheckBoxSelectAll(pnlreport.Controls.OfType<CheckBox>(), this.chkselectallreport, this.pnlreport);
                                    this.GetStatusSelect(chkselectallreport);
                                    break;
                                case "Seguridades":
                                    chksecurity.Tag = item.ModuleId;
                                    foreach (var item2 in pnlsecurity.Controls.OfType<CheckBox>())
                                    {
                                        var btn = item.SubModuleAccounts.Find(l => l.SubModule.Name.ToLower() == item2.Text.ToLower());
                                        if (btn == null)
                                        {
                                            item2.Checked = false;
                                        }
                                        else
                                        {
                                            chksecurity.Checked = true;
                                            item2.Checked = true;
                                            item2.Enabled = true;
                                            pnlsecurity.Enabled = true;
                                            this.chksecurity.Enabled = true;
                                            chkselectallsecurity.Enabled = true;
                                        }
                                    }
                                    this.WatchCheckBoxSelectAll(pnlsecurity.Controls.OfType<CheckBox>(), this.chkselectallsecurity, this.pnlsecurity);
                                    this.GetStatusSelect(chkselectallsecurity);
                                    break;
                                default:
                                    chkmouvement.Tag = item.ModuleId;
                                    foreach (var item2 in pnlmouvment.Controls.OfType<CheckBox>())
                                    {
                                        var btn = item.SubModuleAccounts.Find(l => l.SubModule.Name.ToLower() == item2.Text.ToLower());
                                        if (btn == null)
                                        {
                                            item2.Checked = false;
                                        }
                                        else
                                        {

                                            chkmouvement.Checked = true;
                                            item2.Checked = true;
                                            item2.Enabled = true;
                                            pnlmouvment.Enabled = true;
                                            this.chkmouvement.Enabled = true;
                                            chkselectallmouvment.Enabled = true;
                                        }
                                    }
                                    this.WatchCheckBoxSelectAll(pnlmouvment.Controls.OfType<CheckBox>(), this.chkselectallmouvment, this.pnlmouvment);
                                    this.GetStatusSelect(chkselectallmouvment);
                                    break;
                            }
                        }
                    }
                    else
                    {
                        switch (pnlprincipal.Text)
                        {
                            case "Productos":
                                foreach (var item2 in pnlproduct.Controls.OfType<CheckBox>())
                                {
                                    item2.Checked = false;
                                    pnlproduct.Enabled = true;
                                    this.chkselectallproduct.Enabled = true;
                                }
                                break;
                            case "Ventas":
                                foreach (var item2 in pnlsubsale.Controls.OfType<CheckBox>())
                                {
                                    item2.Checked = false;
                                    pnlsubsale.Enabled = true;
                                    this.chkselectallsale.Enabled = true;
                                }
                                break;
                            case "Proveedores":
                                foreach (var item2 in pnlprovider.Controls.OfType<CheckBox>())
                                {
                                    item2.Checked = false;
                                    pnlprovider.Enabled = true;
                                    chkselectallprovider.Enabled = true;
                                }
                                break;
                            case "Gestion de Usuarios":
                                foreach (var item2 in pnlgestionuser.Controls.OfType<CheckBox>())
                                {
                                    item2.Checked = false;
                                    pnlgestionuser.Enabled = true;
                                    chkselectallgestionuser.Enabled = true;
                                }
                                break;
                            case "Reportes":
                                foreach (var item2 in pnlreport.Controls.OfType<CheckBox>())
                                {
                                    item2.Checked = false;
                                    pnlreport.Enabled = true;
                                    chkselectallreport.Enabled = true;
                                }
                                break;
                            case "Seguridades":
                                foreach (var item2 in pnlsecurity.Controls.OfType<CheckBox>())
                                {
                                    item2.Checked = false;
                                    pnlsecurity.Enabled = true;
                                    chkselectallsecurity.Enabled = true;
                                }
                                break;
                            default:
                                foreach (var item2 in pnlmouvment.Controls.OfType<CheckBox>())
                                {
                                    item2.Checked = false;
                                    pnlmouvment.Enabled = true;
                                    chkselectallmouvment.Enabled = true;
                                }
                                break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                RJMessageBox.Show("Contacte al administrador", "Sistema de ventas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }

        private void GetFillCheck()
        {
            this.chkBox.Add(chksale);
            this.chkBox.Add(chkproduct);
            this.chkBox.Add(chksecurity);
            this.chkBox.Add(chkprovider);
            this.chkBox.Add(chkreport);
            this.chkBox.Add(chkmouvement);
            this.chkBox.Add(chkgestionuser);
        }
        #endregion

        private void btnsave_Click(object sender, EventArgs e)
        {
            if (mabe.Count == 0)
            {
                RJMessageBox.Show("No tiene que tener al menos un permiso habilitado", "Sistema de ventas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {

            }
        }

        private void chkselectallsecurity_CheckedChanged(object sender, EventArgs e)
        {
            this.GetStatusSelect(chkselectallsecurity);
            foreach (var item in pnlsecurity.Controls.OfType<CheckBox>())
            {
                item.Checked = chkselectallsecurity.Checked;
            }
        }

        private void chkselectallprovider_CheckedChanged(object sender, EventArgs e)
        {
            this.GetStatusSelect(chkselectallprovider);
            foreach (var item in pnlprovider.Controls.OfType<CheckBox>())
            {
                item.Checked = chkselectallprovider.Checked;
            }
        }

        private void chkselectallreport_CheckedChanged(object sender, EventArgs e)
        {
            this.GetStatusSelect(chkselectallreport);
            foreach (var item in pnlreport.Controls.OfType<CheckBox>())
            {
                item.Checked = chkselectallreport.Checked;
            }
        }

        private void chkselectallmouvment_CheckedChanged(object sender, EventArgs e)
        {
            this.GetStatusSelect(chkselectallmouvment);
            foreach (var item in pnlmouvment.Controls.OfType<CheckBox>())
            {
                item.Checked = chkselectallmouvment.Checked;
            }
        }

        private void chkselectallgestionuser_CheckedChanged(object sender, EventArgs e)
        {

            this.GetStatusSelect(chkselectallgestionuser);
            foreach (var item in pnlgestionuser.Controls.OfType<CheckBox>())
            {
                item.Checked = chkselectallgestionuser.Checked;
            }
        }

        private void chkproduct_CheckedChanged_1(object sender, EventArgs e)
        {
            if (!chkproduct.Checked)
            {
                this.GetStatusSelect(chkselectallproduct);
                chkselectallproduct.Enabled = false;
                pnlproduct.Enabled = false;
                foreach (var item in pnlproduct.Controls.OfType<CheckBox>())
                {
                    chkselectallproduct.Checked = chkproduct.Checked;
                    item.Checked = chkproduct.Checked;
                }
            }
            else
            {
                chkselectallproduct.Enabled = true;
                pnlproduct.Enabled = true;
            }
            //AddData(pnlproduct, chkselectallproduct, chkproduct);
        }

        private void chksecurity_CheckedChanged_1(object sender, EventArgs e)
        {
            if (!chksecurity.Checked)
            {
                this.GetStatusSelect(chkselectallsecurity);
                chkselectallsecurity.Enabled = false;
                pnlsecurity.Enabled = false;
                foreach (var item in pnlsecurity.Controls.OfType<CheckBox>())
                {
                    chkselectallsecurity.Checked = chksecurity.Checked;
                    item.Checked = chksecurity.Checked;
                }
            }
            else
            {
                chkselectallsecurity.Enabled = true;
                pnlsecurity.Enabled = true;
            }
        }

        private void chkprovider_CheckedChanged_1(object sender, EventArgs e)
        {
            if (!chkprovider.Checked)
            {
                this.GetStatusSelect(chkselectallprovider);
                chkselectallprovider.Enabled = false;
                pnlprovider.Enabled = false;
                foreach (var item in pnlprovider.Controls.OfType<CheckBox>())
                {
                    chkselectallprovider.Checked = chkprovider.Checked;
                    item.Checked = chkprovider.Checked;
                }
            }
            else
            {
                chkselectallprovider.Enabled = true;
                pnlprovider.Enabled = true;
            }
        }

        private void chkreport_CheckedChanged_1(object sender, EventArgs e)
        {
            if (!chkreport.Checked)
            {
                this.GetStatusSelect(chkselectallreport);
                chkselectallreport.Enabled = false;
                pnlreport.Enabled = false;
                foreach (var item in pnlreport.Controls.OfType<CheckBox>())
                {
                    chkselectallreport.Checked = chkreport.Checked;
                    item.Checked = chkreport.Checked;
                }
            }
            else
            {
                chkselectallreport.Enabled = true;
                pnlreport.Enabled = true;
            }
        }

        private void chkmouvement_CheckedChanged_1(object sender, EventArgs e)
        {
            if (!chkmouvement.Checked)
            {
                this.GetStatusSelect(chkselectallmouvment);
                chkselectallmouvment.Enabled = false;
                pnlmouvment.Enabled = false;
                foreach (var item in pnlmouvment.Controls.OfType<CheckBox>())
                {
                    chkselectallmouvment.Checked = chkmouvement.Checked;
                    item.Checked = chkmouvement.Checked;
                }
            }
            else
            {
                chkselectallmouvment.Enabled = true;
                pnlmouvment.Enabled = true;
            }
        }

        private void chkgestionuser_CheckedChanged_1(object sender, EventArgs e)
        {
            if (!chkgestionuser.Checked)
            {
                this.GetStatusSelect(chkselectallgestionuser);
                chkselectallgestionuser.Enabled = false;
                pnlgestionuser.Enabled = false;
                foreach (var item in pnlgestionuser.Controls.OfType<CheckBox>())
                {
                    chkselectallgestionuser.Checked = chkgestionuser.Checked;
                    item.Checked = chkgestionuser.Checked;
                }
            }
            else
            {
                chkselectallgestionuser.Enabled = true;
                pnlgestionuser.Enabled = true;
            }
        }
    }
}
