using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DiscordNews.MessageSettings.Embed.ComponentDialogs;
using JNogueira.Discord.Webhook.Client;
using JNogueira.NotifiqueMe;
using Newtonsoft.Json;

namespace DiscordNews.MessageSettings.Embed
{
    public partial class EmbedDialog : Form
    {
        public Color? EmbedColor { get; set; } = null;
        public DiscordMessageEmbedAuthor? EmbedAuthor { get; set; } = null;
        public List<DiscordMessageEmbedField> EmbedFields { get; set; } = new List<DiscordMessageEmbedField>();
        public DiscordMessageEmbedFooter? EmbedFooter { get; set; } = null;
        public DiscordMessageEmbedImage? EmbedImage { get; set; } = null;
        public DiscordMessageEmbedThumbnail? EmbedThumbnail { get; set; } = null;

        public DiscordMessageEmbed Embed
        {
            get
            {
                return new DiscordMessageEmbed(
                title: string.IsNullOrEmpty(textBox1.Text) ? null : textBox1.Text,
                description: string.IsNullOrEmpty(textBox2.Text) ? null : textBox2.Text,
                url: string.IsNullOrEmpty(textBox3.Text) ? null : textBox3.Text,
                color: EmbedColor == null ? null : EmbedColor.Value.B + EmbedColor.Value.G * 256 + EmbedColor.Value.R * 256 * 256,
                author: EmbedAuthor,
                fields: EmbedFields.ToArray(),
                thumbnail: EmbedThumbnail,
                image: EmbedImage,
                footer: EmbedFooter
                );
            }
            set
            {
                if (value == null)
                    return;
                textBox1.Text = value.Title;
                textBox2.Text = value.Description;
                textBox3.Text = value.Url;
                if (value.Color != null)
                    EmbedColor = Color.FromArgb(value.Color.Value % 256, value.Color.Value / 256 % 256, value.Color.Value / 256 / 256 % 256);
                EmbedAuthor = value.Author;
                EmbedFooter = value.Footer;
                EmbedImage = value.Image;
                EmbedThumbnail = value.Thumbnail;
                EmbedFields = new List<DiscordMessageEmbedField>();
                foreach (var field in value.Fields)
                {
                    if (field.Invalido)
                        continue;
                    EmbedFields.Add(field);
                    listBox1.Items.Add(field.Name);
                }
            }
        }

        public EmbedDialog(DiscordMessageEmbed data = null)
        {
            InitializeComponent();
            Embed = data;
        }

        private void EmbedEditingForm_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ColorDialog clr = new ColorDialog();
            if (clr.ShowDialog() == DialogResult.OK)
                EmbedColor = clr.Color;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            EmbedAuthorDialog eA = new EmbedAuthorDialog(EmbedAuthor);
            if (eA.ShowDialog() == DialogResult.OK)
                EmbedAuthor = eA.EmbedAuthor;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            EmbedImageDialog eA = new EmbedImageDialog(EmbedImage);
            if (eA.ShowDialog() == DialogResult.OK)
                EmbedImage = eA.EmbedImage;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            EmbedThumbnailDialog eA = new EmbedThumbnailDialog(EmbedThumbnail);
            if (eA.ShowDialog() == DialogResult.OK)
                EmbedThumbnail = eA.EmbedThumbnail;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            EmbedFooterDialog eA = new EmbedFooterDialog(EmbedFooter);
            if (eA.ShowDialog() == DialogResult.OK)
                EmbedFooter = eA.EmbedFooter;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            EmbedFieldDialog fld = new EmbedFieldDialog();
            if (fld.ShowDialog() == DialogResult.OK && !string.IsNullOrEmpty(fld.EmbedField.Name))
            {
                EmbedFields.Add(fld.EmbedField);
                listBox1.Items.Add(fld.EmbedField.Name);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
            {
                EmbedFields.RemoveAt(listBox1.SelectedIndex);
                listBox1.Items.RemoveAt(listBox1.SelectedIndex);
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex == -1)
                return;
            EmbedFieldDialog f = new EmbedFieldDialog(EmbedFields[listBox1.SelectedIndex]);
            if (f.ShowDialog() == DialogResult.OK)
            {
                EmbedFields[listBox1.SelectedIndex] = f.EmbedField;
                listBox1.Items[listBox1.SelectedIndex] = f.EmbedField.Name;
            }

        }
    }
}


