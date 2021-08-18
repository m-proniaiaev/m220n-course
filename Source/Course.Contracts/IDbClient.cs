using System;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Course.Contracts
{
    public interface IDbClient
    {
        IMongoCollection<BsonDocument> GetMoviesCollection();
    }
}