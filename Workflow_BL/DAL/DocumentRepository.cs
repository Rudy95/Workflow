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
            Entity = ((DatabaseConfiguration)context).Document;
        }

        internal IList<Document> GetDocumentsByKeyword(string keyword)
        {
            return Entity.Where(x => x.MetaData.Keywords.Any(y=>y.Keywords == keyword)).ToList();
        }

        internal void AddDocument(Document document)
        {
            Entity.Add(document);
        }

        internal Document GetDocumentByName(string oldFileName)
        {
            return Entity.First(x=> x.FileName == oldFileName);
        }

        internal void DeleteDocument(string name)
        {
            Entity.Remove(GetDocumentByName(name));
        }
    }
}