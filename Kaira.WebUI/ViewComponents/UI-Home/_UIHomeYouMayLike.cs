using Kaira.WebUI.Repositories.ProductRepositories;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Kaira.WebUI.ViewComponents.UI_Home
{
    public class _UIHomeYouMayLike(IProductRepository _productRepository) : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var products = await _productRepository.GetRandom5ProductsAsync();
            return View(products);
        }
    }
}
