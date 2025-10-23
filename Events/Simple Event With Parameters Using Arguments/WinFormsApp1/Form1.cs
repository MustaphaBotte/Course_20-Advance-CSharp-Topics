namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void showPersonWithFilter2_OnPersonSelected(object sender, DesktopApp.PersonControl.ShowPersonWithFilter.PersonSelectedEventArgs e)
        {
            MessageBox.Show($"Person With ID = {e.PersonID} Found At Time = {e.FountAt.ToString()}");
        }
    }
}
