using System;
using System.Collections.Generic;
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
    }
}
