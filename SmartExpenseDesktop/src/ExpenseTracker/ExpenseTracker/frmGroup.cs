using SET.BusinessEntity;
using SET.BusinessLogic;
using System;
using System.Data;
using System.Windows.Forms;

namespace SET.ExpenseTracker
{
    public partial class frmGroup : Form
    {
        private clsGroupBusiness objGroupBusiness = new clsGroupBusiness();
        private int GroupId { get; set; }

        public frmGroup(int groupId)
        {
            InitializeComponent();
            this.GroupId = groupId;

            if (this.GroupId != Constants.Default)
            {
                DataTable dtGroup = objGroupBusiness.FetchGroupRecord(this.GroupId);
                if (dtGroup?.Rows?.Count > 0)
                {
                    txtGroupName.Text = dtGroup.Rows[0][1].ToString();
                }
            }

            FillGroups();
        }

        private void btnMapUsers_Click(object sender, EventArgs e)
        {
            var addedUsers = string.Empty;
            var removedUsers = string.Empty;

            var index = 0;
            foreach (DataRowView drvItem in chkUsers.Items)
            {
                var value = drvItem[chkUsers.ValueMember];
                if (chkUsers.GetItemChecked(index))
                {
                    addedUsers += value + ",";
                }
                else
                {
                    removedUsers += value + ",";
                }

                index++;
            }

            if (!string.IsNullOrEmpty(addedUsers))
            {
                objGroupBusiness.UpdateGroupUsers(GroupId, addedUsers, removedUsers);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            clsGroup objGroup = new clsGroup()
            {
                GroupId = this.GroupId,
                GroupName = txtGroupName.Text.Trim()
            };

            if (objGroupBusiness.SaveGroup(objGroup) > 0)
            {
                MessageBox.Show("Group Saved");
            }
            else
            {
                MessageBox.Show("Error in Saving Group Information.");
            }

            FillGroups();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtGroupName.Text = string.Empty;
        }

        private void FillGroups()
        {
            var dtGroups = objGroupBusiness.FetchGroups();

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

        private void cboGroups_SelectedIndexChanged(object sender, EventArgs e)
        {
            GroupId = Convert.ToInt32(((DataRowView)cboGroups.SelectedItem).Row[0]);

            var dtUsers = new clsGroupBusiness().FetchNonMappedUsersForGroup(GroupId);

            if (dtUsers.Rows.Count == 0)
            {
                return;
            }

            ((ListBox)chkUsers).DataSource = dtUsers;
            ((ListBox)chkUsers).DisplayMember = "UserName";
            ((ListBox)chkUsers).ValueMember = "UserId";

            if (cboGroups?.SelectedValue == null)
            {
                return;
            }

            var dtMappedUsers = objGroupBusiness.FetchGroupUsers(GroupId);
            if (dtMappedUsers.Rows.Count == 0)
            {
                return;
            }

            var index = 0;

            for (int i = 0; i < chkUsers.Items.Count; i++)
            {
                var itemValue = ((DataRowView)chkUsers.Items[i]).Row[chkUsers.ValueMember];
                var records = dtMappedUsers.Select("UserId = '" + itemValue + "'");
                if (records.Length > 0)
                {
                    chkUsers.SetItemChecked(index, true);
                }

                index++;
            }
        }
    }
}
