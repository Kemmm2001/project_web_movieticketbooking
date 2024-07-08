using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public partial class Cinema
    {
        public Cinema()
        {
            Halls = new HashSet<Hall>();
            TimeShows = new HashSet<TimeShow>();
        }

        public int Id { get; set; }
        public string? CinemaName { get; set; }
        public string? Address { get; set; }
        public bool? IsDeleted { get; set; }

        public virtual ICollection<Hall> Halls { get; set; }
        public virtual ICollection<TimeShow> TimeShows { get; set; }
    }
}
