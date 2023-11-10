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
using System.IO;
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
        IsDifficultyImage = false, // just to make sure if the picture in the difficulty section is in the difficulty section.
        IsGuessingProcess = false; //boolean for if the guessing has started.

        private int
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
            InitializeFiles(); // the program files of this program to determine the winners and stuff
            InitializeComponent(); // the main menu panel interface goes here :3

            this.StartPosition = FormStartPosition.CenterScreen;
            this.Opacity = 0;
        }

        private void InitializeFiles()
        {
            string programFolderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86), "PythonPioneers-GuessTheNumber");
            string WinnersFilePath = Path.Combine(programFolderPath, "Winners.txt");
            string DistributionFilePath = Path.Combine(programFolderPath, "Distribution.txt");
            for(;;)
            {
                // checking the files
                if (!Directory.Exists(programFolderPath))
                {
                    Directory.CreateDirectory(programFolderPath);
                }
                else
                {
                    if (!File.Exists(WinnersFilePath))
                    {
                        StreamWriter WinnersIni = new StreamWriter(WinnersFilePath);
                        using (WinnersIni)
                        {
                            WinnersIni.WriteLine("Python Pioneers | Guess The Game Winners Count:\n" +
                                                 "Easy: " + 0 + "\n" +
                                                 "Normal: " + 0 + "\n" +
                                                 "Hard: " + 0 + "\n");
                        }                        
                    }
                    else if(!File.Exists(DistributionFilePath))
                    {
                        StreamWriter DistributionIni = new StreamWriter(DistributionFilePath);
                        using (DistributionIni)
                        {
                            DistributionIni.WriteLine("Python Pioneers | Guess The Game\n" +
                                                      "Random distribution count:");
                        }
                    }

                    // using the files:

                    break;
                }
            }
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
                case 4:
                    GameOver();
                    break;
            }
        }

        private void MainMenuInterface()
        {
            // main menu
            GuessTheNumberLogo.Location = new Point(280, -35);
            PressAnyButtonLabel.Location = new Point(373, 507);

            // difficulty stuff
            DifficultySectionPicture.Location = new Point(78, 1077);
            EasyPicture.Location = new Point(830, 1145);
            NormalPicture.Location = new Point(830, 1288);
            HardPicture.Location = new Point(830, 1430);
            GoHome.Location = new Point(12, 1619);

            // game over stuff
        }

        private void DifficultyMenuInterface()
        {
            // main menu
            GuessTheNumberLogo.Location = new Point(280, -1035);
            PressAnyButtonLabel.Location = new Point(373, -507);

            // difficulty stuff
            DifficultySectionPicture.Location = new Point(78, 77);
            EasyPicture.Location = new Point(830, 145);
            NormalPicture.Location = new Point(830, 288);
            HardPicture.Location = new Point(830, 430);
            GoHome.Location = new Point(12, 619);

        }

        private void GuessingGameInterface()
        {
            IsGuessingProcess = true;
            this.BackgroundImage = Properties.Resources.GuessingBackground;

            // guessing game stuff
            GuidingLabel.Location = new Point(GuidingLabel.Location.X, 559);
            CountdownLabel.Location = new Point(CountdownLabel.Location.X, 346);
            NumberHolderLabel.Location = new Point(NumberHolderLabel.Location.X, 452);
            CountingDownLabel.Location = new Point(624, 1290);
            CountdownTimer.Start(); // countdown timer of the guessing game
            CountingDownTimer.Stop();

            // countdown label
            CountingDownLabel.Location = new Point(624, 1290);
        }

        private void GameOver()
        {
            // gohome 207, 549
            // guess again 711, 549
            // gameover 343, 109

            this.BackgroundImage = Properties.Resources.DarkBackground;
            GoHome.Location = new Point(207, 549);
            GameOverPicture.Location = new Point(343, 109);
            GuessAgainPicture.Location = new Point(711, 549);
            GoHome.Location = new Point(207, 549);
            GoHome.Size = new Size(294, 100);
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
            ConsistentInterface();
        }

        #region difficulties modifications goes here :3

        private void GuessingGameStart()
        {
            // difficulty stuff
            DifficultySectionPicture.Location = new Point(78, 1077);
            EasyPicture.Location = new Point(830, 1145);
            NormalPicture.Location = new Point(830, 1288);
            HardPicture.Location = new Point(830, 1430);
            GoHome.Location = new Point(12, 1619);
            CountingDownLabel.Location = new Point(624, 290);

            this.BackgroundImage = Properties.Resources.DarkBackground;

            CountingDownTimer.Start();
        }

        #endregion


        private void EasyPicture_Click(object sender, EventArgs e)
        {
            GuessingLimit = 250;
            RandomNumber = rand.Next(0, GuessingLimit);
            Attempts = 4;
            minutesLeft = 1;
            secondsLeft = 0;
            GuessingGameStart();
        }

        private void NormalPicture_Click(object sender, EventArgs e)
        {
            GuessingLimit = 500;
            RandomNumber = rand.Next(0, GuessingLimit);
            Attempts = 6;
            minutesLeft = 1;
            secondsLeft = 30;
            GuessingGameStart();
        }

        private void HardPicture_Click(object sender, EventArgs e)
        {
            GuessingLimit = 1000;
            RandomNumber = rand.Next(0, GuessingLimit);
            Attempts = 8;
            minutesLeft = 2;
            secondsLeft = 0;
            GuessingGameStart();
        }

        private void GoHome_Click(object sender, EventArgs e)
        {
            MainMenuInterface();
        }

        private void TutorialPictureClick(object sender, EventArgs e)
        {
            if(IsDifficultyImage)
            {
                DifficultySectionPicture.Image = Properties.Resources.GameBasics;
                IsDifficultyImage = false;
            }
            else
            {
                IsDifficultyImage = true;
                DifficultySectionPicture.Image = Properties.Resources.DifficultyImage;
            }
        }

        private void CountingDownTick(object sender, EventArgs e)
        {
            CountingDownTimer.Interval = 1000;
            this.BackgroundImage = Properties.Resources.DarkBackground;
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
            NumberHolderLabel.Text = "-------";
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
                GameOver();
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
                            NumberHolderLabel.Text = "-------";
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
                                                    "Current Number: " + CurrentNumber.ToString();
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
                                GameOver();
                                CountdownLabel.Text = null;
                                CountdownTimer.Stop();
                            }

                            if (Attempts == 0)
                            {
                                if (RandomNumber + 3 <= CurrentNumber || RandomNumber - 3 >= CurrentNumber)
                                {
                                    GuidingLabel.Text = "You ran out of attempts :<\n" +
                                                        "Current Number = " + CurrentNumber + "\n" +
                                                        "Correct Number = " + RandomNumber + "\n" +
                                                        "Game Over.";
                                }
                                else 
                                { 
                                    CountdownLabel.Text = "";
                                    GuidingLabel.Text = "You ran out of attempts :<\n" +
                                                        "Correct Number = " + RandomNumber + "\n" +
                                                        "Game Over.";
                                }
                                IsANumber = false;
                                GameOver();
                                CountdownTimer.Stop();
                            }
                        }
                        IsANumber = false;
                    }
                    StringHolder = "";
                    NumberHolderLabel.Text = "-------";
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
            NumberHolderLabel.Location = new Point((this.Width / 2) - (NumberHolderLabel.Width / 2), 252);
            GuidingLabel.Location = new Point((this.Width / 2) - (GuidingLabel.Width / 2), 450);
            CountdownLabel.Location = new Point((this.Width / 2) - (CountdownLabel.Width / 2), 129);
            CountingDownLabel.Location = new Point((this.Width / 2) - (CountingDownLabel.Width / 2), 462);
        }

        private void ConsistentInterface()
        {
            int ratio = 0;
            if (this.WindowState == FormWindowState.Normal) // fullscreen interface :3
            {
                WindowLabel.Text = "[]]";
                ratio = this.Height / 720;
                this.WindowState = FormWindowState.Maximized;
            }
            else // normal window interface
            {
                ratio = 1;
                WindowLabel.Text = "[]";
                this.WindowState = FormWindowState.Normal;
                this.Size = new Size(1280, 720);
            }

            GuessTheNumberLogo.Location = new Point(((this.Size.Width / 2) - 
                                                      GuessTheNumberLogo.Width / 2),
                                                      GuessTheNumberLogo.Location.Y * ratio);
            GuessTheNumberLogo.Size = new Size((int)(GuessTheNumberLogo.Location.X * ratio),
                                               (int)(GuessTheNumberLogo.Location.Y * ratio));
            GuessTheNumberLogo.Size = new Size(720, 360);
        }

        #endregion
    }
}
