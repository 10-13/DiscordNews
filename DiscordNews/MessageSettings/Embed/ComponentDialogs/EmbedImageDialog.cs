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
        public DiscordMessageEmbedImage EmbedImage { get; set; }

        public EmbedImageDialog()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            EmbedImage = new DiscordMessageEmbedImage(textBox1.Text);
            DialogResult = DialogResult.OK;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            UrlImageSelector url = new UrlImageSelector();
            if (url.ShowDialog() == DialogResult.OK)
                textBox1.Text = url.URL;
        }
    }
}
