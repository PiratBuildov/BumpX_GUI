namespace WinFormsApp1
{
    public partial class About_form : Form
    {
        public About_form()
        {
            InitializeComponent();

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            MaximizeBox = false;
            MinimizeBox = false;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
            {
                FileName = "https://github.com/iOrange/bumpx/",
                UseShellExecute = true,
            });
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
            {
                FileName = "https://github.com/PiratBuildov/BumpX_GUI/",
                UseShellExecute = true,
            });
        }
    }
}
