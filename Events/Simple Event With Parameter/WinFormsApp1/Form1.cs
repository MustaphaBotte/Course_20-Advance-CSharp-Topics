namespace DLMS.WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Old Way
            this.showPersonWithFilter1.OnPersonSelected += (int ID) =>
            {
                MessageBox.Show("Person ID = " + ID.ToString());
            };
        }

    
    }
}
