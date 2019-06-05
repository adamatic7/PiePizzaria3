using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PiePizzaria3.Models;

namespace PiePizzaria3.Data
{
    public class PiePizzaContext : DbContext
    {
        public PiePizzaContext(DbContextOptions<PiePizzaContext> options) : base(options)
        {
        }
        public DbSet<Pie> Pies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pie>().ToTable("Pie");
        }
    }
}
