using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheUndergroundConsole.Data;
using TheUndergroundConsole.Models;

namespace TheUndergroundConsole.Services
{
    public class ModelService : IModelService
    {
        private readonly TheUndergoundConsoleDbContext dbContext;

        public ModelService(TheUndergoundConsoleDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public void ImportData(string name, Brand brand)
        {
            if (name == "" || name == null)
            {
                throw new ArgumentException("Name cannot be empty or null!");
            }

            var property = new Model
            {
                Name = name,
                Brand = brand
            };

            this.dbContext.Models.Add(property);
            this.dbContext.SaveChanges();
        }

        public Model SelectModel()
        {
            var models = this.dbContext.Models
                .Select(b => new
                {
                    b.Id,
                    b.Name
                }).ToList();

            foreach (var model in models)
            {
                Console.WriteLine($"{model.Id}. {model.Name}");
            }

            Console.Write("Select brand's id: ");
            int brandId = int.Parse(Console.ReadLine());

            var selectedModel = this.dbContext.Models
                .First(b => b.Id == brandId);

            return selectedModel;
        }

        public Model SelectModelByBrand(Brand brand)
        {
            var models = this.dbContext.Models
                .Where(m => m.Brand == brand)
                .Select(b => new
                {
                    b.Id,
                    b.Name
                }).ToList();

            foreach (var model in models)
            {
                Console.WriteLine($"{model.Id}. {model.Name}");
            }

            Console.Write("Select brand's id: ");
            int brandId = int.Parse(Console.ReadLine());

            var selectedModel = this.dbContext.Models
                .First(b => b.Id == brandId);

            return selectedModel;
        }
    }
}
