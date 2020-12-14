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

            //ImportDataToBrands(brandService);
            //ImportDataToModels(modelService, brandService);
            CreateCar(carService, brandService, modelService);

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
    }
}
