using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace App_5
{
    static class Message
    {
        private static string RemoveExtraSymb(string str)
        {
            //return Regex.Replace(str, "[@&'(\\s)<>#;:%#,.]", " ");
            str = Regex.Replace(str, @"[^0-9a-zA-Z ]+", " ");
            return Regex.Replace(str, @"\s\s+", " ");
        }
        public static void OutputWordsOfGivenLength(string text, int num_l)
        {
            
            text = RemoveExtraSymb(text);
            string[] str_elems = text.Split(' ');
            Console.WriteLine(text);
            Console.WriteLine();

            string res_str = "";
            for (int i = 0; i < str_elems.Length; i++)
            {
                if (str_elems[i].Length >= num_l)
                {
                    res_str += str_elems[i] + " ";
                }
            }

            Console.WriteLine(res_str);
            
        }

        public static Tuple<string, int> FindMaxWord(string text)
        {

            text = RemoveExtraSymb(text);
            string[] str_elems = text.Split(' ');

            int max_length = str_elems[0].Length;
            string max_l_word = str_elems[0];

            for (int i = 1; i < str_elems.Length; i++)
            {
                if (str_elems[i].Length >= max_length)
                {
                    max_length = str_elems[i].Length;
                    max_l_word = str_elems[i];
                }
            }

            Console.WriteLine(max_l_word);
            return new Tuple<string, int>(max_l_word, max_length);
        }

        public static void RemoveExtraWord(string text, char elem)
        {

            string new_text = RemoveExtraSymb(text);
            string[] str_elems = new_text.Split(' ');
            Console.WriteLine(new_text);
            Console.WriteLine();

            for (int i = 0; i < str_elems.Length; i++)
            {
                if (str_elems[i].EndsWith(elem.ToString()))
                {
                    Console.WriteLine(str_elems[i]);
                    int index = text.IndexOf(str_elems[i]);
                    text = (index < 0) ? text : text.Remove(index, str_elems[i].Length);
                }
            }

            Console.WriteLine(text);
        }

        public static void OutputMaxWords(string text)
        {

            
            Tuple<string, int> max_word = FindMaxWord(text);
            text = RemoveExtraSymb(text);

            string[] str_elems = text.Split(' ');
            Console.WriteLine(text);
            Console.WriteLine();
            StringBuilder res_str = new StringBuilder("");

            for (int i = 0; i < str_elems.Length; i++)
            {
                if (str_elems[i].Length == max_word.Item2)
                {
                    res_str.Append(str_elems[i] + " ");
                }
            }

            Console.WriteLine(res_str);

        }
    }
}
