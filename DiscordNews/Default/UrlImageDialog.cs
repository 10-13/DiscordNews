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
        /*private static XmlDocument Data = null;

        static UrlImageDialog()
        {
            if (File.Exists("image_dump.txt"))
            {
                Data = new XmlDocument();
                Data.LoadXml(File.ReadAllText("image_dump.txt"));
            }
            else
            {
                Data = null;
            }
        }*/


        public string URL { get; set; } = "";

        public UrlImageDialog()
        {
            InitializeComponent();
            /*treeView1.Nodes.Add(new TreeNode("Saved"));
            TreeNode[] f = new TreeNode[]
            {
                new TreeNode("Frigates"),
                new TreeNode("Destroyers"),
                new TreeNode("Cruisers"),
                new TreeNode("Battlecruisres"),
                new TreeNode("Battleships"),
                new TreeNode("Capitalships"),
            };
            f[0].Nodes.AddRange(new TreeNode[] {
                new TreeNode("Atron",new TreeNode[]{ 
                    new TreeNode("https://www.eve-echoes-compendium.com/build/items/110000007.png"),
                    new TreeNode("https://www.eve-echoes-compendium.com/build/items/10102000005.png"),
                    new TreeNode("https://www.eve-echoes-compendium.com/build/items/10102000004.png"),
                    new TreeNode("https://www.eve-echoes-compendium.com/build/items/110003003.png"),
                }),
                new TreeNode("Daredevil",new TreeNode[]{ new TreeNode("https://www.eve-echoes-compendium.com/build/items/110004013.png") }),
                new TreeNode("Dramiel",new TreeNode[]{ new TreeNode("https://www.eve-echoes-compendium.com/build/items/110000013.png") }),
            });
            
            treeView1.Nodes.Add(new TreeNode("Default",f));*/

        }
        /*
        private void LoadXmlDataFromNode()
        {

        }
        */
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
            DialogResult = DialogResult.OK;
        }
        
        private void UrlImageDialog_FormClosing(object sender, FormClosingEventArgs e)
        {

        }
    }
}
