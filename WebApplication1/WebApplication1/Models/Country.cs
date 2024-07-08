using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public partial class Country
    {
        public Country()
        {
            Movies = new HashSet<Movie>();
        }

        public int Id { get; set; }
        public string? CountryName { get; set; }
        public bool? IsDeleted { get; set; }

        public virtual ICollection<Movie> Movies { get; set; }
    }
}
