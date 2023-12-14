import java.util.*;
public class Ciphering 
{
   public static void main(String[] args) 
   {
      Scanner input = new Scanner(System.in);
      String letters = "abcdefghijklmnopqrstuvwxyz", cipherText = "";
   
      System.out.println("Enter a word to cipher:");
      String plainText = input.nextLine();
   
      System.out.print("How many shifts of positions? ");
      int shift = input.nextInt();

      for (int i = 0; i < plainText.length(); i++) 
      {
         char currentChar = plainText.charAt(i);
         if (!(Character.isLetter(currentChar))) 
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
                  char shiftedChar = letters.charAt((j + shift) % 26);
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
      System.out.println("\nCiphered Text: " + cipherText);
   }
}