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

            int a = s.Length - 1;
            int r, l;
            int spos = 0, slen = 0;

            for (int i = 1; i < 3; i++)
            {
                for (int ii = 0; ii <= a - i; ii++)
                {
                    l = ii;
                    r = ii + i;

                    while (l >= 0 && r <= a && s[l] == s[r])
                    {
                        if (r - l > slen)
                        {
                            spos = l;
                            slen = r - l;
                        }

                        r++;
                        l--;
                    }
                }
            }

            return s.Substring(spos, slen + 1);
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