using Kaira.WebUI.Dtos.VideosDtos;

namespace Kaira.WebUI.Repositories.VideoRepositories
{
    public interface IVideoRepository
    {
        Task<IEnumerable<ResultVideoDto>> GetAllAsync();
        Task<UpdateVideoDto> GetByIdAsync(int id);
        Task CreateAsync(CreateVideoDto dto);
        Task UpdateAsync(UpdateVideoDto dto);
        Task DeleteAsync(int id);
    }
}
