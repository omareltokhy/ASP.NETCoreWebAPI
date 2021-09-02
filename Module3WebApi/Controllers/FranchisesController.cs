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
using Module3WebApi.Model.DTOs.FranchiceDTO;
using Module3WebApi.Model.DTOs.MovieDTO;

namespace Module3WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]
    [ApiConventionType(typeof(DefaultApiConventions))]
    public class FranchisesController : ControllerBase
    {
        private readonly MoviesDbContext _context;
        private readonly IMapper _mapper;

        public FranchisesController(MoviesDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Franchises
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FranchiseReadDTO>>> GetFranchises()
        {
            return _mapper.Map<List<FranchiseReadDTO>>(await _context.Franchises.ToListAsync());
        }

        // GET: api/Franchises/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FranchiseReadDTO>> GetFranchise(int id)
        {
            var franchise = await _context.Franchises.FindAsync(id);

            if (franchise == null)
            {
                return NotFound();
            }

            return _mapper.Map<FranchiseReadDTO>(franchise);
        }

        [HttpGet("{id}/movie")]
        public async Task<ActionResult<IEnumerable<MovieReadDTO>>> GetMoviesInAFranchise(int id)
        {
            if (!FranchiseExists(id))
            {
                return NotFound();
            }

            Franchise moviesInFranchise = await _context.Franchises
                 .Include(c => c.Movies)
                 .FirstOrDefaultAsync(c => c.Id == id);

            return _mapper.Map<List<MovieReadDTO>>(moviesInFranchise.Movies);
        }

        [HttpGet("{id}/characters")]
        public async Task<ActionResult<IEnumerable<CharacterReadDTO>>> GetCharactersInAFranchise(int id)
        {
            if (!FranchiseExists(id))
            {
                return NotFound();
            }

            Franchise moviesInFranchise = await _context.Franchises
                 .Include(c => c.Movies)
                 .FirstOrDefaultAsync(c => c.Id == id);

            Movie charactersInFranchise = await _context.Movies
                 .Include(c => c.Characters)
                 .FirstOrDefaultAsync(c => c.Id == id);

            return _mapper.Map<List<CharacterReadDTO>>(charactersInFranchise.Characters);  
        }

        // PUT: api/Franchises/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFranchise(int id, FranchiseUpdateDTO franchise)
        {
            if (id != franchise.Id)
            {
                return BadRequest();
            }
            Franchise domainFranchise = _mapper.Map<Franchise>(franchise);
            _context.Entry(domainFranchise).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FranchiseExists(id))
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

        [HttpPut("{id}/updateMovies")]
        public async Task<IActionResult> UpdateFranchiseMovies(int id, List<int> movies)
        {
            if (!FranchiseExists(id))
            {
                return NotFound();
            }

            // May want to place this in a service - controller is getting bloated
            Franchise franchiseToUpdateMovies = await _context.Franchises
                .Include(c => c.Movies)
                .Where(c => c.Id == id)
                .FirstAsync();

            // Loop through certificates, try and assign to coach
            // Trying to see if there is a nicer way of doing this, dont like the multiple calls
            List<Movie> movs = new();
            foreach (int movId in movies)
            {
                Movie mov = await _context.Movies.FindAsync(movId);
                if (movs == null)
                    return BadRequest("Character doesnt exist!");
                movs.Add(mov);
            }
            franchiseToUpdateMovies.Movies = movs;

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

        // POST: api/Franchises
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Franchise>> PostFranchise(FranchiseCreateDTO dtoFranchise)
        {
            Franchise domainFranchise = _mapper.Map<Franchise>(dtoFranchise);
            _context.Franchises.Add(domainFranchise);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetFranchise", new { id = domainFranchise.Id }, dtoFranchise);
        }

        // DELETE: api/Franchises/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFranchise(int id)
        {
            var franchise = await _context.Franchises.FindAsync(id);
            if (franchise == null)
            {
                return NotFound();
            }

            _context.Franchises.Remove(franchise);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FranchiseExists(int id)
        {
            return _context.Franchises.Any(e => e.Id == id);
        }
    }
}
