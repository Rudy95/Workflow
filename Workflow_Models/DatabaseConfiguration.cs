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

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);
        //    modelBuilder.Entity<User>()
        //        .Property(e=>e.Email);


        //    modelBuilder.Entity<User>()
        //        .Property(e => e.FirstName);


        //    modelBuilder.Entity<User>()
        //        .Property(e => e.LastName);


        //    modelBuilder.Entity<User>()
        //        .Property(e => e.Password);
        //}
    }
}
