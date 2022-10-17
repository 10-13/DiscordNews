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
        public TextGenerator_Simple()
        {
            InitializeComponent();
        }

        public Mode WorkMode 
        { 
            get; 
            set;
        }
        public string DataText 
        { 
            get
            {
                return textBox1.Text;
            }
            set
            {

            }
        }
        public bool IsUsedInFinalCompilation 
        { 
            get; 
            set;
        }
        public bool CanEditData 
        { 
            get; 
            set;
        }
        public string ElementWorkMode 
        { 
            get;
            set; 
        }

        public DiscordMessageData GetDiscordMessage()
        {
            return new DiscordMessageData();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void TextGenerator_Simple_Load(object sender, EventArgs e)
        {

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
        public bool IsUsedInFinalCompilation { get; set; }
        public bool CanEditData { get; set; }
        public string ElementWorkMode { get; set; }
    }
}
