using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounting
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string CommandAddNewAccounting = "1";
            const string CommandShowAllAccounting = "2";
            const string CommandDeleteAccounting = "3";
            const string CommandSearchSecondName = "4";
            const string CommandExit = "5";

            string[] fullNames = { "Иванов Иван Иванович", "Петров Петр Петрович", "Храбрая Люсия Афигевшая",
                                    "Спящий Медведь Ленивый", "Пронин Андрей Великолепный", "Алексеева Александра Александровна"};
            string[] jobs = { "Мясник", "Палач", "Котопес", "Алкоголик", "ЦарьПростоЦарь", "Ведьма" };

            string userInput;

            bool isWork = true;

            while (isWork)
            {
                Console.Clear();

                Console.WriteLine("Кадровый Учет.\n\nВыберите команду: ");
                Console.WriteLine($"{CommandAddNewAccounting} Добавить досье.");
                Console.WriteLine($"{CommandShowAllAccounting} Показать все досье.");
                Console.WriteLine($"{CommandDeleteAccounting} Удалить досье.");
                Console.WriteLine($"{CommandSearchSecondName} Поиск по фамилии.");
                Console.WriteLine($"{CommandExit} Выход из программы.");

                userInput = Console.ReadLine();

                switch (userInput)
                {
                    case CommandAddNewAccounting:
                        AddNewAccounting(ref fullNames, ref jobs);
                        break;

                    case CommandShowAllAccounting:
                        ShowAllAccounting(fullNames, jobs);
                        break;

                    case CommandDeleteAccounting:
                        DeleteAccounting(ref fullNames, ref jobs);
                        break;

                    case CommandSearchSecondName:
                        SearchSecondName(fullNames, jobs);
                        break;

                    case CommandExit:
                        Console.Clear();
                        Console.WriteLine("Прощайте!");
                        isWork = false;
                        break;

                    default:
                        Console.Clear();
                        Console.WriteLine("Введена неверная команда.");
                        WriteAnyKey();
                        break;
                }
            }
        }

        static void AddNewAccounting(ref string[] fullNames, ref string[] jobs)
        {
            Console.Clear();

            Console.WriteLine("Добавление досье.");

            AddWorker("Введите ФИО работника: ", ref fullNames);
            AddWorker("Введите должность работника: ", ref jobs);

            WriteAnyKey();
        }

        static void ShowAllAccounting(string[] fullNames, string[] jobs)
        {
            Console.Clear();

            Console.WriteLine("Список работников.");

            for (int i = 0; i < fullNames.Length; i++)
            {
                ShowResult(fullNames, jobs, i);
            }

            WriteAnyKey();
        }

        static void ShowResult(string[] fullNames, string[] jobs, int i)
        {
            Console.WriteLine("[{0}]: {1} - {2}", i + 1, fullNames[i], jobs[i]);
        }

        static void DeleteAccounting(ref string[] fullNames, ref string[] jobs)
        {
            Console.Clear();

            Console.WriteLine("Введите номер досье для его удаления.");

            int number = ReadInt();
            int index = number - 1;

            if (number > fullNames.Length || number <= 0)
            {
                Console.WriteLine("Неверный номер досье.");
            }
            else
            {
                Console.Clear();

                fullNames = DecreaseArray(fullNames, index);
                jobs = DecreaseArray(jobs, index);

                Console.WriteLine("Досье удалено безвозвратно.");
            }

            WriteAnyKey();
        }

        static void SearchSecondName(string[] fullNames, string[] jobs)
        {
            Console.Clear();

            char symbol = ' ';
            bool isFound = false;

            Console.WriteLine("Поиск по фамилии (второму имени).");

            string userInput = Console.ReadLine();

            Console.Clear();

            for (int i = 0; i < fullNames.Length; i++)
            {
                string[] secondName = fullNames[i].Split(symbol);

                if (secondName[0].ToLower() == userInput.ToLower())
                {
                    ShowResult(fullNames, jobs, i);
                    isFound = true;
                }
            }

            if (isFound == false)
            {
                Console.WriteLine("Работник с такой фамилией не найден.");
            }

            WriteAnyKey();
        }

        static void IncreaseArray(ref string[] array, string newValue)
        {
            string[] tempArray = new string[array.Length + 1];

            for (int i = 0; i < array.Length; i++)
            {
                tempArray[i] = array[i];
            }

            tempArray[tempArray.Length - 1] = newValue;
            array = tempArray;
        }

        static string[] DecreaseArray(string[] fullNames, int index)
        {
            string[] tempArray = new string[fullNames.Length - 1];

            for (int i = 0; i < index; i++)
            {
                tempArray[i] = fullNames[i];
            }

            for (int i = index; i < tempArray.Length; i++)
            {
                tempArray[i] = fullNames[i + 1];
            }

            return tempArray;
        }

        static void AddWorker(string message, ref string[] array)
        {
            Console.WriteLine(message);
            string newValue = Console.ReadLine();
            IncreaseArray(ref array, newValue);
        }

        static void WriteAnyKey()
        {
            Console.WriteLine("\nДля возврата в меню нажмите любую клавишу.");
            Console.ReadKey();
        }

        static int ReadInt()
        {
            int number;

            while (int.TryParse(Console.ReadLine(), out number) == false)
            {
                Console.Write("Не верный ввод! Повторите ввод: ");
            }

            return number;
        }
    }
}
