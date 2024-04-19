using System.Collections.Generic;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PayaPocket.Models;

namespace PayaPocket
{
    public class AppDbContext : IdentityDbContext
    {
            public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
            {

            }
            public DbSet<User> User { get; set; }
        }
    }
