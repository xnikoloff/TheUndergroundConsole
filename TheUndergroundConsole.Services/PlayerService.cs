using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheUndergroundConsole.Data;
using TheUndergroundConsole.Models;
using TheUndergroundConsole.Models.Enumerations;

namespace TheUndergroundConsole.Services
{
    public class PlayerService : IPlayerService
    {
        //String arrays holding commom first and last names. 
        //They're used to generate rival's name
        private readonly string[] firstNames = { "John", "Aaron", "David", "Michael", "Tommy", "Frank", "Christian",
            "Andre", "Curtis", "Travis", "Antony", "Jack"};

        private readonly string[] lastNames = { "Adams", "Baker", "Bell", "Atkinson", "Brown", "Carter", "Davidson",
            "Dixon", "Edwards", "Evans", "Harvey", "Murphy"};

        //String arrays holding common country names
        //It's used to generate rival's origin
        private readonly string[] countries = { "Australia", "Austria", "Belgium", "Bulgaria", "England",
        "Estonia", "France", "Finland", "Germany", "Georgia", "Norway", "Poland", "Sweden", "Unated States"};
        
        private readonly TheUndergoundConsoleDbContext dbContext;

        public PlayerService(TheUndergoundConsoleDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        //Create new player and save it to the Db
        public void Create(string name, string origin)
        {
            Player player = new Player
            {
                Name = name,
                Origin = origin,
                Points = 200,
                PlayerClass = PlayerClass.Rookie
            };

            this.dbContext.Players.Add(player);
            this.dbContext.SaveChanges();
        }

        //Buy a car and save it to the player's garadge
        //The method accepts two parameters - Player and IStoreService
        //Player param is used to determin who is the buyer and
        //IStoreService is to give the player's access to the store
        public void BuyCar(Player player, IStoreService store)
        {
            store.ShowAvailableCarsForPlayer(player);

            Console.Write("Select a car: ");
            int carId = int.Parse(Console.ReadLine());

            /*
            string[] carParameters = ExtractCarName(carChoise);
            string brand = carParameters[0];
            string model = carParameters[1];*/

            //Get a car from the Db
            Car car = this.dbContext.Cars.Where(c => c.Id == carId).FirstOrDefault();

            //Create a new object of mapping class CarPlayer
            CarPlayer carPlayer = new CarPlayer
            {
                Car = car,
                Player = player
            };

            TaxPlayer(player, car);

            this.dbContext.CarPlayers.Add(carPlayer);
            this.dbContext.SaveChanges();
        }

        /*private string[] ExtractCarName(string carName)
        {
            string[] carParameters = carName.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            return carParameters;
        }*/

        //Tax player according to the purchased car's price
        private void TaxPlayer(Player player, Car car)
        {
            player.Bank -= car.Price;
            dbContext.SaveChanges();
        }

        public Player ChoosePlayerToPlayWith()
        {
            var players = this.dbContext.Players
            .Select(c => new
            {
                c.Id,
                c.Name,
                c.Bank
            });

            foreach (var p in players)
            {
                Console.WriteLine($"{p.Id}. {p.Name}, ${p.Bank}");
            }

            Console.Write("Choose player: ");
            int playerChoise = int.Parse(Console.ReadLine());

            Player player = this.dbContext.Players.Where(p => p.Id == playerChoise).FirstOrDefault();

            return player;
        }

        //Generates rival for a race event 
        public Player GenerateRival(Player player)
        {
            string rivalFullName = GeneratRivaleName();
            string rivalOrigin = GetRivalOrigin();
            int rivalPoints = GenerateRivalPoints(player);
            
            Player rival = new Player
            {
                Name = rivalFullName,
                Origin = rivalOrigin,
                Points = rivalPoints,
            };

            return rival;

        }

        private string GeneratRivaleName()
        {
            Random rnd = new Random();

            //get a random value from the firstNames and lastNames arrays
            string rivalFirstName = this.firstNames[rnd.Next(0, this.firstNames.Length)];
            string rivalLastName = this.lastNames[rnd.Next(0, this.lastNames.Length)];

            string rivalFullName = rivalFirstName + " " + rivalLastName;

            return rivalFullName;
        }

        private string GetRivalOrigin()
        {
            Random rnd = new Random();

            //get a random value from the countries arrays
            string country = this.countries[rnd.Next(0, this.countries.Length)];

            return country;
        }

        private int GenerateRivalPoints(Player player)
        {
            Random rnd = new Random();

            //Generate random points for the rival (+20/-20 of the user's points)
            int rivalPoints = rnd.Next((player.Points - 20), (player.Points + 20));

            return rivalPoints;
        }

        //Show player's garadge
        public void ShowGaradge(Player player)
        {
            var garadge = this.dbContext.CarPlayers
            .Where(p => p.Player == player)
            .Select(cp => new
            {
                cp.Car.Id,
                cp.Car.Brand,
                cp.Car.Model,
                cp.Car.Modification
            }).ToList();

            foreach (var car in garadge)
            {
                Console.WriteLine($"{car.Id}. {car.Brand.Name} {car.Model.Name} {car.Modification}");
            }
        }

        //Selects a car for a race event
        public Car ChooseCarToPlayWith(Player player)
        {
            ShowGaradge(player);
            Console.Write("Choose car: ");
            int choise = int.Parse(Console.ReadLine());

            Car car = this.dbContext.Cars
                .Where(c => c.Id == choise)
                .FirstOrDefault();

            return car;
        }
    }
}
