using System;
using System.Collections.Generic;
using System.Linq;

namespace MyTestPrep
{
    public static class Meeting
    {
        /// <summary>
        /// Array, HashTable
        /// Input: intervals = [[1,3],[2,6],[8,10],[15,18]]
        /// Output: [[1,6],[8,10],[15,18]]
        /// https://leetcode.com/problems/merge-intervals/
        /// </summary>
        public static int[][] Merge(int[][] intervals)
        {
            // Sort the intervals by start time
            Array.Sort(intervals, new Comparison<int[]>((a, b) => (a[0] - b[0])));

            var ans = new List<int[]> { intervals[0] };
            int begin = 0;

            for (int i = 1; i < intervals.Length; i++)
            {

                if (intervals[i][0] > ans[begin][1])
                {
                    ans.Add(intervals[i]);
                    begin++;
                }
                else
                {
                    ans[begin][1] = Math.Max(ans[begin][1], intervals[i][1]);
                }
            }

            return ans.ToArray();
        }
    }
}