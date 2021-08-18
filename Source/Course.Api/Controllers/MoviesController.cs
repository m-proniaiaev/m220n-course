using System.Collections.Generic;
using System.Linq;
using Course.Contracts;
using Course.Services;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;
using Store.Core.Database.Database;

namespace M220N.mongo.course.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MoviesController : Controller
    {
        private readonly IMovieService _movies;

        public MoviesController(IMovieService movies)
        {
            _movies = movies;
        }

        [HttpGet]
        public IActionResult GetMovies()
        {
            var result = _movies.GetMoviesLabOne();
            var model = result.Select(bsonDocument => bsonDocument.GetValue("title").ToString()).ToList();

            return Ok(model);
        }
    }
}