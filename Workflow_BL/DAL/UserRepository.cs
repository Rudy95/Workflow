using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workflow_Models;
using Workflow_Models.Models;

namespace Workflow_BL.DAL
{
    public class UserRepository : GenericRepository<User>
    {

        public UserRepository(DatabaseConfiguration context) : base(context)
        {
            Entity = ((DatabaseConfiguration)context).User;
        }

        public User GetUser(int id)
        {
            try
            {
                return Read(id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IList<User> GetAllUsers()
        {
            return Entity.ToList();
        }

        public void AddUser(User user)
        {
            Create(user);
            Context.SaveChanges();
        }
    }
}
