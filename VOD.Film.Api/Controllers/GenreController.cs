using Microsoft.AspNetCore.Mvc;
using VOD.Film.Common.DTOs;
using VOD.Film.Data.Entities.Models;
using VOD.Film.Data.Services;

namespace VOD.Film.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenreController : ControllerBase
    {
        private readonly IMovieService _dbService;

        public GenreController(IMovieService movieService)
        {
            _dbService = movieService;
        }
        [HttpGet]
        public async Task<IResult> GetGenresAsync()
        {
            var genresDTO = await _dbService.GetAllAsync<Genre, GenreDTO>();
            if (genresDTO == null) return Results.NotFound();
            return Results.Ok(genresDTO);
        }
        //[HttpGet("{id}")]
        //public async Task<IResult> GetGenreAsync(int id)
        //{
        //    var genreDTO = await _dbService.GetByIdAsync<Genre, GenreDTO>(x => x.Id == id, asNoTracking: true);
        //    if (genreDTO == null) return Results.NotFound();
        //    return Results.Ok(genreDTO);
        //}

    }
}
