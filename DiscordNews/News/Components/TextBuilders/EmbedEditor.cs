using Discord;
using DiscordNews.MessageSettings.Embed;
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
    public partial class EmbedEditor : UserControl, IMessageBuilder
    {
        public DiscordMessageEmbed MessageEmbed { get; set; } = null;

        public EmbedEditor()
        {
            InitializeComponent();
        }

        public DiscordMessage Message
        {
            get
            {
                return new DiscordMessage(embeds: new DiscordMessageEmbed[1] { MessageEmbed });
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            EmbedDialog f = new EmbedDialog();
            if (f.ShowDialog() == DialogResult.OK)
                MessageEmbed = f.Embed;
        }
    }
}
