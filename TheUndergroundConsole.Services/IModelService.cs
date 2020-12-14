using System;
using System.Collections.Generic;
using System.Text;
using TheUndergroundConsole.Models;

namespace TheUndergroundConsole.Services
{
    public interface IModelService
    {
        void ImportData(string name, Brand brand);
        Model SelectModel();
        Model SelectModelByBrand(Brand brand);
    }
}
