using System;
using System.Collections.Generic;
using System.Text;
using TheUndergroundConsole.Models.Enumerations;

namespace TheUndergroundConsole.Services
{
    public interface IPlayerService
    {
        void Create(string name, string origin, int points = 0, PlayerClass playerClass = PlayerClass.Rookie);
    }
}
