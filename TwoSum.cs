using System;
using System.Collections.Generic;
using System.Linq;

namespace MyTestPrep
{
    public static class TwoSums
    {
        /// <summary>
        /// Array, HashTable
        /// Input: nums = [2,7,11,15], target = 9
        /// Output: [0,1]
        /// https://leetcode.com/problems/two-sum/
        /// </summary>
        public static int[] TwoSum(int[] nums, int target)
        {
            var matchTable = new Dictionary<int, int>();

            for (int i = 0; i < nums.Length; i++)
            {
                var matchNum = matchTable.Where(x => x.Value == nums[i]);

                if (matchNum.Any())
                {
                    return new[] { matchNum.First().Key, i };
                }

                matchTable.Add(i, target - nums[i]);
            }

            return new int[0];
        }

        /// <summary>
        /// Array, HashTable
        /// Input: nums = [34,23,1,24,75,33,54,8], k = 60
        /// Output: 58
        /// https://leetcode.com/problems/two-sum-less-than-k/
        /// </summary>
        public static int TwoSumLessThanK(int[] nums, int k)
        {
            Array.Sort(nums);

            var maxSum = -1;
            var left = 0;
            var right = nums.Length - 1;

            while (left < right)
            {
                var sum = nums[left] + nums[right];

                if (sum < k)
                {
                    maxSum = Math.Max(maxSum, sum);
                    left++;
                }
                else
                {
                    right--;
                }
            }

            return maxSum;
        }
    }
}