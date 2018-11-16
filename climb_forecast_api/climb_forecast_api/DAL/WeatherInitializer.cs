using climb_forecast_api.Models;
using System.Collections.Generic;

namespace climb_forecast_api.DAL
{
    public class WeatherInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<WeatherContext>
    {
        protected override void Seed(WeatherContext context)
        {
            var crags = new List<Crag>
            {
                new Crag{CragName="RosythQuarry", WeatherStationName="ROSYTH"},
                new Crag{CragName="Aberdour (Hawkcraig)", WeatherStationName="ABERDOUR"}
            };

            crags.ForEach(crag => context.Crags.Add(crag));
            context.SaveChanges();
        }

    }
}