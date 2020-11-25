﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WorkshopAPIServer.Models
{

    public class MongoDbSettings : IMongoDbSettings
        {
            public string DatabaseName { get; set; }
            public string ConnectionString { get; set; }
        }
    public interface IMongoDbSettings
        {
            string DatabaseName { get; set; }
            string ConnectionString { get; set; }
        }

        
 
}
