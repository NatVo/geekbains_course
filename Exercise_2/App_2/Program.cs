using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_2
{
    class Program
    {
        static int MinNumber(int a, int b, int c)
        {
            int min = a;

            if (b < min)
                min = b;
            if (c < min)
                min = c;

            return min;

        }

        static int NumOfDigits(int number)
        {
            int sum = 0;
            while (number != 0)
            {
                sum += 1;
                number /= 10;
            }
            return sum;
        }


        static int CountOddPositiveNum()
        {

            Console.WriteLine("Введите число:");
            string num_line = Console.ReadLine();
            int num;
            int sum = 0;

            while (Int32.TryParse(num_line, out num))
            {

                num = Convert.ToInt32(num_line);
                if (num != 0)
                {
                    if (num % 2 != 0 && num > 0)
                        sum += num;
                } else
                {
                    Console.WriteLine("\nПрограмма завершила свою работу");
                    break;

                }

                Console.WriteLine("Введите число:");
                num_line = Console.ReadLine();

            }

            return sum;
           

        }
        static bool Authorize(string login, string password)
        {
            string correct_login = "root";
            string correct_password = "GeekBrains";

            if (login == correct_login && correct_password == password)
                return true;
            else
                return false;

        }

        static void CheckIndx(double h, double w)
        {
            double indx = w / (h * h);
            Console.WriteLine($"Индекс массы тела составляет: {indx:N2} ");

            if (indx < 18.5)
                Console.WriteLine($"Необходимо набрать хотя бы {(18.5 * Math.Pow(h, 2) - w):N4} кг до нижней границы нормы (равной 18,5) индекса массы тела");
            else if (indx > 24)
                Console.WriteLine($"Необходимо сбросить хотя бы {(w - 24 * Math.Pow(h, 2)):N4} кг до верхней границы нормы (равной 24) индекса массы тела ");
            else
                Console.WriteLine("Ваш вес находится в пределах нормы");
        }

        static int SumOfDigits(int number)
        {
            int sum = 0;
            while (number != 0)
            {
                sum += number % 10;
                number /= 10;
            }
            return sum;
        }

        static int GoodNumbers(int a, int n)
        {
            int counter = 0;
            for (int i = a; i < n; i++)
            {
                int sum = SumOfDigits(i);
                if (i % sum == 0)
                {
                    //if (i < 1000)
                    //    Console.WriteLine($"{i} - {sum} - {i % sum} ");
                    counter += 1;
                }

            }
            return counter;
        }

        static int RecursiveOutput(int a, int b)
        {
            Console.Write(a + " ");
            if (a == b) return a;
            return RecursiveOutput(a + 1, b);
        }

        static int RecursiveSum(int a, int b)
        {
            //Console.WriteLine(b);
            if (b == a) return a;
            if (b < a) return 0;
            return b + RecursiveSum(a, b-1);
        }
        static void Main(string[] args)
        {

            OutputHelp output_help = new OutputHelp();
            output_help.OutputName("Наталья", "Воробьева");

            Console.WriteLine("Нажмите Esc для выхода, любую кнопку - для продолжения работы");
            while (Console.ReadKey().Key != ConsoleKey.Escape)
            {

                Console.WriteLine("\nВыберите задачу, введите номер от 1 до 7:");
                string task = Console.ReadLine();
                int task_num;

                if (Int32.TryParse(task, out task_num))
                {
                    task_num = Convert.ToInt32(task);

                    switch (task_num)
                    {
                        case 1:
                            output_help.OutputTaskText("Написать метод, возвращающий минимальное из трех чисел.", 1);

                            Console.WriteLine("Введите целое число a: ");
                            string a_input = Console.ReadLine();
                            Console.WriteLine("Введите целое число b: ");
                            string b_input = Console.ReadLine();
                            Console.WriteLine("Введите целое число c: ");
                            string c_input = Console.ReadLine();

                            int a_num;
                            int b_num;
                            int c_num;

                            //Проверка на корректность ввода (что это числовые значения)
                            if (!Int32.TryParse(a_input, out a_num) || !Int32.TryParse(b_input, out b_num) || !Int32.TryParse(c_input, out c_num))
                            {
                                Console.WriteLine("Данные были введены некорректно!");
                            }
                            else
                            {

                                a_num = Convert.ToInt32(a_input);
                                b_num = Convert.ToInt32(b_input);
                                c_num = Convert.ToInt32(c_input);

                                int min = MinNumber(a_num, b_num, c_num);
                                Console.WriteLine($"Минимальное число среди чисел {a_num}, {b_num} и {c_num} - это {min}");

                            }
                            break;
                        case 2:
                            output_help.OutputTaskText("Написать метод подсчета количества цифр числа.", 2);

                            Console.WriteLine("Введите целое число a: ");
                            string num_line = Console.ReadLine();
                            int num;

                            //Проверка на корректность ввода (что это числовые значения)
                            if (!Int32.TryParse(num_line, out num))
                            {
                                Console.WriteLine("Число было введено некорректно!");
                            }
                            else
                            {

                                num = Convert.ToInt32(num_line);
                                int digits_num = NumOfDigits(num);
                                Console.WriteLine($"Количество цифр числа {num} составляет: {digits_num}");

                            }
                            break;
                        case 3:
                            output_help.OutputTaskText("С клавиатуры вводятся числа, пока не будет введен 0." +
                                "\nПодсчитать сумму всех нечетных положительных чисел.", 3);

                            int sum = CountOddPositiveNum();
                            Console.WriteLine($"Сумма всех введенных нечетных положительных чисел равна: {sum}");
                            break;
                        case 4:
                            output_help.OutputTaskText("Реализовать метод проверки логина и пароля. На вход подается логин и пароль." +
                                "\nНа выходе истина, если прошел авторизацию, и ложь, если не прошел" +
                                "\n(Логин: root, Password: GeekBrains)." +
                                "\nИспользуя метод проверки логина и пароля, написать программу:" +
                                "\nпользователь вводит логин и пароль, программа пропускает его дальше или не пропускает." +
                                "\nС помощью цикла do while ограничить ввод пароля тремя попытками.", 4);

                            bool auth = false;
                            int counter = 3;
                            do
                            {
                                Console.WriteLine("Введите логин: ");
                                string login = Console.ReadLine();
                                Console.WriteLine("Введите пароль: ");
                                string password = Console.ReadLine();

                                auth = Authorize(login, password);

                                if (auth)
                                    Console.WriteLine($"Вы успешно авторизованы");
                                else
                                {
                                    counter -= 1;
                                    Console.WriteLine($"К сожалению вы неправильно ввели логин и/или пароль, у вас осталось {counter} попыток");
                                }

                            } while (counter > 0 && !auth);

                            break;
                        case 5:
                            output_help.OutputTaskText("а) Написать программу, которая запрашивает массу и рост человека," +
                                "\nвычисляет его индекс массы и сообщает, нужно ли человеку похудеть, набрать вес или все в норме;" +
                                "\nб) * Рассчитать, на сколько кг похудеть или сколько кг набрать для нормализации веса.", 5);

                            Console.WriteLine("Введите рост в метрах: ");
                            string height_l = Console.ReadLine();
                            Console.WriteLine("Введите вес в кг: ");
                            string weight_l = Console.ReadLine();

                            double h;
                            double w;


                            //Проверка на корректность ввода веса и роста (что это числовые значения)
                            if (!Double.TryParse(height_l, out h) || !Double.TryParse(weight_l, out w))
                            {
                                Console.WriteLine("Данные были введены некорректно!");
                            }
                            else
                            {
                                h = Convert.ToDouble(height_l);
                                w = Convert.ToDouble(weight_l);

                                //Проверка, что пользователь ввел положительные числа и не 0
                                if (h > 0 && w > 0)
                                    CheckIndx(h, w);
                                else
                                    Console.WriteLine("Значения роста и веса должны быть положительными!");
                            }
                            break;
                        case 6:
                            output_help.OutputTaskText("*Написать программу подсчета количества «Хороших» чисел в диапазоне от 1 до 1 000 000 000." +
                                "\nХорошим называется число, которое делится на сумму своих цифр." +
                                "\nРеализовать подсчет времени выполнения программы, используя структуру DateTime.", 6);

                            DateTime start = DateTime.Now;
                            int good_num_count = GoodNumbers(1, 1000000000);
                            Console.WriteLine($"Найдено хороших чисел в диапазоне (1, 1 000 000 000): {good_num_count}" +
                                $"\nЗатрачено времени на решение задачи: {DateTime.Now - start}");
                            break;
                        case 7:
                            output_help.OutputTaskText("a) Разработать рекурсивный метод, который выводит на экран числа от a до b (a<b);" +
                                "\nб) * Разработать рекурсивный метод, который считает сумму чисел от a до b.", 7);

                            Console.WriteLine("Введите целое число a: ");
                            string a_line = Console.ReadLine();
                            Console.WriteLine("Введите целое число b: ");
                            string b_line = Console.ReadLine();

                            int a;
                            int b;

                            if (!Int32.TryParse(a_line, out a) || !Int32.TryParse(b_line, out b))
                            {
                                Console.WriteLine("Данные были введены некорректно!");
                            }
                            else
                            {

                                a = Convert.ToInt32(a_line);
                                b = Convert.ToInt32(b_line);

                                if (a > b)
                                    Console.WriteLine("Число a должно быть меньше b!");
                                else
                                {
                                    Console.WriteLine($"Все числа в промежутке от {a} и {b} (включая a и b) :");
                                    //Метод рекурсивного вывода:
                                    RecursiveOutput(a, b);
                                    //Метод рекурсивного подсчета суммы:
                                    int result = RecursiveSum(a, b);
                                    Console.WriteLine($"\nСумма чисел от a={a} до b={b} (включая a и b) : {result}");
                                }
                            }
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
            Console.WriteLine($"\nЗадание № {task_num}\n");
            Console.WriteLine($"{text}\n");
        }
        //вывод исполнителя работы
        public void OutputName(string name, string surname)
        {
            Console.WriteLine($"Задание выполнил(а): {name} {surname}\n");
        }

    }
}
