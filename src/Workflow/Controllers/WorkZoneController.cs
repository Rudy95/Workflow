using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Workflow_Models.Models;
using Workflow_BL.BSL;
using Workflow_BL.BL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using System.Security.Claims;
using System.Diagnostics;
using Workflow.Models;
using Microsoft.AspNetCore.Identity;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Workflow.Controllers
{
    public class WorkZoneController : Controller
    {
        private IHostingEnvironment _environment;
        private readonly UserManager<ApplicationUser> _manager;

        public WorkZoneController(IHostingEnvironment environment, UserManager<ApplicationUser> manager)
        {
            _environment = environment;
            _manager = manager;
        }

        private async Task<ApplicationUser> GetCurrentUser()
        {
            return await _manager.GetUserAsync(HttpContext.User);
        }

        // GET: /<controller>/
        public async Task<IActionResult> Index()
        {
            return View();
        }
        
        // TOdo : when a file is uploaded check if already exists in db
        //          if yes -> uploade else add
        [HttpPost]
        public async Task<IActionResult> AddFile(DocumentModel model)
        {
            if (ModelState.IsValid)
            {
                // adding the document to a specific path
                var upload = Path.Combine(_environment.WebRootPath, "documents");
                var newFileName = Guid.NewGuid().ToString();
                // the file will be stored with the name as guid.. the file name will be saved in db
                var path = Path.Combine(upload, newFileName);
                if (model.File.Length > 0)
                    using (var fileStream = new FileStream
                        (Path.Combine(upload, newFileName), FileMode.Create))
                    {
                        // !!! check if the file is store with the guid name
                        await model.File.CopyToAsync(fileStream);
                    }

                // keywords for metadata
                var keywordsArray = model.Keywords.Split(' ').ToList();
                List<Keyword> keywords = new List<Keyword>();
                for (int i = 0; i < keywordsArray.Count; i++)
                    keywords.Add(new Keyword {
                        Keywords = keywordsArray[i]
                    });

                var userId = await GetCurrentUser();

                var metadata = new MetaData
                {
                    Abstract = model.Abstract,
                    Keywords = keywords,
                    Created = new Date
                    {
                        Year = DateTime.Now.Year,
                        Month = DateTime.Now.Month,
                        Day = DateTime.Now.Day,
                        Hour = DateTime.Now.Hour,
                        Minute = DateTime.Now.Minute,
                        Second = DateTime.Now.Second
                    },
                    PersonId = int.Parse(userId.Id)
                };

                if (!object.Equals(ContributorService.GetDocumentByName(model.File.FileName), default(Document)))
                {
                    ContributorService.ModifyDocument(model.File.FileName, metadata, path);
                }
                else
                {
                    ContributorService.AddDocument(model.File.FileName, model.File.FileName.Split('.')[1],
                        metadata, path);
                }
            }

            return View();
        }

        [HttpPost]
        public IActionResult DeleteFile(int id)
        {
            ContributorService.DeleteDocument(id);
            return View();

        }

        [HttpPost]
        public IActionResult ChangeFileToFinal(int id)
        {
            ContributorService.DocumentToFinal(id);
            return View();
        }

        [Route("Work/reload")]
        [HttpPost]
        public IActionResult Reload()
        {
            return View();
        }
    }
}
