using System.Collections.Generic;
using MongoDB.Bson;

namespace Course.Contracts
{
    public interface IMovieService
    {
        public IEnumerable<BsonDocument> GetMoviesLabOne();
    }
}