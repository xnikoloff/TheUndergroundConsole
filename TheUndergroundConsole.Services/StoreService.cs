using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheUndergroundConsole.Data;
using TheUndergroundConsole.Models;

namespace TheUndergroundConsole.Services
{
    public class StoreService : IStoreService
    {
        private readonly TheUndergoundConsoleDbContext dbContext;

        public StoreService(TheUndergoundConsoleDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void ShowAvailableCarsForPlayer(Player player)
        {
            var carsInStock = this.dbContext.Cars
               .Where(c => c.OveralPoints <= player.Points)
               .Select(c => new
               {
                   c.Id,
                   Brand = c.Brand.Name,
                   Model = c.Model.Name,
                   c.Colour,
                   c.Power,
                   c.Price,
                   c.OveralPoints
               }).ToList();

            foreach (var car in carsInStock)
            {
                Console.WriteLine($"{car.Id}, {car.Brand} {car.Model}, {car.Colour}, {car.Power}HP, ${car.Price}, {car.OveralPoints} points");
            }
        }

        public void ShowCarsInStock()
        {
            var carsInStock = this.dbContext.Cars
                .Select(c => new
                {
                    Brand = c.Brand.Name,
                    Model = c.Model.Name,
                    c.Colour,
                    c.Power,
                    c.Price,
                    c.OveralPoints
                }).ToList();

            foreach(var car in carsInStock)
            {
                Console.WriteLine($"{car.Brand} {car.Model}, {car.Colour}, {car.Power}HP, ${car.Price}, {car.OveralPoints} points");
            }
        }
    }
}
