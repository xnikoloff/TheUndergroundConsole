using System;
using TheUndergroundConsole.Data;
using TheUndergroundConsole.Services;

namespace TheUndergroundConsole.ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            TheUndergoundConsoleDbContext dbContext = new TheUndergoundConsoleDbContext();
            IBrandService brandService = new BrandService(dbContext);

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
    }
}
