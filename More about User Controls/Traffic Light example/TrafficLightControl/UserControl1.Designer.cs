namespace TrafficLights
{
    partial class UserControl1
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
            TrafficLightPicture = new PictureBox();
            Timinglabel = new Label();
            ((System.ComponentModel.ISupportInitialize)TrafficLightPicture).BeginInit();
            SuspendLayout();
            // 
            // TrafficLightPicture
            // 
            TrafficLightPicture.Image = Properties.Resources.Red;
            TrafficLightPicture.Location = new Point(3, 3);
            TrafficLightPicture.Name = "TrafficLightPicture";
            TrafficLightPicture.Size = new Size(185, 277);
            TrafficLightPicture.SizeMode = PictureBoxSizeMode.StretchImage;
            TrafficLightPicture.TabIndex = 0;
            TrafficLightPicture.TabStop = false;
            // 
            // Timinglabel
            // 
            Timinglabel.AutoSize = true;
            Timinglabel.Font = new Font("Javanese Text", 18.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Timinglabel.Location = new Point(64, 283);
            Timinglabel.Name = "Timinglabel";
            Timinglabel.Size = new Size(39, 43);
            Timinglabel.TabIndex = 1;
            Timinglabel.Text = "";
            Timinglabel.ForeColor = System.Drawing.Color.Yellow;

             // 
             // UserControl1
             // 
             AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(Timinglabel);
            Controls.Add(TrafficLightPicture);
            Name = "UserControl1";
            Size = new Size(191, 326);
            ((System.ComponentModel.ISupportInitialize)TrafficLightPicture).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox TrafficLightPicture;
        private Label Timinglabel;
    }
}
