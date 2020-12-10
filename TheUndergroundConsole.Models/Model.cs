using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using TheUndergroundConsole.Common;

namespace TheUndergroundConsole.Models
{
    public class Model
    {
        public Model()
        {
            this.Cars = new HashSet<Car>();
        }

        [Key]
        public int Id { get; set; }

        [MinLength(GlobalConstants.MinModelNameLength)]
        [MaxLength(GlobalConstants.MaxModelNameLength)]
        public string Name { get; set; }

        [Required]
        [ForeignKey(nameof(Brand))]
        public int BrandId { get; set; }
        public Brand Brand { get; set; }

        public ICollection<Car> Cars{ get; set; }
    }
}
