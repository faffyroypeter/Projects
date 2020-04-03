using System;
using System.Data;

namespace SET.BusinessEntity
{
    public class clsExpense
    {
        public int ExpenseId { get; set; }

        public int GroupId { get; set; }

        public string Description { get; set; }

        public decimal Amount { get; set; }

        public DateTime TransactionDate { get; set; }

        public DataTable TblSplitDetails { get; set; }
    }
}
