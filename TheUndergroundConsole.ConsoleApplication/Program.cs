using System;
using TheUndergroundConsole.Data;
using TheUndergroundConsole.Models;
using TheUndergroundConsole.Models.Enumerations;
using TheUndergroundConsole.Services;

namespace TheUndergroundConsole.ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            TheUndergoundConsoleDbContext dbContext = new TheUndergoundConsoleDbContext();
            IBrandService brandService = new BrandService(dbContext);
            IModelService modelService = new ModelService(dbContext);
            ICarService carService = new CarService(dbContext);
            IStoreService storeService = new StoreService(dbContext);
            IPlayerService playerService = new PlayerService(dbContext);
            IRaceEventService raceEventService = new RaceEventService();
            //ImportDataToBrands(brandService);
            //ImportDataToModels(modelService, brandService);
            //CreateCar(carService, brandService, modelService);
            //ShowCarsInStore(storeService);
            //CreatePlayer(playerService);
            //BuyCar(playerService, storeService);
            //Player player = playerService.ChoosePlayerToPlayWith();
            //ShowGaradge(playerService, player);

            StartRaceEvent(raceEventService, playerService, carService);
        }

        static void ImportDataToBrands(IBrandService brandService)
        {
            string name = "";

            while (true)
            {
                Console.Write("Brand: ");
                name = Console.ReadLine();

                if (name == "stop")
                {
                    break;
                }

                brandService.ImportData(name);
            }
        }

        static void ImportDataToModels(IModelService modelService, IBrandService brandService)
        {
            string name = "";
            Brand brand = brandService.SelectBrand();

            while (true)
            {
                Console.Write("Model: ");
                name = Console.ReadLine();

                if (name == "stop")
                {
                    break;
                }

                modelService.ImportData(name, brand);
            }
        }

        static void CreateCar(ICarService carService, IBrandService brandService, IModelService modelService)
        {
            Brand brand = brandService.SelectBrand();
            Model model = modelService.SelectModelByBrand(brand);

            Console.Write("Power: ");
            int power = int.Parse(Console.ReadLine());


            foreach(Colour colour in Enum.GetValues(typeof(Colour)))
            {
                Console.WriteLine($"{(int)colour}. {colour.ToString()}");
            }

            Console.Write("Select colour: ");
            string colourString = Console.ReadLine();

            Console.Write("Overal points: ");
            int overallPoints = int.Parse(Console.ReadLine());

            foreach (TuneStage tuneStage in Enum.GetValues(typeof(TuneStage)))
            {
                Console.WriteLine($"{(int)tuneStage}. {tuneStage.ToString()}");
            }

            Console.Write("Select tune stage: ");
            string tuneStageString = Console.ReadLine();

            carService.Create(brand, model, (Colour)Enum.Parse(typeof(Colour), colourString), power, overallPoints, (TuneStage)Enum.Parse(typeof(TuneStage), tuneStageString));
        }

        static void ShowCarsInStore(IStoreService storeService)
        {
            storeService.ShowCarsInStock();
        }

        static void CreatePlayer(IPlayerService playerService)
        {
            Console.Write("Name: ");
            string name = Console.ReadLine();

            Console.Write("Origin: ");
            string origin = Console.ReadLine();

            playerService.Create(name, origin);
        }

        static void BuyCar(IPlayerService playerService, IStoreService storeService)
        {
            Player player = playerService.ChoosePlayerToPlayWith();
            playerService.BuyCar(player, storeService);
        }

        static void ShowGaradge(IPlayerService playerService, Player player)
        {
            Console.WriteLine($"{player.Name}'s garadge: ");
            playerService.ShowGaradge(player);
        }

        static void StartRaceEvent(IRaceEventService raceEventService, IPlayerService playerService, 
            ICarService carService)
        {
            Player player = playerService.ChoosePlayerToPlayWith();
            Player rival = playerService.GenerateRival(player);
            raceEventService.StartEvent(player, rival, playerService, carService);
        }
    }
}
