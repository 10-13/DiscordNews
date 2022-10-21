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
                control.Width = flowLayoutPanel1.Width - 20;
                control.Location = new Point(5, pref);
                pref += control.Height + 5;
            }
        }
        //===============================================================

        public NewsDialog()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            flowLayoutPanel1.Controls.Add(new TextBuilderCarrier(this));
            (flowLayoutPanel1.Controls[flowLayoutPanel1.Controls.Count - 1] as TextBuilderCarrier).EditControl = new StandartText();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
    }
}
