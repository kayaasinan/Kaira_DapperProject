using Kaira.WebUI.Repositories.TestimonialRepositories;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Kaira.WebUI.ViewComponents.UI_Home
{
    public class _UIHomeTestimonial(ITestimonialRepository _testimonialRepository) : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var testimonials = await _testimonialRepository.GetAllAsync();
            return View(testimonials);
        }
    }
}
