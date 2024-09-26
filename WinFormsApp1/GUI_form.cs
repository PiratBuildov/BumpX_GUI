using System.ComponentModel;
using System.Configuration;
using System.Diagnostics;
using System.Reflection;
using System.Security.Cryptography;
using System.Windows.Forms.VisualStyles;

namespace WinFormsApp1
{
    public partial class GUI_form : Form
    {
        public GUI_form()
        {
            InitializeComponent();

            this.quality_changer.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MaximizeBox = false;
            force_lin_gloss.Checked = true;
            quality_changer.SelectedIndex = 0;
            if (!File.Exists("./bumpx.exe"))
            {
                this.TopMost = true;
                MessageBox.Show("bumpx.exe not detected!",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error,
                    MessageBoxDefaultButton.Button1);
                this.TopMost = false;
                this.Close();
            }
            if (!File.Exists("./cudart64_110.dll"))
            {
                this.TopMost = true;
                MessageBox.Show("cudart64_110.dll not detected!",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error,
                    MessageBoxDefaultButton.Button1);
                this.TopMost = false;
                this.Close();
            }
            if (!File.Exists("./nvtt30106.dll"))
            {
                this.TopMost = true;
                MessageBox.Show("nvtt30106.dll not detected!",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error,
                    MessageBoxDefaultButton.Button1);
                this.TopMost = false;
                this.Close();
            }

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btn_choose_nmap_Click(object sender, EventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();
            file.InitialDirectory = Application.StartupPath;
            file.Title = "Choose normal map";
            file.Filter = "Targa (*.tga)|*.tga|PNG (*.png)|*.png|BMP (*.bmp)|*.bmp|JPEG (*.jpg)|*.jpg";
            file.ShowDialog();
            if (!file.FileName.Equals(""))
            {
                nmap_text_box.Text = $"\"{file.FileName}\"";
                nmap_text_box.ReadOnly = true;
                nmap_text_box.Enabled = true;
            }

        }

        private void openFileDialog1_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void btn_choose_gloss_Click(object sender, EventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();
            file.InitialDirectory = Application.StartupPath;
            file.Title = "Choose gloss map";
            file.Filter = "Targa (*.tga)|*.tga|PNG (*.png)|*.png|BMP (*.bmp)|*.bmp|JPEG (*.jpg)|*.jpg";
            file.ShowDialog();
            if (!file.FileName.Equals(""))
            {
                gloss_text_box.Text = $"\"{file.FileName}\"";
                gloss_text_box.ReadOnly = true;
                gloss_text_box.Enabled = true;
            }

        }

        private void btn_choose_height_Click(object sender, EventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();
            file.InitialDirectory = Application.StartupPath;
            file.Title = "Choose height map";
            file.Filter = "Targa (*.tga)|*.tga|PNG (*.png)|*.png|BMP (*.bmp)|*.bmp|JPEG (*.jpg)|*.jpg";
            file.ShowDialog();
            if (!file.FileName.Equals(""))
            {
                hmap_text_box.Text = $"\"{file.FileName}\"";
                hmap_text_box.ReadOnly = true;
                hmap_text_box.Enabled = true;
            }

        }

        private void btn_create_bump_Click(object sender, EventArgs e)
        {
            String nmap;
            String gloss;
            String hmap;
            String quality_index;
            String output = "";
            String lin_gloss_check;
            String bumpx_dir;
            bumpx_dir = Application.StartupPath;
            if (nmap_text_box.Text == "")
            {
                this.TopMost = true;
                MessageBox.Show("Normal map is empty!",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error,
                    MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.DefaultDesktopOnly);
                this.TopMost = false;
                return;

            }
            else
            {
                nmap = nmap_text_box.Text;
            }
            if (gloss_text_box.Text == "")
            {
                this.TopMost = true;
                MessageBox.Show("Gloss map is empty, default value will be used.",
                "Notification",
                 MessageBoxButtons.OK,
                 MessageBoxIcon.Asterisk,
                 MessageBoxDefaultButton.Button1,
                 MessageBoxOptions.DefaultDesktopOnly);
                this.TopMost = false;
                gloss = "gloss";
            }
            else
            {
                gloss = gloss_text_box.Text;
            }
            if (force_lin_gloss.Checked == true)
            {
                lin_gloss_check = "-l:g";
            }
            else
            {
                lin_gloss_check = "";
            }
            if (hmap_text_box.Text == "")
            {
                this.TopMost = true;
                MessageBox.Show("Height map is empty, default value will be used.",
                "Notification",
                 MessageBoxButtons.OK,
                 MessageBoxIcon.Asterisk,
                 MessageBoxDefaultButton.Button1,
                 MessageBoxOptions.DefaultDesktopOnly);
                this.TopMost = false;
                hmap = "height";
            }
            else
            {
                hmap = hmap_text_box.Text;
            }
            if (bump_text_box.Text != "")
            {
                output = bump_text_box.Text;
            }
            /*            else
                        {
                            output = bump_text_box.Text;
                        }*/
            switch (quality_changer.SelectedIndex)
            {
                case 0:
                    quality_index = "3";
                    break;
                case 1:
                    quality_index = "2";
                    break;
                case 2:
                    quality_index = "1";
                    break;
                case 3:
                    quality_index = "0";
                    break;
                default:
                    quality_index = "3";
                    break;
            }
            ProcessStartInfo psi = new ProcessStartInfo();
            psi.WorkingDirectory = bumpx_dir;
            psi.FileName = "bumpx.exe";
            psi.Arguments = $"-n:{nmap} -g:{gloss} -h:{hmap} {lin_gloss_check} -q:{quality_index} -o:{output}";
            psi.UseShellExecute = false;
            psi.CreateNoWindow = true;
            Process.Start(psi).WaitForExit();
            this.TopMost = true;
            MessageBox.Show("Bump packed succesfully!",
                "Packing done!",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information,
                MessageBoxDefaultButton.Button1,
                MessageBoxOptions.DefaultDesktopOnly
               );
            this.TopMost = false;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btn_dis_bump_Click(object sender, EventArgs e)
        {
            String error_map_check;
            OpenFileDialog file = new OpenFileDialog();
            file.InitialDirectory = Application.StartupPath;
            file.Title = "Choose bump file";
            file.Filter = "_bump texture (*_bump.dds)|*_bump.dds";
            file.ShowDialog();
            ProcessStartInfo psi = new ProcessStartInfo();
            psi.FileName = "bumpx.exe";
            psi.Arguments = $"\"{file.FileName}\"";
            psi.UseShellExecute = false;
            psi.CreateNoWindow = true;
            error_map_check = file.FileName;
            error_map_check = error_map_check.Replace(".dds", "#.dds");
            if (file.FileName != "")
            {
                if (!File.Exists(error_map_check))
                {
                    this.TopMost = true;
                    MessageBox.Show("Couldn't find _bump#",
                    "Unpacking failed!",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error,
                    MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.DefaultDesktopOnly);
                    this.TopMost = false;
                    return;
                }
                Process.Start(psi).WaitForExit();
                this.TopMost = true;
                MessageBox.Show("Bump unpacked succesfully!",
                "Unpacking done!",
                MessageBoxButtons.OK,
                MessageBoxIcon.Asterisk,
                MessageBoxDefaultButton.Button1,
                MessageBoxOptions.DefaultDesktopOnly
                );
                this.TopMost = false;
            }
        }

        private void about_bumpx_Click(object sender, EventArgs e)
        {
            Form form = new About_form();
            form.ShowDialog();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void gloss_text_box_TextChanged(object sender, EventArgs e)
        {
            gloss_text_box.ReadOnly = true;
        }

        private void hmap_text_box_TextChanged(object sender, EventArgs e)
        {
            hmap_text_box.ReadOnly = true;
        }

        private void quality_label_Click(object sender, EventArgs e)
        {

        }

        private void statusStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void nmap_text_box_TabIndexChanged(object sender, EventArgs e)
        {

        }

        private void btn_choose_nmap_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop) &&
                ((e.AllowedEffect & DragDropEffects.Move) == DragDropEffects.Move))

                e.Effect = DragDropEffects.Move;
        }

        private void btn_choose_nmap_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop) && e.Effect == DragDropEffects.Move)
            {
                string[] objects = (string[])e.Data.GetData(DataFormats.FileDrop);
                nmap_text_box.Text = null;
                nmap_text_box.ReadOnly = true;
                for (int i = 0; i < objects.Length; i++)
                {
                    if (objects.All(file => IsValidFileFormat(file, new string[] { ".jpg", ".png", ".tga", ".bmp" })))
                    {
                        nmap_text_box.Text += '"' + objects[i] + '"';
                        nmap_text_box.Enabled = true;
                    }
                    else
                    {
                        this.TopMost = true;
                        MessageBox.Show("Wrong file extension!\nShould be .tga, .png, .jpg or .bmp!",
                        "Error!",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error,
                        MessageBoxDefaultButton.Button1,
                        MessageBoxOptions.DefaultDesktopOnly);
                    }
                }

            }
        }

        private void btn_choose_gloss_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop) && e.Effect == DragDropEffects.Move)
            {
                string[] objects = (string[])e.Data.GetData(DataFormats.FileDrop);
                gloss_text_box.Text = null;
                gloss_text_box.ReadOnly = true;
                for (int i = 0; i < objects.Length; i++)
                {
                    if (objects.All(file => IsValidFileFormat(file, new string[] { ".jpg", ".png", ".tga", ".bmp" })))
                    {
                        gloss_text_box.Text += '"' + objects[i] + '"';
                        gloss_text_box.Enabled = true;
                    }
                    else
                    {
                        this.TopMost = true;
                        MessageBox.Show("Wrong file extension!\nShould be .tga, .png, .jpg or .bmp!",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error,
                        MessageBoxDefaultButton.Button1,
                        MessageBoxOptions.DefaultDesktopOnly);
                    }
                }


            }
        }
        private void btn_choose_gloss_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop) &&
                ((e.AllowedEffect & DragDropEffects.Move) == DragDropEffects.Move))

                e.Effect = DragDropEffects.Move;
        }
        private void btn_choose_hmap_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop) &&
                ((e.AllowedEffect & DragDropEffects.Move) == DragDropEffects.Move))

                e.Effect = DragDropEffects.Move;
        }

        private void btn_choose_hmap_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop) && e.Effect == DragDropEffects.Move)
            {
                string[] objects = (string[])e.Data.GetData(DataFormats.FileDrop);
                hmap_text_box.Text = null;
                hmap_text_box.ReadOnly = true;
                for (int i = 0; i < objects.Length; i++)
                {
                    if (objects.All(file => IsValidFileFormat(file, new string[] { ".jpg", ".png", ".tga", ".bmp" })))
                    {
                        hmap_text_box.Text += '"' + objects[i] + '"';
                        hmap_text_box.Enabled = true;
                    }
                    else
                    {
                        this.TopMost = true;
                        MessageBox.Show("Wrong file extension!\nShould be .tga, .png, .jpg or .bmp!",
                        "Error!",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error,
                        MessageBoxDefaultButton.Button1,
                        MessageBoxOptions.DefaultDesktopOnly);
                    }
                }

            }
        }

        private bool IsValidFileFormat(string filePath, string[] validFormats)
        {
            string fileExtension = Path.GetExtension(filePath).ToLower();
            return validFormats.Contains(fileExtension);
        }
    }
}