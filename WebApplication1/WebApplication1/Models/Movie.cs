using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public partial class Movie
    {
        public Movie()
        {
            TimeShows = new HashSet<TimeShow>();
        }

        public int Id { get; set; }
        public string? MovieName { get; set; }
        public string? YearOfManufacture { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public string? Description { get; set; }
        public int? ImageId { get; set; }
        public int? GenreId { get; set; }
        public int? CountryId { get; set; }

        public virtual Country? Country { get; set; }
        public virtual Genre? Genre { get; set; }
        public virtual Image? Image { get; set; }
        public virtual ICollection<TimeShow> TimeShows { get; set; }
    }
}
