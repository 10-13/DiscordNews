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
using V10_13News.News;
using System.Security.Cryptography;

namespace DiscordNews.Default
{
    public partial class MainForm : Form
    {
        private ClientSelector selector;
        private List<NewsMain> News = new List<NewsMain>();

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
                listBox1.Items.Add(f.News.Title);
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
            listBox1.Items.RemoveAt(listBox1.SelectedIndex);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.CheckFileExists = true;
            if (ofd.ShowDialog() == DialogResult.OK)
                News = JsonConvert.DeserializeObject<List<NewsMain>>(File.ReadAllText(ofd.FileName));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.DefaultExt = ".txt";
            sfd.CheckPathExists = true;
            if (sfd.ShowDialog() == DialogResult.OK)
                File.WriteAllText(sfd.FileName, JsonConvert.SerializeObject(News));
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (selector.SelectedClient == null || listBox1.SelectedIndex == -1)
                return;
            var client = selector.SelectedClient;
            News[listBox1.SelectedIndex].SendToClient(client);
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            selector.SaveDatae("Webhooks.txt");
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex == -1)
                return;
            NewsDialog f = new NewsDialog(News[listBox1.SelectedIndex]);
            if (f.ShowDialog() == DialogResult.OK)
            {
                News[listBox1.SelectedIndex] = f.News;
                listBox1.Items[listBox1.SelectedIndex] = f.News.Title;
            }
        }
    }
}
