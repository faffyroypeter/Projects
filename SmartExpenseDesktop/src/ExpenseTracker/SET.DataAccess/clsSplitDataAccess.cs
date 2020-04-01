using SET.BusinessEntity;
using System.Data;
using System.Data.SqlClient;

namespace SET.DataAccess
{
    public class clsSplitDataAccess
    {
        public int SaveSplitExpense(clsSplitExpense expense, EnumCRUD crudOperationType)
        {
            var conn = Database.Instance.objSqlConnection;

            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }

            switch (crudOperationType)
            {
                case EnumCRUD.Create:
                case EnumCRUD.Update:
                    {
                        var sqlCmd = new SqlCommand("spSplit", conn)
                        {
                            CommandType = CommandType.StoredProcedure
                        };

                        sqlCmd.Parameters.AddWithValue("@ActionType", "SaveData");
                        sqlCmd.Parameters.AddWithValue("@SplitId", expense.SplitId);
                        sqlCmd.Parameters.AddWithValue("@ExpenseId", expense.ExpenseId);
                        sqlCmd.Parameters.AddWithValue("@GroupId", expense.GroupId);
                        sqlCmd.Parameters.AddWithValue("@UserId", expense.UserId);
                        sqlCmd.Parameters.AddWithValue("@SplitPercentage", expense.SplitPercentage);
                        sqlCmd.Parameters.AddWithValue("@SplitAmount", expense.SplitAmount);
                        
                        return sqlCmd.ExecuteNonQuery();
                    }
                case EnumCRUD.Delete:
                    {
                        var sqlCmd = new SqlCommand("spSplit", conn);
                        sqlCmd.CommandType = CommandType.StoredProcedure;
                        sqlCmd.Parameters.AddWithValue("@ActionType", "DeleteData");
                        sqlCmd.Parameters.AddWithValue("@ExpenseId", expense.ExpenseId);
                        return sqlCmd.ExecuteNonQuery();
                    }
            }

            return 0;
        }

        public DataTable ReadSplitExpense(EnumCRUD crudOperationType,int expenseId = 0)
        {
            var conn = Database.Instance.objSqlConnection;

            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }

            switch (crudOperationType)
            {
                case EnumCRUD.Read:
                    {
                        DataTable dtData = new DataTable();
                        var sqlCmd = new SqlCommand("spSplit", conn)
                        {
                            CommandType = CommandType.StoredProcedure
                        };

                        sqlCmd.Parameters.AddWithValue("@ActionType", "FetchRecord");
                        sqlCmd.Parameters.AddWithValue("@ExpenseId", expenseId);
                        SqlDataAdapter sqlSda = new SqlDataAdapter(sqlCmd);
                        sqlSda.Fill(dtData);
                        return dtData;
                    }
                case EnumCRUD.SelectAll:
                    {
                        DataTable dtData = new DataTable();
                        var sqlCmd = new SqlCommand("spSplit", conn)
                        {
                            CommandType = CommandType.StoredProcedure
                        };

                        sqlCmd.Parameters.AddWithValue("@ActionType", "FetchAll");
                        SqlDataAdapter sqlSda = new SqlDataAdapter(sqlCmd);
                        sqlSda.Fill(dtData);
                        return dtData;
                    }
            }

            return null;
        }
    }
}
