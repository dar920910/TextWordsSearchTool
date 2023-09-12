using TextWordsSearch.Library;

string customTextFile = Path.Combine(
    Directory.GetCurrentDirectory(), "TestDataExamples", "test_loremipsum.txt");

TextViewer textViewer = new(customTextFile);
textViewer.ReadFileContent();
