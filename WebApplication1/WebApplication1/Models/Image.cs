using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public partial class Image
    {
        public Image()
        {
            ImageDetails = new HashSet<ImageDetail>();
            Movies = new HashSet<Movie>();
        }

        public int Id { get; set; }
        public DateTime? CreateDate { get; set; }
        public bool? IsDeleted { get; set; }

        public virtual ICollection<ImageDetail> ImageDetails { get; set; }
        public virtual ICollection<Movie> Movies { get; set; }
    }
}
