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
    public partial class StartForm : Form
    {
        private bool isDragging = false,
                     isMinimized = true,
                     IsMaximized = false;

        private Point offset;
        public StartForm()
        {
            InitializeComponent();
        }

        private void StartLoad(object sender, EventArgs e)
        {
            this.StartPanel.BackgroundImage = Properties.Resources.MainMenuBackground720p;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            typeof(Panel).InvokeMember("DoubleBuffered",
            BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic,
            null, this.StartPanel, new object[] { true });

            this.FormBorderStyle = FormBorderStyle.None;
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
            if (isMinimized && !(IsMaximized))
            {
                isMinimized = false;
                IsMaximized = true;
                WindowLabel.Text = "[]]";
                this.WindowState = FormWindowState.Maximized;
                this.StartPanel.BackgroundImage = Properties.Resources.MainMenuBackgroud;
            }
            else
            {
                isMinimized = true;
                IsMaximized = false;
                WindowLabel.Text = "[]";
                this.WindowState = FormWindowState.Normal;
                this.StartPanel.BackgroundImage = Properties.Resources.MainMenuBackground720p;
                this.Size = new Size(1280, 720);
            }
        }

        private void WindowDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDragging = true;
                offset = e.Location;
            }
        }

        private void WindowMove(object sender, MouseEventArgs e)
        {
            if (isDragging)
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
                isDragging = false;
            }
        }
    }
}
