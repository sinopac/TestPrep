using System;
using System.Linq;
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

        public static int FindMaxConsecutiveOnes(int[] nums)
        {
            int maxCount = 0;
            int count = 0;

            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] == 1)
                {
                    count++;
                }
                else
                {
                    if (count > maxCount)
                        maxCount = count;

                    count = 0;
                }
            }

            if (count > maxCount)
                maxCount = count;

            return maxCount;
        }

        public static int[] Merge(int[] nums1, int m, int[] nums2, int n)
        {
            var list = new List<int>();



            for (var i = 0; i < m; i++)
            {
                list.Add(nums1[i]);
            }

            for (var j = 0; j < n; j++)
            {
                list.Add(nums2[j]);
            }

            var x = list.OrderBy(x => x).ToArray();

            return x;
        }

        /// Given coins of value 1, 3, and 6 and a sum, what is the minimum number of coins needed to reach the sum?
        public static int SumCombination(int[] coins, int v)
        {
            if (v == 0)
                return 0;

            // Initialize result
            int res = int.MaxValue;

            // Try every coin that has smaller value than V
            for (int i = 0; i < coins.Length; i++)
            {
                if (coins[i] <= v)
                {
                    int sub_res = SumCombination(coins, v - coins[i]);

                    // Check for INT_MAX to  avoid overflow and see if result can minimized
                    if (sub_res != int.MaxValue && sub_res + 1 < res)
                        res = sub_res + 1;
                }
            }

            return res;
        }

        public static int[] TwoSum(int[] nums, int target)
        {
            var numSet = new List<Tuple<int, int>>();

            for (int i = 0; i < nums.Length; i++)
            {
                var solution = numSet.FirstOrDefault(x => x.Item2 == target - nums[i]);

                if (solution != null)
                {
                    return new[] { solution.Item1, i };
                }

                numSet.Add(new Tuple<int, int>(i, nums[i]));
            }

            return new int[] { };
        }

        public static IList<IList<int>> ThreeSum(int[] nums)
        {
            IList<IList<int>> result = new List<IList<int>>();
            var numsList = nums.ToList();

            for (int i = 0; i < numsList.Count; i++)
            {
                numsList.Remove(numsList[i]);
                var xx = NewTwoSum(numsList, -numsList[i]);

                foreach (var x in xx)
                {
                    x.Add(numsList[i]);
                    result.Add(x);
                }
            }

            return result;
        }

        public static List<List<int>> NewTwoSum(List<int> nums, int sum)
        {
            List<List<int>> result = new List<List<int>>();
            List<Tuple<int, int>> matchs = new List<Tuple<int, int>>();

            for (int i = 0; i < nums.Count; i++)
            {
                var ms = matchs.Where(x => x.Item2 == sum - 1);
                if (ms.Any())
                {
                    foreach (var m in ms)
                    {
                        result.Add(new List<int> { i, m.Item2 });
                    }
                }
                else
                {
                    matchs.Add(new Tuple<int, int>(i, nums[i]));
                }
            }
            return result;
        }

        public static void Rotate(int[] nums, int k)
        {
            var newNums = new int[nums.Length];
            k = k % nums.Length;
            for (int i = 0; i < nums.Length; i++)
            {
                int idx = i + k;
                if (idx >= nums.Length)
                {
                    idx = idx - nums.Length;
                }

                newNums[idx] = nums[i];
            }

            nums = newNums;
        }

        public static int RemoveElement(int[] nums, int val)
        {
            int i = 0;
            for (int j = 0; j < nums.Length; j++)
            {
                if (nums[j] != val)
                {
                    nums[i] = nums[j];
                    i++;
                }
            }
            return i;
        }

        public static int RemoveDuplicates(int[] nums)
        {
            int i = 0;
            bool ii = false;

            for (int j = 1; j < nums.Length; j++)
            {
                if (nums[i] != nums[j])
                {
                    i++;
                    nums[i] = nums[j];
                    ii = false;
                }
                else if (nums[i] == nums[j] && ii == false)
                {
                    i++;
                    nums[i] = nums[j];
                    ii = true;
                }
            }

            return i + 1;
        }

        public static int BinarySearch(int[] nums, int target)
        {
            int left = 0;
            int right = nums.Length - 1;
            int mid;

            while (right > left)
            {
                mid = (right + left) / 2;
                if (target == nums[mid])
                    return mid;

                if (target > nums[mid])
                    left = mid;

                if (target < nums[mid])
                    right = mid;
            }

            return -1;
        }

        public static int[] MaxSlidingWindow(int[] nums, int k)
        {
            var ans = new int[nums.Length - k + 1];
            var window = new List<int>();

            for (int i = 0; i < k; i++)
            {
                window.Add(nums[i]);
            }

            ans[0] = window.Max();

            for (int i = 0; i < nums.Length - k; i++)
            {
                window.Remove(window[0]);
                window.Add(nums[k + i]);
                ans[i + 1] = window.Max();
            }

            return ans;
        }

        public static void ccc(int n)
        {
            var c = new char[n - 1];
            Array.Fill(c, '9');
            int max = int.Parse(new string(c));
            int min = (int)Math.Pow(10, n - 2);

            for (int i = min; i <= max; i++)
            {
                Console.WriteLine(i * 10);
                Console.WriteLine(i * 10 + 5);
            }
        }
    }
}