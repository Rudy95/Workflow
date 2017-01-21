using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workflow_BL.DAL;
using Workflow_Models;
using Workflow_Models.Models;

namespace Workflow_BL.BSL
{
    public class ContributorService
    {
        private static DatabaseConfiguration context;
        private static DocumentRepository repo;
        private static MetadataRepository meta;
        private static StatusRepository stat;
        private static KeywordRepository key; 
        private static DateRepository date;

        public ContributorService(DatabaseConfiguration context)
        {
            ContributorService.context = context;
            repo = new DocumentRepository(ContributorService.context);

            meta = new MetadataRepository(context);
            stat = new StatusRepository(context);
            key = new KeywordRepository(context);
            date = new DateRepository(context);
        }

        public static IEnumerable<Document> GetDocumentByName(string fileName)
        {
            try
            {
                return repo.GetDocumentByName(fileName) ;
            }
            catch
            {
                throw new Exception();
            }
        }

        public static IEnumerable<Document> GetAllDocuments()
        {
            var all = repo.GetAllDocuments();

            foreach (var item in all)
            {
                item.MetaData = meta.Read(item.MetaDataId);
                item.Status = stat.Read(item.StatusId);
            }
            return all;
        }

        public static void ModifyDocument(string fileName, MetaData metaData, string path)
        {
            var docs = repo.GetDocumentByName(fileName);
            foreach (var item in docs)
            {
                item.MetaData = meta.Read(item.MetaDataId);
                item.Status = stat.Read(item.StatusId);
            }
            double dd = docs.Max(x => x.Status.VersionType);
            Document doc = repo.GetDocumentByName(fileName)
                .Single(x=>x.Status.VersionType == dd);
            doc.MetaData = metaData;
            if(doc.Status.Stat == DocumentStatus.DRAFT)
                doc.Status.VersionType += 0.1;
            else if (doc.Status.Stat == DocumentStatus.FINAL)
                doc.Status.VersionType += 1.0;
            doc.Path = path;

            repo.AddDocument(doc);
        }

        public static IList<Document> GetAllDocumentsByUser(string name)
        {
            return GetAllDocuments().Where(x=>x.MetaData.UserEmail == name).ToList();
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
                Path = path
            };
            repo.AddDocument(doc);
        }

        public static void DeleteDocument(int id)
        {
            repo.DeleteDocument(id);
        }

        public static void DocumentToFinal(int id)
        {
            var doc = repo.GetDocumentByID(id);
            doc.MetaData = meta.Read(doc.MetaDataId);
            doc.MetaData.Keywords = key.GetAllKeywords().Where(x=>x.MetaDataID == doc.MetaDataId).ToList();
            doc.Status = stat.Read(doc.StatusId);
            doc.Status.Stat = DocumentStatus.FINAL;
            doc.Status.VersionType = 1.0;
            repo.AddDocument(doc);
        }
    }
}
