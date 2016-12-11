using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workflow_BL.DAL
{
    interface IRepository<T>
    {
        T Create(T entity);

        T Read(int id);

        T Update(T entity);

        void Delete(T entity);
    }
}
