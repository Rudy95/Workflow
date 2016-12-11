using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workflow_Models;
using Workflow_Models.Models;

namespace Workflow_BL.DAL
{
    public class GenericRepository<T>:IRepository<T> where T:BaseClassId
    {
        protected readonly DbContext Context;

        public DbSet<T> Entity { get; set; }

        public GenericRepository(DatabaseConfiguration context)
        {
            this.Context = context;
        }

        public T Create(T entity)
        {
            return Entity.Add(entity).Entity;
        }

        public void Delete(T entity)
        {
            Entity.Remove(entity);
        }

        public T Read(int id)
        {
            //return null;
            return Entity.FirstOrDefault(x=>x.ID == id);
        }

        public T Update(T entity)
        {
            return Entity.Attach(entity).Entity;
        }
    }
}
