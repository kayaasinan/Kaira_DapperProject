using Kaira.WebUI.Dtos.CategoryDtos;
using Kaira.WebUI.Dtos.TestimonialDtos;
using Kaira.WebUI.Repositories.TestimonialRepositories;
using Microsoft.AspNetCore.Mvc;

namespace Kaira.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TestimonialController(ITestimonialRepository _testimonialRepository) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var testimonials = await _testimonialRepository.GetAllAsync();
            return View(testimonials);
        }
        public IActionResult CreateTestimonial()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateTestimonial(CreateTestimonialDto dto)
        {
            await _testimonialRepository.CreateAsync(dto);
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> UpdateTestimonial(int id)
        {
            var testimonial = await _testimonialRepository.GetByIdAsync(id);
            return View(testimonial);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateTestimonial(UpdateTestimonialDto dto)
        {
            await _testimonialRepository.UpdateAsync(dto);
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> DeleteTestimonial(int id)
        {
            await _testimonialRepository.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
