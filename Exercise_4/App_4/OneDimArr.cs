using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_4
{


    class OneDimArr
    {

        int N;
        int[] arr;

        int min_value = -100;
        int max_value = 100;

        Random rand_num = new Random();

        public int getN()
        {
            return N;
        }


        public OneDimArr()
        {
            N = rand_num.Next(0, 100);
            arr = new int[N];
            GenOneDimArr(min_value, max_value);
        }


        public OneDimArr(int n)
        {
            N = n;
            arr = new int[N];
            GenOneDimArr(min_value, max_value);

        }
        public OneDimArr(int n, int value_1, int value_2, bool fill_with_step)
        {
            N = n;
            arr = new int[N];

            if (fill_with_step)
            {
                arr[0] = value_1;
                for (int i = 1; i < N; i++)
                    arr[i] = arr[i - 1] + value_2;
            }
            else
            {
                if (value_1 <= value_2)
                {
                    min_value = value_1;
                    max_value = value_2;
                }
                else
                {
                    min_value = value_2;
                    max_value = value_1;
                }
                GenOneDimArr(min_value, max_value);
            }
        }


        public OneDimArr(string file_path, bool generate_arr)
        {
            //Если файл существует

            if (generate_arr)

            {
                if (File.Exists(file_path))
                {
                    bool flag_n = false;;

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
                    arr = new int[N];

                    Console.WriteLine($"\nN:{N}\tmax_value:{min_value}\tmin_value: {max_value}\n");
                    GenOneDimArr(min_value, max_value);

                }
                else
                    Console.WriteLine($"Не получилось найти и открыть файл: {file_path}");

            }
            else
            {
                if (File.Exists(file_path))
                {
                    ////Считываем все строки в файл 
                    //string[] f_lines = File.ReadAllLines(file_path);
                    //arr = new int[f_lines.Length];

                    ////Переводим данные из строкового формата в числовой
                    //for (int i = 0; i < f_lines.Length; i++)
                    //    arr[i] = int.Parse(f_lines[i]);

                    string[] f_lines = File.ReadAllLines(file_path);

                    if (f_lines.Length == 1)
                    {
                        string[] elems = f_lines[0].Split(' ');
                        N = elems.Length;
                        arr = new int[N];

                        for (int i = 0; i < N; i++)
                        {
                            try
                            {
                                arr[i] = Convert.ToInt32(elems[i]);
                            }
                            catch { }
                        }      

                    }
                    else
                    {
                        Console.WriteLine($"Одномерный массив задан некорректно в файле: {file_path}");
                    }

                }
                else
                    Console.WriteLine($"Не получилось найти и открыть файл: {file_path}");
            }

        }

        public void GenOneDimArr(int min, int max)
        {

            if (min < max)
            {
                for (int i = 0; i < N; i++)
                    arr[i] = rand_num.Next(min, max);
            }
            else
            {
                Console.WriteLine("Минимальное значение диапазона для генераций значений массива" +
                    "\nне может быть больше или равно максимуальному значению");
            }
        }


        public int Max
        {
            get
            {
                return arr.Max();
            }
        }

        public int Min
        {
            get
            {
                return arr.Min();
            }
        }

        public int Sum
        {
            get
            {
                int sum = 0;
                foreach (int el in arr)
                    sum += el;
                return sum;
            }

        }

        //public int SumAllElementsLargerGivenValue(int given_value)
        //{
        //    int sum = 0;
        //    foreach (int el in arr)
        //    {
        //        if (el > given_value)
        //            sum += el;
        //    }

        //    return sum;
        //}

        public int[] InverseArr()
        {
            int [] out_arr = new int[N];
            for (int i = 0; i < N; i++)
                out_arr[i] = (-1) * arr[i];

            return out_arr;
        }

        public void MultiArr(int value)
        {
            for (int i = 0; i < N; i++)
                arr[i] = value * arr[i];
        }

        public int MaxCount()
        {
            int max_elem = Max;
            int counter = 0;

            for (int i = 0; i < N; i++)
                if (arr[i] == max_elem)
                    counter += 1;
            return counter;
        }



        public int this[int i]
        {
            get { return arr[i]; }
            set { arr[i] = value; }
        }

        public void OutputOneDimArr()
        {
            foreach (int el in arr)
                Console.Write($"{el} ");
            Console.WriteLine();
        }

        public void OutputOneDimArr(int[] a)
        {
            foreach (int el in a)
                Console.Write($"{el} ");
            Console.WriteLine();
        }

        public int[] GetOneDimArr()
        {
            return arr;
        }

        //Метод подсчета частоты вхождения каждого элемента в массив (коллекция Dictionary<int,int>)

        public Tuple<int[], int[]> ElemOccurences()
        {
            int counter;
            int[] no_duplicates_arr = arr.Distinct().ToArray();
            int[] counter_arr = new int[no_duplicates_arr.Length];

            //OutputOneDimArr(no_duplicates_arr);

            for (int i = 0; i < no_duplicates_arr.Length; i++)
            {
                counter = 0;
                for (int j = 0; j < N; j++)
                    if (arr[j] == no_duplicates_arr[i])
                        counter += 1;
                counter_arr[i] = counter;
                        
            }

            return new Tuple<int[], int[]>(no_duplicates_arr, counter_arr);
        }

    }

}
