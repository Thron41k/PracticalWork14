using PracticalWork14;

var phoneBook = new List<Contact>
{
    // добавляем контакты
    new("Игорь", "Николаев", 79990000001, "igor@example.com"),
    new("Сергей", "Довлатов", 79990000010, "serge@example.com"),
    new("Анатолий", "Карпов", 79990000011, "anatoly@example.com"),
    new("Валерий", "Леонтьев", 79990000012, "valera@example.com"),
    new("Сергей", "Брин", 799900000013, "serg@example.com"),
    new("Иннокентий", "Смоктуновский", 799900000013, "innokentii@example.com")
};

// Сортируем список контактов сначала по имени, потом по фамилии
phoneBook = [..phoneBook.OrderBy(s => s.Name).ThenBy(s => s.LastName)];

var maxPage = (phoneBook.Count + 1) / 2;

while (true)
{
    // Вывод подсказки для пользователя
    Console.Write($"Введите номер страницы (1-{maxPage}): ");

    // Читаем символ, преобразуем в строку и пытаемся преобразовать в целое число.
    // Проверяем, что число находится в диапазоне от 1 до 3 включительно.
    if (int.TryParse(Console.ReadKey().KeyChar.ToString(), out var pageNumber) && pageNumber >= 1 && pageNumber <= maxPage)
    {
        Console.WriteLine(); // Перенос строки после ввода

        // Пропускаем (pageNumber - 1) * 2 элементов и берем следующие 2 элемента для отображения на текущей странице.
        var pageContent = phoneBook.Skip((pageNumber - 1) * 2).Take(2);

        // Проверяем, есть ли данные на текущей странице.
        var enumerable = pageContent as Contact[] ?? pageContent.ToArray();
        if (!enumerable.Any())
        {
            // Если данных нет, выводим соответствующее сообщение
            Console.WriteLine("Нет данных для отображения.");
        }
        else
        {
            // Если данные есть, выводим их построчно в формате "Имя Фамилия: Телефон"
            foreach (var entry in enumerable)
                Console.WriteLine($"{entry.Name} {entry.LastName}: {entry.PhoneNumber}");
        }

        Console.WriteLine();
    }
    else
    {
        // Если введенные данные некорректны, выводим сообщение об ошибке
        Console.WriteLine("\nОшибка: Страницы не существует. Попробуйте снова.");
    }
}