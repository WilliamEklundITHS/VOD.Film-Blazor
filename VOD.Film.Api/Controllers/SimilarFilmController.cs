using Microsoft.AspNetCore.Mvc;
using VOD.Film.Common.DTOs;
using VOD.Film.Data.Entities.Models;
using VOD.Film.Data.Services;

namespace VOD.Film.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SimilarFilmController : ControllerBase
    {
        private readonly IMovieService _dbService;
        public SimilarFilmController(IMovieService movieService)
        {
            _dbService = movieService;
        }
        [HttpDelete("{parentFilmId:int}"),]
        public async Task<IResult> DeleteSimilarFilmAsync([FromRoute] int parentFilmId, [FromBody] int[] similarFilmIds)
        {
            var parentFilm = await _dbService.GetByIdAsync<SimilarFilmModel, SimilarFilmDTO>(x => x.ParentFilmId == parentFilmId, asNoTracking: true);
            foreach (int similarFilmId in similarFilmIds)
            {
                var similarFilmToRemove = await _dbService.DeleteManyAsync<SimilarFilmModel>(
                    y => y.ParentFilmId == parentFilmId,
                    x => x.SimilarFilmId == similarFilmId
                    );
            }
            return Results.NoContent();
        }
    }
}
