import java.util.*;
import javax.swing.*;
import java.io.*;

public class FinalProject_PP_iid3rp
{
    public static Scanner input = new Scanner(System.in);
    public static String textLetter = "", cipherText = "", letters = "abcdefghijklmnopqrstuvwxyz";
    public static void main(String[] args) 
    {
        Ciphering("Letter.txt");
        JOptionPane.showMessageDialog(null, cipherText);
        InitialFrame.initializeComponent();
    }
    
    public static void Ciphering(String file)
    {
        try(BufferedReader fileReader = new BufferedReader(new FileReader(file)))
		{
			String line;
			while((line = fileReader.readLine()) != null) // creating a string of the whole file read..
			{
				textLetter += (line + "\n"); // iteration of the lines         
			}
            
            for(int i = 0; i < textLetter.length(); i++)
            {
                char currentChar = textLetter.charAt(i);
                if(!(Character.isLetter(currentChar))) 
                {
                   cipherText += currentChar;
                } 
                else 
                {
                    boolean isUppercase = Character.isUpperCase(currentChar);
                    for (int j = 0; j < letters.length(); j++) 
                    {
                        if (Character.toLowerCase(currentChar) == letters.charAt(j)) 
                        {
                            char shiftedChar = letters.charAt((j + 11) % 26);
                            if (isUppercase) 
                            {
                                shiftedChar = Character.toUpperCase(shiftedChar);
                            }    
                            cipherText += shiftedChar;
                            break;
                        }
                    }
                }
            }
		}
        catch(IOException e)
        {
           e.printStackTrace();
        }
    }
}