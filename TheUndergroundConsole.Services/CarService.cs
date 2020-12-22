﻿using System;
using System.Collections.Generic;
using System.Linq;
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

        //Import cars to the Db. Theese cars will be shown in the carlot later
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
        
        //Generates car for the player's rival
        //Currently the method just gets random car from the db but later the car will be generated
        //according to player's XP and his current car 
        public Car GenerateCar(Player player)
        {
            Random rnd = new Random();

            var carList = this.dbContext.Cars
            .Select(c => new
            {
                c.Brand,
                c.Model,
                c.Modification,
                c.Power,
                c.OveralPoints

            }).ToList();
            
            Car rndCar = null;

            //The loop makes sure that the number generated by the Random class
            //is an existing Car Id
            do
            {
                int randomNumber = rnd.Next(1, carList.Count);
                rndCar = this.dbContext.Cars.Where(c => c.Id == randomNumber).FirstOrDefault();
            }
            while (rndCar == null);
            
            return rndCar;
        }
    }
}
