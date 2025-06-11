using System;
using System.IO;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using ConsoleApp15;

class Program
{
    //Первое
    static string inputFile = "owners.txt";
    static string outputFile = "vaz_owners.txt";
    
    //Второе
    static string filePath = "f.txt";
    
    //Третье
    
    static string inputFile2 = "matrices.txt";
    static string outputFile2 = "even_sum_matrices.txt";
    
    //Четвёртое 
    const string fileName = "tvs.dat";
    
    const string fileName2 = "filename2.dat";
    
    //Шестое
    const string buyersFile = "buyersData.dat";
    
    static void Main()
    {

        string N = Console.ReadLine();
        switch (N)
        {
            case "1":
                Z1();
                break;
            case "2":
                Z2();
                break;
            case "3":
                Z3();
                break;
            case "4":
                Z4();
                break;
            case "5":
                Z5();
                break;
            case "6":
                Z6();
                break;
            default:
                break;
        }
    }

    static void Z1()
    {
        if (!File.Exists(inputFile))
        {
            string[] sampleData = new string[]
            {
                "Иванов;Иван;Иванович;89001234567;123456,Россия,Московская,Ленинский,Москва,Ленина,10,5;Ваз;А123ВЕ77;Т123456",
                "Петров;Петр;Петрович;89007654321;654321,Россия,Тверская,Центральный,Тверь,Советская,12,1;Toyota;В456ОР69;Т654321",
                "Сидоров;Сидор;Сидорович;89001112233;111222,Россия,Рязанская,Октябрьский,Рязань,Космонавтов,8,3;Ваз;С789АН62;Т789123"
            };
            File.WriteAllLines(inputFile, sampleData);
            Console.WriteLine("Создан файл с начальными данными владельцев автомобилей.");
        }
        
        Console.WriteLine("\nХотите добавить нового владельца? (да/нет): ");
        string answer = Console.ReadLine().ToLower();

        if (answer == "да")
        {
            Console.WriteLine("\nВведите данные нового владельца:");

            Console.Write("Фамилия: ");
            string lastName = Console.ReadLine();

            Console.Write("Имя: ");
            string firstName = Console.ReadLine();

            Console.Write("Отчество: ");
            string patronymic = Console.ReadLine();

            Console.Write("Номер телефона: ");
            string phone = Console.ReadLine();

            Console.WriteLine("Адрес (по частям):");
            Console.Write("Почтовый индекс: ");
            string index = Console.ReadLine();

            Console.Write("Страна: ");
            string country = Console.ReadLine();

            Console.Write("Область: ");
            string region = Console.ReadLine();

            Console.Write("Район: ");
            string district = Console.ReadLine();

            Console.Write("Город: ");
            string city = Console.ReadLine();

            Console.Write("Улица: ");
            string street = Console.ReadLine();

            Console.Write("Дом: ");
            string house = Console.ReadLine();

            Console.Write("Квартира: ");
            string flat = Console.ReadLine();

            Console.Write("Марка автомобиля: ");
            string carBrand = Console.ReadLine();

            Console.Write("Номер автомобиля: ");
            string carNumber = Console.ReadLine();

            Console.Write("Номер техпаспорта: ");
            string passportNumber = Console.ReadLine();

            string address = $"{index},{country},{region},{district},{city},{street},{house},{flat}";
            string newLine = $"{lastName};{firstName};{patronymic};{phone};{address};{carBrand};{carNumber};{passportNumber}";

            File.AppendAllText(inputFile, newLine + Environment.NewLine);
            Console.WriteLine("Запись добавлена.\n");
        }
        
        Console.WriteLine("Содержимое файла:");
        string[] lines = File.ReadAllLines(inputFile);
        foreach (string line in lines)
        {
            Console.WriteLine(line);
        }
        
        List<string> vazOwners = new List<string>();
        foreach (string line in lines)
        {
            string[] parts = line.Split(';');
            if (parts.Length >= 8 && parts[5].Trim().Equals("Ваз", StringComparison.OrdinalIgnoreCase))
            {
                vazOwners.Add(line);
            }
        }
        File.WriteAllLines(outputFile, vazOwners);
        Console.WriteLine("\nИнформация об автомобилях марки 'Ваз' сохранена в файл vaz_owners.txt.");
    }

    static void Z2()
    {
        string filePath = "f.txt";

        if (!File.Exists(filePath))
        {
            File.WriteAllText(filePath, "1.5 -2.0 3.0");
            Console.WriteLine("Создан файл f.txt с тестовыми числами.");
        }

        string content = File.ReadAllText(filePath);
        string[] parts = content.Split(new char[] { ' ', '\n', '\r', '\t' }, StringSplitOptions.RemoveEmptyEntries);

        double sum = 0;
        double product = 1;

        foreach (string part in parts)
        {
            if (double.TryParse(part, NumberStyles.Any, CultureInfo.InvariantCulture, out double number))
            {
                sum += number;
                product *= number;
            }
        }

        double absSum = Math.Abs(sum);
        double productSquared = Math.Pow(product, 2);

        Console.WriteLine($"Модуль суммы: {absSum}");
        Console.WriteLine($"Квадрат произведения: {productSquared}");
    }

    static void Z3()
{
    int k = 3;  // количество матриц
    int m = 2;  // строки
    int n = 3;  // столбцы

    // Исправлено: проверяем наличие файла matrices.txt (inputFile2)
    if (!File.Exists(inputFile2))
    {
        using (StreamWriter writer = new StreamWriter(inputFile2))
        {
            writer.WriteLine("1 2 3");
            writer.WriteLine("4 5 6");
            writer.WriteLine();

            writer.WriteLine("0 8 1");
            writer.WriteLine("2 2 3");
            writer.WriteLine();

            writer.WriteLine("7 5 9");
            writer.WriteLine("1 3 1");
            writer.WriteLine();
        }
    }

    string[] lines = File.ReadAllLines(inputFile2);
    List<string> newInput = new List<string>();
    List<string> evenSumMatrices = new List<string>();

    for (int i = 0; i < lines.Length;)
    {
        List<int[]> matrix = new List<int[]>();
        for (int row = 0; row < m && i < lines.Length; row++, i++)
        {
            if (!string.IsNullOrWhiteSpace(lines[i]))
            {
                int[] rowValues = Array.ConvertAll(lines[i].Trim().Split(' '), int.Parse);
                matrix.Add(rowValues);
            }
        }
        while (i < lines.Length && string.IsNullOrWhiteSpace(lines[i])) i++;

        int sum = 0;
        foreach (var row in matrix)
            foreach (int val in row)
                if (val > 0 && val % 2 == 0)
                    sum += val;

        if (sum % 2 == 0 && sum > 0)
        {
            foreach (var row in matrix)
                evenSumMatrices.Add(string.Join(" ", row));
            evenSumMatrices.Add("");

            for (int r = 0; r < m; r++)
            {
                string line = "";
                for (int c = 0; c < n; c++)
                    line += (r == c ? "1" : "0") + " ";
                newInput.Add(line.Trim());
            }
            newInput.Add("");
        }
        else
        {
            foreach (var row in matrix)
                newInput.Add(string.Join(" ", row));
            newInput.Add("");
        }
    }

    File.WriteAllLines(inputFile2, newInput);
    File.WriteAllLines(outputFile2, evenSumMatrices);

    Console.WriteLine("Содержимое первого файла (matrices.txt):\n");
    Console.WriteLine(File.ReadAllText(inputFile2));

    Console.WriteLine("Содержимое второго файла (even_sum_matrices.txt):\n");
    Console.WriteLine(File.ReadAllText(outputFile2));
}
    static void Z4()
    {
        List<TV> tvs = new List<TV>();

        // Если файла с ТВ нет, создаём тестовые данные и записываем в бинарник
        if (!File.Exists(fileName))
        {
            tvs.Add(new TV("Samsung", 40, 30000));
            tvs.Add(new TV("LG", 32, 25000));
            tvs.Add(new TV("Samsung", 28, 20000));
            tvs.Add(new TV("Sony", 45, 40000));
            tvs.Add(new TV("Samsung", 33, 35000));

            using (BinaryWriter bw = new BinaryWriter(File.Open(fileName, FileMode.Create)))
            {
                foreach (var tv in tvs)
                {
                    bw.Write(tv.Brand);
                    bw.Write(tv.Diagonal);
                    bw.Write(tv.Price);
                }
            }
            Console.WriteLine("Создан бинарный файл с тестовыми телевизорами.");
        }

        // Читаем телевизоры из бинарного файла
        tvs.Clear();
        using (BinaryReader br = new BinaryReader(File.Open(fileName, FileMode.Open)))
        {
            while (br.BaseStream.Position != br.BaseStream.Length)
            {
                string brand = br.ReadString();
                double diagonal = br.ReadDouble();
                decimal price = br.ReadDecimal();
                tvs.Add(new TV(brand, diagonal, price));
            }
        }

        // Фильтруем и выводим Samsung с диагональю больше 32
        var filtered = tvs.FindAll(tv => tv.Brand.Equals("Samsung", StringComparison.OrdinalIgnoreCase) && tv.Diagonal > 32);

        Console.WriteLine("\nТелевизоры фирмы Samsung с диагональю больше 32 дюймов:");
        foreach (var tv in filtered)
        {
            Console.WriteLine($"Марка: {tv.Brand}, Диагональ: {tv.Diagonal}, Цена: {tv.Price}");
        }
    }

    static void Z5()
    {
        Console.OutputEncoding = Encoding.UTF8;
        Console.InputEncoding = Encoding.UTF8;

        Console.WriteLine("Введите строку с русскими символами:");
        string input = Console.ReadLine();

        File.WriteAllBytes(fileName2, Encoding.UTF8.GetBytes(input));
        Console.WriteLine("\nЗаписано в файл.");

        byte[] bytes = File.ReadAllBytes(fileName2);
        string textBefore = Encoding.UTF8.GetString(bytes);

        Console.WriteLine("\nСодержимое файла ДО преобразования:");
        Console.WriteLine(textBefore);

        string textUpper = textBefore.ToUpper(new System.Globalization.CultureInfo("ru-RU"));
        File.WriteAllBytes(fileName2, Encoding.UTF8.GetBytes(textUpper));

        byte[] bytesAfter = File.ReadAllBytes(fileName2);
        string textAfter = Encoding.UTF8.GetString(bytesAfter);

        Console.WriteLine("\nСодержимое файла ПОСЛЕ преобразования:");
        Console.WriteLine(textAfter);
    }

    static void Z6()
    {
        if (!File.Exists(buyersFile))
    {
        var buyers = new List<Buyer>
        {
            new Buyer
            {
                FullName = "Иванов И.И.",
                PurchaseDate = new DateTime(2024, 3, 15),
                FirstHalfSum = 12000,
                SecondHalfSum = 15000,
                DiscountPercent = 5.0
            },
            new Buyer
            {
                FullName = "Петров П.П.",
                PurchaseDate = new DateTime(2024, 6, 10),
                FirstHalfSum = 8000,
                SecondHalfSum = 7000,
                DiscountPercent = 10.0
            },
            new Buyer
            {
                FullName = "Сидоров С.С.",
                PurchaseDate = new DateTime(2024, 9, 5),
                FirstHalfSum = 10000,
                SecondHalfSum = 10000,
                DiscountPercent = 3.0
            }
        };

        using (BinaryWriter writer = new BinaryWriter(File.Open(buyersFile, FileMode.Create)))
        {
            foreach (var b in buyers)
            {
                writer.Write(b.FullName);
                writer.Write(b.PurchaseDate.ToBinary());
                writer.Write(b.FirstHalfSum);
                writer.Write(b.SecondHalfSum);
                writer.Write(b.DiscountPercent);
            }
        }
        Console.WriteLine("Создан файл покупателей с тестовыми данными.");
    }

    // Считаем покупателей из файла
    var buyersList = new List<Buyer>();
    using (BinaryReader reader = new BinaryReader(File.Open(buyersFile, FileMode.Open)))
    {
        while (reader.BaseStream.Position < reader.BaseStream.Length)
        {
            Buyer b = new Buyer
            {
                FullName = reader.ReadString(),
                PurchaseDate = DateTime.FromBinary(reader.ReadInt64()),
                FirstHalfSum = reader.ReadDouble(),
                SecondHalfSum = reader.ReadDouble(),
                DiscountPercent = reader.ReadDouble()
            };
            buyersList.Add(b);
        }
    }

    // Вывод ДО изменения скидки
    Console.WriteLine("\nПокупатели ДО изменения скидки:");
    foreach (var b in buyersList)
        Console.WriteLine(b.ToString());

    // Увеличиваем скидку на 7%, если суммы >= 10000
    for (int i = 0; i < buyersList.Count; i++)
    {
        Buyer b = buyersList[i];  // Получаем копию структуры
        if (b.FirstHalfSum >= 10000 && b.SecondHalfSum >= 10000)
        {
            b.DiscountPercent += 7;  // Изменяем копию
            buyersList[i] = b;        // Записываем обратно в список
        }
    }


    // Записываем обратно
    using (BinaryWriter writer = new BinaryWriter(File.Open(buyersFile, FileMode.Create)))
    {
        foreach (var b in buyersList)
        {
            writer.Write(b.FullName);
            writer.Write(b.PurchaseDate.ToBinary());
            writer.Write(b.FirstHalfSum);
            writer.Write(b.SecondHalfSum);
            writer.Write(b.DiscountPercent);
        }
    }

    // Вывод ПОСЛЕ изменения скидки
    Console.WriteLine("\nПокупатели ПОСЛЕ изменения скидки:");
    foreach (var b in buyersList)
        Console.WriteLine(b.ToString());
    }

}
