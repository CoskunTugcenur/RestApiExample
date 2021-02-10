using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Core.DataAccess.EntityFramework;
using Entities.DTOs;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, ReCapDbContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using (ReCapDbContext context=new ReCapDbContext())
            {
                var result = from car in context.Cars
                             join b in context.Brands on car.BrandId equals b.Id
                             join c in context.Colors on car.ColorId equals c.Id
                             select new CarDetailDto
                             {
                                 CarName=car.Name,
                                 BrandName=b.Name,
                                 ColorName=c.Name,
                                 DailyPrice=car.DailyPrice

                             };

                    return result.ToList();
            }
        }
    }
}
