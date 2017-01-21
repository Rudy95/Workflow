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
using Workflow_Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Workflow.Controllers
{
    public class WorkZoneController : Controller
    {
        private IHostingEnvironment _environment;
        private readonly UserManager<ApplicationUser> _manager;
        private DatabaseConfiguration _context;

        public WorkZoneController(IHostingEnvironment environment, UserManager<ApplicationUser> manager, DatabaseConfiguration context)
        {
            _environment = environment;
            _manager = manager;
            _context = context;
            new ContributorService(_context);
        }

        private async Task<ApplicationUser> GetCurrentUser()
        {
            return await _manager.GetUserAsync(HttpContext.User);
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            var model = ContributorService
                .GetAllDocumentsByUser(User.Identity.Name);

            return View(model.ToList());
        }
        
        // TOdo : when a file is uploaded check if already exists in db
        //          if yes -> uploade else add
        [HttpPost]
        [Route("Work/addFile")]
        public async Task<IActionResult> AddFile(ICollection<IFormFile> files, string abs, string key)
        {
            IFormFile file = files.ElementAt(0);
            if (ModelState.IsValid)
            {
                // adding the document to a specific path
                var upload = Path.Combine(_environment.WebRootPath, "documents");
                var newFileName = Guid.NewGuid().ToString()+".pdf";
                // the file will be stored with the name as guid.. the file name will be saved in db
                var path = Path.Combine(upload, newFileName);
                if (file.Length > 0)
                    using (var fileStream = new FileStream
                        (Path.Combine(upload, newFileName), FileMode.Create))
                    {
                        await file.CopyToAsync(fileStream);
                    }

                // keywords for metadata
                var keywordsArray = key.Split(' ').ToList();
                List<Keyword> keywords = new List<Keyword>();
                for (int i = 0; i < keywordsArray.Count; i++)
                    keywords.Add(new Keyword {
                        Keywords = keywordsArray[i]
                    });

                var userId = await GetCurrentUser();

                var metadata = new MetaData
                {
                    Abstract = abs,
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
                    UserEmail = userId.Email,
                };

                if (ContributorService.GetDocumentByName(file.FileName).Count()!=0)
                {
                    ContributorService.ModifyDocument(file.FileName, metadata, path);
                }
                else
                {
                    ContributorService.AddDocument(file.FileName, file.FileName.Split('.')[1],
                        metadata, path);
                }
            }

            return RedirectToAction("Index");
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
