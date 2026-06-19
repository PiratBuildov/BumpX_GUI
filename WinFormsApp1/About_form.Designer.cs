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
            groupBox1 = new GroupBox();
            linkLabel1 = new LinkLabel();
            label1 = new Label();
            label2 = new Label();
            linkLabel2 = new LinkLabel();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBox1.BackColor = Color.Transparent;
            groupBox1.BackgroundImageLayout = ImageLayout.Center;
            groupBox1.Controls.Add(linkLabel1);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(linkLabel2);
            groupBox1.ForeColor = SystemColors.ControlText;
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(266, 203);
            groupBox1.TabIndex = 5;
            groupBox1.TabStop = false;
            // 
            // linkLabel1
            // 
            linkLabel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            linkLabel1.Font = new Font("Segoe UI", 12F);
            linkLabel1.Location = new Point(0, 135);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(266, 21);
            linkLabel1.TabIndex = 2;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "BumpX GitHub";
            linkLabel1.TextAlign = ContentAlignment.TopCenter;
            linkLabel1.LinkClicked += linkLabel1_LinkClicked;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI", 15F);
            label1.Location = new Point(0, 19);
            label1.Name = "label1";
            label1.Size = new Size(266, 28);
            label1.TabIndex = 0;
            label1.Text = "GUI for BumpX v0.7";
            label1.TextAlign = ContentAlignment.TopCenter;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label2.Font = new Font("Segoe UI", 12F);
            label2.Location = new Point(0, 61);
            label2.Name = "label2";
            label2.Size = new Size(266, 74);
            label2.TabIndex = 1;
            label2.Text = "Pirat, Ghoulyaev - GUI development\r\n\r\niOrange - original author of BumpX";
            label2.TextAlign = ContentAlignment.TopCenter;
            // 
            // linkLabel2
            // 
            linkLabel2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            linkLabel2.Font = new Font("Segoe UI", 12F);
            linkLabel2.Location = new Point(0, 166);
            linkLabel2.Name = "linkLabel2";
            linkLabel2.Size = new Size(266, 21);
            linkLabel2.TabIndex = 3;
            linkLabel2.TabStop = true;
            linkLabel2.Text = "GUI GitHub";
            linkLabel2.TextAlign = ContentAlignment.TopCenter;
            linkLabel2.LinkClicked += linkLabel2_LinkClicked;
            // 
            // About_form
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(292, 240);
            Controls.Add(groupBox1);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "About_form";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "About";
            Load += Form2_Load;
            groupBox1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private Label label2;
        private Label label1;
        private LinkLabel linkLabel2;
        private LinkLabel linkLabel1;
    }
}