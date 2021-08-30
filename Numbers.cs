using System;
using System.Text;
using System.Collections.Generic;

namespace MyTestPrep
{
    public static class Numbers
    {
        // Create your own Interger parser
        public static int IntPars(string s)
        {
            // byte range 0 - 255, 0 is 48, 9 is 57.
            byte[] asciiBytes = Encoding.ASCII.GetBytes(s);
            int num = 0;

            foreach (var digit in asciiBytes)
            {
                if (digit > 57 || digit < 48)
                {
                    // return 0 if string not digits only 
                    return 0;
                }

                num = num * 10 + (digit - 48);
            }

            return num;
        }

        /// An Armstrong number (< 999) is an integer such that the sum of the cubes of its digits is equal to the number itself. 
        /// For example, 371 is an Armstrong number since 3**3 + 7**3 + 1**3 = 371.
        public static List<int> ArmstrongNumber()
        {
            var numbers = new List<int>();

            for (int a = 0; a < 10; a++)
            {
                for (int b = 0; b < 10; b++)
                {
                    for (int c = 0; c < 10; c++)
                    {
                        var n1 = a * 100 + b * 10 + c;
                        var n2 = Math.Pow(a, 3) + Math.Pow(b, 3) + Math.Pow(c, 3);

                        if (n1 == n2)
                        {
                            numbers.Add(n1);
                        }
                    }
                }
            }

            return numbers;
        }
    }
}