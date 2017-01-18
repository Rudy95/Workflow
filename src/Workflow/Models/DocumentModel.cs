using Microsoft.AspNetCore.Http;
using Workflow_Models.Models;

namespace Workflow.Controllers
{
    public class DocumentModel
    {
        public IFormFile File{ get; set; }

        public string Abstract{ get; set; }

        public string Keywords { get; set; }
    }
}