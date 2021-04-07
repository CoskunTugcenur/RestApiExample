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
        public List<CarDetailDto> GetCarDetails(Expression<Func<CarDetailDto, bool>> filter = null)
        {
            using (ReCapDbContext context=new ReCapDbContext())
            {
                var result = from car in context.Cars
                             join b in context.Brands on car.BrandId equals b.Id into carB
                             from resultB in carB.DefaultIfEmpty()
                             join c in context.Colors on car.ColorId equals c.Id into carC
                             from resultC in carC.DefaultIfEmpty() 

                             select new CarDetailDto
                             {
                                 Id=(int)car.Id,
                                 Name= car.Name,
                                 BrandId=(int)resultB.Id,
                                 ColorId=(int)resultC.Id,
                                 Description=car.Description,
                                 ModelYear=car.ModelYear,
                                 BrandName = resultB.Name,
                                 ColorName = resultC.Name,
                                 DailyPrice = car.DailyPrice,
                                 CarImages = (from carImage in context.CarImages
                                              where (carImage.CarId == car.Id)
                                              select carImage).ToArray()

                             };

                return filter == null
                   ? result.ToList()
                   : result.Where(filter).ToList();
                
            }
        }
    }
}
