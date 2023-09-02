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
