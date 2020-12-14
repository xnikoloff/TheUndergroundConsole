using System;
using System.Collections.Generic;
using System.Text;
using TheUndergroundConsole.Data;
using TheUndergroundConsole.Models;
using TheUndergroundConsole.Models.Enumerations;

namespace TheUndergroundConsole.Services
{
    public class CarService : ICarService
    {
        private readonly TheUndergoundConsoleDbContext dbContext;

        public CarService(TheUndergoundConsoleDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Create(Brand brand, Model model, Colour colour, int power, int overalPoints, TuneStage tuneStage)
        {
            Car car = new Car
            {
                Brand = brand,
                Model = model,
                Colour = colour,
                Power = power,
                OveralPoints = overalPoints,
                TuneStage = tuneStage
            };

            this.dbContext.Cars.Add(car);
            this.dbContext.SaveChanges();
        }
    }
}
