using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace MyTestPrep
{
    public static class Basics
    {
        public static int MaximumUnits(int[][] boxTypes, int truckSize)
        {
            Array.Sort(boxTypes, new Comparison<int[]>((a, b) =>
            {
                return a[1] > b[1] ? -1 : (a[1] < b[1] ? 1 : 0);
            }));

            int total = 0;
            for (int i = 0; i < boxTypes.Length; i++)
            {
                if (truckSize >= boxTypes[i][0])
                {
                    total += boxTypes[i][0] * boxTypes[i][1];
                    truckSize -= boxTypes[i][0];
                }
                else
                {
                    total += truckSize * boxTypes[i][1];
                    truckSize = 0;
                }
            }

            return total;
        }

        public static int MaxProfit(int[] inventory, int orders)
        {
            Array.Sort(inventory);
            Array.Reverse(inventory);
            var amount = 0;

            while (orders > 0)
            {
                int[] sell = inventory;

                for (int i = 0; i < inventory.Length - 1; i++)
                {
                    if (inventory[i] > inventory[i + 1])
                    {
                        sell = inventory.Take(i + 1).ToArray();
                        break;
                    }
                }

                var diff = sell.Length == inventory.Length ? sell[0] : sell[0] - inventory[sell.Length];
                for (int j = 0; j < diff; j++)
                {
                    for (int k = 0; k < sell.Length; k++)
                    {
                        amount += sell[k];
                        orders--;
                        inventory[k]--;

                        if (orders == 0)
                            return amount;
                    }
                }
            }

            return 0;
        }

        public static string LastSubstring(string s)
        {
            int l = s.Length;
            int i = 0, j = 1, k = 0;

            while (j + k < l)
            {
                if (s[i + k] == s[j + k])
                {
                    k++;
                    continue;
                }
                if (s[i + k] > s[j + k])
                {
                    j++;
                }
                else
                {
                    i = j;
                    j = i + 1;
                }

                k = 0;
            }

            return s.Substring(i);
        }

        public static int[][] HighFive(int[][] items)
        {
            var groups = items.GroupBy(x => x[0])
                .OrderBy(g => g.Key)
                .Select(student => new
                {
                    ID = student.Key,
                    Scores = student.Select(score => score[1]).OrderByDescending(s => s).Take(5)
                });

            var ans = new int[groups.Count()][];
            var i = 0;

            foreach (var g in groups)
            {
                int sum = g.Scores.Sum();
                int scoreCount = g.Scores.Count();
                ans[i] = new int[] { g.ID, sum / scoreCount };
                i++;
            }

            return ans;
        }
    }
}