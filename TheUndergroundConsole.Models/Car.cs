using System;
using System.Collections.Generic;
using System.Text;
using TheUndergroundConsole.Models.Enumerations;

namespace TheUndergroundConsole.Models
{
    public class Car
    {
        public Car()
        {
            this.CarPlayers = new HashSet<CarPlayer>();
        }

        public int Id { get; set; }

        public int BrandId { get; set; }

        public Brand Bran { get; set; }

        public int ModelId { get; set; }

        public Model Model { get; set; }
        public string Modification { get; set; }

        public int Price { get; set; }

        public Colour Colour { get; set; }

        public int Power { get; set; }

        public TuneStage TuneStage { get; set; }

        public int OveralPoints { get; set; }

        public ICollection<CarPlayer> CarPlayers { get; set; }
    }
}
