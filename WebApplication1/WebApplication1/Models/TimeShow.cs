using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public partial class TimeShow
    {
        public TimeShow()
        {
            Tickets = new HashSet<Ticket>();
        }

        public int Id { get; set; }
        public int? MovieId { get; set; }
        public int? CinemaId { get; set; }
        public int? HallId { get; set; }
        public DateTime? ShowDate { get; set; }
        public TimeSpan? StartTime { get; set; }
        public TimeSpan? EndTime { get; set; }
        public bool? IsDeleted { get; set; }

        public virtual Cinema? Cinema { get; set; }
        public virtual Hall? Hall { get; set; }
        public virtual Movie? Movie { get; set; }
        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
