using Dapper;
using Kaira.WebUI.Context;
using Kaira.WebUI.Dtos.CategoryDtos;
using Kaira.WebUI.Dtos.TestimonialDtos;
using System.Data;

namespace Kaira.WebUI.Repositories.TestimonialRepositories
{
    public class TestimonialRepository(AppDbContext context) : ITestimonialRepository
    {
        private readonly IDbConnection _db = context.CreateConnection();
        public async Task CreateAsync(CreateTestimonialDto dto)
        {
            var query = "insert into Testimonials (FullName,Comment) values (@FullName,@Comment)";
            var parameters = new DynamicParameters(dto);
            await _db.ExecuteAsync(query, parameters);
        }

        public async Task DeleteAsync(int id)
        {
            var query = "delete from Testimonials where TestimonialId = @TestimonialId";
            var parameters = new DynamicParameters();
            parameters.Add("@TestimonialId", id);
            await _db.ExecuteAsync(query, parameters);
        }

        public async Task<IEnumerable<ResultTestimonialDto>> GetAllAsync()
        {
            string query = "select * from Testimonials";
            return await _db.QueryAsync<ResultTestimonialDto>(query);
        }

        public async Task<UpdateTestimonialDto> GetByIdAsync(int id)
        {
            string query = "select * from Testimonials where TestimonialId=@TestimonialId";
            var parameters = new DynamicParameters();
            parameters.Add("@TestimonialId", id);
            return await _db.QueryFirstOrDefaultAsync<UpdateTestimonialDto>(query, parameters);
        }

        public async Task UpdateAsync(UpdateTestimonialDto dto)
        {
            string query = "update Testimonials set FullName=@FullName,Comment=@Comment where TestimonialId=@TestimonialId";
            var parameters = new DynamicParameters(dto);
            await _db.ExecuteAsync(query, parameters);
        }
    }
}
