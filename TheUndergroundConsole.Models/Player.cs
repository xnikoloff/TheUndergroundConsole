using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
            this.RaceEventsAsPlayer = new HashSet<RaceEvent>();
            this.RaceEventsAsRival = new HashSet<RaceEvent>();
        }


        [Key]
        public int Id { get; set; }

        [MinLength(GlobalConstants.MinPlayerNameLength)]
        [MaxLength(GlobalConstants.MaxPlayerNameLength)]
        public string Name { get; set; }

        public string Origin { get; set; }

        public int Bank { get; set; }

        public int Points { get; set; }

        public PlayerClass PlayerClass{ get; set; }

        public IEnumerable<CarPlayer> CarPlayers { get; set; }

        [InverseProperty("Player")]
        public IEnumerable<RaceEvent> RaceEventsAsPlayer { get; set; }

        [InverseProperty("Rival")]
        public IEnumerable<RaceEvent> RaceEventsAsRival { get; set; }
    }
}
