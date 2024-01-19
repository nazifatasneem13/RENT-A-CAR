using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Project
{
    public interface IRentalService
    {
        void RentCar(ICar car);
        void ReturnCar(ICar car);
        List<ICar> GetRentedCars();
        Dictionary<ICar, RentalHistory> GetRentalHistory();
    }
}
