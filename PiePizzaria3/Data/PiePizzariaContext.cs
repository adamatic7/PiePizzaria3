using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace PiePizzaria3.Models
{
    public class PiePizzariaContext : DbContext
    {
        public PiePizzariaContext (DbContextOptions<PiePizzariaContext> options)
            : base(options)
        {
        }

        public DbSet<PiePizzaria3.Models.Pie> Pie { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pie>().ToTable("Pie");


        }
    }
}
