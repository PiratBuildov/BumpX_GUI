namespace WinFormsApp1
{
    partial class About_form
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(About_form));
            label1 = new Label();
            label2 = new Label();
            linkLabel1 = new LinkLabel();
            linkLabel2 = new LinkLabel();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(92, 22);
            label1.Name = "label1";
            label1.Size = new Size(184, 28);
            label1.TabIndex = 0;
            label1.Text = "GUI for BumpX v0.7";
            label1.TextAlign = ContentAlignment.TopCenter;
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(48, 78);
            label2.Name = "label2";
            label2.Size = new Size(258, 63);
            label2.TabIndex = 1;
            label2.Text = "Pirat, Ghoulyaev - GUI development\r\n\r\niOrange - original author of BumpX";
            // 
            // linkLabel1
            // 
            linkLabel1.AutoSize = true;
            linkLabel1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            linkLabel1.Location = new Point(36, 270);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(260, 21);
            linkLabel1.TabIndex = 2;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "https://github.com/IOrange/bumpx/";
            linkLabel1.LinkClicked += linkLabel1_LinkClicked;
            // 
            // linkLabel2
            // 
            linkLabel2.AutoSize = true;
            linkLabel2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            linkLabel2.Location = new Point(36, 240);
            linkLabel2.Name = "linkLabel2";
            linkLabel2.Size = new Size(317, 21);
            linkLabel2.TabIndex = 3;
            linkLabel2.TabStop = true;
            linkLabel2.Text = "https://github.com/PiratBuildov/BumpX_GUI\r\n";
            linkLabel2.LinkClicked += linkLabel2_LinkClicked;
            // 
            // About_form
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(374, 310);
            Controls.Add(linkLabel2);
            Controls.Add(linkLabel1);
            Controls.Add(label2);
            Controls.Add(label1);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "About_form";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "About";
            Load += Form2_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private LinkLabel linkLabel1;
        private LinkLabel linkLabel2;
    }
}