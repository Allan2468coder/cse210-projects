using System;
using System.Collections.Generic;
using System.Linq;

public class Scripture
{
    private Reference _reference;
    private List<Word> _words;
    private Random _random;

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = ParseWords(text);
        _random = new Random();
    }

    public string ReferenceText => _reference.ToString();

    public bool IsFullyHidden => _words.All(word => word.IsHidden);

    public string GetRenderedText()
    {
        return string.Join(" ", _words.Select(word => word.GetDisplayText()));
    }

    public void HideRandomWords()
    {
        var visibleWords = _words.Where(word => !word.IsHidden).ToList();
        if (!visibleWords.Any())
        {
            return;
        }

        var hideCount = Math.Min(_random.Next(1, 4), visibleWords.Count);
        var selectedIndexes = new HashSet<int>();

        while (selectedIndexes.Count < hideCount)
        {
            selectedIndexes.Add(_random.Next(visibleWords.Count));
        }

        foreach (var selectedIndex in selectedIndexes)
        {
            visibleWords[selectedIndex].Hide();
        }
    }

    private List<Word> ParseWords(string text)
    {
        return text.Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .Select(token => new Word(token))
            .ToList();
    }
}
