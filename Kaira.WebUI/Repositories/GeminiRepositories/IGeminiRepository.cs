namespace Kaira.WebUI.Repositories.GeminiRepositories
{
    public interface IGeminiRepository
    {
        Task<string> GetGeminiDataAsync(string prompt);
    }
}
