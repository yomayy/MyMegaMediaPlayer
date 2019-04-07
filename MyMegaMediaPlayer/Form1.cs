using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms;
using System.IO;

namespace MyMegaMediaPlayer
{
    public partial class Form1 : Form
    {

        List<string> routes;


        public Form1()
        {
            InitializeComponent();
            routes = new List<string>();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if(fbd.ShowDialog() == DialogResult.OK)
            {
                string path = fbd.SelectedPath;
                DirectoryInfo di = new DirectoryInfo(path);
                FileInfo[] audio = di.GetFiles("*.mp3");
                FileInfo[] video = di.GetFiles("*.mp4");

                routes.Clear();
                listBox1.Items.Clear();
                foreach(FileInfo file in audio)
                {
                    listBox1.Items.Add(file.Name);
                    routes.Add(file.FullName);
                }

                foreach (FileInfo file in video)
                {
                    listBox1.Items.Add(file.Name);
                    routes.Add(file.FullName);
                }
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int k = listBox1.SelectedIndex;
            axWindowsMediaPlayer1.URL = routes[k];
            axWindowsMediaPlayer1.Ctlcontrols.play();
        }
    }
}
