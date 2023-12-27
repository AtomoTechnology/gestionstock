using ApplicationView.Forms.MsgBox;
using ApplicationView.Forms.RedesignForm;
using ApplicationView.Patern.singleton;
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

namespace ApplicationView.Forms.Sale
{
    public partial class frmclosecachier : Form
    {
        private int borderRadius = 20;
        private int borderSize = 2;
        public bool isClosed;
        private Color borderColor = Color.FromArgb(128, 128, 255);
        public frmclosecachier()
        {
            InitializeComponent();

            this.FormBorderStyle = FormBorderStyle.None;
            this.Padding = new Padding(borderSize);
            this.btnclose.FlatAppearance.BorderSize = 0;

            this.GetOpenCashier();
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

        private void frmclosecachier_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            Rectangle rectForm = this.ClientRectangle;
            int mWidht = rectForm.Width / 2;
            int mHeight = rectForm.Height / 2;
            var fbColors = GetFormBoundsColors();
            //-> SET ROUNDED REGION AND BORDER
            FormRegionAndBorder(this, borderRadius, e.Graphics, borderColor, borderSize);
        }

        private void frmclosecachier_ResizeEnd(object sender, EventArgs e)
        {
            this.Invalidate();
        }

        private void frmclosecachier_SizeChanged(object sender, EventArgs e)
        {
            this.Invalidate();
        }

        private void frmclosecachier_Validated(object sender, EventArgs e)
        {
            this.Invalidate();
        }

        private void frmclosecachier_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void label8_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void GetOpenCashier()
        {
            var result = RepoPathern.SaleService.GetCashier(LoginInfo.IdAccount);
            if (result != null)
            {
                this.lblstartturn.Text = result.Started.ToString();
                this.lblcash.Text = result.Cash.ToString();
                this.lblelectronic.Text = result.ElectronicPay.ToString();
                this.lblcashCashier.Text = (Convert.ToDecimal(this.lblstartturn.Text) + result.Cash).ToString();
                this.lbltotal.Text = (Convert.ToDecimal(this.lblstartturn.Text) + result.Cash + result.ElectronicPay).ToString();
                this.btnnew.Enabled = true;
            }
            else
            {
                this.lblstartturn.Text = "0";
                this.lblcash.Text = "0";
                this.lbltotal.Text = "0";
                this.lblelectronic.Text = "0";
                this.lblcashCashier.Text = "0";
                this.btnnew.Enabled = false;
            }

        }

        private void btncancel_Click(object sender, EventArgs e)
        {
            this.isClosed = true;
            this.Close();
        }

        private void btnnew_Click(object sender, EventArgs e)
        {
            var result = RepoPathern.OpenWorkRepoService.CloseWorkUser(LoginInfo.IdAccount);
            if (result)
            {
                RJMessageBox.Show("El cierre de caja fue con existo", "Sistema de ventas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoginInfo.IscashierOpen = true;
                this.Close();
            }
            else
            {
                RJMessageBox.Show("No se pudo realizar el cierre de caja", "Sistema de ventas", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LoginInfo.IscashierOpen = false;
                this.Close();
            }
        }
    }
}
