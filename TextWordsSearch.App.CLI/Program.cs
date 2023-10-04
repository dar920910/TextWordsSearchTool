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

        TextViewer textViewer = new (customTextFile);
        textViewer.ReadFileContent();
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
