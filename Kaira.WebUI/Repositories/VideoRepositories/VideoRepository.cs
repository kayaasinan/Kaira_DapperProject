using Dapper;
using Kaira.WebUI.Context;
using Kaira.WebUI.Dtos.TestimonialDtos;
using Kaira.WebUI.Dtos.VideosDtos;
using System.Data;

namespace Kaira.WebUI.Repositories.VideoRepositories
{
    public class VideoRepository(AppDbContext context) : IVideoRepository
    {
        private readonly IDbConnection _db = context.CreateConnection();
        public async Task CreateAsync(CreateVideoDto dto)
        {
            var query = "insert into Videos (Url,BackgroundImageUrl) values (@Url,@BackgroundImageUrl)";
            var parameters = new DynamicParameters(dto);
            await _db.ExecuteAsync(query, parameters);
        }

        public async Task DeleteAsync(int id)
        {
            var query = "delete from Videos where VideoId = @VideoId";
            var parameters = new DynamicParameters();
            parameters.Add("@VideoId", id);
            await _db.ExecuteAsync(query, parameters);
        }

        public async Task<IEnumerable<ResultVideoDto>> GetAllAsync()
        {
            string query = "select * from Videos";
            return await _db.QueryAsync<ResultVideoDto>(query);
        }

        public async Task<UpdateVideoDto> GetByIdAsync(int id)
        {
            string query = "select * from Videos where VideoId=@VideoId";
            var parameters = new DynamicParameters();
            parameters.Add("@VideoId", id);
            return await _db.QueryFirstOrDefaultAsync<UpdateVideoDto>(query, parameters);
        }

        public async Task UpdateAsync(UpdateVideoDto dto)
        {
            string query = "update Videos set Url=@Url,BackgroundImageUrl=@BackgroundImageUrl where VideoId=@VideoId";
            var parameters = new DynamicParameters(dto);
            await _db.ExecuteAsync(query, parameters);
        }
    }
}
