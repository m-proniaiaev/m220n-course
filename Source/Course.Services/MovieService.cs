using System.Collections.Generic;
using Course.Contracts;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Course.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMongoCollection<BsonDocument> _movies;

        public MovieService(IDbClient client)
        {
            _movies = client.GetMoviesCollection();
        }

        public IEnumerable<BsonDocument> GetMoviesLabOne()
        {
            return _movies.Find(new BsonDocument())
                .SortByDescending(m => m["runtime"])
                .Limit(10)
                .ToList();
        }
    }
}