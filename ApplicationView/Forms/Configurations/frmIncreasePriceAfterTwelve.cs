using ApplicationView.BusnessEntities.BE;
using ApplicationView.Forms.MsgBox;
using ApplicationView.Forms.RedesignForm;
using ApplicationView.Patern.singleton;
using ApplicationView.Resolver.HelperError.IExceptions;
using ApplicationView.VariableSeesion;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace ApplicationView.Forms.Configurations
{
    public partial class frmIncreasePriceAfterTwelve : Form
    {
        private bool Isnuevo = false;
        private bool IsEditar = false;
        int count = 0;
        private int borderRadius = 20;
        private int borderSize = 2;
        //private Color borderColor = Color.White;
        private Color borderColor = Color.FromArgb(128, 128, 255);
        public frmIncreasePriceAfterTwelve()
        {
            InitializeComponent();
            LoginInfo.pageactual = 1;

            this.FormBorderStyle = FormBorderStyle.None;
            this.Padding = new Padding(borderSize);
            this.btnclose.FlatAppearance.BorderSize = 0;
            //this.panelTitleBar.BackColor = borderColor;
            //this.BackColor = borderColor;
        }

        private void btnnew_Click(object sender, EventArgs e)
        {
            this.Isnuevo = true;
            this.IsEditar = false;
            this.Botones();
            this.CleanBox();
            this.Habilitar(true);
            //this.txtrol.Focus();
        }

        private void CleanBox()
        {
            this.txtcode.Text = string.Empty;
            this.txtporcent.Text = string.Empty;
            this.dtpfrom.Value = DateTime.Now;
            this.dtpto.Value = DateTime.Now;
            this.chbisactive.Checked = false;
            this.btnsave.Text = "Guardar";
        }

        private void Habilitar(bool valor)
        {
            this.dtpto.Enabled = valor;
            this.dtpfrom.Enabled = valor;
            this.txtporcent.ReadOnly = !valor;
            this.chbisactive.Enabled = valor;
        }

        private void Botones()
        {
            if (this.Isnuevo || this.IsEditar)
            {
                this.Habilitar(true);
                this.btnnew.Enabled = false;
                this.btnsave.Enabled = true;
                this.btnedit.Enabled = false;
                this.btncancel.Enabled = true;
            }
            else
            {
                this.Habilitar(false);
                this.btnnew.Enabled = true;
                this.btnsave.Enabled = false;
                this.btnedit.Enabled = true;
                this.btncancel.Enabled = false;
            }
        }

        private void btncancel_Click(object sender, EventArgs e)
        {
            this.Isnuevo = false;
            this.IsEditar = false;
            this.Botones();
            //this.CleanBox();
            this.Habilitar(false);
            if (count == 0)
                this.btnedit.Enabled = false;
            else
                this.btnedit.Enabled = true;
        }

        private void btnedit_Click(object sender, EventArgs e)
        {
            if (!this.txtcode.Text.Equals(""))
            {
                this.Isnuevo = false;
                this.IsEditar = true;
                this.Botones();
                this.Habilitar(true);
            }
            else
            {
                RJMessageBox.Show("Debe de seleccionar primero el registro a Modificar", "Sistema de ventas", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.tabControl1.SelectedIndex = 0;
            }
        }
        private void HideColumn()
        {
            this.dataList.Columns["ckdelete"].Visible = false;
            this.dataList.Columns["FinalDate"].Visible = false;
            this.dataList.Columns["Account"].Visible = false;
            this.dataList.Columns["ModifiedDate"].Visible = false; 
            this.dataList.Columns["AccountId"].Visible = false;
            this.dataList.Columns["CreatedDate"].Visible = false;
            this.dataList.Columns["State"].Visible = false;
            this.dataList.Columns["IsActive"].Visible = false;
        }
        private void LoadList()
        {
            List<IncreasePriceAfterTwelveBE> be = RepoPathern.IncreaseService.GetAll(1, LoginInfo.pageactual, LoginInfo.pagesize, "Id", "asc", DateTime.Now, DateTime.Now, LoginInfo.IdBusiness, ref count);
            this.dataList.DataSource = be;
            if (be.Count > 0)
            {
                this.txtcode.Text = be[0].Id;
                this.dtpfrom.Value = be[0].HourFrom;
                this.dtpto.Value = be[0].HourTo;
                this.txtporcent.Text = be[0].Porcent.ToString();
                this.chbisactive.Checked = be[0].IsActive;

                this.btnedit.Enabled = true;
                this.btnnew.Enabled = true;
                this.btnsave.Text = "Modificar";
            }
            this.HideColumn();
        }

        private void frmIncreasePriceAfterTwelve_Load(object sender, EventArgs e)
        {
            this.LoadList();
            if (count == 0)
            {
                this.tabControl1.SelectedIndex = 0;
                this.Habilitar(false);
                this.Botones();
                this.btnedit.Enabled = false;
                this.btnnew.Visible = true;
            }
            else
            {
                //this.Habilitar(false);
                //this.Botones();
                this.btnedit.Enabled = true;
                this.btncancel.Enabled = true;
                this.btnsave.Text = "Modificar";
                ((Control)this.tabControl1.TabPages[1]).Enabled = true;
                this.btnnew.Enabled = false;
            }
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            try
            {
                String resp = "";
                if (dtpfrom.Text.Trim().Equals(""))
                {
                    RJMessageBox.Show("Debe ingresar la hora desde que el incremento va a empezar", "Sistema de ventas", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.dtpfrom.Value = DateTime.Now;
                }
                else if (dtpto.Text.Trim().Equals(""))
                {
                    RJMessageBox.Show("Debe ingresar  la hora desde que el incremento va a terminar", "Sistema de ventas", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.dtpto.Value = DateTime.Now;
                }
                else if (txtporcent.Text.Trim().Equals(""))
                {
                    RJMessageBox.Show("Debe ingresar el porcentaje del aumento", "Sistema de ventas", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.txtporcent.Text = String.Empty;
                    this.txtporcent.Focus();
                }
                else if (dtpfrom.Text.Equals(dtpto.Text))
                {
                    RJMessageBox.Show("La hora desde no puede se igual a la hora hasta", "Sistema de ventas", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.dtpto.Value = DateTime.Now.AddHours(6);
                }
                else if (!chbisactive.Checked)
                {
                    RJMessageBox.Show("Se debe chequear el check de activado", "Sistema de ventas", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.dtpto.Value = DateTime.Now.AddHours(6);
                }
                else
                {
                    IncreasePriceAfterTwelveBE be = new IncreasePriceAfterTwelveBE()
                    {
                        AccountId = LoginInfo.IdAccount,
                        CreatedDate = DateTime.Now,
                        HourFrom = Convert.ToDateTime(dtpfrom.Value),
                        HourTo = Convert.ToDateTime(dtpto.Value),
                        IsActive = chbisactive.Checked,
                        Porcent = Convert.ToDecimal(txtporcent.Text),
                        ModifiedDate = DateTime.Now,
                        state = 1
                    };

                    if (Isnuevo)
                        resp = RepoPathern.IncreaseService.Create(be);
                    else
                        resp = RepoPathern.IncreaseService.Update(txtcode.Text.Trim(), be).ToString();

                    if (!string.IsNullOrEmpty(resp))
                        RJMessageBox.Show(resp.Split('-')[0], "Sistema de ventas", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.Isnuevo = false;
                    this.IsEditar = false;

                    this.Botones();
                    this.CleanBox();
                    this.LoadList();
                    this.tabControl1.SelectedIndex = 0;
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

        private void dataList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataList.Columns["ckdelete"].Index)
            {
                DataGridViewCheckBoxCell ChkEliminar = (DataGridViewCheckBoxCell)dataList.Rows[e.RowIndex].Cells["ckdelete"];
                ChkEliminar.Value = !Convert.ToBoolean(ChkEliminar.Value);
            }
        }

        private void dataList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var selectedRow = this.dataList.SelectedRows[0];
            var be = (IncreasePriceAfterTwelveBE)selectedRow.DataBoundItem;

            this.txtcode.Text = be.Id;
            this.dtpfrom.Value = be.HourFrom;
            this.dtpto.Value = be.HourTo;
            this.txtporcent.Text = be.Porcent.ToString();
            this.chbisactive.Checked = be.IsActive;

            this.Habilitar(false);
            this.btnedit.Enabled = true;
            this.btnsave.Enabled = false;
            this.btnnew.Enabled = false;
            this.btnsave.Text = "Modificar";
            this.tabControl1.SelectedIndex = 1;
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            try
            {
                Boolean isdelate = false;
                Boolean ischeked = false;

                foreach (DataGridViewRow row in dataList.Rows)
                {
                    if (Convert.ToBoolean(row.Cells[0].Value))
                    {
                        ischeked = true;
                    }
                }
                if (chkEliminar.Checked && ischeked)
                {
                    DialogResult Opcion;
                    Opcion = RJMessageBox.Show("Realmente Desea Eliminar los Registros", "Sistema de Ventas", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    if (Opcion == DialogResult.OK)
                    {
                        String Codigo;
                        string resp = "";

                        foreach (DataGridViewRow row in dataList.Rows)
                        {
                            if (Convert.ToBoolean(row.Cells[0].Value))
                            {
                                Codigo = ((IncreasePriceAfterTwelveBE)row.DataBoundItem).Id;
                                resp = RepoPathern.IncreaseService.Delete(Codigo);

                                if (!string.IsNullOrEmpty(resp))
                                {
                                    isdelate = true;
                                }
                                else
                                {
                                    isdelate = false;
                                }
                            }
                        }
                        if (isdelate)
                        {
                            RJMessageBox.Show(resp, "Sistema de ventas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            chkEliminar.Checked = false;

                        }
                        else
                        {
                            RJMessageBox.Show("El archivo no fue eliminado", "Sistema de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            chkEliminar.Checked = false;
                        }
                        this.LoadList();
                    }
                }
                else
                    RJMessageBox.Show("Debe chequear el checkbox eliminar, si deseas eliminar uno o mas registro", "Sistema de ventas", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void frmIncreasePriceAfterTwelve_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            Rectangle rectForm = this.ClientRectangle;
            int mWidht = rectForm.Width / 2;
            int mHeight = rectForm.Height / 2;
            var fbColors = GetFormBoundsColors();
            //-> SET ROUNDED REGION AND BORDER
            FormRegionAndBorder(this, borderRadius, e.Graphics, borderColor, borderSize);
        }

        private void frmIncreasePriceAfterTwelve_ResizeEnd(object sender, EventArgs e)
        {
            this.Invalidate();
        }

        private void frmIncreasePriceAfterTwelve_SizeChanged(object sender, EventArgs e)
        {
            this.Invalidate();
        }

        private void frmIncreasePriceAfterTwelve_Validated(object sender, EventArgs e)
        {
            this.Invalidate();
        }

        private void frmIncreasePriceAfterTwelve_MouseDown(object sender, MouseEventArgs e)
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
    }
}
