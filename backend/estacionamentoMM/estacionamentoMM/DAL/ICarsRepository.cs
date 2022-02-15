using estacionamentoMM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace estacionamentoMM.DAL
{
    public interface ICarsRepository : IDisposable
    {
        IEnumerable<Cars> GetCars();
        Cars GetCarById(string carId);
        void RegisterCar(Cars car);
        void RemoveCar(string carId);
        void UpdateCar(string carId, Cars car);
        void Save();
    }
}
