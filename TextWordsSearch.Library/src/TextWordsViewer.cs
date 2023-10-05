//-----------------------------------------------------------------------
// <copyright file="TextWordsViewer.cs" company="Demo Projects Workshop">
//     Copyright (c) Demo Projects Workshop. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

#pragma warning disable SA1600 // ElementsMustBeDocumented

namespace TextWordsSearch.Library;

public class TextWordsViewer
{
    private readonly string textFilePath;
    private readonly StreamWriter writer;
    private readonly Dictionary<string, uint> detectedTextWords;

    public TextWordsViewer(string dataTextFilePath)
    {
        this.writer = new StreamWriter(
            Path.Combine(Directory.GetCurrentDirectory(), $"results.log"));

        if (File.Exists(dataTextFilePath))
        {
            this.writer.WriteLine($"[{DateTime.Now}] SUCCESS: File {dataTextFilePath} was successfully detected.");
            this.textFilePath = dataTextFilePath;
        }
        else
        {
            this.writer.WriteLine($"[{DateTime.Now}] ERROR: File {dataTextFilePath} was not detected!");
        }

        this.writer.WriteLine($"[{DateTime.Now}] INFO: Start reading data from the text file ...");

        string currentTextFileContent = File.ReadAllText(this.textFilePath);

        string[] currentTextWords = TextWordsCounter.GetWordsArrayFromTextContent(currentTextFileContent);
        this.OutputDetectedWords(currentTextWords);

        this.detectedTextWords = TextWordsCounter.GetWordsDictionaryFromWordsArray(currentTextWords);
        this.OutputDetectedWords(this.detectedTextWords);

        this.writer.Close();
    }

    public KeyValuePair<uint, List<string>> WordsWithMaximumEntryCount =>
        TextWordsCounter.GetInfoAboutMaximumEntryCountOfWordsInText(this.detectedTextWords);

    public KeyValuePair<uint, List<string>> WordsWithMinimumEntryCount =>
        TextWordsCounter.GetInfoAboutMinimumEntryCountOfWordsInText(this.detectedTextWords);

    public List<KeyValuePair<uint, List<string>>> TextWordsOrderedByAscending =>
        TextWordsCounter.GetSortedWordsByAscending(this.detectedTextWords);

    public List<KeyValuePair<uint, List<string>>> TextWordsOrderedByDescending =>
        TextWordsCounter.GetSortedWordsByDescending(this.detectedTextWords);

    private static string GetOutputTextDelimiter()
    {
        const byte delimiterSize = 100;
        const char delimiterChar = '=';
        return new string(delimiterChar, delimiterSize);
    }

    private void OutputDetectedWords(string[] words)
    {
        this.writer.WriteLine(GetOutputTextDelimiter());
        this.writer.WriteLine($"\n[{DateTime.Now}] INFO: Output for the Array of Detected Text Words...\n");

        for (int number = 0; number < words.Length; number++)
        {
            this.writer.WriteLine($"   i = {number}: {words[number]}");
        }

        this.writer.WriteLine();
    }

    private void OutputDetectedWords(Dictionary<string, uint> words)
    {
        this.writer.WriteLine(GetOutputTextDelimiter());
        this.writer.WriteLine($"\n[{DateTime.Now}] INFO: Output for the Dictionary of Detected Text Words...\n");

        foreach (string word in words.Keys)
        {
            this.writer.WriteLine($"Word: '{word}' | Count: '{words[word]}'");
        }

        this.writer.WriteLine();
    }
}
