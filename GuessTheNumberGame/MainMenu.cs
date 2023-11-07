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

        #region Private values goes here: :3
        private bool
        IsDragging = false, // the dragging boolean for the form moving in normal form size
        IsANumber = false, // boolean for if the input dosent have characters
        IsDifficultySection = false, // boolean for if the difficulty section is started
        IsGuessingProcess = false; //boolean for if the guessing has started.

        private int
        LogoKeypoint = 0, // GuessTheNumberLogo height keypoint initialization
        DifficultyPage = 0, // difficulty process of the pages.,.,
        MainMenuSwitch = 1, // the main menu interface number holder for the methods.
        CountingDownStart = 3, // counting down when the guessing starts.

        // guessing number variables
        CurrentNumber = 0, // current number holder
        GuessingLimit = 0, // guessing limit numebr to use the limit in the number guess
        minutesLeft = 0, // minutes left of the timer
        secondsLeft = 0, // seconds left of the timer
        Attempts = 0, // amount of attempts of the game
        RandomNumber = 0; // the random number which the player will guess

        private readonly Random rand = new Random();

        private Point
        NewLocation, // New location of the form when the form moves each time
        Offset; // the offset location that will track each time the cursor moves

        private readonly Image[] DifficultyImages = 
        {
            Properties.Resources.TutorialImage,
            Properties.Resources.DifficultiesImage,
            Properties.Resources.PrizesImage
        };

        private static string
        StringHolder = "";

        private double MainRatio()
        {
            double ratio = this.Height / 720;
            return MainRatio();
        }

        private double MiddleLocation()
        {
            double middle = this.Width / 2;
            return MiddleLocation();
        }

        #endregion

        public MainMenuForm() // the main menu public class :3
        {
            InitializeComponent(); // the main menu panel interface goes here :3

            this.StartPosition = FormStartPosition.CenterScreen;
            this.Opacity = 0;
            LogoKeypoint = GuessTheNumberLogo.Location.Y;
        }

        private void MainMenuProcess() // the whole form process goes here :3
        {
            switch(MainMenuSwitch)
            {
                case 1: // the main menu stuff.
                    MainMenuInterface();
                    break;
                case 2: // the difficulty section
                    DifficultyMenuInterface();
                    break;
                case 3: // the starting process
                    GuessingGameInterface();
                    break;
            }
        }

        private void MainMenuInterface()
        {
            GuessTheNumberLogo.Location = new Point(280, -35);
            PressAnyButtonLabel.Location = new Point(373, 507);
        }

        private void DifficultyMenuInterface()
        {
            IsDifficultySection = true;

            GuessTheNumberLogo.Location = new Point(280, -1035);
            PressAnyButtonLabel.Location = new Point(373, -507);

            DifficultyTypeLabel.Location = new Point(110, 87);
            DifficultyTextLabel.Location = new Point(113, 150);
            DifficultyPageLabel.Location = new Point(148, 496);

            EasyLabel.Location = new Point(942, 209);
            NormalLabel.Location = new Point(912, 320);
            HardLabel.Location = new Point(942, 428);

            LeftLabel.Location = new Point(117, 496);
            RightLabel.Location = new Point(276, 496);


        }

        private void GuessingGameInterface()
        {
            IsGuessingProcess = true;

            GuidingLabel.Location = new Point(GuidingLabel.Location.X, 559);
            CountdownLabel.Location = new Point(CountdownLabel.Location.X, 346);
            NumberHolderLabel.Location = new Point(NumberHolderLabel.Location.X, 452);
            this.BackgroundImage = Properties.Resources.MainMenuBackground;
            CountingDownLabel.Hide();
            CountdownTimer.Start(); // countdown timer of the guessing game (will be moved in fuutre sessions)
            CountingDownTimer.Stop();
        }

        #region Main Menu stuff goes here :3
        private void MainMenuLoad(object sender, EventArgs e) // main form loading..
        {
            this.BackgroundImage = Properties.Resources.MainMenuBackground; // initialize the background beforehand

            typeof(Panel).InvokeMember("DoubleBuffered",
            BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic,
            null, this.MainMenuPanel, new object[] { true });

            MainMenuInterface();

            TimeToday.Start(); // starting the time and date process :3
            OpeningTime.Start(); // fading in within the form itself
            OpeningTransition.Start(); // opening transitions
        }

        #region window form location moving and stuff goes here :3
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

        private void WindowLabelClick(object sender, EventArgs e)
        {
            WindowChecking();
        }

        private void LeftLabelClick(object sender, EventArgs e)
        {
            DifficultyDownPage();
            DifficultyPageLabelVoid();
        }

        private void RightLabelClick(object sender, EventArgs e)
        {
            DifficultyUpPage();
            DifficultyPageLabelVoid();
        }
        private void DifficultyDownPage()
        {
            DifficultyPage = Math.Max(DifficultyPage - 1, 0);
            DifficultySectionPicture.Image = DifficultyImages[DifficultyPage];
        }

        private void DifficultyUpPage()
        {
            DifficultyPage = Math.Min(DifficultyPage + 1, DifficultyText.Length);
            DifficultySectionPicture.Image = DifficultyImages[DifficultyPage];
            
        }

        private void DifficultyPageLabelVoid()
        {
            DifficultyPageLabel.Text = (DifficultyPage + 1) + " of 3";
        }

        #region difficulties modifications goes here :3
        private void HardLabelClick(object sender, EventArgs e)
        {
            GuessingLimit = 1000;
            RandomNumber = rand.Next(0, GuessingLimit);
            Attempts = 8;
            minutesLeft = 2;
            secondsLeft = 0;
            GuessingGameStart();
        }

        private void NormalLabelClick(object sender, EventArgs e)
        {
            GuessingLimit = 500;
            RandomNumber = rand.Next(0, GuessingLimit);
            Attempts = 6;
            minutesLeft = 1;
            secondsLeft = 30;
            GuessingGameStart();
        }

        private void EasyLabelClick(object sender, EventArgs e)
        {
            GuessingLimit = 250;
            RandomNumber = rand.Next(0, GuessingLimit);
            Attempts = 4;
            minutesLeft = 1;
            secondsLeft = 0;
            GuessingGameStart();
        }

        private void GuessingGameStart()
        {
            CountingDownTimer.Start();
            CountingDownLabel.Show();
        }

        #endregion

        private void CountingDownTick(object sender, EventArgs e)
        {
            CountingDownTimer.Interval = 1000;
            this.BackgroundImage = Properties.Resources.DarkBackground;
            DifficultyPageLabel.Hide();
            DifficultyTextLabel.Hide();
            DifficultyTypeLabel.Hide();
            LeftLabel.Hide();
            RightLabel.Hide();
            EasyLabel.Hide();
            NormalLabel.Hide();
            HardLabel.Hide();

            if(CountingDownStart > -1)
            {
                if (CountingDownStart == 0)
                {
                    CountingDownLabel.Text = "Start Guessing!";
                }
                else
                {
                    CountingDownLabel.Text = CountingDownStart.ToString();
                }
                CountingDownStart--;
            }
            else
            {
                GuessingGameInterface();
            }
            MiddleChecking();
        }

        private void TimeTicking(object sender, EventArgs e)
        {
            TimeToday.Interval = 1000;
            TimeLabel.Text = DateTime.Now.ToString("dddd, M/d/yyyy | HH:mm:ss");
        }
        #endregion

        private void GitHubPictureClick(object sender, EventArgs e)
        {
            Process.Start("https://github.com/iid3rp/PythonPioneers-GuessTheNumber");
        }

        private void MainMenuClick(object sender, EventArgs e)
        {
            StringHolder = "";
            NumberHolderLabel.Text = "Guess Something :3";
            MiddleChecking();
        }

        private void ClosingTick(object sender, EventArgs e)
        {
            this.Opacity -= .04;
            if (this.Opacity == 0)
            {
                ClosingTime.Stop();
                Application.Exit();
            }
        }

        private void OpeningTick(object sender, EventArgs e)
        {
            this.Opacity += 0.1;
            if (this.Opacity == 1)
            {
                OpeningTime.Stop();
            }
        }

        private void OpeningTransitionTick(object sender, EventArgs e)
        {
            /*
            if (GuessTheNumberLogo.Location.Y < -35)
            {
                LogoKeypoint += 5;
                GuessTheNumberLogo.Location = new Point(GuessTheNumberLogo.Location.X, LogoKeypoint);
            }
            else
            {
                OpeningTransition.Stop();
            }
            */

            // were not gonna use this anymore :P it will be  deprecated
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

        #region The other stuff goes here :3

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
            }
            MiddleChecking();
        }

        private void MainMenuPress(object sender, KeyPressEventArgs e)
        {
            if (IsGuessingProcess)
            {
                if (StringHolder.Length > 16)
                {
                    e.Handled = true;
                }
                else if (char.IsLetterOrDigit(e.KeyChar))
                {
                    StringHolder += e.KeyChar.ToString();
                    StringHolder = StringHolder.Trim();
                    NumberHolderLabel.Text = StringHolder;

                    if (!int.TryParse(StringHolder, out CurrentNumber))
                    {
                        GuidingLabel.Text = "Input should not\ncontain characters.";
                        IsANumber = false;
                    }
                    else
                    {
                        GuidingLabel.Text = "Number must be 0 - " + GuessingLimit;
                        IsANumber = true;
                    }
                }
                else
                {
                    e.Handled = true;
                }
            }
            else
            {

            }
            MiddleChecking();
        }

        private void MainMenuDown(object sender, KeyEventArgs e)
        {
            if(IsDifficultySection)
            {
                if (e.KeyCode == Keys.Left)
                {
                    DifficultyDownPage();
                }
                else if (e.KeyCode == Keys.Right)
                {
                    DifficultyUpPage();
                }
                DifficultyPageLabelVoid();
            }
            if (IsGuessingProcess)
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (NumberHolderLabel.Text == "getnumericalvalue") // cheat code for number reference. this should not be abused.
                    {
                        GuidingLabel.Text = "Random Number: " + RandomNumber.ToString();
                    }
                    else if (IsANumber)
                    {
                        if (!(string.IsNullOrEmpty(NumberHolderLabel.Text)))
                        {
                            NumberHolderLabel.Text = "guess something :3";
                            CurrentNumber = int.Parse(StringHolder);
                        }

                        if (CurrentNumber > GuessingLimit)
                        {
                            GuidingLabel.Text = "Number Should not be greater\nthan the guessing limit.";
                        }
                        else
                        {
                            if (CurrentNumber > RandomNumber)
                            {
                                GuidingLabel.Text = "Hint: Current number is greater\nthan the random number.\n" +
                                                    "Current Number: " + CurrentNumber;
                                Attempts--;
                                CountdownLabel.Text = $"{minutesLeft}:{secondsLeft:D2}\n" +
                                          "Attempts: " + Attempts;
                            }
                            else if (CurrentNumber < RandomNumber)
                            {
                                GuidingLabel.Text = GuidingLabel.Text = "Hint: Current number is less\nthan the random number.\n" +
                                                    "Current Number: " + CurrentNumber;
                                Attempts--;
                                CountdownLabel.Text = $"{minutesLeft}:{secondsLeft:D2}\n" +
                                          "Attempts: " + Attempts;
                            }
                            else
                            {
                                GuidingLabel.Text = "You won! Yippie :3";
                                CountdownLabel.Text = null;
                                CountdownTimer.Stop();
                            }

                            if (Attempts == 0)
                            {
                                CountdownLabel.Text = "";
                                GuidingLabel.Text = "You ran out of attempts :<\n" +
                                                    "Correct Number = " + RandomNumber + "\n" +
                                                    "Game Over.";
                                IsANumber = false;
                                CountdownTimer.Stop();
                            }
                        }
                    }
                    StringHolder = "";
                    NumberHolderLabel.Text = StringHolder;
                }
                else if (e.KeyCode == Keys.Back && !string.IsNullOrEmpty(StringHolder))
                {
                    StringHolder = StringHolder.Remove(StringHolder.Length - 1);
                    NumberHolderLabel.Text = StringHolder;
                }
            }
            else
            {
                MainMenuSwitch = 2;
                MainMenuProcess();
            }
            MiddleChecking();
        }
        private void MiddleChecking()
        {
            NumberHolderLabel.Location = new Point((this.Width / 2) - (NumberHolderLabel.Width / 2), NumberHolderLabel.Location.Y);
            GuidingLabel.Location = new Point((this.Width / 2) - (GuidingLabel.Width / 2), GuidingLabel.Location.Y);
            CountdownLabel.Location = new Point((this.Width / 2) - (CountdownLabel.Width / 2), CountdownLabel.Location.Y);
            CountingDownLabel.Location = new Point((this.Width / 2) - (CountingDownLabel.Width / 2), CountingDownLabel.Location.Y);
        }

        private void ConsistentInterface()
        {
            if (this.WindowState == FormWindowState.Normal) // fullscreen interface :3
            {
                WindowLabel.Text = "[]]";
                GitHubPicture.Size = new Size(40, 40);
                GitHubPicture.Location = new Point(GitHubPicture.Location.X, (GitHubPicture.Location.Y - 20));
                GuessTheNumberLogo.Size = new Size((int)(GuessTheNumberLogo.Location.X * MainRatio()),
                                                   (int)(GuessTheNumberLogo.Location.Y * MainRatio()));
                this.WindowState = FormWindowState.Maximized;
            }
            else // normal window interface
            {
                WindowLabel.Text = "[]";

                // the normal size references..
                GuessTheNumberLogo.Size = new Size(720, 360);
                GitHubPicture.Size = new Size(20, 20);
                LeftLabel.Font = new Font("Comic Sans MS", 27.75F, FontStyle.Regular, GraphicsUnit.Point);
                LeftLabel.Location = new Point(117, 1496);
                RightLabel.Font = new Font("Comic Sans MS", 27.75F, FontStyle.Regular, GraphicsUnit.Point);
                RightLabel.Location = new Point(276, 1496);

                ///picturebox of the tutorial
                ///3 picturebox of the difficulties
                ///and other stuff

                GitHubPicture.Location = new Point(GitHubPicture.Location.X, (GitHubPicture.Location.Y + 20));

                this.WindowState = FormWindowState.Normal;
                this.Size = new Size(1280, 720);
            }
            GuessTheNumberLogo.Location = new Point(((this.Size.Width / 2) - GuessTheNumberLogo.Width / 2), -35);
        }

        #endregion
    }
}
