using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using SecondHandMarketApp.Data;
using SecondHandMarketApp.Models;


namespace SecondHandMarketApp.Services
{
    public interface IImageSevice
    {
        Task Create(Image imageModel);
    }

    public class ImageService : IImageSevice
    {
        private readonly AppDbContext _db;
        private readonly IWebHostEnvironment _hostEnvironment;

        public ImageService(AppDbContext db,IWebHostEnvironment hostEnvironment)
        {
            _db = db;
            _hostEnvironment = hostEnvironment;
        }

        public async Task Create(Image imageModel)
        {
            string wwwRootPath = _hostEnvironment.WebRootPath;
            string fileName = Path.GetFileNameWithoutExtension(imageModel.ImageFile.FileName);
            string extension = Path.GetExtension(imageModel.ImageFile.FileName);
            imageModel.ImageName = fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
            string path = Path.Combine(wwwRootPath + "/images/", fileName);
            using (var fileStream = new FileStream(path, FileMode.Create))
            {
                await imageModel.ImageFile.CopyToAsync(fileStream);
            }
            _db.Add(imageModel);
            await _db.SaveChangesAsync();
        }
    }
}
