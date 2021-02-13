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
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }


        public IResult Add(Rental entity)
        {
            bool result =GetRentByCarId(entity.CardId).Success;
            if (result)
            {
                _rentalDal.Add(entity);
                return new SuccessResult("The car is rentaled successfully");
            }
            else
            {
                return new ErrorResult("The car cant be rented");
            }

        }

        public IResult Delete(Rental entity)
        {
            _rentalDal.Delete(entity);

            return new SuccessResult();
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll());
        }

        public IDataResult<Rental> GetById(int id)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(r => r.Id == id));
        }

        public IResult Update(Rental entity)
        {
            _rentalDal.Update(entity);

            return new SuccessResult();
        }

        public IDataResult<Rental> GetRentByCarId(int carId)
        {
            Rental rental=_rentalDal.Get(c => c.CardId == carId ) ;

            if (rental==null || rental.ReturnDate==null)
            {
                return new SuccessDataResult<Rental>(rental);
            }
            else
            {
                return new ErrorDataResult<Rental>(rental);
            }

        }
    }
}
