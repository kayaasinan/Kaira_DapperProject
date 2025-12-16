using Microsoft.AspNetCore.Mvc;

namespace Kaira.WebUI.ViewComponents.UI_Home
{
    public class _UIHomeNewsletter : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
