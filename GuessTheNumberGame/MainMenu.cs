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
using System.Timers;
using System.Windows.Forms;

namespace GuessTheNumberGame
{
    public partial class MainMenuForm : Form
    {
        private readonly PictureBox Background;
        private bool IsDragging = false,
                     IsInMain = true;
        private int OpacityValue = 1,
                    LogoKeypoint = 0;

        private Point NewLocation,
                      Offset,
                      MainCurrentLocation;

        private int[] ExpoTransition =
        {
             0, 0, 0, 4, 6, 12, 16, 24, 30, 40, 48, 60, 70, 84, 96, 112, 126, 144, 160, 180,
             198, 220, 240, 264, 286, 300
        };
        #region Difficulty Interface Section  |  Private Objects goes here :3

         

        #endregion

        #region Guess The Number Interface Section  |  Private Objects goes here :3

        #endregion

        public MainMenuForm()
        {
            InitializeComponent(); // the main menu panel :3

            this.StartPosition = FormStartPosition.CenterScreen;
            this.Opacity = 0;
            LogoKeypoint = GuessTheNumberLogo.Location.Y;
        }

        #region Main Menu stuff goes here :3
        private void MainMenuLoad(object sender, EventArgs e)
        {
            //the initialization of the form itself :3
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.FormBorderStyle = FormBorderStyle.None;
            this.BackgroundImage = Properties.Resources.MainMenuBackground;
            this.BackColor = Color.White;
            

            typeof(Form).InvokeMember("DoubleBuffered",
            BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic,
            null, this.MainMenuPanel, new object[] { true }); // double buffer the form

            Thread.Sleep(100); // just not pausing the smoothness :3

            TimeToday.Start(); // starting the time and date process :3
            OpeningTime.Start(); // fading in within the form itself
            OpeningTransition.Start(); // opening transitions

            CountdownTimer.Start();
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
                ClosingTime.Start();
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

        private void WindowLabelClick(object sender, EventArgs e)
        {
            WindowChecking();
        }

        private void FadingTick(object sender, EventArgs e)
        {
            
        }

        private void ClosingTick(object sender, EventArgs e)
        {
            this.Opacity -= .04;
            if(this.Opacity == 0)
            {
                ClosingTime.Stop();
                Application.Exit();
            }
        }

        private void OpeningTick(object sender, EventArgs e)
        {
            this.Opacity += 0.1;
            if(this.Opacity == 1)
            {
                OpeningTime.Stop();
            }
        }

        private void OpningTransitionTick(object sender, EventArgs e)
        {
            if (GuessTheNumberLogo.Location.Y < -35)
            {
                LogoKeypoint += 5;
                GuessTheNumberLogo.Location = new Point(GuessTheNumberLogo.Location.X, LogoKeypoint);
            }
            else
            {
                OpeningTransition.Stop();
            }
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
        private bool IsHoldingNumber = false;

        private void MainMenuPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetterOrDigit(e.KeyChar))
            {
                StringHolder += e.KeyChar.ToString();
                NumberHolderLabel.Location = new Point((this.Width / 2) - (NumberHolderLabel.Width / 2), NumberHolderLabel.Location.Y);
                NumberHolderLabel.Text = StringHolder;
            }
            else
            {
                e.Handled = true;
            }
        }

        private string StringHolder = "";

        private void WaitingTick(object sender, EventArgs e)
        {
            
        }

        private int CurrentNumber = 0;
        private int GuessingLimit = 250;
        private int minutesLeft = 2;
        private int secondsLeft = 0;
        private int Attempts = 4;

        private void CountdownTick(object sender, EventArgs e)
        {
            if (minutesLeft == 0 && secondsLeft == 0)
            {
                CountdownTimer.Stop();
                CountdownLabel.Text = "0:00";
                GuidingLabel.Text = "You're out of time boo :<";
                CountdownTimer.Stop();
            }
            else
            {
                if (secondsLeft == 0)
                {
                    minutesLeft--;
                    secondsLeft = 59;
                }
                else
                {
                    secondsLeft--;
                }

                CountdownLabel.Text = $"{minutesLeft}:{secondsLeft:D2}\n" +
                                      "Attempts: " + Attempts;
                MiddleChecking();
            }
        }

        private int RandomNumber = new Random().Next(0, 250);

        private void MainMenuDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (NumberHolderLabel.Text == "getnumericalvalue") // cheat code for number reference. this should not be abused.
                {
                    GuidingLabel.Text = "Random Number: " + RandomNumber.ToString();
                    MiddleChecking();
                }
                else if (!int.TryParse(StringHolder, out CurrentNumber))
                {
                    StringHolder = null;
                    NumberHolderLabel.Text = "";
                    GuidingLabel.Text = "Input should not\ncontain characters.";
                    MiddleChecking();
                }
                else
                {
                    CurrentNumber = int.Parse(StringHolder);
                    if(CurrentNumber > GuessingLimit)
                    {
                        StringHolder = null;
                        NumberHolderLabel.Text = "";
                        GuidingLabel.Text = "Number Should not be greater\nthan the guessing limit.";
                        MiddleChecking();
                    }
                    else
                    {
                        if(CurrentNumber > RandomNumber)
                        {
                            StringHolder = null;
                            NumberHolderLabel.Text = "";
                            GuidingLabel.Text = "Hint: Current number is greater\nthan the random number.\n" +
                                                "Current Number: " + CurrentNumber;
                            Attempts--;
                            CountdownLabel.Text = $"{minutesLeft}:{secondsLeft:D2}\n" +
                                      "Attempts: " + Attempts;
                            MiddleChecking();
                        }
                        else if(CurrentNumber < RandomNumber)
                        {
                            StringHolder = null;
                            NumberHolderLabel.Text = "";
                            GuidingLabel.Text = GuidingLabel.Text = "Hint: Current number is less\nthan the random number.\n" +
                                                "Current Number: " + CurrentNumber;
                            Attempts--;
                            CountdownLabel.Text = $"{minutesLeft}:{secondsLeft:D2}\n" +
                                      "Attempts: " + Attempts;
                            MiddleChecking();

                        }
                        else
                        {
                            StringHolder = null;
                            NumberHolderLabel.Text = "";
                            GuidingLabel.Text = "You won! Yippie :3";
                            CountdownLabel.Text = null;
                            CountdownTimer.Stop();
                            MiddleChecking();
                        }

                        if(Attempts == 0)
                        {
                            CountdownLabel.Text = null;
                            GuidingLabel.Text = "You ran out of attempts :<\n" +
                                                "Correct Number = " + RandomNumber + "\n" +
                                                "Game Over.";
                            CountdownTimer.Stop();
                        }
                    }
                }
            }
            else if (e.KeyCode == Keys.Back && !string.IsNullOrEmpty(StringHolder))
            {
                StringHolder = StringHolder.Remove(StringHolder.Length - 1);
                NumberHolderLabel.Text = StringHolder;
                MiddleChecking();
            }
            else if (e.KeyCode == Keys.Space)
            {
                StringHolder += " ";
                NumberHolderLabel.Text = StringHolder;
                MiddleChecking();
            }
        }

        private void MiddleChecking()
        {
            NumberHolderLabel.Location = new Point((this.Width / 2) - (NumberHolderLabel.Width / 2), NumberHolderLabel.Location.Y);
            GuidingLabel.Location = new Point((this.Width / 2) - (GuidingLabel.Width / 2), GuidingLabel.Location.Y);
            CountdownLabel.Location = new Point((this.Width / 2) - (CountdownLabel.Width / 2), CountdownLabel.Location.Y);
        }

        #endregion
    }
}
