
using JNogueira.Discord.Webhook.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DiscordNews.Discord_Client
{
    public partial class ClientSelector : UserControl
    {
        private List<string> clients = new List<string>();

        public DiscordWebhookClient? SelectedClient
        {
            get
            {
                if (listBox1.SelectedIndex == -1)
                    return null;
                return new DiscordWebhookClient(clients[listBox1.SelectedIndex]);
            }
        }

        public ClientSelector()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            WebhookClientDialog d = new WebhookClientDialog();
            if (d.ShowDialog() == DialogResult.OK)
            {
                listBox1.Items.Add(d.ClientName);
                clients.Add(d.Client);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex == -1)
                return;
            clients.RemoveAt(listBox1.SelectedIndex);
            listBox1.Items.RemoveAt(listBox1.SelectedIndex);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.DefaultExt = ".txt";
            sfd.AddExtension = true;
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                using (StreamWriter writer = new StreamWriter(new FileStream(sfd.FileName, FileMode.OpenOrCreate)))
                {
                    writer.WriteLine(clients.Count);
                    for (int i = 0; i < clients.Count; i++)
                    {
                        writer.WriteLine(listBox1.Items[i]);
                        writer.WriteLine(clients[i]);
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.DefaultExt = ".txt";
            ofd.AddExtension = true;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                using (StreamReader reader = new StreamReader(new FileStream(ofd.FileName, FileMode.OpenOrCreate)))
                {
                    int count = int.Parse(reader.ReadLine());
                    for (int i = 0; i < count; i++)
                    {
                        listBox1.Items.Add(reader.ReadLine());
                        clients.Add(reader.ReadLine());
                    }
                }
            }
        }

        public void SaveDatae(string FilePath)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(new FileStream(FilePath, FileMode.OpenOrCreate)))
                {
                    writer.WriteLine(clients.Count);
                    for (int i = 0; i < clients.Count; i++)
                    {
                        writer.WriteLine(listBox1.Items[i]);
                        writer.WriteLine(clients[i]);
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }
        public void LoadData(string FilePath)
        {
            if (!File.Exists(FilePath))
                return;
            try
            {
                using (StreamReader reader = new StreamReader(new FileStream(FilePath, FileMode.OpenOrCreate)))
                {
                    int count = int.Parse(reader.ReadLine());
                    for (int i = 0; i < count; i++)
                    {
                        listBox1.Items.Add(reader.ReadLine());
                        clients.Add(reader.ReadLine());
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}
