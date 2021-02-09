using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_4
{


    struct AuthStruct
    {
        public string correct_login;
        public string correct_password;
        public string file_path;

        public bool AuthFromFile()
        {

            string login = "";
            string password = "";

            if (File.Exists(file_path))
            {

                string[] f_lines = File.ReadAllLines(file_path);
                for (int i = 0; i < f_lines.Length; i++)
                {
                    try
                    {
                        string[] tokens = f_lines[i].Split(':');

                        if (tokens[0] == "login")
                        {
                            login = tokens[1];
                            Console.WriteLine($"Значение логина прочитано из файла: {file_path}");
                        }
                        else if (tokens[0] == "password")
                        {
                            password = tokens[1];
                            Console.WriteLine($"Значение пароля прочитано из файла: {file_path}");
                        }


                    }
                    catch { }

                }

            }
            else
                Console.WriteLine($"Не получилось найти и открыть файл: {file_path}");

            if (login == correct_login && correct_password == password)
                return true;
            else
                return false;
        }
    }
    class Auth
    {

        string correct_login = "root";
        string correct_password = "GeekBrains";
        
        string login = "";
        string password = "";

        public Auth()
        {

        }

        public Auth(string l, string p)
        {
            login = l;
            password = p;
        }

        public Auth(string file_path)
        {
            if (File.Exists(file_path))
            {

                string[] f_lines = File.ReadAllLines(file_path);
                for (int i = 0; i < f_lines.Length; i++)
                {
                    try
                    {
                        string[] tokens = f_lines[i].Split(':');

                        if (tokens[0] == "login")
                        {
                            login = tokens[1];
                            Console.WriteLine($"Значение логина прочитано из файла: {file_path}");
                        }
                        else if (tokens[0] == "password")
                        {
                            password = tokens[1];
                            Console.WriteLine($"Значение пароля прочитано из файла: {file_path}");
                        }


                    }
                    catch { }
                }

            }
            else
                Console.WriteLine($"Не получилось найти и открыть файл: {file_path}");
        }

        public bool Authorize()
        {
            //Console.WriteLine($"{login} {password}");
            if (login == correct_login && correct_password == password)
                return true;
            else
                return false;

        }
    }

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
        static void Main(string[] args)
        {

            OutputHelp output_help = new OutputHelp();
            output_help.OutputName("Наталья", "Воробьева");

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
                            output_help.OutputTaskText("Дан  целочисленный  массив  из 20 элементов.  Элементы  массива  могут принимать  целые  значения  от –10 000 до 10 000 включительно." +
                                "\nЗаполнить случайными числами.  Написать программу, позволяющую найти и вывести количество пар элементов массива, в которых только одно число делится на 3." +
                                "\nВ данной задаче под парой подразумевается два подряд идущих элемента массива. Например, для массива из пяти элементов: 6; 2; 9; –3; 6 ответ — 2. ", 1);

                            int N = 20;
                            int min_v = -10000;
                            int max_v = 10000;
                            OneDimArr obj_1 = new OneDimArr(N, min_v, max_v, false);
                            int[] arr_first = obj_1.GetOneDimArr();

                            Console.WriteLine($"Исходный массив: ");
                            obj_1.OutputOneDimArr(arr_first);
                            ArrayTestOne.FindPairs(N, arr_first);

                            break;
                        case 2:
                            output_help.OutputTaskText("Реализуйте задачу 1 в виде статического класса StaticClass;" +
                                "\nа) Класс должен содержать статический метод, который принимает на вход массив и решает задачу 1;" +
                                "\nб) *Добавьте статический метод для считывания массива из текстового файла. Метод должен возвращать массив целых чисел;" +
                                "\nв)**Добавьте обработку ситуации отсутствия файла на диске.", 2);

                            string file_path = "array_file.txt";
                            Console.WriteLine($"\nИсходный массив из файла: {file_path}:");
                            int[] arr_second = ArrayTestOne.InputFromFile(file_path);
                            ArrayTestOne.FindPairs(arr_second.Length, arr_second);

                            break;
                        case 3:
                            output_help.OutputTaskText("а) Дописать класс для работы с одномерным массивом. Реализовать конструктор," +
                                "\nсоздающий массив определенного размера и заполняющий массив числами от начального значения с заданным шагом." +
                                "\nСоздать свойство Sum, которое возвращает сумму элементов массива, метод Inverse," +
                                "\nвозвращающий новый массив с измененными знаками у всех элементов массива (старый массив, остается без изменений),  метод Multi," +
                                "\nумножающий каждый элемент массива на определённое число, свойство MaxCount, возвращающее количество максимальных элементов." +
                                "\nб) * *Создать библиотеку содержащую класс для работы с массивом.Продемонстрировать работу библиотекие)" +
                                "\n***Подсчитать частоту вхождения каждого элемента в массив(коллекция Dictionary< int,int>)", 3);

                            OneDimArr onedim_obj = new OneDimArr("one_dim_arr_test_0.txt", true);
                            //OneDimArr onedim_obj = new OneDimArr("one_dim_arr_test_1.txt", false);                            
                            Console.WriteLine($"Исходный массив");
                            onedim_obj.OutputOneDimArr();

                            int[] out_arr = new int[onedim_obj.getN()];
                            out_arr = onedim_obj.InverseArr();
                            Console.WriteLine($"\nМаксимальный элемент массива: {onedim_obj.Max} минимальный элемент массива:{onedim_obj.Min}\nСумма всех элементов массива:{onedim_obj.Sum}");

                            Console.WriteLine($"\nНовый массив с измененными знаками у всех элементов массива:");
                            onedim_obj.OutputOneDimArr(out_arr);

                            int value = 2;
                            Console.WriteLine($"\nМассив, умноженный на значение: {value}: ");
                            onedim_obj.MultiArr(value);
                            onedim_obj.OutputOneDimArr();

                            Console.WriteLine($"\nКоличество максимальных элементов в одномерном массиве: {onedim_obj.MaxCount()}");
                            Console.WriteLine($"\nЧастота вхождения каждого элемента в массив:");

                            Tuple<int[], int[]> result_tuple = onedim_obj.ElemOccurences();
                            for (int i = 0; i < result_tuple.Item1.Length; i++)
                            {
                                Console.WriteLine($"Элемент: {result_tuple.Item1[i]} число его вхождений в массив = {result_tuple.Item2[i]}");
                            }

                            break;

                        case 4:
                            output_help.OutputTaskText("Решить задачу с логинами из урока 2, только логины и пароли считать из файла в массив." +
                                "\nСоздайте структуру Account, содержащую Login и Password.", 4);

                            bool auth = false;
                            int counter = 3;

                            //Решение задачи с помощью класса
                            do
                            {
                                //Console.WriteLine("Введите логин: ");
                                //string login = Console.ReadLine();
                                //Console.WriteLine("Введите пароль: ");
                                //string password = Console.ReadLine();

                                Auth auth_obj = new Auth("login_password.txt");

                                if (auth_obj.Authorize())
                                {
                                    Console.WriteLine($"Вы успешно авторизованы");
                                    break;
                                }
                                else
                                {
                                    counter -= 1;
                                    Console.WriteLine($"К сожалению вы неправильно ввели логин и/или пароль, у вас осталось {counter} попыток");
                                }

                            } while (counter > 0 && !auth);

                            //Решение задачи с помощью структуры
                            AuthStruct auth_str;
                            auth_str.correct_login = "root";
                            auth_str.correct_password = "GeekBrains";
                            auth_str.file_path = "login_password.txt";

                            do
                            {

                                if (auth_str.AuthFromFile())
                                {
                                    Console.WriteLine($"Вы успешно авторизованы");
                                    break;
                                }
                                else
                                {
                                    counter -= 1;
                                    Console.WriteLine($"К сожалению вы неправильно ввели логин и/или пароль, у вас осталось {counter} попыток");
                                }

                            } while (counter > 0 && !auth);

                            break;
                        case 5:

                            output_help.OutputTaskText("*а) Реализовать библиотеку с классом для работы с двумерным массивом. Реализовать конструктор, заполняющий массив случайными числами." +
                                "\nСоздать методы, которые возвращают сумму всех элементов массива, сумму всех элементов массива больше заданного, свойство," +
                                "\nвозвращающее минимальный элемент массива," +
                                "\nсвойство, возвращающее максимальный элемент массива, метод, возвращающий номер максимального элемента массива" +
                                "\n(через параметры, используя модификатор ref или out)." +
                                "\n* *б) Добавить конструктор и методы, которые загружают данные из файла и записывают данные в файл." +
                                "\n* *в) Обработать возможные исключительные ситуации при работе с файлами.", 5);



                            //TwoDimArr twodim_obj = new TwoDimArr("two_dim_arr_test_0.txt", true);
                            TwoDimArr twodim_obj = new TwoDimArr("two_dim_arr_test_1.txt", false);

                            Console.WriteLine($"Исходный массив: ");
                            twodim_obj.OutputTwoDimArr();
                            Console.WriteLine($"\nСумма всех элементов массива: {twodim_obj.SumAllElements()}");

                            int given_v = 6;
                            Console.WriteLine($"\nСумма всех элементов массива больше чем: {given_v} = {twodim_obj.SumAllElementsLargerGivenValue(given_v)} ");
                            Console.WriteLine($"\nМаксимальный элемент массива: {twodim_obj.Max} - минимальный элемент массива:{twodim_obj.Min}");
                            int max_i = 0;
                            int max_j = 0;

                            twodim_obj.MaxElemNumber(ref max_i, ref max_j);
                            Console.WriteLine($"Максимальное значение массива находится на {max_i}-й строке и {max_j}-м столбце ");

                            string file_path_out = "two_dim_arr_output.txt";
                            Console.WriteLine($"Массив записан в файл: {file_path_out}");
                            twodim_obj.WriteResultToFile(file_path_out);

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
