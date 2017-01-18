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

        internal void AddLog(UserLog log)
        {
            Create(log);
            Context.SaveChanges();
        }

        internal IList<UserLog> GetLogByInterval(Date start, Date end)
        {
            return Entity.Where(x => x.Date.Year > start.Year 
                && x.Date.Month > start.Month
                && x.Date.Hour > start.Hour
                && x.Date.Minute > start.Minute
                && x.Date.Second > start.Second
                && x.Date.Year < end.Year
                && x.Date.Month < start.Month
                && x.Date.Hour < start.Hour
                && x.Date.Minute < start.Minute
                && x.Date.Second < start.Second
                ).ToList();
        }
    }
}