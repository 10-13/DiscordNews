using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace DiscordNews.Default
{
    public partial class UrlImageDialog : Form
    {
        public static List<KeyValuePair<string, string>> images = new List<KeyValuePair<string, string>>();
        public static bool Changed = false;

        static UrlImageDialog()
        {
            if (File.Exists("userimages.txt"))
                images = JsonConvert.DeserializeObject<List<KeyValuePair<string,string>>>(File.ReadAllText("userimages.txt"));
            if(images == null)
                images = new List<KeyValuePair<string, string>>();
        }

        public string URL { get; set; } = "";

        public UrlImageDialog(bool ShowList = true)
        {
            InitializeComponent();
            if (ShowList)
            {
                foreach (var item in images)
                    listBox1.Items.Add(item.Key);
            }
            else
            {
                listBox1.Hide();
                button3.Hide();
                button4.Hide();
            }
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            URL = textBox1.Text;
            try
            {
                pictureBox1.Load(URL);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            URL = textBox1.Text;
            DialogResult = DialogResult.OK;
        }
        
        private void UrlImageDialog_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Changed)
                File.WriteAllText("userimages.txt", JsonConvert.SerializeObject(images));
        }

        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex == -1)
                return;
            textBox1.Text = images[listBox1.SelectedIndex].Value;
            button1_Click(sender, e);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex == -1)
                return;
            images.RemoveAt(listBox1.SelectedIndex);
            listBox1.Items.RemoveAt(listBox1.SelectedIndex);
            Changed = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            UrlImageDialog f = new UrlImageDialog(false);
            if (f.ShowDialog() == DialogResult.OK) 
            {
                images.Add(new KeyValuePair<string,string>("No name",f.URL));
                listBox1.Items.Add("No name");
            }
            Changed = true;
        }

        private void toolStripTextBox1_Enter(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex == -1)
                return;
            toolStripTextBox1.Text = listBox1.SelectedItem.ToString();
            Changed = true;
        }

        private void toolStripTextBox1_Leave(object sender, EventArgs e)
        {
        }

        private void toolStripTextBox1_TextChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex == -1)
                return;
            listBox1.Items[listBox1.SelectedIndex] = toolStripTextBox1.Text;
            images[listBox1.SelectedIndex] = new KeyValuePair<string, string>(toolStripTextBox1.Text, images[listBox1.SelectedIndex].Value);
            Changed = true;
        }
    }
}
