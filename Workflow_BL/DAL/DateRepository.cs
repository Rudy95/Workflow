using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workflow_Models;
using Workflow_Models.Models;

namespace Workflow_BL.DAL
{
    public class DateRepository:GenericRepository<Date>
    {
        public DateRepository(DatabaseConfiguration context) : base(context)
        {
            Entity = ((DatabaseConfiguration)context).Date;
        }
    }
}
