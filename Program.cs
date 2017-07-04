using System;
using System.Collections.Generic;
using System.Linq;

namespace code
{
    class Program
    {
        static void Main(string[] args)
        {
            Do(args[0]);
        }

        static void Do(string text)
        {
            var dict = new Dictionary<char,int>();
            foreach (var item in text)
            {
                if(dict.ContainsKey(item))
                    dict[item]++;
                else dict.Add(item, 1);
            }

            Console.WriteLine("Permutations of given text {0}", text);
            Permute(dict.Keys.ToArray(), dict.Values.ToArray(), new char[text.Length], 0);
            
            Console.WriteLine("Combinations of given text {0}", text);
            Combination(dict.Keys.ToArray(), dict.Values.ToArray(), new char[text.Length], 0, 0);
        }

        static void Permute(char[] text, int[] count, char[] res, int level) 
        {
            if(level == res.Length)
            {
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

        static void Combination(char[] text, int[] count, char[] res, int level, int pos)
        {
            for (int i = pos; i < text.Length; i++)
            {
                if (count[i] == 0)
                {
                    continue;
                }

                res[level] = text[i];
                Print(res, level + 1);
                count[i]--;
                Combination(text, count, res, level + 1, i);
                count[i]++;
            }
        }

        static void Print(char[] res, int index = -1) 
        {
            if(index > 0 && index < res.Length)
                Console.WriteLine(res.SkipLast(res.Length - index).ToArray());
            else
                Console.WriteLine(res);
        }
    }
}
