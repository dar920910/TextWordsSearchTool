namespace TextWordsSearch.Library
{
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

			return strTextLoremIpsum; // возвращаем полученный массив в вызывающий код
		}
	}
}
