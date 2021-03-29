using Core.Entities;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class CarDetailDto:IDto
    {
        public string CarName { get; set; }
        public int BrandId { get; set; }
        public string BrandName { get; set; }

        public int ColorId { get; set; }
        public string ColorName { get; set; }
        public double DailyPrice { get; set; }

        public CarImage[] CarImages { get; set; }

    }
}
