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
    public partial class TextGenerator_Simple : UserControl, IDSTextGenerator, IDSTextElement
    {
        public INewsBuilder NewsBuilder { get; }

        public TextGenerator_Simple()
        {
            InitializeComponent();
        }
        public TextGenerator_Simple(INewsBuilder newsBuilder)
        {
            NewsBuilder = newsBuilder;
            InitializeComponent();
        }

        public Mode WorkMode 
        {
            get
            {
                return WorkMode;
            }
            set
            {
                WorkMode = value;
                ElementWorkModeName = value.ToString() + " element:";
                UseTextData = value == Mode.Text || value == Mode.List || value == Mode.Fixed;
            }
        }
        public string DataText 
        { 
            get
            {
                return textBox1.Text;
            }
            set
            {
                textBox1.Text = value;
            }
        }
        public bool IsUsedInNewsCompilation 
        { 
            get
            {
                return checkBox1.Checked;
            }
            set
            {
                checkBox1.Checked = value;
            }
        }
        public bool UseTextData 
        { 
            get
            {
                return !textBox1.ReadOnly;
            }
            set
            {
                textBox1.ReadOnly = !value;
            }
        }
        public string ElementWorkModeName
        { 
            get
            {
                return label1.Text;
            }
            set
            {
                label1.Text = value;
            }
        }
        public string ImagePath { get; set; }

        public DiscordMessageData GetDiscordMessage()
        {
            string Text = "";
            if (UseTextData)
            {
                if (WorkMode == Mode.Text)
                    Text = DataText;
                else if (WorkMode == Mode.List)
                    Text = ">>> " + DataText;
                else if (WorkMode == Mode.Fixed)
                    Text = "```\n" + DataText + "\n```";
            }
            return new DiscordMessageData(Text, ImagePath);

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void TextGenerator_Simple_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            NewsBuilder.MoveElementUp(this);
            NewsBuilder.UpdatePositionsAndSizes();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            NewsBuilder.MoveElementDown(this);
            NewsBuilder.UpdatePositionsAndSizes();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            NewsBuilder.DeleteElement(this);
            NewsBuilder.UpdatePositionsAndSizes();
        }
    }

    public enum Mode
    {
        Text,
        Image,
        List,
        Fixed
    }

    public interface IDSTextElement
    {
        public Mode WorkMode { get; set; }
        public string DataText { get; set; }
        public bool IsUsedInNewsCompilation { get; set; }
        public bool UseTextData { get; set; }
        public string ElementWorkModeName { get; set; }
        public string ImagePath { get; set; }
    }
}
