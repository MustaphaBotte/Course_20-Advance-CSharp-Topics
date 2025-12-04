using static TrafficLights.UserControl1;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            LightsControl.OnLightColorChanges += TrafficLightcolorChanged;

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.LightsControl.Start();
            this.userControl11.Start();
            this.userControl12.Start();
            this.userControl13.Start();

        }
        private void TrafficLightcolorChanged(LightColor lightColor)
        {
           // System.Diagnostics.Debug.WriteLine($"Current Light Color is {lightColor.Color.ToString()} please wait {lightColor.Timing}s");

             Task.Run(() => MessageBox.Show($"Current Light Color is {lightColor.Color.ToString()} please wait {lightColor.Timing}s"));
        }

    }
}
