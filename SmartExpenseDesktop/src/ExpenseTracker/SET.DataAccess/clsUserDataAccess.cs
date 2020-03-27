using SET.BusinessEntity;
using System.Data;
using System.Data.SqlClient;

namespace SET.DataAccess
{
    public class clsUserDataAccess
    {
        public int AffectUser(clsUser user, EnumCRUD crudOperationType)
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
                        var sqlCmd = new SqlCommand("spUser", conn)
                        {
                            CommandType = CommandType.StoredProcedure
                        };

                        sqlCmd.Parameters.AddWithValue("@ActionType", "SaveData");
                        sqlCmd.Parameters.AddWithValue("@UserId", user.UserId);
                        sqlCmd.Parameters.AddWithValue("@Name", user.Name);
                        sqlCmd.Parameters.AddWithValue("@UserName", user.UserName);
                        sqlCmd.Parameters.AddWithValue("@Email", user.Email);
                        sqlCmd.Parameters.AddWithValue("@Password", user.Password);

                        return sqlCmd.ExecuteNonQuery();
                    }
                case EnumCRUD.Delete:
                    {
                        var sqlCmd = new SqlCommand("spUser", conn);
                        sqlCmd.CommandType = CommandType.StoredProcedure;
                        sqlCmd.Parameters.AddWithValue("@ActionType", "DeleteData");
                        sqlCmd.Parameters.AddWithValue("@UserId", user.UserId);
                        return sqlCmd.ExecuteNonQuery();
                    }
            }

            return 0;
        }

        public DataTable ReadUser(EnumCRUD crudOperationType,int userId = 0)
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
                        var sqlCmd = new SqlCommand("spUser", conn)
                        {
                            CommandType = CommandType.StoredProcedure
                        };

                        sqlCmd.Parameters.AddWithValue("@ActionType", "FetchRecord");
                        sqlCmd.Parameters.AddWithValue("@UserId", userId);
                        SqlDataAdapter sqlSda = new SqlDataAdapter(sqlCmd);
                        sqlSda.Fill(dtData);
                        return dtData;
                    }
                case EnumCRUD.SelectAll:
                    {
                        DataTable dtData = new DataTable();
                        var sqlCmd = new SqlCommand("spUser", conn)
                        {
                            CommandType = CommandType.StoredProcedure
                        };

                        sqlCmd.Parameters.AddWithValue("@ActionType", "FetchData");
                        SqlDataAdapter sqlSda = new SqlDataAdapter(sqlCmd);
                        sqlSda.Fill(dtData);
                        return dtData;
                    }
            }

            return null;
        }
    }
}
