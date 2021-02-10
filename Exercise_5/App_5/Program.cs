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
                    //Console.WriteLine((int)login[i]);
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

               
        static void Main(string[] args)
        {

            OutputHelp output_help = new OutputHelp();
            output_help.OutputName("Наталья", "Воробьева");


            string login = "chsFWdkj_2ekps3i2o";

            if (CheckLogin(login))
                Console.WriteLine($"Введенный логин отвечает заданным требованиям!");
            else
                Console.WriteLine($"Введенный логин не отвечает заданным требованиям!");


            if (CheckLoginReg(login))
                Console.WriteLine($"Введенный логин отвечает заданным требованиям!");
            else
                Console.WriteLine($"Введенный логин не отвечает заданным требованиям!");
            Console.WriteLine();
            //----------------------------------------------------------------------------------------
            string file_path = "test_text.txt";
            string text = GetTextFromFile(file_path);
            Console.WriteLine($"Исходная строка: {text}");
            Console.WriteLine();

            //Message.OutputWordsOfGivenLength(text, 8);
            Message.FindMaxWord(text);

            //Message.RemoveExtraWord(text, 't');
            Message.OutputMaxWords(text);

            output_help.Pause();
        }
    }
}
