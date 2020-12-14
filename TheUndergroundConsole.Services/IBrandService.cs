using System;
using System.Collections.Generic;
using System.Text;
using TheUndergroundConsole.Models;

namespace TheUndergroundConsole.Services
{
    public interface IBrandService
    {
        void ImportData(string name);
        Brand SelectBrand();
    }
}
