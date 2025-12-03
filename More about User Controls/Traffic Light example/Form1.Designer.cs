namespace WinFormsApp1
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            LightsControl = new TrafficLights.UserControl1();
            label1 = new Label();
            userControl11 = new TrafficLights.UserControl1();
            userControl12 = new TrafficLights.UserControl1();
            userControl13 = new TrafficLights.UserControl1();
            SuspendLayout();
            // 
            // LightsControl
            // 
            LightsControl.BackColor = Color.Transparent;
            LightsControl.Color = TrafficLights.UserControl1.EnColors.Red;
            LightsControl.GreenColorTime = 10;
            LightsControl.Location = new Point(259, 72);
            LightsControl.Name = "LightsControl";
            LightsControl.OrangeColorTime = 10;
            LightsControl.RedColorTime = 10;
            LightsControl.Size = new Size(204, 325);
            LightsControl.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Georgia", 48F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Chocolate;
            label1.Location = new Point(259, 9);
            label1.Name = "label1";
            label1.Size = new Size(441, 72);
            label1.TabIndex = 1;
            label1.Text = "Traffic Light";
            // 
            // userControl11
            // 
            userControl11.BackColor = Color.Transparent;
            userControl11.Color = TrafficLights.UserControl1.EnColors.Green;
            userControl11.GreenColorTime = 10;
            userControl11.Location = new Point(12, 72);
            userControl11.Name = "userControl11";
            userControl11.OrangeColorTime = 10;
            userControl11.RedColorTime = 10;
            userControl11.Size = new Size(204, 325);
            userControl11.TabIndex = 2;
            // 
            // userControl12
            // 
            userControl12.BackColor = Color.Transparent;
            userControl12.Color = TrafficLights.UserControl1.EnColors.Orange;
            userControl12.GreenColorTime = 10;
            userControl12.Location = new Point(496, 72);
            userControl12.Name = "userControl12";
            userControl12.OrangeColorTime = 10;
            userControl12.RedColorTime = 10;
            userControl12.Size = new Size(204, 325);
            userControl12.TabIndex = 3;
            // 
            // userControl13
            // 
            userControl13.BackColor = Color.Transparent;
            userControl13.Color = TrafficLights.UserControl1.EnColors.Red;
            userControl13.GreenColorTime = 10;
            userControl13.Location = new Point(706, 72);
            userControl13.Name = "userControl13";
            userControl13.OrangeColorTime = 10;
            userControl13.RedColorTime = 10;
            userControl13.Size = new Size(204, 325);
            userControl13.TabIndex = 4;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = TrafficLights.Properties.Resources.traffic_sign_outdoors;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(923, 624);
            Controls.Add(userControl13);
            Controls.Add(userControl12);
            Controls.Add(userControl11);
            Controls.Add(label1);
            Controls.Add(LightsControl);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private TrafficLights.UserControl1 LightsControl;
        private Label label1;
        private TrafficLights.UserControl1 userControl11;
        private TrafficLights.UserControl1 userControl12;
        private TrafficLights.UserControl1 userControl13;
    }
}
