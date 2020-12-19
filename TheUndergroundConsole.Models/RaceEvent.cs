using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TheUndergroundConsole.Models
{
    public class RaceEvent
    {
        [Key]
        public int Id { get; set; }

        public int PlayerId { get; set; }

        [ForeignKey(nameof(PlayerId))]
        public Player Player{ get; set; }

        public int RivalId { get; set; }

        [ForeignKey(nameof(RivalId))]
        public Player Rival { get; set; }

    }
}
