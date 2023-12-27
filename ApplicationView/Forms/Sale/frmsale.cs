using ApplicationView.BusnessEntities.BE;
using ApplicationView.BusnessEntities.Dtos;
using ApplicationView.Forms.MsgBox;
using ApplicationView.Forms.RedesignForm;
using ApplicationView.Forms.turnswork;
using ApplicationView.Patern.singleton;
using ApplicationView.print;
using ApplicationView.Resolver.Enums;
using ApplicationView.Resolver.Helper;
using ApplicationView.Resolver.HelperError.IExceptions;
using ApplicationView.Resolver.log;
using ApplicationView.VariableSeesion;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ApplicationView.Forms.Sale
{
    public partial class frmsale : Form
    {
        private decimal price = 0;
        private int count = 0;
        private String saleId = "";
        private String lotId = "";
        private int Quantity = 0;
        string codesale;
        private int borderRadius = 20;
        private int borderSize = 2;
        private Color borderColor = Color.FromArgb(128, 128, 255);

        public frmsale()
        {
            InitializeComponent();
            Shown += Frmsale_Shown;
            txtreadcode.Focus();
            this.txtcajeroname.Text = LoginInfo.UserName;

            this.HideColumn();
            DataListHelper.SetGrid(this.dataList, 22);
            this.btnpay.Enabled = false;

            this.FormBorderStyle = FormBorderStyle.None;
            this.Padding = new Padding(borderSize);
            this.btnclose.FlatAppearance.BorderSize = 0;

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
                this.dataList.Columns["CreatedDate"].Visible = false;
            }        
        }       
        private void Frmsale_Shown(object sender, EventArgs e)
        {
            txtreadcode.Focus();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                List<SaleDetailDto> list = new List<SaleDetailDto>();
                if (e.KeyChar == (char)Keys.Enter && !string.IsNullOrEmpty(txtreadcode.Text))
                {
                    string productocode = string.Concat(txtreadcode.Text.Where(c => !Char.IsWhiteSpace(c)));
                    var result = RepoPathern.ProductService.SearchProducByCode(productocode);
                    if (result != null)
                    {
                        var incr = RepoPathern.IncreaseService.GetAll(1, 1, 12, "Id", "asc", DateTime.Now, DateTime.Now, LoginInfo.IdBusiness, ref count);
                        if (incr.Count > 0){
                            if (IsWithinTime(DateTime.Now.ToLongTimeString(), incr[0].HourFrom.ToLongTimeString(), incr[0].HourTo.ToLongTimeString(), incr[0].IsActive))
                                result.SalePrice = result.SalePrice*(1 + (incr[0].Porcent/100));
                        }
                    }
                   
                    if (dataList.Rows.Count == 0)
                    {

                        var be = new SaleBE()
                        {
                            AccountId = LoginInfo.IdAccount,
                            CreatedDate = DateTime.Now,
                            PaymentTypeId = "f5f737fd-860c-485b-972a-927d385f4ab5",
                            finalizeSale = false,
                            Total = 0,
                            OpenWorkTurnId = LoginInfo.OpenWorkTurnId,
                            state = (Int32)StateEnum.Activeted,
                            SaleDetail = new List<SaleDetailBE>()
                            {
                                new SaleDetailBE()
                                {
                                    state = (Int32)StateEnum.Activeted,
                                    CreatedDate = DateTime.Now,
                                    price =  result.SalePrice,
                                    productId = result.Id,
                                    quantity = this.Quantity == 0 ? 1 : this.Quantity
                                }
                            }
                        };
                        this.lotId = result.LotId;
                        list = RepoPathern.SaleService.Create(be, result.LotId);
                        this.Quantity = 0;
                    }
                    else
                    {
                        var saleid = (SaleDetailDto)dataList.Rows[0].DataBoundItem;
                        var be = new SaleDetailBE()
                        {
                            state = (Int32)StateEnum.Activeted,
                            CreatedDate = DateTime.Now,
                            price =  result.SalePrice,
                            productId = result.Id,
                            quantity = this.Quantity == 0 ? 1 : this.Quantity,
                            SaleId = saleid.SaleId
                        };
                        this.saleId = be.SaleId;
                        this.lotId = result.LotId;
                        list = RepoPathern.SaleDetailService.Create(be, result.LotId);
                        this.Quantity = 0;
                    }
                    txtreadcode.Text = String.Empty;
                    txtreadcode.Focus();

                    if (list.Count > 0)
                    {
                        price = list.Sum(u => (u.SalePrice * u.quantity));

                        this.dataList.DataSource = list;
                        this.saleId = ((SaleDetailDto)dataList.Rows[0].DataBoundItem).SaleId;
                        this.productqquantity.Text =  Convert.ToInt32(list.Sum(u => (u.quantity))).ToString();
                        this.lblStatus.Text = price.ToString("0,0.00");
                    }

                    this.dataList.FirstDisplayedScrollingRowIndex = (this.dataList.Rows.Count - 1);
                    if (this.dataList.Rows.Count > 0)
                    {
                        this.HideColumn(); 
                        DataListHelper.SetGrid(this.dataList, 22);
                        this.btnpay.Enabled = true;
                    }
                    this.dataList.ClearSelection();
                    this.dataList.CurrentCell = null;
                }
                this.HideColumn();
            }
            catch (ApiBusinessException ex)
            {
                this.Quantity = 0;
                txtreadcode.Text = String.Empty;
                RJMessageBox.Show(ex.MessageError, "Sistema de ventas", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                this.Quantity = 0;
                txtreadcode.Text = String.Empty;
                RJMessageBox.Show(ex.Message, "Sistema de ventas", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void InvoiceCodeFormat(Int64 InvoiceCode)
        {
            string fmt = "000-0000-00000";
            codesale = InvoiceCode.ToString();
            string result = InvoiceCode.ToString(fmt);
            textBox1.Text = result;
        }
        public bool IsWithinTime(string stringNowTime, string stringStartTime, string stringEndTime, bool isActive)
        {

            var nowTime = DateTime.Parse(stringNowTime);
            var startTime = DateTime.Parse(stringStartTime);
            var endTime = DateTime.Parse(stringEndTime);

            if ((nowTime.TimeOfDay.Hours <= endTime.TimeOfDay.Hours) && (nowTime.TimeOfDay.Hours >= startTime.TimeOfDay.Hours) && isActive)
                return true;
            return false;
        }
        private void frmsale_Load(object sender, EventArgs e)
        {
            txtreadcode.Focus(); 
            var lastfactnro = RepoPathern.ProductService.LastFactNro();
            this.InvoiceCodeFormat(lastfactnro);
        }
            
        private void btnpay_Click(object sender, EventArgs e)
        {
            frmclosepay frm = new frmclosepay(this.lblStatus.Text, this.saleId, Convert.ToInt32(productqquantity.Text), codesale, chckprinttiket.Checked);
            frm.ShowDialog();
            if (frm.iscorrectSale)
            {
                this.dataList.DataSource = new List<SaleDetailDto>();
                this.lblStatus.Text = "";
                this.btnpay.Enabled = false;
                this.productqquantity.Text = "";
                this.textBox1.Text = "";
                this.price = 0;
                this.Quantity = 0;
                this.txtreadcode.Focus();
                var lastfactnro = RepoPathern.ProductService.LastFactNro();
                this.InvoiceCodeFormat(lastfactnro);
            }
        }

        private async void dataList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                var selectedRow = this.dataList.SelectedRows[0];
                var sale = (SaleDetailDto)selectedRow.DataBoundItem;
                List<SaleDetailDto> dto = new List<SaleDetailDto>();

                if (LoginInfo.Role.ToLower().Equals("Admin".ToLower()))
                {
                    var result = RJMessageBox.Show("Esta por eliminar una venta.\n Esta seguro que desees eliminar la venta?", "Sistema de ventas",
                          MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        RepoPathern.SaleService.RemoveNoneSale(sale, this.lotId, LoginInfo.IdAccount, Resolver.Enums.DeleteSaleEnum.Admin);
                        dto = RepoPathern.SaleDetailService.SearchAllDetailByCode(this.saleId);
                        price = price - sale.SalePrice;
                    }
                    else
                        return;
                }
                else
                {
                    var result = await InputBoxAsync("Eliminar ventas", sale);
                    if (result.Item1 == DialogResult.OK)
                    {
                        if (result.Item2 == true)
                        {
                            var resultadmin = RJMessageBox.Show("Esta por eliminar una venta.\n Esta seguro que desees eliminar la venta?", "Sistema de ventas",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (resultadmin == DialogResult.Yes)
                            {
                                dto = RepoPathern.SaleDetailService.SearchAllDetailByCode(this.saleId);
                                txtreadcode.Text = String.Empty;
                                txtreadcode.Focus(); 
                                price = price - sale.SalePrice;
                            }
                            else
                                return;
                        }
                        else
                            return;
                    }
                    else
                        return;
                }

                if (dto != null)
                    this.dataList.DataSource = dto;
                if (dto.Count > 0)
                {
                    this.productqquantity.Text = Convert.ToInt32(dto.Sum(u => (u.quantity))).ToString();
                    this.lblStatus.Text = price.ToString();
                }
                else
                {
                    this.productqquantity.Text = "";
                    this.lblStatus.Text = "";
                    this.textBox1.Text = "";
                    this.btnpay.Enabled = false;
                    this.Quantity = 0;
                    var lastfactnro = RepoPathern.ProductService.LastFactNro();
                    this.InvoiceCodeFormat(lastfactnro);
                }
            }
            catch (ApiBusinessException ex)
            {
                txtreadcode.Text = String.Empty;
                RJMessageBox.Show(ex.MessageError, "Sistema de ventas", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                RJMessageBox.Show(ex.Message, "Sistema de ventas", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmsale_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.saleId!= null && this.dataList.RowCount > 0)
            {
                var statesale = RepoPathern.SaleService.GetById(this.saleId);
                
                try
                {
                    if (statesale != null)
                    {
                        if (!statesale.finalizeSale)
                        {
                            Application.EnableVisualStyles();
                            var result = RJMessageBox.Show("Esta venta esta abierta sin cobrar,se eliminar la venta al confirmarla.\n Esta seguro que desees salir la venta?", "Sistema de ventas",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (result == DialogResult.Yes)
                            {
                                SaleDetailDto dto = new SaleDetailDto()
                                {
                                    SaleId = this.saleId,
                                };
                                RepoPathern.SaleService.RemoveNoneSale(dto, this.lotId, LoginInfo.IdAccount, DeleteSaleEnum.CloseScreen);
                                this.Close();
                                LoginInfo.IsSaleNoneClose = true;
                            }
                            else
                            {
                                e.Cancel = true;
                                LoginInfo.IsSaleNoneClose = false;
                            }
                        }
                    }
                }
                catch (ApiBusinessException ex)
                {
                    txtreadcode.Text = String.Empty;
                    RJMessageBox.Show(ex.MessageError, "Sistema de ventas", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    txtreadcode.Text = String.Empty;
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

        private async Task<Tuple<DialogResult, bool>> InputBoxAsync(string title, SaleDetailDto saleDetail)
        {
            try
            {
                bool isok = false;
                string user;
                string pass;

                Form form = new Form();
                Label label = new Label();
                TextBox textBox = new TextBox();

                TextBox txtpass = new TextBox();
                Label lblpass = new Label();

                Button buttonOk = new Button();
                Button buttonCancel = new Button();

                form.Text = title;
                label.Text = "Usuario";
                lblpass.Text = "Contraseña";

                label.SetBounds(16, 16, 372, 13);
                textBox.SetBounds(16, 36, 350, 20);

                lblpass.SetBounds(16, 70, 372, 20);
                txtpass.SetBounds(16, 100, 350, 20);

                txtpass.PasswordChar = '*';

                buttonOk.SetBounds(150, 136, 100, 30);
                buttonCancel.SetBounds(268, 136, 100, 30);

                label.AutoSize = true;
                form.ClientSize = new Size(396, 177);
                form.FormBorderStyle = FormBorderStyle.FixedDialog;
                form.StartPosition = FormStartPosition.Manual;
                form.Location = new Point((form.Width + 300), (form.Height + 100));
                form.MinimizeBox = false;
                form.MaximizeBox = false;

                buttonOk.ForeColor = Color.Black;
                buttonOk.Text = "Aceptar";
                buttonCancel.Text = "Cancel";
                buttonOk.DialogResult = DialogResult.OK;
                buttonCancel.DialogResult = DialogResult.Cancel;

                form.Controls.AddRange(new Control[] { label, textBox, lblpass, txtpass, buttonOk, buttonCancel });
                form.AcceptButton = buttonOk;
                form.CancelButton = buttonCancel;

                DialogResult dialogResult = form.ShowDialog();
                user = textBox.Text;
                pass = txtpass.Text;

                if (dialogResult == DialogResult.Cancel)
                {
                    isok = false;
                    return new Tuple<DialogResult, bool>(dialogResult, isok);
                }
                if (string.IsNullOrEmpty(user) && dialogResult == DialogResult.OK)
                {
                    RJMessageBox.Show("Debe ingresar el usuario admin", "Sistema de ventas", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dialogResult = DialogResult.Cancel;
                    await InputBoxAsync(title, saleDetail);
                }
                else if (string.IsNullOrEmpty(pass) && dialogResult == DialogResult.OK)
                {
                    RJMessageBox.Show("Debe ingresar el pass del admin", "Sistema de ventas", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dialogResult = DialogResult.Cancel;
                    await InputBoxAsync(title, saleDetail);
                }
                else
                {
                    AccountBE Datos = await RepoPathern.AccountService.Login(user, pass);
                    if (Datos == null)
                    {
                        RJMessageBox.Show("Usuario y/o contraseña incorrecto", "Sistema de ventas", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        await InputBoxAsync(title, saleDetail);
                    }
                    if (Datos.Role.RoleName.ToLower() == "Admin".ToLower())
                    {
                        try
                        {
                            RepoPathern.SaleService.RemoveNoneSale(saleDetail, this.lotId, Datos.Id, Resolver.Enums.DeleteSaleEnum.Admin);
                            isok = true;
                        }
                        catch (Exception)
                        {
                            RJMessageBox.Show("No tiene acceso administrador", "Sistema de ventas", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            isok = false;
                            this.Close();
                        }
                    }
                    else
                    {
                        RJMessageBox.Show("No tiene acceso administrador", "Sistema de ventas", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        isok = false;
                        this.Close();
                    }
                }
                return new Tuple<DialogResult, bool>(dialogResult, isok);
            }
            catch (ApiBusinessException ex)
            {
                RJMessageBox.Show(ex.MessageError, "Sistema de ventas", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new Tuple<DialogResult, bool>(DialogResult.Cancel, false);
            }
            catch (Exception ex)
            {
                RJMessageBox.Show(ex.Message, "Sistema de ventas", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new Tuple<DialogResult, bool>(DialogResult.Cancel, false);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void frmsale_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            Rectangle rectForm = this.ClientRectangle;
            int mWidht = rectForm.Width / 2;
            int mHeight = rectForm.Height / 2;
            var fbColors = GetFormBoundsColors();
            //-> SET ROUNDED REGION AND BORDER
            FormRegionAndBorder(this, borderRadius, e.Graphics, borderColor, borderSize);
        }

        private void frmsale_ResizeEnd(object sender, EventArgs e)
        {
            this.Invalidate();
        }

        private void frmsale_SizeChanged(object sender, EventArgs e)
        {
            this.Invalidate();
        }

        private void frmsale_Validated(object sender, EventArgs e)
        {
            this.Invalidate();
        }

        private void frmsale_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void chckprinttiket_CheckedChanged(object sender, EventArgs e)
        {
            if (chckprinttiket.Checked)
            {
                chckprinttiket.Checked = true;
                return;

            }
            else
            {
                chckprinttiket.Checked = false;
                return;
            }
        }

        private void txtreadcode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F7)
            {
                frmmorethenone frm = new frmmorethenone();
                frm.ShowDialog();
                this.Quantity = frm.Quantity;
                this.txtreadcode.Text = String.Empty;
            }
        }

        private void btndetailturn_Click(object sender, EventArgs e)
        {
            frmdetailturn frm = new frmdetailturn();
            frm.ShowDialog();
        }
    }
}
