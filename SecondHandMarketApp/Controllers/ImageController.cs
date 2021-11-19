using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SecondHandMarketApp.Data;
using SecondHandMarketApp.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using SecondHandMarketApp.Services;

namespace SecondHandMarketApp.Controllers
{
    //TODO: Rewrite from scratch
    public class ImageController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IItemService _itemService;
        private readonly IImageSevice _imageService;

        public ImageController(AppDbContext context,IItemService itemService, IImageSevice imageService)
        {
            _context = context;
            _itemService = itemService;
            _imageService = imageService;
        }

        // GET: Image
        public async Task<IActionResult> Index()
        {
            return View(await _context.Images.ToListAsync());
        }

        // GET: Image/Details/5
        public async Task<IActionResult> Details(Guid id)
        {
         

            var image = await _context.Images
                .FirstOrDefaultAsync(m => m.ImageId == id);
            if (image == null)
            {
                return NotFound();
            }

            return View(image);
        }
        public IActionResult Create()
        {
            ViewBag.ItemId = new SelectList(_itemService.GetAllItemsWithoutImages(), "Id", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ImageId,ImageFile,ItemId")]Image imageModel)
        {
            if (ModelState.IsValid)
            {
                await _imageService.Create(imageModel);
                return RedirectToAction("Index");
            }
            return View(imageModel);
        }

        // GET: Image/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var image = await _context.Images.FindAsync(id);
            if (image == null)
            {
                return NotFound();
            }
            return View(image);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("ImageId,ImageName")] Image image)
        {
            if (id != image.ImageId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(image);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ImageExists(image.ImageId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(image);
        }

        // GET: Image/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var image = await _context.Images
                .FirstOrDefaultAsync(m => m.ImageId == id);
            if (image == null)
            {
                return NotFound();
            }

            return View(image);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var image = await _context.Images.FindAsync(id);
            _context.Images.Remove(image);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ImageExists(Guid id)
        {
            return _context.Images.Any(e => e.ImageId == id);
        }
    }
}
