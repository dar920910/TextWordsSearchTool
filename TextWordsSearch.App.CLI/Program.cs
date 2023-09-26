//-----------------------------------------------------------------------
// <copyright file="Program.cs" company="Demo Projects Workshop">
//     Copyright (c) Demo Projects Workshop. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using TextWordsSearch.Library;

string customTextFile = Path.Combine(
    Directory.GetCurrentDirectory(), "TestDataExamples", "test_loremipsum.txt");

TextViewer textViewer = new (customTextFile);
textViewer.ReadFileContent();
