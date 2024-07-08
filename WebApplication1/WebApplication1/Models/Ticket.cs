using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public partial class Ticket
    {
        public Ticket()
        {
            Bookings = new HashSet<Booking>();
        }

        public int Id { get; set; }
        public DateTime? SellDate { get; set; }
        public double? Price { get; set; }
        public int? SeatId { get; set; }
        public int? TimeshowId { get; set; }
        public int? Status { get; set; }
        public bool? IsDeleted { get; set; }

        public virtual Seat? Seat { get; set; }
        public virtual TimeShow? Timeshow { get; set; }
        public virtual ICollection<Booking> Bookings { get; set; }
    }
}
