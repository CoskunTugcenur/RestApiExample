using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using Core.CrossCuttingConcerns.Validation;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using Core.Aspects.Autofac.Validation;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _ICar;

        public CarManager(ICarDal carDal)
        {
            _ICar = carDal;
        }

        [ValidationAspect(typeof(CarValidator))]
        public IResult Add(Car car)
        {
            _ICar.Add(car);

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
            return new SuccessDataResult<Car>(_ICar.Get(p => p.Id == id));
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_ICar.GetCarDetails());
        }

        public IDataResult<List<CarDetailDto>> GetCarDetailsByBrandId(int brandId)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_ICar.GetCarDetails(c => c.BrandId == brandId));

        }

        public IDataResult<CarDetailDto> GetCarDetailsByCarId(int carId)
        {
            return new SuccessDataResult<CarDetailDto>(_ICar.GetCarDetails(c => c.Id == carId)[0]);
        }

        public IDataResult<List<CarDetailDto>> GetCarDetailsByColorId(int colorId)
        {   
            return new SuccessDataResult<List<CarDetailDto>>(_ICar.GetCarDetails(c=>c.ColorId==colorId));
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
