using Module3WebApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Module3WebApi.Services
{
    public interface IMovieService
    {
        // We can include a SaveChangesAsync method to have full control over EF, some implementaitons do this.
        // I am not for simplicity sake. Its technically more flexible.
        public Task<IEnumerable<Movie>> GetAllMoviesAsync();
        public Task<Movie> GetSpecificMovieAsync(int id);
        public Task<IEnumerable<Character>> GetAllCharactersInMovieAsync(int id);
        public Task<Movie> AddMovieAsync(Movie movie);
        public Task UpdateMovieAsync(Movie movie);
        public Task UpdateMovieCharactersAsync(int movieId, List<int> characters);
        public Task DeleteMovieAsync(int id);
        public bool MovieExists(int id);
    }
}
