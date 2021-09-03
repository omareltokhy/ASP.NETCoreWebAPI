using Microsoft.EntityFrameworkCore;
using Module3WebApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Module3WebApi.Services
{
    public class MovieService : IMovieService
    {
        private readonly MoviesDbContext _context;
        public MovieService(MoviesDbContext context)
        {
            _context = context;
        }
        public async Task<Movie> AddMovieAsync(Movie movie)
        {
            _context.Movies.Add(movie);
            await _context.SaveChangesAsync();
            return movie;
        }

        public async Task DeleteMovieAsync(int id)
        {
            var movie = await _context.Movies.FindAsync(id);
            _context.Movies.Remove(movie);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Character>> GetAllCharactersInMovieAsync(int id)
        {
            return (IEnumerable<Character>)await _context.Movies.Include(c => c.Characters).FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<IEnumerable<Movie>> GetAllMoviesAsync()
        {
            return await _context.Movies.ToListAsync();
        }

        public async Task<Movie> GetSpecificMovieAsync(int id)
        {
            return await _context.Movies.FindAsync(id);
        }

        public bool MovieExists(int id)
        {
            return _context.Movies.Any(e => e.Id == id);
        }

        public async Task UpdateMovieAsync(Movie movie)
        {
            _context.Entry(movie).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task UpdateMovieCharactersAsync(int movieId, List<int> characters)
        {
            Movie movieToUpdateCharacters = await _context.Movies
                .Include(c => c.Characters)
                .Where(c => c.Id == movieId)
                .FirstAsync();

            List<Character> chars = new();
            foreach (int charId in characters)
            {
                Character chara = await _context.Characters.FindAsync(charId);
                if (chars == null)
                    throw new KeyNotFoundException();
                chars.Add(chara);
            }
            movieToUpdateCharacters.Characters = chars;
            await _context.SaveChangesAsync();
        }
    }
}
