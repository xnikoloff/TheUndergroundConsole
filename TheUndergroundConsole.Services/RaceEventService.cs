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
            //Lets the player to select their car of choise for the race event
            Car playerCar = playerService.ChooseCarToPlayWith(player);

            //Generates a car for the rival
            Car rivalCar = carService.GenerateCar(player);

            //Get the rival car's name
            string rivalCarName = rivalCar.Brand.Name + " " + rivalCar.Model.Name + " " + rivalCar.Modification;

            Console.WriteLine("Event started!");
            Console.WriteLine($"{player.Name}, your rival is {rival.Name} from {rival.Origin} " +
                $"with {rivalCarName}. Blow him out!");

            //Determine the winner and print them on the console
            Player winner = GetWinner(player, rival, playerCar, rivalCar, playerService, carService);
            Console.WriteLine($"The winner is: {winner.Name}");
        }

        private Player GetWinner(Player player, Player rival, Car playerCar, Car rivalCar,
            IPlayerService playerService, ICarService carService)
        {
            //get player's and rival's points
            int playerScore = 0;
            int playerXp = player.Points;
            int rivalScore = 0;
            int rivalXp = rival.Points;


            //get player's and rival's car facts
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
