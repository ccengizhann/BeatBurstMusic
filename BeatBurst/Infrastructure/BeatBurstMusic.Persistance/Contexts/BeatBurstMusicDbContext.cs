using BeatBurstMusic.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeatBurstMusic.Persistance.Contexts
{
    public class BeatBurstMusicDbContext: DbContext
    {
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Instrument> Instruments { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<User> Users { get; set; }


        public BeatBurstMusicDbContext(DbContextOptions<BeatBurstMusicDbContext> dbContextOptions) : base(dbContextOptions)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            

            base.OnModelCreating(modelBuilder);
        }
    }
}
