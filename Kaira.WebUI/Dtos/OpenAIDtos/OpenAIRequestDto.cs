namespace Kaira.WebUI.Dtos.OpenAIDtos
{
    public class OpenAIRequestDto
    {
        public string model { get; set; }
        public List<OpenAIMessageDto> messages { get; set; }
        public float temperature { get; set; }
    }
}
