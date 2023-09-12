using ApplicationView.BusnessEntities.BE;
using ApplicationView.Forms.Category;
using ApplicationView.Forms.MsgBox;
using ApplicationView.Forms.Provider;
using ApplicationView.Forms.RedesignForm;
using ApplicationView.Patern.singleton;
using ApplicationView.Resolver.Enums;
using ApplicationView.Resolver.Helper;
using ApplicationView.Resolver.HelperError.IExceptions;
using ApplicationView.Share;
using ApplicationView.VariableSeesion;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace ApplicationView.Forms.Product
{
    public partial class frmProduct : Form
    {
        private bool Isnuevo = false;
        private bool IsEditar = false;
        int count = 0;
        private int borderRadius = 20;
        private int borderSize = 2;
        //private Color borderColor = Color.White;
        private Color borderColor = Color.FromArgb(128, 128, 255);
        public frmProduct()
        {
            InitializeComponent();
            DataListHelper.SetGrid(this.dataList, 18);
            LoginInfo.pageactual = 1;

            this.FormBorderStyle = FormBorderStyle.None;
            this.Padding = new Padding(borderSize);
            this.btnclose.FlatAppearance.BorderSize = 0;
            //this.panelTitleBar.BackColor = borderColor;
            //this.BackColor = borderColor;
        }
        private void LoadList()
        {
            this.dataList.DataSource = RepoPathern.ProductService.GetAll(1, LoginInfo.pageactual, LoginInfo.pagesize, "Id", "asc", "", ref count);
            this.HideColumn();
            this.GetPagination();
        }

        private void frmProduct_Load(object sender, EventArgs e)
        {

            this.LoadList();
            if (count == 0)
            {
                this.tabControl1.SelectedIndex = 1;
                this.Habilitar(false);
                this.Botones();
                this.btnedit.Enabled = false;
            }
            else
            {
                this.Habilitar(false);
                this.Botones();
                this.btnedit.Enabled = false;
            }
        }
        private void HideColumn()
        {
            this.dataList.Columns["ckdelete"].Visible = false;
            this.dataList.Columns["FinalDate"].Visible = false;
            this.dataList.Columns["CreatedDate"].Visible = false;
            this.dataList.Columns["State"].Visible = false;
            this.dataList.Columns["Account"].Visible = false;
            this.dataList.Columns["AccountId"].Visible = false;
            this.dataList.Columns["Categories"].Visible = false;
            this.dataList.Columns["CategoryId"].Visible = false; 
            this.dataList.Columns["ProductCode"].Visible = false;
            this.dataList.Columns["Id"].Visible = false;
            this.dataList.Columns["Description"].Visible = false;
            this.dataList.Columns["ModifiedDate"].Visible = false;
            this.dataList.Columns["ProviderId"].Visible = false;
        }

        private void CleanBox()
        {
            this.txtproductname.Text = string.Empty;
            this.txtPurchasePrice.Text = string.Empty;
            this.txtcode.Text = string.Empty;
            this.txtproductcode.Text = string.Empty;
            this.txtSalePrice.Text = string.Empty;
            this.txtdescription.Text = string.Empty;
            this.txtcategoryproduct.Text = string.Empty;
            this.txtproviderproduct.Text = string.Empty;
            this.txtproductname.Text = string.Empty;
            this.txtcatproductId.Text = string.Empty;
            this.txtprovproductId.Text = string.Empty;
            this.txtlot.Text = string.Empty;
            this.txtstock.Text = string.Empty;

            this.btnsave.Text = "Guardar";
        }

        private void Habilitar(bool valor)
        {
            this.txtproductname.ReadOnly = !valor;
            this.txtPurchasePrice.ReadOnly = !valor;
            this.txtcode.ReadOnly = !valor;
            this.txtproductcode.ReadOnly = !valor;
            this.txtSalePrice.ReadOnly = !valor;
            this.txtdescription.ReadOnly = !valor;
            this.txtlot.ReadOnly = !valor;
            this.txtstock.ReadOnly = !valor;
            this.btncategory.Enabled = valor;
            this.btnprovider.Enabled = valor;
            this.dtTP.Enabled = valor;
        }

        private void Botones()
        {
            if (this.Isnuevo || this.IsEditar)
            {
                this.Habilitar(true);
                this.btnnew.Enabled = false;
                this.btnsave.Enabled = true;
                this.btnedit.Enabled = false;
                this.btncancel.Enabled = true;
            }
            else
            {
                this.Habilitar(false);
                this.btnnew.Enabled = true;
                this.btnsave.Enabled = false;
                this.btnedit.Enabled = true;
                this.btncancel.Enabled = false;
            }
        }
        private void SearchByName()
        {
            if (!this.txtsearch.Text.Trim().Equals(""))
            {
                this.dataList.DataSource = RepoPathern.ProductService.GetAll(1, LoginInfo.pageactual, LoginInfo.pagesize, "Id", "asc", this.txtsearch.Text.Trim(), ref count);
                this.GetPagination();
            }
            else
                this.LoadList();

            this.HideColumn();
            lblTotal.Text = Convert.ToString(count);
        }

        private void GetPagination()
        {
            if (count > 0)
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

        private void btnnew_Click(object sender, EventArgs e)
        {
            this.Isnuevo = true;
            this.IsEditar = false;
            this.Botones();
            this.CleanBox();
            this.Habilitar(true);
            this.txtproductname.Focus();
        }

        private void btncancel_Click(object sender, EventArgs e)
        {
            this.Isnuevo = false;
            this.IsEditar = false;
            this.ActionCU(false);
            this.Botones();
            this.CleanBox();
            this.Habilitar(false);
            this.btnedit.Enabled = false;
        }

        private void btnedit_Click(object sender, EventArgs e)
        {
            if (!this.txtcode.Text.Equals(""))
            {
                this.Isnuevo = false;
                this.IsEditar = true;
                this.Botones();
                this.Habilitar(true);
                this.ActionCU(true);
            }
            else
            {
                RJMessageBox.Show("Debe de seleccionar primero el registro a Modificar", "Sistema de ventas", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.tabControl1.SelectedIndex = 0;
            }
        }

        private void btnsearch_Click(object sender, EventArgs e)
        {
            this.SearchByName();
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            try
            {
                Boolean isdelate = false;
                Boolean ischeked = false;

                foreach (DataGridViewRow row in dataList.Rows)
                {
                    if (Convert.ToBoolean(row.Cells[0].Value))
                    {
                        ischeked = true;
                    }
                }
                if (chkEliminar.Checked && ischeked)
                {
                    DialogResult Opcion;
                    Opcion = RJMessageBox.Show("Realmente Desea Eliminar los Registros", "Sistema de Ventas", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    if (Opcion == DialogResult.OK)
                    {
                        String Codigo;
                        string resp = "";

                        foreach (DataGridViewRow row in dataList.Rows)
                        {
                            if (Convert.ToBoolean(row.Cells[0].Value))
                            {
                                Codigo = ((ProductBE)row.DataBoundItem).Id;
                                resp = RepoPathern.ProductService.Delete(Codigo);

                                if (!string.IsNullOrEmpty(resp))
                                {
                                    isdelate = true;
                                }
                                else
                                {
                                    isdelate = false;
                                }
                            }
                        }
                        if (isdelate)
                        {
                            RJMessageBox.Show(resp, "Sistema de ventas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            chkEliminar.Checked = false;

                        }
                        else
                        {
                            RJMessageBox.Show("El archivo no fue eliminado", "Sistema de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            chkEliminar.Checked = false;
                        }
                        this.LoadList();
                    }
                }
                else
                    RJMessageBox.Show("Debe chequear el checkbox eliminar, si deseas eliminar uno o mas registro", "Sistema de ventas", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (ApiBusinessException ex)
            {
                RJMessageBox.Show(ex.MessageError, "Sistema de ventas", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                RJMessageBox.Show(ex.Message, "Sistema de ventas", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btncategory_Click(object sender, EventArgs e)
        {
            frmlistcategory frm = new frmlistcategory();
            frm.ShowDialog();
            this.txtcategoryproduct.Text = frm.CategoryNameProduct;
            this.txtcatproductId.Text = frm.CategoryId;
        }

        private void btnprovider_Click(object sender, EventArgs e)
        {
            frmlistprovider frm = new frmlistprovider();
            frm.ShowDialog();
            this.txtproviderproduct.Text = frm.ProviderNameProduct;
            this.txtprovproductId.Text = frm.ProviderId;
            
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            try
            {
                String resp = "";
                if (txtproductname.Text.Trim().Equals(""))
                {
                    RJMessageBox.Show("Debe ingresar  el nombre del producto", "Sistema de ventas", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtproductname.Text = String.Empty;
                    txtproductname.Focus();
                }
                else if (txtlot.Text.Trim().Equals("") && !this.IsEditar)
                {
                    RJMessageBox.Show("Debe ingresar  el lote del producto", "Sistema de ventas", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtlot.Text = String.Empty;
                }
                else if (txtproductcode.Text.Trim().Equals("") && !this.IsEditar)
                {
                    RJMessageBox.Show("Debe ingresar  el codigo del producto", "Sistema de ventas", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtproductcode.Text = String.Empty;
                    txtproductcode.Focus();
                }
                else if (txtstock.Text.Trim().Equals("") && !this.IsEditar)
                {
                    RJMessageBox.Show("Debe ingresar la cantidad del producto", "Sistema de ventas", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtstock.Text = String.Empty;
                    txtstock.Focus();
                }
                else if (dtTP.Text.Trim().Equals("") && !this.IsEditar)
                {
                    RJMessageBox.Show("Debe seleccionar  la fecha del vencimiento del producto", "Sistema de ventas", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dtTP.Value = DateTime.Now;
                }
                else if (dtTP.Value <= DateTime.Now && !this.IsEditar)
                {
                    RJMessageBox.Show("La fecha de vencimiento del producto no puede ser menor que hoy", "Sistema de ventas", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dtTP.Value = DateTime.Now;
                }
                else if (txtcatproductId.Text.Trim().Equals(""))
                {
                    RJMessageBox.Show("Debe seleccionar la categoria del producto", "Sistema de ventas", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtcatproductId.Text = String.Empty;
                    txtcatproductId.Focus();

                    txtcategoryproduct.Text = String.Empty;
                    txtcategoryproduct.Focus();
                }
                else if (txtprovproductId.Text.Trim().Equals(""))
                {
                    RJMessageBox.Show("Debe seleccionar el proveedor del producto", "Sistema de ventas", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtprovproductId.Text = String.Empty;
                    txtprovproductId.Focus();

                    txtproviderproduct.Text = String.Empty;
                    txtproviderproduct.Focus();
                }
                else if (txtPurchasePrice.Text.Trim().Equals("") && !this.IsEditar)
                {
                    RJMessageBox.Show("Debe ingresar el precio de compra del producto", "Sistema de ventas", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtPurchasePrice.Text = String.Empty;
                    txtPurchasePrice.Focus();
                }
                else if (txtSalePrice.Text.Trim().Equals("") && !this.IsEditar)
                {
                    RJMessageBox.Show("Debe ingresar el precio de venta del producto", "Sistema de ventas", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtSalePrice.Text = String.Empty;
                    txtSalePrice.Focus();
                }
                else
                {
                    LotBE Lot = new LotBE()
                    {
                        ExpiredDate = dtTP.Value,
                        LotCode = txtlot.Text,
                        CreatedDate = DateTime.Now,
                        Stock = !this.IsEditar ? Convert.ToInt32(txtstock.Text) : 0,
                        Product = new ProductBE
                        {
                            ProductName = txtproductname.Text.Trim(),
                            ProductCode = !this.IsEditar ? txtproductcode.Text.Trim() : "",
                            CategoryId = txtcatproductId.Text.Trim(),
                            Description = txtdescription.Text.Trim(),
                            ProviderId = txtprovproductId.Text.Trim(),
                            state = (Int32)StateEnum.Activeted,
                            CreatedDate = DateTime.Now,
                            AccountId = LoginInfo.IdAccount,
                            PurchasePrice = !this.IsEditar ? Convert.ToDecimal(txtPurchasePrice.Text) : 0,
                            SalePrice = !this.IsEditar ? Convert.ToDecimal(txtSalePrice.Text) : 0,
                        }
                    };

                    if (Isnuevo)
                        resp = RepoPathern.ProductService.Create(Lot);
                    else
                        resp = RepoPathern.ProductService.Update(txtcode.Text.Trim(), Lot.Product).ToString();

                    if (!string.IsNullOrEmpty(resp))
                        RJMessageBox.Show(resp, "Sistema de ventas", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.Isnuevo = false;
                    this.IsEditar = false;

                    this.Botones();
                    this.CleanBox();
                    this.LoadList();
                    this.tabControl1.SelectedIndex = 0;
                }

            }
            catch (ApiBusinessException ex)
            {
                if (ex.MessageError.Equals("Debe ingresar la fecha de vencimiento para ese lote"))
                {
                    RJMessageBox.Show(ex.MessageError, "Sistema de ventas", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dtTP.Value = DateTime.Now;
                }
                if (ex.MessageError.Equals("Esta vencido el producto para ese lote"))
                {
                    RJMessageBox.Show(ex.MessageError, "Sistema de ventas", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dtTP.Value = DateTime.Now;
                }
                
            }
            catch (Exception ex)
            {
                RJMessageBox.Show(ex.Message, "Sistema de ventas", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void chkEliminar_CheckedChanged(object sender, EventArgs e)
        {
            if (chkEliminar.Checked)
            {
                this.dataList.Columns[0].Visible = true;
            }
            else
            {
                foreach (DataGridViewRow row in dataList.Rows)
                {
                    if (Convert.ToBoolean(row.Cells[0].Value))
                    {
                        row.Cells[0].Value = false;
                    }
                }
                this.dataList.Columns[0].Visible = false;
            }
        }

        private void dataList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataList.Columns["ckdelete"].Index)
            {
                DataGridViewCheckBoxCell ChkEliminar = (DataGridViewCheckBoxCell)dataList.Rows[e.RowIndex].Cells["ckdelete"];
                ChkEliminar.Value = !Convert.ToBoolean(ChkEliminar.Value);
            }
        }

        private void dataList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var selectedRow = this.dataList.SelectedRows[0];
            var product = (ProductBE)selectedRow.DataBoundItem;
            this.txtcode.Text = product.Id;
            this.txtproductname.Text = product.ProductName;
            this.txtproductcode.Text = product.ProductCode;
            //this.txtSalePrice.Text = product.SalePrice.ToString();
            //this.txtPurchasePrice.Text = product.PurchasePrice.ToString();
            LotBE lotbe = RepoPathern.ProductService.GetLotByIdProduct(product.Id);
            this.dtTP.Value = lotbe == null ? DateTime.Now : lotbe.ExpiredDate;
            //this.txtlot.Text = product.Lots[0].LotCode;
            this.txtdescription.Text = product.Description;
            //this.txtstock.Text = product.Stock.ToString();

            var cateser = RepoPathern.CategoryService.GetById(product.CategoryId);
            var proserv = RepoPathern.ProviderService.GetById(product.ProviderId);

            this.txtcatproductId.Text = product.CategoryId.ToString();
            this.txtcategoryproduct.Text = cateser.CategoryName;
            this.txtprovproductId.Text = product.ProviderId.ToString();
            this.txtproviderproduct.Text = proserv.Name;

            this.ActionCU(true);
            this.Habilitar(false);
            this.btnedit.Enabled = true;
            this.btnsave.Enabled = false;
            this.btnnew.Enabled = false;
            this.btnsave.Text = "Modificar";
            this.tabControl1.SelectedIndex = 1;
        }

        private void ActionCU(bool isUpdate)
        {
            this.txtstock.Enabled = !isUpdate;
            this.txtSalePrice.Enabled = !isUpdate;
            this.txtlot.Enabled = !isUpdate;
            this.txtSalePrice.Enabled = !isUpdate;
            this.txtPurchasePrice.Enabled = !isUpdate;
            this.txtproductcode.Enabled = !isUpdate;
            this.dtTP.Enabled = !isUpdate;

            this.IsEditar = isUpdate;
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

        private void txxtlot(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.txtlot.Text) && !string.IsNullOrEmpty(this.txtcode.Text))
            {
                try
                {
                    RepoPathern.ProductService.SearchExpiredProductByLotCode(txtlot.Text, txtcode.Text);
                    return;
                }
                catch (ApiBusinessException ex)
                {
                    RJMessageBox.Show(ex.MessageError, "Sistema de ventas", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    RJMessageBox.Show(ex.Message, "Sistema de ventas", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
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

        private void frmProduct_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            Rectangle rectForm = this.ClientRectangle;
            int mWidht = rectForm.Width / 2;
            int mHeight = rectForm.Height / 2;
            var fbColors = GetFormBoundsColors();
            //-> SET ROUNDED REGION AND BORDER
            FormRegionAndBorder(this, borderRadius, e.Graphics, borderColor, borderSize);
        }

        private void frmProduct_ResizeEnd(object sender, EventArgs e)
        {
            this.Invalidate();
        }

        private void frmProduct_SizeChanged(object sender, EventArgs e)
        {
            this.Invalidate();
        }

        private void frmProduct_Validated(object sender, EventArgs e)
        {
            this.Invalidate();
        }

        private void label14_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void frmProduct_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }
    }
}
