//-----------------------------------------------------------------------
// <copyright file="Program.cs" company="Demo Projects Workshop">
//     Copyright (c) Demo Projects Workshop. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using TextWordsSearch.Library;

try
{
    string customTextFile = args[0];

    if (File.Exists(customTextFile))
    {
        Console.WriteLine($"[INFO] Detected the custom file: {customTextFile}");

        TextWordsViewer viewer = new (customTextFile);
        ConsoleKeyInfo selectionKeyInfo = ReadCustomSelectionKey();
        ExecuteAnalysisTextContent(selectionKeyInfo, viewer);
    }
    else
    {
        Console.WriteLine($"[ERROR] Cannot detect the custom file: {customTextFile}");
    }
}
catch (IndexOutOfRangeException)
{
    Console.WriteLine($"[ERROR] You should pass a custom text file as the one argument to the program.");
}

ConsoleKeyInfo ReadCustomSelectionKey()
{
    Console.WriteLine("Select an action to analyze the content of this text file:");
    Console.WriteLine("-) 'A' - Show text words with the maximum entry count in this text file");
    Console.WriteLine("-) 'B' - Show text words with the minimum entry count in this text file");
    Console.WriteLine("-) 'C' - Show all detected text words ordered by ascending");
    Console.WriteLine("-) 'D' - Show all detected text words ordered by descending");

    ConsoleKey[] possibleKeys = new[]
    {
        ConsoleKey.A,
        ConsoleKey.B,
        ConsoleKey.C,
        ConsoleKey.D,
    };

    return ReadSelectionKey(possibleKeys);
}

ConsoleKeyInfo ReadSelectionKey(ConsoleKey[] availableKeys)
{
    do
    {
        Console.Write("Press a selection key: ");
        ConsoleKeyInfo userKey = Console.ReadKey();
        Console.WriteLine();

        if (availableKeys.Contains(userKey.Key))
        {
            return userKey;
        }
        else
        {
            Console.WriteLine("ERROR! Please select a possible key!");
        }
    }
    while (true);
}

void ExecuteAnalysisTextContent(ConsoleKeyInfo actionSelectionKeyInfo, TextWordsViewer viewer)
{
    switch (actionSelectionKeyInfo.Key)
    {
        case ConsoleKey.A:
            ShowWordsWithMaximumEntryCount(viewer);
            break;
        case ConsoleKey.B:
            ShowWordsWithMinimumEntryCount(viewer);
            break;
        case ConsoleKey.C:
            ShowDetectedWordsWithEntryCountOrderedByAscending(viewer);
            break;
        case ConsoleKey.D:
            ShowDetectedWordsWithEntryCountOrderedByDescending(viewer);
            break;
        default:
            break;
    }
}

void ShowWordsWithMaximumEntryCount(TextWordsViewer viewer)
{
    KeyValuePair<uint, List<string>> wordsWithCount = viewer.WordsWithMaximumEntryCount;
    PrintWordsWithEntryCount(wordsWithCount, "Maximum Count of Words");
}

void ShowWordsWithMinimumEntryCount(TextWordsViewer viewer)
{
    KeyValuePair<uint, List<string>> wordsWithCount = viewer.WordsWithMinimumEntryCount;
    PrintWordsWithEntryCount(wordsWithCount, "Minimum Count of Words");
}

void ShowDetectedWordsWithEntryCountOrderedByAscending(TextWordsViewer viewer)
{
    List<KeyValuePair<uint, List<string>>> detectedWords = viewer.TextWordsOrderedByAscending;
    PrintDetectedWordsWithEntryCount(detectedWords, "Detected Text Words Ordered By Ascending");
}

void ShowDetectedWordsWithEntryCountOrderedByDescending(TextWordsViewer viewer)
{
    List<KeyValuePair<uint, List<string>>> detectedWords = viewer.TextWordsOrderedByDescending;
    PrintDetectedWordsWithEntryCount(detectedWords, "Detected Text Words Ordered By Descending");
}

static void PrintWordsWithEntryCount(KeyValuePair<uint, List<string>> wordsWithCount, string message)
{
    Console.WriteLine($"{message}: {wordsWithCount.Key} times in this text file.");
    Console.WriteLine($"These text words are following:");

    foreach (string word in wordsWithCount.Value)
    {
        Console.WriteLine(word);
    }

    Console.WriteLine();
}

static void PrintDetectedWordsWithEntryCount(List<KeyValuePair<uint, List<string>>> detectedWords, string message)
{
    Console.WriteLine($"{message}:");
    Console.WriteLine();

    foreach (KeyValuePair<uint, List<string>> pair in detectedWords)
    {
        Console.Write($"EntryCount = {pair.Key}: ");

        foreach (string word in pair.Value)
        {
            Console.Write($"'{word}', ");
        }

        Console.WriteLine();
    }

    Console.WriteLine();
}
