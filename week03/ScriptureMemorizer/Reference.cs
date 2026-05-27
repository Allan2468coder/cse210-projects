using System;

public class Reference
{
    private string _book;
    private int _chapter;
    private int _startVerse;
    private int _endVerse;

    public Reference(string book, int chapter, int verse)
        : this(book, chapter, verse, verse)
    {
    }

    public Reference(string book, int chapter, int startVerse, int endVerse)
    {
        _book = book;
        _chapter = chapter;
        _startVerse = startVerse;
        _endVerse = endVerse;
    }

    public static Reference Parse(string referenceText)
    {
        if (string.IsNullOrWhiteSpace(referenceText))
        {
            throw new ArgumentException("Reference text cannot be empty.", nameof(referenceText));
        }

        var trimmedText = referenceText.Trim();
        var lastSpace = trimmedText.LastIndexOf(' ');
        if (lastSpace <= 0)
        {
            throw new FormatException("Reference must contain a book name and chapter/verse.");
        }

        var book = trimmedText.Substring(0, lastSpace);
        var chapterAndVerses = trimmedText.Substring(lastSpace + 1);
        var chapterParts = chapterAndVerses.Split(':');
        if (chapterParts.Length != 2)
        {
            throw new FormatException("Reference must be formatted as Book Chapter:Verse or Book Chapter:Start-End.");
        }

        if (!int.TryParse(chapterParts[0], out var chapter))
        {
            throw new FormatException("Chapter must be a valid integer.");
        }

        var verseRange = chapterParts[1].Split('-');
        if (verseRange.Length == 1)
        {
            if (!int.TryParse(verseRange[0], out var verse))
            {
                throw new FormatException("Verse must be a valid integer.");
            }

            return new Reference(book, chapter, verse);
        }

        if (verseRange.Length == 2
            && int.TryParse(verseRange[0], out var startVerse)
            && int.TryParse(verseRange[1], out var endVerse))
        {
            return new Reference(book, chapter, startVerse, endVerse);
        }

        throw new FormatException("Verse range must be in the format Start-End.");
    }

    public override string ToString()
    {
        if (_startVerse == _endVerse)
        {
            return $"{_book} {_chapter}:{_startVerse}";
        }

        return $"{_book} {_chapter}:{_startVerse}-{_endVerse}";
    }
}
