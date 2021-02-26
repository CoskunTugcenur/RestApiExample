using Business.Abstract;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;

        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }
        public IResult Add(CarImage entity)
        {
            _carImageDal.Add(entity);

            return new SuccessResult();
        }

        public IResult Delete(CarImage entity)
        {
            _carImageDal.Delete(entity);

            return new SuccessResult();
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            var result=_carImageDal.GetAll();

            return new SuccessDataResult<List<CarImage>>(result);
        }

        public IDataResult<CarImage> GetById(string id)
        {
            var result = _carImageDal.Get(i => i.Id == id);
            return new SuccessDataResult<CarImage>(result);
        }


        public IResult Update(CarImage entity)
        {
            _carImageDal.Update(entity);
            return new SuccessResult();
        }
    }
}
