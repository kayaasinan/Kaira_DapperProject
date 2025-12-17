using Kaira.WebUI.Consts;
using Kaira.WebUI.Repositories.OpenAIRepositories;
using Microsoft.AspNetCore.Mvc;

namespace Kaira.WebUI.Areas.Admin.Controllers
{
    [Area(Roles.Admin)]
    public class AIController(IOpenAIRepository _openAIRepository) : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> GenerateStyle(string prompt)
        {
            if (string.IsNullOrWhiteSpace(prompt))
                return Content("Lütfen bir kombin isteği giriniz.");

            var result = await _openAIRepository.GenerateStyleAsync(prompt);

            return Content(result);
        }
    }
}
