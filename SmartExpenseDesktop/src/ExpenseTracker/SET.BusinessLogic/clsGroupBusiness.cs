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
    public class clsGroupBusiness
    {
        private clsGroupDataAccess objGroupDataAccess = new clsGroupDataAccess();

        public int SaveGroup(clsGroup objGroup)
        {
            return objGroupDataAccess.AffectGroup(objGroup, EnumCRUD.Create);
        }

        public DataTable FetchGroupRecord(int groupId)
        {
            return objGroupDataAccess.ReadGroup(EnumCRUD.Read, groupId);
        }

        public int DeleteGroup(int groupId)
        {
            return objGroupDataAccess.AffectGroup(new clsGroup() { GroupId= groupId }, EnumCRUD.Delete);
        }

        public DataTable FetchGroups()
        {
            return objGroupDataAccess.ReadGroup(EnumCRUD.SelectAll);
        }

        public DataTable FetchGroupUsers(int groupId)
        {
            return objGroupDataAccess.ReadGroupUsers(groupId);
        }

        public DataTable FetchNonMappedUsersForGroup(int groupId)
        {
            return objGroupDataAccess.FetchNonMappedUsersForGroup(groupId);
        }

        public DataTable FetchGroupUsersMapping()
        {
            return objGroupDataAccess.ReadGroup(EnumCRUD.FetchGroupMapping);
        }

        public int UpdateGroupUsers(int groupId, string addUsers, string removeUsers)
        {
            return objGroupDataAccess.UpdateGroupUsers(groupId,addUsers,removeUsers);
        }
    }
}
