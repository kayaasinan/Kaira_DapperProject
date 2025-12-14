using Microsoft.AspNetCore.Mvc;

namespace Kaira.WebUI.ViewComponents.Admin_Layout
{
    public class _AdminLayoutScriptComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
