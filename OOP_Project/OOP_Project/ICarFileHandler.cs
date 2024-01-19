using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Project
{
    public interface ICarFileHandler
    {
        List<ICar> LoadCarsFromFile(string filePath);
        void SaveCarsToFile(IEnumerable<ICar> cars, string filePath);
    }
}
