using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Module3WebApi.Model;
using Module3WebApi.Model.DTOs.CharacterDTO;
using Module3WebApi.Model.DTOs.MovieDTO;

namespace Module3WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]
    [ApiConventionType(typeof(DefaultApiConventions))]
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

        [HttpGet("{id}/character")]
        public async Task<ActionResult<IEnumerable<CharacterReadDTO>>> GetCharactersInAMovie(int id)
        {
            if (!MovieExists(id))
            {
                return NotFound();
            }

            Movie charactersInMovie = await _context.Movies
                 .Include(c => c.Characters)
                 .FirstOrDefaultAsync(c => c.Id == id);

            return _mapper.Map<List<CharacterReadDTO>>(charactersInMovie.Characters);
        }

        // PUT: api/Movies/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMovie(int id, MovieUpdateDTO dtoMovie)
        {
            if (id != dtoMovie.Id)
            {
                return BadRequest();
            }
            Movie domainMovie = _mapper.Map<Movie>(dtoMovie);
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

        
        [HttpPut("{id}/updateCharacters")]
        public async Task<IActionResult> UpdateMovieCharacters(int id, List<int> characters)
        {
            if (!MovieExists(id))
            {
                return NotFound();
            }

            // May want to place this in a service - controller is getting bloated
            Movie movieToUpdateCharacters = await _context.Movies
                .Include(c => c.Characters)
                .Where(c => c.Id == id)
                .FirstAsync();

            // Loop through certificates, try and assign to coach
            // Trying to see if there is a nicer way of doing this, dont like the multiple calls
            List<Character> chars = new();
            foreach (int charId in characters)
            {
                Character charctr = await _context.Characters.FindAsync(charId);
                if (chars == null)
                    return BadRequest("Character doesnt exist!");
                chars.Add(charctr);
            }
            movieToUpdateCharacters.Characters = chars;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return NoContent();
        }

            // POST: api/Movies
            // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Movie>> PostMovie(MovieCreateDTO dtoMovie)
        {
            Movie domainMovie = _mapper.Map<Movie>(dtoMovie);
            _context.Movies.Add(domainMovie);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCoach",
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
