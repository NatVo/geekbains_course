using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_4
{
    class TwoDimArr
    {
        int N;
        int M;
        int[,] arr;

        int min_value = -100;
        int max_value = 100;

        Random rand_num = new Random();

        public int getN()
        {
            return N;
        }

        public int getM()
        {
            return N;
        }


        public TwoDimArr()
        {
            
            N = rand_num.Next(0, 100);
            M = rand_num.Next(0, 100);
            arr = new int[N, M];
            GenTwoDimArr(min_value, max_value);
        }
            
        public TwoDimArr(int n, int m)
        {
            N = n;
            M = m;
            arr = new int[N, M];
            GenTwoDimArr(min_value, max_value);

        }

        public TwoDimArr(int n, int m, int min_v, int max_v)
        {
            N = n;
            M = m;
           
            arr = new int[N, M];
            if (min_v <= max_v)
            {
                min_value = min_v;
                max_value = max_v;
            }
            else
            {                
                min_value = max_v;
                max_value = min_v;
            }
            GenTwoDimArr(min_value, max_value);

        }

        public TwoDimArr(string file_path, bool generate_arr)
        {
            //Вариант, когда в файле записана только информация о массиве, сам массив генерируется согласно считаным из файла параметрам
            if (generate_arr)

            {

                if (File.Exists(file_path))
                {
                    bool flag_n = false;
                    bool flag_m = false;

                    string[] f_lines = File.ReadAllLines(file_path);
                    for (int i = 0; i < f_lines.Length; i++)
                    {
                        try
                        {
                            string[] tokens = f_lines[i].Split('=');

                            if (tokens[0] == "N")
                            {
                                N = Convert.ToInt32(tokens[1]);
                                Console.WriteLine($"Значение количества строк матрицы N: {N} прочитано из файла: {file_path}");
                                flag_n = true;
                            }
                            else if (tokens[0] == "M")
                            {
                                M = Convert.ToInt32(tokens[1]);
                                Console.WriteLine($"Значение количества столбцов матрицы M: {M} прочитано из файла: {file_path}");
                                flag_m = true;
                            }
                            else if (tokens[0] == "max_value")
                            {
                                max_value = Convert.ToInt32(tokens[1]);
                                Console.WriteLine($"Максимальная величина диапазона генерируемых значений массива: {max_value} прочитана из файла: {file_path}");
                            }

                            else if (tokens[0] == "min_value")
                            {
                                min_value = Convert.ToInt32(tokens[1]);
                                Console.WriteLine($"Минимальная величина диапазона генерируемых значений массива: {min_value} прочитана из файла: {file_path}");
                            }

                        }
                        catch { }
                    }

                    if (!flag_n) { N = rand_num.Next(0, 100); }
                    if (!flag_m) { M = rand_num.Next(0, 100); }
                    arr = new int[N, M];

                    Console.WriteLine($"\nN:{N}\tM:{M}\tmax_value:{min_value}\tmin_value: {max_value}\n");
                    GenTwoDimArr(min_value, max_value);

                }
                else
                    Console.WriteLine($"Не получилось найти и открыть файл: {file_path}");

                //try
                //{

                //    string line;
                //    bool flag_n = false;
                //    bool flag_m = false;

                //    StreamReader str_r = new StreamReader(file_path);

                //    while ((line = str_r.ReadLine()) != null)
                //    {

                //        try
                //        {
                //            string[] tokens = line.Split('=');

                //            if (tokens[0] == "N")
                //            {
                //                N = Convert.ToInt32(tokens[1]);
                //                Console.WriteLine($"Значение количества строк матрицы N: {N} прочитано из файла: {file_path}");
                //                flag_n = true;
                //            }
                //            else if (tokens[0] == "M")
                //            {
                //                M = Convert.ToInt32(tokens[1]);
                //                Console.WriteLine($"Значение количества столбцов матрицы M: {M} прочитано из файла: {file_path}");
                //                flag_m = true;
                //            }
                //            else if (tokens[0] == "max_value")
                //            {
                //                max_value = Convert.ToInt32(tokens[1]);
                //                Console.WriteLine($"Максимальная величина диапазона генерируемых значений массива: {max_value} прочитана из файла: {file_path}");
                //            }

                //            else if (tokens[0] == "min_value")
                //            {
                //                min_value = Convert.ToInt32(tokens[1]);
                //                Console.WriteLine($"Максимальная величина диапазона генерируемых значений массива: {min_value} прочитана из файла: {file_path}");
                //            }

                //        }
                //        catch { }

                //    }

                //    str_r.Close();

                //    if (!flag_n) { N = rand_num.Next(0, 100); }
                //    if (!flag_m) { M = rand_num.Next(0, 100); }
                //    arr = new int[N, M];

                //    //Console.WriteLine($"\nN:{N} M:{M} max_value:{min_value} min_value: {max_value}\n");
                //    GenTwoDimArr(min_value, max_value);
                //}


                //catch
                //{
                //    Console.WriteLine($"Не получилось найти и открыть файл: {file_path}");
                //}
            }
            //Вариант, когда весь массив записан в файле и просто считывается
            else
            {
                if (File.Exists(file_path))
                {
                    //Считываем все строки в файл 

                    try
                    {
                        string[] f_lines = File.ReadAllLines(file_path);
                        string[] rows = f_lines[0].Split(' ');


                        M = rows.Length;
                        N = f_lines.Length;

                        arr = new int[N, M];

                        Console.WriteLine($"\nN:{N} M:{M} max_value:{min_value} min_value: {max_value}\n");


                        for (int i = 0; i < arr.GetLength(0); i++)
                        {
                            rows = f_lines[i].Split(' ');
                            for (int j = 0; j < rows.Length; j++)
                                try
                                {
                                    arr[i, j] = Convert.ToInt32(rows[j]);
                                }
                                catch { }
                                
                        }
                          
                    }
                    catch
                    {
                        Console.WriteLine($"Не получилось считать информацию из файла: {file_path}");
                    }
                    
                }
                else
                    Console.WriteLine($"При попытке считать файл: {file_path} произоiла ошибка");
            }
                        
        }



        public void GenTwoDimArr(int min, int max)
        {
            //Random rand_num = new Random();

            if (min < max)
            {
                for (int i = 0; i < N; i++)
                    for (int j = 0; j < M; j++)
                        arr[i, j] = rand_num.Next(min, max);
            } 
            else
            {
                Console.WriteLine("Минимальное значение диапазона для генераций значений массива" +
                    "\nне может быть больше или равно максимуальному значению");
            }

        }

        public int SumAllElements()
        {
            int sum = 0;
            foreach (int el in arr)
                sum += el;
            return sum;
        }

        public int SumAllElementsLargerGivenValue(int given_value)
        {
            int sum = 0;
            foreach (int el in arr)
            {
                if (el > given_value)
                    sum += el;
            }

            return sum;
        }

        public int Max
        {
            get
            {
                int max_elem = arr[0, 0];
                for (int i = 0; i < arr.GetLength(0); i++)
                    for (int j = 0; j < arr.GetLength(1); j++)
                        if (arr[i, j] > max_elem) max_elem = arr[i, j];
                return max_elem;
            }
        }

        public int Min
        {
            get
            {
                int min_elem = arr[0, 0];
                for (int i = 0; i < arr.GetLength(0); i++)
                    for (int j = 0; j < arr.GetLength(1); j++)
                        if (arr[i, j] < min_elem) min_elem = arr[i, j];
                return min_elem;
            }
        }

        public void MaxElemNumber(ref int max_i, ref int max_j)
        {
            int max_elem = Max;
            for (int i = 0; i < arr.GetLength(0); i++)
                for (int j = 0; j < arr.GetLength(1); j++)
                    if (arr[i, j] == max_elem)
                    {
                        max_i = i+1;
                        max_j = j+1;
                    }
        }

        public void OutputTwoDimArr()
        {
            Console.WriteLine();
            for (int i = 0; i < N; i++)
            {                
                for (int j = 0; j < M; j++)
                    Console.Write($"{arr[i, j]} \t");
                Console.WriteLine();
            }
        }

        public void WriteResultToFile(string file_output_path)
        {
            if (File.Exists(file_output_path))
                File.Delete(file_output_path);

            try
            {
                StreamWriter str_w = File.CreateText(file_output_path);

                string result_line;
                for (int i = 0; i < N; i++)
                {
                    result_line = "";
                    for (int j = 0; j < M; j++)
                        result_line += arr[i, j].ToString() + " \t";
                    str_w.WriteLine(result_line);
                }
                str_w.Close();


            }
            catch
            {
                Console.WriteLine($"При попытке создать файл: {file_output_path} для вывода результата произошла ошибка!");
            }

        }

        public int[,] GetTwoDimArr()
        {
            return arr;
        }


    }
}
