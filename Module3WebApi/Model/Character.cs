using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Module3WebApi.Model
{
    public class Character
    {
        public int Id { get; set; }
        [MaxLength(50)]
        public string FullName { get; set; }
        [MaxLength(50)]
        public string Alias { get; set; }
        [MaxLength(50)]
        public string Gender { get; set; }
        public string Picture { get; set; }
        public ICollection<Movie> Movies { get; set; }
    }
}
