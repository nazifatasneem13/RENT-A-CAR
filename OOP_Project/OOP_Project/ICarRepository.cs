using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Project
{
    public interface ICarRepository
    {
        void AddCar(ICar car);
        void RemoveCar(ICar car);
        IEnumerable<ICar> GetAvailableCars();
    }
}
