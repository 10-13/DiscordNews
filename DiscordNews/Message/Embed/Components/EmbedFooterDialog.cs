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
    public partial class EmbedFooterDialog : Form
    {
        public DiscordMessageEmbedFooter EmbedFooter 
        {
            get
            {
                return new DiscordMessageEmbedFooter(
                    textBox2.Text,
                    string.IsNullOrWhiteSpace(textBox1.Text) ? null : textBox1.Text
                    );
            }
            set
            {
                if (value == null)
                    return;
                textBox2.Text = value.Text;
                textBox1.Text = value.IconUrl;
            }
        }

        public EmbedFooterDialog(DiscordMessageEmbedFooter data = null)
        {
            InitializeComponent();
            EmbedFooter = data;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UrlImageDialog selector = new UrlImageDialog();
            if (selector.ShowDialog() == DialogResult.OK)
                textBox1.Text = selector.URL;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            EmbedFooter = new DiscordMessageEmbedFooter(textBox2.Text, textBox1.Text);
            DialogResult = DialogResult.OK;
        }
    }
}
