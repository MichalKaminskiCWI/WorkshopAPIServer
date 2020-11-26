using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using WorkshopAPIServer.Models;

namespace WorkshopAPIServer.Services
{
    public class MongoRepository<TDocument> : IMongoRepository<TDocument> where TDocument : IDocument
    {
        private readonly IMongoCollection<TDocument> _collection;

        public MongoRepository(IMongoDbSettings settings)
        {
            var database = new MongoClient(settings.ConnectionString).GetDatabase(settings.DatabaseName);
            _collection = database.GetCollection<TDocument>(GetCollectionName(typeof(TDocument)));
        }

        private protected string GetCollectionName(Type documentType)
        {
            return ((BsonCollectionAttribute)documentType.GetCustomAttributes(
                    typeof(BsonCollectionAttribute),
                    true)
                .FirstOrDefault())?.CollectionName;
        }

        
        public List<TDocument> Get()
        {
            return _collection.Find(document => true).ToList();
        }

        public TDocument Get(string id)
        {
            return _collection.Find<TDocument>(document => document.Id == id).FirstOrDefault();
        }

        public TDocument Create(TDocument document)
        {
            _collection.InsertOne(document);
            return document;
        }

        public void Update(string id, TDocument documentIn) =>
            _collection.ReplaceOne(document => document.Id == id, documentIn);

        public void Remove(string id) =>
            _collection.DeleteOne(document => document.Id == id);



    }
}
