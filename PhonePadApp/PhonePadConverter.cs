using System;
using System.Collections.Generic;
using System.Text;
/// <summary>
/// Converts a string of keypresses into corresponding text.
/// 
/// Input Format:
/// - Digits: '2'-'9' to type letters
/// - '0' adds a space
/// - '1' has no letters (ignored)
/// - '*' acts as a backspace (removes the last added character)
/// - '#' ends the input early
/// - ' ' (space) separates keypress sequences for the same key
/// 
/// Repeated Digits:
/// - Pressing the same digit multiple times cycles through its mapped letters
///   Example: "2" → "A", "22" → "B", "222" → "C"
/// 
/// Example:
/// Input: "4433555 555666096667775553#" → Output: "HELLO WORLD"
/// </summary>
using System;
using System.Collections.Generic;
using System.Text;

/// <summary>
/// Converts digit sequences from old mobile keypads to text.
/// Supports '*', '#', and pauses using spaces.
/// </summary>
public class PhonePadConverter
{
    private static readonly Dictionary<char, string> keyMappings = new Dictionary<char, string>
    {
        {'1', ""}, {'2', "ABC"}, {'3', "DEF"}, {'4', "GHI"},
        {'5', "JKL"}, {'6', "MNO"}, {'7', "PQRS"}, {'8', "TUV"},
        {'9', "WXYZ"}, {'0', " "}
    };

    /// <summary>
    /// Entry point for converting a keypress string to its text.
    /// Returns upper-case result or error message.
    /// </summary>
    public static string ConvertSequence(string input)
    {
        if (!IsValidInput(input)) return "[ERROR: Invalid input]";

        var outputText = new StringBuilder();
        var keySequence = new StringBuilder();

        foreach (char key in input)
        {
            if (!ProcessKey(key, keySequence, outputText))
                break; // '#' ends processing
        }

        AppendKeySequence(keySequence, outputText);
        return outputText.ToString().ToUpper();
    }

    /// <summary>
    /// Validates that all characters in the input are digits, '*', '#', or space.
    /// </summary>
    private static bool IsValidInput(string input)
    {
        foreach (char c in input)
        {
            if (!(char.IsDigit(c) || c == '*' || c == '#' || c == ' '))
                return false;
        }
        return true;
    }
    /// <summary>
    /// Helper function to clean up the append sequence
    /// </summary>
    private static void TryAppendAndClear(StringBuilder sequence, StringBuilder result)
    {
        AppendKeySequence(sequence, result);
    }

    /// <summary>
    /// Processes a single character updating the current state.
    /// </summary>
    private static bool ProcessKey(char key, StringBuilder sequence, StringBuilder result)
    {
        switch (key)
        {
            case '#':
                TryAppendAndClear(sequence, result);
                return false;

            case '*':
                TryAppendAndClear(sequence, result);
                    if (result.Length > 0) result.Length--;
            break;

            case ' ':
                TryAppendAndClear(sequence, result);
            break;

            default:
                if (char.IsDigit(key))
                {
                    if (sequence.Length == 0 || key == sequence[0])
                        sequence.Append(key);
                    else
                    {
                        TryAppendAndClear(sequence, result);
                        sequence.Append(key);
                    }
                }
                break;
        }
        return true;
    }

    /// <summary>
    /// Translates the current digit sequence into the corresponding letter.
    /// Clears the sequence after appending.
    /// </summary>
    private static void AppendKeySequence(StringBuilder sequence, StringBuilder result)
    {
        if (sequence.Length == 0) return;

        char key = sequence[0];
        int pressCount = sequence.Length;

        if (keyMappings.TryGetValue(key, out string letters) && letters.Length > 0)
        {
            int index = (pressCount - 1) % letters.Length;
            result.Append(letters[index]);
        }

        sequence.Clear();
    }
}