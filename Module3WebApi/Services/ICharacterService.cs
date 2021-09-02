using Module3WebApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Module3WebApi.Services
{
    public interface ICharacterService
    {
        // We can include a SaveChangesAsync method to have full control over EF, some implementaitons do this.
        // I am not for simplicity sake. Its technically more flexible.
        public Task<IEnumerable<Character>> GetAllCharactersAsync();
        public Task<Character> GetSpecificCharacterAsync(int id);
        public Task<Character> AddCharacterAsync(Character character);
        public Task UpdateCharacterAsync(Character character);
        public Task DeleteCharacterAsync(int id);
        public bool CharacterExists(int id);
    }
}
