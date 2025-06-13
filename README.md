###Old Phone Pad


Each number key corresponds to a set of characters:
1 -> Blank
2 -> ABC
3 -> DEF
4 -> GHI
5 -> JKL
6 -> MNO
7 -> PQRS
8 -> TUV
9 -> WXYZ
0 -> (space)

Supports multi press input (e.g 2 = A, 22 = B etc)
Features:
  - `#` to mark the end of input
  - `*` to delete the last entered character
  - Space (` `) to pause input and confirm character
  - Converts final output to uppercase
  - Includes test cases to validate functionality

Test Cases:

Input : "33#" Output: "E"  // simple testing

Input:  "227*#" Output:  "B"  // testing with back space

Input :  "4433555 555666 96667775553 # " Output: "HELLOWORLD" //testing more than one word(joined together)

Input :  "8 88777444666*664#" Output:  "TURING"  //Testing word with back space inbetween

Input :  "222 2 22#" Output:  "CAB"  //testing the pause reset between tapping the same button

Input :  "222*333*111" Output: ""  //for testing a blank case

Input :  "2 22 222 3 33 333 4 44 444 5 55 555 6 66 666 7 77 777 7777 8 88 888 9 99 999 9999" Output: "ABCDEFGHIJKLMNOPQRSTUVWXYZ" // Alphabet

## Getting Started

### Prerequisites
 Download .NET SDK (Any version that supports C# 7.0+)
### Running the Program

1. Clone this repository or copy the source code.
2. Compile and run with:

```bash
dotnet run