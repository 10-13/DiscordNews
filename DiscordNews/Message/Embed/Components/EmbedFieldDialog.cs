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
        public DiscordMessageEmbedField EmbedField 
        {
            get
            {
                return  new DiscordMessageEmbedField(
                    string.IsNullOrWhiteSpace(textBox1.Text) ? "No name" : textBox1.Text,
                    textBox2.Text,
                    checkBox1.Checked);
            }
            set
            {
                if (value == null)
                    return;
                textBox1.Text = value.Name;
                textBox2.Text = value.Value;
                checkBox1.Checked = value.InLine;
            }
        }

        public EmbedFieldDialog(DiscordMessageEmbedField data = null)
        {
            InitializeComponent();
            EmbedField = data;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
    }
}
