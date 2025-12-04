using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using static TrafficLights.UserControl1;

namespace TrafficLights
{
  
    public partial class UserControl1: UserControl
    {
        public event Action<LightColor> OnLightColorChanges = delegate { };
        CancellationTokenSource tokensource = new CancellationTokenSource();
        public enum EnColors { Red, Green, Orange };
        public EnColors _CurrentLightColor = EnColors.Red;

      

        public class LightColor
        {
            public  EnColors Color = EnColors.Red;
            public  int Timing = 0;
            public LightColor(EnColors color)
            {
                this.Color = color;
                if (this.Color == EnColors.Green)
                    this.Timing = _GreenTime;

                else if (this.Color == EnColors.Orange)
                    this.Timing = _OrangeTime;

                else if (this.Color == EnColors.Red)
                    this.Timing = _RedTime;
            }
            public LightColor Next()
            {
                if(this.Color == EnColors.Red)
                {
                    return new LightColor(EnColors.Orange);
                }
                else if (this.Color == EnColors.Orange)
                {
                    return new LightColor(EnColors.Green);
                }
                else               
                    return new LightColor(EnColors.Red);
                
            }
        }


        private static int _GreenTime = 6;
        private static int _OrangeTime = 5;
        private static int _RedTime = 9;

        [Category("Light Config")]
        public EnColors Color
        {
            set
            {
                this._CurrentLightColor = value;
                if (_CurrentLightColor == EnColors.Green)
                    this.TrafficLightPicture.Image = Properties.Resources.Green;

                else if (_CurrentLightColor == EnColors.Red)
                    this.TrafficLightPicture.Image = Properties.Resources.Red;

                else if (_CurrentLightColor == EnColors.Orange)
                    this.TrafficLightPicture.Image = Properties.Resources.Orange;
            }
            get
            {
                return this._CurrentLightColor;
            }
        }
        [Category("Light Config")]
        public int RedColorTime
        {
            set
            {
                _RedTime = value;
            }
            get
            {
              return _RedTime;
            }
        }
        [Category("Light Config")]
        public int OrangeColorTime
        {
            set
            {
                _OrangeTime = value;
            }
            get
            {
                return _OrangeTime;
            }
        }
        [Category("Light Config")]
        public int GreenColorTime
        {
            set
            {
                _GreenTime = value;
            }
            get
            {
                return _GreenTime;
            }
        }
        public UserControl1()
        {        
            InitializeComponent();
        }

        private void ChangePicture()
        {
            if (_CurrentLightColor == EnColors.Green)
                this.TrafficLightPicture.Image = Properties.Resources.Green;

            else if (_CurrentLightColor == EnColors.Red)
                this.TrafficLightPicture.Image = Properties.Resources.Red;

            else if (_CurrentLightColor == EnColors.Orange)
                this.TrafficLightPicture.Image = Properties.Resources.Orange;
        }
        private void DecrementTime(int seconds)
        {
            if (this.IsDisposed)
                tokensource.Cancel();
            for (int i = seconds; i > 0; i--)
            {               
                Thread.Sleep(1000);
                this.Invoke(delegate () { this.Timinglabel.Text = i.ToString() + "s"; });              
            }
        }
        private void HandleLightColorChanged(LightColor light)
        {
            Task.Run( ()=>
            {
                while (true)
                {
                    DecrementTime(light.Timing);
                    light = light.Next();
                    Color = light.Color;
                    Task.Run(() => MessageBox.Show($"Current Light Color is {light.Color.ToString()} please wait {light.Timing}s"));
                    // log or or do whatever you want
                }
            }, tokensource.Token);
        }             
        public void Start()
        {
            HandleLightColorChanged(new LightColor(_CurrentLightColor));
        }
    }
}
