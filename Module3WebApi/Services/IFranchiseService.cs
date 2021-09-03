using Module3WebApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Module3WebApi.Services
{
    public interface IFranchiseService
    {
        public Task<IEnumerable<Franchise>> GetAllFranchisesAsync();
        public Task<Franchise> GetSpecificFranchiseAsync(int id);
        public Task<IEnumerable<Movie>> GetAllMoviesInFranchiseAsync(int id);
        public Task<IEnumerable<Franchise>> GetAllCharactersInFranchiseAsync(int id);
        public Task<Franchise> AddFranchiseAsync(Franchise franchise);
        public Task UpdateFranchiseAsync(Franchise franchise);
        public Task UpdateMovieInFranchiseAsync(int franchiseId, List<int> movies);
        public Task DeleteFranchiseAsync(int id);
        public bool FranchiseExists(int id);
    }
}
