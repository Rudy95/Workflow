using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workflow_Models.Models
{
    public class Document:BaseClassId
    {
        public int MyProperty { get; set; }

        public MetaData MetaData { get; set; }

        public Status Status{ get; set; }

    }
}
