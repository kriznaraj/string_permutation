using System;
using System.Collections.Generic;
using System.Linq;

namespace code
{
    class Program
    {
        static void Main(string[] args)
        {
            DoPermute(args[0]);
        }

        static void DoPermute(string text)
        {
            var dict = new Dictionary<char,int>();
            foreach (var item in text)
            {
                if(dict.ContainsKey(item))
                    dict[item]++;
                else dict.Add(item, 1);
            }

            Permute(dict.Keys.ToArray(), dict.Values.ToArray(), new char[text.Length], 0);
        }

        static void Permute(char[] text, int[] count, char[] res, int level) 
        {
            if(level == res.Length){
                Print(res);
                return;
            }

            for (int i = 0; i < text.Length; i++)
            {
                if (count[i] == 0)
                {
                    continue;
                }

                res[level] = text[i];
                count[i]--;
                Permute(text, count, res, level + 1);
                count[i]++;
            }
        }

        static void Print(char[] res) 
        {
            Console.WriteLine(res);
        }
    }
}
