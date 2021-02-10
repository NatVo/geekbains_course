using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_4
{
    static class ArrayTestOne
    {
        public static void FindPairs(int N, int [] arr)
        {
            int counter = 0;
            Console.WriteLine();

            for (int i = 0; i < arr.Length - 1 ; i++)
            {
                if (arr[i] % 3 == 0 || arr[i + 1] % 3 == 0)
                {
                    Console.WriteLine($"{arr[i]} и {arr[i + 1]}");
                    counter += 1;
                }
                    
            }
            Console.WriteLine($"\nКоличество пар элементов массива, в которых только одно число делится на 3:  {counter}");
            
        }


        public static int[] InputFromFile(string file_path)
        {
            if (File.Exists(file_path))
            {
                string[] f_lines = File.ReadAllLines(file_path);

                if (f_lines.Length == 1)
                {
                    string[] elems = f_lines[0].Split(' ');
                    int [] arr = new int[elems.Length];

                    for (int i = 0; i < elems.Length; i++)
                    {
                        try
                        {
                            arr[i] = Convert.ToInt32(elems[i]);
                            
                        }
                        catch { }
                    }

                    foreach (int el in arr)
                        Console.Write($"{el} ");
                    Console.WriteLine();
                    return arr;

                }
                else
                {
                    Console.WriteLine($"\nОдномерный массив задан некорректно в файле: {file_path}");
                    return new int[0]; ;
                }

            }
            else
            {
                Console.WriteLine($"\nНе получилось найти и открыть файл: {file_path}");
                return new int[0];
            }
                

        }


    }
}
