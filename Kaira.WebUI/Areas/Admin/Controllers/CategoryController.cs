using Kaira.WebUI.Repositories.CategoryRepositories;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Kaira.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController(ICategoryReposiyory _categoryReposiyory) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var categories = await _categoryReposiyory.GetAllAsync();
            return View(categories);
        }
    }
}
