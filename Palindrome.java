/************
Brief: Make a function that is passed a word and analyse it to see if it is a Palindrome.

e.g.
function("Tacocat")
Should return: true.

function("Melon")
Should return: false.
*************/



import java.util.Scanner;

public class Palindrome {

    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        boolean flag = false;
        
        // Loops as long as the user wants to check new words
        while (!flag){
            scanner = new Scanner(System.in);
            System.out.println("Enter a word to check if it's a Palindrome e.g. Tacocat.");
            
            // Get user input and convert to lower case
            String input = scanner.nextLine();
            String inputLC = input.toLowerCase();
            System.out.println("");
            
            // Pass word to function that returns TRUE if word is a palindrome
            if (palindromeCheck(inputLC) == true){
                System.out.println("Yes. \"" + input + "\" is a padindrome.");
            } else {
                System.out.println("No. \"" + input + "\" is NOT a padindrome.");
            }

            // Check another word ?
            System.out.println("Check another? Y/N :");
            String choice = scanner.nextLine();
            String choiceLC = choice.toLowerCase();
            
            if (!choiceLC.equals("y")){
                flag = true;
            } else {
                System.out.println("");
            }
        }
    
        System.out.println("\nProgram terminated by user.");
        scanner.close();
    } // end of main
    

    public static boolean palindromeCheck(String input){
        boolean match = true;
        int halfway = (int)(input.length()/2);
        
        // Check [0] against [n], [1] against [n-1] etc
        for (int i=0; i<halfway; i++){
            if ( input.charAt(i) != input.charAt(input.length()-i-1) ) {
                match = false;
                break;
            }
        } // End of for loop
        
    return match;
    } // end of paldindromeCheck method
  
} // end of Palindrome class
