using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_1
{
    class Program
    {

        static double FindDistance(double x1, double y1, double x2, double y2)
        {
            double result = Math.Sqrt(Math.Pow((x2 - x1), 2) + Math.Pow((y2 - y1), 2));
            return result;
        }

        static void ExchangeSimple(int a, int b)
        {
            Console.WriteLine($"Начальные значения переменных - a: {a} b: {b}");
            int c = a;
            a = b;
            b = c;
            Console.WriteLine($"Значения переменных после персетановки местами - a: {a} b: {b}");

        }

        static void Exchange(int a, int b)
        {
            Console.WriteLine($"Начальные значения переменных - a: {a} b: {b}");
            a = a + b;
            b = a - b;
            a = a - b;
            Console.WriteLine($"Значения переменных после персетановки местами - a: {a} b: {b}");

        }

        static void OutputInCenter(string name, string surname, string city)
        {
            string result_line = $"{name} {surname} {city}\n";

            Console.SetCursorPosition((Console.WindowWidth - result_line.Length) / 2, Console.CursorTop);
            Console.WriteLine(result_line);
        }


        static void Main(string[] args)
        {
            //создаем экземпляр класса OutputHelp, со вспомогательными методами (см. задание 6)
            OutputHelp output_help = new OutputHelp();

            output_help.OutputName("Наталья", "Воробьева");

            //Задание 1
            output_help.OutputTaskText("Написать программу «Анкета».\n" +
                "Последовательно задаются вопросы (имя, фамилия, возраст, рост, вес)." +
                "\nВ результате вся информация выводится в одну строчку." +
                "\nа) используя склеивание;" +
                "\nб) используя форматированный вывод;" +
                "\nв) *используя вывод со знаком $.", 1);

            Console.WriteLine("Введите свое имя: ");
            string name = Console.ReadLine();
            Console.WriteLine("Введите свою фамилию: ");
            string surname = Console.ReadLine();
            Console.WriteLine("Введите свой возраст (полных лет): ");
            string age_line = Console.ReadLine();
            Console.WriteLine("Введите свой рост: ");
            string height_line = Console.ReadLine();
            Console.WriteLine("Введите свой вес: ");
            string weight_line = Console.ReadLine();

            int age;
            double height;
            double weight;

            //Проверка на корректность ввода возраста, веса и роста
            if (!Int32.TryParse(age_line, out age) || !Double.TryParse(height_line, out height) || !Double.TryParse(weight_line, out weight))
            {
                Console.WriteLine("Данные были введены некорректно!");
            }
            else
            {

                age = Convert.ToInt32(age_line);
                height = Convert.ToDouble(height_line);
                weight = Convert.ToDouble(weight_line);

                //Проверка, что пользователь ввел положительные числа и не 0
                if (age > 0 && height > 0 && weight > 0)
                {
                    //а) вывод с использованием обычного склеивания:
                    Console.WriteLine("Имя: " + name + ", Фамилия: " + surname + ", Возраст: " + age.ToString() + ", Рост: " + height.ToString() + ", Вес: " + weight.ToString()); ;
                    //б) вывод с использованием форматирования:
                    Console.WriteLine("Имя: {0}, Фамилия: {1}, Возраст {2}, Рост: {3:N2}, Вес: {4:N2}", name, surname, age, height, weight);
                    // вывод с использовнаием $:
                    Console.WriteLine($"Имя: {name}, Фамилия: {surname}, Возраст: {age}, Рост: {height:N2}, Вес: {weight:N2}");
                }
                else
                {
                    Console.WriteLine("Значения возраста, роста и веса должны быть положительными!");
                }
            }

            //Задание 2

            output_help.OutputTaskText("Ввести вес и рост человека." +
                "\nРассчитать и вывести индекс массы тела (ИМТ)" +
                "\nпо формуле I=m/(h*h); где m — масса тела в килограммах, h — рост в метрах.", 2);

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
                {
                    double indx = w / (h * h);
                    Console.WriteLine("Индекс массы тела составляет: {0:N2} ", indx);
                }
                else
                {
                    Console.WriteLine("Значения роста и веса должны быть положительными!");
                }
            }

            //Задание 3
            output_help.OutputTaskText("а)Написать программу, которая подсчитывает расстояние между точками" +
                "\nс координатами x1, y1 и x2,y2 по формуле r=Math.Sqrt(Math.Pow(x2-x1,2)+Math.Pow(y2-y1,2)." +
                "\nВывести результат, используя спецификатор формата .2f (с двумя знаками после запятой);" +
                "\nб) * Выполните предыдущее задание, оформив вычисления расстояния между точками в виде метода.", 3);


            Console.WriteLine("Введите координату x 1-й точки: ");
            string x1_line = Console.ReadLine();
            Console.WriteLine("Введите координату y 1-й точки: ");
            string y1_line = Console.ReadLine();
            Console.WriteLine("Введите координату x 2-й точки: ");
            string x2_line = Console.ReadLine();
            Console.WriteLine("Введите координату y 2-й точки: ");
            string y2_line = Console.ReadLine();

            double x1, x2;
            double y1, y2;

            //Проверка на корректность ввода координат точек (что это числовые значения)
            if (!Double.TryParse(x1_line, out x1) || !Double.TryParse(y1_line, out y1) ||
                !Double.TryParse(x2_line, out x2) || !Double.TryParse(y2_line, out y2))
            {
                Console.WriteLine("Данные были введены некорректно!");
            }
            else
            {

                x1 = Convert.ToDouble(x1_line);
                y1 = Convert.ToDouble(y1_line);
                x2 = Convert.ToDouble(x2_line);
                y2 = Convert.ToDouble(y2_line);

                double result = Math.Sqrt(Math.Pow((x2 - x1), 2) + Math.Pow((y2 - y1), 2));
                //а) Обычный расчет результата
                Console.WriteLine("Расстояние между точками составляет: {0:N2} ", result);
                //б) Расчет результата с помощью метода FindDistance
                Console.WriteLine("Расстояние между точками составляет: {0:N2} ", FindDistance(x1, y1, x2, y2));

            }

            //Задание 4
            output_help.OutputTaskText("Написать программу обмена значениями двух переменных." +
                "\nа) с использованием третьей переменной;" +
                "\nб) *без использования третьей переменной.", 4);

            int a = 10;
            int b = 20;
            //обмен значений с использованием третьей переменной:
            ExchangeSimple(a, b);
            //обмен значений без использования третьей переменной:
            Exchange(a, b);


            //Задание 5
            output_help.OutputTaskText("а) Написать программу, которая выводит на экран ваше имя, фамилию и город проживания." +
                "\nб) Сделать задание, только вывод организуйте в центре экрана" +
                "\nв) *Сделать задание б с использованием собственных методов(например, Print(string ms, int x, int y)", 5);


            string my_name = "Наталья";
            string my_surname = "Воробьева";
            string my_city = "г. Йошкар-Ола";

            string result_line = $"{my_name} {my_surname} {my_city}\n";
            //Обычный вывод 
            Console.WriteLine(result_line);
            Console.SetCursorPosition((Console.WindowWidth - result_line.Length) / 2, Console.CursorTop);
            //Вывод по центру экрана консоли
            Console.WriteLine(result_line);
            //Вывод по центру экрана консоли с использованием метода OutputInCenter
            OutputInCenter(my_name, my_surname, my_city);

            //Задание 6, см класс OutputHelp
            //*Создать класс с методами, которые могут пригодиться в вашей учебе (Print, Pause).
            output_help.OutputTaskText("*Создать класс с методами, которые могут пригодиться в вашей учебе (Print, Pause).", 6);

            output_help.Pause();            

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
