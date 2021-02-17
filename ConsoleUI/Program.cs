using Entities.Concrete;
using System;
using System.Collections.Generic;
using Business.Concrete;
using DataAccess.Concrete;
using DataAccess.Concrete.EntityFramework;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //CarTest();

            //BrandTest();

            //ColorTest();

            //Test();
        }

        private static void Test()
        {
            UserManager userManager = new UserManager(new EfUserDal());
            userManager.Add(new User { FirstName = "Tu", LastName = "Co", Email = "aaa@g.com", Password = "aaaaa" });

            CompanyManager companyManager = new CompanyManager(new EfCompanyDal());
            companyManager.Add(new Company { Name = "TGC LTD." });

            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            customerManager.Add(new Customer { CompanyId = 1, UserId = 1 });
        }

        private static void ColorTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());

           
            colorManager.Add(new Color { Name = "Mavi" });
         
            Color color = colorManager.GetById(5).Data;

            Console.WriteLine(color.Id + color.Name);

            color.Name = "Blue";
            colorManager.Update(color);

            color = colorManager.GetById(5).Data;
            Console.WriteLine(color.Id + color.Name);
            
            colorManager.Delete(color);
            Console.WriteLine(color.Name + " silindi ");
        }

        private static void BrandTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());

            
            brandManager.Add(new Brand { Name = "Reno" });
            
            Brand brand = brandManager.GetById(10).Data;

            Console.WriteLine(brand.Id + brand.Name);

            
            brand.Name = "renault";
            brandManager.Update(brand);

            brand = brandManager.GetById(10).Data;
            Console.WriteLine(brand.Id + brand.Name);
          
            brandManager.Delete(brand);
            Console.WriteLine(brand.Name + "silindi ");
        }

        private static void CarTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());

        
            Car car = new Car();
            car.BrandId = 2;
            car.ColorId = 1;
            car.Name = "BMW i8";
            car.ModelYear = "2019";
            car.DailyPrice = 2500;
            car.Description = "Dizel";
            
            carManager.Add(car);

            Car car1=new Car();
           
            foreach (var item in carManager.GetAll().Data)
            {
                Console.WriteLine(item.Name + "\t Year : " + item.DailyPrice);
                car1 = item; //son elemanı car1'e atadık
            }

            foreach (var item in carManager.GetCarDetails().Data)
            {
                Console.WriteLine(item.CarName + "\t " + item.BrandName + "\t" + item.ColorName + "\t" + item.DailyPrice);
                
            }


         
            car1.Name = "BMW I8";
            carManager.Update(car1);

          
            carManager.Delete(car1);
            Console.WriteLine(car1.Name + "silindi ");

        }
    }
}
