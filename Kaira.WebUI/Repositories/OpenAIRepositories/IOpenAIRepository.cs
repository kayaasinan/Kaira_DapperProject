namespace Kaira.WebUI.Repositories.OpenAIRepositories
{
    public interface IOpenAIRepository
    {
        Task<string> GenerateStyleAsync(string prompt);
    }
}
