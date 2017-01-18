using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workflow_Models;
using Workflow_Models.Models;

namespace Workflow_BL.BSL
{
    public class ContributorService
    {
        private static DatabaseConfiguration context;

        public ContributorService(DatabaseConfiguration context)
        {
            ContributorService.context = context;
        }

        public static void AddDocument(string fileName, MetaData meta)
        {
            
        }

        public static Document GetDocumentByName(string fileName)
        {
            try
            {
                return GetAllDocuments().Single(x=>x.FileName==fileName);
            }
            catch
            {
                throw new Exception();
            }
        }

        public static IEnumerable<Document> GetAllDocuments()
        {
            return new DocumentRepository(context).GetAllDocuments();
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

        public static void ModifyDocument(string fileName, string fileExtension, MetaData metaData, string path)
        {
            throw new NotImplementedException();
        }

        public static void AddDocument(string fileName, string fileExtension, MetaData metaData, string path)
        {
            Document doc = new Document {
                MetaData = metaData,
                FileName = fileName,
                FileExtension = fileExtension,
                Status = new Status
                {
                    Stat = DocumentStatus.DRAFT,
                    VersionType = 0.1
                },
            };
            new DocumentRepository(context)
                .AddDocument(doc);
        }
    }
}
