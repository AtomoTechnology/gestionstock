using ApplicationView.BusnessEntities.BE;
using ApplicationView.Forms.MsgBox;
using ApplicationView.Forms.RedesignForm;
using ApplicationView.Patern.singleton;
using ApplicationView.Resolver.Enums;
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
    public partial class frmupdatesingleproduct : Form
    {
        ProductBE _be;
        public Boolean IsUpdateprice = false;
        public string msg = string.Empty;
        private int borderRadius = 20;
        private int borderSize = 2;
        //private Color borderColor = Color.White;
        private Color borderColor = Color.FromArgb(128, 128, 255);
        public frmupdatesingleproduct(ProductBE be)
        {
            InitializeComponent();
            _be = be;

            this.label3.Text = be.ProductName;
            this.lblTotal.Text = be.SalePrice.ToString();
            this.txtpurchaseprice.Text = be.PurchasePrice.ToString();

            this.FormBorderStyle = FormBorderStyle.None;
            this.Padding = new Padding(borderSize);
            this.btnclose.FlatAppearance.BorderSize = 0;
            //this.panelTitleBar.BackColor = borderColor;
            //this.BackColor = borderColor;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.txtsaleprice.Text))
            {
                RJMessageBox.Show("Debe ingresar el porcentaje de aumento de precio de venta para ese producto", "Sistema de ventas", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtsaleprice.Text = String.Empty;
                txtsaleprice.Focus();
            }
            else if (string.IsNullOrEmpty(this.txtpurchaseprice.Text) && this.chkpurchase.Checked)
            {
                RJMessageBox.Show("Debe ingresar el porcentaje de aumento de precio de compra para ese producto", "Sistema de ventas", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtpurchaseprice.Text = String.Empty;
                txtpurchaseprice.Focus();
            }
            else
            {
                decimal purchase = !string.IsNullOrEmpty(txtpurchaseprice.Text) ? Convert.ToDecimal(txtpurchaseprice.Text) : 0;
                this.msg = RepoPathern.ProductService.UpdatePrices(_be.Id, LoginInfo.IdAccount, Convert.ToDecimal(this.txtsaleprice.Text), purchase, UpdatePriceEnum.ForProduct, this.chkpurchase.Checked);                
                this.IsUpdateprice = true;
                this.Close();
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (chkpurchase.Checked)
            {
                this.txtpurchaseprice.Enabled = true;
                this.txtpurchaseprice.BackColor = SystemColors.Window;
                this.txtpurchaseprice.Text = string.Empty;
                this.label6.Text = "Precio de compra";
            }
            else
            {
                this.txtpurchaseprice.Enabled = false;
                this.txtpurchaseprice.BackColor = SystemColors.MenuBar;
                this.txtpurchaseprice.Text = _be.PurchasePrice.ToString();
                this.label6.Text = "Precio de  compra actual";
            }
        }

        private void lblTotal_Click(object sender, EventArgs e)
        {

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

        private void frmupdatesingleproduct_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            Rectangle rectForm = this.ClientRectangle;
            int mWidht = rectForm.Width / 2;
            int mHeight = rectForm.Height / 2;
            var fbColors = GetFormBoundsColors();
            //-> SET ROUNDED REGION AND BORDER
            FormRegionAndBorder(this, borderRadius, e.Graphics, borderColor, borderSize);
        }

        private void frmupdatesingleproduct_MouseDown(object sender, MouseEventArgs e)
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

        private void frmupdatesingleproduct_ResizeEnd(object sender, EventArgs e)
        {
            this.Invalidate();
        }

        private void frmupdatesingleproduct_SizeChanged(object sender, EventArgs e)
        {
            this.Invalidate();
        }

        private void frmupdatesingleproduct_Validated(object sender, EventArgs e)
        {
            this.Invalidate();
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
