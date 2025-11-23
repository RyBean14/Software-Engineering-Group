using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Software_Engineering_Group.Models;
using SensoreApp.Models;

namespace Software_Engineering_Group.Data
{
    public class Software_Engineering_GroupContext : IdentityDbContext
    {
        public Software_Engineering_GroupContext (DbContextOptions<Software_Engineering_GroupContext> options)
            : base(options)
        {
        }

        public DbSet<Software_Engineering_Group.Models.User> User { get; set; } = default!;
        public DbSet<SensoreApp.Models.Report> Report { get; set; } = default!;
    }
}
