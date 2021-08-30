using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace MyTestPrep
{
    public static class ArrayAndString
    {
        public static bool IsUniqueChars(string s)
        {
            // ASCII contains 128 char.
            if (s.Length > 128)
                return false;

            var asciiSet = new bool[128];

            foreach (char c in s)
            {
                int dec = (int)c;

                if (asciiSet[dec])
                    return false;

                asciiSet[dec] = true;
            }

            return true;
        }

        public static bool IsUniqueChars_Linq(string s)
        {
            if (s.Length > 128)
                return false;

            var duplicateChars = s.GroupBy(x => x).SelectMany(group => group.Skip(1));
            return !duplicateChars.Any();
        }

        /// If two strings are permutations, then we know they have the same characters, but in different orders.
        public static bool IsPermutation(string s1, string s2)
        {
            if (s1.Length != s2.Length)
                return false;

            var s1CharArray = s1.ToCharArray();
            Array.Sort(s1CharArray);

            var s2CharArray = s2.ToCharArray();
            Array.Sort(s2CharArray);

            return new string(s1CharArray) == new string(s2CharArray);
        }

        public static bool IsPermutation_Linq_Except(string s1, string s2)
        {
            if (s1.Length != s2.Length)
                return false;

            var diff = s1.Except(s2);

            return !diff.Any();
        }

        public static bool IsPermutation_Linq_SequenceEqual(string s1, string s2)
        {
            if (s1.Length != s2.Length)
                return false;

            var s1CharArray = s1.ToCharArray();
            Array.Sort(s1CharArray);

            var s2CharArray = s2.ToCharArray();
            Array.Sort(s2CharArray);

            return !Enumerable.SequenceEqual(s1CharArray, s2CharArray);
            // return s1CharArray.SequenceEqual(s2CharArray);
        }

        /// replace all spaces in a string with '%20'
        public static string Urlify(string s)
        {
            s = s.Trim();
            return s.Replace(" ", "%20");
        }

        public static string Urlify_StringBuilder(string s)
        {
            s = s.Trim();
            var strBuilder = new StringBuilder();

            foreach (var c in s)
            {
                if (Char.IsWhiteSpace(c))
                {
                    strBuilder.Append("%20");
                }
                else
                {
                    strBuilder.Append(c.ToString());
                }
            }
            return strBuilder.ToString();
        }

        public static string Urlify_Regex(string s)
        {
            s = s.Trim();
            return Regex.Replace(s, @"\s", "%20");
        }

        /// A palindrome is a string that is the same forwards and backwards.
        public static bool Palindrome(string s)
        {
            s = s.Replace(" ", string.Empty).ToLower();
            var sCharArray = s.ToCharArray();
            Array.Reverse(sCharArray);

            return s == new string(sCharArray);
        }

        /// two string would be same if insert a character, remove a character, or replace a character.
        public static bool OneWay(string s1, string s2)
        {
            var commons = s1.Intersect(s2).Count();
            return commons == s1.Length - 1 || commons == s2.Length - 1;
        }

        /// string compression using the counts of repeated characters.
        public static string StringCompression(string s)
        {
            var compressStringLength = GetCompressStringLength(s);
            Console.WriteLine($"Length: {compressStringLength}");
            if (compressStringLength >= s.Length)
                return s;

            var sChars = s.ToCharArray();
            var strBuilder = new StringBuilder();
            strBuilder.Append(sChars[0]);
            int counter = 1;

            for (var i = 1; i < sChars.Length; i++)
            {
                if (sChars[i] != sChars[i - 1])
                {
                    strBuilder.Append(counter);
                    strBuilder.Append(sChars[i]);
                    counter = 1;
                }
                else
                {
                    counter++;
                }
            }

            strBuilder.Append(counter);
            var compressString = strBuilder.ToString();

            return compressString;
        }

        private static int GetCompressStringLength(string s)
        {
            if (string.IsNullOrEmpty(s))
                return 0;

            int counter = 1;
            for (int i = 1; i < s.Length; i++)
            {
                if (s[i] != s[i - 1])
                    counter++;
            }

            return counter * 2;
        }

        /// rotate the matrix by 90 degrees
        /// the original question is NxN matrix, this solution apply to NxM matrix)
        public static void RotateMatrix(int[,] matrix)
        {
            var n = matrix.GetLength(0);
            var m = matrix.GetLength(1);
            var newMatrix = new int[m, n];

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    newMatrix[i, j] = matrix[n - j - 1, i];
                    Console.Write(newMatrix[i, j] + "\t");
                }
                Console.WriteLine();
            }

            matrix = newMatrix;
        }

        /// if an element in an MxN matrix is 0, its entire row and column are set to 0
        public static void ZeroMatrix(int[,] matrix)
        {
            var rowsWithZero = new List<int>();
            var columnsWithZero = new List<int>();

            // Get rows and columns with zero value
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == 0)
                    {
                        rowsWithZero.Add(i);
                        columnsWithZero.Add(j);
                    }
                }
            }

            // Update and print the matrix
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (rowsWithZero.Contains(i) || columnsWithZero.Contains(j))
                    {
                        matrix[i, j] = 0;
                    }

                    Console.Write(matrix[i, j] + "\t");
                }
                Console.WriteLine();
            }
        }

        /// e.g., "waterbottle" is a rotation of" erbottlewat"
        public static bool StringRotation(string s1, string s2)
        {
            return (s1 + s1).Contains(s2);
        }

        /// https://leetcode.com/problems/longest-substring-without-repeating-characters/
        public static int LengthOfLongestSubstring(string s)
        {

            var result = 0;

            for (var i = 0; i < s.Length; i++)
            {
                var longestSub = new List<char>();
                longestSub.Add(s[i]);

                for (var j = i + 1; j < s.Length; j++)
                {
                    if (longestSub.Contains(s[j]))
                        break;
                    else
                        longestSub.Add(s[j]);
                }

                if (longestSub.Count > result)
                    result = longestSub.Count;
            }

            return result;
        }
    }
}