
using Business.Abstract;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public IResult Add(User entity)
        {
            _userDal.Add(entity);

            return new SuccessResult();
        }

        public IResult Delete(User entity)
        {
            _userDal.Delete(entity);

            return new SuccessResult();

        }

        public IDataResult<List<User>> GetAll()
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll());
        }

        public IDataResult<User> GetById(int id)
        {
            return new SuccessDataResult<User>(_userDal.Get(u => u.Id == id));
        }

        public IDataResult<User> GetByMail(string email)
        {
            var result=_userDal.Get(u => u.Email == email);
            if (result==null)
            { 
                return new ErrorDataResult<User>();
            }
                return new SuccessDataResult<User>(result);

        }

        public IDataResult<List<OperationClaim>> GetClaims(User user)
        {
            var result=_userDal.GetClaims(user);

            return new SuccessDataResult<List<OperationClaim>>(result);
        }

        public IResult Update(User entity)
        {
            _userDal.Update(entity);
            return new SuccessResult();
        }
    }
}
