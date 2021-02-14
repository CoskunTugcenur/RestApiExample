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
    public class EfRentalDal : EfEntityRepositoryBase<Rental, ReCapDbContext>, IRentalDal
    {
        public List<RentalDetailDto> GetRentalDetails()
        {
            using (ReCapDbContext context=new ReCapDbContext())
            {
                var result = from r in context.Rentals
                             join car in context.Cars on r.CarId equals car.Id
                             join c in context.Customers on r.CustomerId equals c.Id 
                             join u in context.Users on c.UserId equals u.Id
                             join company in context.Companies on c.CompanyId equals company.Id
                             select new RentalDetailDto
                             {
                                 CompanyName =company.Name,
                                 UserName=u.FirstName,
                                 UserSurname=u.LastName,
                                 CarName = car.Name,
                                 RentDate =r.RentDate,
                                 ReturnDate= r.ReturnDate

                             };

                return result.ToList();



            }
        }
    }
}
