using ApplicationView.BusnessEntities.BE;
using ApplicationView.Forms.MsgBox;
using ApplicationView.Forms.RedesignForm;
using ApplicationView.Forms.Roles;
using ApplicationView.Patern.singleton;
using ApplicationView.Resolver.Enums;
using ApplicationView.Resolver.Helper;
using ApplicationView.Resolver.HelperError.IExceptions;
using ApplicationView.Share;
using ApplicationView.VariableSeesion;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace ApplicationView.Forms.User
{
    public partial class frmusr : Form
    {
        private bool Isnuevo = false;
        private bool IsEditar = false;
        public List<ModuleAccountBE> mabe = null;
        int count = 0;
        private int borderRadius = 20;
        private int borderSize = 2;
        //private Color borderColor = Color.White;
        private Color borderColor = Color.FromArgb(128, 128, 255);
        public frmusr()
        {
            InitializeComponent();
            DataListHelper.SetGrid(this.dataList, 14, 12);
            mabe = new List<ModuleAccountBE>();
            LoginInfo.pageactual = 1;

            this.FormBorderStyle = FormBorderStyle.None;
            this.Padding = new Padding(borderSize);
            this.btnclose.FlatAppearance.BorderSize = 0;
            //this.panelTitleBar.BackColor = borderColor;
            //this.BackColor = borderColor;
        }
        private void LoadList()
        {
            this.dataList.DataSource = RepoPathern.UserService.GetAll(1, LoginInfo.pageactual, LoginInfo.pagesize, "Id", "asc","", ref count);
            this.HideColumn();
            this.GetPagination(Convert.ToInt32(dataList.Rows.Count));
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

        private void frmusr_Load(object sender, EventArgs e)
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
            this.dataList.Columns["FinalDate"].Visible = false;
            this.dataList.Columns["ModifiedDate"].Visible = false;
            this.dataList.Columns["Business"].Visible = false;
            this.dataList.Columns["BusinessId"].Visible = false;
            this.dataList.Columns["Id"].Visible = false;
        }
        private void btnnew_Click(object sender, EventArgs e)
        {
            this.Isnuevo = true;
            this.IsEditar = false;
            this.Botones();
            this.CleanBox();
            this.Habilitar(true);
            this.txtfirstname.Focus();
        }

        private void CleanBox()
        {
            this.txtcode.Text = string.Empty;
            this.txtaddress.Text = string.Empty;
            this.txtemail.Text = string.Empty;
            this.txtfirstname.Text = string.Empty;
            this.txtlastname.Text = string.Empty;
            this.txtpassword.Text = string.Empty;
            this.txtphone.Text = string.Empty;
            this.txtusername.Text = string.Empty;

            this.btnsave.Text = "Guardar";
        }

        private void Habilitar(bool valor)
        {
            this.txtaddress.ReadOnly = !valor;
            this.txtemail.ReadOnly = !valor;
            this.txtfirstname.ReadOnly = !valor;
            this.txtlastname.ReadOnly = !valor;
            this.txtpassword.ReadOnly = !valor;
            this.txtphone.ReadOnly = !valor;
            this.txtusername.ReadOnly = !valor;
            this.btnselectplan.Enabled = valor;
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
        private void SearchByName()
        {
            if (!this.txtsearch.Text.Trim().Equals(""))
            {
                this.dataList.DataSource = RepoPathern.UserService.GetAll(1, LoginInfo.pageactual, LoginInfo.pagesize, "Id", "asc", this.txtsearch.Text.Trim(), ref count);
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
                        foreach (DataGridViewRow row in dataList.Rows)
                        {
                            var be = (UserBE)row.DataBoundItem;
                            if (be.Id == LoginInfo.IdUser && Convert.ToBoolean(row.Cells[0].Value))//No esta bien hay q revisarlo
                            {
                                RJMessageBox.Show("No se puede eliminar el usuario que esta logeado", "Sistema de ventas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                chkEliminar.Checked = false;
                                return;
                            }
                            if (Convert.ToBoolean(row.Cells[0].Value))
                                isdelate = RepoPathern.UserService.Delete(be.Id);
                        }
                        if (isdelate)
                        {
                            RJMessageBox.Show("El usuario fue eliminado", "Sistema de ventas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            chkEliminar.Checked = false;

                        }
                        else
                        {
                            RJMessageBox.Show("El usuario no fue eliminado", "Sistema de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            var be = (UserBE)selectedRow.DataBoundItem;

            this.txtcode.Text = be.Id;
            this.txtfirstname.Text = be.FirstName;
            this.txtlastname.Text = be.LastName;
            this.txtemail.Text = be.Email;
            this.txtaddress.Text = be.Address;
            this.txtphone.Text = be.Phone;

            this.Habilitar(false);
            this.btnedit.Enabled = true;
            this.btnsave.Enabled = false;
            this.btnnew.Enabled = false;
            this.btnsave.Text = "Modificar";
            this.HideOShowGroup(false);
            this.tabControl1.SelectedIndex = 1;
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

        private void btnnew_Click_1(object sender, EventArgs e)
        {
            this.Isnuevo = true;
            this.IsEditar = false;
            this.Botones();
            this.CleanBox();
            this.Habilitar(true);
            this.txtfirstname.Focus();
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
        private void HideOShowGroup(Boolean val)
        {
            //this.groupBox3.Visible = val;
            this.groupBox4.Visible = val;
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            try
            {
                String resp = "";
                if (txtfirstname.Text.Trim().Equals("") && !this.IsEditar)
                {
                    RJMessageBox.Show("Debe ingresar  el nombre del usuario", "Sistema de ventas", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtfirstname.Text = String.Empty;
                    txtfirstname.Focus();
                }
                else if (txtlastname.Text.Trim().Equals("") && !this.IsEditar)
                {
                    RJMessageBox.Show("Debe ingresar  el apellido del usuario", "Sistema de ventas", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtlastname.Text = String.Empty;
                    txtlastname.Focus();
                }
                else if (txtrolename.Text.Trim().Equals("") && !this.IsEditar)
                {
                    RJMessageBox.Show("Debe seleccionar  el rol para el usuario", "Sistema de ventas", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtrolename.Text = String.Empty;
                    txtrolename.Focus();
                }
                else if (this.mabe.Count == 0 && !this.IsEditar)
                {
                    RJMessageBox.Show("No se puede crear un usuario sin acceso algun modulo", "Sistema de ventas", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    btnselectplan.Focus();
                }
                else if (txtusername.Text.Trim().Equals("") && !this.IsEditar)
                {
                    RJMessageBox.Show("Debe ingresar  el nombre de usuario del usuario", "Sistema de ventas", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtusername.Text = String.Empty;
                    txtusername.Focus();
                }
                else if (txtpassword.Text.Trim().Equals("") && !this.IsEditar)
                {
                    RJMessageBox.Show("Debe ingresar  la contraseña de usuario del usuario", "Sistema de ventas", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtpassword.Text = String.Empty;
                    txtpassword.Focus();
                }
                else if (txtpassword.Text.Trim().Equals(txtusername.Text.Trim()) && !this.IsEditar)
                {
                    RJMessageBox.Show("La contreseña tiene que ser diferente del nombre usuario", "Sistema de ventas", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtpassword.Text = String.Empty;
                    txtpassword.Focus();
                }
                else
                {
                    UserBE be =  new UserBE()
                    {
                        BusinessId = LoginInfo.IdBusiness,
                        Address = this.txtaddress.Text.Trim(),
                        FirstName = this.txtfirstname.Text.Trim(),
                        LastName = this.txtlastname.Text.Trim(),
                        Email = this.txtemail.Text.Trim(),
                        Phone = this.txtphone.Text.Trim(),
                        state = (Int32)StateEnum.Activeted,
                        CreatedDate = DateTime.Now,
                        Accounts = new List<AccountBE>()
                        {
                            new AccountBE()
                            {
                                UserName = this.txtusername.Text.Trim(),
                                UserPass = this.txtpassword.Text.Trim(),
                                RoleId = this.txtroleid.Text.Trim(),
                                Confirm = false
                            }
                        }
                    };

                    if (Isnuevo)
                        resp = RepoPathern.UserService.Create(be,mabe);
                    else
                        resp = RepoPathern.UserService.Update(txtcode.Text.Trim(), be).ToString();

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

        private void btnselectplan_Click(object sender, EventArgs e)
        {
            frmrolelist frm = new frmrolelist();
            frm.ShowDialog();
            if (frm.isselectrole)
            {
                this.txtroleid.Text = frm.rolbe.Id;
                this.txtrolename.Text = frm.rolbe.RoleName;
                this.mabe = frm.mabe;
            }
            else
            {
                RJMessageBox.Show("Debe seleccionar un rol para el usuario", "Sistema de ventas", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void frmusr_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            Rectangle rectForm = this.ClientRectangle;
            int mWidht = rectForm.Width / 2;
            int mHeight = rectForm.Height / 2;
            var fbColors = GetFormBoundsColors();
            //-> SET ROUNDED REGION AND BORDER
            FormRegionAndBorder(this, borderRadius, e.Graphics, borderColor, borderSize);
        }

        private void frmusr_ResizeEnd(object sender, EventArgs e)
        {
            this.Invalidate();
        }

        private void frmusr_SizeChanged(object sender, EventArgs e)
        {
            this.Invalidate();
        }

        private void frmusr_Validated(object sender, EventArgs e)
        {
            this.Invalidate();
        }

        private void frmusr_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void label3_MouseDown(object sender, MouseEventArgs e)
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
