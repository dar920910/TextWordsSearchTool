namespace TextWordsSearch.Library
{
	public class TextViewer
	{
		private readonly string _FilePath;

		private readonly StreamWriter _LogWriter;

		public TextViewer(string dataTextFilePath)
		{
			_LogWriter = new StreamWriter(Path.Combine(Directory.GetCurrentDirectory(), "text_viewer.log"));

			if (File.Exists(dataTextFilePath))
			{
				_LogWriter.WriteLine($"[{DateTime.Now}] SUCCESS: File {dataTextFilePath} was successfully detected.");
				_FilePath = dataTextFilePath;
			}
			else
			{
				_LogWriter.WriteLine($"[{DateTime.Now}] ERROR: File {dataTextFilePath} was not detected!");
			}
		}

		~TextViewer()
		{
			_LogWriter.Close();
		}

		public void ReadFileContent()
		{
			_LogWriter.WriteLine($"[{DateTime.Now}] INFO: Start reading data from the text file ...");
			string[] dataStringsFromTextFile = File.ReadAllLines(_FilePath);
			OutputAllDataFromTextFile(dataStringsFromTextFile);

			string[] detectedTextWords = FindAllTextWords(dataStringsFromTextFile);
			OutputDetectedWords(detectedTextWords);

			(string Value, int Count) resultSuperWord = FindSuperWord(detectedTextWords);
			OutputSuperWord(resultSuperWord);
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
				'(', ')', '{', '}', '[', ']'
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


		private void OutputAllDataFromTextFile(string[] dataStringsFromTextFile)
		{
			_LogWriter.WriteLine(GetOutputTextDelimiter());
			_LogWriter.WriteLine($"\n[{DateTime.Now}] INFO: Text Data from the Loaded File:\n");

			foreach (string dataString in dataStringsFromTextFile)
			{
				_LogWriter.WriteLine(dataString);
			}
		}

		private void OutputDetectedWords(string[] detectedTextWords)
		{
			_LogWriter.WriteLine(GetOutputTextDelimiter());
			_LogWriter.WriteLine($"\n[{DateTime.Now}] INFO: Detected Text Words in the Loaded File:\n");

			for (int i = 0; i < detectedTextWords.Length; i++)
			{
				_LogWriter.WriteLine($"   i = {i}: {detectedTextWords[i]}");
			}

			_LogWriter.WriteLine();
		}

		private void OutputSuperWord((string Value, int Count) super)
		{
			_LogWriter.WriteLine(GetOutputTextDelimiter());
			_LogWriter.WriteLine($"\n[{DateTime.Now}] INFO: SuperWord: '{super.Value}' | Count: {super.Count}.\n");
		}

		private static string GetOutputTextDelimiter()
		{
			const byte delimiterSize = 100;
			const char delimiterChar = '=';

			return new string(delimiterChar, delimiterSize);
		}
	}
}
