using Core.Business;
using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IRentalService:IServiceBase<Rental>
    {
        IDataResult<Rental> GetRentByCarId(int carId);

        IDataResult<List<RentalDetailDto>> GetRentalDetails();

    }
}
