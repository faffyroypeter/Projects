using SET.BusinessEntity;
using System;
using System.Data;
using System.Data.SqlClient;

namespace SET.DataAccess
{
    public class clsGroupDataAccess
    {
        public int AffectGroup(clsGroup group, EnumCRUD crudOperationType)
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
                        var sqlCmd = new SqlCommand("spGroup", conn)
                        {
                            CommandType = CommandType.StoredProcedure
                        };

                        sqlCmd.Parameters.AddWithValue("@ActionType", "SaveData");
                        sqlCmd.Parameters.AddWithValue("@GroupId", group.GroupId);
                        sqlCmd.Parameters.AddWithValue("@GroupName", group.GroupName);
                        
                        return sqlCmd.ExecuteNonQuery();
                    }
                case EnumCRUD.Delete:
                    {
                        var sqlCmd = new SqlCommand("spGroup", conn);
                        sqlCmd.CommandType = CommandType.StoredProcedure;
                        sqlCmd.Parameters.AddWithValue("@ActionType", "DeleteData");
                        sqlCmd.Parameters.AddWithValue("@GroupId", group.GroupId);
                        return sqlCmd.ExecuteNonQuery();
                    }
            }

            return 0;
        }

        // Fetch mapped users for a group
        public DataTable ReadGroupUsers(int groupId)
        {
            var conn = Database.Instance.objSqlConnection;

            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }

            DataTable dtData = new DataTable();
            var sqlCmd = new SqlCommand("spGroupUsers", conn)
            {
                CommandType = CommandType.StoredProcedure
            };

            sqlCmd.Parameters.AddWithValue("@ActionType", "ReadGroupUsers");
            sqlCmd.Parameters.AddWithValue("@GroupId", groupId);
            SqlDataAdapter sqlSda = new SqlDataAdapter(sqlCmd);
            sqlSda.Fill(dtData);
            return dtData;
        }

        // Fetch Non mapped users for a group
        public DataTable FetchNonMappedUsersForGroup(int groupId)
        {
            var conn = Database.Instance.objSqlConnection;

            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }

            DataTable dtData = new DataTable();
            var sqlCmd = new SqlCommand("spGroupUsers", conn)
            {
                CommandType = CommandType.StoredProcedure
            };

            sqlCmd.Parameters.AddWithValue("@ActionType", "FetchNonMappedUsers");
            sqlCmd.Parameters.AddWithValue("@GroupId", groupId);
            SqlDataAdapter sqlSda = new SqlDataAdapter(sqlCmd);
            sqlSda.Fill(dtData);
            return dtData;
        }

        // Remove unmapped users for a group
        // Add new users mapped for a group
        public int UpdateGroupUsers(int groupId,string addUsersId,string removeUsersId)
        {
            var conn = Database.Instance.objSqlConnection;

            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }

            DataTable dtData = new DataTable();
            var sqlCmd = new SqlCommand("spGroupUsers", conn)
            {
                CommandType = CommandType.StoredProcedure
            };

            sqlCmd.Parameters.AddWithValue("@ActionType", "UpdateGroupUsers");
            sqlCmd.Parameters.AddWithValue("@GroupId", groupId);
            sqlCmd.Parameters.AddWithValue("@AddUsersId", addUsersId);
            sqlCmd.Parameters.AddWithValue("@RemoveUsersId", removeUsersId);
            
            return sqlCmd.ExecuteNonQuery();
        }

        public DataTable ReadGroup(EnumCRUD crudOperationType,int groupId = 0)
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
                        var sqlCmd = new SqlCommand("spGroup", conn)
                        {
                            CommandType = CommandType.StoredProcedure
                        };

                        sqlCmd.Parameters.AddWithValue("@GroupId", groupId);
                        SqlDataAdapter sqlSda = new SqlDataAdapter(sqlCmd);
                        sqlSda.Fill(dtData);
                        return dtData;
                    }
                case EnumCRUD.SelectAll:
                    {
                        DataTable dtData = new DataTable();
                        var sqlCmd = new SqlCommand("spGroup", conn)
                        {
                            CommandType = CommandType.StoredProcedure
                        };

                        sqlCmd.Parameters.AddWithValue("@ActionType", "FetchData");
                        SqlDataAdapter sqlSda = new SqlDataAdapter(sqlCmd);
                        sqlSda.Fill(dtData);
                        return dtData;
                    }
                case EnumCRUD.FetchGroupMapping:
                    {
                        DataTable dtData = new DataTable();
                        var sqlCmd = new SqlCommand("spGroup", conn)
                        {
                            CommandType = CommandType.StoredProcedure
                        };

                        sqlCmd.Parameters.AddWithValue("@ActionType", "FetchGroupMapping");
                        //sqlCmd.Parameters.AddWithValue("@ActionType", "FetchData");
                        SqlDataAdapter sqlSda = new SqlDataAdapter(sqlCmd);
                        sqlSda.Fill(dtData);
                        return dtData;
                    }
            }

            return null;
        }
    }
}
