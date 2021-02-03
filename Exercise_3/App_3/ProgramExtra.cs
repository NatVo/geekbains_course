using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_3
{
    class Fraction
    {
        int ch_1, ch_2;
        int zn_1, zn_2;

        int res_ch, res_zn;

        public int getChisl()
        {
            return res_ch;
        }

        public int getZnam()
        {
            return res_zn;
        }

        public double getDecimal(int ch, int zn)
        {
            double res = (double)ch / (double)zn;
            return res;
        }

        private static Tuple<int, int> CheckFractionSign(int ch, int zn)
        {
            if (((float)ch / (float)zn) < 0)
                return new Tuple<int, int>(-1 * Math.Abs(ch), Math.Abs(zn));
            else
                return new Tuple<int, int>(Math.Abs(ch), Math.Abs(zn));
        }

        public bool CheckIfInputIsCorrect(string ch_line_1, string zn_line_1,
                                          string ch_line_2, string zn_line_2)
        {
            if (!Int32.TryParse(ch_line_1, out ch_1) || !Int32.TryParse(zn_line_1, out zn_1)
                || !Int32.TryParse(ch_line_2, out ch_2) || !Int32.TryParse(zn_line_2, out zn_2))
            {
                Console.WriteLine("Данные были введены некорректно!");
                return false;
            }
            else
            {
                ch_1 = Convert.ToInt32(ch_line_1);
                zn_1 = Convert.ToInt32(zn_line_1);
                ch_2 = Convert.ToInt32(ch_line_2);
                zn_2 = Convert.ToInt32(zn_line_2);

                //Проверка, что пользователь ввел положительные числа и не 0
                if (zn_1 != 0 || zn_2 != 0)
                {
                    var result_1 = CheckFractionSign(ch_1, zn_1);
                    ch_1 = result_1.Item1;
                    zn_1 = result_1.Item2;
                    var result_2 = CheckFractionSign(ch_2, zn_2);
                    ch_2 = result_2.Item1;
                    zn_2 = result_2.Item2;
                    Console.WriteLine($"\nДробь 1: {ch_1}/{zn_1}");
                    Console.WriteLine($"Дробь 2: {ch_2}/{zn_2}");
                    return true;
                }

                else
                {
                    Console.WriteLine("Значения знаменателей не должны быть равны 0!");
                    return false;
                }

            }
        }

        private static int FindNOD(int num_1, int num_2)
        {
            if (num_2 == 0)
                return num_1;
            else
                return FindNOD(num_2, num_1 % num_2);
        }

        private static int FindNOK(int num_1, int num_2)
        {
            int x = num_1;
            int y = num_2;
            while (num_1 != num_2)
            {
                if (num_1 > num_2)
                    num_1 = num_1 - num_2;
                else
                    num_2 = num_2 - num_1;

            }
            return (x * y) / num_1;
        }

        public void SumResFractions(bool flag_is_sum)
        {
            //int sum_ch;
            string act = "Сумма";
            string sign = "+";

            int nok = FindNOK(zn_1, zn_2);
            res_zn = nok;

            if (flag_is_sum)
                res_ch = (nok / zn_1) * ch_1 + (nok / zn_2) * ch_2;
            else
            { res_ch = (nok / zn_1) * ch_1 - (nok / zn_2) * ch_2; act = "Разность"; sign = "-"; }

            int nod = FindNOD(Math.Abs(res_ch), Math.Abs(res_zn));

            if (nod > 1)
                Console.WriteLine($"{act} дробей {ch_1}/{zn_1} {sign} {ch_2}/{zn_2} = {res_ch}/{res_zn} = {(res_ch / nod)}/{(res_zn / nod)}");
            else
                Console.WriteLine($"{act} дробей {ch_1}/{zn_1} {sign} {ch_2}/{zn_2} = {res_ch}/{res_zn}");

        }

        public void MultFractions()
        {
            res_ch = ch_1 * ch_2;
            res_zn = zn_1 * zn_2;

            var result = CheckFractionSign(res_ch, res_zn);
            res_ch = result.Item1;
            res_zn = result.Item2;

            int nod = FindNOD(Math.Abs(res_ch), Math.Abs(res_zn));

            if (nod > 1)
            {
                Console.WriteLine($"Произведение дробей {ch_1}/{zn_1} * {ch_2}/{zn_2} = {res_ch}/{res_zn} = {(res_ch / nod)}/{(res_zn / nod)}");
                res_ch /= nod;
                res_zn /= nod;
            }

            else
                Console.WriteLine($"Произведение дробей {ch_1}/{zn_1} * {ch_2}/{zn_2} = {res_ch}/{res_zn}");

        }

        public void DivideFractions()
        {
            res_ch = ch_1 * zn_2;
            res_zn = zn_1 * ch_2;

            var result = CheckFractionSign(res_ch, res_zn);
            res_ch = result.Item1;
            res_zn = result.Item2;

            int nod = FindNOD(Math.Abs(res_ch), Math.Abs(res_zn));

            if (nod > 1)
            {

                Console.WriteLine($"Деление дробей {ch_1}/{zn_1} / {ch_2}/{zn_2} = {res_ch}/{res_zn} = {(res_ch / nod)}/{(res_zn / nod)}");
                res_ch /= nod;
                res_zn /= nod;
            }

            else
                Console.WriteLine($"Деление дробей {ch_1}/{zn_1} / {ch_2}/{zn_2} = {res_ch}/{res_zn}");

        }
    }

    struct Complex
    {
        public double im;
        public double re;
        //  в C# в структурах могут храниться также действия над данными
        public Complex Plus(Complex x)
        {
            Complex y;
            y.im = im + x.im;
            y.re = re + x.re;
            return y;
        }

        public Complex Minus(Complex x)
        {

            Complex y;
            y.im = im - x.im;
            y.re = re - x.re;
            return y;
        }
        //  Пример произведения двух комплексных чисел
        public Complex Multi(Complex x)
        {
            Complex y;
            y.im = re * x.im + im * x.re;
            y.re = re * x.re - im * x.im;
            return y;
        }
        public string ToString()
        {

            string result;

            if (im < 0)
                result = re + "" + im + "i";
            else
                result = re + "+" + im + "i";
            return result;
            //return + re + "+" + im + "i";
        }
    }

    class ComplexClass
    {
        // Все методы и поля публичные. Мы можем получить доступ к ним из другого класса.
        public double im;
        public double re;

        public ComplexClass Plus(ComplexClass x2)
        {
            ComplexClass x3 = new ComplexClass();
            x3.im = x2.im + this.im;
            x3.re = x2.re + this.re;
            return x3;
        }

        public ComplexClass Minus(ComplexClass x2)
        {
            ComplexClass x3 = new ComplexClass();

            x3.im = this.im - x2.im;
            x3.re = this.re - x2.re;
            return x3;
        }

        public ComplexClass Multi(ComplexClass x2)
        {
            ComplexClass x3 = new ComplexClass();
            x3.im = this.re * x2.im + this.im * x2.re;
            x3.re = this.re * x2.re - this.im * x2.im;
            return x3;
        }

        public string ToString()
        {
            string result;

            if (im < 0)
                result = re + "" + im + "i";
            else
                result = re + "+" + im + "i";
            return result;
            //return re + "+" + im + "i";
        }
    }

    class SumOddNum
    {
        public void CountSum()
        {
            Console.WriteLine("\nВведите число:");
            string num_line = Console.ReadLine();
            string odd_nums = "";
            int num;
            int sum = 0;

            while (num_line != "0")
            {
                if (Int32.TryParse(num_line, out num))
                {
                    num = Convert.ToInt32(num_line);
                    if (num % 2 != 0 && num > 0)
                    {
                        sum += num;
                        odd_nums += num.ToString() + ", ";
                    }

                }
                else
                {
                    Console.WriteLine("Некооректный ввод! Введите пожалуйста целое число!");
                }
                Console.WriteLine("Введите число:");
                num_line = Console.ReadLine();

            }
            Console.WriteLine("\nПрограмма завершила свою работу");
            Console.WriteLine($"Перечень нечетных положительных чисел: {odd_nums} - их сумма: {sum}");


        }
    }


    class ProgramExtra
    {
        static void Main(string[] args)
        {


            OutputHelp output_help = new OutputHelp();
            output_help.OutputName("Наталья", "Воробьева");

            Console.WriteLine("Нажмите Esc для выхода, любую кнопку - для продолжения работы");
            while (Console.ReadKey().Key != ConsoleKey.Escape)
            {

                Console.WriteLine("\nВыберите задачу, введите номер от 1 до 3:");
                string task = Console.ReadLine();
                int task_num;

                if (Int32.TryParse(task, out task_num))
                {
                    task_num = Convert.ToInt32(task);

                    switch (task_num)
                    {
                        case 1:
                            output_help.OutputTaskText("а)Дописать структуру Complex, добавив метод вычитания комплексных чисел. Продемонстрировать работу структуры;" +
                                "\nб) Дописать класс Complex, добавив методы вычитания и произведения чисел. Проверить работу класса;" +
                                "\nв) Добавить диалог с использованием switch демонстрирующий работу класса.", 1);

                            Console.WriteLine("\nВыберите вариант решения задачи, 1 - структура, 2 - класс:");
                            string complex_line = Console.ReadLine();
                            int complex_var;
                            
                            if (Int32.TryParse(complex_line, out complex_var))
                            {
                                complex_var = Convert.ToInt32(complex_var);
                                switch (complex_var)
                                {
                                    case 1:
                                        Complex complex_1;
                                        complex_1.re = 5;
                                        complex_1.im = -6;

                                        Complex complex_2;
                                        complex_2.re = -3;
                                        complex_2.im = 2;

                                        Complex result = complex_1.Plus(complex_2);
                                        Console.WriteLine($"Сумма комплексных чисел: ({complex_1.ToString()}) + ({complex_2.ToString()}) = {result.ToString()}");
                                        result = complex_1.Minus(complex_2);
                                        Console.WriteLine($"Разность комплексных чисел: ({complex_1.ToString()}) - ({complex_2.ToString()}) = {result.ToString()}");
                                        result = complex_1.Multi(complex_2);
                                        Console.WriteLine($"Произведение комплексных чисел: ({complex_1.ToString()}) * ({complex_2.ToString()}) = {result.ToString()}");
                                        break;

                                    case 2:
                                        ComplexClass complex_cl_1 = new ComplexClass();
                                        complex_cl_1.re = 5;
                                        complex_cl_1.im = -6;

                                        ComplexClass complex_cl_2 = new ComplexClass();
                                        complex_cl_2.re = -3;
                                        complex_cl_2.im = 2;

                                        Console.WriteLine($"\nИсходные комплексные числа: ({complex_cl_1.ToString()}) и ({complex_cl_2.ToString()})" +
                                                          $"\nВыберите действие, 1 - сумма, 2 - разность, 3 - произведение:");
                                        
                                        string complex_act_line = Console.ReadLine();
                                        int complex_act;

                                        if (Int32.TryParse(complex_act_line, out complex_act))
                                        {
                                            complex_act = Convert.ToInt32(complex_act_line);
                                            ComplexClass result_cl;

                                            switch (complex_act)
                                            {
                                                case 1:
                                                    result_cl = complex_cl_1.Plus(complex_cl_2);
                                                    Console.WriteLine($"\nСумма комплексных чисел: ({complex_cl_1.ToString()}) + ({complex_cl_2.ToString()}) = {result_cl.ToString()}");
                                                    break;
                                                case 2:
                                                    result_cl = complex_cl_1.Minus(complex_cl_2);
                                                    Console.WriteLine($"Разность комплексных чисел: ({complex_cl_1.ToString()}) - ({complex_cl_2.ToString()}) = {result_cl.ToString()}");
                                                    break;
                                                case 3:
                                                    result_cl = complex_cl_1.Multi(complex_cl_2);
                                                    Console.WriteLine($"Произведение комплексных чисел: ({complex_cl_1.ToString()}) * ({complex_cl_2.ToString()}) = {result_cl.ToString()}");
                                                    break;
                                                default:
                                                    Console.WriteLine("Задачи под таким номером не существует!");
                                                    break;

                                            }
                                        }
                                        else
                                            Console.WriteLine("Некорректный ввод номера действия!");

                                        break;
                                    default:
                                        Console.WriteLine("Варианта решения задачи под введеным номером не существует!");
                                        break;
                                }

                            }
                            else
                                Console.WriteLine("Некорректный ввод номера задачи!");


                            
                            break;
                        case 2:
                            output_help.OutputTaskText("2. а) С клавиатуры вводятся числа, пока не будет введен 0 (каждое число в новой строке). " +
                                "\nТребуется подсчитать сумму всех нечетных положительных чисел. Сами числа и сумму вывести на экран, используя tryParse;" +
                                "\nб) Добавить обработку исключительных ситуаций на то, что могут быть введены некорректные данные." +
                                "\nПри возникновении ошибки вывести сообщение.Напишите соответствующую функцию;.", 2);

                            SumOddNum sum_odd_obj = new SumOddNum();
                            sum_odd_obj.CountSum();

                            break;
                        case 3:
                            output_help.OutputTaskText("*Описать класс дробей - рациональных чисел, являющихся отношением двух целых чисел." +
                                "\nПредусмотреть методы сложения, вычитания, умножения и деления дробей." +
                                "\nНаписать программу, демонстрирующую все разработанные элементы класса." +
                                "\n* Добавить свойства типа int для доступа к числителю и знаменателю;" +
                                "\n* Добавить свойство типа double только на чтение, чтобы получить десятичную дробь числа;" +
                                "\n**Добавить проверку, чтобы знаменатель не равнялся 0.Выбрасывать исключение" +
                                "\nArgumentException(Знаменатель не может быть равен 0);Добавить упрощение дробей.", 3);

                            Console.WriteLine("Введите числитель 1-й дроби: ");
                            string ch_line_1 = Console.ReadLine();
                            Console.WriteLine("Введите знаменатель 1-й дроби: ");
                            string zn_line_1 = Console.ReadLine();
                            Console.WriteLine("Введите числитель 2-й дроби: ");
                            string ch_line_2 = Console.ReadLine();
                            Console.WriteLine("Введите знаменатель 2-й дроби: ");
                            string zn_line_2 = Console.ReadLine();

                            Fraction obj_fr = new Fraction();
                            if (obj_fr.CheckIfInputIsCorrect(ch_line_1, zn_line_1, ch_line_2, zn_line_2))
                            {
                                obj_fr.SumResFractions(true);
                                obj_fr.SumResFractions(false);
                                obj_fr.MultFractions();
                                obj_fr.DivideFractions();
                                double decim = obj_fr.getDecimal(obj_fr.getChisl(), obj_fr.getZnam());
                                Console.WriteLine($"Десятичная дробь числа: {obj_fr.getChisl()}/{obj_fr.getZnam()} = {decim}");
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
