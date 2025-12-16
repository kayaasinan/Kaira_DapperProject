using Kaira.WebUI.Dtos.ProductDtos;

namespace Kaira.WebUI.Repositories.ProductRepositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<ResultProductDto>> GetAllAsync();
        Task<IEnumerable<ResultProductDto>> GetAccesoryByCategoryIdAsync(int id);
        Task<IEnumerable<ResultProductDto>> GetLast5ProductAsync();
        Task<IEnumerable<ResultProductDto>> GetMinPrice6ProductsAsync();
        Task<IEnumerable<ResultProductDto>> GetRandom5ProductsAsync();
        Task<UpdateProductDto> GetByIdAsync(int id);
        Task CreateAsync(CreateProductDto dto);
        Task UpdateAsync(UpdateProductDto dto);
        Task DeleteAsync(int id);
    }
}
