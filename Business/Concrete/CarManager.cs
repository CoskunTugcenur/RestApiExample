using Business.Abstract;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
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

        public IResult Add(Car car)
        {
            if (car.Name.Length > 2 && car.DailyPrice > 0)
                _ICar.Add(car);
            else
                throw new ArgumentException("car's name must be at least 2 characters and the daily price cannot be 0");

            return new SuccessResult();
        }

        public IResult Delete(Car car)
        {
            _ICar.Delete(car);

            return new SuccessResult();
        }

        public IDataResult<List<Car>> GetAll()
        {

            return new SuccessDataResult<List<Car>>(_ICar.GetAll());
        }

        public IDataResult<Car> GetById(int id)
        {
            return new SuccessDataResult<Car>(_ICar.Get(p=>p.Id==id));
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_ICar.GetCarDetails());
        }

        public IDataResult<List<Car>> GetCarsByBrandId(int brandId)
        {
            return new SuccessDataResult<List<Car>>(_ICar.GetAll(p => p.BrandId == brandId));
        }

        public IDataResult<List<Car>> GetCarsByColorId(int colorId)
        {
            return new SuccessDataResult<List<Car>>(_ICar.GetAll(p => p.ColorId == colorId));
        }

        public IResult Update(Car car)
        {
            _ICar.Update(car);
            return new SuccessResult();
        }
    }
}
