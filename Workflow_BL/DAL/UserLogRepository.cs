using System.Linq;
using System;
using System.Collections.Generic;
using Workflow_BL.DAL;
using Workflow_Models;
using Workflow_Models.Models;

namespace Workflow_BL.BSL
{
    internal class UserLogRepository:GenericRepository<UserLog>
    {
        public UserLogRepository(DatabaseConfiguration context):base(context)
        {
            Entity = ((DatabaseConfiguration)context).UserLog;
        }

        public IList<UserLog> GetAllLogs()
        {
            return Entity.ToList();
        }

        public IList<UserLog> GetLogByUserAdmin()
        {
            return Entity.Where(x => x.UserType == Permission.Admin).ToList();
        }

        public IList<UserLog> GetLogByUserManager()
        {
            return Entity.Where(x => x.UserType == Permission.Manager).ToList();
        }

        public IList<UserLog> GetLogByUserContributor()
        {
            return Entity.Where(x => x.UserType == Permission.Contributor).ToList();
        }

        public IList<UserLog> GetLogByUserSimpleUser()
        {
            return Entity.Where(x => x.UserType == Permission.User).ToList();
        }

        internal IList<UserLog> GetLogByInterval(string start, string end)
        {
            return Entity.Where(x => x.Date.CompareTo(start.Reverse())>=0
                && x.Date.CompareTo(end.Reverse())<0).ToList();
        }
    }
}