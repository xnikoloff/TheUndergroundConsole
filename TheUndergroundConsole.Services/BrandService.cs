using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheUndergroundConsole.Data;
using TheUndergroundConsole.Models;

namespace TheUndergroundConsole.Services
{
    public class BrandService : IBrandService
    {
        private readonly TheUndergoundConsoleDbContext dbContext;

        public BrandService(TheUndergoundConsoleDbContext dbContext)
        {
            this.dbContext = dbContext;
        }


        public void ImportData(string name)
        {
            if(name == "" || name == null)
            {
                throw new ArgumentException("Name cannot be empty or null!");
            }

            var property = new Brand
            {
                Name = name
            };

            this.dbContext.Brands.Add(property);
            this.dbContext.SaveChanges();
        }

        public Brand SelectBrand()
        {
            var brands = this.dbContext.Brands
                .Select(b => new
                {
                    b.Id,
                    b.Name
                }).ToList();

            foreach (var brand in brands)
            {
                Console.WriteLine($"{brand.Id}. {brand.Name}");
            }

            Console.Write("Select brand's id: ");
            int brandId = int.Parse(Console.ReadLine());

            var selectedBrand = this.dbContext.Brands
                .First(b => b.Id == brandId);

            return selectedBrand;
        }
    }
}
