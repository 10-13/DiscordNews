using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using JNogueira.Discord.Webhook.Client;

namespace V10_13News.News
{
    public enum DataMode
    {
        FooterImage,
        TitledImage,
        LinkedFooterImage,
        Text,
        FullMessage,
        Embed
    }

    public class NewsMain
    {
        [JsonProperty("title")]
        public string Title { get; set; } = "No title";

        [JsonProperty("description")]
        public string Description { get; set; } = null;

        [JsonProperty("imageURL")]
        public string URL { get; set; } = null;

        [JsonProperty("author")]
        public DiscordMessageEmbedFooter AuthorFooter { get; set; } = null;

        [JsonProperty("newsTexts")]
        public List<DiscordMessage> TextData { get; set; } = new List<DiscordMessage>();

        [JsonProperty("dataModes")]
        public List<DataMode> TextDataModes { get; set; } = new List<DataMode>();

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
                Title = "No title";
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
            DiscordMessageEmbedImage f = new DiscordMessageEmbedImage(URL);
            var msg = new DiscordMessage(
                embeds: new DiscordMessageEmbed[]
                {
                    new DiscordMessageEmbed(
                        title: Title,
                        description: Description,
                        image: f.Invalido ? null : f,
                        color: Color,
                        footer: new DiscordMessageEmbedFooter("by @" + AuthorFooter.Text,AuthorFooter.IconUrl),
                        author: PreDescription
                        )
                }
                );
            client.SendToDiscord(msg);
            foreach (var item in TextData)
            {
                Thread.Sleep(1000);
                client.SendToDiscord(item);
            }
        }

        public void SetColor(int r,int g,int b)
        {
            Color = r + g * 256 + b * 256 * 256;
        }
        public void AddTextData(DataMode mode,DiscordMessage message)
        {
            TextData.Add(message);
            TextDataModes.Add(mode);
        }
        public void RemoveTextData(int index)
        {
            TextData.RemoveAt(index);
            TextDataModes.RemoveAt(index);
        }
    }
}
