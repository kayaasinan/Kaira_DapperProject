using Kaira.WebUI.Repositories.ProductRepositories;
using Microsoft.AspNetCore.Mvc;

namespace Kaira.WebUI.ViewComponents.UI_Home
{
    public class _UIHomeBestSellers(IProductRepository _productRepository) : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var products = await _productRepository.GetMinPrice6ProductsAsync();
            return View(products);
        }
    }
}
