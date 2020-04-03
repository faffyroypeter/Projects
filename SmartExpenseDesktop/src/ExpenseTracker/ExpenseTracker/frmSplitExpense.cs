using SET.BusinessEntity;
using SET.BusinessLogic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SET.ExpenseTracker
{
    public partial class frmSplitExpense : Form
    {
        private clsExpenseBusiness objExpenseBusiness = new clsExpenseBusiness();
        private string RecordId { get; set; }
        private int GroupIdValue { get; set; }
        public int ExpenseIdValue { get; set; }

        public DataTable dtSplitDetails { get; set; }

        public frmSplitExpense(int expenseId)
        {
            InitializeComponent();

            this.ExpenseIdValue = expenseId;
            FillGroups();
            FillUsers();
            FillExpenseHistory();
            FillEditableRecord(expenseId);
        }

        private void FillEditableRecord(int expenseId)
        {
            if (expenseId != Constants.Default)
            {
                DataTable dtExpense = objExpenseBusiness.FetchExpense(expenseId);

                if (dtExpense?.Rows?.Count > 0)
                {
                    dtTransactionDatePicker.Text = dtExpense.Rows[0]["TransactionDate"].ToString();
                    // cboGroups.SelectedItem = dtExpense.Rows[0]["GroupId"].ToString();
                    txtExpenseDesc.Text = dtExpense.Rows[0]["Description"].ToString();
                    txtAmount.Text = dtExpense.Rows[0]["Amount"].ToString();

                    // TODO : Bind Expense Detail
                }
            }
        }

        private void txtAmount_TextChanged(object sender, EventArgs e)
        {


        }

        private void rdoCustomSplitPercentage_CheckedChanged(object sender, EventArgs e)
        {
            // Custom Split by Percentage
        }

        private void rdoSplitByAmount_CheckedChanged(object sender, EventArgs e)
        {
            // Custome Split by amount
        }

        private void FillGroups()
        {
            var dtGroups = new clsGroupBusiness().FetchGroups();

            if (dtGroups.Rows.Count == 0)
            {
                return;
            }

            cboGroups.DataSource = dtGroups;
            cboGroups.DisplayMember = "GroupName";
            cboGroups.ValueMember = "GroupId";

            if (dtGroups?.Rows.Count > 0)
            {
                cboGroups.SelectedIndex = 0;
            }
        }

        private void FillUsers()
        {
            GroupIdValue = Convert.ToInt32(((DataRowView)cboGroups.SelectedItem).Row[0]);

            var dtUsers = new clsGroupBusiness().FetchGroupUsers(GroupIdValue);

            if (dtUsers.Rows.Count == 0)
            {
                return;
            }

            ((ListBox)chkUsers).DataSource = dtUsers;
            ((ListBox)chkUsers).DisplayMember = "Name";
            ((ListBox)chkUsers).ValueMember = "UserId";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            GroupIdValue = Convert.ToInt32(((DataRowView)cboGroups.SelectedItem).Row[0]);

            clsExpense objExpense = new clsExpense()
            {
                ExpenseId = this.ExpenseIdValue,
                GroupId = GroupIdValue,
                Description = txtExpenseDesc.Text.Trim(),
                Amount = Convert.ToDecimal("0" + txtAmount.Text.Trim()),
                TransactionDate = DateTime.Parse(dtTransactionDatePicker.Text),
                TblSplitDetails = (DataTable)dgSplit.DataSource

            };

            if (objExpenseBusiness.SaveExpense(objExpense) > 0)
            {
                // Save Split Details
                MessageBox.Show("Expense Saved");
            }
            else
            {
                MessageBox.Show("Error in Saving Expense Information.");
            }

            FillExpenseHistory();
        }

        private void FillExpenseHistory()
        {
            var dtExpense = objExpenseBusiness.FetchAllExpense();
            dgAllExpense.DataSource = dtExpense;
        }

        private void dgAllExpense_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                RecordId = dgAllExpense.Rows[e.RowIndex].Cells[0].Value.ToString();
            }

            FillEditableRecord(Convert.ToInt32(RecordId));
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            objExpenseBusiness.DeleteExpense(Convert.ToInt32(RecordId));
            FillExpenseHistory();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            FillExpenseHistory();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            dtTransactionDatePicker.Value = DateTime.Today;
            txtExpenseDesc.Text = string.Empty;
            txtAmount.Text = string.Empty;
        }

        private void btnSplit_Click(object sender, EventArgs e)
        {
            dgSplit.DataSource = null;
            var dtTemp = dtSplitDetails.Clone();

            int rowsCount = chkUsers.CheckedItems.Count;
            decimal amountProcessed = Convert.ToDecimal("0" + txtAmount.Text.Trim());
            decimal percentage = 0;

            if (rowsCount > 0)
            {
                percentage = 100 / rowsCount;
            }

            foreach (var item in chkUsers.CheckedItems)
            {
                var userId = ((DataRowView)item).Row[chkUsers.ValueMember];
                var dr = dtTemp.NewRow();

                dr["ExpenseId"] = "-1";
                dr["SplitId"] = "-1";
                dr["GroupId"] = GroupIdValue;
                dr["UserId"] = userId;
                dr["SplitAmount"] = Math.Round(amountProcessed / rowsCount, 2);
                dr["SplitPercentage"] = percentage;
                dr["PaidAmount"] = 0.00;

                dtTemp.Rows.Add(dr);
            }

            dgSplit.DataSource = dtTemp;
        }

        private void txtAmount_Leave(object sender, EventArgs e)
        {
            GroupIdValue = Convert.ToInt32(((DataRowView)cboGroups.SelectedItem).Row[0]);
            dtSplitDetails = new clsSplitExpenseBusiness().FetchSplitExpense(ExpenseIdValue);
        }
    }
}
