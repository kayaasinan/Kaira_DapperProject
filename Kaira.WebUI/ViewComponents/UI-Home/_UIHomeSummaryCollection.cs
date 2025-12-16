using Kaira.WebUI.Repositories.ProductRepositories;
using Microsoft.AspNetCore.Mvc;

namespace Kaira.WebUI.ViewComponents.UI_Home
{
    public class _UIHomeSummaryCollection: ViewComponent
    {
        public  IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
