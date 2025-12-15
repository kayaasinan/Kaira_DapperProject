using Kaira.WebUI.Repositories.CollectionRepositories;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Kaira.WebUI.ViewComponents.UI_Home
{
    public class _UIHomeNewCollection(ICollectionRepository _collectionRepository) : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var collections = await _collectionRepository.GetAllAsync();
            return View(collections);
        }
    }
}
