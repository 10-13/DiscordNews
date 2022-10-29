using DiscordNews.Discord_Client;
using DiscordNews.News;
using JNogueira.Discord.Webhook.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DiscordNews.Default
{
    public partial class MainForm : Form
    {
        private ClientSelector selector;
        private List<List<DiscordMessage>> News = new List<List<DiscordMessage>>();
        private List<string> Titles = new List<string>();

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            selector = new ClientSelector();
            selector.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            selector.Location = new Point(3, 17);
            selector.Size = new Size(200, this.ClientSize.Height - 20);
            if (File.Exists("Webhooks.txt"))
                selector.LoadData("Webhooks.txt");
            Controls.Add(selector);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            NewsDialog f = new NewsDialog();
            if (f.ShowDialog() == DialogResult.OK)
            {
                News.Add(f.News);
                listBox1.Items.Add(f.Title);
                Titles.Add(f.Title);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Not aliveble now");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Not aliveble now");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex == -1)
                return;
            News.RemoveAt(listBox1.SelectedIndex);
            Titles.RemoveAt(listBox1.SelectedIndex);
            listBox1.Items.RemoveAt(listBox1.SelectedIndex);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Not aliveble now");
            /*
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.CheckFileExists = true;
            if (ofd.ShowDialog() == DialogResult.OK)
                using (StreamReader reader = new StreamReader(new FileStream(ofd.FileName, FileMode.Open)))
                {
                    

                    var temp = JsonConverter
                    Titles = new List<string>();
                    Titles.AddRange(temp.Value);
                    News = new List<List<DiscordMessage>>();
                    foreach (DiscordMessage[] f in temp.Key)
                    {
                        News.Add(new List<DiscordMessage>());
                        News[News.Count - 1].AddRange(f);
                    }
                }
            listBox1.Items.Clear();
            foreach (string title in Titles)
                listBox1.Items.Add(title);*/
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Not aliveble now");
            /*
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.DefaultExt = ".txt";
            sfd.CheckPathExists = true;
            if (sfd.ShowDialog() == DialogResult.OK)
                using (StreamWriter writer = new StreamWriter(new FileStream(sfd.FileName, FileMode.OpenOrCreate)))
                    writer.WriteLine(JsonSerializer.Serialize(new KeyValuePair<List<List<DiscordMessage>>,List<string>>(News,Titles)));*/
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (selector.SelectedClient == null || listBox1.SelectedIndex == -1)
                return;
            var client = selector.SelectedClient;
            foreach (var msg in News[listBox1.SelectedIndex])
                client.SendToDiscord(msg);
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            selector.SaveDatae("Webhooks.txt");
        }
    }
}
