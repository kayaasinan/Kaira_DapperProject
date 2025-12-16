using Kaira.WebUI.Repositories.VideoRepositories;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Kaira.WebUI.ViewComponents.UI_Home
{
    public class _UIHomeVideos(IVideoRepository _videoRepository) : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var video = await _videoRepository.GetAllAsync();
            return View(video);
        }
    }
}
