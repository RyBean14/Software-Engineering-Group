using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Software_Engineering_Group.Models;

namespace Software_Engineering_Group.Data
{
    public class Software_Engineering_GroupContext : DbContext
    {
        public Software_Engineering_GroupContext (DbContextOptions<Software_Engineering_GroupContext> options)
            : base(options)
        {
        }

        public DbSet<Software_Engineering_Group.Models.User> User { get; set; } = default!;
    }
}
