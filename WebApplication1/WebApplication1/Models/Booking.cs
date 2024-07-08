using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public partial class Booking
    {
        public int TicketId { get; set; }
        public int UserId { get; set; }
        public bool? IsDeleted { get; set; }

        public virtual Ticket Ticket { get; set; } = null!;
        public virtual User User { get; set; } = null!;
    }
}
