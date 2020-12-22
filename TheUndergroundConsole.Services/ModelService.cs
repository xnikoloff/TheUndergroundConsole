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
        
        //Inital import to the Db
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
        
        //Used to select a car model from the Db while creating a car
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

            //Select the Brand's id for the desired model
            Console.Write("Select model's id: ");
            int modelId = int.Parse(Console.ReadLine());

            //Get the car model from the Db
            var selectedModel = this.dbContext.Models
                .First(m => m.Id == modelId);

            return selectedModel;
        }

        //Used to select a model 
        public Model SelectModelByBrand(Brand brand)
        {
            var models = this.dbContext.Models
                .Where(m => m.Brand == brand)
                .Select(m => new
                {
                    m.Id,
                    m.Name
                }).ToList();

            foreach (var model in models)
            {
                Console.WriteLine($"{model.Id}. {model.Name}");
            }

            Console.Write("Select model's id: ");
            int modelId = int.Parse(Console.ReadLine());

            var selectedModel = this.dbContext.Models
                .First(m => m.Id == modelId);

            return selectedModel;
        }
    }
}
