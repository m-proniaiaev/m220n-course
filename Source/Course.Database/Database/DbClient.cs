using System;
using Course.Contracts;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Store.Core.Database.Database
{
    public class DbClient : IDbClient
    {
        private readonly IMongoCollection<BsonDocument> _movies;

        public DbClient(IOptions<DbConfig> recordDbConfig)
        {
            if (recordDbConfig == null)
                throw new Exception("Can't configure MongoDb!");
            
            var client = new MongoClient(recordDbConfig.Value.ConnectionString);
            var db = client.GetDatabase(recordDbConfig.Value.DbName ?? "sample_mflix");
            
            if (db is null)
                throw new InvalidOperationException("Can't connect to db!");
            
            _movies = db.GetCollection<BsonDocument>("movies");
            
        }

        public IMongoCollection<BsonDocument> GetMoviesCollection()
        {
            return _movies;
        }
    }
}