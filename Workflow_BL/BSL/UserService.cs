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
        private static UserRepository repo;

        public UserService(DatabaseConfiguration context)
        {
            UserService.context = context;
            repo = new UserRepository(context);
        }

        public static IEnumerable<User> GetAllUsers()
        {
            return repo.GetAllUsers();
        }

        public static void AddUser(User user)
        {
            repo.AddUser(user);
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
