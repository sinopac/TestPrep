using System;
using System.Collections.Generic;
using System.Linq;

namespace MyTestPrep
{
    public static class LexicographicalOrer
    {
        public static string biggerIsGreater(string w)
        {
            int pivotIndex = -1;

            for (int i = w.Length - 1; i >= 0; i--)
            {
                if (w[i] > w[i - 1])
                {
                    pivotIndex = i - 1;
                    break;
                }
            }

            if (pivotIndex == -1)
                return "no answer";

            var prefix = w.Substring(0, pivotIndex);
            var p = w[pivotIndex];
            var suffix = w.Substring(pivotIndex + 1).OrderBy(x => x).ToArray();

            for (int j = 0; j < suffix.Length; j++)
            {
                if (suffix[j] > p)
                {
                    // swap
                    var temp = p;
                    p = suffix[j];
                    suffix[j] = temp;
                    break;
                }
            }

            var newword = prefix + p.ToString() + new string(suffix);

            return newword;
        }
    }
}