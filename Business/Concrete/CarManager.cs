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

        ICarDal _ICar;

        public CarManager(ICarDal carDal)
        {
            _ICar = carDal;
        }

        public void Add(Car car)
        {
            _ICar.Add(car);   
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
            return _ICar.GetById(id);
        }

        public void Update(Car car)
        {
            _ICar.Update(car);
        }
    }
}
