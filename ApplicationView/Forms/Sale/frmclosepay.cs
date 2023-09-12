using ApplicationView.BusnessEntities.BE;
using ApplicationView.BusnessEntities.Dtos;
using ApplicationView.Forms.MsgBox;
using ApplicationView.Forms.RedesignForm;
using ApplicationView.Patern.singleton;
using ApplicationView.print;
using ApplicationView.Resolver.Enums;
using ApplicationView.Resolver.HelperError.IExceptions;
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

namespace ApplicationView.Forms.Sale
{
    public partial class frmclosepay : Form
    {
        private readonly String _SaleId;
        private Boolean IsLotPayment = false;
        private int _productquantity;
        private int borderRadius = 20;
        private int borderSize = 2;
        //private Color borderColor = Color.White;
        private Color borderColor = Color.FromArgb(128, 128, 255);

        public Boolean iscorrectSale = false;
        public frmclosepay(string total, String SaleId, int productquantity)
        {
            InitializeComponent();
            this.label7.Text = total; 
            _SaleId = SaleId;
            _productquantity = productquantity;

            this.label3.Text = "0";
            this.cbtypePay.SelectedIndex = -1;
            this.cbtypePay.Text = "Seleccione metodo de pago";

            this.FormBorderStyle = FormBorderStyle.None;
            this.Padding = new Padding(borderSize);
            this.btnclose.FlatAppearance.BorderSize = 0;
            //this.panelTitleBar.BackColor = borderColor;
            //this.BackColor = borderColor;
        }

        private void LoadList()
        {
            this.cbtypePay.DisplayMember = "PaymentName";
            this.cbtypePay.ValueMember = "Id";
            this.cbtypePay.DataSource = RepoPathern.SaleService.GetAllPaymentType(1);      
        }

        private void frmclosepay_Load(object sender, EventArgs e)
        {
            this.LoadList();

            this.cbtypePay.SelectedIndex = -1;
            this.cbtypePay.Text = "Seleccione metodo de pago";
        }

        private void txtrol_TextChanged(object sender, EventArgs e)
        {
            if (!this.txtreceive.Text.Equals("") && cbtypePay.Text.ToLower().Equals("Efectivo".ToLower()))
            {
                if (Convert.ToDecimal(this.label7.Text) <= Convert.ToDecimal(this.txtreceive.Text))
                    label3.Text = "-" + " " + (Convert.ToDecimal(this.txtreceive.Text) - Convert.ToDecimal(this.label7.Text)).ToString();
            }
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbtypePay.Text.ToLower().Equals("Efectivo".ToLower()))
                {
                    if (this.txtreceive.Text.Equals(""))
                    {
                        RJMessageBox.Show("Ingreso el total recibido", "Sistema de ventas", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                if (cbtypePay.SelectedItem == null || cbtypePay.SelectedItem.Equals("Seleccione metodo de pago"))
                {
                    RJMessageBox.Show("Debe seleccionar el metodo de pago", "Sistema de ventas", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (this.txtreceive.Text.Equals("") && this.IsLotPayment)
                {
                    RJMessageBox.Show("Ingreso nro de lote de pago", "Sistema de ventas", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.txtreceive.Focus();
                    return;
                }
                var be = new SaleBE()
                {
                    AccountId = LoginInfo.IdAccount,
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    PaymentTypeId = cbtypePay.SelectedValue.ToString(),
                    finalizeSale = true,
                    CodeLotePayment = this.IsLotPayment != false ? this.txtreceive.Text : "",
                    Total = Convert.ToDecimal(this.label7.Text),
                    state = (Int32)SaleEnum.PayFinished
                };

                RepoPathern.SaleService.Update(_SaleId, be);
                PrintFinishSale.Finish(Convert.ToDecimal(this.label7.Text), cbtypePay.Text, _productquantity);
                this.iscorrectSale = true;
                this.Close();
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
        frmlegit frm = null;
        private void cbtypePay_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbtypePay.Text.ToLower().Equals("Efectivo".ToLower()))
            {
                this.txtreceive.Visible = true;
                this.label2.Visible = true;
                this.IsLotPayment = false;
                this.txtreceive.Text = "";
                this.label2.Text = "Recibido";
            }
            if (cbtypePay.Text.ToLower().Equals("Fiar".ToLower()))
            {

                this.txtreceive.Visible = false;
                label2.Visible = false;
                this.IsLotPayment = false;
                this.txtreceive.Text = "";
                this.label3.Text = "0";

                var sl = new SaleWithLogitDto()
                {
                    Sale = new SaleBE()
                    {
                        Id = _SaleId,
                        AccountId = LoginInfo.IdAccount,
                        CreatedDate = DateTime.Now,
                        ModifiedDate = DateTime.Now,
                        PaymentTypeId = cbtypePay.SelectedValue.ToString(),
                        finalizeSale = true,
                        CodeLotePayment = this.IsLotPayment != false ? this.txtreceive.Text : "",
                        Total = Convert.ToDecimal(this.label7.Text),
                        state = (Int32)SaleEnum.PayActived
                    },
                    Legit = new LegitBE()
                    {
                        SaleId = _SaleId,
                        AccountId = LoginInfo.IdAccount,
                        state = (Int32)SaleEnum.PayActived
                    }
                };
                frm = new frmlegit(sl);

                frm.ShowDialog();
                if (frm.iscomplete)
                {
                    this.iscorrectSale = true;
                    this.Close();
                }

            }
            else if(!cbtypePay.Text.ToLower().Equals("Efectivo".ToLower()) && !cbtypePay.Text.ToLower().Equals("Especie".ToLower()) && !cbtypePay.Text.ToLower().Equals("".ToLower()) && !cbtypePay.Text.ToLower().Equals("Seleccione metodo de pago".ToLower()))
            {
                this.txtreceive.Visible = true;
                label2.Visible = true;
                this.IsLotPayment = true;
                this.txtreceive.Text = "";
                this.label2.Text = "Nro lote de pago";
            }
            else
            {
                if (cbtypePay.Text.ToLower().Equals("Efectivo".ToLower()))
                {
                    this.txtreceive.Visible = true;
                    this.label2.Visible = true;
                    this.label2.Text = "Recibido";
                }
                else
                {
                    this.txtreceive.Visible = false;
                    label2.Visible = false;
                }
                this.IsLotPayment = false;
                this.txtreceive.Text = "";
                this.label3.Text = "0";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbtypePay_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
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

        private void frmclosepay_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            Rectangle rectForm = this.ClientRectangle;
            int mWidht = rectForm.Width / 2;
            int mHeight = rectForm.Height / 2;
            var fbColors = GetFormBoundsColors();
            //-> SET ROUNDED REGION AND BORDER
            FormRegionAndBorder(this, borderRadius, e.Graphics, borderColor, borderSize);
        }

        private void frmclosepay_ResizeEnd(object sender, EventArgs e)
        {
            this.Invalidate();
        }

        private void frmclosepay_SizeChanged(object sender, EventArgs e)
        {
            this.Invalidate();
        }

        private void frmclosepay_Validated(object sender, EventArgs e)
        {
            this.Invalidate();
        }

        private void frmclosepay_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void lblinfo_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
    }
}
