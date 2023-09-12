using ApplicationView.BusnessEntities.BE;
using ApplicationView.Patern.singleton;
using ApplicationView.Share;
using ApplicationView.VariableSeesion;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ApplicationView.Forms.Account
{
    public partial class frmlistuser : Form
    {
        int count = 0;
        private string _businessId;
        public string fullName { get; set; }
        public string AccountId { get; set; }
        public bool IsSelect { get; set; }
        public frmlistuser(string businessId)
        {
            InitializeComponent();
            _businessId = businessId;
        }
        private void LoadList()
        {

            this.dataList.DataSource = RepoPathern.AccountService.FilterAccountByBusinessId(1, 1, 12,_businessId, "Id", "asc", "", ref count);
            this.HideColumn();
            this.GetPagination();
        }
        private void HideColumn()
        {
            this.dataList.Columns["Role"].Visible = false;
            this.dataList.Columns["State"].Visible = false;
            this.dataList.Columns["User"].Visible = false;
            this.dataList.Columns["CreatedDate"].Visible = false;
            this.dataList.Columns["ModifiedDate"].Visible = false;
            this.dataList.Columns["FinalDate"].Visible = false;
            this.dataList.Columns["Confirm"].Visible = false;
            this.dataList.Columns["RoleId"].Visible = false;
            this.dataList.Columns["UserId"].Visible = false;
            //this.dataList.Columns["UserName"].Visible = false;
            this.dataList.Columns["UserPass"].Visible = false;
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
                this.dataList.DataSource = RepoPathern.AccountService.FilterAccountByBusinessId(1, 1, 12, _businessId, "Id", "asc", this.txtsearch.Text.Trim(), ref count);
                this.GetPagination();
            }
            else
                this.LoadList();

            this.HideColumn();
            lblTotal.Text = Convert.ToString(count);
        }

        private void frmlistuser_Load(object sender, EventArgs e)
        {
            this.LoadList();
        }

        private void dataList_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var selectedRow = this.dataList.SelectedRows[0];
            var be = (AccountBE)selectedRow.DataBoundItem;

            this.AccountId = be.Id;
            this.fullName = be.FirstName + " " + be.LastName;
            this.IsSelect = true;
            this.Close();
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

        private void frmlistuser_FormClosing(object sender, FormClosingEventArgs e)
        {
            //this.IsSelect = false;
        }
    }
}
