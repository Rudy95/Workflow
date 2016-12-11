using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workflow_Models.Models
{
    public abstract class BaseClassId
    {
        [Required]
        public int ID { get; set; }
    }
}
