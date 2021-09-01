using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Module3WebApi.Model.DTOs.CharacterDTO
{
    public class CharacterCreateDTO
    {
        public string FullName { get; set; }
        public string Alias { get; set; }
        public string Gender { get; set; }
        public string Picture { get; set; }
    }
}
