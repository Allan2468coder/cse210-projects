using System;
using System.Text;

public class Word
{
    private string _text;
    private bool _isHidden;

    public Word(string text)
    {
        _text = text;
        _isHidden = false;
    }

    public bool IsHidden => _isHidden;
    public string Text => _text;

    public void Hide()
    {
        _isHidden = true;
    }

    public string GetDisplayText()
    {
        if (!_isHidden)
        {
            return _text;
        }

        var builder = new StringBuilder();
        foreach (char c in _text)
        {
            builder.Append(char.IsLetter(c) ? '_' : c);
        }

        return builder.ToString();
    }

    public override string ToString()
    {
        return GetDisplayText();
    }
}
