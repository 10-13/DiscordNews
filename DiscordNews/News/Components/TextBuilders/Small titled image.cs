using DiscordNews.MessageSettings.Embed.ComponentDialogs;
using JNogueira.Discord.Webhook.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DiscordNews.News.Components.TextBuilders
{
    public partial class Small_titled_image : UserControl, IMessageBuilder
    {
        public DiscordMessageEmbedFooter EmbedFooter { get; set; } = null;

        public DiscordMessage Message
        {
            get
            {
                return new DiscordMessage(embeds: new DiscordMessageEmbed[1] { new DiscordMessageEmbed(footer: EmbedFooter) });
            }
        }

        public Small_titled_image(DiscordMessage data = null)
        {
            InitializeComponent();
            if (data != null && data.Embeds != null && data.Embeds.Length > 0 && data.Embeds[0] != null)
                EmbedFooter = data.Embeds[0].Footer;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            EmbedFooterDialog f = new EmbedFooterDialog(EmbedFooter);
            if (f.ShowDialog() == DialogResult.OK)
                EmbedFooter = f.EmbedFooter;
        }
    }
}
