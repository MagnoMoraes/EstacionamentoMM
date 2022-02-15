using estacionamentoMM.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace estacionamentoMM.DAL
{
    public class CarsRepository : ICarsRepository
    {
        private CarsContext _context;
        public CarsRepository(CarsContext carContext)
        {
            this._context = carContext;
        }

        public Cars GetCarById(string carId)
        {
            return this._context.Car.Find(carId);
        }

        public IEnumerable<Cars> GetCars()
        {
            return this._context.Car.ToList().OrderBy(c => c.VagaOcupada);
        }

        public void RegisterCar(Cars car)
        {
            Random randId = new Random();
            int resultIdRandom = randId.Next(999);
            car.Id = $"{resultIdRandom}";
            this._context.Car.Add(car);
            foreach (var item in GetCars())
            {
                if (car.Id == item.Id)
                {
                    resultIdRandom = randId.Next(1000, 9999);
                    car.Id = $"{resultIdRandom}";
                }
            }            
            Save();
        }

        public void RemoveCar(string carId)
        {
            Cars carSearch = GetCarById(carId);
            this._context.Car.Remove(carSearch);
            Save();
        }

        public void UpdateCar(string carId, Cars car)
        {
            Cars carSearch = GetCarById(carId);
            carSearch.Id = car.Id;
            carSearch.Placa = car.Placa;
            carSearch.VagaOcupada = car.VagaOcupada;
            this._context.Car.Update(carSearch);
            Save();
        }

        public void Save()
        {
            this._context.SaveChanges();
        }

        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
