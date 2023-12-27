using ApplicationView.Forms.Account;
using ApplicationView.Forms.MsgBox;
using ApplicationView.Forms.RedesignForm;
using ApplicationView.Forms.turnswork;
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
    public partial class frmdetailxturn : Form
    {
        private int borderRadius = 20;
        private int borderSize = 2;
        //private Color borderColor = Color.White;
        private Color borderColor = Color.FromArgb(128, 128, 255);
        public frmdetailxturn()
        {
            InitializeComponent();

            this.FormBorderStyle = FormBorderStyle.None;
            this.Padding = new Padding(borderSize);
            this.btnclose.FlatAppearance.BorderSize = 0;
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

        private void frmdetailxturn_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            Rectangle rectForm = this.ClientRectangle;
            int mWidht = rectForm.Width / 2;
            int mHeight = rectForm.Height / 2;
            var fbColors = GetFormBoundsColors();
            //Top Left
            Redesign.GetInstancia().DrawPath(rectForm, e.Graphics, fbColors.TopLeftColor);
            //Top Right
            Rectangle rectTopRight = new Rectangle(mWidht, rectForm.Y, mWidht, mHeight);
            Redesign.GetInstancia().DrawPath(rectTopRight, e.Graphics, fbColors.TopRightColor);
            //Bottom Left
            Rectangle rectBottomLeft = new Rectangle(rectForm.X, rectForm.X + mHeight, mWidht, mHeight);
            Redesign.GetInstancia().DrawPath(rectBottomLeft, e.Graphics, fbColors.BottomLeftColor);
            //Bottom Right
            Rectangle rectBottomRight = new Rectangle(mWidht, rectForm.Y + mHeight, mWidht, mHeight);
            Redesign.GetInstancia().DrawPath(rectBottomRight, e.Graphics, fbColors.BottomRightColor);
            //-> SET ROUNDED REGION AND BORDER
            FormRegionAndBorder(this, borderRadius, e.Graphics, borderColor, borderSize);
        }

        private void frmdetailxturn_ResizeEnd(object sender, EventArgs e)
        {
            this.Invalidate();
        }

        private void frmdetailxturn_SizeChanged(object sender, EventArgs e)
        {
            this.Invalidate();
        }

        private void frmdetailxturn_Validated(object sender, EventArgs e)
        {
            this.Invalidate();
        }

        private void frmdetailxturn_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmdetailturnlist frm = new frmdetailturnlist(this.txtaccountIdselect.Text, this.lbluseraccount.Text);
            frm.ShowDialog();
            if (frm.IsSelect)
            {
                this.txtturn.Text = frm.OpenWorkTurnid;
                this.lblturnaccount.Text = frm.turnName;
                this.lbldate.Text = frm.creationDate;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmlistuser frm = new frmlistuser(LoginInfo.IdBusiness);
            frm.ShowDialog();
            if (frm.IsSelect)
            {
                this.lbluseraccount.Text = frm.fullName;
                this.txtaccountIdselect.Text = frm.AccountId;
                this.button2.Enabled = true;
            }
        }

        private void btnsearch_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.txtaccountIdselect.Text))
            {
                RJMessageBox.Show("Debe seleccionar el usuario para el turno a consultar", "Sistema de ventas", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (string.IsNullOrEmpty(this.txtturn.Text))
            {
                RJMessageBox.Show("Debe seleccionar el turno a consultar", "Sistema de ventas", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                var result = RepoPathern.SaleService.GetAccountredemption(this.txtaccountIdselect.Text, this.txtturn.Text);
                if (result != null)
                {
                    this.lblstartturn.Text = result.Started.ToString();
                    this.lblcash.Text = result.Cash.ToString();
                    this.lblelectronic.Text = result.ElectronicPay.ToString();
                    this.lblcashCashier.Text = (Convert.ToDecimal(this.lblstartturn.Text) + result.Cash).ToString();
                    this.lbltotal.Text = (Convert.ToDecimal(this.lblstartturn.Text) + result.Cash + result.ElectronicPay).ToString();
                    //this.btnnew.Enabled = true;
                }
                else
                {
                    this.lblstartturn.Text = "0";
                    this.lblcash.Text = "0";
                    this.lbltotal.Text = "0";
                    this.lblelectronic.Text = "0";
                    this.lblcashCashier.Text = "0";
                    //this.btnnew.Enabled = false;
                }
            }
          
        }
    }
}
