using Microsoft.AspNetCore.Mvc;

namespace Kaira.WebUI.ViewComponents.UI_Layout
{
    public class _UILayoutScript : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
