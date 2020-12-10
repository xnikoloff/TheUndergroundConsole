using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using TheUndergroundConsole.Common;

namespace TheUndergroundConsole.Models
{
    public class Brand
    {
        public Brand()
        {
            this.Cars = new HashSet<Car>();
            this.Models = new HashSet<Model>();
        }


        [Key]
        public int Id { get; set; }

        [MinLength(GlobalConstants.MinBrandNameLength)]
        [MaxLength(GlobalConstants.MaxBrandNameLength)]
        public string Name { get; set; }

        public ICollection<Model> Models { get; set; }

        public ICollection<Car> Cars { get; set; }

    }
}
