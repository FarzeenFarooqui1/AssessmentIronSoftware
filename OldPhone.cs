using System;
using System.Collections.Generic;
using System.Text;

public class PhonePadConverter
{
	// Dictionary For mapping number keys 
	private static readonly Dictionary <char, string> Keypad = new Dictionary<char, string>
	{
		{'1',""}, {'2', "ABC"}, {'3', "DEF"}, {'4', "GHI"}, {'5', "JKL"}, {'6', "MNO"}, {'7', "PQRS"}, {'8', "TUV"}, {'9', "WXYZ"}, {'0', " "},  
	};
	// method for converting the 
	public static string OldPhonePad(string input)
	{
		if (string.IsNullOrEmpty(input)) return "";

        StringBuilder result = new StringBuilder();
        StringBuilder currentSequence = new StringBuilder();
        char? lastCharacter = null;

        foreach (char character in input)
        {
            if (character == '#')
            {
                // End of input
                break;
            }
            else if (character == '*')
            {
                // delete current sequence first
    			AppendCharacter(result, currentSequence.ToString());
    			currentSequence.Clear();
    			lastCharacter = null;

    			if (result.Length > 0)
        			result.Length--;
            }
            else if (character == ' ')
            {
                // Pause and end current sequence
                AppendCharacter(result, currentSequence.ToString());
                currentSequence.Clear();
                lastCharacter = null;
            }
            else if (char.IsDigit(character))
            {
                if (lastCharacter == null || character == lastCharacter)
                {
                    currentSequence.Append(character);
                }
                else
                {
                    // end keypress sequence
                    AppendCharacter(result, currentSequence.ToString());
                    currentSequence.Clear();
                    currentSequence.Append(character);
                }

                lastCharacter = character;
            }
        }

        // Add any leftover sequence
        AppendCharacter(result, currentSequence.ToString());

        return result.ToString().ToUpper(); //For returning the result and making sure to enforce upper case
	}
	// appending characters to the sequence
    private static void AppendCharacter(StringBuilder result, string keySequence)
    {
        	if (string.IsNullOrEmpty(keySequence)) return;

        	char key = keySequence[0];
        	int pressCount = keySequence.Length;

        	if (Keypad.ContainsKey(key) && Keypad[key].Length > 0)
        	{
            	string letters = Keypad[key];
            	int index = (pressCount - 1) % letters.Length;
            	result.Append(letters[index]);
        	}
    }


}
// testing class
public class TestCases
{
   static void Main(string[] args)
    {
        // Run test cases
        Test("33#", "E"); // simple testing
        Test("227*#", "B"); // testing with back space
        Test("4433555 555666 96667775553 # ", "HELLOWORLD");//testing more than one word(joined together)
        Test("8 88777444666*664#", "TURING");//Testing word with back space inbetween
        Test("222 2 22#", "CAB"); //testing the pause reset between tapping the same button
        Test("222*333*111",""); //for testing a blank case
        Test("2 22 222 3 33 333 4 44 444 5 55 555 6 66 666 7 77 777 7777 8 88 888 9 99 999 9999", "ABCDEFGHIJKLMNOPQRSTUVWXYZ");
    }

    static void Test(string input, string expected)
    {
        var result = PhonePadConverter.OldPhonePad(input);
        Console.WriteLine($"Input: {input} => Output: {result} | {(result == expected ? "Pass" : "Fail")}");
    }
}