using System;
using System.Collections.Generic;
using System.Text;
using TheUndergroundConsole.Models;
using TheUndergroundConsole.Models.Enumerations;

namespace TheUndergroundConsole.Services
{
    public interface IPlayerService
    {
        void Create(string name, string origin);
        void BuyCar(Player player, IStoreService storeService);
        Player ChoosePlayerToPlayWith();
        Player GenerateRival(Player player);
        void ShowGaradge(Player player);
        Car ChooseCarToPlayWith(Player player);
    }
}
