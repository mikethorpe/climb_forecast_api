using ClimbForeCastApi.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace ClimbForeCastApi.DAL
{
    public class WeatherContext : DbContext
    {
        public WeatherContext() : base("WeatherContext")
        {

        }

        public DbSet<Crag> Crags { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}