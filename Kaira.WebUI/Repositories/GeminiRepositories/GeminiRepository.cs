
using Kaira.WebUI.Dtos.GeminiDtos;
using Newtonsoft.Json;
using System.Text;

namespace Kaira.WebUI.Repositories.GeminiRepositories
{
    public class GeminiRepository : IGeminiRepository
    {
        private readonly HttpClient _client;
        private readonly string _apiKey;
        private const string Model = "gemini-2.5-flash";
        private const string BaseUrl = "https://generativelanguage.googleapis.com/v1beta/models/";
        public GeminiRepository(HttpClient client, IConfiguration configuration)
        {
            _client = client;
            _apiKey = configuration["Gemini:ApiKey"];
        }
        public async Task<string> GetGeminiDataAsync(string prompt)
        {
            var finalPrompt = "Sen profesyonel bir moda stil danışmanısın.\n\n" + "Kurallar:\n" + "- En fazla 5 parça öner\n" + "- Madde madde yaz\n" + "- Marka ismi kullanma\n" + "- Sonda kısa bir stil notu ekle\n" + "- Türkçe yaz\n\n" + "Kullanıcı isteği:\n" + prompt;

            var requestBody = new GeminiRequestDto
            {
                contents = new List<Content>
                {
                    new Content
                    {
                        role="user",
                        parts=new List<Part>
                        {
                            new Part
                            {
                                text=finalPrompt
                            }
                        }
                    }
                },
                generationConfig = new GenerationConfig
                {
                    temperature = 0.7f,
                    maxOutputTokens = 10000,
                }
            };
            var jsonContent = JsonConvert.SerializeObject(requestBody);
            var httpContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            var url = $"{BaseUrl}{Model}:generateContent?key={_apiKey}";
            var response = await _client.PostAsync(url, httpContent);
            if (!response.IsSuccessStatusCode)
            {
                var message = await response.Content.ReadAsStringAsync();
                return message;
            }
            var responseString = await response.Content.ReadAsStringAsync();
            var geminiResponse = JsonConvert.DeserializeObject<GeminiResponseDto>(responseString);

            return geminiResponse?.candidates?.FirstOrDefault()?.content?.parts?.FirstOrDefault()?.text
            ?? "Yanıt alınamadı.";
        }
    }
}
