using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;
using System.Data.SqlClient;

namespace SET.DataAccess
{
    public class Database
    {
        private static string dbConnString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SmartExpenseTracker;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        private static Database instanceObj = null;

        public SqlConnection objSqlConnection = null;

        public Database()
        {
            if(objSqlConnection == null)
            {
                objSqlConnection = new SqlConnection(dbConnString);
                objSqlConnection.Open();
            }
        }

        public static Database Instance
        {
            get 
            {
                if(instanceObj == null)
                {
                    instanceObj = new Database();
                }

                return instanceObj;
            }
        }
                     
    }
}
