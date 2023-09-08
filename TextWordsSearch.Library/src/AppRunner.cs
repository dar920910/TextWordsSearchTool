namespace TextWordsSearch.Library
{
	public static class AppRunner
	{
		public static void Launch()
		{
			// Константа, используемая для обозначения имени целевого файла:
			const string FILE_DEST = "test_loremipsum.txt";

			if(File.Exists(FILE_DEST)) // целевой файл существует
			{
				Console.WriteLine("Целевой файл LoremIpsum был найден и успешно прочитан.\n\n");

				/* Алгоритм чтения целевого файла:
				 * 1. Создаем объект класса FileScanner.
				 * 2. Объявляем строковый массив arrTextLoremIpsum для сохранения прочитанных данных.
				 * 3. Читаем текст-"рыбу" Lorem Ipsum с помощью вызова метода ReadText_LoremIpsum(),
				 *  которому в качестве аргумента передаем константу FILE_DEST, содержащую имя
				 *  целевого файла.
				 * 4. Инициализируем массив arrTextLoremIpsum возвращаемым значением, полученным
				 * в результате вызова вышеуказанного метода.
				 */

				var testLoremIpsum = new FileScanner();
				string [] arrTextLoremIpsum = testLoremIpsum.ReadText_LoremIpsum(FILE_DEST);

				
				// Выводим в консоль прочитанный текст Lorem Ipsum:
				FileResult.OutputTextLoremIpsum(arrTextLoremIpsum);

				/* Алгоритм формирования списка слов в целевом файле:
				 * 1. Создаем объект класса WordConstructor.
				 * 2. Объявляем строковый массив arrWordsLoremIpsum для сохранения
				 * всех найденных слов в тексте Lorem Ipsum.
				 * 3. Относительно созданного экземпляра вызываем метод WordFinder(), 
				 * которому в качестве аргумента передаем массив строк arrTextLoremIpsum
				 * целевого текста, для поиска существующих слов в целевом файле.
				 * 4. Инициализируем массив arrWordsLoremIpsum возвращаемым значением, полученным
				 * в результате вызова вышеуказанного метода.
				 * 
				 */

				var testWordFinder = new WordConstructor();
				string[] arrWordsLoremIpsum = testWordFinder.WordFinder(arrTextLoremIpsum);

				/* Алгоритм подсчета слов и определения "супер-слова" в целевом массиве слов:
				 * 
				 * 1. Создаем объект класса WordCalculator.
				 * 2. Объявляем переменную resultSuperWord типа структуры SuperWord для хранения "супер-слова".
				 * 3. Относительно созданного экземпляра вызываем метод WordCalculator(), 
				 * которому в качестве аргумента передаем массив слов arrWordsLoremIpsum
				 * целевого текста, для подсчета слов и определения "супер-слова" в целевом файле.
				 * 4. Инициализируем переменную resultSuperWord возвращаемым значением, полученным
				 * в результате вызова вышеуказанного метода.
				 * 
				 */

				var testWordCalculator = new WordCalculator();
				SuperWord resultSuperWord = testWordCalculator.CalculateSuperWord(arrWordsLoremIpsum);

				// Выводим на консоль полученное "супер-слово".
				FileResult.OutputSuperWord(resultSuperWord);

			}
			else // целевой файл НЕ существует
			{
				Console.WriteLine("Файл не существует !!!\n\n");
			}

			Console.ReadKey(); // удерживаем консоль
		}
	}
}
