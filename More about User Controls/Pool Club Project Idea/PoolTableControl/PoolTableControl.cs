using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pool_Club_Project_Idea.PoolTableControl
{
    public partial class PoolTableControl : UserControl
    {
        public class PoolTableInfo:EventArgs
        {
            public int PlayingCountInMinutes;
            public PoolTableInfo(int playingCountInMinutes)
            {
                PlayingCountInMinutes = playingCountInMinutes;
            }
        }
        public event EventHandler<PoolTableInfo> OnPoolTableTimeEnd = delegate { };
        public enum EnStatus { running, suspended, available }
        public EnStatus _CurrentTableStatus = EnStatus.available;
        int Seconds = 0;
        int Minutes = 0;
        int Hours = 0;
        public PoolTableControl()
        {
            
            InitializeComponent();           
            ResetTheTable();
            TableTimer.Tick += HandleCounterTick;
            OnPoolTableTimeEnd += Form1.HandleTableTimeEnd;
            Minutes = 60;
        }
        private void HandleCounterTick(object? sender, EventArgs e)
        {
            this.Seconds += 1;
            if (Seconds == 60)
            {
                Seconds = 0;
                Minutes = Minutes + 1;
            }
            if (Minutes == 60)
            {
                Minutes = 0;
                this.Hours += 1;
            }
            this.TimingLabel.Text = $"{Hours.ToString("D2")}:{Minutes.ToString("D2")}:{Seconds.ToString("D2")}";
        }
        private void StartStopBtn_Click(object sender, EventArgs e)
        {
            if (this._CurrentTableStatus == EnStatus.available || this._CurrentTableStatus == EnStatus.suspended)
            {
                this._CurrentTableStatus = EnStatus.running;
                this.TableTimer.Start();
            }
            else if (this._CurrentTableStatus == EnStatus.running)
            {
                this._CurrentTableStatus = EnStatus.suspended;
                this.TableTimer.Stop();
            }
            SetTable();
        }
        private void EndBtn_Click(object sender, EventArgs e)
        {
            if(this._CurrentTableStatus != EnStatus.available)
            {
                this.TableTimer.Stop();
                int TimeInMinutes = (Hours * 60) + Minutes + (Seconds / 60);
                this.OnPoolTableTimeEnd?.Invoke(this,new PoolTableInfo(TimeInMinutes));
                ResetTheTable();
            }
        }
        private void SetTable()
        {
            if (this._CurrentTableStatus == EnStatus.suspended)
            {              
                this.StartStopBtn.Text = "Continue";
                this.guna2PictureBox1.BackColor = Color.Red;
                this.PoolTableStatus.ForeColor = Color.Red;
                this.PoolTableStatus.Text = "Suspended";
            }
            else if (this._CurrentTableStatus == EnStatus.running)
            {              
                this.StartStopBtn.Text = "Stop";
                this.guna2PictureBox1.BackColor = Color.Green;
                this.PoolTableStatus.ForeColor = Color.Green;
                this.PoolTableStatus.Text = "In use";
            }
        }
        private void ResetTheTable()
        {
            Hours = 0;
            Seconds = 0;
            Minutes = 0;
            this._CurrentTableStatus = EnStatus.available;
            this.PoolTableGroupBox.BackColor = Color.Black;
            this.guna2PictureBox1.BackColor = Color.Transparent;
            this.StartStopBtn.Text = "Start";
            this.TimingLabel.Text = "00:00:00";
            this.PoolTableStatus.Text = "Available";
            this.PoolTableStatus.ForeColor = Color.Blue;
        }
    }
}
