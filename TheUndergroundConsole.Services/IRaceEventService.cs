using System;
using System.Collections.Generic;
using System.Text;
using TheUndergroundConsole.Models;

namespace TheUndergroundConsole.Services
{
    public interface IRaceEventService
    {
        void StartEvent(Player player, Player rival, IPlayerService playerService, ICarService carService);
    }
}
