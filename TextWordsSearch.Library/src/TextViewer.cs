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

			string[] arrTextLoremIpsum = new FileScanner().ReadText_LoremIpsum(_FilePath);

			FileResult.OutputTextLoremIpsum(arrTextLoremIpsum);

			string[] arrWordsLoremIpsum = new WordConstructor().WordFinder(arrTextLoremIpsum);

			SuperWord resultSuperWord = new WordCalculator().CalculateSuperWord(arrWordsLoremIpsum);

			FileResult.OutputSuperWord(resultSuperWord);
		}
	}


	/// <summary>
	/// dar920910: Класс FileScanner представляет собой реализацию устройства,
	/// обеспечивающего обработку целевого текстового файла.
	/// </summary>
	public class FileScanner
	{
		/// <summary>
		/// dar920910: Метод ReadText_LoremIpsum() выполняет поиск и чтение
		/// целевого текстового файла, содержащего текст-"рыбу" Lorem Ipsum. 
		/// </summary>
		/// <param name="fileLoremIpsum">Путь к целевому файлу, содержащему текст-"рыбу"
		/// Lorem Ipsum.</param>
		/// <returns>Метод возвращает строковый массив, содержащий данные,
		/// прочитанные из целевого файла.</returns>
		public string[] ReadText_LoremIpsum(string fileLoremIpsum)
		{
			/* Чтение целевого файла:
			 * 1. Объявление строкового массива strTextLoremIpsum для сохранения
			 * считываемых данных.
			 * 2. Вызов метода ReadAllLines() с аргументом, представляющим
			 * собой имя целевого файла.
			 * 3. Инициализация массива strTextLoremIpsum возвращаемым значением,
			 * полученным при вызове метода ReadAllLines().
			 */ 
			
			string[] strTextLoremIpsum = File.ReadAllLines(fileLoremIpsum);

			return strTextLoremIpsum;
		}
	}


	/// <summary>
	/// dar920910: Класс FileResult выполняет функции вывода результатов
	/// произведенных вычислений во время выполнения программы.
	/// </summary>
	public class FileResult
	{
		/// <summary>
		/// dar920910: Метод OutputTextLoremIpsum() создан для вывода 
		/// проверки прочитанных данных в консоль:
		/// </summary>
		/// <param name="destArrStringText">Целевой массив строк текста</param>
		public static void OutputTextLoremIpsum(string[] destArrStringText)
		{
			OutputTestLine();

			Console.WriteLine("\nВыводим исходный текст Lorem Ipsum, прочитанный программой:\n\n\n");

			foreach (var strText in destArrStringText)
			{
				Console.WriteLine(strText);
			}
		}

		/// <summary>
		/// dar920910: Метод OutputWords() создан для вывода 
		/// массива слов в консоль:
		/// </summary>
		/// <param name="destArrStringText">Массив слов, предназначенный для вывода</param>
		public static void OutputWords(string[] destArrWords)
		{
			OutputTestLine();

			Console.WriteLine("\nВыводим каждый элемент массива слов исходного текста Lorem Ipsum:\n\n\n");

			for (int i = 0; i < destArrWords.Length; i++)
			{
				Console.WriteLine("   i = " + i + " : " + "res[i] = " + destArrWords[i]);
			}

			Console.WriteLine();
		}

		/// <summary>
		/// dar920910: Метод OutputCountWords() создан для вывода в консоль информации о
		/// количестве каждого слова в тексте:
		/// </summary>
		/// <param name="destWord">Массив слов</param>
		/// <param name="destCount">Массив количества вхождений каждого слова</param>
		public static void OutputCountWords(string[] destArrWords, int[] destCount)
		{
			OutputTestLine();

			Console.WriteLine("\nВыводим каждый элемент массива слов и количество его вхождений в исходном тексте:\n\n\n");

			// Выполняем циклический обход каждого элемента массива слов:

			for(int i = 0; i < destArrWords.Length; i++)
			{			
				// Вывод текущего слова, преобразованного в верхний регистр (согласно заданию):
				Console.WriteLine(" Слово: " + destArrWords[i].ToUpper());
				// Вывод количества вхождений данного слова в тексте, вычисленного в вызывающем коде:
				Console.WriteLine("   Количество вхождений: встречается ровно " + destCount[i] + " раз в тексте.\n");
			}
			
		}

		/// <summary>
		/// dar920910: Метод OutputSuperWord() создан для вывода в консоль "супер-слова":
		/// </summary>
		/// <param name="super">Структура, содержащая поля описания "супер-слова"</param>
		public static void OutputSuperWord(SuperWord super)
		{
			OutputTestLine();

			// Результирующий вывод "супер-слова" и его рекордного количества вхождений в тексте:
			Console.WriteLine("\nСамое частое слово в тексте: " + super.curWord + ". Это слово встречается " + super.curCount + " раз.\n");
		}

		/// <summary>
		/// dar920910: Метод OutputTestLine() выводит в окне консоли тестовый разделитель
		/// в целях улучшения наглядности выводимой информации.
		/// </summary>
		private static void OutputTestLine()
		{
			int test = 100; // величина тестового разделителя
			char ch = '='; // символ тестового разделителя

			Console.WriteLine();

			for (int i = 0; i < test; i++)
				Console.Write(ch);

			Console.WriteLine();
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
			 * ПРИМЕЧАНИЕ для работодателя:
			 * 
			 * В реальном проекте мой выбор остановился бы на регулярных выражениях Regex.
			 * Однако пока что я редко ими пользуюсь, поэтому предпочел более примитивный способ.
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

			// Вывод в консоль массива слов:
			FileResult.OutputWords(res);

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

			// Вывод текущего слова и количества его вхождений в текст:
			FileResult.OutputCountWords(arrWords, arrCount);
			
			return currentSuperWord;
		}
	}
}
