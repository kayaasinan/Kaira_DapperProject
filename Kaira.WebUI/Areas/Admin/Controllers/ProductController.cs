using Kaira.WebUI.Consts;
using Kaira.WebUI.Dtos.ProductDtos;
using Kaira.WebUI.Repositories.CategoryRepositories;
using Kaira.WebUI.Repositories.ProductRepositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Threading.Tasks;
using X.PagedList.Extensions;

namespace Kaira.WebUI.Areas.Admin.Controllers
{
    [Area(Roles.Admin)]
    public class ProductController(IProductRepository _productRepository,ICategoryReposiyory _categoryReposiyory) : Controller
    {
        private async Task GetCategoriesAsync()
        {
            var categoryList = await _categoryReposiyory.GetAllAsync();
            ViewBag.categories = (from c in categoryList
                                  select new SelectListItem
                                  {
                                      Text = c.Name,
                                      Value = c.CategoryId.ToString()

                                  }).ToList();
        }
        public async Task<IActionResult> Index(int page=1,int pageSize = 4)
        {
            var products = await _productRepository.GetAllAsync();
            var pagedList = products.ToPagedList(page, pageSize);
            return View(pagedList);
        }
        public async Task<IActionResult> CreateProduct()
        {
            await GetCategoriesAsync();
            return View();
        }   
        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductDto dto)
        {
            if (!ModelState.IsValid)
            {
                await GetCategoriesAsync();
                return View(dto);
            }
            await _productRepository.CreateAsync(dto);
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> DeleteProduct(int id)
        {
            await _productRepository.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> UpdateProduct(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            if (product == null)
                return RedirectToAction(nameof(Index));

            await GetCategoriesAsync();
            return View(product);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateProduct(UpdateProductDto dto)
        {
            if (!ModelState.IsValid)
            {
                await GetCategoriesAsync();
                return View(dto);
            }

            await _productRepository.UpdateAsync(dto);
            return RedirectToAction(nameof(Index));
        }
    }
}
