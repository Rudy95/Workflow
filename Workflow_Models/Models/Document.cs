using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workflow_Models.Models
{
    public class Document:BaseClassId
    {
        public MetaData MetaData { get; set; }

        public Status Status{ get; set; }

        public string FileName { get; set; }

        public string FileExtension { get; set; }
    }
}
