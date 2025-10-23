using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Form2 : Form
    {
        public delegate void _SendDataBack(object sender, int ID);
        public event _SendDataBack OnPersonSelected = delegate {};
        //better to initialize your event to prevent null reference + use ?.invoke

        [DllImport("kernel32.dll")]
        static extern bool AllocConsole();
        public Form2()
        {
            InitializeComponent();
            AllocConsole();
        }
        //delegation used to call all the subscribed functions
        private void button1_Click(object sender, EventArgs e)
        {
            this.OnPersonSelected?.Invoke(this, Convert.ToInt32(this.textBox1.Text));
        }
    }
}
