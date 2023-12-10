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
    
    public static JFrame initialFrame;
    public static JPanel initialPanel;
    
    public static Point offset;
    public static boolean isDragging = false;

    public static void initializeComponent() 
    {
        initialFrame = createInitialFrame();
        initialPanel = createInitialPanel();
        initialFrame.add(initialPanel);
        initialFrame.setContentPane(initialPanel);
        
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
        
        return initialFrame;
    }
    
    public static JPanel createInitialPanel()
    {
        initialPanel = new JPanel();
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
                if (isDragging)
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

    public static void main(String[] args) 
    {
        // Your main method logic goes here
    }
}