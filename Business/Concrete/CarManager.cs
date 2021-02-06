using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        IEntityRepository<Car> _ICar;

        public CarManager(IEntityRepository<Car> carDal)
        {
            _ICar = carDal;
        }

        public void Add(Car car)
        {
            if (car.Name.Length > 2 && car.DailyPrice > 0)
                _ICar.Add(car);
            else
                throw new ArgumentException("car's name must be at least 2 characters and the daily price cannot be 0");
        }

        public void Delete(Car car)
        {
            _ICar.Delete(car);
        }

        public List<Car> GetAll()
        {

            return _ICar.GetAll();
        }

        public Car GetById(int id)
        {
            return _ICar.Get(p=>p.Id==id);
        }

        public Car GetCarsByBrandId(int brandId)
        {
            return _ICar.Get(p => p.BrandId == brandId);
        }

        public Car GetCarsByColorId(int colorId)
        {
            return _ICar.Get(p => p.ColorId == colorId);
        }

        public void Update(Car car)
        {
            _ICar.Update(car);
        }
    }
}
