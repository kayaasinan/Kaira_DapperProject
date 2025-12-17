using System.Diagnostics;
using Kaira.WebUI.Models;
using Kaira.WebUI.Repositories.GeminiRepositories;
using Microsoft.AspNetCore.Mvc;

namespace Kaira.WebUI.Controllers
{
    public class HomeController(IGeminiRepository _geminiRepository) : Controller
    {

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> GenerateStyle(string prompt)
        {
            if (string.IsNullOrWhiteSpace(prompt))
                return Content("Lütfen bir kombin açýklamasý giriniz.");

            var result = await _geminiRepository.GetGeminiDataAsync(prompt);
            return Content(result);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
