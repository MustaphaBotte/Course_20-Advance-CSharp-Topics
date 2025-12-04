using static Pool_Club_Project_Idea.PoolTableControl.PoolTableControl;

namespace Pool_Club_Project_Idea
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public static void HandleTableTimeEnd(object?sender,PoolTableInfo poolTable)
        {
            decimal amount = ((decimal)poolTable.PlayingCountInMinutes) * 0.1m;
            MessageBox.Show($"Table Is Now Available. Total Price {amount}$g");
        }
    }
}
