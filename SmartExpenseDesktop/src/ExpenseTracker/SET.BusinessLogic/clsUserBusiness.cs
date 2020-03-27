using SET.BusinessEntity;
using SET.DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SET.BusinessLogic
{
    public class clsUserBusiness
    {
        private clsUserDataAccess objUserDataAccess = new clsUserDataAccess();

        public int SaveUser(clsUser objUser)
        {
            return objUserDataAccess.AffectUser(objUser, EnumCRUD.Create);
        }

        public int DeleteUser(int userId)
        {
            return objUserDataAccess.AffectUser(new clsUser() { UserId = userId }, EnumCRUD.Delete);
        }

        public DataTable FetchUsers()
        {
            return objUserDataAccess.ReadUser(EnumCRUD.SelectAll);
        }

        public DataTable FetchUserRecord(int userId)
        {
            return objUserDataAccess.ReadUser(EnumCRUD.Read, userId);
        }
    }
}
