using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DiscordNews.MainForm
{
    public partial class MainForm : Form, INewsBuilder
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {

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
            int width = flowLayoutPanel1.Width - step * 2;
            int PrefHeight = step;
            for(int i = 0;i < flowLayoutPanel1.Controls.Count;i++)
            {
                flowLayoutPanel1.Controls[i].Width = width;
                flowLayoutPanel1.Controls[i].Location = new Point(step, PrefHeight);
                PrefHeight += flowLayoutPanel1.Controls[i].Height;
                PrefHeight += step;
            }
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
