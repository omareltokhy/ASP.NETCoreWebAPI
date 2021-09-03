using Microsoft.EntityFrameworkCore;
using Module3WebApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Module3WebApi.Services
{
    public class FranchiseService : IFranchiseService
    {
        private readonly MoviesDbContext _context;
        public FranchiseService(MoviesDbContext context)
        {
            _context = context;
        }
        public async Task<Franchise> AddFranchiseAsync(Franchise franchise)
        {
            _context.Franchises.Add(franchise);
            await _context.SaveChangesAsync();
            return franchise;
        }

        public async Task DeleteFranchiseAsync(int id)
        {
            var franchise = await _context.Franchises.FindAsync(id);
            _context.Franchises.Remove(franchise);
            await _context.SaveChangesAsync();
        }

        public bool FranchiseExists(int id)
        {
            return _context.Franchises.Any(e => e.Id == id);
        }

        public Task<IEnumerable<Franchise>> GetAllCharactersInFranchiseAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Movie>> GetAllMoviesInFranchiseAsync(int id)
        {
            return (IEnumerable<Movie>)await _context.Franchises.Include(f => f.Movies).FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<IEnumerable<Franchise>> GetAllFranchisesAsync()
        {
            return await _context.Franchises.ToListAsync();
        }
        
        public async Task<Franchise> GetSpecificFranchiseAsync(int id)
        {
            return await _context.Franchises.FindAsync(id);
        }

        public async Task UpdateFranchiseAsync(Franchise franchise)
        {
            _context.Entry(franchise).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task UpdateMovieInFranchiseAsync(int franchiseId, List<int> movies)
        {
            Franchise franchiseToUpdateMovies = await _context.Franchises
               .Include(f => f.Movies)
               .Where(c => c.Id == franchiseId)
               .FirstAsync();

            List<Movie> movs = new();
            foreach (int movieId in movies)
            {
                Movie mov = await _context.Movies.FindAsync(movieId);
                if (movs == null)
                    throw new KeyNotFoundException();
                movs.Add(mov);
            }
            franchiseToUpdateMovies.Movies = movs;
            await _context.SaveChangesAsync();
        }
    }
}
