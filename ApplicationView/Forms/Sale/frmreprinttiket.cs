using ApplicationView.BusnessEntities.Dtos;
using ApplicationView.Forms.Loading;
using ApplicationView.Forms.MsgBox;
using ApplicationView.Forms.RedesignForm;
using ApplicationView.Patern.singleton;
using ApplicationView.print;
using ApplicationView.Resolver.Helper;
using ApplicationView.Resolver.HelperError.IExceptions;
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
    public partial class frmreprinttiket : Form
    {

        private int borderRadius = 20;
        private int borderSize = 2;

        SplashForm loading;
        private Color borderColor = Color.FromArgb(128, 128, 255);
        public frmreprinttiket()
        {
            InitializeComponent();
            DataListHelper.SetGrid(this.dataList, 18);

            this.FormBorderStyle = FormBorderStyle.None;
            this.Padding = new Padding(borderSize);
            this.btnclose.FlatAppearance.BorderSize = 0;
            //this.panelTitleBar.BackColor = borderColor;
            //this.BackColor = borderColor;
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

        private void frmreprinttiket_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            Rectangle rectForm = this.ClientRectangle;
            int mWidht = rectForm.Width / 2;
            int mHeight = rectForm.Height / 2;
            var fbColors = GetFormBoundsColors();
            //-> SET ROUNDED REGION AND BORDER
            FormRegionAndBorder(this, borderRadius, e.Graphics, borderColor, borderSize);
        }

        private void frmreprinttiket_ResizeEnd(object sender, EventArgs e)
        {
            this.Invalidate();
        }

        private void frmreprinttiket_SizeChanged(object sender, EventArgs e)
        {
            this.Invalidate();
        }

        private void frmreprinttiket_Validated(object sender, EventArgs e)
        {
            this.Invalidate();
        }

        private void lblinfo_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void frmreprinttiket_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnprint_Click(object sender, EventArgs e)
        {
            if (dataList.Rows.Count > 0)
            {
                this.ShowLoading();
                this.btnprint.Enabled = false;
                var busniss = RepoPathern.BusnessService.GetById(LoginInfo.IdBusiness);
                PrintHead.Head(busniss.BusinessName, busniss.Address, busniss.Cuit_Cuil, busniss.Grossrevenue, busniss.CreatedDate.Date.ToShortDateString(), LoginInfo.UserName, txtnrofact.Text);
                decimal total = 0;
                string mode = "";
                int productquantity = 0;
                foreach (DataGridViewRow row in dataList.Rows)
                {
                    var dto = (SaleDetailDto)row.DataBoundItem;
                    total += dto.Subtotal;
                    productquantity += dto.quantity;
                    mode = dto.PaymentName;

                    PrintSaleBody.Body(dto.ProductName, dto.SalePrice);
                }
                PrintFinishSale.Finish(total, mode, productquantity);
                this.CloseLoading();
            }
        }

        private void btnsearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtnrofact.Text))
                {
                    RJMessageBox.Show("Debe ingresa el numero de tiket", "Sistema de ventas", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    this.LoadList();
                }
            }
            catch (ApiBusinessException ex)
            {
                txtnrofact.Text = String.Empty;
                RJMessageBox.Show(ex.MessageError, "Sistema de ventas", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                txtnrofact.Text = String.Empty;
                RJMessageBox.Show(ex.Message, "Sistema de ventas", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LoadList()
        {
            this.dataList.DataSource = RepoPathern.SaleService.GetReprintTicket(txtnrofact.Text);
            if (dataList.Rows.Count > 0)
            {
                this.btnprint.Enabled = true;
            }
            this.HideColumn();
        }

        private void HideColumn()
        {
            if (this.dataList.RowCount > 0)
            {
                this.dataList.Columns["Id"].Visible = false;
                this.dataList.Columns["productId"].Visible = false;
                this.dataList.Columns["SaleId"].Visible = false;
                this.dataList.Columns["InvoiceCode"].Visible = false;
                this.dataList.Columns["ProductCode"].Visible = false;
                this.dataList.Columns["PaymentName"].Visible = false;
            }
        }


        private void ShowLoading()
        {
            loading = new SplashForm();
            loading.Show();
        }

        private void CloseLoading()
        {
            if (this.loading != null)
                this.loading.Close();
        }
    }
}
