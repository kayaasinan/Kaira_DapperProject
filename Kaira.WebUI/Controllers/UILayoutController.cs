using Microsoft.AspNetCore.Mvc;

namespace Kaira.WebUI.Controllers
{
    public class UILayoutController : Controller
    {
        public IActionResult Layout()
        {
            return View();
        }
    }
}
