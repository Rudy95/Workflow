using System;
using System.Collections.Generic;
using System.Linq;
using Workflow_BL.DAL;
using Workflow_Models;
using Workflow_Models.Models;

namespace Workflow_BL.BSL
{
    internal class DocumentRepository:GenericRepository<Document>
    {

        public DocumentRepository(DatabaseConfiguration context):base(context)
        {
            Entity = (context).Document;
        }

        internal IList<Document> GetDocumentsByKeyword(string keyword)
        {
            return Entity.Where(x => x.MetaData.Keywords.Any(y=>y.Keywords == keyword)).ToList();
        }

        internal void AddDocument(Document document)
        {
            var a = Create(document);
            Context.Attach(a);
            Context.SaveChanges();
        }

        internal IEnumerable<Document> GetDocumentByName(string name)
        {
            return Entity.Where(x=> x.FileName == name);
        }

        internal void DeleteDocument(int iD)
        {
            Entity.Remove(GetDocumentByID(iD));
        }

        internal Document GetDocumentByID(int iD)
        {
            return Entity.First(x=>x.ID == iD);
        }

        internal IList<Document> GetAllDocuments()
        {
            return Entity.ToList();
        }

    }
}