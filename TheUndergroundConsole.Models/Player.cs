using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using TheUndergroundConsole.Common;
using TheUndergroundConsole.Models.Enumerations;

namespace TheUndergroundConsole.Models
{
    public class Player
    {
        public Player()
        {
            this.CarPlayers = new HashSet<CarPlayer>();
        }


        [Key]
        public int Id { get; set; }

        [MinLength(GlobalConstants.MinPlayerNameLength)]
        [MaxLength(GlobalConstants.MaxPlayerNameLength)]
        public string Name { get; set; }

        public string Origin { get; set; }

        public int Points { get; set; }

        public PlayerClass PlayerClass{ get; set; }

        public HashSet<CarPlayer> CarPlayers{ get; set; }
    }
}
