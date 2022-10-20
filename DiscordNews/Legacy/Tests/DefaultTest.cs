using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DiscordNews.Message;
using JNogueira.Discord.Webhook.Client;

namespace DiscordNews.Legacy.Tests
{
    public partial class DefaultTest : Form
    {
        public DefaultTest()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DiscordWebhookClient client = new DiscordWebhookClient(textBox1.Text);
            MessageDialog d = new MessageDialog();
            if (d.ShowDialog() == DialogResult.OK)
                client.SendToDiscord(d.Message);
        }   
    }
}
