﻿using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public partial class Role
    {
        public Role()
        {
            Users = new HashSet<User>();
        }

        public int Id { get; set; }
        public string? RoleName { get; set; }
        public bool? IsDeleted { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
