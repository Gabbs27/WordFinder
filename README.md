# WordFinder Project

A word search implementation that finds words in a character matrix both horizontally and vertically, with a console interface for testing.

## Prerequisites
- .NET 8.0 SDK
- Visual Studio 2022 or VS Code

## Project Structure
- **WordFinder.Core**: Main algorithm implementation
- **WordFinder.Tests**: Unit tests
- **WordFinder.Console**: Interactive testing interface

## How to Run

### Using Visual Studio 2022:
1. Open `WordFinder.sln`
2. Right-click on `WordFinder.Console` in Solution Explorer
3. Select "Set as Startup Project"
4. Press F5 or click the Run button

### Using Command Line:
1. Open Command Prompt or PowerShell
2. Navigate to the project folder:
   ```
   cd WordFinder.Console
   ```
3. Run the application:
   ```
   dotnet run
   ```

## How to Test the Console App

1. When prompted, enter matrix size (example: 4 for 4x4 matrix)

2. Enter the matrix row by row:
   ```
   Row 1: cold
   Row 2: wind
   Row 3: snow
   Row 4: hill
   ```

3. Enter words to search (comma-separated):
   ```
   cold, wind, snow, sun
   ```

4. View results:
   ```
   Results (Top 10 found words):
   -----------------------------
   Found: cold
   Found: wind
   Found: snow
   ```

5. Press 'R' to run another test or any other key to exit

## Running Unit Tests

Using Command Line:

```
dotnet test
```

Using Visual Studio:
1. Open Test Explorer
2. Click "Run All Tests"

## Features
- Searches words horizontally (left to right)
- Searches words vertically (top to bottom)
- Returns top 10 most repeated words
- Handles duplicate words
- Maximum matrix size: 64x64

## Example Matrix

c o l d
w i n d
s n o w
h i l l


## Technical Notes
- Uses optimized char[,] array for matrix storage
- Implements input validation
- Memory-efficient implementation
- Early exit optimization for word searches

Developed by Gabriel - 2025
