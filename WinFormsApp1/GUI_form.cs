using System.ComponentModel;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Windows.Forms.VisualStyles;

namespace WinFormsApp1
{
    public partial class GUI_form : Form
    {
        public GUI_form()
        {
            InitializeComponent();
            this.TopMost = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MaximizeBox = false;
            quality_changer.SelectedIndex = 0;
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
            file.Title = "Choose normal map";
            file.Filter = "Targa (*.tga)|*.tga|PNG (*.png)|*.png|BMP (*.bmp)|*.bmp|JPEG (*.jpg)|*.jpg";
            file.ShowDialog();
            nmap_text_box.Text = file.FileName;
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
            file.Title = "Choose gloss map";
            file.Filter = "Targa (*.tga)|*.tga|PNG (*.png)|*.png|BMP (*.bmp)|*.bmp|JPEG (*.jpg)|*.jpg";
            file.ShowDialog();
            gloss_text_box.Text = file.FileName;
        }

        private void btn_choose_height_Click(object sender, EventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();
            file.Title = "Choose height map";
            file.Filter = "Targa (*.tga)|*.tga|PNG (*.png)|*.png|BMP (*.bmp)|*.bmp|JPEG (*.jpg)|*.jpg";
            file.ShowDialog();
            hmap_text_box.Text = file.FileName;
        }

        private void btn_create_bump_Click(object sender, EventArgs e)
        {
            String nmap;
            String gloss;
            String hmap;
            String quality_index;
            String output;
            if (nmap_text_box.Text == "")
            {
                MessageBox.Show("Normal map is empty!",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error,
                    MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.DefaultDesktopOnly);
                return;
            }
            else
            {
                nmap = nmap_text_box.Text;
            }
            if (gloss_text_box.Text == "")
            {
                MessageBox.Show("Gloss map is empty, default value will be used.",
                "Notification",
                 MessageBoxButtons.OK,
                 MessageBoxIcon.Asterisk,
                 MessageBoxDefaultButton.Button1,
                 MessageBoxOptions.DefaultDesktopOnly);
                gloss = "gloss";
            }
            else
            {
                gloss = gloss_text_box.Text;
            }
            if (hmap_text_box.Text == "")
            {
                MessageBox.Show("Height map is empty, default value will be used.",
                "Notification",
                 MessageBoxButtons.OK,
                 MessageBoxIcon.Asterisk,
                 MessageBoxDefaultButton.Button1,
                 MessageBoxOptions.DefaultDesktopOnly);
                hmap = "height";
            }
            else
            {
                hmap = hmap_text_box.Text;
            }
            if (bump_text_box.Text == "")
            {
                output = "image";
            }
            else
            {
                output = bump_text_box.Text;
            }
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
            psi.FileName = "bumpx.exe";
            psi.Arguments = $"-n:{nmap} -g:{gloss} -h:{hmap} -l:g -q:{quality_index} -o:{output}";
            Process.Start(psi).WaitForExit();
            MessageBox.Show("Bump packed succesfully!",
                "Packing done!",
                MessageBoxButtons.OK,
                MessageBoxIcon.None,
                MessageBoxDefaultButton.Button1,
                MessageBoxOptions.DefaultDesktopOnly
               );
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btn_choose_bump_Click(object sender, EventArgs e)
        {

        }

        private void btn_dis_bump_Click(object sender, EventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();
            file.Title = "Choose bump file";
            file.Filter = "DirectDraw Surface (*.dds)|*.dds";
            file.ShowDialog();
            ProcessStartInfo psi = new ProcessStartInfo();
            psi.FileName = "bumpx.exe";
            psi.Arguments = $"{file.FileName}";
            if (file.FileName != "")
            {
                Process.Start(psi).WaitForExit();
                MessageBox.Show("Bump unpacked succesfully!",
                "Unpacking done!",
                MessageBoxButtons.OK,
                MessageBoxIcon.None,
                MessageBoxDefaultButton.Button1,
                MessageBoxOptions.DefaultDesktopOnly
                );
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
    }
}