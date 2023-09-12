using ApplicationView.BusnessEntities.BE;
using ApplicationView.Forms.MsgBox;
using ApplicationView.Patern.singleton;
using ApplicationView.Resolver.Enums;
using ApplicationView.Share;
using ApplicationView.VariableSeesion;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ApplicationView.Forms.Roles
{
    public partial class frmrolelist : Form
    {
        public bool isselectrole = false;
        public List<ModuleAccountBE> mabe = null;
        public RoleBE rolbe = null;
        int count = 0;
        public frmrolelist()
        {
            InitializeComponent();
            this.isselectrole = false;
            this.EnablePermission();
            mabe = new List<ModuleAccountBE>();
            rolbe = new RoleBE();
            LoginInfo.pageactual = 1;
        }
        private void LoadList()
        {
            this.dataList.DataSource = RepoPathern.RoleService.GetAll(1, LoginInfo.pageactual, LoginInfo.pagesize, "Id", "asc", "", ref count);
            this.HideColumn();
            this.GetPagination(Convert.ToInt32(dataList.Rows.Count));
        }

        private void LoadPermisionList()
        {
            var mod = RepoPathern.ModuleService.GetAll(1, LoginInfo.pageactual, LoginInfo.pagesize, "Id", "asc", "", ref count);            
            foreach (var item in mod)
            {
                switch (item.Name)
                {
                    case "Productos":
                        chkproduct.Tag = item.Id;
                        chkproduct.CheckedChanged += Chkproduct_CheckedChanged;
                        foreach (var submod in item.SubModules)
                        {
                            switch (submod.Name)
                            {
                                case "ABM Producto":
                                    this.chkabmproduct.Tag = submod.Id;
                                    this.chkabmproduct.CheckedChanged += Chkabmproduct_CheckedChanged;
                                    break;
                                case "Consultar Vencimiento":
                                    this.chkconsultantexpired.Tag = submod.Id;
                                    this.chkconsultantexpired.CheckedChanged += Chkconsultantexpired_CheckedChanged;
                                    break;
                                case "Detalle Producto":
                                    this.chkdetailproduct.Tag = submod.Id;
                                    this.chkdetailproduct.CheckedChanged += Chkdetailproduct_CheckedChanged;
                                    break;
                                case "Actualizar stock":
                                    this.chkupdatestock.Tag = submod.Id;
                                    this.chkupdatestock.CheckedChanged += Chkupdatestock_CheckedChanged; ;
                                    break;
                                default:
                                    this.chkcreateoffer.Tag = submod.Id;
                                    this.chkcreateoffer.CheckedChanged += Chkcreateoffer_CheckedChanged;
                                    break;
                            }
                        }
                        break;
                    case "Ventas":
                        chksale.Tag = item.Id;
                        chksale.CheckedChanged += Chksale_CheckedChanged;
                        foreach (var submod in item.SubModules)
                        {
                            switch (submod.Name)
                            {
                                case "Iniciar venta":
                                    this.chkstartsale.Tag = submod.Id;
                                    this.chkstartsale.CheckedChanged += Chkstartsale_CheckedChanged;
                                    break;
                                case "Consultar precio":
                                    this.chkconsultantsale.Tag = submod.Id;
                                    this.chkconsultantsale.CheckedChanged += Chkconsultantsale_CheckedChanged;
                                    break;
                                case "Consultar venta":
                                    this.chkconsultantprice.Tag = submod.Id;
                                    this.chkconsultantprice.CheckedChanged += Chkconsultantprice_CheckedChanged;
                                    break;
                                default:
                                    this.chkfiar.Tag = submod.Id;
                                    this.chkfiar.CheckedChanged += Chkfiar_CheckedChanged;
                                    break;
                            }                            
                        }
                        break;
                    case "Proveedores":
                        chkprovider.Tag = item.Id;
                        chkprovider.CheckedChanged += Chkprovider_CheckedChanged;
                        foreach (var submod in item.SubModules)
                        {
                            switch (submod.Name)
                            {
                                case "ABM Proveedor":
                                    this.chkabmprovider.Tag = submod.Id;
                                    this.chkabmprovider.CheckedChanged += Chkabmprovider_CheckedChanged;
                                    break;
                                default:
                                    this.chkconsultantproviderproduct.Tag = submod.Id;
                                    this.chkconsultantproviderproduct.CheckedChanged += Chkconsultantproviderproduct_CheckedChanged;
                                    break;
                            }
                        }
                        break;
                    case "Gestion de Usuarios":
                        chkgestionuser.Tag = item.Id;
                        chkgestionuser.CheckedChanged += Chkgestionuser_CheckedChanged; ;
                        foreach (var submod in item.SubModules)
                        {
                            switch (submod.Name)
                            {
                                case "ABM Usuario":
                                    this.chkambuser.Tag = submod.Id;
                                    this.chkambuser.CheckedChanged += Chkambuser_CheckedChanged;
                                    break;
                                default:
                                    this.chkchangepaass.Tag = submod.Id;
                                    this.chkchangepaass.CheckedChanged += Chkchangepaass_CheckedChanged;
                                    break;
                            }
                        }
                        break;
                    case "Reportes":
                        chkreport.Tag = item.Id;
                        chkreport.CheckedChanged += Chkreport_CheckedChanged;
                        foreach (var submod in item.SubModules)
                        {
                            switch (submod.Name)
                            {
                                case "Ventas":
                                    this.chksalereport.Tag = submod.Id;
                                    this.chksalereport.CheckedChanged += Chksalereport_CheckedChanged;
                                    break;
                                case "Productos":
                                    this.chkproductreport.Tag = submod.Id;
                                    this.chkproductreport.CheckedChanged += Chkproductreport_CheckedChanged;
                                    break;
                                default:
                                    this.chkproviderreport.Tag = submod.Id;
                                    this.chkproviderreport.CheckedChanged += Chkproviderreport_CheckedChanged;
                                    break;
                            }
                        }
                        break;
                    case "Seguridades":
                        chksecurity.Tag = item.Id;
                        chksecurity.CheckedChanged += Chksecurity_CheckedChanged;
                        foreach (var submod in item.SubModules)
                        {
                            switch (submod.Name)
                            {
                                case "ABM rol":
                                    this.chkabmrol.Tag = submod.Id;
                                    this.chkabmrol.CheckedChanged += Chkabmrol_CheckedChanged;
                                    break;
                                case "ABM forma de pago":
                                    this.chkpayform.Tag = submod.Id;
                                    this.chkpayform.CheckedChanged += Chkpayform_CheckedChanged;
                                    break;
                                case "Gestionar turno":
                                    this.chkgestionturn.Tag = submod.Id;
                                    this.chkgestionturn.CheckedChanged += Chkgestionturn_CheckedChanged;
                                    break;
                                case "ABM categoria":
                                    this.chkabtcategory.Tag = submod.Id;
                                    this.chkabtcategory.CheckedChanged += Chkabtcategory_CheckedChanged;
                                    break;
                                case "Incremento nocturno":
                                    this.chkincrementnigth.Tag = submod.Id;
                                    this.chkincrementnigth.CheckedChanged += Chkincrementnigth_CheckedChanged;
                                    break;
                                case "Actualizar precio":
                                    this.chkupdateprice.Tag = submod.Id;
                                    this.chkupdateprice.CheckedChanged += Chkupdateprice_CheckedChanged;
                                    break;
                                case "Abrir turno":
                                    this.chkopenturn.Tag = submod.Id;
                                    this.chkopenturn.CheckedChanged += Chkopenturn_CheckedChanged;
                                    break;
                                case "Cerrar turno":
                                    this.chkcloseturn.Tag = submod.Id;
                                    this.chkcloseturn.CheckedChanged += Chkcloseturn_CheckedChanged;
                                    break;
                                case "Modificar rol":
                                    this.chkmodifyrol.Tag = submod.Id;
                                    this.chkmodifyrol.CheckedChanged += Chkmodifyrol_CheckedChanged; ;
                                    break;
                                default:
                                    this.chkturnclose.Tag = submod.Id;
                                    this.chkturnclose.CheckedChanged += Chkturnclose_CheckedChanged;
                                    break;
                            }
                        }
                        break;
                    default:
                        chkmouvement.Tag = item.Id;
                        chkmouvement.CheckedChanged += Chkmouvement_CheckedChanged;
                        foreach (var submod in item.SubModules)
                        {
                            switch (submod.Name)
                            {
                                case "ABM movimiento":
                                    this.chkabmmouvement.Tag = submod.Id;
                                    this.chkabmmouvement.CheckedChanged += Chkabmmouvement_CheckedChanged;
                                    break;
                                default:
                                    this.chktipomouv.Tag = submod.Id;
                                    this.chktipomouv.CheckedChanged += Chktipomouv_CheckedChanged;
                                    break;
                            }
                        }
                        break;
                }
            }
        }

        private void Chkmodifyrol_CheckedChanged(object sender, EventArgs e)
        {
            var be = mabe.Single(u => u.ModuleId == chksecurity.Tag.ToString());
            this.WatchCheckBoxSelectAll(pnlsecurity.Controls.OfType<CheckBox>(), this.chkselectallsecurity);
            this.AddDataSubModel(this.chkmodifyrol, be);
        }

        private void Chkupdatestock_CheckedChanged(object sender, EventArgs e)
        {
            var be = mabe.Single(u => u.ModuleId == chkproduct.Tag.ToString());
            this.WatchCheckBoxSelectAll(pnlproduct.Controls.OfType<CheckBox>(), this.chkselectallproduct);
            this.AddDataSubModel(this.chkupdatestock, be);
        }

        private void Chktipomouv_CheckedChanged(object sender, EventArgs e)
        {
            var be = mabe.Single(u => u.ModuleId == chkmouvement.Tag.ToString());
            this.WatchCheckBoxSelectAll(pnlmouvment.Controls.OfType<CheckBox>(), this.chkselectallmouvment);
            this.AddDataSubModel(this.chktipomouv,be);
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

        private void Chkcreateoffer_CheckedChanged(object sender, EventArgs e)
        {
            var be = mabe.Single(u => u.ModuleId == chkproduct.Tag.ToString());
            this.WatchCheckBoxSelectAll(pnlproduct.Controls.OfType<CheckBox>(), this.chkselectallproduct);
            this.AddDataSubModel(this.chkcreateoffer, be);
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

        private void Chkgestionuser_CheckedChanged(object sender, EventArgs e)
        {
            AddData(pnlgestionuser, chkselectallgestionuser, chkgestionuser);
        }

        private void Chkmouvement_CheckedChanged(object sender, EventArgs e)
        {
            AddData(pnlmouvment, chkselectallmouvment, chkmouvement);
        }

        private void Chksecurity_CheckedChanged(object sender, EventArgs e)
        {
            AddData(pnlsecurity, chkselectallsecurity, chksecurity);
        }

        private void Chkreport_CheckedChanged(object sender, EventArgs e)
        {
            AddData(pnlreport, chkselectallreport, chkreport);
        }

        private void Chkprovider_CheckedChanged(object sender, EventArgs e)
        {
            AddData(pnlprovider, chkselectallprovider, chkprovider);
        }

        private void Chkproduct_CheckedChanged(object sender, EventArgs e)
        {
            AddData(pnlproduct, chkselectallproduct, chkproduct);
        }

        private void Chksale_CheckedChanged(object sender, EventArgs e)
        {
            AddData(pnlsubsale, chkselectallsale, chksale);
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
        private void HideColumn()
        {
            this.dataList.Columns["State"].Visible = false;
            this.dataList.Columns["FinalDate"].Visible = false;
            this.dataList.Columns["ModifiedDate"].Visible = false;
            //this.dataList.Columns["CreatedDate"].Visible = false;
        }
        private void GetPagination(int quantity)
        {
            if (quantity > 0)
            {
                LoginInfo.pageamount = count;
                LoginInfo.page = Math.Ceiling(LoginInfo.pageamount / LoginInfo.pagesize);

                this.lblStatus.Text = (LoginInfo.skipamount).ToString() + " / " + LoginInfo.page.ToString();
                this.lblTotal.Text = LoginInfo.pageamount.ToString();

                if (Convert.ToInt32(LoginInfo.skipamount) < Convert.ToInt32(LoginInfo.page))
                {
                    ShareMethod.GetInstance().HabilitarBtnPagination(new List<Button> { btnNext, btnLast }, true);
                }
                else
                {
                    ShareMethod.GetInstance().HabilitarBtnPagination(new List<Button> { btnNext, btnLast }, false);
                }

                if (LoginInfo.skipamount > 1)
                {
                    ShareMethod.GetInstance().HabilitarBtnPagination(new List<Button> { btnPrevious, btnFirst }, true);
                }
                else
                {
                    ShareMethod.GetInstance().HabilitarBtnPagination(new List<Button> { btnPrevious, btnFirst }, false);
                }
            }
            else
            {
                this.lblStatus.Text = (0 + " / " + 0);
                this.lblTotal.Text = (0).ToString();
            }
        }
        private void SearchByName()
        {
            if (!this.txtsearch.Text.Trim().Equals(""))
            {
                this.dataList.DataSource = RepoPathern.UserService.GetAll(1, LoginInfo.pageactual, LoginInfo.pagesize, "Id", "asc", this.txtsearch.Text.Trim(), ref count);
                this.GetPagination(Convert.ToInt32(dataList.Rows.Count));
            }
            else
                this.LoadList();

            this.HideColumn();
            lblTotal.Text = Convert.ToString(count);
        }

        private void btnsearch_Click(object sender, EventArgs e)
        {
            this.SearchByName();
        }

        private void frmrolelist_Load(object sender, EventArgs e)
        {
            this.LoadList();
            this.LoadPermisionList();
        }

        private void dataList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!chksale.Checked && !chkproduct.Checked && !chkprovider.Checked && !chkreport.Checked && !chkgestionuser.Checked && !chkmouvement.Checked && !chksecurity.Checked)
            {
                RJMessageBox.Show("Debe seleccionar por lo menos un permiso para este usuario", "Sistema de ventas", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (chksale.Checked)
            {
                bool ischecked = false;

                foreach (var item in pnlsubsale.Controls.OfType<CheckBox>())
                {
                    if (item.Checked)
                        ischecked = true;
                }

                if (!ischecked)
                {
                    RJMessageBox.Show("Debe seleccionar una action para la venta", "Sistema de ventas", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            if (chkproduct.Checked)
            {
                bool ischecked = false;

                foreach (var item in pnlproduct.Controls.OfType<CheckBox>())
                {
                    if (item.Checked)
                        ischecked = true;
                }

                if (!ischecked)
                {
                    RJMessageBox.Show("Debe seleccionar una action para el producto", "Sistema de ventas", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            if (chkprovider.Checked)
            {
                bool ischecked = false;

                foreach (var item in pnlprovider.Controls.OfType<CheckBox>())
                {
                    if (item.Checked)
                        ischecked = true;
                }

                if (!ischecked)
                {
                    RJMessageBox.Show("Debe seleccionar una action para el proveedor", "Sistema de ventas", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            if (chkreport.Checked)
            {
                bool ischecked = false;

                foreach (var item in pnlreport.Controls.OfType<CheckBox>())
                {
                    if (item.Checked)
                        ischecked = true;
                }

                if (!ischecked)
                {
                    RJMessageBox.Show("Debe seleccionar una action para el reporte", "Sistema de ventas", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            if (chkgestionuser.Checked)
            {
                bool ischecked = false;

                foreach (var item in pnlgestionuser.Controls.OfType<CheckBox>())
                {
                    if (item.Checked)
                        ischecked = true;
                }

                if (!ischecked)
                {
                    RJMessageBox.Show("Debe seleccionar una action para el usuario", "Sistema de ventas", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            if (chkmouvement.Checked)
            {
                bool ischecked = false;

                foreach (var item in pnlmouvment.Controls.OfType<CheckBox>())
                {
                    if (item.Checked)
                        ischecked = true;
                }

                if (!ischecked)
                {
                    RJMessageBox.Show("Debe seleccionar una action para el movimiento", "Sistema de ventas", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            if (chksecurity.Checked)
            {
                bool ischecked = false;

                foreach (var item in pnlsecurity.Controls.OfType<CheckBox>())
                {
                    if (item.Checked)
                        ischecked = true;
                }

                if (!ischecked)
                {
                    RJMessageBox.Show("Debe seleccionar una action para la seguridad", "Sistema de ventas", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            var selectedRow = this.dataList.SelectedRows[0];
            rolbe = (RoleBE)selectedRow.DataBoundItem;
            this.isselectrole = true;

            this.Close();
        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            ShareMethod.GetInstance().goFirst();
            LoadList();
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            ShareMethod.GetInstance().goPrevious();
            LoadList();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            ShareMethod.GetInstance().goNext();
            LoadList();
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            ShareMethod.GetInstance().goLast(this.count);
            LoadList();
        }

        private void chkselectallsale_CheckedChanged(object sender, EventArgs e)
        {
            this.GetStatusSelect(chkselectallsale);
            foreach (var item in pnlsubsale.Controls.OfType<CheckBox>())
            {
                item.Checked = chkselectallsale.Checked;
            }
        }

        private void chkselectallproduct_CheckedChanged(object sender, EventArgs e)
        {
            this.GetStatusSelect(chkselectallproduct);
            foreach (var item in pnlproduct.Controls.OfType<CheckBox>())
            {
                item.Checked = chkselectallproduct.Checked;
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

        private void chkselectallgestionuser_CheckedChanged(object sender, EventArgs e)
        {
            this.GetStatusSelect(chkselectallgestionuser);
            foreach (var item in pnlgestionuser.Controls.OfType<CheckBox>())
            {
                item.Checked = chkselectallgestionuser.Checked;
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

        private void chkselectallsecurity_CheckedChanged(object sender, EventArgs e)
        {
            this.GetStatusSelect(chkselectallsecurity);
            foreach (var item in pnlsecurity.Controls.OfType<CheckBox>())
            {
                item.Checked = chkselectallsecurity.Checked;
            }
        }
    
        private void GetStatusSelect(CheckBox chk)
        {
            if (chk.Checked)
                chk.Text = "Deseleccionar todos";
            else
                chk.Text = "Seleccionar todos";
        }

        private void WatchCheckBoxSelectAll(IEnumerable<CheckBox> cklall, CheckBox chk)
        {
            var isallcheck = cklall.Where(u => u.Checked == true);
            if (!isallcheck.Any())
                chk.Checked = false;
            if (isallcheck.Count() == cklall.Count())
                chk.Checked = true;

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
        private void AddData(Panel pnl,CheckBox chkselect, CheckBox chkaction)
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
    }
}
