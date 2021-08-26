using System;

namespace MyTestPrep
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Program start:");

            // var testResult1 = ArrayAndString.IsUniqueCharsWithLinq("abcdedaa");
            // Console.WriteLine($"Result: {testResult1}");

            // var testResult2 = ArrayAndString.IsPermutation("abcd", "bcda");
            // Console.WriteLine($"Result: {testResult2}");

            // var testResult3 = ArrayAndString.Urlify_Regex("Mr John Smith    ");
            // Console.WriteLine($"Result: {testResult3}");

            // var testResult4 = ArrayAndString.Palindrome("taco cat");
            // Console.WriteLine($"Result: {testResult4}");

            // var testResult5 = ArrayAndString.OneWay("1235", "12365");
            // Console.WriteLine($"Result: {testResult5}");

            // var testResult6 = ArrayAndString.StringCompression("aabcccccaaa");  // a2blc5a3.
            // Console.WriteLine($"Result: {testResult6}");

            // var testResult7 = ArrayAndString.StringRotation("waterbottle", "erbottlewat");
            // Console.WriteLine($"Result: {testResult7}");
            
            var matrix_rotate = new int[4, 4] {{ 1, 2, 3, 4 }, { 5, 6, 7, 8 }, { 9, 10, 11, 12 }, {13, 14, 15, 16 }};
            ArrayAndString.RotateMatrix(matrix_rotate);

            // var matrix_zero = new int[4, 3] { { 1, 2, 3 }, { 4, 5, 6}, { 7, 0, 9 }, { 10, 11, 12 } };
            // ArrayAndString.ZeroMatrix(matrix_zero);

            Console.WriteLine("Program end.");        
        }
    }
}
