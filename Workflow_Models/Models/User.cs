using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Workflow_Models.Models;

namespace Workflow_Models.Models
{
    public class User:BaseClassId
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Display(Name = "First Name")]
        [Required]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [Required]
        public string LastName { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Required]
        public Permission Permission { get; set; }

        public List<UserLog> Logs { get; set; }
    }
}