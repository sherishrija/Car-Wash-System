using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CarWashBackend.Models;

namespace CarWashBackend.Repository
{
    public class CarRepository : ICarRepository<Car>
    {
        CarWashEntities _context;
        public CarRepository(CarWashEntities context)
        {
            _context = context;
        }

        public void Add(Car car)
        {
            _context.Cars.Add(car);
            _context.SaveChanges();
        }

        public void Delete(int Id)
        {
            Car car  = _context.Cars.Find(Id);
            _context.Cars.Remove(car);
            _context.SaveChanges();
        }

        public IEnumerable<Car> Get()
        {
            return _context.Cars.ToList();
        }

        public Package GetById(int Id)
        {
            return _context.Packages.Find(Id);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public void Update(int Id,Car car)
        {
            var _car = _context.Cars.Find(Id);
            _car.Id = car.Id;
            _car.CarModel= car.CarModel;
            _car.Status = car.Status;
            _context.Entry(_car).State = System.Data.Entity.EntityState.Modified;
            _context.SaveChanges();
        }

    }
}