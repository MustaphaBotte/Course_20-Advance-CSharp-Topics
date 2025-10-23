
namespace DLMS.WinFormsApp1
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
            showPersonWithFilter1 = new DesktopApp.PersonControl.ShowPersonWithFilter();
            SuspendLayout();
            // 
            // showPersonWithFilter1
            // 
            showPersonWithFilter1.Location = new Point(23, 33);
            showPersonWithFilter1.Name = "showPersonWithFilter1";
            showPersonWithFilter1.Size = new Size(803, 393);
            showPersonWithFilter1.TabIndex = 0;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(849, 456);
            Controls.Add(showPersonWithFilter1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);

        }

        #endregion

        private DesktopApp.PersonControl.ShowPersonWithFilter showPersonWithFilter1;
    }
}
