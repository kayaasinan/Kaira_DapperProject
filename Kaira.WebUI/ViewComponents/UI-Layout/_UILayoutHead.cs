using Microsoft.AspNetCore.Mvc;

namespace Kaira.WebUI.ViewComponents.UI_Layout
{
    public class _UILayoutHead : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
