using System.Diagnostics;
using System.Text.RegularExpressions;

namespace WinFormsApp1
{
    public partial class GUI_form : Form
    {
        private String[] Nmap_Files = new String[0];
        private String[] Gloss_Files = new String[0];
        private String[] Height_Files = new String[0];
        private string Regex_Pattern = @"([^\\]+)$";
        public GUI_form()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            statusStrip1.Enabled = false;
            tsProgressBar.Value = 0;
            bump_text_box.Enabled = false;
            MaximizeBox = false;
            force_lin_gloss.Checked = true;
            quality_changer.SelectedIndex = 0;
            btn_create_bump.Enabled = false;
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

        private void btn_choose_nmap_Click(object sender, EventArgs e)
        {
            bump_text_box.Text = "";
            nmap_text_box.Text = "";
            Nmap_Files = new String[0];
            Height_Files = new String[0];
            Gloss_Files = new String[0];
            OpenFileDialog file = new OpenFileDialog();
            file.InitialDirectory = Application.StartupPath;
            file.Title = "Choose normal map";
            file.Multiselect = true;
            file.Filter = "Targa (*.tga)|*.tga|PNG (*.png)|*.png|BMP (*.bmp)|*.bmp|JPEG (*.jpg)|*.jpg";
            file.ShowDialog();
            if (!file.FileName.Equals(""))
            {
                if (file.FileNames.Length <= 25)
                {
                    foreach (var item in file.FileNames)
                    {
                        Array.Resize<String>(ref Nmap_Files, Nmap_Files.Length + 1);
                        Array.Resize<String>(ref Gloss_Files, Nmap_Files.Length + 1);
                        Array.Resize<String>(ref Height_Files, Nmap_Files.Length + 1);
                        Nmap_Files[Nmap_Files.Length - 1] = item;
                        nmap_text_box.Text += @$"{Regex.Match(item, Regex_Pattern).Value}, ";
                        nmap_text_box.ReadOnly = true;
                        nmap_text_box.Enabled = true;
                    }
                }
                else
                {
                    this.TopMost = true;
                    MessageBox.Show("Too many normals choosen!\nMaximum number of normals for once is 25",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error,
                        MessageBoxDefaultButton.Button1,
                        MessageBoxOptions.DefaultDesktopOnly);
                    this.TopMost = false;
                }
                btn_create_bump.Enabled = true;
                statusStrip1.Enabled = true;
                tsStatusText.Text = "Ready";
            }
            if (Nmap_Files.Length == 1)
            {
                bump_text_box.Enabled = true;
            }
            else
            {
                bump_text_box.Enabled = false;
            }
        }

        private void btn_choose_gloss_Click(object sender, EventArgs e)
        {
            gloss_text_box.Text = "";
            OpenFileDialog file = new OpenFileDialog();
            file.InitialDirectory = Application.StartupPath;
            file.Title = "Choose gloss map";
            file.Filter = "Targa (*.tga)|*.tga|PNG (*.png)|*.png|BMP (*.bmp)|*.bmp|JPEG (*.jpg)|*.jpg";
            file.Multiselect = true;
            file.ShowDialog();
            if (!file.FileName.Equals(""))
            {
                if (file.FileNames.Length <= Nmap_Files.Length)
                {
                    for (var i = 0; i < file.FileNames.Length; i++)
                    {
                        Gloss_Files[i] = file.FileNames[i];
                        gloss_text_box.Text += @$"{Regex.Match(file.FileNames[i], Regex_Pattern).Value}, ";
                        gloss_text_box.ReadOnly = true;
                        gloss_text_box.Enabled = true;
                    }
                }
                else
                {
                    this.TopMost = true;
                    MessageBox.Show("Number of chosen gloss maps doesn't equal to the number of choosen normal maps!",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error,
                        MessageBoxDefaultButton.Button1,
                        MessageBoxOptions.DefaultDesktopOnly);
                    this.TopMost = false;
                }

            }
        }

        private void btn_choose_height_Click(object sender, EventArgs e)
        {

            hmap_text_box.Text = "";
            OpenFileDialog file = new OpenFileDialog();
            file.InitialDirectory = Application.StartupPath;
            file.Title = "Choose height map";
            file.Filter = "Targa (*.tga)|*.tga|PNG (*.png)|*.png|BMP (*.bmp)|*.bmp|JPEG (*.jpg)|*.jpg";
            file.Multiselect = true;
            file.ShowDialog();
            if (!file.FileName.Equals(""))
            {
                if (file.FileNames.Length <= Nmap_Files.Length)
                {
                    for (var i = 0; i < file.FileNames.Length; i++)
                    {
                        Height_Files[i] = file.FileNames[i];
                        hmap_text_box.Text += @$"{Regex.Match(file.FileNames[i], Regex_Pattern).Value}, ";
                        hmap_text_box.ReadOnly = true;
                        hmap_text_box.Enabled = true;
                    }
                }
                else
                {
                    this.TopMost = true;
                    MessageBox.Show("Number of chosen height maps doesn't equal to the number of choosen normal maps!",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error,
                        MessageBoxDefaultButton.Button1,
                        MessageBoxOptions.DefaultDesktopOnly);
                    this.TopMost = false;
                }

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
            FolderBrowserDialog pack_out_dialog = new FolderBrowserDialog();
            bumpx_dir = Application.StartupPath;
            String pack_path = bumpx_dir;
            if (Nmap_Files.Length == 0)
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
                tsStatusText.Text = "Ready";
            }
            if (Gloss_Files.Length == 0)
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
            if (force_lin_gloss.Checked == true)
            {
                lin_gloss_check = "-l:g";
            }
            else
            {
                lin_gloss_check = "";
            }
            if (Height_Files.Length == 0)
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
            if (bump_text_box.Text != "")
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
            tsProgressBar.Maximum = Nmap_Files.Length;
            tsProgressBar.Step = 1;
            ProcessStartInfo psi = new ProcessStartInfo();
            psi.WorkingDirectory = bumpx_dir;
            psi.FileName = @"bumpx.exe";
            psi.UseShellExecute = false;
            psi.CreateNoWindow = true;
            if (pack_output_path.Checked)
            {
                if (pack_out_dialog.ShowDialog() == DialogResult.OK)
                {
                    pack_path = pack_out_dialog.SelectedPath;
                    goto output_full_path;
                }
                else
                {
                    pack_path = bumpx_dir;
                    this.TopMost = true;
                    DialogResult result = MessageBox.Show("No path was selected!\nContinue packing?\nThe bump will be packed in the default application folder.",
                            "No path was selected!",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question,
                            MessageBoxDefaultButton.Button1,
                            MessageBoxOptions.DefaultDesktopOnly);
                    this.TopMost = false;
                    if (result == DialogResult.Yes)
                    {
                        goto output_def;
                    }
                    else {
                        pack_path = "";
                        tsStatusText.Text = "Packing: Cancelled";
                        return;
                    }
                }
            output_full_path:
                output = @$"{pack_path}\\{output}";
            }
        output_def:
            for (int i = 0; i < Nmap_Files.Length; i++)
            {
                psi.Arguments = $"-n:\"{Nmap_Files[i]}\" -g:\"{Gloss_Files[i]}\" -h:\"{Height_Files[i]}\" {lin_gloss_check} -q:{quality_index} -o:\"{output}\"";
                tsStatusText.Text = $"Packing {i + 1}/{Nmap_Files.Length}...";
                tsProgressBar.PerformStep();
                Process.Start(psi).WaitForExit();
                tsStatusText.Text = "Packing done!";
            }
        }

        private void btn_dis_bump_Click(object sender, EventArgs e)
        {
            tsProgressBar.Value = 0;
            String unpack_output = "";
            String error_map_check;
            FolderBrowserDialog unpack_out_dialog = new FolderBrowserDialog();
            String unpack_path = Application.StartupPath;
            OpenFileDialog file = new OpenFileDialog();
            file.InitialDirectory = Application.StartupPath;
            file.Title = "Choose bump file";
            file.Filter = "_bump texture (bump.dds)|*bump.dds";
            file.Multiselect = true;
            file.ShowDialog();
            if (!file.FileNames.Equals(""))
            {
                statusStrip1.Enabled = true;
                if (file.FileNames.Length <= 25)
                {
                    tsProgressBar.Maximum = file.FileNames.Length;
                    tsProgressBar.Step = 1;
                    ProcessStartInfo psi = new ProcessStartInfo();
                    psi.FileName = @"bumpx.exe";
                    psi.UseShellExecute = false;
                    psi.CreateNoWindow = true;
                    psi.WorkingDirectory = Application.StartupPath;
                    if (unpack_output_path.Checked)
                    {
                        if (unpack_out_dialog.ShowDialog() == DialogResult.OK)
                        {
                            unpack_path = unpack_out_dialog.SelectedPath;
                            goto unpack_full_path;
                        }
                        else
                        {
                            //unpack_path = bumpx_dir;
                            this.TopMost = true;
                            DialogResult result = MessageBox.Show("No path was selected!\nContinue unpacking?\nThe bump will be unpacked in the default application folder.",
                                    "No path was selected!",
                                    MessageBoxButtons.YesNo,
                                    MessageBoxIcon.Question,
                                    MessageBoxDefaultButton.Button1,
                                    MessageBoxOptions.DefaultDesktopOnly);
                            this.TopMost = false;
                            if (result == DialogResult.Yes)
                            {
                                goto unpack_def;
                            }
                            else
                            {
                                unpack_path = "";
                                tsStatusText.Text = "Unpacking: Cancelled";
                                return;
                            }
                        }
                    unpack_full_path:
                        unpack_output = @$"{unpack_path}\\{unpack_output}";
                    }
                unpack_def:
                    for (var i = 0; i < file.FileNames.Length; i++)
                    {
                        psi.Arguments = $"\"{file.FileNames[i]}\" \"{unpack_output}\"";
                        var bump_map_size = new FileInfo(file.FileNames[i]).Length;
                        error_map_check = file.FileNames[i].Replace(".dds", "#.dds");
                        if (!File.Exists(error_map_check))
                        {
                            this.TopMost = true;
                            MessageBox.Show("Couldn't find _bump#",
                            "Unpacking failed!",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error,
                            MessageBoxDefaultButton.Button1,
                            MessageBoxOptions.DefaultDesktopOnly);
                            tsStatusText.Text = "Invalid bump! Unpacking cancelled";
                            this.TopMost = false;
                            break;
                        }
                        else
                        {
                            var error_map_size = new FileInfo(error_map_check).Length;
                            if (error_map_size != bump_map_size || bump_map_size != error_map_size)
                            {
                                this.TopMost = true;
                                MessageBox.Show("_bump and _bump# maps are not of the same size!",
                                "Unpacking failed!",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error,
                                MessageBoxDefaultButton.Button1,
                                MessageBoxOptions.DefaultDesktopOnly);
                                tsStatusText.Text = "Invalid bump! Unpacking cancelled";
                                this.TopMost = false;
                            }
                            else
                            {
                                Process.Start(psi).WaitForExit();
                                tsProgressBar.PerformStep();
                                tsStatusText.Text = $"Unpacking {i + 1}/{file.FileNames.Length}...";
                                tsStatusText.Text = "Unpacking done!";
                            }
                        }
                    }
                }
            }
        }

        private void about_bumpx_Click(object sender, EventArgs e)
        {
            Form form = new About_form();
            form.ShowDialog();
        }
        private void nmap_text_box_TextChanged(object sender, EventArgs e)
        {
            nmap_text_box.ReadOnly = true;
        }

        private void gloss_text_box_TextChanged(object sender, EventArgs e)
        {
            gloss_text_box.ReadOnly = true;
        }

        private void hmap_text_box_TextChanged(object sender, EventArgs e)
        {
            hmap_text_box.ReadOnly = true;
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
                statusStrip1.Enabled = true;
                bump_text_box.Text = "";
                nmap_text_box.Text = "";
                Nmap_Files = new String[0];
                string[] objects = (string[])e.Data.GetData(DataFormats.FileDrop);
                nmap_text_box.Text = null;
                nmap_text_box.ReadOnly = true;
                for (int i = 0; i < objects.Length; i++)
                {
                    if (objects.All(file => IsValidFileFormat(file, new string[] { ".jpg", ".png", ".tga", ".bmp" })))
                    {
                        Array.Resize<String>(ref Nmap_Files, Nmap_Files.Length + 1);
                        Nmap_Files[Nmap_Files.Length - 1] = objects[i];
                        nmap_text_box.Text += @$"{Regex.Match(objects[i], Regex_Pattern).Value}, ";
                        nmap_text_box.ReadOnly = true;
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
                    btn_create_bump.Enabled = true;
                }
                if (Nmap_Files.Length == 1)
                {
                    bump_text_box.Enabled = true;
                }
                else
                {
                    bump_text_box.Enabled = false;
                }
            }
        }

        private void btn_choose_gloss_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop) && e.Effect == DragDropEffects.Move)
            {
                gloss_text_box.Text = "";
                Gloss_Files = new String[0];
                string[] objects = (string[])e.Data.GetData(DataFormats.FileDrop);
                gloss_text_box.Text = null;
                gloss_text_box.ReadOnly = true;
                for (int i = 0; i < objects.Length; i++)
                {
                    if (objects.All(file => IsValidFileFormat(file, new string[] { ".jpg", ".png", ".tga", ".bmp" })))
                    {
                        Array.Resize<String>(ref Gloss_Files, Nmap_Files.Length + 1);
                        Gloss_Files[i] = objects[i];
                        gloss_text_box.Text += @$"{Regex.Match(objects[i], Regex_Pattern).Value}, ";
                        gloss_text_box.ReadOnly = true;
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
                hmap_text_box.Text = "";
                Height_Files = new String[0];
                string[] objects = (string[])e.Data.GetData(DataFormats.FileDrop);
                hmap_text_box.Text = null;
                hmap_text_box.ReadOnly = true;
                for (int i = 0; i < objects.Length; i++)
                {
                    if (objects.All(file => IsValidFileFormat(file, new string[] { ".jpg", ".png", ".tga", ".bmp" })))
                    {
                        Array.Resize<String>(ref Height_Files, Nmap_Files.Length + 1);
                        Height_Files[i] = objects[i];
                        hmap_text_box.Text += @$"{Regex.Match(objects[i], Regex_Pattern).Value}, ";
                        hmap_text_box.ReadOnly = true;
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

        private void btn_clear_input_Click(object sender, EventArgs e)
        {
            nmap_text_box.Text = "";
            nmap_text_box.Enabled = false;
            gloss_text_box.Text = "";
            gloss_text_box.Enabled = false;
            hmap_text_box.Text = "";
            hmap_text_box.Enabled = false;
            bump_text_box.Text = "";
            bump_text_box.Enabled = false;
            btn_create_bump.Enabled = false;
            tsProgressBar.Value = 0;
            tsStatusText.Text = "Waiting";
            statusStrip1.Enabled = false;
        }
    }
}