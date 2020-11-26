using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using WorkshopAPIServer.Models;

namespace WorkshopAPIServer.Services
{
    public interface IMongoRepository<TDocument> where TDocument : IDocument
    {       
        List<TDocument> Get();

        TDocument Get(string id);

        TDocument Create(TDocument document);

        void Update(string id, TDocument document);

        void Remove(string id);

    }
}
