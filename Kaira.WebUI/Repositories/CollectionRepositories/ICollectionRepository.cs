using Kaira.WebUI.Dtos;
using Kaira.WebUI.Dtos.CollectionDtos;

namespace Kaira.WebUI.Repositories.CollectionRepositories
{
    public interface ICollectionRepository
    {
        Task<IEnumerable<ResultCollectionDto>> GetAllAsync();
        Task<UpdateCollectionDto> GetByIdAsync(int id);
        Task CreateAsync(CreateCollectionDto dto);
        Task UpdateAsync(UpdateCollectionDto dto);
        Task DeleteAsync(int id);
    }
}
