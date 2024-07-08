using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public partial class Seat
    {
        public Seat()
        {
            Tickets = new HashSet<Ticket>();
        }

        public int Id { get; set; }
        public int? HallId { get; set; }
        public string? SeatCode { get; set; }
        public bool? IsDeleted { get; set; }

        public virtual Hall? Hall { get; set; }
        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
