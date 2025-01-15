using System;
using System.Collections.Generic;
using System.Linq;

namespace WordFinder.Core
{
    public class WordFinder
    {
        private readonly char[,] _matrix;
        private readonly int _rows;
        private readonly int _cols;
        private const int MaxMatrixSize = 64;

        public WordFinder(IEnumerable<string> matrix)
        {
            if (matrix == null) throw new ArgumentNullException(nameof(matrix));

            var matrixList = matrix.ToList();
            if (!matrixList.Any()) throw new ArgumentException("Matrix cannot be empty");

            _rows = matrixList.Count;
            _cols = matrixList[0].Length;

            // Validate matrix size
            if (_rows > MaxMatrixSize || _cols > MaxMatrixSize)
                throw new ArgumentException($"Matrix cannot exceed {MaxMatrixSize}x{MaxMatrixSize}");

            // Validate equal string lengths
            if (matrixList.Any(row => row.Length != _cols))
                throw new ArgumentException("All strings in matrix must have equal length");

            // Convert to char array for better performance
            _matrix = new char[_rows, _cols];
            for (int i = 0; i < _rows; i++)
                for (int j = 0; j < _cols; j++)
                    _matrix[i, j] = matrixList[i][j];
        }

        public IEnumerable<string> Find(IEnumerable<string> wordStream)
        {
            if (wordStream == null) throw new ArgumentNullException(nameof(wordStream));

            var wordCounts = new Dictionary<string, int>();
            var processedWords = new HashSet<string>();

            foreach (var word in wordStream)
            {
                if (string.IsNullOrEmpty(word) || processedWords.Contains(word)) continue;

                processedWords.Add(word);
                if (SearchWord(word))
                    wordCounts[word] = wordCounts.GetValueOrDefault(word, 0) + 1;
            }

            return wordCounts
                .OrderByDescending(w => w.Value)
                .Take(10)
                .Select(w => w.Key);
        }

        private bool SearchWord(string word)
        {
            // Search horizontally
            for (int i = 0; i < _rows; i++)
            {
                for (int j = 0; j <= _cols - word.Length; j++)
                {
                    if (CheckWordMatch(i, j, word, true))
                        return true;
                }
            }

            // Search vertically
            for (int i = 0; i <= _rows - word.Length; i++)
            {
                for (int j = 0; j < _cols; j++)
                {
                    if (CheckWordMatch(i, j, word, false))
                        return true;
                }
            }

            return false;
        }

        private bool CheckWordMatch(int row, int col, string word, bool horizontal)
        {
            for (int k = 0; k < word.Length; k++)
            {
                char matrixChar = horizontal ?
                    _matrix[row, col + k] :
                    _matrix[row + k, col];

                if (matrixChar != word[k]) return false;
            }
            return true;
        }
    }
}
