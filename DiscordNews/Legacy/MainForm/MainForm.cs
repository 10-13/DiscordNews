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

namespace DiscordNews.MainForm
{
    public partial class MainForm : Form, INewsBuilder
    {
        private DiscordInterface Interface = new DiscordInterface("https://discord.com/api/webhooks/1031633631044698262/BK_lbwyhcJJ80Vt_QUSkhRHJvx1weOOWLua7ZJC17pAEBLi2uebtFDjWHUA91cB7skjC");

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            var Msg = new DiscordMessage(
                embeds: new DiscordMessageEmbed[1]
                {
                    new DiscordMessageEmbed(
                        author: new DiscordMessageEmbedAuthor("WSKY NEWS",iconUrl: "https://media.discordapp.net/attachments/893583871147397182/1028203181173383218/jack-daniels-butylka-chernyy.jpg"),
                        title: "Название новости",
                        url: "https://media.discordapp.net/attachments/893583871147397182/1028203181173383218/jack-daniels-butylka-chernyy.jpg",
                        description: "```\n\nТут вы читаете какое-то короткое описание новости\n\n```",
                        image: new DiscordMessageEmbedImage("https://media.discordapp.net/attachments/893583871147397182/1028203181173383218/jack-daniels-butylka-chernyy.jpg"),
                        fields: new DiscordMessageEmbedField[2] { new DiscordMessageEmbedField("Параграф 1.", "Краткая информация"), new DiscordMessageEmbedField("Параграф 2.", "Краткая информация") },
                        footer: new DiscordMessageEmbedFooter("@by 10-13","https://media.discordapp.net/attachments/893583871147397182/1028203181173383218/jack-daniels-butylka-chernyy.jpg")
                        )
                }
                ) ;
            MessageBox.Show(Msg.Invalido.ToString());
            Interface.client.SendToDiscord(Msg);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            flowLayoutPanel1.Controls.Add(new TextGenerator_Simple(this));
            UpdatePositionsAndSizes();
        }

        public void MoveElementUp(in UserControl userControl)
        {
            if (!flowLayoutPanel1.Controls.Contains(userControl))
                return;
            int pos = flowLayoutPanel1.Controls.GetChildIndex(userControl);
            if (pos < 1)
                return;
            flowLayoutPanel1.Controls.SetChildIndex(userControl, pos - 1);
        }

        public void MoveElementDown(in UserControl userControl)
        {
            if (!flowLayoutPanel1.Controls.Contains(userControl))
                return;
            int pos = flowLayoutPanel1.Controls.GetChildIndex(userControl);
            if (pos == -1 || pos > flowLayoutPanel1.Controls.Count - 2)
                return;
            flowLayoutPanel1.Controls.SetChildIndex(userControl, pos + 1);
        }
        public void DeleteElement(in UserControl userControl)
        {
            flowLayoutPanel1.Controls.Remove(userControl);
        }
        public void UpdatePositionsAndSizes()
        {
            const int step = 5;
            int width = flowLayoutPanel1.Width - step * 5;
            int PrefHeight = step;
            for(int i = 0;i < flowLayoutPanel1.Controls.Count;i++)
            {
                flowLayoutPanel1.Controls[i].Width = width;
                flowLayoutPanel1.Controls[i].Location = new Point(step, PrefHeight);
                (flowLayoutPanel1.Controls[i] as IDSTextElement)?.SetIndex(i + 1);
                PrefHeight += flowLayoutPanel1.Controls[i].Height;
                PrefHeight += step;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Queue<DiscordMessageData> output = new Queue<DiscordMessageData>();
            foreach (IDSTextElement element in flowLayoutPanel1.Controls)
                if(element.IsUsedInNewsCompilation)
                    output.Enqueue(element.GetDiscordMessage());
            Interface.Send(output);
        }
    }

    public interface INewsBuilder
    {
        public void MoveElementUp(in UserControl userControl);
        public void MoveElementDown(in UserControl userControl);
        public void DeleteElement(in UserControl userControl);
        public void UpdatePositionsAndSizes();
    }
}
