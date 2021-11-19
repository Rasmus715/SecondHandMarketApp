using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using SecondHandMarketApp.Models;
using SecondHandMarketApp.Services;
using SecondHandMarketApp.ViewModels.Item;
using System;

namespace SecondHandMarketApp.Controllers
{
    public class ItemController : Controller
    {
        private readonly IItemService _itemService;
        private readonly IConditionService _conditionService;
        private readonly ICategoryService _categoryService;
        private readonly IImageSevice _imageService;

        public ItemController(IItemService itemService, ICategoryService categoryService, IConditionService conditionService, IImageSevice imageService)
        {
            _itemService = itemService;
            _conditionService = conditionService;
            _categoryService = categoryService;
            _imageService = imageService;
        }
        public IActionResult Index()
        {
            return View(_itemService.GetAllItems());
        }

        public async Task<IActionResult> Create()
        {
            //TODO: Make async
            ViewBag.CategoryList = new SelectList(_categoryService.GetAllICategories(), "Id", "Name");
            ViewBag.ConditionList = new SelectList(await _conditionService.GetAllIConditions(), "Id", "Name");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateItemViewModel itemViewModel)
        {
            //TODO: Put to service
            var item = new Item()
            {
                Category = itemViewModel.Category,
                CategoryId = itemViewModel.CategoryId,
                ConditionId = itemViewModel.ConditionId,
                Condition = itemViewModel.Condition,
                Description = itemViewModel.Description,
                Name = itemViewModel.Name,
                Price = itemViewModel.Price,
                NumberViewsCount = 0,
                UserId = Guid.Parse(User.FindFirst("Id")?.Value),
            };
            var itemId = await _itemService.AddItemAsync(item);

            var image = new Image()
            {
                ItemId = itemId,
                ImageFile = itemViewModel.ImageFile
            };

            await _imageService.Create(image);
            return RedirectToAction("Index");
        }

        public IActionResult Details(Guid itemId)
        {
            return View(_itemService.GetItemById(itemId));
        }

        public IActionResult MyAds(Guid userId)
        {
            return View(_itemService.GetItemsSpecificForUser(userId));
        }
    }
}
