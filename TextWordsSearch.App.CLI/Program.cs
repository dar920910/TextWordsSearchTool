using TextWordsSearch.Library;
using static System.Console;

WriteLine("Input a Text String with Space Separators:");
string text = ReadLine();

Write("Input a Target Word to Count in the Text: ");
string word = ReadLine();

uint count = TextWordsCounter.GetWordCountInText(word, text);

WriteLine($"This text contains {count} entries of the '{word}' word.");
