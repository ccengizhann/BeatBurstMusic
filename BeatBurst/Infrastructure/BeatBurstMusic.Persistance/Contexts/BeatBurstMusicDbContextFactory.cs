using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeatBurstMusic.Persistance.Contexts
{
    public class BeatBurstMusicDbContextFactory : IDesignTimeDbContextFactory<BeatBurstMusicDbContext>
    {
        public BeatBurstMusicDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var optionsBuilder = new DbContextOptionsBuilder<BeatBurstMusicDbContext>();

            var connectionString = configuration.GetSection("YetgenPostgreSQLDB").Value;

            optionsBuilder.UseNpgsql(connectionString);

            return new BeatBurstMusicDbContext(optionsBuilder.Options);
        }
    }
}
