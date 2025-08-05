using System.Runtime.CompilerServices;

namespace Amazon2025
{
    public class Solution
    {
        #region 1. Two Sum
        public int[] TwoSum(int[] nums, int target)
        {
            int[] result = new int[2];

            Dictionary<int, int> map = new Dictionary<int, int>();

            map.Add(nums[0], 0);

            for (int i = 1; i < nums.Length; i++)
            {
                int k = target - nums[i];

                if (map.ContainsKey(k))
                {
                    return new int[] { map[k], i };
                }
                map[nums[i]] = i;
            }

            return result;
        }
        #endregion

        #region 3. Longest Substring Without Repeating Characters
        public int LengthOfLongestSubstring(string s)
        {
            if (s.Length <= 1) return s.Length;
            Dictionary<char, int> indexMap = new Dictionary<char, int>();
            int result = 0;
            int startIndex = 0;
            indexMap[s[0]] = 0;
            for (int i = 1; i < s.Length; i++)
            {
                if (indexMap.ContainsKey(s[i]) && indexMap[s[i]] >= startIndex)
                {
                    result = Math.Max(i - startIndex, result);
                    startIndex = indexMap[s[i]] + 1;
                }
                indexMap[s[i]] = i;
            }


            return Math.Max(result, s.Length - startIndex);
        }
        #endregion

        #region 42. Trapping Rain Water
        /*  0   1   2   3   4   5   6   7   8   9   10  11
         * [0,  1,  0,  2,  1,  0,  1,  3,  2,  1,  2,  1]
         * [-1, -1, 1,  -1, 3,  3,  3,  -1, 7,  7,  7,  7]
         * [7,  7,  7,  7,  7,  7,  7,  -1, 10, 10, -1, -1]
         * [0,  0,  1,  0,  1,  2,  1,  0,  0,  1,  0,  0]
         */
        public int Trap(int[] height)
        {
            int len = height.Length;
            int[] arrLR = new int[len];
            int[] arrRL = new int[len];
            int currLRMax = height[0];
            int currRLMax = height[len - 1];

            for (int i = 1; i < len; i++)
            {
                if (currLRMax < height[i])
                {
                    currLRMax = height[i];
                }
                else
                {
                    arrLR[i] = currLRMax;
                }

                if (currRLMax < height[len - 1 - i])
                {
                    currRLMax = height[len - 1 - i];
                }
                else
                {
                    arrRL[len - 1 - i] = currRLMax;
                }
            }
            Console.WriteLine(string.Join(" , ", arrLR));
            Console.WriteLine(string.Join(" , ", arrRL));
            int result = 0;
            for (int i = 1; i < len - 1; i++)
            {
                int min = Math.Min(arrLR[i], arrRL[i]);
                if (min > height[i])
                {
                    result += (height[i] - min);
                    Console.WriteLine($"{i} : {result}");
                }
            }
            return result;
        }
        #endregion

        #region 88. Merge Sorted Array
        public void Merge(int[] nums1, int m, int[] nums2, int n)
        {
            int processedIndex = nums1.Length - 1;
            while (m > 0 && n > 0)
            {
                if (nums2[n - 1] >= nums1[m - 1])
                {
                    nums1[processedIndex] = nums2[n - 1];
                    n--;
                }
                else
                {
                    nums1[processedIndex] = nums1[m - 1];
                    m--;
                }
                processedIndex--;
            }
            while (n > 0)
            {
                nums1[processedIndex--] = nums2[--n];
            }
        }
        #endregion

        #region 118. Pascal's Triangle
        public IList<IList<int>> Generate(int numRows)
        {
            IList<int> lst = new List<int>() { 1 };
            IList<IList<int>> result = new List<IList<int>>()
            {
                new List<int>( lst)
            };
            if (numRows == 1) return result;
            lst.Add(1);
            result.Add(new List<int>(lst));

            if (numRows == 2) return result;

            for (int i = 3; i <= numRows; i++)
            {
                IList<int> temp = new List<int>() { 1 };
                for (int j = 1; j < lst.Count; j++)
                {
                    temp.Add(lst[j] + lst[j - 1]);
                }
                temp.Add(1);
                lst = temp;
                result.Add(new List<int>(lst));
            }

            return result;
        }
        #endregion

        #region 904. Fruit Into Baskets
        public int TotalFruit(int[] fruits)
        {
            int result = 1;
            Dictionary<int, int> map = new Dictionary<int, int>();
            int startIndex = 0;
            int currIndex = 1;
            map.Add(fruits[0], 1);

            while (currIndex < fruits.Length)
            {
                if (!map.ContainsKey(fruits[currIndex]))
                {
                    if (map.Count == 2)
                    {
                        result = Math.Max(result, currIndex - startIndex);
                        while (map.Count == 2)
                        {
                            map[fruits[startIndex]]--;
                            if (map[fruits[startIndex]] == 0)
                            {
                                map.Remove(fruits[startIndex]);
                            }
                            startIndex++;
                        }
                        map[fruits[currIndex]] = 1;
                    }
                    else
                    {
                        map[fruits[currIndex]] = 1;
                    }
                }
                else
                {
                    map[fruits[currIndex]]++;
                }

                currIndex++;
            }
            return Math.Max(result, currIndex - startIndex);
        }
        #endregion

        #region 2106. Maximum Fruits Harvested After at Most K Steps
        public int MaxTotalFruits(int[][] fruits, int startPos, int k)
        {
            int result = 0;
            int startPosFruit = 0;

            List<int> left = new List<int>();
            List<int> leftFruit = new List<int>();
            List<int> right = new List<int>();
            List<int> rightFruit = new List<int>();

            foreach (int[] arr in fruits)
            {
                int diff = Math.Abs(startPos - arr[0]);
                if (diff > k) continue;
                if (arr[0] < startPos)
                {
                    left.Insert(0, diff);
                    leftFruit.Insert(0, arr[1]);
                }
                else if (arr[0] == startPos)
                {
                    startPosFruit = arr[1];
                }
                else
                {
                    right.Add(diff);
                    rightFruit.Add(arr[1]);
                }
            }

            int[] leftPrefix = new int[left.Count + 1];

            for (int i = 1; i <= left.Count; i++)
            {
                leftPrefix[i] = leftPrefix[i - 1] + leftFruit[i - 1];
            }

            int[] rightPrefix = new int[right.Count + 1];

            for (int i = 1; i <= right.Count; i++)
            {
                rightPrefix[i] = rightPrefix[i - 1] + rightFruit[i - 1];
            }

            int kTemp = k;
            int currResult = 0;
            for (int i = 0; i < left.Count; i++)
            {
                kTemp = k;
                currResult = leftPrefix[i + 1];

                kTemp -= (2 * left[i]);
                if (kTemp > 0)
                {
                    int ub = UpperBound(right, kTemp);

                    currResult += rightPrefix[ub];
                }
                result = Math.Max(result, currResult);
            }

            for (int i = 0; i < right.Count; i++)
            {
                kTemp = k;
                currResult = rightPrefix[i + 1];

                kTemp -= (2 * right[i]);
                if (kTemp > 0)
                {
                    int ub = UpperBound(left, kTemp);

                    currResult += leftPrefix[ub];
                }
                result = Math.Max(result, currResult);
            }
            return result + startPosFruit;
        }

        private int UpperBound(List<int> arr, int k)
        {

            int left = 0;
            int right = arr.Count;
            int result = right;


            while (left < right)
            {
                int mid = (left + right) / 2;

                if (arr[mid] <= k)
                {
                    left = mid + 1;
                }
                else
                {
                    result = mid;
                    right = mid - 1;
                }
            }

            return result;

        }
        #endregion

        #region 2561. Rearranging Fruits
        public long MinCost(int[] basket1, int[] basket2)
        {
            long result = 0;
            Dictionary<int, int> freqMap = new Dictionary<int, int>();
            int min = int.MaxValue;
            for (int i = 0; i < basket1.Length; i++)
            {
                int currMin = Math.Min(basket1[i], basket2[i]);
                min = Math.Min(min, currMin);
                if (!freqMap.ContainsKey(basket1[i]))
                {
                    freqMap.Add(basket1[i], 0);
                }
                if (!freqMap.ContainsKey(basket2[i]))
                {
                    freqMap.Add(basket2[i], 0);
                }

                freqMap[basket1[i]]++;
                freqMap[basket2[i]]--;
            }
            List<int> lst = new List<int>();
            foreach (var key in freqMap.Keys)
            {
                if (freqMap[key] == 0) continue;
                if (freqMap[key] % 2 == 1) return -1;

                for (int i = 0; i < Math.Abs(freqMap[key]) / 2; i++)
                {
                    lst.Add(key);
                }
            }
            lst.Sort();

            for (int i = 0; i < lst.Count / 2; i++)
            {
                result += lst[i];
            }
            return result;
        }
        public long MinCost25611(int[] basket1, int[] basket2)
        {
            Array.Sort(basket1);
            Array.Sort(basket2);


            Dictionary<int, int> basket1Extra = new Dictionary<int, int>();
            Dictionary<int, int> basket2Extra = new Dictionary<int, int>();
            for (int i = 0; i < basket1.Length; i++)
            {
                if (basket1[i] == basket2[i]) continue;
                if (!basket1Extra.ContainsKey(basket1[i]))
                {
                    basket1Extra.Add(basket1[i], 0);
                }
                basket1Extra[basket1[i]]++;
                if (!basket2Extra.ContainsKey(basket2[i]))
                {
                    basket2Extra.Add(basket2[i], 0);
                }

                basket2Extra[basket1[i]]++;
            }
            if (basket1Extra.Count == 0 && basket2Extra.Count == 0) return 0;

            long result = 0;

            while (basket1Extra.Count > 1 && basket2Extra.Count > 1)
            {
                int basket1First = basket1Extra.Keys.First();
                int basket2Last = basket2Extra.Keys.Last();
                if (basket1Extra[basket1First] == basket2Extra[basket2Last])
                {
                    result += (basket1First * basket1Extra[basket1First]);
                    basket1Extra.Remove(basket1First);
                    basket2Extra.Remove(basket2Last);
                }
                else if (basket1Extra[basket1First] < basket2Extra[basket2Last])
                {
                    result += (basket1First * basket1Extra[basket1First]);
                    basket2Extra[basket2Last] -= basket1Extra[basket1First];
                    basket1Extra.Remove(basket1First);
                }
                else
                {
                    result += (basket1First * basket2Extra[basket2Last]);
                    basket1Extra[basket1First] -= basket2Extra[basket2Last];
                    basket2Extra.Remove(basket2Last);
                }
            }

            if (basket1Extra.Count == 1 && basket2Extra.Count == 1)
            {
                int key1 = basket1Extra.Keys.First();
                int key2 = basket2Extra.Keys.First();

                if (basket1Extra[key1] % 2 == 1 || basket2Extra[key2] % 2 == 1 || basket1Extra[key1] != basket2Extra[key2]) { return -1; }

                int val = basket1Extra[key1] / 2;

                int min = Math.Min(key1, key2);

                result += (min * val);
            }



            return result;
        }
        #endregion

        #region 3477. Fruits Into Baskets II
        public int NumOfUnplacedFruits(int[] fruits, int[] baskets)
        {
            int rem = 0;

            foreach (int fruit in fruits)
            {
                int placed = 1;
                for (int j = 0; j < baskets.Length; j++)
                {

                    if (baskets[j] >= fruit)
                    {
                        baskets[j] = 0;
                        placed = 0;
                        break;
                    }
                }

                rem += placed;
            }

            return rem;
        }

        public int NumOfUnplacedFruits1(int[] fruits, int[] baskets)
        {
            int rem = 0;
            HashSet<int> used = new HashSet<int>();

            foreach (int fruit in fruits)
            {
                bool placed = false;
                for (int j = 0; j < baskets.Length; j++)
                {

                    if (used.Contains(j)) continue;

                    if (baskets[j] >= fruit)
                    {
                        placed = true;
                        used.Add(j);
                        break;
                    }
                }

                if (!placed) rem++;
            }

            return rem;
        }
        #endregion
    }
}
