using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public partial class ImageDetail
    {
        public int Id { get; set; }
        public int? ImageId { get; set; }
        public string? ImageName { get; set; }
        public bool? IsDeleted { get; set; }

        public virtual Image? Image { get; set; }
    }
}
