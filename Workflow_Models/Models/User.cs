using System.ComponentModel.DataAnnotations;
using Workflow_Models.Models;

namespace Workflow_Models
{
    public class User:BaseClassId
    {
        [Required]
        public string Email { get; set; }

        [Display(Name = "First Name")]
        [Required]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [Required]
        public string LastName { get; set; }

        [Required]
        public string Password { get; set; }
    }
}