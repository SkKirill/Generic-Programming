using GeneralizedProgramming.Lists;
using GeneralizedProgramming.Utilites;

namespace GeneralizedProgramming
{
    internal class TestingGeneralizedProgramming
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Задание 1. Обобщенное программирование. 1.Список.");
            do
            {
                Interfaces.IList<string> testList;
                string? input;
                Console.Write("Введите A или L в зависимости от того, с каким типом списка мы будем работать и делать проверки!\nДля выхода введите ");
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("exit");
                do
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.Write("\nОжидание A - (ArrayList) или L - (LinkedList): ");
                    Console.ForegroundColor = ConsoleColor.White;
                    input = Console.ReadLine();
                    if (string.Equals("exit".ToLower(), input.ToLower(), StringComparison.OrdinalIgnoreCase))
                    {
                        Environment.Exit(0);
                    }
                        
                }
                while (!string.Equals("a".ToLower(), input.ToLower(), StringComparison.OrdinalIgnoreCase) &&
                        !string.Equals("l".ToLower(), input.ToLower(), StringComparison.OrdinalIgnoreCase));

                if (string.Equals("a".ToLower(), input.ToLower(), StringComparison.OrdinalIgnoreCase))
                {
                    testList = new ArrayList<string>();
                }
                else
                {
                    testList = new Lists.Linked.LinkedList<string>();
                }


                TestingListWhile(testList);

            } while (true);
        }

        private static void TestingListWhile(Interfaces.IList<string> testList)
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine();
            Console.Write("Доступные для проверки действия: \n");
            Console.Write(@"      IList: ".PadRight(55));        Console.ForegroundColor = ConsoleColor.Blue;Console.Write(@"        Utils:"); Console.WriteLine(); Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write(@"1 -> int Add(T value)".PadRight(55)); Console.ForegroundColor = ConsoleColor.Blue; Console.Write(@"1U -> bool Exists<T>(IList<T>, CheckDelegate<T>)"); Console.WriteLine(); Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write(@"2 -> void Clear()".PadRight(55)); Console.ForegroundColor = ConsoleColor.Blue; Console.Write(@"2U -> T Find<T>(IList<T>, CheckDelegate<T>)    "); Console.WriteLine(); Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write(@"3 -> bool Contains(T value)".PadRight(55)); Console.ForegroundColor = ConsoleColor.Blue; Console.Write(@"3U -> T FindLast<T>(IList<T>, CheckDelegate<T>)"); Console.WriteLine(); Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write(@"4 -> int IndexOf(T value)".PadRight(55)); Console.ForegroundColor = ConsoleColor.Blue; Console.Write(@"4U -> int FindIndex<T>(IList<T>, CheckDelegate<T>)"); Console.WriteLine(); Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write(@"5 -> void Insert(int index, T value)".PadRight(55)); Console.ForegroundColor = ConsoleColor.Blue; Console.Write(@"5U -> int FindLastIndex<T>(IList<T>...)"); Console.WriteLine(); Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write(@"6 -> void Remove(T value)".PadRight(55)); Console.ForegroundColor = ConsoleColor.Blue; Console.Write(@"6U -> IList<T> FindAll<T>(...)"); Console.WriteLine(); Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write(@"7 -> void RemoveAt(int index)".PadRight(55)); Console.ForegroundColor = ConsoleColor.Blue; Console.Write(@"7U -> IList<TO> ConvertAll<TI, TO>(...)"); Console.WriteLine(); Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write(@"8 -> IList<T> SubList(int fromIndex, int toIndex)".PadRight(55)); Console.ForegroundColor = ConsoleColor.Blue; Console.Write(@"8U -> void ForEach(IList<T>, ActionDelegate<T>)"); Console.WriteLine(); Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write(@"9 -> int Count { get; }".PadRight(55)); Console.ForegroundColor = ConsoleColor.Blue; Console.Write(@"9U -> void Sort(IList<T>, CompareDelegate<T>)"); Console.WriteLine(); Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write(@"10 -> T this[int index] { get; }".PadRight(55)); Console.ForegroundColor = ConsoleColor.Blue; Console.Write(@"10U -> bool CheckForAll<T>(...)"); Console.WriteLine(); Console.ForegroundColor = ConsoleColor.DarkGreen;

            Console.WriteLine("Чтобы выбрать действие нужно написать цифру или название метода\n" +
                                    "(чтобы вызвать Add(T value) нужно написать 1 или Add или добавить)\n" +
                                    "Для проверки неизменяемого создайте исписок и введите 0 - он станет неизменяемым!");
            Console.Write("Для выода из тестирования данного введите ");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("exit");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(" или ");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("выход");
            do
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write("\nОжидание ввода: ");
                Console.ForegroundColor = ConsoleColor.White;
                try
                {
                    string el;
                    int index, indexTo;
                    switch (Console.ReadLine().ToLower())
                    {
                        case "0":
                        case "unmuntable":
                        case "неизменяемое":
                            testList = new UnmutableList<string>(testList);
                            Console.WriteLine("Список превращен в неизменяемый!");
                            break;

                        case "1":
                        case "add":
                        case "добавить":
                            Console.Write("Элемент для добавления в конец: ");
                            string value = Console.ReadLine();
                            testList.Add(value);
                            break;

                        case "2":
                        case "clear":
                        case "очистить":
                            testList.Clear();
                            Console.WriteLine("Список очищен!");
                            break;

                        case "3":
                        case "contains":
                        case "входит":
                            Console.Write("Проверить вхождение элемента: ");
                            el = Console.ReadLine();
                            Console.WriteLine($"Элемент {el} в текущем списке " + (testList.Contains(el) ? "содержится" : "не содержится"));
                            break;

                        case "4":
                        case "indexof":
                        case "индекс":
                            Console.Write("Узнать индекс элемента: ");
                            el = Console.ReadLine();
                            Console.WriteLine($"Индекс элемента {el} в текущем списке: " + testList.IndexOf(el).ToString());
                            break;

                        case "5":
                        case "insert":
                        case "вставить":
                            Console.Write("Новый элемент: ");
                            el = Console.ReadLine();
                            Console.Write("Вставить под индексом: ");
                            index = Convert.ToInt32(Console.ReadLine());
                            testList.Insert(index, el);
                            Console.WriteLine("Элемент успешно вставлен!");
                            break;

                        case "6":
                        case "remove":
                        case "удалить":
                            Console.Write("Элемент, который требуется удалить: ");
                            el = Console.ReadLine();
                            testList.Remove(el);
                            Console.WriteLine("Элемент успешно удален!");
                            break;

                        case "7":
                        case "removeat":
                        case "удалитьпоиндексу":
                            Console.Write("Индекс элемента, который требуется удалить: ");
                            index = Convert.ToInt32(Console.ReadLine());
                            testList.RemoveAt(index);
                            Console.WriteLine("Элемент успешно удален!");
                            break;

                        case "8":
                        case "sublist":
                        case "подсписок":
                            Console.Write("Индекс начала подсписка: ");
                            index = Convert.ToInt32(Console.ReadLine());
                            Console.Write("Индекс конца подсписка: ");
                            indexTo = Convert.ToInt32(Console.ReadLine());
                            testList.SubList(index, indexTo);
                            Console.WriteLine("Подсписок успешно создан!");
                            break;

                        case "9":
                        case "count":
                        case "количество":
                            Console.WriteLine(testList.Count);
                            break;

                        case "10":
                        case "this":
                        case "конкретный":
                            Console.Write("Индекс элемента: ");
                            index = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Элемент: ", testList[index]);
                            break;

                        case "1u":
                        case "exists":
                        case "существование":
                            Console.Write("Проверить существование элемента: ");
                            el = Console.ReadLine();
                            Console.WriteLine($"Элемент {el} в текущем списке ", ListUtils.Exists(testList, item => item == el) ? "ссуществует" : "не существует");
                            break;

                        case "2u":
                        case "find":
                        case "поиск":
                            Console.Write("Найти элемент длинной больше: ");
                            index = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Первый подходящий: " + ListUtils.Find(testList, item => item.Length > index));
                            break;

                        case "3u":
                        case "findlast":
                        case "найтипоследний":
                            Console.Write("Найти элемент длинной больше: ");
                            index = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Последний подходящий: " + ListUtils.FindLast(testList, item => item.Length > index));
                            break;

                        case "4u":
                        case "findindex":
                        case "найтипоиндексу":
                            Console.Write("Найти индекс элемента длинной больше: ");
                            index = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine($"Индекс элемента: " + ListUtils.FindIndex(testList, item => item.Length > index));
                            break;

                        case "5u":
                        case "findlastindex":
                        case "найтипоследнийиндекс":
                            Console.Write("Найти последний индекс элемента длинной больше: ");
                            index = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine($"Индекс элемента : " + ListUtils.FindLastIndex(testList, item => item.Length > index));
                            break;

                        case "6u":
                        case "findall":
                        case "найтивсе":
                            Console.Write("Найти все элементы длинной больше: ");
                            index = Convert.ToInt32(Console.ReadLine());
                            Console.Write($"Элементы: ");
                            ListUtils.ForEach(
                                ListUtils.FindAll(
                                    testList, 
                                    item => item.Length > index, 
                                    () => new ArrayList<string>()
                                ), 
                                (item) => Console.Write(item + " ")
                            );
                            break;

                        case "7u":
                        case "convertall":
                        case "поменятьвсе":
                            Console.Write("Поменять все элементы в верхний регистр...");
                            Console.Write($"Список: ");
                            ListUtils.ForEach(
                                ListUtils.ConvertAll(
                                    testList,
                                    item => item.ToUpper(),
                                    () => new ArrayList<string>()
                                ),
                                (item) => Console.Write(item + " ")
                            );
                            break;

                        case "8u":
                        case "foreach":
                        case "view":
                            Console.Write("Список: ");
                            ListUtils.ForEach(testList, (item) => Console.Write(item + " "));
                            Console.WriteLine();
                            break;

                        case "9u":
                        case "sort":
                        case "сортировать":
                        case "отсортировать":
                            ListUtils.Sort(testList, (item1, item2) => string.Compare(item2, item1, StringComparison.Ordinal));
                            Console.WriteLine("Список отсортирован в лексигрофическом порядке!");
                            break;

                        case "10u":
                        case "checkforall":
                        case "проверитьвсе":
                            Console.Write("Проверка все ли элементы длиннее чем: ");
                            index = Convert.ToInt32(Console.ReadLine());
                            ListUtils.CheckForAll(testList, item => item.Length > index);
                            break;

                        case "exit":
                        case "выход":
                            return;

                        default:
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Неккоректный ввод! Повторите!");
                            Console.ForegroundColor = ConsoleColor.White;
                            break;
                    }
                }
                catch (Exception e)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("[ERROR] - " + e.Message);
                    Console.ForegroundColor = ConsoleColor.White;
                }
            } while (true);
        }
    }
}
