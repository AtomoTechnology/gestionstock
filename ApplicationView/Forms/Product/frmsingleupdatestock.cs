using ApplicationView.BusnessEntities.BE;
using ApplicationView.Forms.MsgBox;
using ApplicationView.Forms.RedesignForm;
using ApplicationView.Patern.singleton;
using ApplicationView.Resolver.HelperError.IExceptions;
using ApplicationView.Resolver.log;
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

namespace ApplicationView.Forms.Product
{
    public partial class frmsingleupdatestock : Form
    {
        ProductBE _be;
        LotBE lotbe;
        private int borderRadius = 20;
        private int borderSize = 2;
        //private Color borderColor = Color.White;
        private Color borderColor = Color.FromArgb(128, 128, 255);
        public frmsingleupdatestock(ProductBE be)
        {
            InitializeComponent();
            _be = new ProductBE();
            _be = be;
            lotbe = new LotBE();
            lotbe = RepoPathern.ProductService.GetLotByIdProduct(be.Id);
            this.label5.Text = be.ProductName;
            this.label6.Text = lotbe != null ? lotbe.Stock.ToString(): "0";
            this.label7.Text = be.PurchasePrice.ToString();
            this.label8.Text = be.SalePrice.ToString();
            this.label9.Text = lotbe != null ? lotbe.LotCode : "00";
            this.lblsalecode.Text = be.ProductCode;

            this.FormBorderStyle = FormBorderStyle.None;
            this.Padding = new Padding(borderSize);
            this.btnclose.FlatAppearance.BorderSize = 0;
            //this.panelTitleBar.BackColor = borderColor;
            //this.BackColor = borderColor;
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtstock.Text.Trim().Equals(""))
                {
                    RJMessageBox.Show("Debe ingresar la cantidad del producto", "Sistema de ventas", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtstock.Text = String.Empty;
                    txtstock.Focus();
                    return;
                }

                if (this.chkblote.Checked == true)
                {
                    if (txtlotecode.Text.Trim().Equals(""))
                    {
                        RJMessageBox.Show("Debe ingresar el lote del producto", "Sistema de ventas", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtlotecode.Text = String.Empty;
                        txtlotecode.Focus();
                        return ;
                    }
                    else if(this.dTPlote.Value == DateTime.Now || this.dTPlote.Value < DateTime.Now)
                    {
                        RJMessageBox.Show("La fecha vencimiento no puede ser igual o menor a hoy", "Sistema de ventas", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return ;
                    }                     
                }
                var lot = new LotBE()
                {
                    ExpiredDate = this.chkblote.Checked ? this.dTPlote.Value : lotbe.ExpiredDate,
                    LotCode = this.chkblote.Checked ? this.txtlotecode.Text : lotbe.LotCode,
                    Id = this.lotbe.Id,
                    ProductId = _be.Id
                };
                var stock = new UpdateStockProductBe()
                {
                    ExpiredDate = this.dTPlote.Value,
                    NewLote = this.chkblote.Checked ? this.txtlotecode.Text : lotbe.LotCode,
                    IsNewLote = this.chkblote.Checked,
                    stock = Convert.ToInt32(this.txtstock.Text),
                    AccountId = LoginInfo.IdAccount
                };
                var resp = RepoPathern.ProductService.UpdateStock(_be.Id, stock);
                if (!string.IsNullOrEmpty(resp))
                {
                    RJMessageBox.Show(resp, "Sistema de ventas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
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

        private void btncancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void chkblote_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chkblote.Checked)
            {
                this.dTPlote.Enabled = true;
                this.txtlotecode.Enabled = true;
            }
            else
            {
                this.dTPlote.Enabled = false;
                this.txtlotecode.Enabled = false;
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

        private void frmsingleupdatestock_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            Rectangle rectForm = this.ClientRectangle;
            int mWidht = rectForm.Width / 2;
            int mHeight = rectForm.Height / 2;
            var fbColors = GetFormBoundsColors();
            //-> SET ROUNDED REGION AND BORDER
            FormRegionAndBorder(this, borderRadius, e.Graphics, borderColor, borderSize);
        }

        private void frmsingleupdatestock_ResizeEnd(object sender, EventArgs e)
        {
            this.Invalidate();
        }

        private void frmsingleupdatestock_SizeChanged(object sender, EventArgs e)
        {
            this.Invalidate();
        }

        private void frmsingleupdatestock_Validated(object sender, EventArgs e)
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

        private void frmsingleupdatestock_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
    }
}
