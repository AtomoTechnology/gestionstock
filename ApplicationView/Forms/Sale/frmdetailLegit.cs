using ApplicationView.BusnessEntities.BE;
using ApplicationView.Forms.MsgBox;
using ApplicationView.Forms.RedesignForm;
using ApplicationView.Patern.singleton;
using ApplicationView.Resolver.HelperError.IExceptions;
using ApplicationView.Share;
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
    public partial class frmdetailLegit : Form
    {
        int count = 0;
        private int borderRadius = 20;
        private int borderSize = 2;
        //private Color borderColor = Color.White;
        private Color borderColor = Color.FromArgb(128, 128, 255);
        public frmdetailLegit()
        {
            InitializeComponent();
            this.lblcount.Text = "0.00";
            LoginInfo.pageactual = 1;

            this.FormBorderStyle = FormBorderStyle.None;
            this.Padding = new Padding(borderSize);
            this.btnclose.FlatAppearance.BorderSize = 0;
            //this.panelTitleBar.BackColor = borderColor;
            //this.BackColor = borderColor;
        }
        private void LoadList()
        {

            var be = RepoPathern.LegitBusinessService.GetAll(1, LoginInfo.pageactual, LoginInfo.pagesize, "Id", "asc", this.txtsearch.Text.Trim(), ref count);
            var dto = (from l in be
                      select new LocalBe
                      {
                          Id = l.Id,
                          User = l?.Account?.UserName,
                          FullName = l.FullName,
                          Address = l.Address,
                          Total = l.Total
                      }).ToList();

            this.dataList.DataSource = dto;
            this.HideColumn();
            this.GetPagination();
        }
        private void HideColumn()
        {
            this.dataList.Columns["ckdelete"].Visible = false;
            this.dataList.Columns["Id"].Visible = false;
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
        private void SearchByName()
        {
            if (!this.txtsearch.Text.Trim().Equals(""))
            {
                var be = RepoPathern.LegitBusinessService.GetAll(1, LoginInfo.pageactual, LoginInfo.pagesize, "Id", "asc", this.txtsearch.Text.Trim(), ref count);
                var dto = (from l in be
                          select new LocalBe
                          {
                              Id = l.Id,
                              User = l?.Account?.UserName,
                              FullName = l.FullName,
                              Address = l.Address,
                              Total = l.Total
                          }).ToList().Cast<LocalBe>();
                          
                this.dataList.DataSource = dto;
                this.GetPagination();
            }
            else
                this.LoadList();

            this.HideColumn();
            lblTotal.Text = Convert.ToString(count);
        }

        private void frmdetailLegit_Load(object sender, EventArgs e)
        {
            this.LoadList();
        }

        private void chkEliminar_CheckedChanged(object sender, EventArgs e)
        {
            if (chkEliminar.Checked)
            {
                this.dataList.Columns[0].Visible = true;
            }
            else
            {
                foreach (DataGridViewRow row in dataList.Rows)
                {
                    if (Convert.ToBoolean(row.Cells[0].Value))
                    {
                        row.Cells[0].Value = false;
                    }
                }
                this.dataList.Columns[0].Visible = false;
            }
        }
        List<LegitBE> listbe = new List<LegitBE>();
        private void dataList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == dataList.Columns["ckdelete"].Index)
                {
                    DataGridViewCheckBoxCell ChkEliminar = (DataGridViewCheckBoxCell)dataList.Rows[e.RowIndex].Cells["ckdelete"];
                    int quantity = dataList.Rows.Count;

                    if (quantity > 0)
                    {
                        for (int i = 0; i < quantity; i++)
                        {
                            var ischeck = (DataGridViewCheckBoxCell)dataList.Rows[i].Cells["ckdelete"];
                            if (Convert.ToBoolean(ischeck.Value) && !Convert.ToBoolean(ChkEliminar.Value))
                            {
                                RJMessageBox.Show("Un fiador ya fue seleccionado", "Sistema de ventas", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                        }
                    }

                    ChkEliminar.Value = !Convert.ToBoolean(ChkEliminar.Value);


                    var selectedRow = this.dataList.SelectedRows[0].Cells;
                    var bound = this.dataList.SelectedRows[0];
                    var be = (LocalBe)bound.DataBoundItem;
                    decimal pa = 0;

                    if ((Boolean)ChkEliminar.Value == true)
                    {
                        String message = "Desees pagar todos";
                        String captacion = "Pagar fia";
                        MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                        DialogResult result;

                        result = RJMessageBox.Show(message, captacion, buttons);

                        string value = "";

                        if (result == System.Windows.Forms.DialogResult.No)
                        {
                            if (InputBox("Registro de pago de fia", "Ingrese la cantidad a pagar?", be.Total, ref value) == DialogResult.OK)                             
                                if (!String.IsNullOrEmpty(value))
                                    pa = Math.Abs((!String.IsNullOrEmpty(value) ? Convert.ToDecimal(value) : 0) - be.Total);      
                        }
                        else
                            pa = be.Total;

                        lblcount.Text = String.IsNullOrEmpty(value) ? pa.ToString() : value;
                        listbe.Add(new LegitBE()
                        {
                            Id = be.Id,
                            Total = pa
                        });
                    }
                    else
                    {
                        if (!String.IsNullOrEmpty(lblcount.Text) && !lblcount.Text.Equals("0"))
                        {
                            lblcount.Text = "0";
                            listbe.RemoveAll(u => u.Id == be.Id);
                        }
                    }

                    if (!listbe.Any())
                        btnpay.Enabled = false;
                    else
                        btnpay.Enabled = true;
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

        private DialogResult InputBox(string title, string promptText, decimal paactual, ref string value)
        {
            Form form = new Form();
            Label label = new Label();
            TextBox textBox = new TextBox();
            Button buttonOk = new Button();
            Button buttonCancel = new Button();

            form.Text = title;
            label.Text = promptText;

            label.SetBounds(16, 16, 372, 13);
            textBox.SetBounds(16, 36, 350, 20);
            buttonOk.SetBounds(150, 66, 100, 30);
            buttonCancel.SetBounds(268, 66, 100, 30);

            label.AutoSize = true;
            form.ClientSize = new Size(396, 107);
            form.FormBorderStyle = FormBorderStyle.FixedDialog;
            form.StartPosition = FormStartPosition.Manual;
            form.Location = new Point((form.Width + 300), (form.Height + 100));
            form.MinimizeBox = false;
            form.MaximizeBox = false;
            textBox.KeyPress += TextBox_KeyPress;    

            buttonOk.ForeColor = Color.Black;
            buttonOk.Text = "Aceptar";
            buttonCancel.Text = "Cancel";
            buttonOk.DialogResult = DialogResult.OK;
            buttonCancel.DialogResult = DialogResult.Cancel;

            form.Controls.AddRange(new Control[] { label, textBox, buttonOk, buttonCancel });
            form.AcceptButton = buttonOk;
            form.CancelButton = buttonCancel;

            DialogResult dialogResult = form.ShowDialog();
            value = textBox.Text;
            decimal mayor = !String.IsNullOrEmpty(value) ? Convert.ToDecimal(value) : 0;
            if (mayor > paactual && dialogResult == DialogResult.OK)
            {
                RJMessageBox.Show("El valor ingresado no puede ser mayor que el total", "Sistema de ventas", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dialogResult = DialogResult.Cancel;
                InputBox("Registro de pago de fia", "Ingrese la cantidad a pagar?", paactual, ref value);
            }
            if (string.IsNullOrEmpty(value) && dialogResult == DialogResult.OK)
            {
                RJMessageBox.Show("Debe ingresar el valor a pagar", "Sistema de ventas", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dialogResult = DialogResult.Cancel;
                InputBox("Registro de pago de fia", "Ingrese la cantidad a pagar?", paactual, ref value);
            }
            return dialogResult;
        }

        private void TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void btnsearch_Click(object sender, EventArgs e)
        {
            this.SearchByName();
        }

        private void btnpay_Click(object sender, EventArgs e)
        {
            try
            {
                RepoPathern.LegitBusinessService.PayLegit(listbe);
                this.lblcount.Text = "0.00";

                this.chkEliminar.Checked = false;
                this.LoadList();
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

        private void frmdetailLegit_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            Rectangle rectForm = this.ClientRectangle;
            int mWidht = rectForm.Width / 2;
            int mHeight = rectForm.Height / 2;
            var fbColors = GetFormBoundsColors();
            //-> SET ROUNDED REGION AND BORDER
            FormRegionAndBorder(this, borderRadius, e.Graphics, borderColor, borderSize);
        }

        private void frmdetailLegit_ResizeEnd(object sender, EventArgs e)
        {
            this.Invalidate();
        }

        private void frmdetailLegit_SizeChanged(object sender, EventArgs e)
        {
            this.Invalidate();
        }

        private void frmdetailLegit_Validated(object sender, EventArgs e)
        {
            this.Invalidate();
        }

        private void frmdetailLegit_MouseDown(object sender, MouseEventArgs e)
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

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }
    }

    public class LocalBe
    {
        public string Id { get; set; }
        public string User { get; set; }
        public string FullName { get; set; }
        public string Address { get; set; }
        public decimal Total { get; set; }   
    }
}
