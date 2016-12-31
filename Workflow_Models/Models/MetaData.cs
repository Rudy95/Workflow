using System.Collections.Generic;

namespace Workflow_Models.Models
{
    public class MetaData:BaseClassId
    {
        public string Abstract { get; set; }

        public int PersonId { get; set; }

        public string Created { get; set; }

        public List<Keyword> Keywords { get; set; }

        public double Version { get; set; }
    }
}