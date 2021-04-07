using Core.Entities;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class CarDetailDto: Car, IDto
    {
        public string BrandName { get; set; }
  
        public string ColorName { get; set; }
       
        public CarImage[] CarImages { get; set; }

    }
}
