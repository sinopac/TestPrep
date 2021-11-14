using System;
using System.Collections.Generic;
using System.Linq;

namespace MyTestPrep
{
    public static class Palindrome
    {
        public static string LongestPalindrome(string s)
        {
            if (s.Length == 0 || s.Length == 1)
                return s;

            int right, left;
            int p_index = 0, p_length = 0;

            for (int i = 1; i <= 2; i++)
            {
                for (int j = 0; j < s.Length - i; j++)
                {
                    left = j;
                    right = j + i;

                    var x = s[left];
                    var y = s[right];

                    while (left >= 0 && right < s.Length && s[left] == s[right])
                    {
                        if (right - left > p_length)
                        {
                            p_index = left;
                            p_length = right - left;
                        }

                        right++;
                        left--;
                    }
                }
            }

            return s.Substring(p_index, p_length + 1);
        }

        public static string LongestPalindrome_BruteForce(string s)
        {
            // Input: Given string :"forgeeksskeegfor", 
            // Output: "geeksskeeg"
            // Window Sliding Technique
            // two pointers

            string ans = "";

            for (int i = 0; i < s.Length; i++)
            {
                for (int j = 0; j <= s.Length - i; j++)
                {
                    var subStr = s.Substring(i, j);
                    if (CheckPalindrome(subStr))
                    {
                        if (subStr.Length > ans.Length)
                            ans = subStr;
                    }
                }
            }

            return ans;
        }

        public static bool CheckPalindrome(string s)
        {
            if (s.Length < 2)
                return true;

            int left = 0;
            int right = s.Length - 1;

            while (right > left)
            {
                if (s[right] != s[left])
                    return false;

                right--;
                left++;
            }

            return true;
        }
    }
}