using Kaira.WebUI.Consts;
using Kaira.WebUI.Dtos.VideosDtos;
using Kaira.WebUI.Repositories.VideoRepositories;
using Microsoft.AspNetCore.Mvc;

namespace Kaira.WebUI.Areas.Admin.Controllers
{
    [Area(Roles.Admin)]
    public class VideoController(IVideoRepository _videoRepository) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var videos = await _videoRepository.GetAllAsync();
            return View(videos);
        }
        public IActionResult CreateVideo()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateVideo(CreateVideoDto dto)
        {
            await _videoRepository.CreateAsync(dto);
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> UpdateVideo(int id)
        {
            var video = await _videoRepository.GetByIdAsync(id);
            return View(video);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateVideo(UpdateVideoDto dto)
        {
            await _videoRepository.UpdateAsync(dto);
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> DeleteVideo(int id)
        {
            await _videoRepository.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
