using Business.Abstract;
using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using DataAccess.Abstract;
using Core.Utilities.Results.Concrete;

namespace Business.Concrete
{
    class CreditCardManager : ICreditCardService
    {
        ICreditCardDal _creditCardDal;
        public CreditCardManager(ICreditCardDal creditCardDal)
        {
            _creditCardDal = creditCardDal;
        }
        public IResult Add(CreditCard creditCard)
        {
            _creditCardDal.Add(creditCard);

            return new SuccessDataResult<CreditCard>(creditCard);
        }

        public IResult Delete(CreditCard creditCard)
        {
            _creditCardDal.Delete(creditCard);

            return new SuccessDataResult<CreditCard>(creditCard);
        }

        public IDataResult<List<CreditCard>> GetByCustomerId(int customerId)
        {
            var result=_creditCardDal.GetAll(card => card.CustomerId == customerId);

            return new SuccessDataResult<List<CreditCard>>(result);
        }

        public IDataResult<CreditCard> GetById(int id)
        {
            var result = _creditCardDal.Get(card => card.Id == id);

            return new SuccessDataResult<CreditCard>(result);
        }

        public IResult Update(CreditCard creditCard)
        {
            _creditCardDal.Update(creditCard);

            return new SuccessDataResult<CreditCard>(creditCard);
        }
    }
}
