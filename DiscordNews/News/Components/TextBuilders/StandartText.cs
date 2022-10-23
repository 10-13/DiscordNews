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

namespace DiscordNews.News.Components.TextBuilders
{
    public partial class StandartText : UserControl, IMessageBuilder
    {
        public StandartText()
        {
            InitializeComponent();
        }

        public DiscordMessage Message
        {
            get
            {
                if (radioButton2.Checked)
                    return new DiscordMessage("```" + textBox1.Text + "```");
                if (radioButton3.Checked)
                    return new DiscordMessage(">>>" + textBox1.Text);
                return new DiscordMessage(textBox1.Text);
            }
        }

        private void StandartText_Resize(object sender, EventArgs e)
        {
            textBox1.Width = this.Width - 6;
        }
    }
}
