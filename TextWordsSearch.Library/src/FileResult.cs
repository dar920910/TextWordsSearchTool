namespace TextWordsSearch.Library
{
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
			OutputTestLine(); // выводим разделитель

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
			OutputTestLine(); // выводим разделитель

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
			OutputTestLine(); // выводим разделитель

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
			OutputTestLine(); // выводим разделитель

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
}
