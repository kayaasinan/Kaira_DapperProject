using Microsoft.AspNetCore.Mvc;

namespace Kaira.WebUI.ViewComponents.UI_Home
{
    public class _UIHomeServices : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
