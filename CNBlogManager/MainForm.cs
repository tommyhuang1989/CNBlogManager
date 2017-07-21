using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace CNBlogManager
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            this.listBox1.DrawMode = DrawMode.OwnerDrawVariable;
            this.listBox1.DrawItem += listBoxMetals_DrawItem;
        }


        private SolidBrush reportsForegroundBrushSelected = new SolidBrush(Color.White);
        private SolidBrush reportsForegroundBrush = new SolidBrush(Color.Black);
        private SolidBrush reportsBackgroundBrushSelected = new SolidBrush(Color.FromKnownColor(KnownColor.Highlight));
        private SolidBrush reportsBackgroundBrush1 = new SolidBrush(Color.White);
        private SolidBrush reportsBackgroundBrush2 = new SolidBrush(Color.YellowGreen);

        private string xmlFilePath;
        private Blog blog;
        private List<BlogItem> blogItem;

        internal List<BlogItem> BlogItem
        {
            get { return blogItem; }
            set { blogItem = value; }
        }

        internal Blog Blog
        {
            get { return blog; }
            set { blog = value; }
        }


        public string XmlFilePath{
            get { return xmlFilePath; }
            set { xmlFilePath = value; }
         }


    void listBoxMetals_DrawItem(object sender, DrawItemEventArgs e)
    {
        e.DrawBackground();
        bool selected = ((e.State & DrawItemState.Selected) == DrawItemState.Selected);

        int index = e.Index;
        if (index >= 0 && index < listBox1.Items.Count)
        {
            string text = listBox1.Items[index].ToString();
            Graphics g = e.Graphics;

            //background:
            SolidBrush backgroundBrush;
            if (selected)
                backgroundBrush = reportsBackgroundBrushSelected;
            else if ((index % 2) == 0)
                backgroundBrush = reportsBackgroundBrush1;
            else
                backgroundBrush = reportsBackgroundBrush2;
            g.FillRectangle(backgroundBrush, e.Bounds);

            //text:
            SolidBrush foregroundBrush = (selected) ? reportsForegroundBrushSelected : reportsForegroundBrush;
            g.DrawString(text, e.Font, foregroundBrush, listBox1.GetItemRectangle(index).Location);
        }

        e.DrawFocusRectangle();
    }

        private void MainForm_Load(object sender, EventArgs e)
        {
            if (this.XmlFilePath == null || this.XmlFilePath == "")
                return;

            ParseXmlFile(this.XmlFilePath);

            lblBlogName.Text = blog.Title;
            listBox1.ItemHeight = 25;
            int i = 0;
            foreach (BlogItem bi in blog.Items)
            {
                i++;
                listBox1.Items.Add(i+". "+bi.Title);
            }

        }

        private void ParseXmlFile(string fileName)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(fileName);

            blog = new Blog();
            blog.Title = xmlDoc.DocumentElement.SelectSingleNode("channel/title").InnerText;
            blog.Link = xmlDoc.DocumentElement.SelectSingleNode("channel/link").InnerText;
            blog.Description = xmlDoc.DocumentElement.SelectSingleNode("channel/description").InnerText;
            blog.Language = xmlDoc.DocumentElement.SelectSingleNode("channel/language").InnerText;
            blog.LastBuildDate = xmlDoc.DocumentElement.SelectSingleNode("channel/lastBuildDate").InnerText;
            blog.PubDate = xmlDoc.DocumentElement.SelectSingleNode("channel/pubDate").InnerText;
            blog.Ttl = xmlDoc.DocumentElement.SelectSingleNode("channel/ttl").InnerText;

            //获取到所有<item>的子节点
            XmlNodeList nodeList = xmlDoc.DocumentElement.SelectNodes("channel/item");

            List<BlogItem> list = new List<BlogItem>();
            //遍历所有子节点
            foreach (XmlNode xn in nodeList)
            {
                BlogItem blogItem = new BlogItem();
                blogItem.Title = xn.SelectSingleNode("title").InnerText;
                blogItem.Link = xn.SelectSingleNode("link").InnerText;
                //blogItem.Creator = xn.SelectSingleNode("dc:creator").InnerText;
                blogItem.Author = xn.SelectSingleNode("author").InnerText;
                blogItem.PubDate = xn.SelectSingleNode("pubDate").InnerText;
                blogItem.Guid = xn.SelectSingleNode("guid").InnerText;
                blogItem.Description = xn.SelectSingleNode("description").InnerText;

                list.Add(blogItem);
            }
            blog.Items = list;
             
        }

        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            string blogTitle = listBox1.SelectedItem.ToString();
            blogTitle = blogTitle.Split('.')[1].Trim();
            foreach (BlogItem bi in blog.Items)
            {
                if (blogTitle.Equals(bi.Title))
                {
                    webBrowser1.DocumentText = bi.Description;
                    break;
                }
            }
        }

        private void 修改ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }


    }
}
