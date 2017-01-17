using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workflow_Models;
using Workflow_Models.Models;

namespace Workflow_BL.BSL
{
    class ContributorService
    {
        private static DatabaseConfiguration context;

        public ContributorService(DatabaseConfiguration context)
        {
            ContributorService.context = context;
        }

        public static void AddDocument(string fileName, MetaData meta)
        {
            Document doc = new Document();
            doc.MetaData = meta;
            doc.FileName = fileName;
            doc.Status = new Status();
            doc.Status.Stat = DocumentStatus.DRAFT;
            doc.Status.VersionType = 0.1;
            new DocumentRepository(context)
                .AddDocument(doc);
        }

        // TODO
        public static void ModifyDocument(
            int myProperty, string oldFileName,string newFileName, MetaData meta)
        {
            //var repo = new DocumentRepository(context);
            //Document doc = repo.GetDocumentByName(oldFileName);
            //doc.MyProperty = myProperty;
            //doc.MetaData = meta;
            //doc.FileName = newFileName;
            //doc.Status = new Status();
            //doc.Status.Stat = DocumentStatus.DRAFT;
            //doc.Status.VersionType += 0.1;
            //repo.AddDocument(doc);
        }

        public static void DeleteDocument(string name)
        {
            new DocumentRepository(context).DeleteDocument(name);
        }
    }
}
