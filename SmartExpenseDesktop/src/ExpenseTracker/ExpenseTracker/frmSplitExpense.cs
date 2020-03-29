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

        public int ExpenseId { get; set; }

        public frmSplitExpense(int expenseId)
        {
            InitializeComponent();

            this.ExpenseId = expenseId;
            FillGroups();
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
            // Split the amount based on default selection
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            var GroupId = Convert.ToInt32(((DataRowView)cboGroups.SelectedItem).Row[0]);

            clsExpense objExpense = new clsExpense()
            {
                ExpenseId = this.ExpenseId,
                GroupId = GroupId,
                Description = txtExpenseDesc.Text.Trim(),
                Amount = Convert.ToDecimal("0" + txtAmount.Text.Trim()),
                TransactionDate = DateTime.Parse(dtTransactionDatePicker.Text)
            };

            if (objExpenseBusiness.SaveExpense(objExpense) > 0)
            {
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
    }
}
