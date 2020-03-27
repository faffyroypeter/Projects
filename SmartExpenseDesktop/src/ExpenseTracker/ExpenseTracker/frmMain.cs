using SET.BusinessEntity;
using SET.BusinessLogic;
using System;
using System.Data;
using System.Windows.Forms;

namespace SET.ExpenseTracker
{
    public partial class frmUsers : Form
    {
        private FormActivity formActivity = FormActivity.None;

        private string RecordId { get; set; }

        public frmUsers()
        {
            InitializeComponent();
        }

        private void frmUsers_Load(object sender, EventArgs e)
        {
            FillGrid();
        }

        private void FillGrid()
        {
            switch (formActivity)
            {
                case FormActivity.User:
                    {
                        dgView.DataSource = new clsUserBusiness().FetchUsers();
                        break;
                    }

                case FormActivity.Group:
                    {
                        break;
                    }
                case FormActivity.SplitExpense:
                    {
                        break;
                    }
                case FormActivity.ExenseReports:
                    {
                        break;
                    }
            }
        }

        private void btnUserManagement_Click(object sender, EventArgs e)
        {
            formActivity = FormActivity.User;
            new frmUser(Constants.Default).ShowDialog();
            FillGrid();
        }

        private void btnGroupManagement_Click(object sender, EventArgs e)
        {
            formActivity = FormActivity.Group;
            new frmGroup().ShowDialog();
        }

        private void btnExpenseManagement_Click(object sender, EventArgs e)
        {
            formActivity = FormActivity.SplitExpense;
            new frmSplitExpense().ShowDialog();
        }

        private void btnExpenseReports_Click(object sender, EventArgs e)
        {
            formActivity = FormActivity.ExenseReports;
            new frmExpenseReports().ShowDialog();
        }

        private void dgView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                RecordId = dgView.Rows[e.RowIndex].Cells[0].Value.ToString();
            }
        }

        private void dgView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                RecordId = dgView.Rows[e.RowIndex].Cells[0].Value.ToString();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            switch (formActivity)
            {
                case FormActivity.User:
                    {
                        new frmUser(Constants.Default).ShowDialog();
                        break;
                    }
                case FormActivity.Group:
                    {
                        break;
                    }
                case FormActivity.SplitExpense:
                    {
                        break;
                    }
                case FormActivity.ExenseReports:
                    {
                        break;
                    }
            }

            FillGrid();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            switch (formActivity)
            {
                case FormActivity.User:
                    {
                        new frmUser(Convert.ToInt32(RecordId)).ShowDialog();
                        break;
                    }
                case FormActivity.Group:
                    {
                        break;
                    }
                case FormActivity.SplitExpense:
                    {
                        break;
                    }
                case FormActivity.ExenseReports:
                    {
                        break;
                    }
            }

            FillGrid();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            switch (formActivity)
            {
                case FormActivity.User:
                    {
                        dgView.DataSource = new clsUserBusiness().DeleteUser(Convert.ToInt32(RecordId));

                        break;
                    }
                case FormActivity.Group:
                    {
                        break;
                    }
                case FormActivity.SplitExpense:
                    {
                        break;
                    }
                case FormActivity.ExenseReports:
                    {
                        break;
                    }
            }

            FillGrid();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            FillGrid();
        }
    }
}