using System.Collections.Generic;

namespace Workflow_Models.Models
{
    public class MetaData:BaseClassId
    {
        public string Abstract { get; set; }

        public string UserEmail { get; set; }

        public Date Created { get; set; }

        public int CreatedId { get; set; }

        public List<Keyword> Keywords { get; set; }
    }
}