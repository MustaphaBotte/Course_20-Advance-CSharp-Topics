using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
   
    public partial class GetTastInfoFrm: Form
    {
        public class TaskInfo : EventArgs
        {
            public int ID;
            public string Url = "";
            public string DownloadPath = "";
            
            public TaskInfo(string url, string downloadPath)
            {
                Url = url;
                DownloadPath = downloadPath;
            }
        }
        public event EventHandler<TaskInfo> OnDownloadInfoReady = delegate { };
        public GetTastInfoFrm()
        {
            InitializeComponent();
        }

        private void AddBtn_MouseEnter(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void AddBtn_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void AddBtn_Click(object sender, EventArgs e)
        {
            string Downpath = DownloadPathTextBox.Text;
            string Url = UrlTextBox.Text;
            if(Downpath == "")
            {
                MessageBox.Show("Please select a download path", "Download Path Required", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (Url == "")
            {
                MessageBox.Show("Please Fill the url field", "url Required", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (Downpath == "")
            {
                MessageBox.Show("Please select a download path", "Download Path Required", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (Url == "" && Downpath == "")
            {
                MessageBox.Show("Please Fill the url and download path fields", "Required info", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            this.OnDownloadInfoReady?.Invoke(this, new TaskInfo(Url, Downpath));
            this.UrlTextBox.Clear();
        }

        private void DownloadPathBtn_Click(object sender, EventArgs e)
        {
            string Path = "";
            using(FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog())
            {
                folderBrowserDialog.Description = "Select a folder";
                folderBrowserDialog.ShowNewFolderButton = true;
                if(folderBrowserDialog.ShowDialog()==DialogResult.OK)
                {
                    Path = folderBrowserDialog.SelectedPath;
                    this.DownloadPathTextBox.Text = Path;
                    File.WriteAllText("../../Path.txt", Path);
                   
                }
            }
        }

        private void GetTastInfoFrm_Load(object sender, EventArgs e)
        {
            string Path = File.ReadAllText("../../Path.txt");
            if(Path!="")
            {
                this.DownloadPathTextBox.Text = Path;
            }
        }
    }
}
