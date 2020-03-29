using SET.BusinessEntity;
using SET.DataAccess;
using System.Data;

namespace SET.BusinessLogic
{
    public class clsExpenseBusiness
    {
        private clsExpenseDataAccess objExpenseDataAccess = new clsExpenseDataAccess();

        public int SaveExpense(clsExpense objExpense)
        {
            return objExpenseDataAccess.SaveExpense(objExpense, EnumCRUD.Create);
        }

        public int DeleteExpense(int expenseId)
        {
            return objExpenseDataAccess.SaveExpense(new clsExpense() { ExpenseId= expenseId}, EnumCRUD.Delete);
        }

        public DataTable FetchAllExpense()
        {
            return objExpenseDataAccess.ReadExpense(EnumCRUD.SelectAll);
        }

        public DataTable FetchExpense(int expenseId)
        {
            return objExpenseDataAccess.ReadExpense(EnumCRUD.Read, expenseId);
        }
    }
}
