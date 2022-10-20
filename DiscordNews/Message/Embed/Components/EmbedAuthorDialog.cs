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
        public DiscordMessageEmbedAuthor EmbedAuthor { get; set; }

        public EmbedAuthorDialog()
        {
            InitializeComponent();
        }

        /*
        private void button1_Click(object sender, EventArgs e)
        {
            UrlImageDialog selector = new UrlImageDialog();
            if (selector.ShowDialog() == DialogResult.OK)
                textBox1.Text = selector.URL;
        }
        */
        private void button2_Click(object sender, EventArgs e)
        {
            UrlImageDialog selector = new UrlImageDialog();
            if (selector.ShowDialog() == DialogResult.OK)
                textBox2.Text = selector.URL;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            EmbedAuthor = new DiscordMessageEmbedAuthor(textBox3.Text, textBox1.Text, textBox2.Text);
            DialogResult = DialogResult.OK;
        }
    }
}
