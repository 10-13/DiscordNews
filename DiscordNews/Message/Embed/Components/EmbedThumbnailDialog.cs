using DiscordNews.Default;
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

namespace DiscordNews.MessageSettings.Embed.ComponentDialogs
{
    public partial class EmbedThumbnailDialog : Form
    {
        public DiscordMessageEmbedThumbnail EmbedThumbnail { get; set; }

        public EmbedThumbnailDialog()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            EmbedThumbnail = new DiscordMessageEmbedThumbnail(textBox1.Text);
            DialogResult = DialogResult.OK;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            UrlImageDialog f = new UrlImageDialog();
            if (f.ShowDialog() == DialogResult.OK)
                textBox1.Text = f.URL;
        }
    }
}
