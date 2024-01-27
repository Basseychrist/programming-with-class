using System;
using System.Collections.Generic;
using System.Linq;

class Scripture
{
    private string reference;
    private List<Word> words;

    public Scripture(string reference, string text)
    {
        this.reference = reference;
        this.words = text.Split(' ').Select(word => new Word(word)).ToList();
    }

    public string GetFullScripture()
    {
        return $"{reference}\n{string.Join(" ", words.Select(word => word.Text))}";
    }

    public string GetVisibleScripture()
    {
        return $"{reference}\n{string.Join(" ", words.Select(word => word.Visible ? word.Text : new string('_', word.Text.Length)))}";
    }

    public void HideRandomWords()
    {
        Random random = new Random();
        int wordsToHide = random.Next(1, words.Count(word => word.Visible));

        foreach (Word word in words.Where(word => word.Visible).OrderBy(_ => random.Next()).Take(wordsToHide))
        {
            word.Hide();
        }
    }

    public bool AllWordsHidden()
    {
        return words.All(word => !word.Visible);
    }
}
