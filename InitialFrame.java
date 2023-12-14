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
import java.time.format.DateTimeFormatter;
import java.time.LocalDateTime;

public class InitialFrame
{
   public static String[] args; // argument stated
   public static ImageIcon[] difficultySectionImages =
   {
      new ImageIcon("Resources/GameBasics.png"),
      new ImageIcon("Resources/DifficultyImage.png")
   };
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
   public static JLabel gameOverPicture;
   public static JLabel gameOverLabel;
   public static JLabel timerLabel;
   public static JLabel numberHolderLabel;
   public static JLabel attemptLabel;
   public static JLabel goHomeLabel;
   public static JLabel winnersLabel;
   public static JLabel guidingLabel;
   public static JLabel numberLabel;
   //
   // Timers goes here
   //
   public static javax.swing.Timer timeDateTimer;
   public static javax.swing.Timer tipTimer;
   public static javax.swing.Timer openingWindow;
   public static javax.swing.Timer closingWindow;
   public static javax.swing.Timer countDownTimer;
   public static javax.swing.Timer guessingTimer;
   //
   // The window dragging values
   //
   public static Point offset;
   public static boolean isDragging = false;
   //
   // File manipulation values
   //
   public static String programFolderPath = Paths.get(System.getenv("ProgramFiles(x86)"), "PythonPioneers-GuessTheNumber").toString();
   public static String winnersFilePath = programFolderPath + "/Winners.txt"; // Provide the actual path
   public static String distributionFilePath = programFolderPath + "/Distribution.txt"; // Provide the actual path
   //
   // Other static values
   //
   public static String winnersString = "";
   public static float frameOpacity = 0.0f;
   public static float currentOpacity = 0.0f;
   public static boolean isMainMenu, isDifficultySection, isGuessing, isANumber, isGuessed, isGameOver;
   public static Image scaledImage, difficultySectionImage;
   public static String stringHolder = "", difficultyName = "";
   public static int 
   //
   /// integer values
      index = 1,
      attempts = 0,
      secondsTime = 0,
      minutesTime = 0,
      guessingLimit = 0,
      currentNumber = 0,
      randomNumber = 0,
      countDown = 4,
      easy = 0,
      normal = 0,
      hard = 0;
   /// endregion    
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
            File winnersFile = new File(winnersFilePath);   
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
         
            File distributionFile = new File(distributionFilePath);
         
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
      try(BufferedReader winnersRead = new BufferedReader(new FileReader(winnersFilePath))) 
      {
         winnersRead.readLine();
      
         easy = parseWinnersLine(winnersRead.readLine());
         normal = parseWinnersLine(winnersRead.readLine());
         hard = parseWinnersLine(winnersRead.readLine());
         winnersString = "<html>" +
                        "Winners:<br>" +
                        "Easy: " + easy + "<br>" +
                        "Normal: " + normal + "<br>" +
                        "Hard: " + hard + "<br>" +
                        "</html>"; 
      } 
      catch(IOException e) 
      {
         e.printStackTrace();
      }
   }

   public static int parseWinnersLine(String line) 
   {
      if (line != null) 
      {
          String[] parts = line.split(":");
          if (parts.length > 1) 
          {
             try 
             {
                 return Integer.parseInt(parts[1].trim());
             } 
             catch(NumberFormatException e) 
             {
                 // Handle the exception appropriately
             }
          }
      }
      return 0;
   }
   
   public static void refreshIntegers()
   {
      index = 1;
      attempts = 0;
      secondsTime = 0;
      minutesTime = 0;
      guessingLimit = 0;
      currentNumber = 0;
      randomNumber = 0;
      countDown = 3;
      winnersLabel.setText(winnersString);
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
      gameOverPicture = createGameOverPicture();
      gameOverLabel = createGameOverLabel();
      timerLabel = createTimerLabel();
      numberHolderLabel = createNumberHolder();
      attemptLabel = createAttemptLabel();
      goHomeLabel = createGoHome();
      winnersLabel = createWinnersLabel();
      guidingLabel = createGuidingLabel();
      numberLabel = createNumberLabel();
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
      // Guessing section goes here
      //
      guessingPanel.add(attemptLabel);
      guessingPanel.add(numberHolderLabel);
      guessingPanel.add(guidingLabel);
      guessingPanel.add(timerLabel);
      guessingPanel.add(numberLabel);
      //
      // Game over section goes here
      //
      initialPanel.add(gameOverLabel);
      initialPanel.add(gameOverPicture);
      ///
      //// #endregion ------------------------------------------
      ///
      //
      // Timers goes here
      timeDateTimer = createTimeDateTimer();
      tipTimer = createTipTimer();
      openingWindow = createOpening();
      closingWindow = createClosing();
      countDownTimer = createCountDownTimer();
      guessingTimer = createGuessingTimer();
      //
      // Timers starting in JFrame load:
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
      
      initialFrame.addKeyListener(
         new KeyAdapter() 
         {
            @Override
            public void keyPressed(KeyEvent e) 
            {
               if(e.getKeyCode() == KeyEvent.VK_ESCAPE) 
               {
                  if(isDifficultySection)
                  {
                     difficultySectionVisible(false);
                     mainMenuSectionVisible(true);
                     isDifficultySection = false;
                  }
                  else
                  {
                     exitConfirmation();
                  }
               }
               else if(e.getKeyCode() == KeyEvent.VK_LEFT || e.getKeyCode() == KeyEvent.VK_RIGHT)
               {
                  if(isDifficultySection)
                  {
                     changingDifficultyImage();
                  }
               }
               else
               {
                  if(isGuessing)
                  {
                     if (e.getKeyCode() == KeyEvent.VK_ENTER)
                     {
                        if(numberLabel.getText().equals("getnum")) 
                        {
                           guidingLabel.setText("Random Number: " + randomNumber);
                        } 
                        else if (isANumber) 
                        {
                           if (!stringHolder.isEmpty()) 
                           {
                              numberLabel.setText("0");
                              currentNumber = Integer.parseInt(stringHolder);
                           }
                        
                           if (currentNumber > guessingLimit) 
                           {
                              guidingLabel.setText("<html>Number should not be greater than the guessing limit.</html>");
                           } 
                           else 
                           {
                              if(currentNumber > randomNumber) 
                              {
                                 guidingLabel.setText("<html>Hint: Current number is greater<br>than the random number.<br>"
                                    + "Current Number: " + currentNumber + "</html>");
                                 attempts--;
                                 countDownLabel.setText(String.format("%d:%02d%n", minutesTime, secondsTime));
                                 attemptLabel.setText("Attempts: " + attempts);
                              } 
                              else if(currentNumber < randomNumber) 
                              {
                                 guidingLabel.setText("<html>Hint: Current number is less<br>than the random number.<br>"
                                    + "Current Number: " + currentNumber + "</html>");
                                 attempts--;
                                 countDownLabel.setText(String.format("%d:%02d%n", minutesTime, secondsTime));
                                 attemptLabel.setText("Attempts: " + attempts);
                              } 
                              else if(currentNumber == randomNumber) 
                              {
                                 guessingPanel.setVisible(false);
                                 scalingImage("Resources/DarkBackground.png");
                                 gameOverLabel.setText("You won!! Yippie");
                                 Dimension d = gameOverLabel.getPreferredSize();
                                 gameOverLabel.setBounds((initialFrame.getWidth() / 2) - ((int)d.getWidth() / 2),
                                                 (initialFrame.getHeight() / 2) - ((int)d.getHeight() / 2),
                                    		 (int)d.getWidth(), (int)d.getHeight());
                                 isGuessed = true;
                                 isGuessing = false;
                                 isANumber = false;
                                 winnerVoid();
                                 distributionVoid();
                                 gameOverVisible(true);
                                 isGameOver = true;
                                 guessingTimer.stop();
                              }
                           
                              if(attempts == 0) 
                              {
                                 guessingPanel.setVisible(false);
                                 scalingImage("Resources/DarkBackground.png");
                                 if(Math.abs(currentNumber - randomNumber) <= 3) 
                                 {
                                    gameOverLabel.setText("<html>" + 
                                                     "You are so close!!!" + "<br>"
                                                   + "Current Number: " + currentNumber + "<br>"
                                                   + "Correct Number: " + randomNumber + 
                                                     "</html>");
                                 }
                                 else
                                 {
                                    countDownLabel.setText("");
                                    gameOverLabel.setText("<html>" 
                                                   + "You ran out of attempts :" + "<br>"
                                                   + "Current Number: " + currentNumber + "<br>"
                                                   + "Correct Number: " + randomNumber 
                                                   + "</html>");
                                 }
                                 isGuessing = false;
                                 isANumber = false;
                                 Dimension d = gameOverLabel.getPreferredSize();
                                 gameOverLabel.setBounds((initialFrame.getWidth() / 2) - ((int)d.getWidth() / 2),
                                                 (initialFrame.getHeight() / 2) - ((int)d.getHeight() / 2),
                                    		 (int)d.getWidth(), (int)d.getHeight());
                                 distributionVoid();
                                 gameOverVisible(true);
                                 isGameOver = true;
                                 guessingTimer.stop();
                              }
                           }
                           isANumber = false;
                        }
                     
                        stringHolder = "";
                        numberLabel.setText("0");
                     } 
                     else if(e.getKeyCode() == KeyEvent.VK_BACK_SPACE && !stringHolder.isEmpty()) 
                     {
                        stringHolder = stringHolder.substring(0, stringHolder.length() - 1);
                        numberLabel.setText(stringHolder);
                     }
                     middleChecking();
                  }
                  else if(isGameOver)
                  {
                     mainMenuSectionVisible(true);
                     gameOverVisible(false);
                     scalingImage("Resources/MainMenuBackground.png");
                     refreshIntegers();
                     isGameOver = false;
                  }
                  else
                  {
                     difficultySectionVisible(true);
                     mainMenuSectionVisible(false);
                     changingDifficultyImage();
                     isDifficultySection = true;
                  }
               }
               System.out.println("clicked."); // debugging
            }
            @Override
            public void keyTyped(KeyEvent e) 
            {
               if (isGuessing) 
               {
                  if (stringHolder.length() > 6) 
                  {
                     e.consume(); // Consume the event to prevent more characters being added
                  } else if (Character.isLetterOrDigit(e.getKeyChar())) 
                  {
                     stringHolder += e.getKeyChar();
                     stringHolder = stringHolder.trim();
                     numberLabel.setText(stringHolder);
                  
                     if (!isInteger(stringHolder))
                     {
                        guidingLabel.setText("Input should not contain characters.");
                        isANumber = false;
                     } 
                     else 
                     {
                        guidingLabel.setText("Number must be 0 - " + guessingLimit);
                        isANumber = true;
                     }
                  } 
                  else 
                  {
                     e.consume(); // its the like the e.handled = true in c#
                  }
               } 
               middleChecking();
            }
         });
      ImageIcon icon = new ImageIcon("PythonPioneersGuessTheNumber.png");
      initialFrame.setIconImage(icon.getImage());
      return initialFrame;
   }
   
   public static JPanel createInitialPanel()
   {
      initialPanel = 
         new JPanel() 
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
      
      initialPanel.addMouseListener(
         new MouseAdapter() 
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
      
      initialPanel.addMouseMotionListener(
         new MouseMotionAdapter() 
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
   
   public static void gameOverVisible(boolean b)
   {
      gameOverLabel.setVisible(b);
      gameOverPicture.setVisible(b);
      if(b)
      {
         pressAnyButton.setText("- Press Anything To Go Home -");
      }
      else pressAnyButton.setText("- Press Anything To Continue -");
      
      Dimension d = pressAnyButton.getPreferredSize();
      pressAnyButton.setBounds((initialFrame.getWidth() / 2) - (int)(d.getWidth() / 2), 620, (int)d.getWidth(), (int)d.getHeight());
   
   }
   
   public static void guessingSectionVisible(boolean b)
   {
      guessingPanel.setVisible(b);
   }

   public static JPanel createGuessingPanel()
   {
      guessingPanel = 
         new JPanel()
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
      guessingPanel.setLayout(null);
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
      
      exitOnClose.addMouseListener(
         new MouseAdapter()
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
      
      minimizeLabel.addMouseListener(
         new MouseAdapter()
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
      mainMenuTitle = 
         new JLabel() 
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
      easyLabel = 
         new JLabel()
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
      easyLabel.addMouseListener(
         new MouseAdapter()
         {
            @Override
            public void mouseClicked(MouseEvent e)
            {
               difficultySectionVisible(false);
               scalingImage("Resources/DarkBackground.png");
               countDownLabel.setVisible(true);
               countDownTimer.start();
               guessingProcess(250, "Easy", 4, 1, 0);
            }
         });
      return easyLabel;
   }
   
   public static JLabel createNormalLabel()
   {
      normalLabel = 
         new JLabel()
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
      normalLabel.addMouseListener(
         new MouseAdapter()
         {
            @Override
            public void mouseClicked(MouseEvent e)
            {
               difficultySectionVisible(false);
               scalingImage("Resources/DarkBackground.png");
               countDownLabel.setVisible(true);
               countDownTimer.start();
               guessingProcess(500, "Normal", 6, 1, 30);
            }
         });
      return normalLabel;
   }
   
   public static JLabel createHardLabel()
   {
      hardLabel = 
         new JLabel()
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
      hardLabel.addMouseListener(
         new MouseAdapter()
         {
            @Override
            public void mouseClicked(MouseEvent e)
            {
               difficultySectionVisible(false);
               scalingImage("Resources/DarkBackground.png");
               countDownLabel.setVisible(true);
               countDownTimer.start();
               guessingProcess(1000, "Hard",8, 2, 0);
            }
         });
      return hardLabel;
   }
   
   public static JLabel createGitHub()
   {
      gitHubPicture = 
         new JLabel()
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
      
      gitHubPicture.addMouseListener(
         new MouseAdapter()
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
                  ex.printStackTrace();
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
      difficultySection = 
         new JLabel()
         {
            @Override
            protected void paintComponent(Graphics g) 
            {
               ImageIcon bgImage = new ImageIcon(difficultySectionImage);
               super.paintComponent(g);
               g.drawImage(bgImage.getImage(), 0, 0, getWidth(), getHeight(), null);
            }
         };
      difficultySection.setFont(new Font("Comic Sans MS", Font.PLAIN, 15));
      difficultySection.setForeground(Color.WHITE);
      Dimension d = difficultySection.getPreferredSize();
      difficultySection.setBounds(78, 77, 500, 500);
      difficultySection.setVisible(false);
      difficultySection.addMouseListener(
         new MouseAdapter()
         {
            @Override
            public void mouseClicked(MouseEvent e)
            {
               changingDifficultyImage();
            }
         });
      return difficultySection;
   }
   
   public static JLabel createCountDown()
   {
      countDownLabel = new JLabel("3");
      countDownLabel.setFont(new Font("Comic Sans MS", Font.PLAIN, 72));
      countDownLabel.setForeground(new Color(152, 251, 152));
      Dimension d = countDownLabel.getPreferredSize();
      countDownLabel.setBounds((initialFrame.getWidth() / 2) - (int)(d.getWidth() / 2), 
                              (initialFrame.getHeight() / 2) - (int)(d.getHeight() / 2), 
                              (int) d.getWidth(), (int) d.getHeight());
      countDownLabel.setVisible(false);
      return countDownLabel;
   }

   public static JLabel createGuidingLabel()
   {
      guidingLabel = new JLabel("Guess any number!!");
      guidingLabel.setFont(new Font("Comic Sans MS", Font.PLAIN, 20));
      guidingLabel.setForeground(new Color(152, 251, 152));
      Dimension d = guidingLabel.getPreferredSize();
      guidingLabel.setBounds((guessingPanel.getWidth() / 2) - (int)(d.getWidth() / 2), 350, (int)d.getWidth(), (int)d.getHeight());
      guidingLabel.setVisible(true);
      return guidingLabel;
   }
   
   public static JLabel createGameOverPicture()
   {
      gameOverPicture = 
         new JLabel()
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
      gameOverPicture.setFont(new Font("Comic Sans MS", Font.PLAIN, 15));
      gameOverPicture.setForeground(Color.WHITE);
      Dimension d = gameOverPicture.getPreferredSize();
      gameOverPicture.setBounds((initialFrame.getWidth() / 2) - 181, 109, 362, 135);
      gameOverPicture.setVisible(false);
      return gameOverPicture;
   }
   
   public static JLabel createGameOverLabel()
   {
      gameOverLabel = new JLabel();
      gameOverLabel.setFont(new Font("Comic Sans MS", Font.PLAIN, 30));
      gameOverLabel.setForeground(new Color(152, 251, 152));
      Dimension d = gameOverLabel.getPreferredSize();
      gameOverLabel.setBounds((initialFrame.getWidth() / 2) - 181, 450, 362, 135);
      gameOverLabel.setVisible(false);
      return gameOverLabel;
   }
   
   public static JLabel createTimerLabel()
   {
      timerLabel = new JLabel("Time Left:  0m, 00s");
      timerLabel.setFont(new Font("Comic Sans MS", Font.PLAIN, 35));
      timerLabel.setForeground(new Color(152, 251, 152));
      Dimension d = timerLabel.getPreferredSize();
      timerLabel.setBounds((guessingPanel.getWidth() / 2) - (int)(d.getWidth() / 2), 50, (int)d.getWidth(), (int)d.getHeight());
      timerLabel.setVisible(true);
      return timerLabel;
   }
   
   public static JLabel createNumberLabel()
   {
      numberLabel = new JLabel("0");
      numberLabel.setFont(new Font("Comic Sans MS", Font.PLAIN, 60));
      numberLabel.setForeground(new Color(152, 251, 152));
      Dimension d = numberLabel.getPreferredSize();
      numberLabel.setBounds((guessingPanel.getWidth() / 2) - (int)(d.getWidth() / 2), 220, (int)d.getWidth(), (int)d.getHeight());
      numberLabel.setVisible(true);
      return numberLabel;
   }
   
   public static JLabel createNumberHolder()
   {
      numberHolderLabel = new JLabel("___________");
      numberHolderLabel.setFont(new Font("Consolas", Font.PLAIN, 50));
      numberHolderLabel.setForeground(new Color(152, 251, 152));
      Dimension d = numberHolderLabel.getPreferredSize();
      numberHolderLabel.setBounds((guessingPanel.getWidth() / 2) - (int)(d.getWidth() / 2), 250, (int)d.getWidth(), (int)d.getHeight());
      numberHolderLabel.setVisible(true);
      return numberHolderLabel;
   }
   
   public static JLabel createAttemptLabel()
   {
      attemptLabel = new JLabel("Attempts: 0");
      attemptLabel.setFont(new Font("Comic Sans MS", Font.PLAIN, 25));
      attemptLabel.setForeground(new Color(152, 251, 152));
      Dimension d = attemptLabel.getPreferredSize();
      attemptLabel.setBounds((guessingPanel.getWidth() / 2) - (int)(d.getWidth() / 2), 150, (int)d.getWidth(), (int)d.getHeight());
      attemptLabel.setVisible(true);
      return attemptLabel;
   }
   
   public static JLabel createGoHome()
   {
      goHomeLabel = 
         new JLabel()
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
      timeDateTimer = new javax.swing.Timer(1, 
         new ActionListener()
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
      tipTimer = new javax.swing.Timer(1, 
         new ActionListener()
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
      openingWindow = new javax.swing.Timer(10, 
         new ActionListener()
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
      closingWindow = new javax.swing.Timer(10, 
         new ActionListener()
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
   
   public static javax.swing.Timer createGuessingTimer()
   {
      guessingTimer = new javax.swing.Timer(1000, 
         new ActionListener()
         {
            @Override
            public void actionPerformed(ActionEvent e)
            {
               if (minutesTime == 0 && secondsTime == 0)
               {
                  guessingPanel.setVisible(false);
                  timerLabel.setText("0:00");
                  gameOverLabel.setText("<html>You're out of time :<br>"
                     + "Correct number: " + randomNumber + "</html>");
                  
                  pressAnyButton.setText("- Press Anything To Go Home -");
                  scalingImage("Resources/DarkBackground.png");
                  
                  // the label adjustments...
                  Dimension d = pressAnyButton.getPreferredSize();
                  pressAnyButton.setBounds((initialFrame.getWidth() / 2) - (int)(d.getWidth() / 2), 620, (int)d.getWidth(), (int)d.getHeight());
                  d = gameOverLabel.getPreferredSize();
                  gameOverLabel.setBounds((initialFrame.getWidth() / 2) - (int)(d.getWidth() / 2), 620, (int)d.getWidth(), (int)d.getHeight());

                  isGuessing = false;
                  isANumber = false;
                  distributionVoid();
                  gameOverVisible(true);
                  isGameOver = true;
                  guessingTimer.stop();
               }
               else
               {
                  if (secondsTime == 0)
                  {
                     minutesTime--;
                     secondsTime = 59;
                  }
                  else
                  {
                     secondsTime--;
                  }
                  timerLabel.setText(String.format("Time Left: %dm, %02ds%n", minutesTime, secondsTime));
               }
               middleChecking();
            }
         });
      return guessingTimer;
   }
   
   public static javax.swing.Timer createCountDownTimer()
   {
      countDownTimer = new javax.swing.Timer(1, 
         new ActionListener()
         {
            @Override
            public void actionPerformed(ActionEvent e)
            {
               pressAnyButton.setText("");
               if(countDown >= 0)
               {
                  if(countDown == 0)
                  {
                     countDownLabel.setText("Start Guessing!");                
                  }
                  else
                  {
                     countDownLabel.setText(Integer.toString(countDown));
                  }
                  countDown--;
                  countDownTimer.setDelay(1000);
                  Dimension d = countDownLabel.getPreferredSize();
                  countDownLabel.setBounds((initialFrame.getWidth() / 2) - (int)(d.getWidth() / 2), 
                                      (initialFrame.getHeight() / 2) - (int)(d.getHeight() / 2), 
                                      (int) d.getWidth(), (int) d.getHeight());
               }
               else
               {
                  scalingImage("Resources/MainMenuBackground.png");
                  countDownLabel.setVisible(false);
                  guessingPanel.setVisible(true);
                  guessingTimer.start();
                  countDownTimer.stop();
               }
            }
         });
      return countDownTimer;
   }
   
   private static boolean isInteger(String s) 
   {
      try 
      {
         Integer.parseInt(s);
         return true;
      } 
      catch(NumberFormatException e) 
      {
         return false;
      }
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
   
   public static void guessingProcess(int limit, String diff, int att, int min, int sec)
   {
      attempts = att;
      attemptLabel.setText("Attempts: " + att);
      guessingLimit = limit;
      difficultyName = diff;
      randomNumber = new Random().nextInt(limit);
      minutesTime = min;
      secondsTime = sec;
      isDifficultySection = false;
      isGuessing = true;
   }
   
   public static void scalingImage(String image)
   {
      ImageIcon backgroundImage = new ImageIcon(image);
      scaledImage = backgroundImage.getImage().getScaledInstance(initialFrame.getWidth(), initialFrame.getHeight(), Image.SCALE_SMOOTH);
      initialFrame.repaint();
   }

   public static void changingDifficultyImage()
   {
      if(index == 0)
      {
         difficultySectionImage = difficultySectionImages[1].getImage().getScaledInstance(500, 500, Image.SCALE_SMOOTH);
         index++;
      }
      else
      {
         difficultySectionImage = difficultySectionImages[0].getImage().getScaledInstance(500, 500, Image.SCALE_SMOOTH);
         index--;
      }
      difficultySection.repaint();
   }
   
   public static void middleChecking()
   {
      Dimension[] d =
         {
         timerLabel.getPreferredSize(),
         numberLabel.getPreferredSize(),
         attemptLabel.getPreferredSize(),
         guidingLabel.getPreferredSize()
         };
      timerLabel.setBounds((guessingPanel.getWidth() / 2) - (int)(d[0].getWidth() / 2), 50, (int)d[0].getWidth(), (int)d[0].getHeight());
      numberLabel.setBounds((guessingPanel.getWidth() / 2) - (int)(d[1].getWidth() / 2), 220, (int)d[1].getWidth(), (int)d[1].getHeight());
      attemptLabel.setBounds((guessingPanel.getWidth() / 2) - (int)(d[2].getWidth() / 2), 150, (int)d[2].getWidth(), (int)d[2].getHeight());
      guidingLabel.setBounds((guessingPanel.getWidth() / 2) - (int)(d[3].getWidth() / 2), 350, (int)d[3].getWidth(), (int)d[3].getHeight());
   }

   public static void distributionVoid() 
   {
      String pastText = null;
      try (BufferedReader distributionFileRead = new BufferedReader(new FileReader(distributionFilePath)))
      {
         StringBuilder stringBuilder = new StringBuilder();
         String line;
         while ((line = distributionFileRead.readLine()) != null) 
         {
            stringBuilder.append(line).append("\n");
         }
         pastText = stringBuilder.toString();
      }
      catch (IOException e) 
      {
         e.printStackTrace(); // Handle the exception appropriately
      }
   
      try (PrintWriter distributionIni = new PrintWriter(new FileWriter(distributionFilePath))) 
      {
         distributionIni.print(pastText);
         if ("Normal".equals(difficultyName)) 
         {
            distributionIni.println(DateTimeFormatter.ofPattern("MM/dd/yyyy HH:mm:ss").format(LocalDateTime.now()) +
                       "\t  " + difficultyName + "\t  " +
                       randomNumber + "\t\t " + isGuessed);
         }
         else
         {
            distributionIni.println(DateTimeFormatter.ofPattern("MM/dd/yyyy HH:mm:ss").format(LocalDateTime.now()) +
                       "\t  " + difficultyName + "\t\t  " +
                       randomNumber + "\t\t " + isGuessed);
         }
      }
      catch (IOException e) 
      {
         e.printStackTrace(); // Handle the exception appropriately
      }
   }

   public static void winnerVoid()
   {
      try (PrintWriter winnersWrite = new PrintWriter(new FileWriter(winnersFilePath))) 
      {
         switch(guessingLimit)
         {
            case 250:
            {
               easy++;
               break;
            }
            case 500:
            {
               normal++;
               break;
            }
            case 1000:
            {
               hard++;
               break;
            }
         }
         winnersWrite.println("Winners:\n" +
                     "Easy: " + easy + "\n" +
                     "Normal: " + normal + "\n" +
                     "Hard: " + hard + "\n");
      }
      catch(IOException e)
      {
         e.printStackTrace(); // Handle the exception appropriately
      }
      winnersFileRead();
   }
	
   public static void main(String[] args) 
   {
      initializeComponent();
   }
}
