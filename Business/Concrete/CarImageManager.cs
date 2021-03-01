using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.FileHelper;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
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


        public IResult Add(CarImage carImage, IFormFile file)
        {
            IDataResult<string> saveFileCntrol;
            IResult result = BusinessRules.Run(CheckImageLimitExceeded(carImage.CarId), saveFileCntrol = CheckFileIsSaved(file));

            if (result != null)
            {
                return new ErrorResult("noo");
            }

            carImage.Date = DateTime.Now;

            carImage.ImagePath = saveFileCntrol.Data;
            _carImageDal.Add(carImage);

            return new SuccessResult();

        }

        public IResult Update(CarImage carImage, IFormFile file)
        {
            var deleteToFile = carImage.ImagePath;
            var result = CheckFileIsSaved(file);
            if (result.Success)
            {
                carImage.ImagePath = CheckFileIsSaved(file).Data;
                _carImageDal.Update(carImage);

                FileHelper.DeleteFile(deleteToFile);

                return new SuccessResult();
            }

            return new ErrorResult();

        }

        public IResult Delete(CarImage carImage)
        {
            FileHelper.DeleteFile(carImage.ImagePath);

            _carImageDal.Delete(carImage);

            return new SuccessResult();
        }


        public IDataResult<List<CarImage>> GetAll()
        {
            var result = _carImageDal.GetAll();

            return new SuccessDataResult<List<CarImage>>(result);
        }


        public IDataResult<CarImage> GetById(int id)
        {
            var result = _carImageDal.Get(i => i.Id == id);
            return new SuccessDataResult<CarImage>(result);
        }


        public IDataResult<List<CarImage>> GetByCarId(int carId)
        {
            var result = _carImageDal.GetAll(i => i.CarId == carId);
            if (result.Count==0)
            {
                result.Add(new CarImage(){ CarId = carId, ImagePath = FilePaths.logoImagePath });
            }

            return new SuccessDataResult<List<CarImage>>(result);


        }


        private IDataResult<String> CheckFileIsSaved(IFormFile file)
        {
            var result = FileHelper.SaveFile(file);

            if (!String.IsNullOrEmpty(result))
            {
                return new SuccessDataResult<String>(result);
            }

            return new ErrorDataResult<String>(null);
        }


        private IResult CheckImageLimitExceeded(int carId)
        {
            var result = _carImageDal.GetAll(i => i.CarId == carId).Count;

            if (result < 5)
            {
                return new SuccessResult();
            }

            return new ErrorResult();
        }

    }
}
