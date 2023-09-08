namespace TextWordsSearch.Library
{
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
			
			return currentSuperWord; // возвращаем найденное "супер-слово" в вызывающий код
		}
	}
}
