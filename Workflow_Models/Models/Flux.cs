using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workflow_Models.Models
{
    public class Flux:BaseClassId
    {
        public List<Document> Documents { get; set; }

        public List<Department> Departments { get; set; }
    }
}
