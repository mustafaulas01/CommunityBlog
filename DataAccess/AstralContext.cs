using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public class AstralContext : DbContext
    {


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           optionsBuilder.UseSqlServer(@"Server=MUSTAFAULAS\SQLEXPRESS;Database=astralDb;trusted_connection=true; TrustServerCertificate=true");
        }
        public DbSet<AppUser> AppUsers { get; set; }
    }
}