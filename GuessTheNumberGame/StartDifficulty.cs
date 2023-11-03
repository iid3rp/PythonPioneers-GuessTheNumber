using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrayNotify;

namespace GuessTheNumberGame
{
    public partial class StartDifficultyForm : Form
    {
        private bool IsDragging = false;

        private Point offset;
        public StartDifficultyForm(Point CurrentLocation)
        {
            InitializeComponent();
            this.Location = CurrentLocation;
            this.FormBorderStyle = FormBorderStyle.None;
        }

        private void StartDifficultyLoad(object sender, EventArgs e)
        {
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.FormBorderStyle = FormBorderStyle.None;
            typeof(Panel).InvokeMember("DoubleBuffered",
            BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic,
            null, this.DifficultyPanel, new object[] { true });
            if (this.WindowState == FormWindowState.Normal)
            {
                WindowLabel.Text = "[]]";
                this.WindowState = FormWindowState.Maximized;
            }
            else
            {
                WindowLabel.Text = "[]";
                this.WindowState = FormWindowState.Normal;
                this.Size = new Size(1280, 720);
            }
            label2.BackColor = Color.FromArgb(60, Color.White);
        }

        private void WindowClick(object sender, EventArgs e)
        {
            WindowChecking();
        }

        private void ClosingClick(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you wish to exit?", "Exit Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
                Application.Exit();
            }
        }

        private void MinimizeClick(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void WindowChecking()
        {

        }

        private void Label1_Click(object sender, EventArgs e)
        {
            MainMenuForm Form1 = new MainMenuForm();
            Form1.Show();
            this.Close();
        }

        private void WindowDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                IsDragging = true;
                offset = e.Location;
            }
        }

        private void WindowMove(object sender, MouseEventArgs e)
        {
            if (IsDragging)
            {
                Point newLocation = this.PointToScreen(e.Location);
                newLocation.Offset(-offset.X, -offset.Y);
                this.Location = newLocation;
            }
        }

        private void WindowUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                IsDragging = false;
            }
        }
    }
}
