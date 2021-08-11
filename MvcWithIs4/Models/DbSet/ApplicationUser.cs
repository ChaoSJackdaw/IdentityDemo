﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MvcWithIs4.Models.DbSet
{
    public class ApplicationUser : IdentityUser<string>
    {
        public string LoginName { get; set; }

        public string RealName { get; set; }

        public int sex { get; set; } = 0;

        public int age { get; set; }

        public DateTime birth { get; set; } = DateTime.Now;

        public string addr { get; set; }

        public bool tdIsDelete { get; set; }

        public ICollection<ApplicationUserRole> UserRoles { get; set; }
    }
}