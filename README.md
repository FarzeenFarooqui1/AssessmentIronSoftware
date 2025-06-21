# Old Phone Pad Converter

A simple C# console app that simulates typing text using an old-school mobile phone keypad.

---

## How It Works

This program converts digit sequences like `"4433555 555666096667775553#"` into their text equivalents using T9-style mapping.

---

## Input Format

- Digits `2` through `9` represent letters:
  - `'2'` → A, `'22'` → B, `'222'` → C
  - `'7'` and `'9'` support 4 letters each (e.g., `'7777'` → S)
- `'0'` inserts a **space**.
- `'1'` has **no letters** — it's ignored.
- `'*'` acts as a **backspace**, deleting the last added character.
- `'#'` marks the **end** of input. All characters after it are ignored.
- `' '` (space) **pauses** a key sequence to separate identical digits.

---
## How to Run This Code
Requirements:
.NET 6 SDK or higher installed
Steps to Run:
git clone https://github.com/your-username/PhonePadApp.git
cd PhonePadApp
dotnet restore     # Ensures dependencies are available
dotnet run         # Builds and runs the app

