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
        private List<City> cities = new List<City>
        {
            new City { Name = "New York", Country = "USA", Population = 8_129_430 },
            new City { Name = "Kharkov", Country = "Ukraine", Population = 1_547_106 },
            new City { Name = "London", Country = "England", Population = 7_908_080 },
            new City { Name = "Kyiv", Country = "Ukraine", Population = 2_507_176 },
            new City { Name = "Los Angeles", Country = "USA", Population = 3_047_116 },
            new City { Name = "Paris", Country = "France", Population = 4_047_190 },
            new City { Name = "Denver", Country = "USA", Population = 15_947_126 }
        };
        public IEnumerable<City> Cities => cities;

        public void AddCity(City city)
        {
            cities.Add(city);
        }
    }
}
