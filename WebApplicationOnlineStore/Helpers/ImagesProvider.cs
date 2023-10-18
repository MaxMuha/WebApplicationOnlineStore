﻿
namespace WebApplicationOnlineStore.Helpers
{
    public class ImagesProvider
    {
        private readonly IWebHostEnvironment appEnvironment;

        public ImagesProvider(IWebHostEnvironment appenvironment)
        {
            this.appEnvironment = appenvironment;
        }

        public List<string> SafeFiles(IFormFile[] files, ImageFolders folder)
        {
            var imagesPaths = new List<string>();
            foreach (var file in files)
            {
                var imagePath = SafeFile(file, folder);
                imagesPaths.Add(imagePath);
            }
            return imagesPaths;
        }

        public string SafeFile(IFormFile file, ImageFolders folder)
        {
            if(file != null)
            {
                var folderPath = Path.Combine(appEnvironment.WebRootPath + "/images/" + folder);
                if(!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }

                var fileName = Guid.NewGuid() + "." + file.FileName.Split('.').Last();
                string path = Path.Combine(folderPath, fileName);
                using(var fileStream = new FileStream(path, FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }

                return "/images/" + folder + "/" + fileName;
            }
            return null;
        }
    }
}