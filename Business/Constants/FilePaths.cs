using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Business.Constants
{
    public static class FilePaths
    {
        public static string carImagesPath = Path.Combine(Directory.GetCurrentDirectory(), Path.Combine("Images", "CarImages"));

        public static string logoImagePath = carImagesPath +"\\carDefault.png";
    }
}
