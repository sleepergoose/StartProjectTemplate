using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppConfigTest.Models
{
    public interface ICityRepository
    {
        IEnumerable<City> Cities { get; }
        void AddCity(City city);

    }

    public class CityRepository : ICityRepository
    {
        private List<City> cities = new List<City>()
        {
            new City { Name = "London", Country = "England", Population = 8_258_369 },
            new City { Name = "New York", Country = "USA", Population = 9_558_369 },
            new City { Name = "Moscow", Country = "Russia", Population = 7_158_369 },
            new City { Name = "Shefild", Country = "England", Population = 858_369 },
            new City { Name = "Manchester", Country = "England", Population = 1_458_369 }
        };
        public IEnumerable<City> Cities => cities;

        public void AddCity(City city)
        {
            cities.Add(city);
        }
    }
}
