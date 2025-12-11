using Dapper;
using Kaira.WebUI.Context;
using Kaira.WebUI.Dtos.CategoryDtos;
using System.Data;

namespace Kaira.WebUI.Repositories.CategoryRepositories
{
    public class CategoryRepository(AppDbContext context) : ICategoryReposiyory
    {
        private readonly IDbConnection _db = context.CreateConnection();
        public async Task CreateAsync(CreateCategoryDto dto)
        {
            string query = "insert into Categories (Name) VALUES (@Name)";
            var parameters = new DynamicParameters(dto);     
            await _db.ExecuteAsync(query, parameters);
        }

        public async Task DeleteAsync(int id)
        {
            string query = "delete from categories where CategoryId = @CategoryId";
            var parameters = new DynamicParameters();
            parameters.Add("@CategoryId", id);
            await _db.ExecuteAsync(query, parameters);
        }

        public async Task<IEnumerable<ResultCategoryDto>> GetAllAsync()
        {
            string query = "select * from categories";
            return await _db.QueryAsync<ResultCategoryDto>(query);
        }

        public async Task<UpdateCategoryDto> GetByIdAsync(int id)
        {
            string query = "select * from categories where CategoryId=@CategoryId";
            var parameters = new DynamicParameters();
            parameters.Add("@CategoryId", id);
            return await _db.QueryFirstOrDefaultAsync<UpdateCategoryDto>(query, parameters);
        }

        public async Task UpdateAsync(UpdateCategoryDto dto)
        {
            string query = "update categories set Name=@Name where CategoryId=@CategoryId";
            var parameters = new DynamicParameters(dto);
            await _db.ExecuteAsync(query, parameters);

        }
    }
}
