using Kaira.WebUI.Dtos.CategoryDtos;

namespace Kaira.WebUI.Repositories.CategoryRepositories
{
    public interface ICategoryReposiyory
    {
        Task<IEnumerable<ResultCategoryDto>> GetAllAsync();
        Task<UpdateCategoryDto> GetByIdAsync(int id);
        Task CreateAsync(CreateCategoryDto dto);
        Task UpdateAsync(UpdateCategoryDto dto);
        Task DeleteAsync(int id);
    }
}
