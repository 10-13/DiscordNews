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
        public StandartText(DiscordMessage f = null)
        {
            InitializeComponent();
            if (f != null && f.Content != null)
                textBox1.Text = f.Content;
            if(textBox1.Text.Length > 8 && textBox1.Text.StartsWith("``` ") && textBox1.Text.EndsWith(" ```"))
            {
                textBox1.Text = textBox1.Text.Substring(4, textBox1.TextLength - 8);
                radioButton2.Checked = true;
            }
            if(textBox1.TextLength > 4 && textBox1.Text.StartsWith(">>> "))
            {
                textBox1.Text = textBox1.Text.Substring(4);
                radioButton3.Checked = true;
            }
        }

        public DiscordMessage Message
        {
            get
            {
                if (radioButton2.Checked)
                    return new DiscordMessage("``` " + textBox1.Text + " ```");
                if (radioButton3.Checked)
                    return new DiscordMessage(">>> " + textBox1.Text);
                return new DiscordMessage(textBox1.Text);
            }
        }

        private void StandartText_Resize(object sender, EventArgs e)
        {
            textBox1.Width = this.Width - 6;
        }
    }
}
