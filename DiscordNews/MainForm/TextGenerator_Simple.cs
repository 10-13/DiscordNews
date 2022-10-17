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
    public partial class TextGenerator_Simple : UserControl, IDSTextGenerator
    {
        public TextGenerator_Simple()
        {
            InitializeComponent();
        }

        public DiscordMessageData GetDiscordMessage()
        {
            return new DiscordMessageData();
        }
    }
}
