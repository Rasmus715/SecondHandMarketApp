using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SecondHandMarketApp.Data;
using SecondHandMarketApp.Models;
using SecondHandMarketApp.ViewModels.Item;

namespace SecondHandMarketApp.Services
{
    public interface IItemService
    { 
        IEnumerable<Item> GetAllItemsWithoutImages();
        IEnumerable<Item> GetAllItems();
        Task<Guid> AddItemAsync(Item item);
        DetailsItemViewModel GetItemById(Guid itemId);
        IEnumerable<Item> GetItemsSpecificForUser(Guid userId);
    }

    public class ItemService : IItemService
    {
        private readonly AppDbContext _db;

        public ItemService(AppDbContext db)
        {
            _db = db;
        }

        public IEnumerable<Item> GetAllItemsWithoutImages()
        {
            return _db.Items
                .AsNoTracking();
        }
        public IEnumerable<Item> GetAllItems()
        {
            return _db.Items
                .Include(u=> u.Images)
                .Include(u => u.Condition)
                .Include(u => u.Category)
                .AsNoTracking();
        }

        public async Task<Guid> AddItemAsync(Item item)
        {
            await _db.Items.AddAsync(item);
            await _db.SaveChangesAsync();
            return item.Id;
        }

        public DetailsItemViewModel GetItemById(Guid itemId)
        {
            //TODO: Change mapping algorithm
            return  _db.Items.Include(u => u.Images)
                .Include(u=>u.Category)
                .Include(u=>u.Condition)
                .Include(u =>u.User)
                .Where(u => u.Id == itemId)
                .AsNoTracking()
                .Select(u => new DetailsItemViewModel()
            {
                Name = u.Name,
                Category = u.Category.Name,
                Condition = u.Condition.Name,
                Price = u.Price,
                Images = u.Images,
                SellerPhoneNumber = u.User.PhoneNumber
            })
                .FirstOrDefault();
        }

        public IEnumerable<Item> GetItemsSpecificForUser(Guid userId)
        {
            return _db.Items.Where(u => u.UserId == userId)
                .Include(u=>u.Category)
                .Include(u=>u.Condition)
                .Include(u => u.Images)
                .AsNoTracking();
        }
    }
}
