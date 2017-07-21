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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSelectFile_Click(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory = "e:\\Tommy";//默认路径，注意这里写路径时要用c:\\而不是c:\
            openFileDialog1.Filter = "XML文件|*.xml";//过滤的文件，以|隔开，如“文本文件|*.*|Java文件|*.java”
            openFileDialog1.RestoreDirectory = true;//但打开对话框后，文件内容有改变了，是否同步刷新
            openFileDialog1.FilterIndex = 1;//当filter有多个时，选择默认的filter，注意，下标时从1开始，如果只有一个filter可以不用写这个属性
            if (openFileDialog1.ShowDialog() == DialogResult.OK)//这个是关键，意思是当你选择了文件后并点击了OK按钮
            {
                lblFilePath.Text = openFileDialog1.FileName; //获取选中文件的路径是通过FileName属性来获得

                btnStart.Enabled = true;
                btnStart.Visible = true;

            }

        }

       

        private void Form1_Load(object sender, EventArgs e)
        {
            //首先隐藏开始按钮
            btnStart.Enabled = false;
            btnStart.Visible = false;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            MainForm mainForm = new MainForm();
            mainForm.XmlFilePath = lblFilePath.Text;
            mainForm.ShowDialog();
            //this.Close();
        }
    }
}
