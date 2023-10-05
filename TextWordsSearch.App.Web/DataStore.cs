//-----------------------------------------------------------------------
// <copyright file="DataStore.cs" company="Demo Projects Workshop">
//     Copyright (c) Demo Projects Workshop. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

#pragma warning disable SA1600 // ElementsMustBeDocumented

using TextWordsSearch.Library;

public class DataStore
{
    private readonly string targetFilePath;

    static DataStore()
    {
        WordsOrderedByAscending = new ();
        WordsOrderedByDescending = new ();
    }

    private DataStore(string customFilePath)
    {
        this.targetFilePath = customFilePath;

        this.ContentStringsFromTextFile = File.ReadAllLines(this.targetFilePath);
        this.ContentViewer = new TextWordsViewer(this.targetFilePath);
    }

    public static DataStore? CurrentInstance { get; private set; }

    public static List<KeyValuePair<uint, List<string>>> WordsOrderedByAscending { get; private set; }

    public static List<KeyValuePair<uint, List<string>>> WordsOrderedByDescending { get; private set; }

    public static KeyValuePair<uint, List<string>> MinimumWordsCountInfo { get; private set; }

    public static KeyValuePair<uint, List<string>> MaximumWordsCountInfo { get; private set; }

    public string[] ContentStringsFromTextFile { get; }

    public TextWordsViewer ContentViewer { get; }

    public static void Create(string customFilePath)
    {
        CurrentInstance = new DataStore(customFilePath);

        WordsOrderedByAscending = CurrentInstance.ContentViewer.TextWordsOrderedByAscending;
        WordsOrderedByDescending = CurrentInstance.ContentViewer.TextWordsOrderedByDescending;

        MinimumWordsCountInfo = WordsOrderedByAscending.First();
        MaximumWordsCountInfo = WordsOrderedByDescending.First();
    }
}
