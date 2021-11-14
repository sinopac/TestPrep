using System;
using System.Collections.Generic;
using System.Linq;

namespace MyTestPrep
{
    /// <summary>
    /// Input: [7,1,5,3,6,4]
    /// Output: 7
    /// https://leetcode.com/problems/best-time-to-buy-and-sell-stock-ii/
    /// </summary>
    public static class BestTimeBuySellStock
    {
        public static int MaxProfitII(int[] prices)
        {
            int profit = 0;
            int cost = 0;
            bool hold = false;

            for (int j = 0; j < prices.Length - 1; j++)
            {
                // sold
                if (prices[j] > prices[j + 1] && hold)
                {
                    profit += prices[j] - cost;
                    hold = false;
                }
                // buy
                if (prices[j] < prices[j + 1] && !hold)
                {
                    cost = prices[j];
                    hold = true;
                }

                // close in the end
                if (j == prices.Length - 2 && hold)
                {
                    profit += prices[j + 1] - cost;
                }
            }

            return profit;
        }

        public static int MaxProfit(int[] prices)
        {
            var min = int.MaxValue;
            var profit = 0;

            for (int i = 0; i < prices.Length; i++)
            {
                if (prices[i] < min)
                {
                    min = prices[i];
                }
                else if (prices[i] > min)
                {
                    profit = Math.Max(profit, prices[i] - min);
                }
            }

            return profit;

        }

        public static IList<string> MostVisitedPattern(string[] username, int[] timestamp, string[] website)
        {
            var tuples = new List<Tuple<string, string, int>>();

            for (int i = 0; i < username.Length; i++)
            {
                tuples.Add(Tuple.Create(username[i], website[i], timestamp[i]));
            }

            var histories = tuples.GroupBy(x => x.Item1).ToList();

            foreach (var h in histories)
            {

            }

            return new List<string>();
        }

        public static string[] CommonString(string[] left, string[] right)
        {
            List<string> result = new List<string>();

            result.AddRange(right.Where(r => left.Any(l => l.StartsWith(r))));

            // must check other way in case left array contains smaller words than right array
            result.AddRange(left.Where(l => right.Any(r => r.StartsWith(l))));

            return result.Distinct().ToArray();
        }

        public static int MinFlipsMonoIncr(string s)
        {
            // 0110010
            int one = 0;
            int flip = 0;

            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == '1')
                    one++;
                else
                    flip++;

                flip = Math.Min(one, flip);
            }

            return flip;
        }

        public static int CountComponents(int n, int[][] edges)
        {
            var nodes = new int[] { 0, 1, 2, 3, 4 };
            var visits = new List<int>();
            var groupCount = 0;

            for (int i = 0; i < edges.Length; i++)
            {
                visits.AddRange(edges[i]);

                GetChildren(edges, edges[i], visits);
                // GetParents(edges, edges[i], visits);

                groupCount++;
            }

            return groupCount;
        }

        private static void GetParents(int[][] edges, int[] edge, List<int> visits)
        {
            foreach (var parent in edges.Where(x => x[1] == edge[0]))
            {
                if (visits.Contains(parent[1]))
                    return;

                visits.Add(parent[1]);
                GetParents(edges, parent, visits);
            }
        }

        private static void GetChildren(int[][] edges, int[] edge, List<int> visits)
        {
            foreach (var child in edges.Where(x => x[0] == edge[0]))
            {
                if (visits.Contains(child[1]))
                    continue;

                visits.Add(child[1]);
                GetChildren(edges, child, visits);
            }
        }
    }
}