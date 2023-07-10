using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace Etqaan.Application.Helpers
{
    public class FileHelper
    {

        public FileHelper()
        {
        }



        public static async Task<string> SaveImageAsync(IFormFile image, IHostingEnvironment _environment)
        {
            if (!Directory.Exists(_environment.WebRootPath + "/uploads/images/"))
            {
                Directory.CreateDirectory(_environment.WebRootPath + "/uploads/images/");
            }
            string ImagePath = "/uploads/images/" + RandomHelper.GenerateUniqueID(25) + Path.GetExtension(image.FileName).ToLower();
            using (FileStream filestream = File.Create(_environment.WebRootPath + ImagePath))
            {
                image.CopyTo(filestream);
                filestream.Flush();
                var fileExtention = Path.GetExtension(image.FileName).ToLower();
            }
            return ImagePath;
        }

        public static void DeleteFile(string filePath, IHostingEnvironment _environment)
        {


            var fullPath = $"{_environment.WebRootPath}{filePath}";
            if (File.Exists(fullPath))
            {
                File.Delete(fullPath);
            }
        }

        public static string SaveVideo(IFormFile video, IHostingEnvironment _environment)
        {
            if (!Directory.Exists(_environment.WebRootPath + "/uploads/videos/"))
            {
                Directory.CreateDirectory(_environment.WebRootPath + "/uploads/videos/");
            }
            string magePath = "/uploads/videos/" + RandomHelper.GenerateUniqueID(25) + Path.GetExtension(video.FileName).ToLower();
            using (FileStream filestream = File.Create(_environment.WebRootPath + magePath))
            {
                video.CopyTo(filestream);
                filestream.Flush();
                var fileExtention = Path.GetExtension(video.FileName).ToLower();
            }
            return magePath;
        }
        //public static async Task<TimeSpan> GetVideoDuration(string FilePath, IHostingEnvironment _environment)
        //{
        //    var fullPath = $"{_environment.WebRootPath}{FilePath}";

        //    var ffProbe = new NReco.VideoInfo.FFProbe();
        //    var videoInfo = ffProbe.GetMediaInfo(fullPath);

        //    if (videoInfo.FormatName.Contains("mp4") || videoInfo.FormatName.Contains("mp3"))
        //    {
        //        return videoInfo.Duration;
        //    }
        //    else
        //    {
        //        return TimeSpan.FromHours(1); // Return a default duration of one hour if the file is not a video
        //    }
        //}


        public static async Task<string> SaveFileAsync(IFormFile file, IHostingEnvironment _environment)
        {
            if (!Directory.Exists(_environment.WebRootPath + "/uploads/AttachedFiles/"))
            {
                Directory.CreateDirectory(_environment.WebRootPath + "/uploads/AttachedFiles/");
            }
            string ImagePath = "/uploads/AttachedFiles/" + RandomHelper.GenerateUniqueID(25) + Path.GetExtension(file.FileName).ToLower();
            using (FileStream filestream = File.Create(_environment.WebRootPath + ImagePath))
            {
                file.CopyTo(filestream);
                filestream.Flush();
                var fileExtention = Path.GetExtension(file.FileName).ToLower();
            }
            return ImagePath;
        }
    }
}
