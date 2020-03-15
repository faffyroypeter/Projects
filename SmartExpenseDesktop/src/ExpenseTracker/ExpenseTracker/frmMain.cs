using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExpenseTracker
{
    public partial class frmUsers : Form
    {
        public frmUsers()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnUserManagement_Click(object sender, EventArgs e)
        {
            new frmUser().ShowDialog();
        }

        private void btnGroupManagement_Click(object sender, EventArgs e)
        {
            new frmGroup().ShowDialog();
        }

        private void btnExpenseManagement_Click(object sender, EventArgs e)
        {
            new frmSplitExpense().ShowDialog();
        }

        private void btnExpenseReports_Click(object sender, EventArgs e)
        {
            new frmExpenseReports().ShowDialog();
        }
    }
}
