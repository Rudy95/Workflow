﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workflow_Models;
using Workflow_Models.Models;

namespace Workflow_BL.DAL
{
    public class StatusRepository:GenericRepository<Status>
    {
        public StatusRepository(DatabaseConfiguration context) : base(context)
        {
            Entity = ((DatabaseConfiguration)context).Status;
        }
    }
}
