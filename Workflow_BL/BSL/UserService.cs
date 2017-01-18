using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workflow_BL.BSL;
using Workflow_BL.DAL;
using Workflow_Models;
using Workflow_Models.Models;

namespace Workflow_BL.BL
{
    public class UserService
    {
        private static DatabaseConfiguration context;

        public UserService(DatabaseConfiguration context)
        {
            UserService.context = context;
        }

        public static IEnumerable<User> GetAllUsers()
        {
            return new UserRepository(context).GetAllUsers();
        }

        public static void AddUser(User user)
        {
            new UserRepository(context).AddUser(user);
        }

        public static void AddUserLog(Date date, int iD, Permission permission, User user)
        {
            var log = new UserLog
            {
                Date = date,
                User = user,
                UserId = iD,
                UserType = permission
            };
            new UserLogRepository(context).AddLog(log);
        }
    }
}
