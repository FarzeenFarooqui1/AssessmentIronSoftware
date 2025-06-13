Old Phone Pad:


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
("33#", "E"); // simple testing
("227*#", "B"); // testing with back space

("4433555 555666 96667775553 # ", "HELLOWORLD");//testing more than one word(joined together)

("8 88777444666*664#", "TURING");//Testing word with back space inbetween

("222 2 22#", "CAB"); //testing the pause reset between tapping the same button

("222*333*111",""); //for testing a blank case

("2 22 222 3 33 333 4 44 444 5 55 555 6 66 666 7 77 777 7777 8 88 888 9 99 999 9999", "ABCDEFGHIJKLMNOPQRSTUVWXYZ"); // Alphabet

## Getting Started

### Prerequisites
 Download .NET SDK (Any version that supports C# 7.0+)
### Running the Program

1. Clone this repository or copy the source code.
2. Compile and run with:

```bash
dotnet run