using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Module3WebApi.Model
{
    public class Movie
    {
        public int Id { get; set; }
        [MaxLength(50)]
        public string Title { get; set; }
        [MaxLength(250)]
        public string Genre { get; set; }
        public int ReleaseYear { get; set; }
        [MaxLength(50)]
        public string Director { get; set; }
        public string Picture { get; set; }
        public string Trailer { get; set; }
        public int? FranchiseId { get; set; }
        public Franchise Franchise { get; set; }
        public ICollection<Character> Characters { get; set; }
    }
}
