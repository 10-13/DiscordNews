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
    public partial class Big_titled_image : UserControl, IMessageBuilder
    {
        public DiscordMessageEmbedImage Image { get; set; }

        public Big_titled_image()
        {
            InitializeComponent();
        }

        public DiscordMessage Message
        {
            get
            {
                return new DiscordMessage(embeds: new DiscordMessageEmbed[1] { new DiscordMessageEmbed(textBox1.Text, image: Image) });
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            EmbedImageDialog f = new EmbedImageDialog();
            if (f.ShowDialog() == DialogResult.OK)
                Image = f.EmbedImage;
        }
    }
}
