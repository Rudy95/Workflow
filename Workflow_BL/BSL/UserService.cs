using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workflow_BL.DAL;
using Workflow_Models;

namespace Workflow_BL.BL
{
    public class UserService
    {
        public static IEnumerable<User> GetAllUsers(DatabaseConfiguration context)
        {
            return new UserRepository(context).GetAllUsers();
        }

        public static void AddUser(DatabaseConfiguration context,User user)
        {
            new UserRepository(context).AddUser(user);
        }
    }
}
