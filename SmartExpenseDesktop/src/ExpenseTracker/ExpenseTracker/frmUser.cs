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
    public partial class frmUser : Form
    {
        private clsUserBusiness objUserBusiness = new clsUserBusiness();

        private int UserId { get; set; }

        public frmUser(int userId)
        {
            InitializeComponent();
            this.UserId = userId;

            if(this.UserId != Constants.Default)
            {
                DataTable dtUser = objUserBusiness.FetchUserRecord(this.UserId);
                if (dtUser?.Rows?.Count > 0)
                {
                    txtName.Text = dtUser.Rows[0][1].ToString();
                    txtUserName.Text = dtUser.Rows[0][2].ToString();
                    txtEmail.Text = dtUser.Rows[0][3].ToString();
                    txtPassword.Text = dtUser.Rows[0][4].ToString();
                    txtConfirmPassword.Text = txtPassword.Text;
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var message = string.Empty;

            if (txtPassword.Text.Trim().Equals(txtConfirmPassword.Text.Trim()))
            {
                clsUser objUser = new clsUser()
                {
                    UserId = this.UserId,
                    Name = txtName.Text.Trim(),
                    UserName = txtUserName.Text.Trim(),
                    Email = txtEmail.Text.Trim(),
                    Password = txtPassword.Text.Trim()
                };

                if (objUserBusiness.SaveUser(objUser) > 0)
                {
                    MessageBox.Show("User Saved");
                }
                else
                {
                    MessageBox.Show("Error in Saving User Information.");
                }

                this.Close();
            }
            else
            {
                MessageBox.Show("Password mismatch.");
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtName.Text = string.Empty;
            txtUserName.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtPassword.Text = string.Empty;
            txtConfirmPassword.Text = string.Empty;
        }
    }
}
