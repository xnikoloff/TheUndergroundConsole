using System;
using System.Collections.Generic;
using System.Text;
using TheUndergroundConsole.Models;
using TheUndergroundConsole.Models.Enumerations;

namespace TheUndergroundConsole.Services
{
    public interface ICarService
    {
        void Create(Brand brand, Model model, Colour colour, int power, int overalPoints, TuneStage tuneStage);
    }
}
