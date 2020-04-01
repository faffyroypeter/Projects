using SET.BusinessEntity;
using SET.DataAccess;
using System.Data;

namespace SET.BusinessLogic
{
    public class clsSplitExpenseBusiness
    {
        private clsSplitDataAccess objSplitDataAccess = new clsSplitDataAccess();

        public int SaveSplitExpense(clsSplitExpense objSplitExpense)
        {
            return objSplitDataAccess.SaveSplitExpense(objSplitExpense, EnumCRUD.Create);
        }

        public int DeleteSplitExpense(int expenseId)
        {
            return objSplitDataAccess.SaveSplitExpense(new clsSplitExpense() { ExpenseId= expenseId}, EnumCRUD.Delete);
        }

        public DataTable FetchSplitAllExpense()
        {
            return objSplitDataAccess.ReadSplitExpense(EnumCRUD.SelectAll);
        }

        public DataTable FetchSplitExpense(int expenseId)
        {
            return objSplitDataAccess.ReadSplitExpense(EnumCRUD.Read, expenseId);
        }
    }
}
