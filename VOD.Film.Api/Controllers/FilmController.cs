using Microsoft.AspNetCore.Mvc;
using VOD.Film.Common.DTOs;
using VOD.Film.Common.Parameters;
using VOD.Film.Data.Entities.Models;
using VOD.Film.Data.Services;

namespace VOD.Film.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilmController : ControllerBase
    {
        private readonly IMovieService _dbService;

        public FilmController(IMovieService dbService) =>
              _dbService = dbService;


        [HttpGet]
        public async Task<IResult> GetFilmsAsync([FromQuery] FilmParameter filmParameter)
        {
            var films = await _dbService.GetAllAsync<FilmModel, FilmDTO>();

            if (filmParameter.GetByGenre)
            {
                var moviesByGenre = films
                .SelectMany(film => film.FilmGenres!
                .Select(genre => new { Genre = genre, Film = film }))
                .GroupBy(x => x.Genre.Name)
                .ToDictionary(group => group.Key, group => group
                .Select(x => x.Film)
                .ToList());
                return Results.Ok(moviesByGenre);
            }
            if (filmParameter.GetByDirector)
            {
                var moviesByDirector = films.Select(film =>
                    new { film, film.Director })
                    .GroupBy(x => x.Director!.Name)
                    .ToDictionary(group => group.Key, group => group.Select(x => x.film))
                    .ToList();
                return Results.Ok(moviesByDirector);
            }

            else if (filmParameter.IncludeAll)
            {
                var filmsWithInclude = await _dbService.GetWithIncludeAsync<FilmModel, FilmDTO>(
                   "FilmGenres.Genre",
                   "Director",
                   "SimilarFilms.SimilarFilm");
                return Results.Ok(filmsWithInclude);
            }
            var filmAsNoTracking = await _dbService.GetAllAsync<FilmModel, FilmDTO>(asNoTracking: true);

            return Results.Ok(filmAsNoTracking);
        }

        [HttpGet("GetAsRequestModel/{id}")]
        public async Task<IResult> GetFilmAsRequestModelAsync(int id)
        {
            var film = await _dbService.GetFirstWithIncludeAsync<FilmModel, FilmRequestDTO>(
           f => f.Id == id,
           "FilmGenres.Genre",
           "Director",
           "SimilarFilms.SimilarFilm");
            if (film == null) return Results.NotFound();
            return Results.Ok(film);
        }

        [HttpGet("{id}")]
        public async Task<IResult> GetFilmAsync(int id, [FromQuery] FilmParameter filmParameter)
        {
            if (filmParameter.IncludeAll)
            {
                var filmWithIncludes = await _dbService.GetFirstWithIncludeAsync<FilmModel, FilmDTO>(
                    f => f.Id == id,
                    "FilmGenres.Genre",
                    "Director",
                    "SimilarFilms.SimilarFilm");
                if (filmWithIncludes == null) return Results.NotFound();

                return Results.Ok(filmWithIncludes);
            }
            var film = await _dbService.GetByIdAsync<FilmModel, FilmDTO>(x => x.Id == id,
                asNoTracking: true);
            if (film == null) return Results.NotFound();

            return Results.Ok(film);

        }

        [HttpPost]
        public async Task<IResult> CreateFilmAsync([FromBody] FilmRequestDTO req)
        {
            var director = await _dbService.GetByIdAsync<Director, Director>(x => x.Id == req.DirectorId,
                asNoTracking: true);
            if (director == null) return Results.NotFound();

            var filmToCreate = new FilmModel
            {
                FilmGenres = new List<FilmGenre>(),
                SimilarFilms = new List<SimilarFilmModel>(),
                Director = director,
            };

            foreach (int genreId in req.GenreIds)
            {
                var genre = await _dbService.GetByIdAsync<Genre, FilmGenre>(x => x.Id == genreId,
                    asNoTracking: true);
                if (genre == null) return Results.BadRequest();
                filmToCreate.FilmGenres.Add(genre);
            }
            foreach (int similarFilmId in req.SimilarFilmsIds)
            {
                var similarFilm = await _dbService.GetByIdAsync<FilmModel, SimilarFilmModel>(x => x.Id == similarFilmId,
                    asNoTracking: true);
                if (similarFilm == null) return Results.BadRequest();
                filmToCreate.SimilarFilms.Add(similarFilm);
            }
            var result = await _dbService.CreateWithIncludesAsync<FilmRequestDTO, FilmModel, FilmDTO>(req, filmToCreate);
            if (result == null) return Results.BadRequest();

            var uri = _dbService.GetUri<FilmModel>(result.Id);
            return Results.Created(uri, result);
        }
        [HttpDelete("{id}"),]
        public async Task<IResult> DeleteFilmAsync([FromRoute] int id)
        {
            var deletedSuccessfully = await _dbService.DeleteAsync<FilmModel>(x => x.Id == id);
            if (!deletedSuccessfully) return Results.NotFound();
            return Results.NoContent();
        }
        [HttpPut("{id}")]
        public async Task<IResult> UpdateFilmAsync([FromRoute] int id, [FromBody] FilmRequestDTO req)
        {
            if (req.GenreIds.Length <= 0) return Results.BadRequest();

            var filmToUpdate = await _dbService.GetFirstWithIncludeAsync<FilmModel, FilmModel>(
                   f => f.Id == id,
                   "FilmGenres",
                   "Director",
                   "SimilarFilms");

            //Retrive and track Director entity from db
            var newDirector = await _dbService.GetByIdAsync<Director, Director>(d => d.Id == req.DirectorId);
            if (newDirector == null) return Results.NotFound();

            if (filmToUpdate == null) return Results.NotFound();
            filmToUpdate.FilmGenres = new List<FilmGenre>();
            filmToUpdate.SimilarFilms = new List<SimilarFilmModel>();


            foreach (var genreId in req.GenreIds)
            {
                var filmGenre = await _dbService.GetByIdAsync<Genre, FilmGenre>(x => x.Id == genreId,
                    asNoTracking: true);
                if (filmGenre == null) return Results.BadRequest();
                filmToUpdate.FilmGenres.Add(filmGenre);
            }

            foreach (int similarFilmId in req.SimilarFilmsIds)
            {
                //Entity instances become tracked when they are:
                //Returned from a query executed against the database
                //Explicitly attached to the DbContext by Add, Attach, Update, or similar methods
                //Detected as new entities connected to existing tracked entities
                var similarFilm = await _dbService.GetByIdAsync<FilmModel, SimilarFilmModel>(x => x.Id == similarFilmId,
                    asNoTracking: true);
                if (similarFilm == null) return Results.BadRequest();
                filmToUpdate.SimilarFilms.Add(similarFilm);
            }
            var result = _dbService.Update<FilmModel, FilmDTO, FilmRequestDTO>(filmToUpdate, req);
            return Results.Ok(result);
        }

    }
}
