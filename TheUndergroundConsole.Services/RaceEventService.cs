using System;
using System.Collections.Generic;
using System.Text;
using TheUndergroundConsole.Models;

namespace TheUndergroundConsole.Services
{
    public class RaceEventService : IRaceEventService
    {
        public void StartEvent(Player player, Player rival, IPlayerService playerService, ICarService carService)
        {
            Car playerCar = playerService.ChooseCarToPlayWith(player);
            Car rivalCar = carService.GenerateCar(player);

            string rivalCarName = rivalCar.Brand.Name + " " + rivalCar.Model.Name + " " + rivalCar.Modification;

            Console.WriteLine("Event started!");
            Console.WriteLine($"{player.Name}, your rival is {rival.Name} with {rivalCarName}. Blow him out!");

            Player winner = GetWinner(player, rival, playerCar, rivalCar, playerService, carService);
            Console.WriteLine($"The winner is: {winner.Name}");
        }

        private Player GetWinner(Player player, Player rival, Car playerCar, Car rivalCar,
            IPlayerService playerService, ICarService carService)
        {
            int playerScore = 0;
            int rivalScore = 0;

            int playerXp = player.Points;
            int rivalXp = rival.Points;

            int playerCarPower = playerCar.Power;
            int playerCarPoints = playerCar.OveralPoints;

            int rivalCarPower = rivalCar.Power;
            int rivalCarPoints = rivalCar.OveralPoints;

            //Compare XPs
            if (playerXp > rivalXp)
            {
                playerScore++;
            }

            else
            {
                rivalScore++;
            }
            
            //Compare cars
            if (playerCarPoints > rivalCarPoints)
            {
                playerScore++;
            }

            else
            {
                rivalScore++;
            }

            //Compare cars' power
            if (playerCarPower > rivalCarPower)
            {
                playerScore++;
            }

            else
            {
                rivalScore++;
            }

            //GetFinalResult
            if(playerScore > rivalScore)
            {
                return player;
            }

            else
            {
                return rival;
            }
        }
    }
}
