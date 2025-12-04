namespace Pool_Club_Project_Idea.PoolTableControl
{
    partial class PoolTableControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            PoolTableGroupBox = new GroupBox();
            guna2PictureBox1 = new Guna.UI2.WinForms.Guna2PictureBox();
            TimingLabel = new Guna.UI2.WinForms.Guna2HtmlLabel();
            EndBtn = new Guna.UI2.WinForms.Guna2Button();
            StartStopBtn = new Guna.UI2.WinForms.Guna2Button();
            TableTimer = new System.Windows.Forms.Timer(components);
            PoolTableStatus = new Guna.UI2.WinForms.Guna2HtmlLabel();
            PoolTableGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)guna2PictureBox1).BeginInit();
            SuspendLayout();
            // 
            // PoolTableGroupBox
            // 
            PoolTableGroupBox.BackColor = Color.Transparent;
            PoolTableGroupBox.BackgroundImageLayout = ImageLayout.Center;
            PoolTableGroupBox.Controls.Add(guna2PictureBox1);
            PoolTableGroupBox.Controls.Add(TimingLabel);
            PoolTableGroupBox.Controls.Add(EndBtn);
            PoolTableGroupBox.Controls.Add(StartStopBtn);
            PoolTableGroupBox.Font = new Font("Times New Roman", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            PoolTableGroupBox.ForeColor = Color.Maroon;
            PoolTableGroupBox.Location = new Point(19, 23);
            PoolTableGroupBox.Name = "PoolTableGroupBox";
            PoolTableGroupBox.Size = new Size(340, 195);
            PoolTableGroupBox.TabIndex = 0;
            PoolTableGroupBox.TabStop = false;
            PoolTableGroupBox.Text = "Table";
            // 
            // guna2PictureBox1
            // 
            guna2PictureBox1.BackgroundImage = Properties.Resources.pool;
            guna2PictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
            guna2PictureBox1.CustomizableEdges = customizableEdges1;
            guna2PictureBox1.FillColor = Color.Transparent;
            guna2PictureBox1.ImageFlip = Guna.UI2.WinForms.Enums.FlipOrientation.Horizontal;
            guna2PictureBox1.ImageRotate = 0F;
            guna2PictureBox1.Location = new Point(6, 24);
            guna2PictureBox1.Name = "guna2PictureBox1";
            guna2PictureBox1.ShadowDecoration.CustomizableEdges = customizableEdges2;
            guna2PictureBox1.Size = new Size(205, 128);
            guna2PictureBox1.TabIndex = 1;
            guna2PictureBox1.TabStop = false;
            // 
            // TimingLabel
            // 
            TimingLabel.BackColor = Color.Transparent;
            TimingLabel.Font = new Font("Times New Roman", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            TimingLabel.ForeColor = SystemColors.ButtonFace;
            TimingLabel.Location = new Point(128, 158);
            TimingLabel.Name = "TimingLabel";
            TimingLabel.Size = new Size(65, 26);
            TimingLabel.TabIndex = 2;
            TimingLabel.Text = "Timing";
            // 
            // EndBtn
            // 
            EndBtn.BorderColor = Color.DarkGreen;
            EndBtn.BorderRadius = 15;
            EndBtn.BorderThickness = 1;
            EndBtn.CustomizableEdges = customizableEdges3;
            EndBtn.DisabledState.BorderColor = Color.DarkGray;
            EndBtn.DisabledState.CustomBorderColor = Color.DarkGray;
            EndBtn.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            EndBtn.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            EndBtn.FillColor = Color.Crimson;
            EndBtn.Font = new Font("Segoe UI", 9F);
            EndBtn.ForeColor = Color.Black;
            EndBtn.Location = new Point(228, 69);
            EndBtn.Name = "EndBtn";
            EndBtn.ShadowDecoration.CustomizableEdges = customizableEdges4;
            EndBtn.Size = new Size(96, 39);
            EndBtn.TabIndex = 1;
            EndBtn.Text = "End";
            EndBtn.Click += EndBtn_Click;
            // 
            // StartStopBtn
            // 
            StartStopBtn.BorderColor = Color.DarkGreen;
            StartStopBtn.BorderRadius = 15;
            StartStopBtn.BorderThickness = 1;
            StartStopBtn.CustomizableEdges = customizableEdges5;
            StartStopBtn.DisabledState.BorderColor = Color.DarkGray;
            StartStopBtn.DisabledState.CustomBorderColor = Color.DarkGray;
            StartStopBtn.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            StartStopBtn.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            StartStopBtn.FillColor = Color.Lime;
            StartStopBtn.Font = new Font("Segoe UI", 9F);
            StartStopBtn.ForeColor = Color.Black;
            StartStopBtn.Location = new Point(228, 24);
            StartStopBtn.Name = "StartStopBtn";
            StartStopBtn.ShadowDecoration.CustomizableEdges = customizableEdges6;
            StartStopBtn.Size = new Size(96, 39);
            StartStopBtn.TabIndex = 0;
            StartStopBtn.Text = "Start";
            StartStopBtn.Click += StartStopBtn_Click;
            // 
            // TableTimer
            // 
            TableTimer.Interval = 1000;
            // 
            // PoolTableStatus
            // 
            PoolTableStatus.BackColor = Color.Transparent;
            PoolTableStatus.Font = new Font("Times New Roman", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            PoolTableStatus.ForeColor = SystemColors.ButtonFace;
            PoolTableStatus.Location = new Point(145, 0);
            PoolTableStatus.Name = "PoolTableStatus";
            PoolTableStatus.Size = new Size(59, 26);
            PoolTableStatus.TabIndex = 3;
            PoolTableStatus.Text = "Status";
            // 
            // PoolTableControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            BackgroundImageLayout = ImageLayout.Stretch;
            BorderStyle = BorderStyle.FixedSingle;
            Controls.Add(PoolTableStatus);
            Controls.Add(PoolTableGroupBox);
            DoubleBuffered = true;
            Name = "PoolTableControl";
            Size = new Size(377, 231);
            PoolTableGroupBox.ResumeLayout(false);
            PoolTableGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)guna2PictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox PoolTableGroupBox;
        private Guna.UI2.WinForms.Guna2HtmlLabel TimingLabel;
        private Guna.UI2.WinForms.Guna2Button EndBtn;
        private Guna.UI2.WinForms.Guna2Button StartStopBtn;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox1;
        private System.Windows.Forms.Timer TableTimer;
        private Guna.UI2.WinForms.Guna2HtmlLabel PoolTableStatus;
    }
}
