using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class CarImage : IEntity
    {
        public string Id { get; set; }

        public int CarId { get; set; }

        public string ImageId { get; set; }

        public DateTime Date { get; set; }
    }
}
