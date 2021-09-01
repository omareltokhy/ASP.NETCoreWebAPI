using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Module3WebApi.Model.DTOs.MovieDTO
{
    public class MovieUpdateDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public int ReleaseYear { get; set; }
        public string Director { get; set; }
        public string Picture { get; set; }
        public string Trailer { get; set; }
        //public List<int> Characters { get; set; }
     }
}
