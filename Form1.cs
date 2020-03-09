using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace ExplorerZubkov
{
    public partial class Form1 : MetroFramework.Forms.MetroForm
    {
        public Form1()
        {
            InitializeComponent();
            notifyIcon1.Icon = SystemIcons.Information;
            notifyIcon1.Click += notifyIcon1_Click;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DriveInfo[] all_disk = DriveInfo.GetDrives();
            foreach (DriveInfo disk_name in all_disk)
            {
                treeView1.Nodes.Add(disk_name.Name);
            }
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }
        private void open_page(string puti)
        {
            treeView1.Nodes.Clear();
            string[] all_dir = Directory.GetDirectories(@puti);
            foreach (string papka in all_dir)
                treeView1.Nodes.Add(papka);
            string[] all_files = Directory.GetFiles(@puti);
            foreach (string now_file in all_files)
                treeView1.Nodes.Add(now_file);
        }

        private void treeView1_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            metroTextBox1.Text = treeView1.SelectedNode.Text.ToString();
            open_page(metroTextBox1.Text);
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            if (metroTextBox1.Text.Length > 3)
            {
                metroTextBox1.Text = metroTextBox1.Text.Substring(0, metroTextBox1.Text.LastIndexOf('\\'));
                metroTextBox1.Text += '\\';
                open_page(metroTextBox1.Text);
            }
        }

        private void notifyIcon1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            this.Show();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }
    }
}
