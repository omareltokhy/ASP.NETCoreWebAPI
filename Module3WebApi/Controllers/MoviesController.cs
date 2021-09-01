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

namespace Module3WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly MoviesDbContext _context;
        private readonly IMapper _mapper;

        public MoviesController(MoviesDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Movies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MovieReadDTO>>> GetMovies()
        {
            return _mapper.Map<List<MovieReadDTO>>(await _context.Movies
                .Include(c => c.Characters)
                .Include(c => c.Franchise)
                .ToListAsync());
        }

        // GET: api/Movie/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MovieReadDTO>> GetMovie(int id)
        {
            Movie movie = await _context.Movies.FindAsync(id);

            if (movie == null)
            {
                return NotFound();
            }

            return _mapper.Map<MovieReadDTO>(movie);
        }
    
        // PUT: api/Movies/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMovie(int id, MovieUpdateDTO movie)
        {
            if (id != movie.Id)
            {
                return BadRequest();
            }
            Movie domainMovie = _mapper.Map<Movie>(movie);
            _context.Entry(domainMovie).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MovieExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }
        
        // POST: api/Movies
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Movie>> PostMovie(MovieCreateDTO movie)
        {
            Movie domainMovie = _mapper.Map<Movie>(movie);
            _context.Movies.Add(domainMovie);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMovie",
                new { id = domainMovie.Id },
                _mapper.Map<MovieReadDTO>(domainMovie));
        }

        // DELETE: api/Movies/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMovie(int id)
        {
            var movie = await _context.Movies.FindAsync(id);
            if (movie == null)
            {
                return NotFound();
            }

            _context.Movies.Remove(movie);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MovieExists(int id)
        {
            return _context.Movies.Any(e => e.Id == id);
        }
    }
}
