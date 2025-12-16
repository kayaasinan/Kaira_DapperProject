using Kaira.WebUI.Enums;
using Kaira.WebUI.Repositories.ProductRepositories;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Kaira.WebUI.ViewComponents.UI_Home
{
    public class _UIHomeAccessory(IProductRepository _productRepository) : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            var products = await _productRepository.GetAccesoryByCategoryIdAsync((int)ProductCategory.Aksesuar);
            return View(products);
        }
    }
}
