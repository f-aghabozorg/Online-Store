using Online_Store.Application.Interfaces.Contexts;
using Online_Store.Application.Services.Products.Commands.AddNewProduct;
using Online_Store.Common.Dto;
using Online_Store.Domain.Entities.HomePages;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Online_Store.Application.Services.HomePages.Commands.AddHomePageImages
{
    public interface IAddHomePageImagesService
    {
        ResultDto Execute(requestAddHomePageImagesDto request);
    }


    public class AddHomePageImagesService : IAddHomePageImagesService
    {
        private readonly IDataBaseContext _context;
        private readonly IHostingEnvironment _environment;

        public AddHomePageImagesService(IDataBaseContext context, IHostingEnvironment hosting)
        {
            _context = context;
            _environment = hosting;
        }
        public ResultDto Execute(requestAddHomePageImagesDto request)
        {

            var resultUpload = UploadFile(request.file);

            HomePageImages homePageImages = new HomePageImages()
            {
                link = request.Link,
                Src = resultUpload.FileNameAddress,
                ImageLocation = request.ImageLocation,
            };
            _context.HomePageImages.Add(homePageImages);
            _context.SaveChanges();
            return new ResultDto()
            {
                IsSuccess = true,
            };
        }




        private UploadDto UploadFile(IFormFile file)
        {
            if (file != null)
            {
                string folder = $@"images\HomePages\HomePageImages\";
                var uploadsRootFolder = Path.Combine(_environment.WebRootPath, folder);
                if (!Directory.Exists(uploadsRootFolder))
                {
                    Directory.CreateDirectory(uploadsRootFolder);
                }


                if (file == null || file.Length == 0)
                {
                    return new UploadDto()
                    {
                        Status = false,
                        FileNameAddress = "",
                    };
                }



                string filePath = Path.Combine(uploadsRootFolder, file.FileName);
                if (File.Exists(filePath))
                    filePath = uploadsRootFolder + DateTime.Now.Ticks.ToString() + "-" + file.FileName;

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }

                return new UploadDto()
                {
                    FileNameAddress = folder + file.FileName,
                    Status = true,
                };
            }
            return null;
        }
    }

    public class requestAddHomePageImagesDto
    {
        public IFormFile file { get; set; }
        public string Link { get; set; }
        public ImageLocation ImageLocation { get; set; }
    }
}
