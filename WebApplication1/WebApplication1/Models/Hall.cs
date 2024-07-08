using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public partial class Hall
    {
        public Hall()
        {
            Seats = new HashSet<Seat>();
            TimeShows = new HashSet<TimeShow>();
        }

        public int Id { get; set; }
        public int? CinemaId { get; set; }
        public string? HallName { get; set; }
        public int? NumberSeat { get; set; }
        public bool? IsDeleted { get; set; }

        public virtual Cinema? Cinema { get; set; }
        public virtual ICollection<Seat> Seats { get; set; }
        public virtual ICollection<TimeShow> TimeShows { get; set; }
    }
}
