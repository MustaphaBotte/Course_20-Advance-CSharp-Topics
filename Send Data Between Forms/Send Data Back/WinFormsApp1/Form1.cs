namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 Frm2 = new Form2();
            Frm2.OnPersonSelected += (object SenderForm, int ID) =>
            {
                this.textBox1.Text = ID.ToString();
            };

            Frm2.ShowDialog();
        }
    }
}
