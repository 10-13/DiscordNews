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

namespace DiscordNews.Discord_Client
{
    public partial class WebhookClientDialog : Form
    {
        public string ClientName { get; set; } = "";

        public string Client { get; set; } = "";

        public WebhookClientDialog()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ClientName = textBox1.Text;
            Client = textBox2.Text;
            DialogResult = DialogResult.OK;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}
