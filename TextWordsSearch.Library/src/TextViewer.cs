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

			string[] arrTextLoremIpsum = File.ReadAllLines(_FilePath);

			OutputAllDataFromTextFile(arrTextLoremIpsum);

			string[] arrWordsLoremIpsum = new WordConstructor().WordFinder(arrTextLoremIpsum);

			SuperWord resultSuperWord = new WordCalculator().CalculateSuperWord(arrWordsLoremIpsum);

			OutputSuperWord(resultSuperWord);
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
	/// dar920910: Класс WordConstructor выполняет роль устройства, которое
	/// занимается распознаванием слов в тексте.
	/// </summary>
	public class WordConstructor
	{
		/// <summary>
		/// dar920910: Метод WordFinder() принимает в качестве аргумента целевой массив,
		/// который впоследствии обрабатывается с целью поиска существующих слов в тексте.
		/// </summary>
		/// <param name="destStrArr">Целевой строковый массив для обработки</param>
		/// <returns>Метод возвращает строковый массив, состоящий из слов, обнаруженных
		/// в процессе обработки разбираемого целевого массива.</returns>
		public string[] WordFinder(string[] destStrArr)
		{
			// Объявляем строковую переменную для хранения слов:
			string result = string.Empty;

			// Объявляем тестовую целочисленную переменную для хранения количества символов: 
			// int sum = 0; // можно отключить

			// Выполняем циклический обход каждого элемента-строки в исходном строковом массиве:
			/* с целью преобразования каждой подстроки и создания результирующей строки найденных слов.
			 * 
			 * 1. Передаем подстроку destStrArr для обработки методу ToDoWordsV1()
			 * в качестве аргумента.
			 * 2. Осуществляем приращение результирующей строки result на величину
			 * преобразованной строки, которая является результатом обработки подстроки destStrArr,
			 * возвращенным при вызове метода ToDoWordsV1().
			 * 
			 */

			foreach (var destStr in destStrArr) result += ToDoWordsV1(destStr);

			/* Выполняем построение массива существующих слов:
			 * 
			 * 1. Объявляем строковый массив res, который будет содержать все слова в целевом тексте.
			 * 2. Разбиваем с помощью метода Split() текстовую строку result на подстроки,
			 * разделенные символом новой строки, с помощью чего мы получаем слова в подстроках.
			 * 3. Инициализируем массив res массивом подстрок, полученным при вызове метода Split().
			 * 
			 */

			string[] res = result.Split('\n');
			return res;
		}

		/// <summary>
		/// dar920910: Метод ToDoWordsV1() выполняет операции по замене символов
		/// в целевой строке, выполняя задачу получения массива слов из целевой строки.
		/// Это низкоуровневый метод.
		/// </summary>
		/// <param name="subString"></param>
		/// <returns></returns>
		private string ToDoWordsV1(string subString)
		{
			// Объявляем массив "запретных" символов и выполняем его инициализацию "запретными" символами.
			// "Запретные" символы - это символы, которые НЕ должны присутствовать в результирующем массиве слов.

			char[] symbols = 
			{
				'.', ',', ':', ';',
				'!', '?', '%', '$',
				'#', '@', '&', '~',
				'*', '/', '+', '/',
				'\\', '|', '^', '"', '\'',
				'(', ')', '{', '}', '[', ']'
			};

			/* Циклический обход массива запретных символов.
			 * Если обрабатываемая строка содержит "запретный" символ,
			 * мы просто выполняем замену этого символа на пустой символ.
			 */

			foreach (var symb in symbols)
			{
				subString = subString.Replace(symb, '\0');
			}

			// Проверка и замена всех пробелов на символы перевода строки:

			if (subString.Contains('\x0020'))
				subString = subString.Replace('\x0020', '\n');

			return subString;
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
