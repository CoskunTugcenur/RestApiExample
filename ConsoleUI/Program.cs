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
           
            CarManager carManager = new CarManager(new EfCarDal());

            carManager.Add(new Car { BrandId = 7, ColorId = 6, Name = "BMW", DailyPrice = 2500, Description = "1000km", ModelYear = "2010" });



            foreach (var item in carManager.GetAll())
            {
                Console.WriteLine(item.Name + "\t Year : " + item.DailyPrice);
            }


            //Console.WriteLine("########################## IDSI 1 OLAN ARABA BILGILERI ##########################");

            Car car = carManager.GetById(1);

            Console.WriteLine("BRAND ID : " + car.BrandId);
            Console.WriteLine("COLOR ID : " + car.ColorId);
            Console.WriteLine("DAILY PRICE : " + car.DailyPrice);
            Console.WriteLine("DESCRIPTION : " + car.Description);
            Console.WriteLine("MODEL YEAR : "+ car.ModelYear);

            //Console.WriteLine("########################## SON ##########################");
        }
    }
}
