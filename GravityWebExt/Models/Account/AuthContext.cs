using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

namespace GravityWebExt.Models
{
    public class AuthContext : DbContext
    {
        public DbSet<UserAccount> Users { get; set; }
        public DbSet<UserGroup> Roles { get; set; }
        public AuthContext(DbContextOptions<AuthContext> options)
            : base(options)
        {
            Database.Migrate();
        }
    }
}
