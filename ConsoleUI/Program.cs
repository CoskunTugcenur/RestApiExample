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
            CarTest();

            //BrandTest();

            //ColorTest();
        }

        private static void ColorTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());

            /*
             * Add
             */
            colorManager.Add(new Color { Name = "Mavi" });
            /*
             * Read
             */
            Color color = colorManager.GetById(5).Data;

            Console.WriteLine(color.Id + color.Name);

            /*
             * Update
             */
            color.Name = "Blue";
            colorManager.Update(color);

            color = colorManager.GetById(5).Data;
            Console.WriteLine(color.Id + color.Name);
            /*
             * Delete
             */
            colorManager.Delete(color);
            Console.WriteLine(color.Name + " silindi ");
        }

        private static void BrandTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());

            /*
             * Add
             */
            brandManager.Add(new Brand { Name = "Reno" });
            /*
             * Read
             */
            Brand brand = brandManager.GetById(10).Data;

            Console.WriteLine(brand.Id + brand.Name);

            /*
             * Update
             */
            brand.Name = "renault";
            brandManager.Update(brand);

            brand = brandManager.GetById(10).Data;
            Console.WriteLine(brand.Id + brand.Name);
            /*
             * Delete
             */
            brandManager.Delete(brand);
            Console.WriteLine(brand.Name + "silindi ");
        }

        private static void CarTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            /*
            * Add
            */

            Car car = new Car();
            car.BrandId = 2;
            car.ColorId = 1;
            car.Name = "BMW i8";
            car.ModelYear = "2019";
            car.DailyPrice = 2500;
            car.Description = "Dizel";
            
            carManager.Add(car);

            Car car1=new Car();
            /*
             * Read
             */
            foreach (var item in carManager.GetAll().Data)
            {
                Console.WriteLine(item.Name + "\t Year : " + item.DailyPrice);
                car1 = item; //son elemanı car1'e atadık
            }

            foreach (var item in carManager.GetCarDetails().Data)
            {
                Console.WriteLine(item.CarName + "\t " + item.BrandName + "\t" + item.ColorName + "\t" + item.DailyPrice);
                
            }


            /*
             * Update
             */
            car1.Name = "BMW I8";
            carManager.Update(car1);

          
            /*
             * Delete
             */
            carManager.Delete(car1);
            Console.WriteLine(car1.Name + "silindi ");

        }

        

        
    }
}
