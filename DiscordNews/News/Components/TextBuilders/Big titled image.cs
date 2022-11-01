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

        public Big_titled_image(DiscordMessage data = null)
        {
            InitializeComponent();
            if (data != null && data.Embeds != null && data.Embeds.Length > 0 && data.Embeds[0] != null)
            {
                if (data.Embeds[0].Title != null)
                    textBox1.Text = data.Embeds[0].Title;
                Image = data.Embeds[0].Image;
            }
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
            EmbedImageDialog f = new EmbedImageDialog(Image);
            if (f.ShowDialog() == DialogResult.OK)
                Image = f.EmbedImage;
        }
    }
}
