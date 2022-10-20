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
    public partial class EmbedFieldDialog : Form
    {
        public DiscordMessageEmbedField EmbedField { get; set; }

        public EmbedFieldDialog()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            EmbedField = new DiscordMessageEmbedField(textBox1.Text, textBox2.Text,checkBox1.Checked);
            DialogResult = DialogResult.OK;
        }
    }
}
