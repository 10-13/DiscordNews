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

namespace DiscordNews.News.Components
{
    public partial class TextBuilderCarrier : UserControl
    {
        public readonly NewsDialog _endpoint;

        public const int UpperAnchor = 35;
        public const int DownAnchor = 5;
        public const int RLAnchror = 5;

        public TextBuilderCarrier()
        {
            InitializeComponent();
            _endpoint = null;
        }
        public TextBuilderCarrier(in Form form)
        {
            InitializeComponent();
            _endpoint = form as NewsDialog;
        }

        private void TextBuilderCarrier_Load(object sender, EventArgs e)
        {

        }

        public Control EditControl
        {
            set
            {
                if (Controls.Count > 4)
                    Controls.RemoveAt(4);
                Controls.Add(value);
                value.Width = this.Width - RLAnchror * 2;
                this.Size = new Size(this.Width, UpperAnchor + DownAnchor + value.Height);
                value.Location = new Point(RLAnchror, UpperAnchor);
                value.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;
            }
        }

        public DiscordMessage? Message 
        { 
            get
            {
                if(Controls.Count != 5)
                    return null;
                if ((Controls[4] == null) || !(Controls[4] is IMessageBuilder))
                    return null;
                return (Controls[4] as IMessageBuilder)?.Message;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            _endpoint?.Delete(this);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            _endpoint?.MoveDown(this);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _endpoint?.MoveUp(this);
        }
        public void UpdateControl()
        {
            if (Controls.Count > 4 && Controls[4] != null)
                Controls[4].Width = this.Width - 6;
        }
    }

    public interface IMessageBuilder
    {
        public DiscordMessage Message { get; }
    }
}
