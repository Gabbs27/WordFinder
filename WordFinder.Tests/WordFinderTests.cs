using System.Collections.Generic;
using Xunit;

public class WordFinderTests
{
    [Fact]
    public void Find_ReturnsEmpty_WhenNoWordsFound()
    {
        var matrix = new List<string> { "abcd", "efgh", "ijkl", "mnop" };
        var wordStream = new List<string> { "xyz", "uvw" };
        var wordFinder = new WordFinder.Core.WordFinder(matrix);

        var result = wordFinder.Find(wordStream);

        Assert.Empty(result);
    }

    [Fact]
    public void Find_FindsWordsHorizontally()
    {
        var matrix = new List<string> { "abcd", "efgh", "ijkl", "mnop" };
        var wordStream = new List<string> { "abcd", "mnop" };
        var wordFinder = new WordFinder.Core.WordFinder(matrix);

        var result = wordFinder.Find(wordStream);

        Assert.Contains("abcd", result);
        Assert.Contains("mnop", result);
    }

    [Fact]
    public void Find_FindsWordsVertically()
    {
        var matrix = new List<string> { "abcd", "efgh", "ijkl", "mnop" };
        var wordStream = new List<string> { "aeim", "bfjn" };
        var wordFinder = new WordFinder.Core.WordFinder(matrix);

        var result = wordFinder.Find(wordStream);

        Assert.Contains("aeim", result);
        Assert.Contains("bfjn", result);
    }

    [Fact]
    public void Find_ReturnsTop10MostRepeatedWords()
    {
        var matrix = new List<string> { "abcd", "abcd", "ijkl", "mnop" };
        var wordStream = new List<string> { "abcd", "abcd", "ijkl", "mnop", "mnop", "mnop" };
        var wordFinder = new WordFinder.Core.WordFinder(matrix);

        var result = wordFinder.Find(wordStream);

        Assert.Equal(3, result.Count());
        Assert.Contains("abcd", result);
        Assert.Contains("mnop", result);
        Assert.Contains("ijkl", result);
    }
}