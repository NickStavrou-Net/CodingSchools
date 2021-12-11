using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MVCMovies.Models
{
    public enum Genre
    {
        Romantic,
        Comedy,
        Western,
        Action,
        Horror,
        [Display(Name= "Sci-Fi")]
        SciFi,
        Adventure
    }
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }

        [Display(Name = "Release Date")]
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }
        public Genre Genre { get; set; }

        [Column(TypeName = "decimal(8, 2)")]
        public decimal Price { get; set; }
        public string Rating { get; set; }
    }
}
