
using Kaira.WebUI.Consts;
using Kaira.WebUI.Dtos.OpenAIDtos;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace Kaira.WebUI.Repositories.OpenAIRepositories
{
    public class OpenAIRepository : IOpenAIRepository
    {
        private readonly HttpClient _client;
        private readonly string _apiKey;

        private const string Model = "gpt-4o-mini";
        private const string BaseUrl = "https://api.openai.com/v1/chat/completions";
        public OpenAIRepository(HttpClient client, IConfiguration configuration)
        {
            _client = client;
            _apiKey = configuration["OpenAI:ApiKey"];
        }
        public async Task<string> GenerateStyleAsync(string prompt)
        {
            var finalPrompt = StylePromptBuilder.Build(prompt);

  
            var requestBody = new OpenAIRequestDto
            {
                model = Model,
                temperature = 0.7f,
                messages = new List<OpenAIMessageDto>
                {
                    new OpenAIMessageDto
                    {
                        role = "user",
                        content = finalPrompt
                    }
                }
            };

            var jsonContent = JsonConvert.SerializeObject(requestBody);
            var httpContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            _client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", _apiKey);

            var response = await _client.PostAsync(BaseUrl, httpContent);

            if (!response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }

            var responseString = await response.Content.ReadAsStringAsync();
            var openAiResponse = JsonConvert.DeserializeObject<OpenAIResponseDto>(responseString);

            return openAiResponse?.choices?.FirstOrDefault()?.message?.content ?? "Yanıt alınamadı.";
        }
    }
}
