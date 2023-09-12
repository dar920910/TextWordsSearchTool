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
			OutputWords(detectedTextWords);

			SuperWord resultSuperWord = new WordCalculator().CalculateSuperWord(detectedTextWords);
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


		private void OutputAllDataFromTextFile(string[] dataStringsFromTextFile)
		{
			_LogWriter.WriteLine(GetOutputTextDelimiter());
			_LogWriter.WriteLine($"\n[{DateTime.Now}] INFO: Text Data from the Loaded File:\n");

			foreach (string dataString in dataStringsFromTextFile)
			{
				_LogWriter.WriteLine(dataString);
			}
		}

		private void OutputWords(string[] detectedTextWords)
		{
			_LogWriter.WriteLine(GetOutputTextDelimiter());
			_LogWriter.WriteLine($"\n[{DateTime.Now}] INFO: Detected Text Words in the Loaded File:\n");

			for (int i = 0; i < detectedTextWords.Length; i++)
			{
				_LogWriter.WriteLine($"   i = {i}: {detectedTextWords[i]}");
			}

			_LogWriter.WriteLine();
		}

		private void OutputCountWords(string[] detectedTextWords, int[] detectedTextWordsCount)
		{
			_LogWriter.WriteLine(GetOutputTextDelimiter());
			_LogWriter.WriteLine($"\n[{DateTime.Now}] INFO: Count of Text Words from the Loaded File:\n");

			for(int i = 0; i < detectedTextWords.Length; i++)
			{
				_LogWriter.WriteLine($"   Word: {detectedTextWords[i].ToUpper()} | Count: {detectedTextWordsCount[i]}");
			}
		}

		private void OutputSuperWord(SuperWord super)
		{
			_LogWriter.WriteLine(GetOutputTextDelimiter());
			_LogWriter.WriteLine($"\n[{DateTime.Now}] INFO: SuperWord: '{super.curWord}' | Count: {super.curCount}.\n");
		}

		private static string GetOutputTextDelimiter()
		{
			const byte delimiterSize = 100;
			const char delimiterChar = '=';

			return new string(delimiterChar, delimiterSize);
		}
	}


	/// <summary>
	/// dar920910: Структура, содержащая название и количество вхождений "супер-слова".
	/// </summary>
	public struct SuperWord
	{
		public string curWord; // название "супер-слова"
		public int curCount; // количество вхождений "супер-слова"
	}

	/// <summary>
	/// dar920910: Класс WordCalculator содержит алгоритмы, предназначенные для подсчета
	/// найденных слов в целевом текстовом файле.
	/// </summary>
	public class WordCalculator
	{
		// Объявляем переменную типа структуры SuperWord для хранения "супер-слова":
		SuperWord currentSuperWord;

		/// <summary>
		/// dar920910: Переопределенный конструктор класса WordCalculator,
		/// выполняющий инициализацию полей структуры, в которую будет сохранен результат.
		/// </summary>
		public WordCalculator()
		{
			// Инициализируем поля структуры currentSuperWord значениями по умолчанию:

			currentSuperWord.curWord = string.Empty;
			currentSuperWord.curCount = 0;
		}

		/// <summary>
		/// dar920910: Метод CalculateSuperWord() принимает в качестве аргумента массив слов
		/// целевого текста и возвращает самое часто встречающееся слово в этом массиве.
		/// </summary>
		/// <param name="arrWords">Целевой массив, состоящий из слов.</param>
		/// <returns>Метод возвращает самое часто встречающееся слово в разбираемом
		/// массиве слов.</returns>
		public SuperWord CalculateSuperWord(string[] arrWords)
		{		
			// Объявляем целочисленный массив размерностью массива слов
			// Этот массив будет хранить информацию о количестве вхождений слов в тексте.
			int[] arrCount = new int[arrWords.Length];

			// Алгоритм подсчета, циклический обход массива слов, принимаемого параметром метода arrWords:

			for (int i = 0; i < arrWords.Length; i++)
			{
				// Локальная переменная, используемая для подсчета числа вхождений текущего слова в массиве слов:
				int count = 0; // инициализируем count нулем
				
				// Запускаем внутренний цикл для поиска одинаковых слов в массиве слов:
				foreach (var word in arrWords)
				{
					// Текущее слово эквивалентно проверяемому ?

					//if (word == arrWords[i]) // более простой и понятный вариант
					if (word.Equals(arrWords[i])) // более корректный вариант
						count++; // инкрементируем count, ведь найдено еще одно вхождение слова!
				}

				// Инициализируем текущий элемент массива arrCount только что вычисленным значением: count:
				arrCount[i] = count;

				// Заключительная проверка:
				// Количество вхождений count текущего слова больше, чем текущее значение поля curCount структуры currentSuperWord ?
				if (count > currentSuperWord.curCount)
				{
					// Присваиваем значения полям структуры currentSuperWord:

					// Определение количества вхождений часто встречающегося слова:
					currentSuperWord.curCount = count; // похоже, что count достойно зваться "супер-словом" ...
					// Определение самого часто встречающегося слова (преобразуем к верхнему регистру согласно заданию):
					currentSuperWord.curWord = arrWords[i].ToUpper(); // текущее слово становится обладателем титула "супер-слово"!!!
				}
			}

			return currentSuperWord;
		}
	}
}
