namespace WinFormsApp1
{
    partial class GUI_form
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GUI_form));
            nmap_label = new Label();
            btn_choose_nmap = new Button();
            btn_choose_gloss = new Button();
            gloss_label = new Label();
            btn_choose_height = new Button();
            height_label = new Label();
            menuStrip1 = new MenuStrip();
            about_bumpx = new ToolStripMenuItem();
            btn_dis_bump = new Button();
            btn_create_bump = new Button();
            openFileDialog1 = new OpenFileDialog();
            nmap_text_box = new TextBox();
            gloss_text_box = new TextBox();
            hmap_text_box = new TextBox();
            label1 = new Label();
            bump_text_box = new TextBox();
            toolTip1 = new ToolTip(components);
            quality_label = new Label();
            quality_changer = new ComboBox();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // nmap_label
            // 
            resources.ApplyResources(nmap_label, "nmap_label");
            nmap_label.Name = "nmap_label";
            nmap_label.Click += label1_Click;
            // 
            // btn_choose_nmap
            // 
            btn_choose_nmap.AllowDrop = true;
            resources.ApplyResources(btn_choose_nmap, "btn_choose_nmap");
            btn_choose_nmap.Name = "btn_choose_nmap";
            toolTip1.SetToolTip(btn_choose_nmap, resources.GetString("btn_choose_nmap.ToolTip"));
            btn_choose_nmap.UseVisualStyleBackColor = true;
            btn_choose_nmap.Click += btn_choose_nmap_Click;
            // 
            // btn_choose_gloss
            // 
            btn_choose_gloss.AllowDrop = true;
            resources.ApplyResources(btn_choose_gloss, "btn_choose_gloss");
            btn_choose_gloss.Name = "btn_choose_gloss";
            toolTip1.SetToolTip(btn_choose_gloss, resources.GetString("btn_choose_gloss.ToolTip"));
            btn_choose_gloss.UseVisualStyleBackColor = true;
            btn_choose_gloss.Click += btn_choose_gloss_Click;
            // 
            // gloss_label
            // 
            resources.ApplyResources(gloss_label, "gloss_label");
            gloss_label.Name = "gloss_label";
            gloss_label.Click += label2_Click;
            // 
            // btn_choose_height
            // 
            btn_choose_height.AllowDrop = true;
            resources.ApplyResources(btn_choose_height, "btn_choose_height");
            btn_choose_height.Name = "btn_choose_height";
            toolTip1.SetToolTip(btn_choose_height, resources.GetString("btn_choose_height.ToolTip"));
            btn_choose_height.UseVisualStyleBackColor = true;
            btn_choose_height.Click += btn_choose_height_Click;
            // 
            // height_label
            // 
            resources.ApplyResources(height_label, "height_label");
            height_label.Name = "height_label";
            height_label.Click += label3_Click;
            // 
            // menuStrip1
            // 
            menuStrip1.BackColor = SystemColors.ControlLight;
            menuStrip1.Items.AddRange(new ToolStripItem[] { about_bumpx });
            resources.ApplyResources(menuStrip1, "menuStrip1");
            menuStrip1.Name = "menuStrip1";
            menuStrip1.ItemClicked += menuStrip1_ItemClicked;
            // 
            // about_bumpx
            // 
            about_bumpx.Name = "about_bumpx";
            resources.ApplyResources(about_bumpx, "about_bumpx");
            about_bumpx.Click += about_bumpx_Click;
            // 
            // btn_dis_bump
            // 
            btn_dis_bump.AllowDrop = true;
            resources.ApplyResources(btn_dis_bump, "btn_dis_bump");
            btn_dis_bump.Name = "btn_dis_bump";
            toolTip1.SetToolTip(btn_dis_bump, resources.GetString("btn_dis_bump.ToolTip"));
            btn_dis_bump.UseVisualStyleBackColor = true;
            btn_dis_bump.Click += btn_dis_bump_Click;
            // 
            // btn_create_bump
            // 
            resources.ApplyResources(btn_create_bump, "btn_create_bump");
            btn_create_bump.Name = "btn_create_bump";
            toolTip1.SetToolTip(btn_create_bump, resources.GetString("btn_create_bump.ToolTip"));
            btn_create_bump.UseVisualStyleBackColor = true;
            btn_create_bump.Click += btn_create_bump_Click;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            openFileDialog1.FileOk += openFileDialog1_FileOk;
            // 
            // nmap_text_box
            // 
            resources.ApplyResources(nmap_text_box, "nmap_text_box");
            nmap_text_box.Name = "nmap_text_box";
            // 
            // gloss_text_box
            // 
            resources.ApplyResources(gloss_text_box, "gloss_text_box");
            gloss_text_box.Name = "gloss_text_box";
            // 
            // hmap_text_box
            // 
            resources.ApplyResources(hmap_text_box, "hmap_text_box");
            hmap_text_box.Name = "hmap_text_box";
            // 
            // label1
            // 
            resources.ApplyResources(label1, "label1");
            label1.Name = "label1";
            label1.Click += label1_Click_1;
            // 
            // bump_text_box
            // 
            resources.ApplyResources(bump_text_box, "bump_text_box");
            bump_text_box.Name = "bump_text_box";
            toolTip1.SetToolTip(bump_text_box, resources.GetString("bump_text_box.ToolTip"));
            // 
            // quality_label
            // 
            resources.ApplyResources(quality_label, "quality_label");
            quality_label.Name = "quality_label";
            // 
            // quality_changer
            // 
            quality_changer.FormattingEnabled = true;
            quality_changer.Items.AddRange(new object[] { resources.GetString("quality_changer.Items"), resources.GetString("quality_changer.Items1"), resources.GetString("quality_changer.Items2"), resources.GetString("quality_changer.Items3") });
            resources.ApplyResources(quality_changer, "quality_changer");
            quality_changer.Name = "quality_changer";
            quality_changer.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // GUI_form
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            Controls.Add(quality_changer);
            Controls.Add(quality_label);
            Controls.Add(bump_text_box);
            Controls.Add(label1);
            Controls.Add(hmap_text_box);
            Controls.Add(gloss_text_box);
            Controls.Add(nmap_text_box);
            Controls.Add(btn_create_bump);
            Controls.Add(btn_dis_bump);
            Controls.Add(btn_choose_height);
            Controls.Add(height_label);
            Controls.Add(btn_choose_gloss);
            Controls.Add(gloss_label);
            Controls.Add(btn_choose_nmap);
            Controls.Add(nmap_label);
            Controls.Add(menuStrip1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MainMenuStrip = menuStrip1;
            Name = "GUI_form";
            Load += Form1_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label nmap_label;
        private Button btn_choose_nmap;
        private Button btn_choose_gloss;
        private Label gloss_label;
        private Button btn_choose_height;
        private Label height_label;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem about_bumpx;
        private Button btn_dis_bump;
        private Button btn_create_bump;
        private OpenFileDialog openFileDialog1;
        private TextBox nmap_text_box;
        private TextBox gloss_text_box;
        private TextBox hmap_text_box;
        private Label label1;
        private TextBox bump_text_box;
        private ToolTip toolTip1;
        private Label quality_label;
        private ComboBox quality_changer;
    }
}