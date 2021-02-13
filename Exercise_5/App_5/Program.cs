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

        
        static void WorstScholars(string file_path)
        {
            if (File.Exists(file_path))
            {
                string[] f_lines = File.ReadAllLines(file_path);
                double[] average = new double[int.Parse(f_lines[0])];
                double[] tmp_average = new double[int.Parse(f_lines[0])];
                string[] names = new string[int.Parse(f_lines[0])];

                string[] elems;
                char[] num_str;
                double sum;

                for (int i = 1; i < f_lines.Length; i++)
                {
                    try
                    {

                        elems = f_lines[i].Split(' ');

                        num_str = f_lines[i].Where(Char.IsDigit).ToArray();
                        sum = 0;

                        for (int j = 0; j < num_str.Length; j++)
                            sum += int.Parse(num_str[j].ToString());                        
                        sum /= num_str.Length;

                        average[i - 1] = Math.Round(sum, 3);
                        tmp_average[i - 1] = Math.Round(sum, 3);
                        names[i - 1] = elems[0] + " " + elems[1];
                        Console.WriteLine($"{names[i - 1]} {num_str[0]} {num_str[1]} {num_str[2]}, средний балл ученика = {average[i - 1]}");

                    }
                    catch
                    {
                        average[i - 1] = 0;
                        tmp_average[i - 1] = 0;
                        Console.WriteLine("Строка с информацией об ученике некорректна!");
                    }
                     
                }


                Array.Sort(tmp_average);

                int num_remove = 0;
                tmp_average = tmp_average.Where(val => val != num_remove).ToArray();
                average = average.Where(val => val != num_remove).ToArray();

                int N = 3;
                if (tmp_average.Length < 3)
                    N = tmp_average.Length;

                //foreach (double a in tmp_average) Console.Write(a + " ");
                //Console.WriteLine("\n");
                //foreach (double aa in average) Console.Write(aa + " ");
                //Console.WriteLine("\n");


                Dictionary<string, double> result = new Dictionary<string, double>();
                

                for (int i = 0; i < N; i++)
                {
                    for (int j = 0; j < average.Length; j++)
                    {
                        if (average[j] == tmp_average[i])
                        {
                            try
                            {
                                result.Add(names[j], average[j]);
                            }
                            catch { }
                            

                        }
                            
                    }
                }

                Console.WriteLine($"\nУченики с самыми низким средним баллом: ");
                foreach (var item in result)
                    Console.WriteLine($"{item.Key} - {item.Value}");

            }
            else
                Console.WriteLine($"Не получилось найти и открыть файл: {file_path}");

        }

        static void TrueFalse(string file_path)
        {
            if (File.Exists(file_path))
            {
                string[] f_lines = File.ReadAllLines(file_path);
                Random rand_num = new Random();

                int n;
                int counter = 0;

                for (int i = 0; i < 5; i++)
                {
                    n = rand_num.Next(0, f_lines.Length);
                    string[] elems = f_lines[n].Split('|');
                    Console.WriteLine($"\n{elems[0]}");
                    Console.WriteLine("Введите ответ да/нет: ");
                    string answer = Console.ReadLine();

                    if (answer == elems[1])
                        counter += 1;

                }

                Console.WriteLine($"Игра закончена, ваш счёт: {counter}");


            }
            else
                Console.WriteLine($"Не получилось найти и открыть файл: {file_path}");
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
                            output_help.OutputTaskText("Задача ЕГЭ." +
                                "\n* На вход программе подаются сведения о сдаче экзаменов учениками 9 - х классов некоторой средней" +
                                "\nшколы.В первой строке сообщается количество учеников N, которое не меньше 10, но не" +
                                "\nпревосходит 100, каждая из следующих N строк имеет следующий формат:" +
                                "\n< Фамилия > < Имя > < оценки >," +
                                "\nгде < Фамилия > — строка, состоящая не более чем из 20 символов, < Имя > — строка, состоящая не" +
                                "\nболее чем из 15 символов, < оценки > — через пробел три целых числа, соответствующие оценкам по" +
                                "\nпятибалльной системе. < Фамилия > и<Имя>, а также < Имя > и < оценки > разделены одним пробелом." +
                                "\nПример входной строки:" +
                                "\nИванов Петр 4 5 3" +
                                "\nТребуется написать как можно более эффективную программу, которая будет выводить на экран" +
                                "\nфамилии и имена трёх худших по среднему баллу учеников.Если среди остальных есть ученики," +
                                "\nнабравшие тот же средний балл, что и один из трёх худших, следует вывести и их фамилии и имена." +
                                "\nДостаточно решить 2 задачи.Старайтесь разбивать программы на подпрограммы.Переписывайте в" +
                                "\nначало программы условие и свою фамилию.Все программы сделать в одном решении.Для решения" +
                                "\nзадач используйте неизменяемые строки(string)", 4);

                            //WorstScholars("scholars_0.txt");
                            WorstScholars("scholars_1.txt");
                            break;
                        case 5:

                            output_help.OutputTaskText("**Написать игру «Верю. Не верю»." +
                                "\nВ файле хранятся вопрос и ответ, правда это или нет." +
                                "\nНапример: «Шариковую ручку изобрели в древнем Египте», «Да»." +
                                "\nКомпьютер загружает эти данные, случайным образом выбирает 5 вопросов и задаёт их игроку." +
                                "\nИгрок отвечает Да или Нет на каждый вопрос и набирает баллы за каждый правильный ответ." +
                                "\nСписок вопросов ищите во вложении или воспользуйтесь интернетом.,", 5);
                            TrueFalse("true_false.txt");

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
