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

using JNogueira.Discord.Webhook.Client;
using DiscordNews.News.Components.TextBuilders;
using DiscordNews.News.Components;
using DiscordNews.Default;
using DiscordNews.MessageSettings.Embed.ComponentDialogs;

namespace DiscordNews.News
{
    public partial class NewsDialog : Form
    {
        //==== TEXT BUILDER =============================================

        public void MoveUp(Control control)
        {
            if (!flowLayoutPanel1.Controls.Contains(control))
                return;
            if (flowLayoutPanel1.Controls.IndexOf(control) == 0)
                return;
            flowLayoutPanel1.Controls.SetChildIndex(control, flowLayoutPanel1.Controls.IndexOf(control) - 1);
        }
        public void MoveDown(Control control)
        {
            if (!flowLayoutPanel1.Controls.Contains(control))
                return;
            if (flowLayoutPanel1.Controls.IndexOf(control) == flowLayoutPanel1.Controls.Count - 1)
                return;
            flowLayoutPanel1.Controls.SetChildIndex(control, flowLayoutPanel1.Controls.IndexOf(control) + 1);
        }
        public void Delete(Control control)
        {
            if (!flowLayoutPanel1.Controls.Contains(control))
                return;
            flowLayoutPanel1.Controls.Remove(control);
        }
        public void UpdateFlow()
        {
            int pref = 5;
            foreach(Control control in flowLayoutPanel1.Controls)
            {
                control.Width = flowLayoutPanel1.Width - 25;
                control.Location = new Point(5, pref);
                pref += control.Height + 5;
                //if (control is TextBuilderCarrier)
                //    (control as TextBuilderCarrier)?.UpdateControl();
            }
        }
        //===============================================================

        public List<DiscordMessage> News { get; set; } = new List<DiscordMessage>();
        public string Title { get; set; } = "";
        public DiscordMessageEmbedFooter footer { get; set; } = null;
        public NewsDialog()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            TextBuilderCarrier f = new TextBuilderCarrier(this);
            f.EditControl = new StandartText();
            flowLayoutPanel1.Controls.Add(f);
            UpdateFlow();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UrlImageDialog url = new UrlImageDialog();
            if (url.ShowDialog() == DialogResult.OK)
                textBox3.Text = url.URL;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            News.Add(new DiscordMessage(
                embeds: new DiscordMessageEmbed[]
                {
                    new DiscordMessageEmbed(
                        title: textBox2.Text,
                        description: textBox3.Text,
                        image: string.IsNullOrEmpty(textBox1.Text) ? null : new DiscordMessageEmbedImage(textBox1.Text),
                        footer: footer
                        )
                }
                ));
            foreach(TextBuilderCarrier carrier in flowLayoutPanel1.Controls)
            {
                if (carrier.Message != null)
                    News.Add(carrier.Message);
            }
            Title = textBox2.Text;
            DialogResult = DialogResult.OK;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            UpdateFlow();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            TextBuilderCarrier f = new TextBuilderCarrier(this);
            f.EditControl = new Big_titled_image();
            flowLayoutPanel1.Controls.Add(f);
            UpdateFlow();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            TextBuilderCarrier f = new TextBuilderCarrier(this);
            f.EditControl = new Small_titled_image();
            flowLayoutPanel1.Controls.Add(f);
            UpdateFlow();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            TextBuilderCarrier f = new TextBuilderCarrier(this);
            f.EditControl = new EmbedEditor();
            flowLayoutPanel1.Controls.Add(f);
            UpdateFlow();
        }

        private void NewsDialog_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            EmbedFooterDialog footer = new EmbedFooterDialog();
            if (footer.ShowDialog() == DialogResult.OK)
                this.footer = footer.EmbedFooter;
        }
    }
}
