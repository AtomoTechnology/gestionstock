using ApplicationView.BusnessEntities.BE;
using ApplicationView.Patern.singleton;
using ApplicationView.Resolver.Enums;
using ApplicationView.Theme;
using ApplicationView.VariableSeesion;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ApplicationView.Forms.Roles
{
    public partial class frmuserpermision : Form
    {
        public List<ModuleAccountBE> mabe = null;
        public RoleBE rolbe = null;
        int count = 0;
        ModuleBE _be;
        List<ModuleBE> listbe;

        private Random random;
        private int tempIndex;

        public frmuserpermision(List<ModuleBE> be)
        {
            InitializeComponent();
            mabe = new List<ModuleAccountBE>();
            if (be.Any())
            {
                _be = be[0];
                mabe = be[0].ModuleAccounts;
            }
            this.lblfirstname.Text = LoginInfo.LastName;
            this.lbllastname.Text = LoginInfo.FirstName;
            this.lblusername.Text = LoginInfo.UserName;
            this.lblrol.Text = LoginInfo.Role;

            this.EnablePermission();
            random = new Random();
            LoginInfo.pageactual = 1;
        }

        private void GetActualRol(ModuleBE be)
        {
            Color color = SelectThemeColor();
            var mod = RepoPathern.ModuleService.GetAll(1, LoginInfo.pageactual, LoginInfo.pagesize, "Id", "asc", "", ref count);
            if (be!!=null)
            {
                //foreach (var item in be.ModuleAccounts)
                //{
                //    bool iscontent = mod.Where(u => u.ModuleAccounts.Any(p =>p.SubModuleAccounts.Any(z => z.ModuleAccountId == p.Id))).Count() > 0 ? true : false;

                //    if (iscontent)
                //    {

                //    }
                //}
            }
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
                                this.chksecurity.Tag = item.Id;
                                this.chksecurity.CheckedChanged += Chksecurity_CheckedChanged;
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
            var be = mabe.Single(u => u.ModuleId == chkgestionuser.Tag.ToString());
            this.WatchCheckBoxSelectAll(pnlgestionuser.Controls.OfType<CheckBox>(), this.chkselectallgestionuser);
            this.AddDataSubModel(this.chkchangepaass, be);
        }

        private void Chkambuser_CheckedChanged(object sender, EventArgs e)
        {
            var be = mabe.Single(u => u.ModuleId == chkgestionuser.Tag.ToString());
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
                    case "ABM rol":
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
                    case "Modificar rol":
                        this.chkmodifyrol.Tag = submod.Id;
                        this.chkmodifyrol.Checked = ischecksub;
                        this.chkmodifyrol.CheckedChanged += Chkmodifyrol_CheckedChanged;
                        break;
                    default:
                        this.chkturnclose.Tag = submod.Id;
                        this.chkturnclose.Checked = ischecksub;
                        this.chkturnclose.CheckedChanged += Chkturnclose_CheckedChanged;
                        break;
                }
            }
        }

        private void GetAllStatusMouvement(ModuleBE item, bool iscontent)
        {
            this.chksecurity.Tag = item.Id;
            this.chksecurity.Checked = iscontent;
            this.chksecurity.CheckedChanged += Chksecurity_CheckedChanged;
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
            var be = mabe.Single(u => u.ModuleId == chkmouvement.Tag.ToString());
            this.WatchCheckBoxSelectAll(pnlmouvment.Controls.OfType<CheckBox>(), this.chkselectallmouvment);
            this.AddDataSubModel(this.chktipomouv, be);
        }

        private void Chkabmmouvement_CheckedChanged(object sender, EventArgs e)
        {
            var be = mabe.Single(u => u.ModuleId == chkmouvement.Tag.ToString());
            this.WatchCheckBoxSelectAll(pnlmouvment.Controls.OfType<CheckBox>(), this.chkselectallmouvment);
            this.AddDataSubModel(this.chkabmmouvement, be);
        }

        private void Chkturnclose_CheckedChanged(object sender, EventArgs e)
        {
            var be = mabe.Single(u => u.ModuleId == chksecurity.Tag.ToString());
            this.WatchCheckBoxSelectAll(pnlsecurity.Controls.OfType<CheckBox>(), this.chkselectallsecurity);
            this.AddDataSubModel(this.chkturnclose, be);
        }

        private void Chkmodifyrol_CheckedChanged(object sender, EventArgs e)
        {
            var be = mabe.Single(u => u.ModuleId == chksecurity.Tag.ToString());
            this.WatchCheckBoxSelectAll(pnlsecurity.Controls.OfType<CheckBox>(), this.chkselectallsecurity);
            this.AddDataSubModel(this.chkmodifyrol, be);
        }

        private void Chkcloseturn_CheckedChanged(object sender, EventArgs e)
        {
            var be = mabe.Single(u => u.ModuleId == chksecurity.Tag.ToString());
            this.WatchCheckBoxSelectAll(pnlsecurity.Controls.OfType<CheckBox>(), this.chkselectallsecurity);
            this.AddDataSubModel(this.chkcloseturn, be);
        }

        private void Chkopenturn_CheckedChanged(object sender, EventArgs e)
        {
            var be = mabe.Single(u => u.ModuleId == chksecurity.Tag.ToString());
            this.WatchCheckBoxSelectAll(pnlsecurity.Controls.OfType<CheckBox>(), this.chkselectallsecurity);
            this.AddDataSubModel(this.chkopenturn, be);
        }

        private void Chkupdateprice_CheckedChanged(object sender, EventArgs e)
        {
            var be = mabe.Single(u => u.ModuleId == chksecurity.Tag.ToString());
            this.WatchCheckBoxSelectAll(pnlsecurity.Controls.OfType<CheckBox>(), this.chkselectallsecurity);
            this.AddDataSubModel(this.chkupdateprice, be);
        }

        private void Chkincrementnigth_CheckedChanged(object sender, EventArgs e)
        {
            var be = mabe.Single(u => u.ModuleId == chksecurity.Tag.ToString());
            this.WatchCheckBoxSelectAll(pnlsecurity.Controls.OfType<CheckBox>(), this.chkselectallsecurity);
            this.AddDataSubModel(this.chkincrementnigth, be);
        }

        private void Chkabtcategory_CheckedChanged(object sender, EventArgs e)
        {
            var be = mabe.Single(u => u.ModuleId == chksecurity.Tag.ToString());
            this.WatchCheckBoxSelectAll(pnlsecurity.Controls.OfType<CheckBox>(), this.chkselectallsecurity);
            this.AddDataSubModel(this.chkabtcategory, be);
        }

        private void Chkgestionturn_CheckedChanged(object sender, EventArgs e)
        {
            var be = mabe.Single(u => u.ModuleId == chksecurity.Tag.ToString());
            this.WatchCheckBoxSelectAll(pnlsecurity.Controls.OfType<CheckBox>(), this.chkselectallsecurity);
            this.AddDataSubModel(this.chkgestionturn, be);
        }

        private void Chkpayform_CheckedChanged(object sender, EventArgs e)
        {
            var be = mabe.Single(u => u.ModuleId == chksecurity.Tag.ToString());
            this.WatchCheckBoxSelectAll(pnlsecurity.Controls.OfType<CheckBox>(), this.chkselectallsecurity);
            this.AddDataSubModel(this.chkpayform, be);
        }

        private void Chkabmrol_CheckedChanged(object sender, EventArgs e)
        {
            var be = mabe.Single(u => u.ModuleId == chksecurity.Tag.ToString());
            this.WatchCheckBoxSelectAll(pnlsecurity.Controls.OfType<CheckBox>(), this.chkselectallsecurity);
            this.AddDataSubModel(this.chkabmrol, be);
        }

        private void Chksecurity_CheckedChanged(object sender, EventArgs e)
        {
            AddData(pnlsecurity, chkselectallsecurity, chksecurity);
        }

        private void Chkproviderreport_CheckedChanged(object sender, EventArgs e)
        {
            var be = mabe.Single(u => u.ModuleId == chkreport.Tag.ToString());
            this.WatchCheckBoxSelectAll(pnlreport.Controls.OfType<CheckBox>(), this.chkselectallreport);
            this.AddDataSubModel(this.chkproviderreport, be);
        }

        private void Chkproductreport_CheckedChanged(object sender, EventArgs e)
        {
            var be = mabe.Single(u => u.ModuleId == chkreport.Tag.ToString());
            this.WatchCheckBoxSelectAll(pnlreport.Controls.OfType<CheckBox>(), this.chkselectallreport);
            this.AddDataSubModel(this.chkproductreport, be);
        }

        private void Chksalereport_CheckedChanged(object sender, EventArgs e)
        {
            var be = mabe.Single(u => u.ModuleId == chkreport.Tag.ToString());
            this.WatchCheckBoxSelectAll(pnlreport.Controls.OfType<CheckBox>(), this.chkselectallreport);
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
            var be = mabe.Single(u => u.ModuleId == chkprovider.Tag.ToString());
            this.WatchCheckBoxSelectAll(pnlprovider.Controls.OfType<CheckBox>(), this.chkselectallprovider);
            this.AddDataSubModel(this.chkconsultantproviderproduct, be);
        }

        private void Chkabmprovider_CheckedChanged(object sender, EventArgs e)
        {
            var be = mabe.Single(u => u.ModuleId == chkprovider.Tag.ToString());
            this.WatchCheckBoxSelectAll(pnlprovider.Controls.OfType<CheckBox>(), this.chkselectallprovider);
            this.AddDataSubModel(this.chkabmprovider, be);
        }

        private void Chkprovider_CheckedChanged(object sender, EventArgs e)
        {
            AddData(pnlprovider, chkselectallprovider, chkprovider);
        }

        private void Chkfiar_CheckedChanged(object sender, EventArgs e)
        {
            var be = mabe.Single(u => u.ModuleId == chksale.Tag.ToString());
            this.WatchCheckBoxSelectAll(pnlsubsale.Controls.OfType<CheckBox>(), this.chkselectallsale);
            this.AddDataSubModel(this.chkfiar, be);
        }

        private void Chkconsultantprice_CheckedChanged(object sender, EventArgs e)
        {
            var be = mabe.Single(u => u.ModuleId == chksale.Tag.ToString());
            this.WatchCheckBoxSelectAll(pnlsubsale.Controls.OfType<CheckBox>(), this.chkselectallsale);
            this.AddDataSubModel(this.chkconsultantprice, be);
        }

        private void Chkconsultantsale_CheckedChanged(object sender, EventArgs e)
        {
            var be = mabe.Single(u => u.ModuleId == chksale.Tag.ToString());
            this.WatchCheckBoxSelectAll(pnlsubsale.Controls.OfType<CheckBox>(), this.chkselectallsale);
            this.AddDataSubModel(this.chkconsultantsale, be);
        }

        private void Chkstartsale_CheckedChanged(object sender, EventArgs e)
        {
            var be = mabe.Single(u => u.ModuleId == chksale.Tag.ToString());
            this.WatchCheckBoxSelectAll(pnlsubsale.Controls.OfType<CheckBox>(), this.chkselectallsale);
            this.AddDataSubModel(this.chkstartsale, be);
        }
        private void Chksale_CheckedChanged(object sender, EventArgs e)
        {
            AddData(pnlsubsale, chkselectallsale, chksale);
        }

        private void Chkproduct_CheckedChanged(object sender, EventArgs e)
        {
            AddData(pnlproduct, chkselectallproduct, chkproduct);
        }

        private void Chkcreateoffer_CheckedChanged(object sender, EventArgs e)
        {
            var be = mabe.Single(u => u.ModuleId == chkproduct.Tag.ToString());
            this.WatchCheckBoxSelectAll(pnlproduct.Controls.OfType<CheckBox>(), this.chkselectallproduct);
            this.AddDataSubModel(this.chkcreateoffer, be);
        }

        private void Chkupdatestock_CheckedChanged(object sender, EventArgs e)
        {
            var be = mabe.Single(u => u.ModuleId == chkproduct.Tag.ToString());
            this.WatchCheckBoxSelectAll(pnlproduct.Controls.OfType<CheckBox>(), this.chkselectallproduct);
            this.AddDataSubModel(this.chkupdatestock, be);
        }

        private void Chkdetailproduct_CheckedChanged(object sender, EventArgs e)
        {
            var be = mabe.Single(u => u.ModuleId == chkproduct.Tag.ToString());
            this.WatchCheckBoxSelectAll(pnlproduct.Controls.OfType<CheckBox>(), this.chkselectallproduct);
            this.AddDataSubModel(this.chkdetailproduct, be);
        }

        private void Chkconsultantexpired_CheckedChanged(object sender, EventArgs e)
        {
            var be = mabe.Single(u => u.ModuleId == chkproduct.Tag.ToString());
            this.WatchCheckBoxSelectAll(pnlproduct.Controls.OfType<CheckBox>(), this.chkselectallproduct);
            this.AddDataSubModel(this.chkconsultantexpired, be);
        }

        private void Chkabmproduct_CheckedChanged(object sender, EventArgs e)
        {
            var be = mabe.Single(u => u.ModuleId == chkproduct.Tag.ToString());
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
            if (chk.Checked)
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
                be.SubModuleAccounts.RemoveAll(u => u.SubModuleId == chk.Tag.ToString());
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
                mabe.RemoveAll(u => u.ModuleId == chkaction.Tag.ToString());
            }
            else
            {
                mabe.Add(new ModuleAccountBE()
                {
                    ModuleId = chkaction.Tag.ToString(),
                    CreatedDate = DateTime.Now,
                    state = (Int32)StateEnum.Activeted
                });
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
            this.GetActualRol(_be);
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
    }
}
