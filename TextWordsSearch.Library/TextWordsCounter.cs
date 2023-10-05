//-----------------------------------------------------------------------
// <copyright file="TextWordsCounter.cs" company="Demo Projects Workshop">
//     Copyright (c) Demo Projects Workshop. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

#pragma warning disable SA1600 // ElementsMustBeDocumented

namespace TextWordsSearch.Library;

public static class TextWordsCounter
{
    public static string[] GetWordsArrayFromTextContent(string textContent)
    {
        List<string> detectedWords = new ();
        List<char> wordCharacters = new ();

        CharEnumerator enumerator = textContent.GetEnumerator();
        while (enumerator.MoveNext())
        {
            char symbol = enumerator.Current;

            if (char.IsWhiteSpace(symbol) || char.IsPunctuation(symbol) || char.IsControl(symbol))
            {
                if (wordCharacters.Count != 0)
                {
                    string word = new (wordCharacters.ToArray());
                    detectedWords.Add(word);
                    wordCharacters.Clear();
                }
            }
            else
            {
               wordCharacters.Add(symbol);
            }
        }

        return detectedWords.ToArray();
    }

    public static Dictionary<string, uint> GetWordsDictionaryFromWordsArray(string[] words)
    {
        List<string> sourceWords = words.ToList();

        Dictionary<string, uint> uniqueWords = new ();

        for (int index = 0; index < sourceWords.Count; index++)
        {
            string word = sourceWords[index];

            if (uniqueWords.ContainsKey(word))
            {
                uniqueWords[word]++;
            }
            else
            {
                uniqueWords.Add(key: word, value: 1);
            }
        }

        return uniqueWords;
    }
}
