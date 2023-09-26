//-----------------------------------------------------------------------
// <copyright file="TextWordsCounter.cs" company="Demo Projects Workshop">
//     Copyright (c) Demo Projects Workshop. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

#pragma warning disable SA1600 // ElementsMustBeDocumented

namespace TextWordsSearch.Library;

public static class TextWordsCounter
{
    public static uint GetWordCountInText(string word, string text)
    {
        // Start implementation - use only strings separated by spaces.
        string[] words = text.Split(' ');

        uint count = 0;
        foreach (string elem in words)
        {
            if (elem.Equals(word))
            {
                count++;
            }
        }

        return count;
    }
}
