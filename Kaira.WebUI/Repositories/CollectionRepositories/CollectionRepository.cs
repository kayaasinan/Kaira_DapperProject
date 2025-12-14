using Dapper;
using Kaira.WebUI.Context;
using Kaira.WebUI.Dtos.CollectionDtos;
using System.Data;

namespace Kaira.WebUI.Repositories.CollectionRepositories
{
    public class CollectionRepository(AppDbContext context) : ICollectionRepository
    {
        private readonly IDbConnection _db = context.CreateConnection();
        public async Task CreateAsync(CreateCollectionDto dto)
        {
            string query = "insert into Collections (Title,ImageUrl,Description) VALUES (@Title,@ImageUrl,@Description)";
            var parameters = new DynamicParameters(dto);
            await _db.ExecuteAsync(query, parameters);
        }

        public async Task DeleteAsync(int id)
        {
            string query = "delete from collections where CollectionId = @CollectionId";
            var parameters = new DynamicParameters();
            parameters.Add("@CollectionId", id);
            await _db.ExecuteAsync(query, parameters);
        }

        public async Task<IEnumerable<ResultCollectionDto>> GetAllAsync()
        {
            string query = "select * from collections";
            return await _db.QueryAsync<ResultCollectionDto>(query);
        }

        public async Task<UpdateCollectionDto> GetByIdAsync(int id)
        {
            string query = "select * from collections where CollectionId=@CollectionId";
            var parameters = new DynamicParameters();
            parameters.Add("@CollectionId", id);
            return await _db.QueryFirstOrDefaultAsync<UpdateCollectionDto>(query, parameters);
        }

        public async Task UpdateAsync(UpdateCollectionDto dto)
        {
            string query = "update Collections set Title=@Title,ImageUrl=@ImageUrl,Description=@Description where CollectionId=@CollectionId";
            var parameters = new DynamicParameters(dto);
            await _db.ExecuteAsync(query, parameters);
        }
    }
}
