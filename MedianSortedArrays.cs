using System;
using System.Linq;

namespace MyTestPrep
{
    public static class MedianSortedArrays
    {
        /// <summary>
        /// Input: nums1 = [1,3], nums2 = [2]
        /// Output: 2.00000
        /// Explanation: merged array = [1,2,3] and median is 2.
        /// https://leetcode.com/problems/median-of-two-sorted-arrays/
        /// </summary>
        public static double FindMedianSortedArrays_1(int[] nums1, int[] nums2)
        {
            var nums = nums1.Concat(nums2).ToArray();
            Array.Sort(nums);
            var m = nums.Length / 2;

            if (nums.Length % 2 == 0)
            {
                return (nums[m] + nums[m - 1]) / 2.0;
            }

            return nums[m];
        }

        /// <summary>
        /// Linq Union has better memory comsumption then Array concat and sort.
        /// Output: 2.00000
        /// Explanation: merged array = [1,2,3] and median is 2.
        /// https://leetcode.com/problems/median-of-two-sorted-arrays/
        /// </summary>
        public static double FindMedianSortedArrays_2(int[] nums1, int[] nums2)
        {
            var nums = nums1.Union(nums2).OrderBy(x => x).ToArray();

            if (nums.Length % 2 == 0)
            {
                return (nums[nums.Length / 2 - 1] + nums[nums.Length / 2]) / 2;
            }

            return nums[nums.Length / 2];
        }
    }
}