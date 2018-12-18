using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductWebApplication.Services
{
    public class FileAccessLayer : IFileAccessLayer
    {
        private const string BaseUrl = "//drive.google.com/uc?id=";
        public string GetFileUrl(string fileName)
        {
            return $"{BaseUrl}{fileName}";
        }
    }

    public interface IFileAccessLayer
    {
        string GetFileUrl(string fileName);
    }
}
