using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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
                     IsInMain = true;

        private Point NewLocation,
                      Offset,
                      MainCurrentLocation;
        #region Difficulty Interface Section  |  Private Objects goes here :3

        #endregion

        #region Guess The Number Interface Section  |  Private Objects goes here :3

        #endregion

        public MainMenuForm()
        {
            InitializeComponent(); // the main menu panel :3

            this.StartPosition = FormStartPosition.CenterScreen; ;
            Background = new PictureBox();
            Background = CreateBackground();
        }

        #region Main Menu stuff goes here :3
        private void MainMenuLoad(object sender, EventArgs e)
        {
            //the initialization of the form itself :3
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.FormBorderStyle = FormBorderStyle.None;
            this.BackgroundImage = Properties.Resources.MainMenuBackgroud;
            this.BackColor = Color.White;

            typeof(Form).InvokeMember("DoubleBuffered",
            BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic,
            null, this.MainMenuPanel, new object[] { true }); // double buffer the form

            TimeToday.Start(); // starting the time and date process :3
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

        private void TimeTicking(object sender, EventArgs e)
        {
            TimeLabel.Text = DateTime.Now.ToString("dddd, M/d/yyyy | HH:mm:ss");
        }

        private void GitHubPictureClick(object sender, EventArgs e)
        {
            Process.Start("https://github.com/iid3rp/PythonPioneers-GuessTheNumber");
        }

        private void Label1_Click(object sender, EventArgs e)
        {
            MainCurrentLocation = this.Location;
            var StartDifficultyForm = new StartDifficultyForm(MainCurrentLocation);
            StartDifficultyForm.Show();
            this.Hide();
        }

        private void MainMenuPress(object sender, KeyEventArgs e)
        {
            //StartForm GuessTheGameStart = new StartForm();
            //GuessTheGameStart.Show();
            //this.Hide();
            if (IsInMain)
            {
                DifficultyInterface();
            }
            else
            {
                MainMenuShow();
            }
        }

        private void WindowLabelClick(object sender, EventArgs e)
        {
            WindowChecking();
        }

        private void WindowChecking()
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                WindowLabel.Text = "[]]";
                GitHubPicture.Size = new Size(40, 40);
                GitHubPicture.Location = new Point(GitHubPicture.Location.X, (GitHubPicture.Location.Y - 20));
                GuessTheNumberLogo.Size = new Size(1280, 640);
                this.WindowState = FormWindowState.Maximized;
            }
            else
            {
                WindowLabel.Text = "[]";
                GuessTheNumberLogo.Size = new Size(720, 360);
                GitHubPicture.Size = new Size(20, 20);
                GitHubPicture.Location = new Point(GitHubPicture.Location.X, (GitHubPicture.Location.Y + 20));
                this.WindowState = FormWindowState.Normal;
                this.Size = new Size(1280, 720);
            }
            GuessTheNumberLogo.Location = new Point(((this.Size.Width / 2) - GuessTheNumberLogo.Width / 2), -35);
        }
        #endregion

        #region Diificulty Choices stuff goes here :3
        private void DifficultyInterface()
        {
            IsInMain = false;
            GitHubPicture.Hide();
            GuessTheNumberLogo.Hide();
            PressAnyButtonLabel.Hide();


        }

        #endregion

        #region Main Menu Opening Stuff goes here :3

        private void MainMenuShow()
        {
            IsInMain = true;
            GitHubPicture.Show();
            GuessTheNumberLogo.Show();
            PressAnyButtonLabel.Show();
        }

        #endregion

        #region Starting Process of Guess The Number Game goes here :3

        #endregion

    }
}
