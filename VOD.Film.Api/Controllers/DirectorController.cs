using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using VOD.Film.Common.DTOs;
using VOD.Film.Data.Entities.Models;
using VOD.Film.Data.Services;

namespace VOD.Film.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DirectorController : ControllerBase
    {
        private readonly IMovieService _dbService;
        private readonly IMapper _mapper;

        public DirectorController(IMovieService dbService, IMapper mapper)
        {
            _dbService = dbService;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IResult> GetDirectorsAsync()
        {
            var res = await _dbService.GetAllAsync<Director, DirectorDTO>();
            return Results.Ok(res);
        }
        [HttpGet("{id}")]
        public async Task<IResult> GetDirectorByIdAsync(int id)
        {
            var director = await _dbService.GetByIdAsync<Director, DirectorDTO>(x => x.Id == id,
                asNoTracking: true);

            if (director == null) return Results.NotFound();
            return Results.Ok(director);
        }
        [HttpPost]
        public async Task<IResult> CreateDirectorAsync(DirectorRequestDTO req)
        {
            var result = await _dbService.CreateAsync<Director, DirectorDTO, DirectorRequestDTO>(req);
            return Results.Ok(result);
        }
        [HttpPut("{id}")]
        public async Task<IResult> UpdateDirectorAsync(int id, DirectorRequestDTO req)
        {
            var directorToUpdate = await _dbService.GetByIdAsync<Director, Director>(x => x.Id == id, asNoTracking: true);
            if (directorToUpdate == null) return Results.NotFound();
            try
            {
                var updatedDirector = _mapper.Map(req, directorToUpdate);
                var result = _dbService.Update<Director, DirectorDTO, DirectorRequestDTO>(directorToUpdate, req);
                return Results.Ok(result);
            }
            catch
            {
                return Results.StatusCode(500);
            }
        }
        [HttpDelete("{id}")]
        public async Task<IResult> DeleteDirectorAsync(int id)
        {
            var directorToDelete = await _dbService.DeleteAsync<Director>(x => x.Id == id);
            if (directorToDelete == false) return Results.NotFound();
            return Results.NoContent();
        }
    }
}
