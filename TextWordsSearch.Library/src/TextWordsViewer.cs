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
        this.detectedTextWords = TextWordsCounter.GetWordsDictionaryFromWordsArray(currentTextWords);

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

    private void OutputAllDataFromTextFile(string[] dataStringsFromTextFile)
    {
        this.writer.WriteLine(GetOutputTextDelimiter());
        this.writer.WriteLine($"\n[{DateTime.Now}] INFO: Text Data from the Loaded File:\n");

        foreach (string dataString in dataStringsFromTextFile)
        {
            this.writer.WriteLine(dataString);
        }
    }

    private void OutputDetectedWords(string[] detectedTextWords)
    {
        this.writer.WriteLine(GetOutputTextDelimiter());
        this.writer.WriteLine($"\n[{DateTime.Now}] INFO: Detected Text Words in the Loaded File:\n");

        for (int i = 0; i < detectedTextWords.Length; i++)
        {
            this.writer.WriteLine($"   i = {i}: {detectedTextWords[i]}");
        }

        this.writer.WriteLine();
    }

    private void OutputSuperWord((string Value, int Count) super)
    {
        this.writer.WriteLine(GetOutputTextDelimiter());
        string outputResult = $"\n[{DateTime.Now}] INFO: SuperWord: '{super.Value}' | Count: {super.Count}.\n";
        this.writer.WriteLine(outputResult);
    }
}
