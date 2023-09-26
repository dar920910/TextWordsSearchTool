//-----------------------------------------------------------------------
// <copyright file="TextViewer.cs" company="Demo Projects Workshop">
//     Copyright (c) Demo Projects Workshop. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

#pragma warning disable SA1600 // ElementsMustBeDocumented

namespace TextWordsSearch.Library;

public class TextViewer
{
    private readonly string textFilePath;
    private readonly StreamWriter writer;

    public TextViewer(string dataTextFilePath)
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
    }

    public void ReadFileContent()
    {
        this.writer.WriteLine($"[{DateTime.Now}] INFO: Start reading data from the text file ...");
        string[] dataStringsFromTextFile = File.ReadAllLines(this.textFilePath);
        this.OutputAllDataFromTextFile(dataStringsFromTextFile);

        string[] detectedTextWords = FindAllTextWords(dataStringsFromTextFile);
        this.OutputDetectedWords(detectedTextWords);

        (string Value, int Count) resultSuperWord = FindSuperWord(detectedTextWords);
        this.OutputSuperWord(resultSuperWord);
        this.writer.Close();
    }

    private static string[] FindAllTextWords(string[] dataStringsFromTextFile)
    {
        string result = string.Empty;

        foreach (string dataString in dataStringsFromTextFile)
        {
            result += GetSubstringWithTextWords(dataString);
        }

        return result.Split('\n');
    }

    private static string GetSubstringWithTextWords(string subString)
    {
        char[] targetSymbols =
        {
                '.', ',', ':', ';',
                '!', '?', '%', '$',
                '#', '@', '&', '~',
                '*', '/', '+', '/',
                '\\', '|', '^', '"', '\'',
                '(', ')', '{', '}', '[', ']',
        };

        foreach (var symbol in targetSymbols)
        {
            subString = subString.Replace(symbol, '\0');
        }

        if (subString.Contains('\x0020'))
        {
            subString = subString.Replace('\x0020', '\n');
        }

        return subString;
    }

    private static (string Value, int Count) FindSuperWord(string[] detectedTextWords)
    {
        string superWordValue = string.Empty;
        int superWordCount = 0;

        int[] wordsNumbers = new int[detectedTextWords.Length];

        for (int i = 0; i < detectedTextWords.Length; i++)
        {
            int currentWordCount = 0;

            foreach (var word in detectedTextWords)
            {
                if (word.Equals(detectedTextWords[i]))
                {
                    currentWordCount++;
                }
            }

            wordsNumbers[i] = currentWordCount;

            if (currentWordCount > superWordCount)
            {
                superWordValue = detectedTextWords[i].ToUpper();
                superWordCount = currentWordCount;
            }
        }

        return (Value: superWordValue, Count: superWordCount);
    }

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
