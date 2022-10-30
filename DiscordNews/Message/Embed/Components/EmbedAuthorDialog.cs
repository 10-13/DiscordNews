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
    public partial class EmbedAuthorDialog : Form
    {
        public DiscordMessageEmbedAuthor EmbedAuthor 
        { 
            get
            {
                return new DiscordMessageEmbedAuthor(
                    textBox3.Text,
                    url: string.IsNullOrWhiteSpace(textBox1.Text) ? null : textBox1.Text,
                    iconUrl: string.IsNullOrWhiteSpace(textBox2.Text) ? null : textBox2.Text
                    );
            }
            set
            {
                if (value == null)
                    return;
                textBox3.Text = value.Name;
                textBox1.Text = value.Url;
                textBox2.Text = value.IconUrl;
            }
        }

        public EmbedAuthorDialog(DiscordMessageEmbedAuthor data = null)
        {
            InitializeComponent();
            EmbedAuthor = data;
        }

        
        private void button1_Click(object sender, EventArgs e)
        {
            UrlImageDialog selector = new UrlImageDialog();
            if (selector.ShowDialog() == DialogResult.OK)
                textBox1.Text = selector.URL;
        }
        
        private void button2_Click(object sender, EventArgs e)
        {
            UrlImageDialog selector = new UrlImageDialog();
            if (selector.ShowDialog() == DialogResult.OK)
                textBox2.Text = selector.URL;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
    }
}
