using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace App_5
{
    public class OutputHelp
    {
        //метод для создания паузы
        public void Pause()
        {
            Console.ReadKey();
        }

        //вывод тескта и номера задания
        public void OutputTaskText(string text, int task_num)
        {
            Console.WriteLine($"------------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine($"\nЗадание № {task_num}\n");
            Console.WriteLine($"{text}\n");
        }
        //вывод исполнителя работы
        public void OutputName(string name, string surname)
        {
            Console.WriteLine($"Задание выполнил(а): {name} {surname}\n");
        }
    }

    class Program
    {


        static bool CheckLogin(string login) 
        {
            bool flag = true;
            if (login.Length > 20 || login.Length <= 0 )
            {
                Console.WriteLine($"Длина логина должна быть положительной и не превышать 20 символов!");
                return false;
            }
            else 
            {
                for (int i = 0; i < login.Length; i++)
                {
                    int n = (int)login[i];
                    if ((n > 122 || n < 97) && (n > 90 || n < 65) && (n > 57 || n < 48))
                        flag = false;                       
                }

                return flag;

            }

        }

        static bool CheckLoginReg(string login)
        {

            Regex myRegEx = new Regex(@"^[a-zA-Z0-9 ]*$");
            return myRegEx.IsMatch(login);
        }

        static string GetTextFromFile(string file_path)
        {
            if (File.Exists(file_path))
            {

                return File.ReadAllText(file_path);
            }
            else
            {
                Console.WriteLine($"Не получилось найти и открыть файл: {file_path}");
                return "";
            }
                
        }

        static bool IsStringsRearrangedSimple(string str_1, string str_2)
        {
            

            string res_1 = String.Concat(str_1.OrderBy(c => c));
            string res_2 = String.Concat(str_2.OrderBy(c => c));

            if (res_1 == res_2)
                return true;
            else
                return false;
        }

        static Dictionary<char, int> RemoveDublicates(string str)
        {
            Dictionary<char, int> result = new Dictionary<char, int>();

            int index;
            int counter;
            char elem;

            while (str.Length > 0)
            {
                counter = 0;
                elem = str[0];
                index = str.IndexOf(elem);
                
                while (index >= 0)
                {

                    counter += 1;
                    str = (index < 0) ? str : str.Remove(index, 1);
                    index = str.IndexOf(elem);
                    //Console.WriteLine(index);
                    //Console.WriteLine(str);
                }
                
                result.Add(elem, counter);
            }

            return result;
        }

        static bool IsStringsRearranged(string str_1, string str_2)
        {
            Dictionary<char, int> res_1 = RemoveDublicates(str_1);
            Dictionary<char, int> res_2 = RemoveDublicates(str_2);

            bool flag = true;

            foreach (var item in res_1)
            {
                int count;
                if (res_2.TryGetValue(item.Key, out count))
                {
                    //Console.WriteLine($"{item.Key} {item.Value} {count}");
                    if (item.Value != count)
                    {
                        flag = false;
                        break;
                    }

                }
                else
                {
                    flag = false;
                    break;
                }
            }

            return flag;

        }


        static void Main(string[] args)
        {

            OutputHelp output_help = new OutputHelp();
            output_help.OutputName("Наталья", "Воробьева");

            //----------------------------------------------------------------------------------------

            Console.WriteLine("Нажмите Esc для выхода, любую кнопку - для продолжения работы");
            while (Console.ReadKey().Key != ConsoleKey.Escape)
            {
                Console.WriteLine($"------------------------------------------------------------------------------------------------------------------------");
                Console.WriteLine("\nВыберите задачу, введите номер от 1 до 5:");
                string task = Console.ReadLine();
                int task_num;

                if (Int32.TryParse(task, out task_num))
                {
                    task_num = Convert.ToInt32(task);

                    switch (task_num)
                    {
                        case 1:
                            output_help.OutputTaskText("Создать программу, которая будет проверять корректность ввода логина." +
                                "\nКорректным логином будет строка от 2 до 10 символов," +
                                "\nсодержащая только буквы латинского алфавита или цифры, при этом цифра не может быть первой:" +
                                "\nа) без использования регулярных выражений;" +
                                "\nб) с использованием регулярных выражений. ", 1);

                            string login = "chsFWdkj_2ekps3i2o";

                            //Решение без помощи регулярных выражений
                            if (CheckLogin(login))
                                Console.WriteLine($"Введенный логин {login} отвечает заданным требованиям!");
                            else
                                Console.WriteLine($"Введенный логин {login} не отвечает заданным требованиям!\n");

                            //Решение с помощью регулярных выражений
                            if (CheckLoginReg(login))
                                Console.WriteLine($"Введенный логин {login} отвечает заданным требованиям!");
                            else
                                Console.WriteLine($"Введенный логин  {login} не отвечает заданным требованиям!\n");


                            break;
                        case 2:
                            output_help.OutputTaskText("Разработать класс Message, содержащий следующие статические методы для обработкитекста:" +
                                "\nа) Вывести только те слова сообщения, которые содержат не более n букв." +
                                "\nб) Удалить из сообщения все слова, которые заканчиваются на заданный символ." +
                                "\nв) Найти самое длинное слово сообщения." +
                                "\nг) Сформировать строку с помощью StringBuilder из самых длинных слов сообщения." +
                                "\nПродемонстрируйте работу программы на текстовом файле с вашей программой.", 2);

                            string file_path = "test_text.txt";
                            string text = GetTextFromFile(file_path);
                            Console.WriteLine($"Исходная строка: \n\n{text}");

                            int n = 8;
                            Console.WriteLine($"\nСлова сообщения, содержащие не более {n} букв: \n");
                            Message.OutputWordsOfGivenLength(text, n);

                            char symb = 't';
                            Console.WriteLine($"\nСообщение без слов, заканчивающихся на символ {symb}: \n");
                            Message.RemoveExtraWord(text, symb);

                            
                            Tuple<string, int> max_word = Message.FindMaxWord(text);
                            Console.WriteLine($"\nСамое длинное слово сообщения: {max_word.Item1} длинной {max_word.Item2}\n");

                            Console.WriteLine($"\nСтрока из самых длинных слов сообщения: \n");
                            Message.OutputMaxWords(text);

                            break;
                        case 3:
                            output_help.OutputTaskText("Для двух строк написать метод, определяющий, является ли одна строка перестановкой другой." +
                                "\nРегистр можно не учитывать:" +
                                "\nа) с использованием методов C#;" +
                                "\nб) *разработав собственный алгоритм." +
                                "\nНапример:badc являются перестановкой abcd.", 3);

                            string str_1 = "bandbbbcahccaaa";
                            //string str_2 = "aadnbbbhcaaccba";
                            //string str_2 = "adnbbbhcaccba";
                            string str_2 = "aadbbbhcaaccb";

                            //Решение с помощью собственного алгоритма
                            if (IsStringsRearranged(str_1, str_2))
                                Console.WriteLine($"Строка {str_1} является перестановкой строки {str_2}");
                            else
                                Console.WriteLine($"Строка {str_1} не является перестановкой строки {str_2}");

                            //Решение с помощью встроенных методов 
                            if (IsStringsRearrangedSimple(str_1, str_2))
                                Console.WriteLine($"Строка {str_1} является перестановкой строки {str_2}");
                            else
                                Console.WriteLine($"Строка {str_1} не является перестановкой строки {str_2}");

                            break;

                        case 4:
                            output_help.OutputTaskText("Решить задачу с логинами из урока 2, только логины и пароли считать из файла в массив." +
                                "\nСоздайте структуру Account, содержащую Login и Password.", 4);

                            break;
                        case 5:

                            output_help.OutputTaskText("*а) Реализовать библиотеку с классом для работы с двумерным массивом. Реализовать конструктор, заполняющий массив случайными числами." +
                                "\nСоздать методы, которые возвращают сумму всех элементов массива, сумму всех элементов массива больше заданного, свойство," +
                                "\nвозвращающее минимальный элемент массива," +
                                "\nсвойство, возвращающее максимальный элемент массива, метод, возвращающий номер максимального элемента массива" +
                                "\n(через параметры, используя модификатор ref или out)." +
                                "\n* *б) Добавить конструктор и методы, которые загружают данные из файла и записывают данные в файл." +
                                "\n* *в) Обработать возможные исключительные ситуации при работе с файлами.", 5);


                            break;

                        default:
                            Console.WriteLine("Задачи под таким номером не существует!");
                            break;
                    }

                }
                else
                {
                    Console.WriteLine("Некорректный ввод номера задачи!");
                }

                Console.WriteLine("\nНажмите Esc для выхода, любую кнопку - для продолжения работы");
            }
        }
    }
}
