using Kaira.WebUI.Dtos.CollectionDtos;
using Kaira.WebUI.Repositories.CollectionRepositories;
using Microsoft.AspNetCore.Mvc;

namespace Kaira.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CollectionController(ICollectionRepository _collectionRepository) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var categories = await _collectionRepository.GetAllAsync();
            return View(categories);
        }
        public IActionResult CreateCollection()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateCollection(CreateCollectionDto dto)
        {
            await _collectionRepository.CreateAsync(dto);
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> UpdateCollection(int id)
        {
            var collection = await _collectionRepository.GetByIdAsync(id);
            return View(collection);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateCollection(UpdateCollectionDto dto)
        {
            await _collectionRepository.UpdateAsync(dto);
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> DeleteCollection(int id)
        {
            await _collectionRepository.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
