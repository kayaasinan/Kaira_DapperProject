using Kaira.WebUI.Consts;
using Kaira.WebUI.Dtos.CategoryDtos;
using Kaira.WebUI.Repositories.CategoryRepositories;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using X.PagedList.Extensions;

namespace Kaira.WebUI.Areas.Admin.Controllers
{
    [Area(Roles.Admin)]
    public class CategoryController(ICategoryReposiyory _categoryReposiyory) : Controller
    {
        public async Task<IActionResult> Index(int page = 1, int pageSize = 4)
        {
            var categories = await _categoryReposiyory.GetAllAsync();
            var pagedList = categories.ToPagedList(page, pageSize);
            return View(pagedList);
        }
        public IActionResult CreateCategory()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryDto dto)
        {
            await _categoryReposiyory.CreateAsync(dto);
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> UpdateCategory(int id)
        {
            var category = await _categoryReposiyory.GetByIdAsync(id);
            return View(category);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryDto dto)
        {
            await _categoryReposiyory.UpdateAsync(dto);
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> DeleteCategory(int id)
        {
            await _categoryReposiyory.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
