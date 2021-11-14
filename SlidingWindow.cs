using System;
using System.Collections.Generic;
using System.Linq;

namespace MyTestPrep
{
    public static class SlidingWindow
    {
        public static int[] MaxSlidingWindow(int[] nums, int k)
        {
            var ans = new int[nums.Length - k + 1];

            var window = new int[k];
            for (int i = 0; i < k; i++)
            {
                window[i] = nums[i];
            }

            ans[0] = window.Max();

            for (int i = 0; i < nums.Length - k; i++)
            {
                for (int j = 0; j < k - 1; j++)
                    window[j] = window[j + 1];

                window[k - 1] = nums[k + i];

                ans[i + 1] = window.Max();
            }

            return ans;
        }

        public static int MaxDistance(IList<IList<int>> list)
        {
            int maxDistance = 0;
            int start = list[0].First();
            int end = list[0].Last();

            for (int i = 1; i < list.Count; i++)
            {
                var d1 = Math.Abs(list[i].Last() - start);
                var d2 = Math.Abs(end - list[i].First());
                var distance = Math.Max(d1, d2);

                maxDistance = Math.Max(maxDistance, distance);

                start = Math.Min(start, list[i].First());
                end = Math.Max(end, list[i].Last());
            }

            return Math.Abs(start - end);
        }
    }
}