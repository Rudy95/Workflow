using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workflow_Models;
using Workflow_Models.Models;

namespace Workflow_Models
{
    public class DatabaseConfiguration:DbContext
    {
        public DatabaseConfiguration(DbContextOptions<DatabaseConfiguration> options)
            :base(options)
            {}

        public virtual DbSet<User> User { get; set; }

        public virtual DbSet<UserLog> UserLog { get; set; }

        public virtual DbSet<Document> Document{ get; set; }

        public virtual DbSet<MetaData> Metadata { get; set; }

        public virtual DbSet<Keyword> Keyword { get; set; }

        public virtual DbSet<Status> Status { get; set; }

        public virtual DbSet<Flux> Flux { get; set; }

        public virtual DbSet<Department> Department { get; set; }

        public virtual DbSet<Date> Date { get; set; }

    }
}
