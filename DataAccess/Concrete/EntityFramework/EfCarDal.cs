using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EntityRepository<Car> //ICarDal
    {
        //DbContext context;
        //public EfCarDal(DbContext dbContext)
        //{
        //    context = dbContext;
        //}
        //public void Add(Car entity)
        //{
        //    using (context)
        //    {
        //        var addedEntity = context.Entry(entity);
        //        addedEntity.State = EntityState.Added;
        //        context.SaveChanges();
        //    }
        //}

        //public void Delete(Car entity)
        //{
        //    using (context)
        //    {
        //        var deletedEntity = context.Entry(entity);
        //        deletedEntity.State = EntityState.Deleted;
        //        context.SaveChanges();
        //    }
        //}


        //public Car Get(Expression<Func<Car, bool>> filter)
        //{
        //    using (context)
        //    {
        //        return context.Set<Car>().SingleOrDefault(filter);
        //    }
        //}

      

        //public List<Car> GetAll(Expression<Func<Car, bool>> filter)
        //{
        //    using (context)
        //    {
        //        return filter == null
        //            ? context.Set<Car>().ToList()
        //            : context.Set<Car>().Where(filter).ToList();
        //    }
        //}

        //public void Update(Car entity)
        //{
        //    using (context)
        //    {
        //        var updatedEntity = context.Entry(entity);
        //        updatedEntity.State = EntityState.Modified;
        //        context.SaveChanges();
        //    }
        //}
    }
}
