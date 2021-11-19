using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using SecondHandMarketApp.Data;
using SecondHandMarketApp.Models;

namespace SecondHandMarketApp.Services
{
    public interface ICategoryService
    {
        IEnumerable<Category> GetAllICategories();
    }

    public class CategoryService : ICategoryService
    {
        private readonly AppDbContext _db;

        public CategoryService(AppDbContext db)
        {
            _db = db;
        }

        public IEnumerable<Category> GetAllICategories()
        {
            return _db.Categories.AsNoTracking();
        }
    }
}