using DiscordNews.Default;
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
    public partial class EmbedAuthorDialog : Form
    {
        public 

        public EmbedAuthorDialog()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UrlImageSelector selector = new UrlImageSelector();
            if (selector.ShowDialog() == DialogResult.OK)
                textBox1.Text = selector.URL;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            UrlImageSelector selector = new UrlImageSelector();
            if (selector.ShowDialog() == DialogResult.OK)
                textBox2.Text = selector.URL;
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}
