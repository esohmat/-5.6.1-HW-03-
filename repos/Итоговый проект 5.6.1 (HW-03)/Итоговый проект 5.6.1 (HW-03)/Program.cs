using System;

class Program
{
    static void Main(string[] args)
    {
        var userData = GetUserData();

        DisplayUserData(userData);
    }
    static (string Name, string Surname, int Age, bool HasPet, int PetCount, string[] PetNames, int ColorCount, string[] FavoriteColors) GetUserData()
    {
        Console.WriteLine("=== ЗАПОЛНЕНИЕ ДАННЫХ ПОЛЬЗОВАТЕЛЯ ===");

        Console.Write("Введите имя: ");
        string name = Console.ReadLine();

        Console.Write("Введите фамилию: ");
        string surname = Console.ReadLine();

        int age = GetPositiveNumber("Введите возраст: ");

        bool hasPet = GetYesNoAnswer("Есть ли у вас питомец? (да/нет): ");

        int petCount = 0;
        string[] petNames = Array.Empty<string>();

        if (hasPet)
        {
            petCount = GetPositiveNumber("Введите количество питомцев: ");
            petNames = GetPetNames(petCount);
        }
        int colorCount = GetPositiveNumber("Введите количество любимых цветов: ");
        string[] favoriteColors = GetFavoriteColors(colorCount);

        return (name, surname, age, hasPet, petCount, petNames, colorCount, favoriteColors);
    }
    static int GetPositiveNumber(string message)
    {
        int number;
        while (true)
        {
            Console.Write(message);
            string input = Console.ReadLine();

            if (int.TryParse(input, out number) && number > 0)
            {
                return number;
            }
            else
            {
                Console.WriteLine("Ошибка! Введите целое число больше 0.");
            }
        }
    }
    static bool GetYesNoAnswer(string message)
    {
        while (true)
        {
            Console.Write(message);
            string input = Console.ReadLine().ToLower();

            if (input == "да" || input == "д" || input == "yes" || input == "y")
            {
                return true;
            }
            else if (input == "нет" || input == "н" || input == "no" || input == "n")
            {
                return false;
            }
            else
            {
                Console.WriteLine("Ошибка! Введите 'да' или 'нет'.");
            }
        }
    }
    static string[] GetPetNames(int count)
    {
        string[] names = new string[count];

        Console.WriteLine($"Введите клички {count} питомцев:");
        for (int i = 0; i < count; i++)
        {
            Console.Write($"Кличка питомца {i + 1}: ");
            names[i] = Console.ReadLine();
        }

        return names;
    }
    static string[] GetFavoriteColors(int count)
    {
        string[] colors = new string[count];

        Console.WriteLine($"Введите {count} любимых цветов:");
        for (int i = 0; i < count; i++)
        {
            Console.Write($"Цвет {i + 1}: ");
            colors[i] = Console.ReadLine();
        }

        return colors;
    }
    static void DisplayUserData((string Name, string Surname, int Age, bool HasPet, int PetCount, string[] PetNames, int ColorCount, string[] FavoriteColors) userData)
    {
        Console.WriteLine("\n=== ВАШИ ДАННЫЕ ===");
        Console.WriteLine($"Имя: {userData.Name}");
        Console.WriteLine($"Фамилия: {userData.Surname}");
        Console.WriteLine($"Возраст: {userData.Age}");

        if (userData.HasPet)
        {
            Console.WriteLine($"Количество питомцев: {userData.PetCount}");
            Console.WriteLine("Клички питомцев:");
            foreach (string name in userData.PetNames)
            {
                Console.WriteLine($"  - {name}");
            }
        }
        else
        {
            Console.WriteLine("Питомцев нет");
        }

        Console.WriteLine($"Количество любимых цветов: {userData.ColorCount}");
        Console.WriteLine("Любимые цвета:");
        foreach (string color in userData.FavoriteColors)
        {
            Console.WriteLine($"  - {color}");
        }
    }
}