using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http.Headers;
using System.Text;
using Microsoft.AspNetCore.Http;
namespace Core.Utilities.FileHelper
{
    public class FileHelper
    {
        public static string SaveFile(IFormFile file)
        {
                var folderName = Path.Combine("Images", "CarImages");
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
                if (file.Length > 0)
                {
                    var fileName = Guid.NewGuid().ToString();
                    var fullPath = Path.Combine(pathToSave, fileName);
                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                    return fullPath;
                }
               
                 return null;
               
        }


        public static IResult DeleteFile(string path)
        {
            try
            {

                File.Delete(path);
                return new SuccessResult();
            }
            catch
            {
                return new ErrorResult();
            }
        }




    }
}
