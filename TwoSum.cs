using System.Collections.Generic;
using System.Linq;

namespace MyTestPrep
{
    /// <summary>
    /// Array, HashTable
    /// Input: nums = [2,7,11,15], target = 9
    /// Output: [0,1]
    /// </summary>
    public static class TwoSum
    {
        public static int[] TwoSum_1(int[] nums, int target)
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

        public static int[] TwoSum_2(int[] nums, int target)
        {
            var matchNums = new Dictionary<int, int>();

            for (int i = 0; i < nums.Length; i++)
            {
                var matchNum = target - nums[i];
                var matchs = matchNums.Where(x => x.Value == matchNum);

                if (matchs.Any())
                {
                    return new[] { matchs.First().Key, i };
                }

                matchNums.Add(i, nums[i]);
            }

            return null;
        }
    }
}