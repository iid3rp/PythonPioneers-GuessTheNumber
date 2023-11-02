using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GuessTheNumberGame
{
    public partial class MainMenuForm : Form
    {
        private readonly PictureBox Background;
        private bool IsDragging = false,
                     IsNormal = true,
                     IsMaximized = false;

        private Point NewLocation,
                      Offset,
                      MainCurrentLocation;

        public MainMenuForm()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;

            Background = new PictureBox();
            Background = CreateBackground();
        }

        private void MainMenuLoad(object sender, EventArgs e)
        {
            this.MainMenuPanel.BackgroundImage = Properties.Resources.MainMenuBackground720p;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            typeof(Panel).InvokeMember("DoubleBuffered",
            BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic,
            null, this.MainMenuPanel, new object[] { true });
            this.FormBorderStyle = FormBorderStyle.None;
        }

        private PictureBox CreateBackground()
        {
            Background.Image = Properties.Resources.MainMenuBackgroud;
            Background.SizeMode = PictureBoxSizeMode.StretchImage;
            return Background;
        }

        private void WindowDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                IsDragging = true;
                Offset = e.Location;
            }
        }

        private void WindowMove(object sender, MouseEventArgs e)
        {
            if (IsDragging)
            {
                NewLocation = this.PointToScreen(e.Location);
                NewLocation.Offset(-Offset.X, -Offset.Y);
                this.Location = NewLocation;
            }
        }

        private void WindowUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                IsDragging = false;
            }
        }

        private void ClosingLabelClick(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you wish to exit?", "Exit Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
                Application.Exit();
            }
        }

        private void MinimizeLabelClick(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void Label1_Click(object sender, EventArgs e)
        {
            MainCurrentLocation = this.Location;
            var StartDifficultyForm = new StartDifficultyForm(MainCurrentLocation, 
                                                              IsNormal,
                                                              IsMaximized);
            StartDifficultyForm.Show();
            this.Hide();
        }

        private void MainMenuPress(object sender, KeyEventArgs e)
        {
            StartForm GuessTheGameStart = new StartForm();
            GuessTheGameStart.Show();
            this.Hide();
        }

        private void WindowLabelClick(object sender, EventArgs e)
        {
            WindowChecking();
        }

        private void WindowChecking()
        {
            if (IsNormal && !(IsMaximized))
            {
                IsNormal = false;
                IsMaximized = true;
                WindowLabel.Text = "[]]";
                this.WindowState = FormWindowState.Maximized;
                this.MainMenuPanel.BackgroundImage = Properties.Resources.MainMenuBackgroud;
                Background.Size = this.ClientSize;
            }
            else
            {
                IsNormal = true;
                IsMaximized = false;
                WindowLabel.Text = "[]";
                this.WindowState = FormWindowState.Normal;
                this.MainMenuPanel.BackgroundImage = Properties.Resources.MainMenuBackground720p;
                this.Size = new Size(1280, 720);
                Background.Size = this.ClientSize;
            }
        }
    }
}
