using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SET.BusinessEntity
{
    public class clsSplitExpense
    {
        public int SplitId { get; set; }

        public int ExpenseId { get; set; }

        public int GroupId { get; set; }

        public int UserId { get; set; }

        public decimal SplitPercentage { get; set; }
        
        public decimal SplitAmount { get; set; }
    }
}
