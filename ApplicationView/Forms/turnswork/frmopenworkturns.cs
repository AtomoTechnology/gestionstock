using ApplicationView.BusnessEntities.BE;
using ApplicationView.Forms.Account;
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

namespace ApplicationView.Forms.turnswork
{
    public partial class frmopenworkturns : Form
    {
        //private readonly IAccountService _repoAccount;
        //private readonly ITurnService _repoTurn;
        private bool Isnuevo = false;
        private bool IsEditar = false;
        int count = 0;
        int _Islistuser;
        private int borderRadius = 20;
        private int borderSize = 2;
        //private Color borderColor = Color.White;
        private Color borderColor = Color.FromArgb(128, 128, 255);
        public frmopenworkturns(int isclose = 1)
        {
            InitializeComponent();
            this._Islistuser = isclose;
            LoginInfo.pageactual = 1;

            this.FormBorderStyle = FormBorderStyle.None;
            this.Padding = new Padding(borderSize);
            this.btnclose.FlatAppearance.BorderSize = 0;
            //this.panelTitleBar.BackColor = borderColor;
            //this.BackColor = borderColor;
        }
        private void LoadList()
        {
            int state = 1;
            if (_Islistuser == 2)
            {
                this.label14.Text = "Cerrar turno";
                this.dataList.Columns["ckdelete"].Visible = false;
                tabPage2.Visible = false;
                tabControl1.Controls.Remove(tabPage2);
                this.chkEliminar.Visible = false;
            }
            else if (_Islistuser == 3)
            {
                //tabControl1.Controls.Remove(tabPage2);
                //((Control)this.tabControl1.TabPages["tabPage2"]).Enabled = false;
                this.label14.Text = "Turno cerrado";
                this.dataList.Columns["ckdelete"].Visible = false;
                this.chkEliminar.Visible = false;

                state = 3;
            }

            this.dataList.DataSource = RepoPathern.OpenWorkRepoService.GetAll(state, LoginInfo.pageactual, LoginInfo.pagesize, "Id", "asc", "", ref count);
            this.HideColumn();
            this.GetPagination(Convert.ToInt32(dataList.Rows.Count));
        }
        private void HideColumn()
        {
            this.dataList.Columns["ckdelete"].Visible = false;
            this.dataList.Columns["AccountId"].Visible = false;
            this.dataList.Columns["Turn"].Visible = false;
            this.dataList.Columns["State"].Visible = false;
            this.dataList.Columns["Account"].Visible = false;
            this.dataList.Columns["FinalDate"].Visible = false;
            this.dataList.Columns["TurnId"].Visible = false;
            this.dataList.Columns["CreatedDate"].Visible = false;
            this.dataList.Columns["ModifiedDate"].Visible = false;
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
        private void SearchByName()
        {
            if (!this.txtsearch.Text.Trim().Equals(""))
            {
                this.dataList.DataSource = RepoPathern.OpenWorkRepoService.GetAll(1, LoginInfo.pageactual, LoginInfo.pagesize, "Id", "asc", this.txtsearch.Text.Trim(), ref count);
                this.GetPagination(Convert.ToInt32(dataList.Rows.Count));
            }
            else
                this.LoadList();

            this.HideColumn();
            lblTotal.Text = Convert.ToString(count);
        }
        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void txtStartingQuantity_TextChanged(object sender, EventArgs e)
        {

        }

        private void frmopenworkturns_Load(object sender, EventArgs e)
        {
            this.LoadList();
            if (count == 0)
            {
                 if (_Islistuser != 2)
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
        private void CleanBox()
        {
            this.txtStartingQuantity.Text = string.Empty;
            this.txtcode.Text = string.Empty;
            this.txtturn.Text = string.Empty;
            this.txtturnIdselect.Text = string.Empty;
            this.txtuser.Text = string.Empty;
            this.txtaccountIdselect.Text = string.Empty;

            this.btnsave.Text = "Guardar";
        }

        private void Habilitar(bool valor)
        {
            this.txtStartingQuantity.ReadOnly = !valor;
            this.btnselectturn.Enabled = valor;
            this.btnselectuser.Enabled = valor;
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
                        string resp = "";

                        foreach (DataGridViewRow row in dataList.Rows)
                        {
                            if (Convert.ToBoolean(row.Cells[0].Value))
                            {
                                var turn = (OpenWorkTurnBE)row.DataBoundItem;
                                resp = RepoPathern.OpenWorkRepoService.Delete(turn.Id);

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
                MessageBox.Show(ex.MessageError, "Sistema de ventas", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            var turn = (OpenWorkTurnBE)selectedRow.DataBoundItem;

            if (_Islistuser == 2)
            {
                DialogResult Opcion = RJMessageBox.Show("¿Deseas cerrar el turno?", "Sistema de Ventas", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (Opcion == DialogResult.OK)
                {
                    RepoPathern.OpenWorkRepoService.CloseCashier(turn.AccountId, turn.TurnId);
                    this.LoadList();
                }
            }
            else if (_Islistuser == 1)
            {
                this.txtcode.Text = Convert.ToString(turn.Id);
                this.txtStartingQuantity.Text = Convert.ToString(turn.StartingQuantity);
                this.txtaccountIdselect.Text = turn.AccountId;
                this.txtturnIdselect.Text = turn.TurnId;
                this.txtturn.Text = turn.TurnName;
                this.txtuser.Text = turn?.Account?.User?.FirstName + " " + turn?.Account?.User?.LastName;

                this.Habilitar(false);
                this.btnedit.Enabled = true;
                this.btnsave.Enabled = false;
                this.btnnew.Enabled = false;
                this.btnsave.Text = "Modificar";
                this.tabControl1.SelectedIndex = 1;
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

        private void btnnew_Click(object sender, EventArgs e)
        {
            this.Isnuevo = true;
            this.IsEditar = false;
            this.Botones();
            this.CleanBox();
            this.Habilitar(true);
            this.txtStartingQuantity.Focus();
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            try
            {
                String resp = "";
                if (txtturn.Text.Trim().Equals(""))
                {
                    RJMessageBox.Show("Debe seleccionar el turno a abrir", "Sistema de ventas", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtturn.Text = String.Empty;
                    txtturn.Focus();
                }
                else if (txtuser.Text.Trim().Equals(""))
                {
                    RJMessageBox.Show("Debe seleccion el usuario para ese turno", "Sistema de ventas", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtuser.Text = String.Empty;
                    txtuser.Focus();
                }
                else if (txtStartingQuantity.Text.Trim().Equals(""))
                {
                    RJMessageBox.Show("Debe ingresar el dinero que deseas abrir el turno", "Sistema de ventas", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtStartingQuantity.Text = String.Empty;
                    txtStartingQuantity.Focus();
                }
                else
                {
                    OpenWorkTurnBE be = new OpenWorkTurnBE()
                    {
                        StartingQuantity = Convert.ToDecimal(this.txtStartingQuantity.Text),
                        AccountId = this.txtaccountIdselect.Text,
                        TurnId = this.txtturnIdselect.Text
                    };

                    if (Isnuevo)
                    {
                        var result =  RepoPathern.OpenWorkRepoService.Create(be);
                        var rest = result.Split('-');
                        LoginInfo.OpenWorkTurnId = rest[1];
                        resp = rest[0];
                    }                        
                    else
                        resp = RepoPathern.OpenWorkRepoService.Update(txtcode.Text.Trim(), be).ToString();

                    if (!string.IsNullOrEmpty(resp))
                        RJMessageBox.Show(resp, "Sistema de ventas", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.Isnuevo = false;
                    this.IsEditar = false;

                    this.Botones();
                    this.CleanBox();
                    this.LoadList();
                    this.tabControl1.SelectedIndex = 0;
                    //this.CloseAfterCreateTurnoWork();
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
        private void CloseAfterCreateTurnoWork()
        {
            LoginInfo.ischange = true;
            LoginInfo.changesession = true;
            LoginInfo.messegeaftercreateturn = "Se debe reiniciarel sistema al crear la caja de apertura.\n¿Desee hacerlo ahora?";
            //DialogResult result = RJMessageBox.Show("Se debe reiniciarel sistema al crear la caja de apertura \n.¿Desee hacerlo ahora?", "Sistema de ventas", MessageBoxButtons.OK, MessageBoxIcon.Question);

            if (DialogResult.OK == RJMessageBox.Show("Se debe reiniciarel sistema al crear la caja de apertura.\n¿Desee hacerlo ahora?", "Sistema de ventas", MessageBoxButtons.OK, MessageBoxIcon.Question))
            {
                this.Close();
                Application.Restart();
            }
            //foreach (Form frmlog in Application.OpenForms)
            //{
            //    if (frmlog.GetType() == typeof(frmPrincipal))
            //    {
            //        frmlog.Close();
            //        break;
            //    }
            //}
        }
        private void btnselectuser_Click(object sender, EventArgs e)
        {
            frmlistuser frm = new frmlistuser(LoginInfo.IdBusiness);
            frm.ShowDialog();
            if (frm.IsSelect)
            {
                this.txtuser.Text = frm.fullName;
                this.txtaccountIdselect.Text = frm.AccountId;
            }
            else
            {
                if (string.IsNullOrEmpty(this.txtuser.Text) && string.IsNullOrEmpty(this.txtaccountIdselect.Text))
                    RJMessageBox.Show("Debe seleccionar el usuario", "Sistema de ventas", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnselectturn_Click(object sender, EventArgs e)
        {
            frmturns frm = new frmturns(true);
            frm.ShowDialog();
            if (frm.IsSelect)
            {
                this.txtturnIdselect.Text = frm.turnId;
                this.txtturn.Text = frm.turnName;
            }
            else
            {
                if (string.IsNullOrEmpty(this.txtturnIdselect.Text) && string.IsNullOrEmpty(this.txtturn.Text))
                    RJMessageBox.Show("Debe seleccionar el turno", "Sistema de ventas", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void frmopenworkturns_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            Rectangle rectForm = this.ClientRectangle;
            int mWidht = rectForm.Width / 2;
            int mHeight = rectForm.Height / 2;
            var fbColors = GetFormBoundsColors();
            //-> SET ROUNDED REGION AND BORDER
            FormRegionAndBorder(this, borderRadius, e.Graphics, borderColor, borderSize);
        }

        private void frmopenworkturns_ResizeEnd(object sender, EventArgs e)
        {
            this.Invalidate();
        }

        private void frmopenworkturns_SizeChanged(object sender, EventArgs e)
        {
            this.Invalidate();
        }

        private void frmopenworkturns_Validated(object sender, EventArgs e)
        {
            this.Invalidate();
        }

        private void frmopenworkturns_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
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
    }
}
