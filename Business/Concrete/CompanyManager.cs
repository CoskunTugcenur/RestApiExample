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
    public class CompanyManager : ICompanyService
    {
        ICompanyDal _companyDal;

        public CompanyManager(ICompanyDal companyDal)
        {
            _companyDal = companyDal;
        }

        public IResult Add(Company entity)
        {
            _companyDal.Add(entity);
        
            return new SuccessResult();
        }

        public IResult Delete(Company entity)
        {
            _companyDal.Delete(entity);

            return new SuccessResult();
        }

        public IDataResult<List<Company>> GetAll()
        {
            return new SuccessDataResult<List<Company>>(_companyDal.GetAll());
        }

        public IDataResult<Company> GetById(int id)
        {
            return new SuccessDataResult<Company>(_companyDal.Get(c => c.Id == id));
        }

        public IResult Update(Company entity)
        {
            _companyDal.Update(entity);

            return new SuccessResult();
        }
    }
}
