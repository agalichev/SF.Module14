namespace Task_14_3_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Создаём пустой список с типом данных Contact
            var phoneBook = new List<Contact>();

            phoneBook.Add(new Contact("Игорь", "Николаев", 79990000001, "igor@example.com"));
            phoneBook.Add(new Contact("Сергей", "Довлатов", 79990000010, "serge@example.com"));
            phoneBook.Add(new Contact("Анатолий", "Карпов", 79990000011, "anatoly@example.com"));
            phoneBook.Add(new Contact("Валерий", "Леонтьев", 79990000012, "valera@example.com"));
            phoneBook.Add(new Contact("Сергей", "Брин", 799900000013, "serg@example.com"));
            phoneBook.Add(new Contact("Иннокентий", "Смоктуновский", 799900000013, "innokentii@example.com"));

            //Сортируем телефонный справочник сначала по именам, затем по фамилиям
            var sortedPhoneBook = phoneBook.OrderBy(c => c.Name).ThenBy(c => c.LastName);

            while (true)
            {
                Console.Write("Введите 1, 2 или 3 для выбора страницы: ");

                //Считываем символ, соответсвтующий клавише
                var input = Console.ReadKey().KeyChar;

                Console.WriteLine();

                //Производим проверку полученного символа на соответствие числу
                var parsed = Int32.TryParse(input.ToString(), out int pageNumber);

                if (!parsed || pageNumber < 1 || pageNumber > 3)
                {
                    Console.WriteLine();
                    Console.WriteLine($"Страницы {pageNumber} не существует\n");
                }
                else
                {
                    Console.Clear();

                    //В зависимости от введенного номера страницы, пропускаем элементы и берем 2 для показа
                    var pageContent = sortedPhoneBook.Skip((pageNumber - 1) * 2).Take(2);

                    Console.WriteLine($"Страница {pageNumber}\n");

                    foreach (var content in pageContent)
                        Console.WriteLine($"{content.Name} {content.LastName}\n{content.PhoneNumber} {content.Email}\n");
                }
            }
        }
    }
}