using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1: Form
    {
        //Rules : Send Data to form only using Constructor (Remember)
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (int.TryParse(textBox1.Text, out int ID))
            {
               (new Form2(ID)).ShowDialog();
            }
            else
                MessageBox.Show("Enter a valid person id", "invalid id");
        }
    }
}
