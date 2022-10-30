using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DiscordNews.Default;
using JNogueira.Discord.Webhook.Client;

namespace DiscordNews.MessageSettings.Embed.ComponentDialogs
{
    public partial class EmbedImageDialog : Form
    {
        public DiscordMessageEmbedImage EmbedImage 
        {
            get
            {
                return string.IsNullOrWhiteSpace(textBox1.Text) ? null : new DiscordMessageEmbedImage(textBox1.Text);
            }
            set
            {
                if (value == null)
                    return;
                textBox1.Text = value.Url;

            }
        }

        public EmbedImageDialog(DiscordMessageEmbedImage data = null)
        {
            InitializeComponent();
            EmbedImage = data;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            UrlImageDialog url = new UrlImageDialog();
            if (url.ShowDialog() == DialogResult.OK)
                textBox1.Text = url.URL;
        }
    }
}
