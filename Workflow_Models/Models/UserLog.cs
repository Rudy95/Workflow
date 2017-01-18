using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workflow_Models.Models
{
    public class UserLog:BaseClassId
    {
        [Required]
        public Date Date { get; set; }

        public int UserId { get; set; }

        public Permission UserType { get; set; }

        public User User { get; set; }
    }
}
