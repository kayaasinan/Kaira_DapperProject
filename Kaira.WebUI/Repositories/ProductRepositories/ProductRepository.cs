using Dapper;
using Kaira.WebUI.Context;
using Kaira.WebUI.Dtos.ProductDtos;
using System.Data;

namespace Kaira.WebUI.Repositories.ProductRepositories
{
    public class ProductRepository(AppDbContext context) : IProductRepository
    {
        private readonly IDbConnection _db = context.CreateConnection();
        public async Task CreateAsync(CreateProductDto dto)
        {
            var query = "insert into Products (Name,ImageUrl,Description,Price,CategoryId) values (@Name,@ImageUrl,@Description,@Price,@CategoryId)";
            var parameters = new DynamicParameters(dto);
            await _db.ExecuteAsync(query, parameters);
        }

        public async Task DeleteAsync(int id)
        {
            var query = "delete from Products where ProductId = @ProductId";
            var parameters = new DynamicParameters();
            parameters.Add("@ProductId", id);
            await _db.ExecuteAsync(query, parameters);
        }

        public async Task<IEnumerable<ResultProductDto>> GetAllAsync()
        {
            var query = "select p.Name,c.Name as categoryName,Price,ImageUrl,Description,ProductId from Products as p inner join categories as c on c.CategoryId=p.CategoryId";
            return await _db.QueryAsync<ResultProductDto>(query);
        }

        public async Task<UpdateProductDto> GetByIdAsync(int id)
        {
            var query = "select * from Products where ProductId=@ProductId";
            var parameters = new DynamicParameters();
            parameters.Add("@ProductId", id);
            return await _db.QueryFirstOrDefaultAsync<UpdateProductDto>(query, parameters);
        }

        public async Task UpdateAsync(UpdateProductDto dto)
        {
            var query = "update Products set Name=@Name,ImageUrl=@ImageUrl,Description=@Description,Price=@Price,CategoryId=@CategoryId where ProductId=@ProductId";
            var parameters = new DynamicParameters(dto);
            await _db.ExecuteAsync(query, parameters);
        }
    }
}
