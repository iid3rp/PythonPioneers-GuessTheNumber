import javax.swing.*;
import javax.swing.JOptionPane.*;
import java.awt.Toolkit;
import java.awt.image.*;
import java.awt.datatransfer.*;
import java.awt.*;
import java.awt.event.*;
import java.awt.geom.Ellipse2D;
import java.io.*;
import java.util.*;

public class InitialFrame
{
    public static String[] args; // argument stated
    public static final String[] TipsText =
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

    public static JFrame initialFrame;
    public static JPanel initialPanel;
    private static ImageIcon backgroundImage;

    // this.components = new System.ComponentModel.Container();
//     System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainMenuForm));
//     this.TimeToday = new System.Windows.Forms.Timer(this.components);
//     this.MainMenuPanel = new System.Windows.Forms.Panel();
//     this.TipLabel = new System.Windows.Forms.Label();
//     this.WinnersLabel = new System.Windows.Forms.Label();
//     this.NumberPage = new System.Windows.Forms.Label();
//     this.GameOverLabel = new System.Windows.Forms.Label();
//     this.GuessingPanel = new System.Windows.Forms.Panel();
//     this.AttemptLabel = new System.Windows.Forms.Label();
//     this.NumberHolderLabel = new System.Windows.Forms.Label();
//     this.GuidingLabel = new System.Windows.Forms.Label();
//     this.CountdownLabel = new System.Windows.Forms.Label();
//     this.GameOverPicture = new System.Windows.Forms.PictureBox();
//     this.GoHome = new System.Windows.Forms.PictureBox();
//     this.HardPicture = new System.Windows.Forms.PictureBox();
//     this.NormalPicture = new System.Windows.Forms.PictureBox();
//     this.EasyPicture = new System.Windows.Forms.PictureBox();
//     this.DifficultySectionPicture = new System.Windows.Forms.PictureBox();
//     this.CountingDownLabel = new System.Windows.Forms.Label();
//     this.GuessTheNumberLogo = new System.Windows.Forms.PictureBox();
//     this.GitHubPicture = new System.Windows.Forms.PictureBox();
//     this.TimeLabel = new System.Windows.Forms.Label();
//     this.MinimizeLabel = new System.Windows.Forms.Label();
//     this.ClosingLabel = new System.Windows.Forms.Label();
//     this.PressAnyButtonLabel = new System.Windows.Forms.Label();
//     this.ClosingTime = new System.Windows.Forms.Timer(this.components);
//     this.OpeningTime = new System.Windows.Forms.Timer(this.components);
//     this.OpeningTransition = new System.Windows.Forms.Timer(this.components);
//     this.CountdownTimer = new System.Windows.Forms.Timer(this.components);
//     this.CountingDownTimer = new System.Windows.Forms.Timer(this.components);
//     this.TipAppearance = new System.Windows.Forms.Timer(this.components);
//     this.MainMenuPanel.SuspendLayout();
//     this.GuessingPanel.SuspendLayout();

    public static JLabel exitOnClose;
    public static JLabel minimizeLabel;
    public static JLabel mainMenuTitle;
    public static JLabel timeDateLabel;
    public static JLabel pressAnyButton;
    public static JLabel easyLabel;
    public static JLabel normalLabel;
    public static JLabel hardLabel;
    public static JLabel gitHubPicture;
    public static JLabel tipLabel;
    public static JLabel numberPage;
    public static JLabel difficultySection;
    public static JLabel countDownLabel;
    public static JLabel gameOverLabel;
    public static JLabel timerLabel;
    public static JLabel numberHolderLabel;
    public static JLabel attemptLabel;
    public static JLabel goHomeLabel;
    public static JLabel winnersLabel;
    
    public static Point offset;
    public static boolean isDragging = false;

    public static void initializeComponent() 
    {
        initialFrame = createInitialFrame();
        initialPanel = createInitialPanel();
        initialFrame.add(initialPanel);
        initialFrame.setContentPane(initialPanel);

        // the stuff in the window thingy
        exitOnClose = createExitLabel();
        minimizeLabel = createMinimizeLabel();
        mainMenuTitle = createTitle();
        timeDateLabel = createTimeDate();
        pressAnyButton = createPressAny();
        easyLabel = createEasyLabel();
        normalLabel = createNormalLabel();
        hardLabel = createHardLabel();
        gitHubPicture = createGitHub();
        tipLabel = createTipLabel();
        numberPage = createNumberPage();
        difficultySection = createDifficultySection();
        countDownLabel = createCountDown();
        gameOverLabel = createGameOver();
        timerLabel = createTimerLabel();
        numberHolderLabel = createNumberHolder();
        attemptLabel = createAttemptLabel();
        goHomeLabel = createGoHome();
        winnersLabel = createWinnersLabel();
        
        // adding the stuff in the panel:
        initialPanel.add(exitOnClose);
        initialPanel.add(minimizeLabel);
        initialPanel.add(mainMenuTitle);
        
        // making sure they're in so that the events will work
        initialFrame.setVisible(true);
        initialPanel.setVisible(true);
        JavaMainMenu.main(args);
    }
    
    public static JFrame createInitialFrame()
    {
        initialFrame = new JFrame();
        initialFrame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
        initialFrame.setSize(1280, 720);
        initialFrame.setForeground(new Color(0, 0, 0));
        initialFrame.setUndecorated(true);
        initialFrame.setLocationRelativeTo(null);
        
        initialFrame.addKeyListener(new KeyAdapter() 
        {
            @Override
            public void keyPressed(KeyEvent e) 
            {
                if (e.getKeyCode() == KeyEvent.VK_ESCAPE) 
                {
                    exitConfirmation();
                }
                System.out.println("clicked."); // debugging
            }
        });
        
        return initialFrame;
    }
    
    public static JPanel createInitialPanel()
    {
        initialPanel = new JPanel() 
        {
            static final long serialVersionUID = 1L;
            {
                backgroundImage = new ImageIcon("Resources/MainMenuBackground.png");
                Image scaledImage = backgroundImage.getImage().getScaledInstance(initialFrame.getWidth(), initialFrame.getHeight(), Image.SCALE_SMOOTH);
                backgroundImage = new ImageIcon(scaledImage);
            }
    
            @Override
            protected void paintComponent(Graphics g) 
            {
                super.paintComponent(g);
    
                // Draw the stretched image
                g.drawImage(backgroundImage.getImage(), 0, 0, getWidth(), getHeight(), null);
            }
        };
        initialPanel.setOpaque(false);
        initialPanel.setLayout(null);
        
        initialPanel.addMouseListener(new MouseAdapter() 
        {
            @Override
            public void mousePressed(MouseEvent e) 
            {
                if (SwingUtilities.isLeftMouseButton(e)) 
                {
                    isDragging = true;
                    offset = e.getPoint();
                }
            }

            @Override
            public void mouseReleased(MouseEvent e) 
            {
                if (SwingUtilities.isLeftMouseButton(e)) 
                {
                    isDragging = false;
                }
            }
        });
        
        initialPanel.addMouseMotionListener(new MouseMotionAdapter() 
        {   
            @Override
            public void mouseDragged(MouseEvent e)
            {
                if(isDragging)
                {
                    Point currentMouse = e.getLocationOnScreen();

                    int deltaX = currentMouse.x - offset.x;
                    int deltaY = currentMouse.y - offset.y;

                    initialFrame.setLocation(deltaX, deltaY);
                }
            }
        });
        return initialPanel;
    }

    public static JLabel createExitLabel()
    {
        exitOnClose = new JLabel("X");
        exitOnClose.setFont(new Font("Comic Sans MS", Font.PLAIN, 17));
        Dimension d = exitOnClose.getPreferredSize();
        exitOnClose.setBounds((int)(initialFrame.getWidth() - 10 - d.getWidth()), 5, 
                              (int)d.getWidth(), (int)d.getHeight());
        exitOnClose.setForeground(Color.WHITE);
        exitOnClose.setVisible(true);
        
        exitOnClose.addMouseListener(new MouseAdapter()
        {
            @Override
            public void mouseClicked(MouseEvent e)
            {
                exitConfirmation();
            }
        });
        return exitOnClose;
    }
    
    public static JLabel createMinimizeLabel()
    {
        minimizeLabel = new JLabel("_");
        minimizeLabel.setFont(new Font("Comic Sans MS", Font.PLAIN, 17));
        Dimension d = minimizeLabel.getPreferredSize();
        minimizeLabel.setBounds((int)(initialFrame.getWidth() - 10 - 20 - d.getWidth()), 3, 
                              (int)d.getWidth(), (int)d.getHeight());
        minimizeLabel.setForeground(Color.WHITE);
        minimizeLabel.setVisible(true);
        
        minimizeLabel.addMouseListener(new MouseAdapter()
        {
            @Override
            public void mouseClicked(MouseEvent e)
            {
                initialFrame.setState(Frame.ICONIFIED);
            }
        });
        return minimizeLabel;
        
    }
    
    public static JLabel createTitle()
    {
        mainMenuTitle = new JLabel() 
        {
            static ImageIcon titleImage = new ImageIcon("Resources/MainMenuBackground.png");
            Image title = titleImage.getImage();
            
            int newWidth = 753;
            int newHeight = 300;

            BufferedImage bufferedOriginal = new BufferedImage(
                    title.getWidth(null),
                    title.getHeight(null),
                    BufferedImage.TYPE_INT_ARGB
            );
            @Override
            protected void paintComponent(Graphics g) 
            {
                super.paintComponent(g);
                    
                Graphics2D g2d = bufferedOriginal.createGraphics();
                g2d.drawImage(title, 0, 0, null);
                g2d.dispose();
            }
        };
        mainMenuTitle.setVisible(true);
        Dimension d = mainMenuTitle.getPreferredSize();
        mainMenuTitle.setBounds((initialFrame.getWidth() / 2) - (int)(d.getWidth() / 2), 33, (int)d.getWidth(), (int)d.getHeight());
        mainMenuTitle.setVisible(true);
        return mainMenuTitle;
    }
    
    public static JLabel createTimeDate()
    {
        timeDateLabel = new JLabel("Time and Date goes here :3");
        timeDateLabel.setFont(new Font("Comic Sans MS", Font.PLAIN, 15));
        timeDateLabel.setForeground(Color.WHITE);
        Dimension d = timeDateLabel.getPreferredSize();
        timeDateLabel.setBounds(10, 10, (int)d.getWidth(), (int)d.getHeight());
        return timeDateLabel;
    }
    
    public static JLabel createPressAny()
    {
        pressAnyButton = new JLabel("- Press Anything To Continue -");
        pressAnyButton.setFont(new Font("Comic Sans MS", Font.PLAIN, 15));
        pressAnyButton.setForeground(Color.WHITE);
        Dimension d = pressAnyButton.getPreferredSize();
        pressAnyButton.setBounds(10, 10, (int)d.getWidth(), (int)d.getHeight());
        return pressAnyButton;
    }
    
    public static JLabel createEasyLabel()
    {
       easyLabel = new JLabel();
       easyLabel.setFont(new Font("Comic Sans MS", Font.PLAIN, 15));
       easyLabel.setForeground(Color.WHITE);
       Dimension d = easyLabel.getPreferredSize();
       easyLabel.setBounds(10, 10, (int)d.getWidth(), (int)d.getHeight());
       return easyLabel;
    }
    
    public static JLabel createNormalLabel()
    {
        normalLabel = new JLabel();
        normalLabel.setFont(new Font("Comic Sans MS", Font.PLAIN, 15));
        normalLabel.setForeground(Color.WHITE);
        Dimension d = normalLabel.getPreferredSize();
        normalLabel.setBounds(10, 10, (int)d.getWidth(), (int)d.getHeight());
        return normalLabel;
    }
    
    public static JLabel createHardLabel()
    {
        hardLabel = new JLabel();
        hardLabel.setFont(new Font("Comic Sans MS", Font.PLAIN, 15));
        hardLabel.setForeground(Color.WHITE);
        Dimension d = hardLabel.getPreferredSize();
        hardLabel.setBounds(10, 10, (int)d.getWidth(), (int)d.getHeight());
        return hardLabel;
    }
    
    public static JLabel createGitHub()
    {
        gitHubPicture = new JLabel();
        gitHubPicture.setFont(new Font("Comic Sans MS", Font.PLAIN, 15));
        gitHubPicture.setForeground(Color.WHITE);
        Dimension d = gitHubPicture.getPreferredSize();
        gitHubPicture.setBounds(10, 10, (int)d.getWidth(), (int)d.getHeight());
        return gitHubPicture;
    }
    
    public static JLabel createTipLabel()
    {
        tipLabel = new JLabel();
        tipLabel.setFont(new Font("Comic Sans MS", Font.PLAIN, 15));
        tipLabel.setForeground(Color.WHITE);
        Dimension d = tipLabel.getPreferredSize();
        tipLabel.setBounds(10, 10, (int)d.getWidth(), (int)d.getHeight());
        return tipLabel;
    }
    
    public static JLabel createNumberPage()
    {
        numberPage = new JLabel();
        numberPage.setFont(new Font("Comic Sans MS", Font.PLAIN, 15));
        numberPage.setForeground(Color.WHITE);
        Dimension d = numberPage.getPreferredSize();
        numberPage.setBounds(10, 10, (int)d.getWidth(), (int)d.getHeight());
        return numberPage;
    }
    
    public static JLabel createDifficultySection()
    {
        difficultySection = new JLabel();
        difficultySection.setFont(new Font("Comic Sans MS", Font.PLAIN, 15));
        difficultySection.setForeground(Color.WHITE);
        Dimension d = difficultySection.getPreferredSize();
        difficultySection.setBounds(10, 10, (int)d.getWidth(), (int)d.getHeight());
        return difficultySection;
    }
    
    public static JLabel createCountDown()
    {
        countDownLabel = new JLabel();
        countDownLabel.setFont(new Font("Comic Sans MS", Font.PLAIN, 15));
        countDownLabel.setForeground(Color.WHITE);
        Dimension d = countDownLabel.getPreferredSize();
        countDownLabel.setBounds(10, 10, (int)d.getWidth(), (int)d.getHeight());
        return countDownLabel;
    }
    
    public static JLabel createGameOver()
    {
        gameOverLabel = new JLabel();
        gameOverLabel.setFont(new Font("Comic Sans MS", Font.PLAIN, 15));
        gameOverLabel.setForeground(Color.WHITE);
        Dimension d = gameOverLabel.getPreferredSize();
        gameOverLabel.setBounds(10, 10, (int)d.getWidth(), (int)d.getHeight());
        return gameOverLabel;
    }
    
    public static JLabel createTimerLabel()
    {
        timerLabel = new JLabel();
        timerLabel.setFont(new Font("Comic Sans MS", Font.PLAIN, 15));
        timerLabel.setForeground(Color.WHITE);
        Dimension d = timerLabel.getPreferredSize();
        timerLabel.setBounds(10, 10, (int)d.getWidth(), (int)d.getHeight());
        return timerLabel;
    }
    
    public static JLabel createNumberHolder()
    {
        numberHolderLabel = new JLabel();
        numberHolderLabel.setFont(new Font("Comic Sans MS", Font.PLAIN, 15));
        numberHolderLabel.setForeground(Color.WHITE);
        Dimension d = numberHolderLabel.getPreferredSize();
        numberHolderLabel.setBounds(10, 10, (int)d.getWidth(), (int)d.getHeight());
        return numberHolderLabel;
    }
    
    public static JLabel createAttemptLabel()
    {
        attemptLabel = new JLabel();
        attemptLabel.setFont(new Font("Comic Sans MS", Font.PLAIN, 15));
        attemptLabel.setForeground(Color.WHITE);
        Dimension d = attemptLabel.getPreferredSize();
        attemptLabel.setBounds(10, 10, (int)d.getWidth(), (int)d.getHeight());
        return attemptLabel;
    }
    
    public static JLabel createGoHome()
    {
        goHomeLabel = new JLabel();
        goHomeLabel.setFont(new Font("Comic Sans MS", Font.PLAIN, 15));
        goHomeLabel.setForeground(Color.WHITE);
        Dimension d = goHomeLabel.getPreferredSize();
        goHomeLabel.setBounds(10, 10, (int)d.getWidth(), (int)d.getHeight());
        return goHomeLabel;
    }
    
    public static JLabel createWinnersLabel()
    {
        winnersLabel = new JLabel();
        winnersLabel.setFont(new Font("Comic Sans MS", Font.PLAIN, 15));
        winnersLabel.setForeground(Color.WHITE);
        Dimension d = winnersLabel.getPreferredSize();
        winnersLabel.setBounds(10, 10, (int)d.getWidth(), (int)d.getHeight());
        return winnersLabel;
    }
    
    public static void exitConfirmation()
    {
        int result = JOptionPane.showConfirmDialog(initialFrame,
                                                   "Do you wish to exit?",
                                                   "Exit Confirmation",
                                                   JOptionPane.YES_NO_OPTION,
                                                   JOptionPane.QUESTION_MESSAGE);
        if (result == JOptionPane.YES_OPTION)
        {
            // Perform cleanup or any other exit actions
            System.exit(0);
        }
    }

    public static void main(String[] args) 
    {
        // Your main method logic goes here
    }
}
