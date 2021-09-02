using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Module3WebApi.Model;
using Module3WebApi.Model.DTOs.MovieDTO;
using Module3WebApi.Services;

namespace Module3WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesV2Controller : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IMovieService _movieService;

        public MoviesV2Controller(IMapper mapper, IMovieService movieService)
        {
            _mapper = mapper;
            _movieService = movieService;
        }

        // GET: api/MoviesV2
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MovieReadDTO>>> GetMovies()
        {
            return _mapper.Map<List<MovieReadDTO>>(await _movieService.GetAllMoviesAsync());
        }

        // GET: api/MoviesV2/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MovieReadDTO>> GetMovie(int id)
        {
            Movie movie = await _movieService.GetSpecificMovieAsync(id);
            
            if (movie == null)
            {
                return NotFound();
            }
            return _mapper.Map<MovieReadDTO>(movie);
        }

        // PUT: api/MoviesV2/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMovie(int id, MovieUpdateDTO dtoMovie)
        {
            if (id != dtoMovie.Id)
            {
                return BadRequest();
            }

            if (!_movieService.MovieExists(id))
            {
                return NotFound();
            }

            Movie domainMovie = _mapper.Map<Movie>(dtoMovie);
            await _movieService.UpdateMovieAsync(domainMovie);

            return NoContent();
        }

        // POST: api/MoviesV2
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Movie>> PostMovie(MovieCreateDTO dtoMovie)
        {
            Movie domainMovie = _mapper.Map<Movie>(dtoMovie);
            domainMovie = await _movieService.AddMovieAsync(domainMovie);

            return CreatedAtAction("GetMovie", new { id = domainMovie.Id }, _mapper.Map<MovieReadDTO>(domainMovie));
        }

        // DELETE: api/MoviesV2/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMovie(int id)
        {
            if (!_movieService.MovieExists(id))
            {
                return NotFound();
            }
            await _movieService.DeleteMovieAsync(id);
            return NoContent();
        }
        // PUT: api/MoviesV2/characters
        [HttpPut("{id}/characters")]
        public async Task<IActionResult> UpdateMovieCharacters(int id, List<int> characters)
        {
            if (!_movieService.MovieExists(id))
            {
                return NotFound();
            }

            try
            {
                await _movieService.UpdateMovieCharactersAsync(id, characters);
            }
            catch (KeyNotFoundException)
            {
                return BadRequest("Invalid character.");
            }

            return NoContent();
        }

    }
}
