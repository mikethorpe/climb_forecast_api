using climb_forecast_api.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace climb_forecast_api.DAL
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