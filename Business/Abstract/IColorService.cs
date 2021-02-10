using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IColorService
    {

        Color GetById(int id);
        List<Color> GetAll();
        void Add(Color color);
        void Delete(Color color);
        void Update(Color color);

    }
}
