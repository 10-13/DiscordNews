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
        public DiscordMessageEmbedFooter EmbedFooter { get; set; }

        public EmbedFooterDialog()
        {
            InitializeComponent();
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
