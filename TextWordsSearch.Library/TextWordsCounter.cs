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

    public static List<KeyValuePair<uint, List<string>>> GetSortedWordsByAscending(Dictionary<string, uint> words)
    {
        Dictionary<uint, List<string>> wordsCountDictionary = CreateWordsCountDictionary(words);

        IOrderedEnumerable<KeyValuePair<uint, List<string>>> orderedWords =
            OrderWordsCountDictionaryByAscending(wordsCountDictionary);

        return orderedWords.ToList();
    }

    public static List<KeyValuePair<uint, List<string>>> GetSortedWordsByDescending(Dictionary<string, uint> words)
    {
        Dictionary<uint, List<string>> wordsCountDictionary = CreateWordsCountDictionary(words);

        IOrderedEnumerable<KeyValuePair<uint, List<string>>> orderedWords =
            OrderWordsCountDictionaryByDescending(wordsCountDictionary);

        return orderedWords.ToList();
    }

    private static Dictionary<uint, List<string>> CreateWordsCountDictionary(Dictionary<string, uint> words)
    {
        Dictionary<uint, List<string>> wordsCountDictionary = new ();

        foreach (string currentWord in words.Keys)
        {
            uint currentWordCount = words[currentWord];

            if (wordsCountDictionary.ContainsKey(currentWordCount))
            {
                wordsCountDictionary[currentWordCount].Add(currentWord);
            }
            else
            {
                wordsCountDictionary.Add(key: currentWordCount, value: new () { currentWord });
            }
        }

        return wordsCountDictionary;
    }

    private static IOrderedEnumerable<KeyValuePair<uint, List<string>>> OrderWordsCountDictionaryByAscending(
        Dictionary<uint, List<string>> wordsCountDictionary)
    {
        IOrderedEnumerable<KeyValuePair<uint, List<string>>> orderedWords =
            wordsCountDictionary.OrderBy(key => key.Key);

        foreach (KeyValuePair<uint, List<string>> pair in orderedWords)
        {
            pair.Value.Sort();
        }

        return orderedWords;
    }

    private static IOrderedEnumerable<KeyValuePair<uint, List<string>>> OrderWordsCountDictionaryByDescending(
        Dictionary<uint, List<string>> wordsCountDictionary)
    {
        IOrderedEnumerable<KeyValuePair<uint, List<string>>> orderedWords =
            wordsCountDictionary.OrderByDescending(key => key.Key);

        foreach (KeyValuePair<uint, List<string>> pair in orderedWords)
        {
            pair.Value.Sort();
            pair.Value.Reverse();
        }

        return orderedWords;
    }
}
