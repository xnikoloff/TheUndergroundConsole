using System;
using System.Collections.Generic;
using System.Text;
using TheUndergroundConsole.Models;

namespace TheUndergroundConsole.Services
{
    public interface IStoreService
    {
        void ShowCarsInStock();
        void ShowAvailableCarsForPlayer(Player player);

    }
}
