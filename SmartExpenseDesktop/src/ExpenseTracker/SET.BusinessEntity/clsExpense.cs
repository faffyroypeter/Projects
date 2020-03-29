using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SET.BusinessEntity
{
    public class clsExpense
    {
        public int ExpenseId { get; set; }

        public int GroupId { get; set; }

        public string Description { get; set; }
        
        public decimal Amount { get; set; }

        public DateTime TransactionDate { get; set; }
    }
}
