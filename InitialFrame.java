import javax.swing.*;
import javax.swing.JOptionPane.*;
import java.awt.Toolkit;
import java.awt.image.*;
import java.awt.datatransfer.*;
import java.awt.*;
import java.awt.event.*;
import java.awt.geom.Ellipse2D;
import java.io.*;
import java.text.SimpleDateFormat;
import java.util.*;
import java.net.*;
import java.nio.file.*;

public class InitialFrame
{
    public static String[] args; // argument stated
    public static final String[] tipsText =
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
    //
    // The Frame and the panels goes here
    //
    public static JFrame initialFrame;
    public static JPanel initialPanel;
    public static JPanel guessingPanel;
    public static ImageIcon backgroundImage;
    //
    // The JLabels goes here

//     this.CountingDownLabel = new System.Windows.Forms.Label();
//     this.TimeLabel = new System.Windows.Forms.Label();
//     this.CountdownTimer = new System.Windows.Forms.Timer(this.components);
//     this.CountingDownTimer = new System.Windows.Forms.Timer(this.components);
//     this.TipAppearance = new System.Windows.Forms.Timer(this.components);
//     this.MainMenuPanel.SuspendLayout();
//     this.GuessingPanel.SuspendLayout();
    //
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
    public static JLabel guidingLabel;
    //
    // Timers goes here
    //
    public static javax.swing.Timer timeDateTimer;
    public static javax.swing.Timer tipTimer;
    public static javax.swing.Timer openingWindow;
    public static javax.swing.Timer closingWindow;
    //
    // The window dragging values
    //
    public static Point offset;
    public static boolean isDragging = false;
    //
    // File manipulation values
    //
    public static String programFolderPath = Paths.get(System.getenv("ProgramFiles(x86)"), "PythonPioneers-GuessTheNumber").toString();
    public static String WinnersFilePath = programFolderPath + "/Winners.txt"; // Provide the actual path
    public static String DistributionFilePath = programFolderPath + "/Distribution.txt"; // Provide the actual path
    //
    // Other static values
    //
    public static String winnersString = "";
    public static float frameOpacity = 0.0f;
    public static float currentOpacity = 0.0f;
    public static boolean isMainMenu, isDifficultySection, isGuessing;
    public static Image scaledImage;
    //
    // File Manipulation process
    //
    public static void initializeFiles() 
    {
        for(;;)
        {
            File programFolder = new File(programFolderPath);
            if(!programFolder.exists()) 
            {
                programFolder.mkdirs();
            } 
            else 
            {
                File winnersFile = new File(WinnersFilePath);

                if(!winnersFile.exists()) 
                {
                    try(FileWriter winnersIni = new FileWriter(winnersFile)) 
                    {
                        winnersIni.write("Python Pioneers | Guess The Game Winners Count:\n" +
                                "Easy: 0\n" +
                                "Normal: 0\n" +
                                "Hard: 0\n");
                    } 
                    catch(IOException e) 
                    {
                        e.printStackTrace(); // Handle the exception appropriately
                    }
                }

                File distributionFile = new File(DistributionFilePath);

                if(!distributionFile.exists()) 
                {
                    try(FileWriter distributionIni = new FileWriter(distributionFile)) 
                    {
                        distributionIni.write("Python Pioneers | Guess The Game\n" +
                                "Random distribution count:\n\n" +
                                "    Date & Time     |  Difficulty  |  Random Number  |   Guessed\n");
                    } 
                    catch(IOException e) 
                    {
                        e.printStackTrace(); // Handle the exception appropriately
                    }
                }
                winnersFileRead();
                break;
            }
        }
    }
    
    public static void winnersFileRead() 
    {
        try(BufferedReader winnersRead = new BufferedReader(new FileReader(WinnersFilePath))) 
        {
            winnersRead.readLine();

            int easy = parseWinnersLine(winnersRead.readLine());
            int normal = parseWinnersLine(winnersRead.readLine());
            int hard = parseWinnersLine(winnersRead.readLine());

            winnersString = "<html>" +
                            "Winners:<br>" +
                            "Easy: " + easy + "<br>" +
                            "Normal: " + normal + "<br>" +
                            "Hard: " + hard + "<br>" +
                            "</html>"; // wow html in java LOL
        } 
        catch(IOException e) 
        {
            e.printStackTrace();
        }
    }

    public static int parseWinnersLine(String line) 
    {
        String[] parts = line.split(":");
        if(parts.length > 1) 
        {
            int value;
            // Try to parse the number, if successful, return it; otherwise, return 0
            try 
            {
                value = Integer.parseInt(parts[1].trim());
            } 
            catch(NumberFormatException e) 
            {
                value = 0; // Default value if parsing fails
            }
            return value;
        }
        return 0; // Default value if parsing fails
    }
    
    public static void initializeComponent() 
    {
        initializeFiles(); // THE MAIN CHARACTER :3
        //
        // Frame and panel initialization
        //
        initialFrame = createInitialFrame();
        initialPanel = createInitialPanel();
        guessingPanel = createGuessingPanel();
        initialFrame.add(initialPanel);
        initialFrame.setContentPane(initialPanel);
        //
        // the stuff in the window thingy
        //
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
        guidingLabel = createGuidingLabel();
        //
        ///
        //// #region ---------------------------------------------
        ///  adding the stuff in the panel:
        //
        initialPanel.add(guessingPanel);
        initialPanel.add(exitOnClose);
        initialPanel.add(minimizeLabel);
        initialPanel.add(mainMenuTitle);
        initialPanel.add(timeDateLabel);
        initialPanel.add(tipLabel);
        initialPanel.add(gitHubPicture);
        initialPanel.add(mainMenuTitle);
        initialPanel.add(winnersLabel);
        initialPanel.add(pressAnyButton);
        //
        // difficulty section addition
        //
        initialPanel.add(easyLabel);
        initialPanel.add(normalLabel);
        initialPanel.add(hardLabel);
        initialPanel.add(difficultySection);
        //
        // countdownlabel
        //
        initialPanel.add(countDownLabel);
        //
        ///
        //// #endregion ------------------------------------------
        ///
        //
        // Timers goes here
        timeDateTimer = createTimeDateTimer();
        tipTimer = createTipTimer();
        openingWindow = createOpening();
        closingWindow = createClosing();
        //
        // Timers starting in load:
        timeDateTimer.start();
        tipTimer.start();
        //
        // Frame and other visibility stuff
        //
        scalingImage("Resources/MainMenuBackground.png");
        initialFrame.setVisible(true);
        initialPanel.setVisible(true);
        gitHubPicture.setVisible(true);
        JavaMainMenu.main(args);
        initialFrame.setOpacity(0.0f);
        isMainMenu = true;
        createOpening().start();
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
                    if(!isMainMenu)
                    {
                        difficultySectionVisible(false);
                        mainMenuSectionVisible(true);
                        isMainMenu = true;
                    }
                    else
                    {
                        exitConfirmation();
                    }
                }
                else
                {
                    if(isMainMenu)
                    {
                        difficultySectionVisible(true);
                        mainMenuSectionVisible(false);
                        isMainMenu = false;
                    }
                }
                System.out.println("clicked."); // debugging
            }
        });
        ImageIcon icon = new ImageIcon("PythonPioneersGuessTheNumber.png");
        initialFrame.setIconImage(icon.getImage());
        return initialFrame;
    }
    
    public static JPanel createInitialPanel()
    {
        initialPanel = new JPanel() 
        {
            @Override
            protected void paintComponent(Graphics g) 
            {
                super.paintComponent(g);
                g.drawImage(new ImageIcon(scaledImage).getImage(), 0, 0, getWidth(), getHeight(), null);
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
    
    public static void difficultySectionVisible(boolean b)
    {
        easyLabel.setVisible(b);
        normalLabel.setVisible(b);
        hardLabel.setVisible(b);
        difficultySection.setVisible(b);
        if(b)
        {
            pressAnyButton.setText("- Click Panel or Left / Right keys |  Escape to exit -");
            Dimension d = pressAnyButton.getPreferredSize();
            pressAnyButton.setBounds((initialFrame.getWidth() / 2) - (int)(d.getWidth() / 2), 620, (int)d.getWidth(), (int)d.getHeight());
        }
    }
    
    public static void mainMenuSectionVisible(boolean b)
    {
        mainMenuTitle.setVisible(b);
        winnersLabel.setVisible(b);
        if(b)
        {
            pressAnyButton.setText("- Press Anything To Continue -");
            Dimension d = pressAnyButton.getPreferredSize();
            pressAnyButton.setBounds((initialFrame.getWidth() / 2) - (int)(d.getWidth() / 2), 620, (int)d.getWidth(), (int)d.getHeight());
        }
    }

    public static JPanel createGuessingPanel()
    {
        guessingPanel = new JPanel()
        {
            ImageIcon backgroundImage = new ImageIcon("Resources/GuessingPanel.png");
            Image scaledImage = backgroundImage.getImage().getScaledInstance(initialFrame.getWidth(), initialFrame.getHeight(), Image.SCALE_SMOOTH);
            ImageIcon bgImage = new ImageIcon(scaledImage);
            @Override
            protected void paintComponent(Graphics g) 
            {
                super.paintComponent(g);
                g.drawImage(bgImage.getImage(), 0, 0, getWidth(), getHeight(), null);
            }
        };
        guessingPanel.setOpaque(false);
        guessingPanel.setVisible(false);
        guessingPanel.setBounds((initialFrame.getWidth() / 2) - 250, (initialFrame.getHeight() / 2) - 250, 500, 500);
        return guessingPanel;
    }

    public static JLabel createExitLabel()
    {
        exitOnClose = new JLabel("X");
        exitOnClose.setFont(new Font("Comic Sans MS", Font.PLAIN, 17));
        Dimension d = exitOnClose.getPreferredSize();
        exitOnClose.setBounds((int)(initialFrame.getWidth() - 10 - d.getWidth()), 5, 
                              (int)d.getWidth(), (int)d.getHeight());
        exitOnClose.setForeground(new Color(152, 251, 152));
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
        minimizeLabel.setForeground(new Color(152, 251, 152));
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
           ImageIcon backgroundImage = new ImageIcon("Resources/GuessTheNumberLogo.png");
           Image scaledImage = backgroundImage.getImage().getScaledInstance(753, 300, Image.SCALE_SMOOTH);
           ImageIcon bgImage = new ImageIcon(scaledImage);
           @Override
           protected void paintComponent(Graphics g) 
           {
               super.paintComponent(g);
               g.drawImage(bgImage.getImage(), 0, 0, getWidth(), getHeight(), null);
           }
        };
        mainMenuTitle.setVisible(true);
        Dimension d = mainMenuTitle.getPreferredSize();
        mainMenuTitle.setBounds((initialFrame.getWidth() / 2) - (int)(753 / 2), 33, 753, 300);
        mainMenuTitle.setVisible(true);
        return mainMenuTitle;
    }
    
    public static JLabel createTimeDate()
    {
        timeDateLabel = new JLabel("Time and Date goes here :3");
        timeDateLabel.setFont(new Font("Comic Sans MS", Font.PLAIN, 15));
        timeDateLabel.setForeground(new Color(152, 251, 152));
        Dimension d = timeDateLabel.getPreferredSize();
        timeDateLabel.setBounds(10, 10, (int)d.getWidth(), (int)d.getHeight());
        return timeDateLabel;
    }
    
    public static JLabel createPressAny()
    {
        pressAnyButton = new JLabel("- Press Anything To Continue -");
        pressAnyButton.setFont(new Font("Comic Sans MS", Font.PLAIN, 32));
        pressAnyButton.setForeground(new Color(152, 251, 152));
        Dimension d = pressAnyButton.getPreferredSize();
        pressAnyButton.setBounds((initialFrame.getWidth() / 2) - (int)(d.getWidth() / 2), 620, (int)d.getWidth(), (int)d.getHeight());
        return pressAnyButton;
    }
    
    public static JLabel createEasyLabel()
    {
       easyLabel = new JLabel()
       {
           ImageIcon backgroundImage = new ImageIcon("Resources/EasyPicture.png");
           Image scaledImage = backgroundImage.getImage().getScaledInstance(295, 100, Image.SCALE_SMOOTH);
           ImageIcon bgImage = new ImageIcon(scaledImage);
           @Override
           protected void paintComponent(Graphics g) 
           {
               super.paintComponent(g);
               g.drawImage(bgImage.getImage(), 0, 0, getWidth(), getHeight(), null);
           }
       };
       easyLabel.setFont(new Font("Comic Sans MS", Font.PLAIN, 15));
       easyLabel.setForeground(new Color(152, 251, 152));
       Dimension d = easyLabel.getPreferredSize();
       easyLabel.setBounds(830, 145, 295, 100);
       easyLabel.setVisible(false);
       easyLabel.addMouseListener(new MouseAdapter()
       {
           @Override
           public void mouseClicked(MouseEvent e)
           {
               difficultySectionVisible(false);
               scalingImage("Resources/DarkBackground.png");
               guessingProcess(250, 4, 1, 0);
           }
       });
       return easyLabel;
    }
    
    public static JLabel createNormalLabel()
    {
        normalLabel = new JLabel()
        {
           ImageIcon backgroundImage = new ImageIcon("Resources/NormalPicture.png");
           Image scaledImage = backgroundImage.getImage().getScaledInstance(295, 100, Image.SCALE_SMOOTH);
           ImageIcon bgImage = new ImageIcon(scaledImage);
           @Override
           protected void paintComponent(Graphics g) 
           {
               super.paintComponent(g);
               g.drawImage(bgImage.getImage(), 0, 0, getWidth(), getHeight(), null);
           }
        };
        normalLabel.setFont(new Font("Comic Sans MS", Font.PLAIN, 15));
        normalLabel.setForeground(Color.WHITE);
        Dimension d = normalLabel.getPreferredSize();
        normalLabel.setBounds(830, 288, 295, 100);
        normalLabel.setVisible(false);
        return normalLabel;
    }
    
    public static JLabel createHardLabel()
    {
        hardLabel = new JLabel()
        {
            ImageIcon backgroundImage = new ImageIcon("Resources/HardPicture.png");
            Image scaledImage = backgroundImage.getImage().getScaledInstance(295, 100, Image.SCALE_SMOOTH);
            ImageIcon bgImage = new ImageIcon(scaledImage);
            @Override
            protected void paintComponent(Graphics g) 
            {
                super.paintComponent(g);
                g.drawImage(bgImage.getImage(), 0, 0, getWidth(), getHeight(), null);
            }
        };
        hardLabel.setFont(new Font("Comic Sans MS", Font.PLAIN, 15));
        hardLabel.setForeground(Color.WHITE);
        Dimension d = hardLabel.getPreferredSize();
        hardLabel.setBounds(830, 430, 295, 100);
        hardLabel.setVisible(false);
        return hardLabel;
    }
    
    public static JLabel createGitHub()
    {
        gitHubPicture = new JLabel()
        {
           ImageIcon backgroundImage = new ImageIcon("Resources/GitHub40p.png");
           Image scaledImage = backgroundImage.getImage().getScaledInstance(20, 20, Image.SCALE_SMOOTH);
           ImageIcon bgImage = new ImageIcon(scaledImage);
           @Override
           protected void paintComponent(Graphics g) 
           {
               super.paintComponent(g);
               g.drawImage(bgImage.getImage(), 0, 0, getWidth(), getHeight(), null);
           }
        };
        gitHubPicture.setFont(new Font("Comic Sans MS", Font.PLAIN, 15));
        gitHubPicture.setForeground(Color.WHITE);
        gitHubPicture.setBounds(initialFrame.getWidth() - 30, initialFrame.getHeight() - 30, 20, 20);
        gitHubPicture.setVisible(true);
        
        gitHubPicture.addMouseListener(new MouseAdapter()
        {
            @Override
            public void mouseClicked(MouseEvent e)
            {
                try 
                {
                    Desktop.getDesktop().browse(new URI("https://github.com/iid3rp/PythonPioneers-GuessTheNumber"));
                } 
                catch(IOException | URISyntaxException ex) 
                {
                    ex.printStackTrace(); // Handle the exception appropriately
                }
            }
        });
        return gitHubPicture;
    }
    
    public static JLabel createTipLabel()
    {
        tipLabel = new JLabel();
        tipLabel.setFont(new Font("Comic Sans MS", Font.PLAIN, 15));
        tipLabel.setForeground(new Color(152, 251, 152));
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
        difficultySection = new JLabel()
        {
           ImageIcon backgroundImage = new ImageIcon("Resources/GameBasics.png");
           Image scaledImage = backgroundImage.getImage().getScaledInstance(500, 500, Image.SCALE_SMOOTH);
           ImageIcon bgImage = new ImageIcon(scaledImage);
           @Override
           protected void paintComponent(Graphics g) 
           {
               super.paintComponent(g);
               g.drawImage(bgImage.getImage(), 0, 0, getWidth(), getHeight(), null);
           }
        };
        difficultySection.setFont(new Font("Comic Sans MS", Font.PLAIN, 15));
        difficultySection.setForeground(Color.WHITE);
        Dimension d = difficultySection.getPreferredSize();
        difficultySection.setBounds(78, 77, 500, 500);
        difficultySection.setVisible(false);
        return difficultySection;
    }
    
    public static JLabel createCountDown()
    {
        countDownLabel = new JLabel("3");
        countDownLabel.setFont(new Font("Comic Sans MS", Font.PLAIN, 72));
        countDownLabel.setForeground(Color.WHITE);
        Dimension d = countDownLabel.getPreferredSize();
        countDownLabel.setBounds((initialFrame.getWidth() / 2) - (int)(d.getHeight() / 2), (initialFrame.getHeight() / 2) - (int)(d.getHeight() / 2), (int)d.getWidth(), (int)d.getHeight());
        return countDownLabel;
    }

    public static JLabel createGuidingLabel()
    {
        guidingLabel = new JLabel();
        guidingLabel.setFont(new Font("Comic Sans MS", Font.PLAIN, 30));
        guidingLabel.setForeground(Color.WHITE);
        Dimension d = guidingLabel.getPreferredSize();
        guidingLabel.setBounds((initialFrame.getWidth() / 2) - (int)(d.getHeight() / 2), (initialFrame.getHeight() / 2) - (int)(d.getHeight() / 2), (int)d.getWidth(), (int)d.getHeight());
        return guidingLabel;
    }
    
    public static JLabel createGameOver()
    {
        gameOverLabel = new JLabel()
        {
           ImageIcon backgroundImage = new ImageIcon("Resources/GameOver.png");
           Image scaledImage = backgroundImage.getImage().getScaledInstance(362, 135, Image.SCALE_SMOOTH);
           ImageIcon bgImage = new ImageIcon(scaledImage);
           @Override
           protected void paintComponent(Graphics g) 
           {
               super.paintComponent(g);
               g.drawImage(bgImage.getImage(), 0, 0, getWidth(), getHeight(), null);
           }
        };
        gameOverLabel.setFont(new Font("Comic Sans MS", Font.PLAIN, 15));
        gameOverLabel.setForeground(Color.WHITE);
        Dimension d = gameOverLabel.getPreferredSize();
        gameOverLabel.setBounds((initialFrame.getWidth() / 2) - 181, 360, (int)d.getWidth(), (int)d.getHeight());
        return gameOverLabel;
    }
    
    public static JLabel createTimerLabel()
    {
        timerLabel = new JLabel("0:00");
        timerLabel.setFont(new Font("Comic Sans MS", Font.PLAIN, 15));
        timerLabel.setForeground(Color.WHITE);
        Dimension d = timerLabel.getPreferredSize();
        timerLabel.setBounds(10, 10, (int)d.getWidth(), (int)d.getHeight());
        return timerLabel;
    }
    
    public static JLabel createNumberHolder()
    {
        numberHolderLabel = new JLabel("_______");
        numberHolderLabel.setFont(new Font("Comic Sans MS", Font.PLAIN, 72));
        numberHolderLabel.setForeground(Color.WHITE);
        Dimension d = numberHolderLabel.getPreferredSize();
        numberHolderLabel.setBounds(10, 10, (int)d.getWidth(), (int)d.getHeight());
        return numberHolderLabel;
    }
    
    public static JLabel createAttemptLabel()
    {
        attemptLabel = new JLabel("Attempts: 0");
        attemptLabel.setFont(new Font("Comic Sans MS", Font.PLAIN, 25));
        attemptLabel.setForeground(Color.WHITE);
        Dimension d = attemptLabel.getPreferredSize();
        attemptLabel.setBounds(10, 10, (int)d.getWidth(), (int)d.getHeight());
        return attemptLabel;
    }
    
    public static JLabel createGoHome()
    {
        goHomeLabel = new JLabel()
        {
           ImageIcon backgroundImage = new ImageIcon("Resources/GoHome.png");
           Image scaledImage = backgroundImage.getImage().getScaledInstance(294, 100, Image.SCALE_SMOOTH);
           ImageIcon bgImage = new ImageIcon(scaledImage);
           @Override
           protected void paintComponent(Graphics g) 
           {
               super.paintComponent(g);
               g.drawImage(bgImage.getImage(), 0, 0, getWidth(), getHeight(), null);
           }
        };
        goHomeLabel.setFont(new Font("Comic Sans MS", Font.PLAIN, 15));
        goHomeLabel.setForeground(Color.WHITE);
        Dimension d = goHomeLabel.getPreferredSize();
        goHomeLabel.setBounds(12, 619, 294, 100);
        return goHomeLabel;
    }
    
    public static JLabel createWinnersLabel()
    {
        winnersLabel = new JLabel();
        winnersLabel.setFont(new Font("Comic Sans MS", Font.PLAIN, 25));
        winnersLabel.setForeground(new Color(152, 251, 152));
        winnersFileRead();
        winnersLabel.setText(winnersString);
        Dimension d = winnersLabel.getPreferredSize();
        winnersLabel.setBounds(10, initialFrame.getHeight() - (int) d.getHeight() - 10, (int) d.getWidth(), (int) d.getHeight());
        winnersLabel.setVisible(true);
        return winnersLabel;
    }
    
    public static javax.swing.Timer createTimeDateTimer()
    {
        timeDateTimer = new javax.swing.Timer(1, new ActionListener()
        {
            @Override
            public void actionPerformed(ActionEvent e)
            {
                SimpleDateFormat sdf = new SimpleDateFormat("EEEE, MMMM dd, yyyy | HH:mm:ss");
                String timeDateNow = sdf.format(new Date());
                timeDateLabel.setText(timeDateNow);
                timeDateTimer.setDelay(1000);
                Dimension d = timeDateLabel.getPreferredSize();
                timeDateLabel.setBounds(10, 10, (int) d.getWidth(), (int) d.getHeight());
            }
        });
        return timeDateTimer;
    }
    
    public static javax.swing.Timer createTipTimer()
    {
        tipTimer = new javax.swing.Timer(1, new ActionListener()
        {
            @Override
            public void actionPerformed(ActionEvent e)
            {
                tipLabel.setText(tipsText[new Random().nextInt(tipsText.length)]);
                tipTimer.setDelay(3000);
                Dimension d = tipLabel.getPreferredSize();
                tipLabel.setBounds((initialFrame.getWidth() / 2) - (int)(d.getWidth() / 2), (initialFrame.getHeight() - (int) d.getHeight() - 10), (int) d.getWidth(), (int) d.getHeight());
            }
        });
        return tipTimer;
    }
    
    public static javax.swing.Timer createOpening()
    {
        openingWindow = new javax.swing.Timer(10, new ActionListener()
        {
            @Override
            public void actionPerformed(ActionEvent e)
            {
                initialFrame.setOpacity(initialFrame.getOpacity() + .04f);
                if(initialFrame.getOpacity() > .96f)
                {
                    initialFrame.setOpacity(1);
                    openingWindow.stop();
                }
            }
        });
        return openingWindow;
    }
    
    public static javax.swing.Timer createClosing()
    {
        closingWindow = new javax.swing.Timer(10, new ActionListener()
        {
            @Override
            public void actionPerformed(ActionEvent e)
            {
                initialFrame.setOpacity(initialFrame.getOpacity() - .04f);
                if(initialFrame.getOpacity() < .04f)
                {
                    initialFrame.setOpacity(0);
                    closingWindow.stop();
                    System.exit(0);
                }
            }
        });
        return closingWindow;
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
            createClosing().start();
        }
    }
    
    public static void guessingProcess(int limit, int attempts, int minutes, int seconds)
    {
        
    }
    
    public static void scalingImage(String image)
    {
        ImageIcon backgroundImage = new ImageIcon(image);
        scaledImage = backgroundImage.getImage().getScaledInstance(initialFrame.getWidth(), initialFrame.getHeight(), Image.SCALE_SMOOTH);
        initialFrame.repaint();
    }

    public static void main(String[] args) 
    {
        initializeComponent();
    }
}
