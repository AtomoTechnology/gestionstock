using ApplicationView.BusnessEntities.Dtos;
using ApplicationView.exportExcel;
using ApplicationView.Forms.MsgBox;
using ApplicationView.Forms.RedesignForm;
using ApplicationView.Patern.singleton;
using ApplicationView.Resolver.HelperError.IExceptions;
using ApplicationView.Resolver.log;
using ApplicationView.Share;
using ApplicationView.VariableSeesion;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace ApplicationView.Forms.Sale
{
    public partial class frmsalehistoric : Form
    {
        private int borderRadius = 20;
        private int borderSize = 2;
        //private Color borderColor = Color.White;
        private Color borderColor = Color.FromArgb(128, 128, 255);
        public frmsalehistoric()
        {
            InitializeComponent();
            LoadTurns();
            this.dtpfrom.Value = DateTime.Now.AddDays(-1);
            LoginInfo.pageactual = 1;

            this.FormBorderStyle = FormBorderStyle.None;
            this.Padding = new Padding(borderSize);
            this.btnclose.FlatAppearance.BorderSize = 0;
            //this.panelTitleBar.BackColor = borderColor;
            //this.BackColor = borderColor;
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
        private void LoadList()
        {
            try
            {
                var result = RepoPathern.SaleService.GetAllSaleHistoric(dtpfrom.Value, dtpto.Value, cbturns.SelectedValue.ToString(), LoginInfo.pageactual, LoginInfo.pagesize);

                this.dataList.DataSource = result;
                if (this.dataList.Columns.Count == 0)
                    this.btnexport.Enabled = false;
                else
                    this.btnexport.Enabled = true;

                this.LoadGraph(result);
                this.HideColumn();
                this.GetPagination(Convert.ToInt32(dataList.Rows.Count));
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
        private void LoadTurns()
        {
            try
            {
                this.cbturns.DataSource = RepoPathern.SaleService.GetAllTurn();
                this.cbturns.DisplayMember = "TurnName";
                this.cbturns.ValueMember = "Id";
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
        private void GetPagination(int quantity)
        {
            if (quantity > 0)
            {
                var selectedRow = this.dataList.SelectedRows[0];
                var count = (SearchSaleSPDTO)selectedRow.DataBoundItem;
                this.lblprice.Text = count.Total.ToString();
                LoginInfo.pageamount = count.count;
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
            this.dataList.Columns["count"].Visible = false;
            this.dataList.Columns["Total"].Visible = false;
            this.dataList.Columns["Accountname"].Visible = false;
            this.dataList.Columns["InvoiceCode"].Visible = false;
            this.dataList.Columns["PaymentName"].Visible = false;
            this.dataList.Columns["ProductCode"].Visible = false;
            this.dataList.Columns["price"].Visible = false;            
        }

        private void frmsalehistoric_Load(object sender, EventArgs e)
        {
            this.LoadList();
        }

        private void btnsearch_Click(object sender, EventArgs e)
        {
            this.LoadList();
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
            var selectedRow = this.dataList.SelectedRows[0];
            var count = (SearchSaleSPDTO)selectedRow.DataBoundItem;
            ShareMethod.GetInstance().goLast((int)count.count);
            LoadList();
        }

        public void LoadGraph(List<SearchSaleSPDTO> list)
        {
            foreach (var series in chartTorta.Series)
            {
                series.Points.Clear();
            }

            this.chartTorta.Series["Series1"].XValueMember = "ProductName";
            this.chartTorta.Series["Series1"].YValueMembers = "subtotal";

            DataTable dt = ToDataTable(list);
            this.chartTorta.DataSource = dt;

            this.chartTorta.Series[0]["PieLabelStyle"] = "Outside";
            this.chartTorta.ChartAreas[0].Area3DStyle.Enable3D = true;
            this.chartTorta.ChartAreas[0].Area3DStyle.Inclination = 0;
            this.chartTorta.ChartAreas[0].Area3DStyle.Rotation = 0;
            this.chartTorta.Series[0].LegendText = "#PERCENT{P2}";
        }

        public DataTable ToDataTable(IList<SearchSaleSPDTO> data)
        {
            List<HistoricSale> dat = new List<HistoricSale>();

            //var result = from item in data.Select item (new List<HistoricSale>{ }).to;
            //var suma = data.Where(u =>u.ProductName ==  u.ProductName).Sum(u => u.price);
            PropertyDescriptorCollection properties =
                TypeDescriptor.GetProperties(typeof(SearchSaleSPDTO));
            DataTable table = new DataTable();
            foreach (PropertyDescriptor prop in properties)
                table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            foreach (SearchSaleSPDTO item in data)
            {
                DataRow row = table.NewRow();
                foreach (PropertyDescriptor prop in properties)
                    row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                table.Rows.Add(row);
            }
            return table;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void frmsalehistoric_Paint(object sender, PaintEventArgs e)
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

        private void frmsalehistoric_ResizeEnd(object sender, EventArgs e)
        {
            this.Invalidate();
        }

        private void frmsalehistoric_SizeChanged(object sender, EventArgs e)
        {
            this.Invalidate();
        }

        private void frmsalehistoric_Validated(object sender, EventArgs e)
        {
            this.Invalidate();
        }

        private void frmsalehistoric_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //if (dataList.Items.Count > 0)
            //{
            List<SearchSaleSPDTO> fields = new List<SearchSaleSPDTO>();
                SaveFileDialog form = new SaveFileDialog();
                form.AddExtension = false;
                form.CheckPathExists = true;
                form.Filter = "Archivo Excel | *.xls";
                form.DefaultExt = "xls";
                form.FileName = string.Format("{0}_{1}.{2}", "Campo", "ParaProbar", "xls");
                form.Title = "Guardar Archivo Excel";
                if (form.ShowDialog() == DialogResult.OK)
                {
                    //LogicaExcel.Instancia.getExcellFromPlus(campo, form.FileName);
                    //_servicereporte.
                    ExportData pro = new ExportData();
                    fields = RepoPathern.SaleService.GetAllSaleHistoricExport(dtpfrom.Value, dtpto.Value, cbturns.SelectedValue.ToString());
                    pro.ExportExcel(form.FileName, fields, "Prueba");
                    if (RJMessageBox.Show(this, "¿Desea abrir el archivo?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        System.Diagnostics.Process.Start(form.FileName);
                    }
                }
            //}
        }
      
    }
    public class HistoricSale
    {
        public String ProductName { get; set; }
        public decimal price { get; set; }
    }
}
