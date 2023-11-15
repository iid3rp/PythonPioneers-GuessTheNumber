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
        IsGuessed = false,  // the boolean if the user has guessed the random number 
        IsDragging = false, // the dragging boolean for the form moving in normal form size
        IsANumber = false, // boolean for if the input dosent have characters
        IsDifficultyImage = false, // just to make sure if the picture in the difficulty section is in the difficulty section.
        IsGuessingProcess = false; //boolean for if the guessing has started.

        private static int
        CountingDownStart = 3, // counting down when the guessing starts.
        // difficulty stuff (winners list)
        easy = 0,
        normal = 0,
        hard = 0,
        // guessing number variables
        CurrentNumber = 0, // current number holder
        GuessingLimit = 1000, // guessing limit numebr to use the limit in the number guess
        minutesLeft = 0, // minutes left of the timer
        secondsLeft = 0, // seconds left of the timer
        Attempts = 0, // amount of attempts of the game
        RandomNumber = 0; // the random number which the player will guess

        private readonly Random rand = new Random();

        private Point
        NewLocation, // New location of the form when the form moves each time
        Offset; // the offset location that will track each time the cursor moves

        private static string
        StringHolder = "",
        DifficultyName = null,
        programFolderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86), "PythonPioneers-GuessTheNumber"),
        WinnersFilePath = Path.Combine(programFolderPath, "Winners.txt"),
        DistributionFilePath = Path.Combine(programFolderPath, "Distribution.txt");

        private readonly string[] TipsText =
        {
            "Start with a Lucky Number. Today's might be your day!",
            "Try to follow with a fibonacci sequence.",
            "Close your eyes and guess whatever.",
            "Dive into the world of primes and see if the answer lies within.",
            "Eliminate possibilities through step by step.",
            "Is it your month? put that month and day into a guess!",
            "Try a number in the middle.",
            "Try to guess in thirds as well.",
            "Maybe ask yourself why do you have to guess the number.",
            "Maybe press three random numbers in the keyboard.",
            "See if the reversed number holds the secret.",
            "Try a palindrome number.",
            "Either you guess or not, at least you had fun!",
            "Ask for a therapist for a random number.",
            "Maybe the nature will tell you whats the number.",
            "Take a quantum leap of faith.",
            "Ask a Professor for a random number",
            "Think random for today!",
            "Try to be more practical. Guess or forfeit.",
            "Try to guess within the Golden Ratio.",
            "Apply Sudoku strategies to your guessing game.",
            "Let's guess for something!",
            "Guess, Guess, Guess! (pun intended)",
            "Mathematical Magic: Sprinkle some math spells.",
            "Maybe ask chatGPT for a random number.",
            "Maybe ask yourself where did the number go.",
            "What's the number? Who knows, honestly. :3",
            "Maybe ask google for a random number.",
            "Ask for a friend.",
            "...............",
            "Pick a number with a pirate's swagger.",
            "Have a luck for quite some time!",
            "Debate the number with your friends.",
            "Please play this game!!!!",
            "Hello World!",
            "Let's go Cluster 2!!",
            "Also please also play for other booths :3",
            "Try to do lucky numbers like 444 or something lol.",
            "Look to the python leaves for guidance",
            "Apply your favorite geeky algorithm for the perfect guess.",
            "Channel your inner artist and paint the number in your mind.",
            "Try to focus for a number that you dont know.",
            "Unhappy go lucky!",
            "Saan aabot ang \u20B1" + "10 mo?",
            "Maybe guess the number with your birthday.",
            "Try to guess with how many times you have seen people today."
        };

        private static int randomNumberText(int limit)
        {
            limit = new Random().Next(0, GuessingLimit);
            return limit;
        }

        private StreamWriter DistributionIni;

        #endregion

        public MainMenuForm() // the main menu public class :3
        {
            InitializeComponent(); // the main menu panel interface goes here :3
            InitializeFiles(); // the program files of this program to determine the winners and stuff

            this.StartPosition = FormStartPosition.CenterScreen;
            this.Opacity = 0;
        }

        private void InitializeFiles()
        {
            for (; ; )
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
                        WinnersIni.Close();
                    }

                    if (!File.Exists(DistributionFilePath))
                    {
                        DistributionIni = new StreamWriter(DistributionFilePath);
                        using (DistributionIni)
                        {
                            DistributionIni.WriteLine("Python Pioneers | Guess The Game\n" +
                                                      "Random distribution count:\n\n" +
                                                      "    Date & Time     |  Difficulty  |  Random Number  |    Guessed\n");
                        }
                    }

                    WinnersFileRead();
                    break;
                }
            }
        }
        private void WinnersFileRead() // read the winners text file
        {
            using (StreamReader WinnersRead = new StreamReader(WinnersFilePath))
            {
                // Read the header line ("winners:")
                WinnersRead.ReadLine();

                // Read and parse the easy, normal, and hard lines
                easy = ParseWinnersLine(WinnersRead.ReadLine());
                normal = ParseWinnersLine(WinnersRead.ReadLine());
                hard = ParseWinnersLine(WinnersRead.ReadLine());

                // Display the results

                WinnersLabel.Text = "Winners: \n" +
                                    "Easy: " + easy + "\n" +
                                    "Normal: " + normal + "\n" +
                                    "Hard: " + hard + "\n";
            }
        }

        private int ParseWinnersLine(string line)
        {
            // Split the line into parts using ':' as the separator
            string[] parts = line.Split(':');

            // Assuming the number is the second part after splitting
            if (parts.Length > 1)
            {
                int value;
                // Try to parse the number, if successful, return it; otherwise, return 0
                return int.TryParse(parts[1].Trim(), out value) ? value : 0;
            }
            return 0; // Default value if parsing fails
        }

        private void DistributionVoid()
        {
            string PastText = null;
            using (StreamReader DistributionFileRead = new StreamReader(DistributionFilePath))
            {
                PastText = DistributionFileRead.ReadToEnd();
            }

            using (DistributionIni = new StreamWriter(DistributionFilePath))
            {
                DistributionIni.Write(PastText);
                DistributionIni.WriteLine(DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss") +
                                          "\t  " + DifficultyName + "\t\t  " +
                                          RandomNumber + "\t\t " + IsGuessed);
            }
        }

        private void MainMenuInterface()
        {
            this.BackgroundImage = Properties.Resources.MainMenuBackground;
            IsGuessingProcess = false;

            // main menu
            WinnersLabel.Show();
            GuessTheNumberLogo.Location = new Point(264, 35);
            PressAnyButtonLabel.Location = new Point(373, 577);

            // difficulty stuff
            NumberPage.Hide();
            DifficultySectionPicture.Location = new Point(78, 1077);
            EasyPicture.Location = new Point(830, 1145);
            NormalPicture.Location = new Point(830, 1288);
            HardPicture.Location = new Point(830, 1430);
            GoHome.Location = new Point(12, 1619);

            //guessing game stuff
            GuessingPanel.Hide();

            // game over stuff
            CountdownLabel.Text = "0:00";
            CountingDownLabel.Hide();
            GameOverPicture.Location = new Point((MainMenuPanel.Width / 2) - 
                                                 (GameOverPicture.Width/2), 1109);
            GoHome.Size = new Size(294, 1100);
            GoHome.Location = new Point((MainMenuPanel.Width / 2) -
                                        (GoHome.Width / 2), 1549);
            GameOverLabel.Location = new Point(446, 1340);

        }

        private void DifficultyMenuInterface()
        {
            // main menu
            WinnersLabel.Hide();
            GuessTheNumberLogo.Location = new Point(280, -1035);
            PressAnyButtonLabel.Location = new Point(373, -507);

            // difficulty stuff
            NumberPage.Show();
            DifficultySectionPicture.Location = new Point(78, 77);
            EasyPicture.Location = new Point(830, 145);
            NormalPicture.Location = new Point(830, 288);
            HardPicture.Location = new Point(830, 430);
            GoHome.Size = new Size(147, 50);
            GoHome.Location = new Point(12, 619);
        }

        private void GuessingGameInterface()
        {
            IsGuessingProcess = true;
            this.BackgroundImage = Properties.Resources.MainMenuBackground;

            // guessing game stuff
            StringHolder = "";
            NumberHolderLabel.Text = "-------";
            GuidingLabel.Text = "Enter number from 0 - " + GuessingLimit;
            GuessingPanel.Show(); // the panel shows
            CountdownTimer.Start(); // countdown timer of the guessing game
            CountingDownTimer.Stop();

            // countdown label
            CountingDownLabel.Location = new Point(624, 1290);
        }

        private void GameOver()
        {
            GuessingPanel.Hide();

            DistributionVoid();
            this.BackgroundImage = Properties.Resources.DarkBackground;
            CountingDownLabel.Hide();
            GameOverPicture.Location = new Point((MainMenuPanel.Width / 2) -
                                                 (GameOverPicture.Width / 2), 109);
            GoHome.Size = new Size(294, 100);
            GoHome.Location = new Point((MainMenuPanel.Width / 2) -
                                        (GoHome.Width / 2), 529);
            GameOverLabel.Location = new Point((this.Width / 2) -
                                               (GameOverLabel.Width / 2), 340);
        }

        #region Main Menu stuff goes here :3
        private void MainMenuLoad(object sender, EventArgs e) // main form loading..
        {
            this.BackgroundImage = Properties.Resources.MainMenuBackground; // initialize the background beforehand

            GuessingPanel.Location = new Point(382, 72);

            typeof(Panel).InvokeMember("DoubleBuffered",
            BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic,
            null, this.MainMenuPanel, new object[] { true });

            MainMenuInterface();

            TimeToday.Start(); // starting the time and date process :3
            OpeningTime.Start(); // fading in within the form itself
            OpeningTransition.Start(); // opening transitions
            TipAppearance.Start(); // strting of the ticking process
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
            DialogResult result = MessageBox.Show("Do you wish to exit?", 
            "Exit Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

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
            IsGuessingProcess = true;
            // difficulty stuff
            DifficultySectionPicture.Location = new Point(78, 1077);
            EasyPicture.Location = new Point(830, 1145);
            NormalPicture.Location = new Point(830, 1288);
            HardPicture.Location = new Point(830, 1430);
            GoHome.Location = new Point(12, 1619);
            CountingDownLabel.Location = new Point(624, 290);

            this.BackgroundImage = Properties.Resources.DarkBackground;
            CountingDownStart = 3;
            CountingDownLabel.Text = CountingDownStart.ToString();
            CountingDownTimer.Interval = 1;
            CountingDownLabel.Show();
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
            DifficultyName = "Easy";
            GuessingGameStart();
        }

        private void TipTick(object sender, EventArgs e)
        {
            TipAppearance.Interval = 3000;
            TipLabel.Text = TipsText[rand.Next(0, TipsText.Length - 1)];
            TipLabel.Location = new Point((MainMenuPanel.Width / 2) -
                                          (TipLabel.Width / 2), 646);
        }

        private void NormalPicture_Click(object sender, EventArgs e)
        {
            GuessingLimit = 500;
            RandomNumber = rand.Next(0, GuessingLimit);
            Attempts = 6;
            minutesLeft = 1;
            secondsLeft = 30;
            DifficultyName = "Hard";
            GuessingGameStart();
        }

        private void HardPicture_Click(object sender, EventArgs e)
        {
            GuessingLimit = 1000;
            RandomNumber = rand.Next(0, GuessingLimit);
            Attempts = 8;
            minutesLeft = 2;
            secondsLeft = 0;
            DifficultyName = "Hard";
            GuessingGameStart();
        }

        private void GoHome_Click(object sender, EventArgs e)
        {
            MainMenuInterface();
        }

        private void TutorialPictureClick(object sender, EventArgs e)
        {
            PictureScene();
        }

        private void PictureScene()
        {
            if (IsDifficultyImage)
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
            NumberPage.Hide();
            this.BackgroundImage = Properties.Resources.DarkBackground;
            if(CountingDownStart > -1)
            {
                if (CountingDownStart == 0)
                {
                    CountingDownLabel.Text = "Start Guessing!";
                    AttemptLabel.Text = "Attempts: " + Attempts;
                }
                else
                {
                    CountingDownLabel.Text = CountingDownStart.ToString();
                }
                CountingDownStart--;
            }
            else
            {
                CountingDownLabel.Location = new Point(624, 1290);
                GuessingGameInterface();
            }
            MiddleChecking();
        }

        private void GuessAgainClick(object sender, EventArgs e)
        {
            GuessingGameStart();
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
        #endregion

        #region The other stuff goes here :3

        private void CountdownTick(object sender, EventArgs e)
        {
            if (minutesLeft == 0 && secondsLeft == 0)
            {
                GameOver();
                CountdownLabel.Text = "0:00";
                GameOverLabel.Text = "You're out of time :<\n" +
                                     "Correct number: " + RandomNumber;
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

                CountdownLabel.Text = $"{minutesLeft}:{secondsLeft:D2}\n";
            }
            MiddleChecking();
        }

        private void MainMenuPress(object sender, KeyPressEventArgs e)
        {
            if (IsGuessingProcess)
            {
                if (StringHolder.Length > 6)
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
                    if (NumberHolderLabel.Text == "getnum") // cheat code for number reference. this should not be abused.
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
                                CountdownLabel.Text = $"{minutesLeft}:{secondsLeft:D2}\n";
                                AttemptLabel.Text = "Attempts: " + Attempts;
                            }
                            else if (CurrentNumber < RandomNumber)
                            {
                                GuidingLabel.Text = GuidingLabel.Text = "Hint: Current number is less\nthan the random number.\n" +
                                                    "Current Number: " + CurrentNumber;
                                Attempts--;
                                CountdownLabel.Text = $"{minutesLeft}:{secondsLeft:D2}\n";
                                AttemptLabel.Text = "Attempts: " + Attempts;
                            }
                            else if(CurrentNumber == RandomNumber)
                            {
                                GameOverLabel.Text = "You won! Yippie :3";
                                IsGuessed = true;
                                Yippie();
                                CountdownLabel.Text = null;
                                GameOver();
                                CountdownTimer.Stop();           
                            }

                            if (Attempts == 0)
                            {
                                if (Math.Abs(CurrentNumber - RandomNumber) <= 3)
                                {
                                    GameOverLabel.Text = "You are so close!!!\n" +
                                                        "Current Number: " + CurrentNumber + "\n" +
                                                        "Correct Number: " + RandomNumber;
                                }
                                else
                                {
                                    CountdownLabel.Text = "";
                                    GameOverLabel.Text = "You ran out of attempts :<\n" +
                                                         "Current Number: " + CurrentNumber + "\n" +
                                                         "Correct Number: " + RandomNumber;
                                }
                                IsGuessed = false;
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
                MiddleChecking();
            }
            else
            {
                DifficultyMenuInterface();

                if(e.KeyCode == Keys.Left || e.KeyCode == Keys.Right)
                {
                    PictureScene();
                }
            }
            
        }
        private void MiddleChecking()
        {
            Point centerPoint = new Point(GuessingPanel.Width / 2, 0);
            Point screenCenterPoint = GuessingPanel.PointToScreen(centerPoint);

            CountingDownLabel.Location = new Point((MainMenuPanel.Width / 2) - (CountingDownLabel.Width / 2), 290);
            CountdownLabel.Location = new Point(centerPoint.X - (CountdownLabel.Width / 2), 55);
            NumberHolderLabel.Location = new Point(centerPoint.X - (NumberHolderLabel.Width / 2), 244);
            GuidingLabel.Location = new Point(centerPoint.X - (GuidingLabel.Width / 2), 360);
        }

        private void ConsistentInterface() // deprecated value
        {
            if (this.WindowState == FormWindowState.Normal) // fullscreen interface :3
            {
                this.WindowState = FormWindowState.Maximized;

                

            }
            else // normal window interface
            {
                this.WindowState = FormWindowState.Normal;
                this.Size = new Size(1280, 720);    
            }

            // main menu

            // difficulty stuff
            DifficultySectionPicture.Location = new Point(78, 1077);
            EasyPicture.Location = new Point(830, 1145);
            NormalPicture.Location = new Point(830, 1288);
            HardPicture.Location = new Point(830, 1430);
            GoHome.Location = new Point(12, 1619);

            //guessing game stuff
            GuessingPanel.Hide();

            // game over stuff
            CountdownLabel.Text = "0:00";
            CountingDownLabel.Hide();
            GameOverPicture.Location = new Point(343, 1109);
            GoHome.Size = new Size(294, 1100);
            GoHome.Location = new Point((MainMenuPanel.Width / 2) -
                                        (GoHome.Width / 2), 1549);
            GameOverLabel.Location = new Point(446, 1360);
        }

        private void Yippie() // this is so autism :sob:
        {
            switch(GuessingLimit)
            {
                case 250:
                    DifficultyName = "Easy";
                    easy++;
                    break;
                case 500:
                    DifficultyName = "Normal";
                    normal++;
                    break;
                case 1000:
                    DifficultyName = "Hard";
                    hard++;
                    break;
            }

            using (StreamWriter WinnersWrite = new StreamWriter(WinnersFilePath))
            {
                WinnersWrite.WriteLine("Winners:\n" +
                                        "Easy: " + easy + "\n" +
                                        "Normal: " + normal + "\n" +
                                        "Hard: " + hard + "\n");
            }
                WinnersFileRead();
        }
        #endregion
    }
}
