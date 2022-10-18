using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using JNogueira.Discord.Webhook.Client;
using JNogueira.NotifiqueMe;
using Newtonsoft.Json;

namespace DiscordNews.MessageSettings.Embed
{
    public partial class EmbedEditingForm : Form
    {
        public DiscordMessageEmbed target { get; protected set; }

        public EmbedEditingForm()
        {
            InitializeComponent();
            target = null;
        }
        public EmbedEditingForm(in DiscordMessageEmbed target)
        {
            
        }

        private void EmbedEditingForm_Load(object sender, EventArgs e)
        {
            
        }
    }


    public class DiscordMessageEmbed : Notificavel
    {
        /// <summary>
        /// Color code of the embed. You have to use Decimal numeral system, not Hexadecimal. You can use SpyColor (https://www.spycolor.com) for that. It has a decimal number converter.
        /// </summary>
        [JsonProperty("color")]
        public int? Color { get; private set; }

        /// <summary>
        ///  Embed author object
        /// </summary>
        [JsonProperty("author")]
        public DiscordMessageEmbedAuthor Author { get; private set; }

        /// <summary>
        /// Title of embed
        /// </summary>
        [JsonProperty("title")]
        public string Title { get; private set; }

        /// <summary>
        /// Url of embed. If title was used, it becomes hyperlink
        /// </summary>
        [JsonProperty("url")]
        public string Url { get; private set; }

        /// <summary>
        /// Description text
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; private set; }

        /// <summary>
        /// Array of embed field objects
        /// </summary>
        [JsonProperty("fields")]
        public DiscordMessageEmbedField[] Fields { get; private set; }

        /// <summary>
        /// Embed thumbnail object
        /// </summary>
        [JsonProperty("thumbnail")]
        public DiscordMessageEmbedThumbnail Thumbnail { get; private set; }

        /// <summary>
        /// Embed image object
        /// </summary>
        [JsonProperty("image")]
        public DiscordMessageEmbedImage Image { get; private set; }

        /// <summary>
        /// Embed footer object
        /// </summary>
        [JsonProperty("footer")]
        public DiscordMessageEmbedFooter Footer { get; private set; }

        [JsonConstructor]
        private DiscordMessageEmbed()
        {

        }

        public DiscordMessageEmbed(
            string title = null,
            int? color = null,
            DiscordMessageEmbedAuthor author = null,
            string url = null,
            string description = null,
            IEnumerable<DiscordMessageEmbedField> fields = null,
            DiscordMessageEmbedThumbnail thumbnail = null,
            DiscordMessageEmbedImage image = null,
            DiscordMessageEmbedFooter footer = null)
        {
            this.Color = color;
            this.Author = author;
            this.Title = title?.Trim();
            this.Url = url?.Trim();
            this.Description = description?.Trim();
            this.Fields = fields?.ToArray();
            this.Thumbnail = thumbnail;
            this.Image = image;
            this.Footer = footer;

            Validate();
        }

        internal void Validate()
        {
            this
                .NotificarSeVerdadeiro(this.Title?.Length > 256, $"The embed \"title\" length limit is 256 characters (actual lenght is {this.Title?.Length}).")
                .NotificarSeVerdadeiro(this.Description?.Length > 2048, $"The embed \"description\" length limit is 2048 characters (actual lenght is {this.Description?.Length}).");

            if (this.Fields?.Length > 0)
            {
                this.NotificarSeVerdadeiro(this.Fields.Length > 25, $"The embed \"fields\" collection size limit is 25 elements. (actual size is {this.Fields.Length})");

                this.Fields.ToList().ForEach(x => this.AdicionarNotificacoes(x));
            }

            this.AdicionarNotificacoes(this.Author);
            this.AdicionarNotificacoes(this.Thumbnail);
            this.AdicionarNotificacoes(this.Image);
            this.AdicionarNotificacoes(this.Footer);
        }

        public string ToTxtFileContent()
        {
            var attachmentErrorMessage = new StringBuilder();

            if (this.Color.HasValue)
                attachmentErrorMessage.Append("Embed color: ").AppendLine(this.Color.ToString());

            if (this.Author != null)
                attachmentErrorMessage.AppendFormat(this.Author.ToTxtFileContent());

            if (!string.IsNullOrEmpty(this.Title))
                attachmentErrorMessage.Append("Embed title: ").AppendLine(this.Title);

            if (!string.IsNullOrEmpty(this.Url))
                attachmentErrorMessage.Append("Embed URL: ").AppendLine(this.Url);

            if (!string.IsNullOrEmpty(this.Description))
                attachmentErrorMessage.Append("Embed description: ").AppendLine(this.Description);

            if (this.Thumbnail != null)
                attachmentErrorMessage.Append(this.Thumbnail.ToTxtFileContent());

            if (this.Image != null)
                attachmentErrorMessage.Append(this.Image.ToTxtFileContent());

            if (this.Footer != null)
                attachmentErrorMessage.Append(this.Footer.ToTxtFileContent());

            if (this.Fields?.Length > 0)
            {
                int fieldIndex = 1;

                foreach (var field in this.Fields)
                {
                    attachmentErrorMessage.Append("- Embed field #").AppendLine(fieldIndex.ToString());
                    attachmentErrorMessage.Append(field.ToTxtFileContent());

                    fieldIndex++;
                }
            }

            return attachmentErrorMessage.ToString();
        }
    }
}


