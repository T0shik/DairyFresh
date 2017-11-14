using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Website.Data.FileManager
{
    public interface IFileManager
    {
        FileStream VideoStream(string id, string path);
        FileStream PictureStream(string id, string path);

        Task<string> SaveVideoAsync(string id, IFormFile video);
        bool RemoveVideo(string id, string path);
        Task<string> SavePictureAsync(string id, IFormFile picture);
        bool RemovePicture(string id, string path);
    }
}
