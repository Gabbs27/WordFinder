using WordFinder.Core;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("WordFinder Visual Tester");
            Console.WriteLine("=======================\n");

            // Get matrix dimensions
            Console.Write("Enter matrix size (e.g., 4 for 4x4): ");
            if (!int.TryParse(Console.ReadLine(), out int size) || size <= 0 || size > 64)
            {
                Console.WriteLine("Invalid size. Please enter a number between 1 and 64.");
                WaitForKey();
                continue;
            }

            // Create matrix
            var matrix = new List<string>();
            Console.WriteLine("\nEnter matrix row by row:");
            for (int i = 0; i < size; i++)
            {
                Console.Write($"Row {i + 1}: ");
                var row = Console.ReadLine()?.Trim();
                if (string.IsNullOrEmpty(row) || row.Length != size)
                {
                    Console.WriteLine($"Invalid row. Please enter exactly {size} characters.");
                    i--; // Retry this row
                    continue;
                }
                matrix.Add(row);
            }

            // Display the matrix
            Console.WriteLine("\nYour Matrix:");
            DisplayMatrix(matrix);

            // Create WordFinder instance
            var wordFinder = new WordFinder.Core.WordFinder(matrix);

            // Get words to search
            Console.WriteLine("\nEnter words to search (comma-separated):");
            var wordInput = Console.ReadLine() ?? "";
            var wordStream = wordInput.Split(',')
                                    .Select(w => w.Trim())
                                    .Where(w => !string.IsNullOrEmpty(w));

            // Search for words
            Console.WriteLine("\nSearching...");
            var results = wordFinder.Find(wordStream);

            // Display results
            Console.WriteLine("\nResults (Top 10 found words):");
            Console.WriteLine("-----------------------------");
            if (!results.Any())
            {
                Console.WriteLine("No words found in the matrix.");
            }
            else
            {
                foreach (var word in results)
                {
                    Console.WriteLine($"Found: {word}");
                    HighlightWord(matrix, word);
                }
            }

            // Ask to continue
            Console.WriteLine("\nPress 'R' to run again or any other key to exit.");
            if (Console.ReadKey().Key != ConsoleKey.R)
                break;
        }
    }

    static void DisplayMatrix(List<string> matrix)
    {
        Console.WriteLine();
        for (int i = 0; i < matrix.Count; i++)
        {
            Console.Write("  ");
            for (int j = 0; j < matrix[i].Length; j++)
            {
                Console.Write(matrix[i][j] + " ");
            }
            Console.WriteLine();
        }
        Console.WriteLine();
    }

    static void HighlightWord(List<string> matrix, string word)
    {
        // Check horizontal
        for (int i = 0; i < matrix.Count; i++)
        {
            int index = matrix[i].IndexOf(word);
            if (index >= 0)
            {
                Console.WriteLine($"  Found horizontally at row {i + 1}, column {index + 1}");
                return;
            }
        }

        // Check vertical
        for (int col = 0; col < matrix[0].Length; col++)
        {
            var verticalWord = new StringBuilder();
            for (int row = 0; row < matrix.Count; row++)
            {
                verticalWord.Append(matrix[row][col]);
            }
            int index = verticalWord.ToString().IndexOf(word);
            if (index >= 0)
            {
                Console.WriteLine($"  Found vertically at column {col + 1}, starting at row {index + 1}");
                return;
            }
        }
    }

    static void WaitForKey()
    {
        Console.WriteLine("\nPress any key to continue...");
        Console.ReadKey();
    }
}
