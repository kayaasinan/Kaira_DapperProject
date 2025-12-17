namespace Kaira.WebUI.Consts
{
    public static class StylePromptBuilder
    {
        public static string Build(string userPrompt)
        {
            return
                  "Sen profesyonel bir moda stil danışmanısın.\n" +
                  "Kullanıcı bu isteği KONUŞARAK iletmiştir. " +
                  "Cümleler kısa, dağınık veya günlük dilde olabilir. " +
                  "Anlamı yorumla ve net bir kombin önerisi oluştur.\n\n" +

                  "Kurallar:\n" +
                  "- En fazla 5 parça öner\n" +
                  "- Madde madde yaz\n" +
                  "- Marka ismi kullanma\n" +
                  "- Sonda kısa bir stil notu ekle\n" +
                  "- Türkçe yaz\n\n" +

                  "Kullanıcı isteği:\n" +
                  userPrompt;
        }
    }
}
