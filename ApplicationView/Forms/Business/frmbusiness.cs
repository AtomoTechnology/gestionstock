using ApplicationView.BusnessEntities.BE;
using ApplicationView.Forms.MsgBox;
using ApplicationView.Forms.RedesignForm;
using ApplicationView.Patern.singleton;
using ApplicationView.Resolver.Enums;
using ApplicationView.Resolver.HelperError.IExceptions;
using ApplicationView.Resolver.Security;
using ApplicationView.Share;
using ApplicationView.VariableSeesion;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace ApplicationView.Forms.Business
{
    public partial class frmbusiness : Form
    {
        private bool Isnuevo = false;
        private bool IsEditar = false;
        int count = 0;
        private int borderRadius = 20;
        private int borderSize = 2;
        //private Color borderColor = Color.White;
        private Color borderColor = Color.FromArgb(128, 128, 255);
        public frmbusiness()
        {
            InitializeComponent();
            LoginInfo.pageactual = 1;

            this.FormBorderStyle = FormBorderStyle.None;
            this.Padding = new Padding(borderSize);
            this.btnclose.FlatAppearance.BorderSize = 0;
            //this.panelTitleBar.BackColor = borderColor;
            //this.BackColor = borderColor;
        }
        private void LoadList()
        {
            this.dataList.DataSource = RepoPathern.BusnessService.GetAll(1, LoginInfo.pageactual, LoginInfo.pagesize, "Id", "asc", "", ref count);
            this.HideColumn();
            this.GetPagination(Convert.ToInt32(dataList.Rows.Count));
        }

        private void frmbusiness_Load(object sender, EventArgs e)
        {
            this.LoadList();
            if (count == 0)
            {
                this.tabControl1.SelectedIndex = 1;
                this.Habilitar(false);
                this.Botones();
                this.btnedit.Enabled = false;
            }
            else
            {
                this.Habilitar(false);
                this.Botones();
                this.btnedit.Enabled = false;
            }
        }
        private void HideColumn()
        {
            this.dataList.Columns["ckdelete"].Visible = false;
            this.dataList.Columns["FinalDate"].Visible = false;
            this.dataList.Columns["CreatedDate"].Visible = false;
            this.dataList.Columns["State"].Visible = false;
        }
        private void btnnew_Click(object sender, EventArgs e)
        {
            this.Isnuevo = true;
            this.IsEditar = false;
            this.Botones();
            this.CleanBox();
            this.Habilitar(true);
            this.txtbusinessname.Focus();
        }

        private void CleanBox()
        {
            this.txtbusinessname.Text = string.Empty;
            this.txtaddress.Text = string.Empty;
            this.txtcode.Text = string.Empty;
            this.txtcuit_cuil.Text = string.Empty;
            this.txtemail.Text = string.Empty;
            this.txtfirstname.Text = string.Empty;
            this.txtlastname.Text = string.Empty;
            this.txtpassword.Text = string.Empty;
            this.txtphone.Text = string.Empty;
            this.txtphoneadmin.Text = string.Empty;
            this.txtusername.Text = string.Empty;
            this.txtaddressbusiness.Text = string.Empty;
            this.txtrevenue.Text = string.Empty;
            this.dtpcreatedactivity.Value = DateTime.Now;

            this.btnsave.Text = "Guardar";
        }

        private void Habilitar(bool valor)
        {
            this.txtbusinessname.ReadOnly = !valor;
            this.txtaddress.ReadOnly = !valor;
            this.txtcode.ReadOnly = !valor;
            this.txtcuit_cuil.ReadOnly = !valor;
            this.txtemail.ReadOnly = !valor;
            this.txtfirstname.ReadOnly = !valor;
            this.txtlastname.ReadOnly = !valor;
            this.txtpassword.ReadOnly = !valor;
            this.txtphone.ReadOnly = !valor;
            this.txtphoneadmin.ReadOnly = !valor;
            this.txtusername.ReadOnly = !valor;
            this.txtaddressbusiness.ReadOnly = !valor;
            this.txtrevenue.ReadOnly = !valor;
            this.dtpcreatedactivity.Enabled = valor;
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
            this.CleanBox();
            this.Habilitar(false);
            this.btnedit.Enabled = false;
            this.HideOShowGroup(true);
        }

        private void btnedit_Click(object sender, EventArgs e)
        {
            this.HideOShowGroup(false);
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

        private void btnnew_Click_1(object sender, EventArgs e)
        {
            this.Isnuevo = true;
            this.IsEditar = false;
            this.Botones();
            this.CleanBox();
            this.Habilitar(true);
            this.txtbusinessname.Focus();
            this.HideOShowGroup(true);
        }
        private void SearchByName()
        {
            if (!this.txtsearch.Text.Trim().Equals(""))
            {
                this.dataList.DataSource = RepoPathern.BusnessService.GetAll(1, LoginInfo.pageactual, LoginInfo.pagesize, "Id", "asc", this.txtsearch.Text.Trim(), ref count);
                this.GetPagination(Convert.ToInt32(dataList.Rows.Count));
            }
            else
                this.LoadList();

            this.HideColumn();
            lblTotal.Text = Convert.ToString(count);
        }

        private void btnsearch_Click(object sender, EventArgs e)
        {
            this.SearchByName();
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
                                Codigo = Convert.ToString(row.Cells[5].Value);
                                resp = RepoPathern.BusnessService.Delete(Codigo);

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
            var be = (BusinessBE)selectedRow.DataBoundItem;

            this.txtcode.Text = be.Id;
            this.txtbusinessname.Text = be.BusinessName;
            this.txtcuit_cuil.Text = be.Cuit_Cuil;
            this.txtaddressbusiness.Text = be.Address;
            this.txtphone.Text = be.Phone;
            this.txtrevenue.Text = be.Grossrevenue;
            this.dtpcreatedactivity.Value = be.CreatedDate;

            this.Habilitar(false);
            this.btnedit.Enabled = true;
            this.btnsave.Enabled = false;
            this.btnnew.Enabled = false;
            this.btnsave.Text = "Modificar";
            this.HideOShowGroup(false);
            this.tabControl1.SelectedIndex = 1;
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            try
            {
                String resp = "";
                if (txtbusinessname.Text.Trim().Equals(""))
                {
                    RJMessageBox.Show("Debe ingresar  el nombre del negocio", "Sistema de ventas", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtbusinessname.Text = String.Empty;
                    txtbusinessname.Focus();
                }
                else if (txtcuit_cuil.Text.Trim().Equals(""))
                {
                    RJMessageBox.Show("Debe ingresar  el C.U.I.T del negocio", "Sistema de ventas", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtcuit_cuil.Text = String.Empty;
                    txtcuit_cuil.Focus();
                }
                else if (txtrevenue.Text.Trim().Equals(""))
                {
                    RJMessageBox.Show("Debe ingresar  el ingreso bruto del negocio", "Sistema de ventas", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtrevenue.Text = String.Empty;
                    txtrevenue.Focus();
                }
                else if (txtaddressbusiness.Text.Trim().Equals(""))
                {
                    RJMessageBox.Show("Debe ingresar la direccion del negocio", "Sistema de ventas", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtaddressbusiness.Text = String.Empty;
                    txtaddressbusiness.Focus();
                }
                else if (txtfirstname.Text.Trim().Equals("") && !this.IsEditar)
                {
                    RJMessageBox.Show("Debe ingresar  el nombre del administrador", "Sistema de ventas", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtfirstname.Text = String.Empty;
                    txtfirstname.Focus();
                }
                else if (txtlastname.Text.Trim().Equals("") && !this.IsEditar)
                {
                    RJMessageBox.Show("Debe ingresar  el apellido del administrador", "Sistema de ventas", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtlastname.Text = String.Empty;
                    txtlastname.Focus();
                }
                else if (txtusername.Text.Trim().Equals("") && !this.IsEditar)
                {
                    RJMessageBox.Show("Debe ingresar  el nombre de usuario del administrador", "Sistema de ventas", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtusername.Text = String.Empty;
                    txtusername.Focus();
                }
                else if (txtpassword.Text.Trim().Equals("") && !this.IsEditar)
                {
                    MessageBox.Show("Debe ingresar  la contraseña de usuario del administrador", "Sistema de ventas", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtpassword.Text = String.Empty;
                    txtpassword.Focus();
                }
                else
                {
                    BusinessBE be = new BusinessBE()
                    {
                        BusinessName = txtbusinessname.Text.Trim(),
                        Address = txtaddressbusiness.Text.Trim(),
                        Cuit_Cuil = txtcuit_cuil.Text.Trim(),
                        Phone = txtphone.Text.Trim(),
                        state = (Int32)StateEnum.Activeted,
                        Grossrevenue = txtrevenue.Text,
                        CreatedDate = DateTime.Now,
                        Users = new List<UserBE>()
                        {
                            new UserBE()
                            {
                                Address = txtaddress.Text.Trim(),
                                FirstName = txtfirstname.Text.Trim(),
                                LastName = txtlastname.Text.Trim(),
                                Email = txtemail.Text.Trim(),
                                Phone = txtphone.Text.Trim(),
                                state = (Int32)StateEnum.Activeted,
                                CreatedDate = dtpcreatedactivity.Value,
                                Accounts = new List<AccountBE>()
                                {
                                    new AccountBE()
                                    {
                                        UserName = txtusername.Text.Trim(),
                                        UserPass = PassValidation.GetInstance().Encypt(txtpassword.Text.Trim()),
                                        Confirm = false
                                    }
                                }
                            }
                        }
                    };

                    if (Isnuevo)
                        resp = RepoPathern.BusnessService.Create(be);
                    else
                        resp = RepoPathern.BusnessService.Update(txtcode.Text.Trim(), be).ToString();

                    if (!string.IsNullOrEmpty(resp))
                        RJMessageBox.Show(resp, "Sistema de ventas", MessageBoxButtons.OK, MessageBoxIcon.Information);

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
        private void HideOShowGroup(Boolean val)
        {
            this.groupBox3.Visible = val;
            this.groupBox4.Visible = val;
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

        private void GetPagination(int quantity)
        {
            if (quantity > 0)
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

        private void frmbusiness_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            Rectangle rectForm = this.ClientRectangle;
            int mWidht = rectForm.Width / 2;
            int mHeight = rectForm.Height / 2;
            var fbColors = GetFormBoundsColors();
            //-> SET ROUNDED REGION AND BORDER
            FormRegionAndBorder(this, borderRadius, e.Graphics, borderColor, borderSize);
        }

        private void frmbusiness_ResizeEnd(object sender, EventArgs e)
        {
            this.Invalidate();
        }

        private void frmbusiness_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
    }
}
