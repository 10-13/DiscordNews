using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using JNogueira.Discord.Webhook.Client;

namespace V10_13News.News
{
    public class NewsMain
    {
        [JsonProperty("title")]
        public string Title { get; set; } = "No title";

        [JsonProperty("description")]
        public string Description { get; set; } = null;

        [JsonProperty("titleURL")]
        public string URL { get; set; } = null;

        [JsonProperty("author")]
        public DiscordMessageEmbedFooter AuthorFooter { get; set; } = null;

        [JsonProperty("newsTexts")]
        public List<DiscordMessage> TextData { get; set; } = new List<DiscordMessage>();

        [JsonProperty("color")]
        public int? Color { get; set; } = null;

        [JsonProperty("preDescription")]
        public DiscordMessageEmbedAuthor PreDescription { get; set; } = null;

        public NewsMain()
        {

        }

        public void Validate()
        {
            if (string.IsNullOrEmpty(Description))
                Description = null;
            if (string.IsNullOrEmpty(Title))
                Title = null;
            if (string.IsNullOrEmpty(URL))
                URL = null;
            if (AuthorFooter != null)
                if (AuthorFooter.Invalido)
                    AuthorFooter = null;
            for(int i = 0;i < TextData.Count;i++)
            {
                if (TextData[i].Invalido)
                    TextData.RemoveAt(i--);
            }
        }
        public void SendToClient(in DiscordWebhookClient client)
        {
            var msg = new DiscordMessage(
                embeds: new DiscordMessageEmbed[]
                {
                    new DiscordMessageEmbed(
                        title: Title,
                        description: Description,
                        url: URL,
                        color: Color,
                        author: PreDescription
                        )
                }
                );
            client.SendToDiscord(msg);
            foreach (var item in TextData)
                client.SendToDiscord(item);
        }
    }
}
