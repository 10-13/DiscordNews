using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Discord;
using DiscordNews.Default;
using DiscordNews.MessageSettings.Embed;
using DiscordNews.MessageSettings.Embed.ComponentDialogs;
using JNogueira.Discord.Webhook.Client;

namespace DiscordNews.Message
{
    public partial class MessageDialog : Form
    {
        public List<DiscordMessageEmbed> MessageEmbeds { get; set; } = new List<DiscordMessageEmbed>();

        public DiscordMessage Message 
        { 
            get
            {
                return new DiscordMessage(
                content: textBox1.Text,
                username: string.IsNullOrEmpty(textBox2.Text) ? null : textBox2.Text,
                avatarUrl: string.IsNullOrEmpty(textBox3.Text) ? null : textBox3.Text,
                tts: checkBox1.Checked,
                embeds: MessageEmbeds.ToArray()
                );
            }
            set
            {
                if (value == null)
                    return;
                textBox1.Text = value.Content;
                textBox2.Text = value.Username;
                textBox3.Text = value.AvatarUrl;
                checkBox1.Checked = value.Tts;
                foreach (var embed in value.Embeds)
                {
                    MessageEmbeds.Add(embed);
                    listBox1.Items.Add(string.IsNullOrWhiteSpace(embed.Title) ? "No title" : embed.Title);
                }
            }
        }

        public MessageDialog(DiscordMessage data = null)
        {
            InitializeComponent();
            Message = data;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            EmbedDialog f = new EmbedDialog();
            if(f.ShowDialog() == DialogResult.OK)
            {
                MessageEmbeds.Add(f.Embed);
                listBox1.Items.Add((f.Embed.Title == null) ? "___TITLE_ERROR_" + (f.Embed.Description == null ? "*" : f.Embed.Description) : f.Embed.Title);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            UrlImageDialog f = new UrlImageDialog();
            if (f.ShowDialog() == DialogResult.OK)
                textBox3.Text = f.URL;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(listBox1.SelectedIndex > -1)
            {
                MessageEmbeds.RemoveAt(listBox1.SelectedIndex);
                listBox1.Items.RemoveAt(listBox1.SelectedIndex);
            }
        }

        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex == -1)
                return;
            EmbedDialog f = new EmbedDialog(MessageEmbeds[listBox1.SelectedIndex]);
            if (f.ShowDialog() == DialogResult.OK)
            {
                MessageEmbeds[listBox1.SelectedIndex] = f.Embed;
                listBox1.Items[listBox1.SelectedIndex] = f.Embed.Title;
            }
        }
    }
}
