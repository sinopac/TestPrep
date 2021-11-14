using System;
using System.Collections.Generic;
using System.Linq;

namespace MyTestPrep
{
    public static class Recursive
    {
        private static long count = 0;

        public static long WonderfulSubstrings(string word)
        {
            GenerateSub(word, 0, string.Empty);
            // SubStrings(word, "");

            return count;
        }

        private static void SubStrings(string str, string temp)
        {
            if (str.Length == 0)
            {
                if (temp.Length % 2 == 1)
                    count++;

                Console.WriteLine(temp);
                return;
            }

            SubStrings(str.Substring(1), temp + str.Substring(0, 1));
            SubStrings(str.Substring(1), temp);
        }

        private static void GenerateSub(string word, int index, string temp)
        {
            if (index == word.Length)
            {
                return;
            }

            for (int i = index; i < word.Length; i++)
            {
                temp += word[i];
                Console.WriteLine(temp);
                GenerateSub(word, i + 1, temp);
            }
        }
    }
}