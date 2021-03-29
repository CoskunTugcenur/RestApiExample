using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.Abstract;
using System.Linq.Expressions;
using Entities.DTOs;

namespace DataAccess.Concrete
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;

        public InMemoryCarDal()
        {
            _cars = new List<Car> {
                new Car{Id=1,BrandId=1,ColorId=1,DailyPrice=1000,Description="10000km",ModelYear="2010"},
                new Car{Id=2,BrandId=2,ColorId=2,DailyPrice=800,Description="50000km",ModelYear="2012"},
                new Car{Id=3,BrandId=2,ColorId=2,DailyPrice=500,Description="70000km",ModelYear="2015"},
                new Car{Id=4,BrandId=3,ColorId=3,DailyPrice=500,Description="80000km",ModelYear="2014"},
                new Car{Id=5,BrandId=1,ColorId=4,DailyPrice=500,Description="100000km",ModelYear="2011" }
            };


        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(c => c.Id == car.Id);
            _cars.Remove(carToDelete);
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            return null;
        }


        public List<Car> GetAll(Expression<Func<Car, bool>> filter)
        {
            return _cars;
        }

        public Car GetById(int id)
        {
            Car carValues = _cars.First(c => c.Id == id);

            return carValues;
        }

        public List<CarDetailDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }

        public List<CarDetailDto> GetCarDetails(Expression<Func<CarDetailDto, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c => c.Id == car.Id);
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.DailyPrice = 500;
            carToUpdate.Description = car.Description;
            carToUpdate.ModelYear = car.ModelYear;
        }
    }
}
