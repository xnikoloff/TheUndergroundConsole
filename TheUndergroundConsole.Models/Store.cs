using System;
using System.Collections.Generic;
using System.Text;

namespace TheUndergroundConsole.Models
{
    public class Store
    {
        public Store()
        {
            this.CarsInStock = new HashSet<Car>();
        }

        public int Id { get; set; }
        public ICollection<Car> CarsInStock { get; set; }
    }
}
