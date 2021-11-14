using System;
using System.Collections;
using System.Collections.Generic;

namespace MyTestPrep
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Program start:");

            // var x = Numbers.MaxSlidingWindow(new[] { 1, 3, -1, -3, 5, 3, 6, 7 }, 3);
            // var x = ArrayAndString.Permute(new int[] { 1, 2, 3, 4 });

            // ArrayAndString.Merge(new int[7][] { new[] { 2, 3 }, new[] { 2, 2 }, new[] { 3, 3 }, new[] { 1, 3 }, new[] { 5, 7 }, new[] { 2, 2 }, new[] { 4, 6 } });

            // LinkedListTest.RotateRight(new ListNode(1, new ListNode(2, new ListNode(3, new ListNode(4, new ListNode(5))))), 2);

            // ArrayAndString.LengthOfLIS(new int[] { 10, 9, 2, 5, 3, 7, 101, 18 });

            // ArrayAndString.CountVowels('aba');

            //// ["joe","joe","joe","james","james","james","james","mary","mary","mary"]
            //// [1,2,3,4,5,6,7,8,9,10]
            //// ["home","about","career","home","cart","maps","home","home","about","career"]
            //// BestTimeBuySellStock.MostVisitedPattern(
            ////    new string[] { "joe", "joe", "joe", "james", "james", "james", "james", "mary", "mary", "mary" },
            ////    new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 },
            ////    new string[] { "home", "about", "career", "home", "cart", "maps", "home", "home", "about", "career" });

            //// BestTimeBuySellStock.CountComponents(5, new int[][] { new[] { 0, 1 }, new[] { 1, 2 }, new[] { 0, 2 }, new[] { 3, 4 } });

            // Graph.NumIslands(new char[4][]{
            //    new char[]{ '1','1','1','1','0' },
            //    new char[]{ '1','1','0','1','0' },
            //    new char[]{ '1','1','0','0','0' },
            //    new char[]{ '0','0','0','0','0' }
            //});

            // var x = SlidingWindow.MaxSlidingWindow(new int[] { 1, 3, -1, -3, 5, 3, 6, 7 }, 3);
            // var x = SlidingWindow.MaxDistance(new List<IList<int>> { new List<int> { 1, 4, 5 }, new List<int> { 0, 2 } });

            // var x = ArrayAndString.Merge(new int[3][] { new[] { 8, 9 }, new[] { 1, 5 }, new[] { 8, 9 } });

            var x = Graph.GetFood(new char[4][] {
                new char[]{'X','X','X','X','X','X'},
                new char[]{'X','*','O','O','O','X'},
                new char[]{'X','O','O','#','O','X'},
                new char[]{'X','X','X','X','X','X'}
                });

            // Basics.MaximumUnits(new int[4][] { new[] { 5, 10 }, new[] { 2, 5 }, new[] { 4, 7 }, new[] { 3, 9 } }, 10);
            // Basics.MaxProfit(new[] { 2, 5 }, 4);

            // var y = Basics.LastSubstring("abab");

            var z = Basics.HighFive(new int[11][] {
                new []{ 1, 91 },
                new []{ 1, 92 },
                new []{ 2, 93 },
                new []{ 2, 97 },
                new []{ 1, 60 },
                new []{ 2, 77 },
                new []{ 1, 65 },
                new []{ 1, 87 },
                new []{ 1, 100 },
                new []{ 2, 100},
                new []{ 2, 76 }});

            Robot.IsRobotBounded("GLRLGLLGLGRGLGL");

            Console.WriteLine("Program end.");
            // 
        }
    }
}