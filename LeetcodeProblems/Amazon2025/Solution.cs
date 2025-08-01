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
    }
}
