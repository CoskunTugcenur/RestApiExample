using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICompanyService 
    {
        IDataResult<List<Company>> GetAll();
        IDataResult<Company> GetById(int id);
        IResult Add(Company company);
        IResult Delete(Company company);
        IResult Update(Company company);

    }
}
