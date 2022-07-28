using MelhorRota.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MelhorRota.Data.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder options)
        //{
        //    options.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=MelhorRota;Trusted_Connection=True;MultipleActiveResultSets=true");
        //}

        public DbSet<Aeroporto> Aeroporto { get; set; }
        public DbSet<AeroportoRotas> AeroportoRotas { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Aeroporto>().ToTable("Aeroporto");
        //    modelBuilder.Entity<AeroportoRotas>().ToTable("AeroportoRotas");
        //}
    }
}
