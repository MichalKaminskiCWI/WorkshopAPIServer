using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WorkshopAPIServer.Models
{
    public abstract class Document: IDocument
    {
       [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

    }
}
