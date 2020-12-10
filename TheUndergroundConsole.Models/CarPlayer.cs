using System;
using System.Collections.Generic;
using System.Text;

namespace TheUndergroundConsole.Models
{
    public class CarPlayer
    {
        public int CarId { get; set; }

        public Car Car { get; set; }

        public int PlayerId { get; set; }

        public Player Player { get; set; }
    }
}
