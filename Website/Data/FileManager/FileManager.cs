using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace Website.Data.FileManager
{
    public class FileManager : IFileManager
    {
        private IConfigurationRoot _config;
        private string _picturepath;
        private string _videopath;

        public FileManager(IConfigurationRoot config)
        {
            _config = config;
            _picturepath = _config["Path:I:Picture"];
            _videopath = _config["Path:Video"];

        }

        public FileStream VideoStream(string id, string path)
        {
            var fileStream = new FileStream($"{_videopath}{id}/{path}",
                      FileMode.Open,
                      FileAccess.Read);

            return fileStream;
        }

        public FileStream PictureStream(string id, string path)
        {
            var fileStream = new FileStream($"{_picturepath}{id}/{path}",
                   FileMode.Open,
                   FileAccess.Read);

            return fileStream;
        }

        public bool RemovePicture(string id, string path)
        {
            throw new NotImplementedException();
        }

        public bool RemoveVideo(string id, string path)
        {
            throw new NotImplementedException();
        }

        public async Task<string> SavePictureAsync(string id, IFormFile picture)
        {
            try
            {
                var save_path = Path.Combine(_picturepath, id);
                if (!Directory.Exists(save_path))
                {
                    Directory.CreateDirectory(save_path);
                }
                var user_path = Path.Combine(id, picture.FileName == "" ? "Default" : picture.FileName);
                var final_path = Path.Combine(_picturepath, user_path);
                using (var fileStream = new FileStream(final_path, FileMode.Create))
                {
                    await picture.CopyToAsync(fileStream);
                }
                
                return user_path;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error: {e.Message}");
                return $"Error: {e.Message}";
            }
        }

        public async Task<string> SaveVideoAsync(string id, IFormFile video)
        {
            try
            {
                var save_path = Path.Combine(_videopath, id);
                if (!Directory.Exists(save_path))
                {
                    Directory.CreateDirectory(save_path);
                }
                var match_path = Path.Combine(id, video.FileName == "" ? "Default" : video.FileName);
                var final_path = Path.Combine(_videopath, match_path);
                using (var fileStream = new FileStream(final_path, FileMode.Create))
                {
                    await video.CopyToAsync(fileStream);
                }

                return match_path;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error: {e.Message}");
                return $"Error: {e.Message}";
            }
        }

    }
}
