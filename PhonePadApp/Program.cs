using System;

using System;

/// <summary>
/// Test harness for the PhonePadConverter.
/// Groups test cases into categories and runs them.
/// </summary>
public class Program
{
    public static void Main(string[] args)
    {
        RunPositiveTests();
        RunNegativeTests();
        RunEdgeCaseTests();
    }

    private static void RunPositiveTests()
    {
        Console.WriteLine("=== POSITIVE TEST CASES ===");
        RunTest("33#", "E", "Single letter");
        RunTest("227*#", "B", "Backspace once");
        RunTest("4433555 555666 96667775553#", "HELLOWORLD", "Multiple words");
        RunTest("8 88777444666*664#", "TURING", "Word with backspace in middle");
        RunTest("222 2 22#", "CAB", "Repeating key with spaces");
        RunTest("2 22 222 3 33 333 4 44 444 5 55 555 6 66 666 7 77 777 7777 8 88 888 9 99 999 9999#", 
                "ABCDEFGHIJKLMNOPQRSTUVWXYZ", "Full alphabet");
    }

    private static void RunNegativeTests()
    {
        Console.WriteLine("\n=== NEGATIVE TEST CASES ===");
        RunTest("abc#", "[ERROR: Invalid input]", "Contains invalid letters");
        RunTest("22@", "[ERROR: Invalid input]", "Contains special character '@'");
        RunTest("22a#", "[ERROR: Invalid input]", "Mixed valid and invalid characters");
    }

    private static void RunEdgeCaseTests()
    {
        Console.WriteLine("\n=== EDGE CASES ===");
        RunTest("", "[ERROR: Invalid input]", "Empty string");
        RunTest("*#", "", "Backspace at start");
        RunTest("#", "", "Just ending marker");
        RunTest("2*#", "", "Digit then backspace");
        RunTest("*2#", "A", "Backspace then digit");
        RunTest("22 22 22#", "CCC", "Pauses between same key");
        RunTest("****#", "", "Multiple backspaces without input");
    }

    // Runs a single test and prints result
    private static void RunTest(string input, string expected, string description)
    {
        var output = PhonePadConverter.ConvertSequence(input);
        string status = output == expected ? " Pass" : "Fail";
        Console.WriteLine($"[{description}] Input: \"{input}\" → Output: \"{output}\" | Expected: \"{expected}\" | {status}");
    }
}
