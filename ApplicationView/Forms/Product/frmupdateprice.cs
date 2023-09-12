using ApplicationView.BusnessEntities.BE;
using ApplicationView.Forms.MsgBox;
using ApplicationView.Forms.RedesignForm;
using ApplicationView.Patern.singleton;
using ApplicationView.Resolver.Enums;
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
    public partial class frmupdateprice : Form
    {
        int count = 0;
        private int borderRadius = 20;
        private int borderSize = 2;
        //private Color borderColor = Color.White;
        private Color borderColor = Color.FromArgb(128, 128, 255);
        public frmupdateprice()
        {
            InitializeComponent();
            LoginInfo.pageactual = 1;

            this.FormBorderStyle = FormBorderStyle.None;
            this.Padding = new Padding(borderSize);
            this.btnclose.FlatAppearance.BorderSize = 0;
            //this.panelTitleBar.BackColor = borderColor;
            //this.BackColor = borderColor;
        }

        private void cboptionupdate_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void cboptionupdate_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboptionupdate.Text.ToLower().Equals("Seleccionar opcion de actualizacion".ToLower()))
            {
                this.groupBox2.Visible = false;
                this.groupBox3.Visible = false;
                this.Height = 135;
            }
            else if (cboptionupdate.Text.ToLower().Equals("Todos".ToLower()))
            {
                this.groupBox2.Visible = false;
                this.groupBox3.Visible = true;
                this.Height = 290;
            }
            else
            {
                this.groupBox2.Visible = true;
                this.groupBox3.Visible = false;
                this.groupBox2.Top = 150;
                this.Height = 822;
                this.txtperchaseprice.Enabled = false;
                this.chkpurchase.Checked = false;
                this.txtperchaseprice.BackColor = SystemColors.MenuBar;
                this.LoadList();
            }
        }

        private void frmupdateprice_Load(object sender, EventArgs e)
        {
            if (cboptionupdate.Text.ToLower().Equals("Seleccionar opcion de actualizacion".ToLower()))
            {
                this.groupBox2.Visible = false;
                this.groupBox3.Visible = false;
                this.Height = 135;
            }
        }

        private void LoadList()
        {
            this.dataList.DataSource = RepoPathern.ProductService.GetAll(1, LoginInfo.pageactual, LoginInfo.pagesize, "Id", "asc", "", ref count);
            this.HideColumn();
            this.GetPagination();
        }

        private void HideColumn()
        {
            //this.dataList.Columns["Stock"].Visible = false;
            this.dataList.Columns["FinalDate"].Visible = false;
            this.dataList.Columns["CreatedDate"].Visible = false;
            this.dataList.Columns["State"].Visible = false;
            this.dataList.Columns["Account"].Visible = false;
            this.dataList.Columns["AccountId"].Visible = false;
            this.dataList.Columns["Categories"].Visible = false;
            this.dataList.Columns["CategoryId"].Visible = false;
            this.dataList.Columns["ProductCode"].Visible = false; 
            this.dataList.Columns["Description"].Visible = false;
            this.dataList.Columns["ModifiedDate"].Visible = false;
            this.dataList.Columns["ProviderId"].Visible = false;
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

        private void dataList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Application.EnableVisualStyles();
            var result = RJMessageBox.Show("Esta seguro que desees actualizar el precio de ese producto?", "Sistema de ventas",
            MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                var selectedRow = this.dataList.SelectedRows[0];
                var product = (ProductBE)selectedRow.DataBoundItem;
                frmupdatesingleproduct frm = new frmupdatesingleproduct(product);
                frm.ShowDialog();
                if (frm.IsUpdateprice)
                {
                    var updateprice = RJMessageBox.Show(frm.msg, "Sistema de ventas",MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (updateprice == DialogResult.No)
                        this.Close();
                }
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.txtporcent.Text))
            {
                RJMessageBox.Show("Debe ingresar el porcentaje de aumento de precio de venta para ese producto", "Sistema de ventas", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtporcent.Text = String.Empty;
                txtporcent.Focus();
            }
            else if (string.IsNullOrEmpty(this.txtperchaseprice.Text) && this.chkpurchase.Checked)
            {
                RJMessageBox.Show("Debe ingresar el porcentaje de aumento de precio de compra para ese producto", "Sistema de ventas", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtporcent.Text = String.Empty;
                txtporcent.Focus();
            }
            else
            {
                decimal purchase = !string.IsNullOrEmpty(txtperchaseprice.Text) ? Convert.ToDecimal(txtperchaseprice.Text) : 0;
                string msg = RepoPathern.ProductService.UpdatePrices("", LoginInfo.IdAccount, Convert.ToDecimal(this.txtporcent.Text), purchase, UpdatePriceEnum.All, this.chkpurchase.Checked);
                RJMessageBox.Show(msg, "Sistema de ventas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }

        private void chkpurchase_CheckedChanged(object sender, EventArgs e)
        {
            if (chkpurchase.Checked)
            {
                this.txtperchaseprice.Enabled = true;
                this.txtperchaseprice.BackColor = SystemColors.Window;
            }
            else
            {
                this.txtperchaseprice.Enabled = false;
                this.txtperchaseprice.BackColor = SystemColors.MenuBar;
            }
        }

        private void btnsearch_Click(object sender, EventArgs e)
        {
            if (cbo.SelectedItem.Equals("Seleccionar una opcion") || cbo.SelectedItem.Equals(" "))
            {
                RJMessageBox.Show("Debe seleccionar una opcion para la busqueda", "Sistema de ventas", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                int option = this.GetOptionSearch(cbo.SelectedItem.ToString());

                this.dataList.DataSource = RepoPathern.ProductService.GetAllSearch(1, LoginInfo.pageactual, LoginInfo.pagesize, "Id", "asc", txtsearch.Text, option, ref count);
                this.HideColumn();
                this.GetPagination();
            }
        }

        private int GetOptionSearch(string cad)
        {
            switch (cad)
            {
                case "Por nombre de producto":
                    return 1;
                default:
                    return 2;
            }
        }

        private void cbo_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.txtsearch.Text = String.Empty;
            this.txtsearch.Focus();
        }

        private void txtsearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (cbo.SelectedItem.Equals("Seleccionar una opcion") || cbo.SelectedItem.Equals(" "))
                {
                    RJMessageBox.Show("Debe seleccionar una opcion para la busqueda", "Sistema de ventas", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    int option = this.GetOptionSearch(cbo.SelectedItem.ToString());

                    this.dataList.DataSource = RepoPathern.ProductService.GetAllSearch(1, LoginInfo.pageactual, LoginInfo.pagesize, "Id", "asc", txtsearch.Text, option, ref count);
                    this.HideColumn();
                    this.GetPagination();
                }
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

        private void frmupdateprice_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            Rectangle rectForm = this.ClientRectangle;
            int mWidht = rectForm.Width / 2;
            int mHeight = rectForm.Height / 2;
            var fbColors = GetFormBoundsColors();
            //-> SET ROUNDED REGION AND BORDER
            FormRegionAndBorder(this, borderRadius, e.Graphics, borderColor, borderSize);
        }

        private void frmupdateprice_ResizeEnd(object sender, EventArgs e)
        {
            this.Invalidate();
        }

        private void frmupdateprice_SizeChanged(object sender, EventArgs e)
        {
            this.Invalidate();
        }

        private void frmupdateprice_Validated(object sender, EventArgs e)
        {
            this.Invalidate();
        }

        private void frmupdateprice_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void label14_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
    }
}
