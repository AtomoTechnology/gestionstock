using ApplicationView.BusnessEntities.BE;
using ApplicationView.Forms.MsgBox;
using ApplicationView.Forms.RedesignForm;
using ApplicationView.Patern.singleton;
using ApplicationView.Resolver.Helper;
using ApplicationView.Resolver.HelperError.IExceptions;
using ApplicationView.Share;
using ApplicationView.VariableSeesion;
//using IronBarCode;
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

namespace ApplicationView.Forms.Product
{
    public partial class frmoffer : Form
    {
        private bool Isnuevo = false;
        private bool IsEditar = false;
        int count = 0;
        private int borderRadius = 20;
        private int borderSize = 2;
        //private Color borderColor = Color.White;
        private Color borderColor = Color.FromArgb(128, 128, 255);
        public frmoffer()
        {
            InitializeComponent();
            DataListHelper.SetGrid(this.dataList, 14, 12);
            DataListHelper.SetGrid(this.dGridproductselect, 14, 12);
            LoginInfo.pageactual = 1;

            this.FormBorderStyle = FormBorderStyle.None;
            this.Padding = new Padding(borderSize);
            this.btnclose.FlatAppearance.BorderSize = 0;
            //this.panelTitleBar.BackColor = borderColor;
            //this.BackColor = borderColor;
        }
        private void LoadList()
        {
            this.dataList.DataSource = RepoPathern.PromotionService.GetAll(1, LoginInfo.pageactual, LoginInfo.pagesize, "Id", "asc", "", ref count);
            this.HideColumn();
            this.GetPagination(Convert.ToInt32(dataList.Rows.Count));
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
        private void HideColumn()
        {
            this.dataList.Columns["ckdelete"].Visible = false;
            this.dataList.Columns["FinalDate"].Visible = false;
            this.dataList.Columns["CreatedDate"].Visible = false;
            this.dataList.Columns["State"].Visible = false;
            this.dataList.Columns["FinalDate"].Visible = false;
            this.dataList.Columns["ModifiedDate"].Visible = false;
            this.dataList.Columns["Description"].Visible = false;
            this.dataList.Columns["Id"].Visible = false;
            this.dataList.Columns["untilstockexhausted"].Visible = false;
            this.dataList.Columns["FinalPromotion"].Visible = false;
            this.dataList.Columns["PromoCode"].Visible = false;
        }

        private void frmoffer_Load(object sender, EventArgs e)
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

        private void Habilitar(bool valor)
        {
            this.txtpromotionname.ReadOnly = !valor;
            this.txtproduct.ReadOnly = !valor;
            this.txtcode.ReadOnly = !valor;
            this.txtSalePrice.ReadOnly = !valor;
            this.txtdescription.ReadOnly = !valor;
            this.dtTP.Enabled = valor;
            this.chckBxuntilstockexhausted.Enabled = valor;

            this.btnproduct.Enabled = valor;

            this.btnsave.Text = "Guardar";
        }
        private void CleanBox()
        {
            this.txtcode.Text = string.Empty;
            this.txtpromotionname.Text = string.Empty;
            this.txtproduct.Text = string.Empty;
            this.txtSalePrice.Text = string.Empty;
            this.txtdescription.Text = string.Empty;
            this.dtTP.Value = DateTime.Now;
            this.dGridproductselect.DataSource = null;
            this.data = null;
            this.be = null;

            this.btnsave.Text = "Guardar";
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

        private void btnnew_Click(object sender, EventArgs e)
        {
            this.Isnuevo = true;
            this.IsEditar = false;
            this.Botones();
            this.CleanBox();
            this.Habilitar(true);
            this.txtpromotionname.Focus();
        }

        private void btncancel_Click(object sender, EventArgs e)
        {
            this.Isnuevo = false;
            this.IsEditar = false;
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
            }
            else
            {
                RJMessageBox.Show("Debe de seleccionar primero el registro a Modificar", "Sistema de ventas", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.tabControl1.SelectedIndex = 0;
            }
        }

        PromotionBE be;
        List<Data> data;
        private void btnproduct_Click(object sender, EventArgs e)
        {
            frmlistproduct frm = new frmlistproduct();
            frm.ShowDialog();
            if (frm.isselectrole)
            {
                if (be == null)
                {
                    be = new PromotionBE();
                    be.PromotionDetails = new List<PromotionDetailBE>();
                    data = new List<Data>(); 

                }
                if (be.PromotionDetails.Count == 0)
                {
                    be.PromotionDetails.Add(new PromotionDetailBE()
                    {
                        ProductId = frm.be.Id,
                        quantity = 1
                    });

                    data.Add(new Data()
                    {
                        promocode = "",
                        Codigo = frm.be.Id,
                        Nombre = frm.be.ProductName
                    });
                }
                else
                {
                    var isExist = be.PromotionDetails.Where( u => u.ProductId == frm.be.Id);
                    if (isExist.Any())
                    {
                        RJMessageBox.Show("Este producto ya fue seleccionado", "Sistema de ventas", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        be.PromotionDetails.Add(new PromotionDetailBE()
                        {
                            ProductId = frm.be.Id,
                            quantity = 1
                        });

                        data.Add(new Data()
                        {
                            promocode = "",
                            Codigo = frm.be.Id,
                            Nombre = frm.be.ProductName
                        });
                    }
                }               

                BindingSource source = new BindingSource();
                source.DataSource = data;
                dGridproductselect.DataSource = source;

            }
            else
            {
                RJMessageBox.Show("Debe seleccionar un rol para el usuario", "Sistema de ventas", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            try
            {
                String resp = "";
                if (txtpromotionname.Text.Trim().Equals(""))
                {
                    RJMessageBox.Show("Debe ingresar  el nombre de la promocion", "Sistema de ventas", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtpromotionname.Text = String.Empty;
                    txtpromotionname.Focus();
                }
                else if (dtTP.Text.Trim().Equals("") && !this.IsEditar && !chckBxuntilstockexhausted.Checked)
                {
                    RJMessageBox.Show("Debe seleccionar la fecha de finalizacion de la promocion", "Sistema de ventas", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dtTP.Value = DateTime.Now;
                }
                else if (!data.Any())
                {
                    RJMessageBox.Show("Debe seleccionar los productos para la promocion", "Sistema de ventas", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (txtSalePrice.Text.Trim().Equals("") && !this.IsEditar)
                {
                    RJMessageBox.Show("Debe ingresar el precio de la promocion", "Sistema de ventas", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtSalePrice.Text = String.Empty;
                    txtSalePrice.Focus();
                }
                else if (txtstockpromo.Text.Trim().Equals("") && !this.IsEditar)
                {
                    RJMessageBox.Show("Debe ingresar el stock para la promocion", "Sistema de ventas", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtstockpromo.Text = String.Empty;
                    txtstockpromo.Focus();
                }
                else if (dtTP.Value <= DateTime.Now && !this.IsEditar)
                {
                    RJMessageBox.Show("La fecha de vencimiento del producto no puede ser menor que hoy", "Sistema de ventas", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dtTP.Value = DateTime.Now;
                }               
                else
                {
                    be.FinalPromotion = this.chckBxuntilstockexhausted.Checked ? dtTP.Value : null;
                    be.Description = this.txtdescription.Text;
                    be.stock = Convert.ToInt32(this.txtstockpromo.Text);
                    be.untilstockexhausted = this.chckBxuntilstockexhausted.Checked;
                    be.PromoName = this.txtpromotionname.Text;
                    be.Price = Convert.ToDecimal(txtSalePrice.Text);

                    if (Isnuevo)
                    {
                        resp = RepoPathern.PromotionService.Create(be);
                        var split = resp.Split('_');
                        //frmcodebara frm = new frmcodebara(split[1], BarcodeWriterEncoding.Code128);
                        //frm.ShowDialog();
                        RJMessageBox.Show(split[0], "Sistema de ventas", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    else
                        resp = RepoPathern.PromotionService.Update(txtcode.Text.Trim(), be).ToString();

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
                RJMessageBox.Show(ex.MessageError, "Sistema de ventas", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                RJMessageBox.Show(ex.Message, "Sistema de ventas", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void chckBxuntilstockexhausted_CheckedChanged(object sender, EventArgs e)
        {
            this.dtTP.Enabled = !this.chckBxuntilstockexhausted.Checked;
        }

        private void dataList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            be = new PromotionBE();
            be.PromotionDetails = new List<PromotionDetailBE>();
            var selectedRow = this.dataList.SelectedRows[0];
            be = (PromotionBE)selectedRow.DataBoundItem;
            this.txtcode.Text = be.Id;
            this.txtpromotionname.Text = be.PromoName;
            this.dtTP.Value = (DateTime)(be.FinalPromotion == null ? DateTime.Now : be.FinalPromotion);
            this.txtSalePrice.Text = be.Price.ToString();
            this.txtstockpromo.Text = be.stock.ToString();
            this.chckBxuntilstockexhausted.Checked = be.untilstockexhausted;

            if (be.untilstockexhausted)
                this.dtTP.Enabled = false;
            else
                this.dtTP.Enabled = true;

            this.txtdescription.Text = be.Description;

            be.PromotionDetails = RepoPathern.PromotionService.GetDetailPromoById(be.Id);

            if (be.PromotionDetails.Any())
            {
                data = new List<Data>();

                foreach (var item in be.PromotionDetails)
                {
                    var pro = RepoPathern.ProductService.GetById(item.ProductId);
                    data.Add(new Data()
                    {
                        promocode = item.Id,
                        Codigo = item.ProductId,
                        Nombre = pro.ProductName
                    });
                }
            }

            BindingSource source = new BindingSource();
            source.DataSource = data;
            dGridproductselect.DataSource = source;

            //this.ActionCU(true);
            this.Habilitar(false);
            this.btnedit.Enabled = true;
            this.btnsave.Enabled = false;
            this.btnnew.Enabled = false;
            this.btnsave.Text = "Modificar";
            this.tabControl1.SelectedIndex = 1;
        }

        private void dGridproductselect_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                var selectedRow = this.dGridproductselect.SelectedRows[0];
                var pro = (Data)selectedRow.DataBoundItem;

                var result = RJMessageBox.Show("Esta seguro desea eliminar este producto de la promocion?", "Sistema de ventas",
                         MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    data = data.Where(x => x.Codigo != pro.Codigo).ToList();
                    be.PromotionDetails = be.PromotionDetails.Where(u => u.ProductId == pro.Codigo).ToList();

                    BindingSource source = new BindingSource();
                    source.DataSource = data;
                    dGridproductselect.DataSource = source;
                }
                else
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

        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void frmoffer_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            Rectangle rectForm = this.ClientRectangle;
            int mWidht = rectForm.Width / 2;
            int mHeight = rectForm.Height / 2;
            var fbColors = GetFormBoundsColors();
            //-> SET ROUNDED REGION AND BORDER
            FormRegionAndBorder(this, borderRadius, e.Graphics, borderColor, borderSize);
        }

        private void frmoffer_ResizeEnd(object sender, EventArgs e)
        {
            this.Invalidate();
        }

        private void frmoffer_SizeChanged(object sender, EventArgs e)
        {
            this.Invalidate();
        }

        private void frmoffer_Validated(object sender, EventArgs e)
        {
            this.Invalidate();
        }

        private void frmoffer_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
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
    }

    public class Data
    {
        public string promocode { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
    }
}
