using System.Text;

namespace Leetcode2025
{
    public class Leetcode2025
    {
        #region 153. Find Minimum in Rotated Sorted Array
        public int FindMin_153(int[] nums)
        {

            int low = 0, high = nums.Length - 1;
            int min = Math.Min(nums[low], nums[high]);
            while (low < high)
            {
                int mid = (low + high) / 2;

                if (nums[mid] > nums[high])
                {
                    min = Math.Min(min, nums[high]);
                    low = mid + 1;
                }
                else if (nums[mid] < nums[low])
                {
                    min = Math.Min(min, nums[mid]);
                    high = mid - 1;
                }
                else
                {
                    min = Math.Min(min, nums[low]);
                    high = mid - 1;
                }
            }
            return min;
        }
        #endregion

        #region 154. Find Minimum in Rotated Sorted Array II
        public int FindMin(int[] nums)
        {
            return FindMin_Helper(nums, 0, nums.Length - 1);
        }

        private int FindMin_Helper(int[] nums, int low, int high)
        {
            if (high < 0) return nums[low];
            if (low >= nums.Length) return nums[high];
            if (low == high) return nums[low];

            int min = Math.Min(nums[low], nums[high]);
            if (low > high) return min;
            int mid = (low + high) / 2;

            if (nums[low] == nums[mid] && nums[high] == nums[mid])
            {
                return Math.Min(FindMin_Helper(nums, low, mid - 1), FindMin_Helper(nums, mid + 1, high));
            }

            while (low < high)
            {
                mid = (low + high) / 2;
                if (nums[mid] > nums[high])
                {
                    min = Math.Min(min, nums[high]);
                    low = mid + 1;
                }
                else if (nums[mid] < nums[low])
                {
                    min = Math.Min(min, nums[mid]);
                    high = mid - 1;
                }
                else
                {
                    min = Math.Min(min, nums[low]);
                    high = mid - 1;
                }
            }
            return min;
        }
        #endregion

        #region 174. Dungeon Game
        public int CalculateMinimumHP(int[][] dungeon)
        {
            PriorityQueue<(int row, int col, int prefixSum, int hp), int> priorityQueue = new PriorityQueue<(int row, int col, int prefixSum, int hp), int>();
            bool[][] visited = new bool[dungeon.Length][];
            for (int i = 0; i < dungeon.Length; i++)
            {
                visited[i] = new bool[dungeon[0].Length];
            }
            int hp = dungeon[0][0];
            if (hp <= 0)
            {
                hp = 0 - hp + 1;
            }

            priorityQueue.Enqueue((0, 0, dungeon[0][0], hp), hp);

            visited[0][0] = true;
            while (priorityQueue.Count > 0)
            {
                var dq = priorityQueue.Dequeue();

                if (dq.row == dungeon.Length - 1 && dq.col == dungeon[0].Length - 1) return dq.hp;
                int predecessor = dq.prefixSum, predecessorHP = dq.hp;
                //enqueue(priorityQueue, dungeon, visited, dq.row + 1, dq.col, predecessor, predecessorHP);
                //enqueue(priorityQueue, dungeon, visited, dq.row, dq.col + 1, predecessor, predecessorHP);

            }
            return 1;
        }

        private void enqueue(PriorityQueue<(int row, int col, int hp), int> priorityQueue, int[][] dungeon, bool[][] visited, int row, int col, int predecessor, int predecessorHP)
        {
            if (row == dungeon.Length || col == dungeon[0].Length || visited[row][col]) return;

            int curr = dungeon[row][col];

            if (curr < 0)
            {
                predecessorHP += (curr * -1);
            }
            else
            {
                predecessorHP -= (curr);
            }

            priorityQueue.Enqueue((row, col, predecessorHP), predecessorHP);
            visited[row][col] = true;
        }


        public int CalculateMinimumHP_1(int[][] dungeon)
        {
            int rows = dungeon.Length;
            int cols = dungeon[0].Length;

            for (int i = 1; i < rows; i++)
            {
                dungeon[i][0] += dungeon[i - 1][0];
            }

            for (int i = 1; i < cols; i++)
            {
                dungeon[0][i] += dungeon[0][i - 1];
            }

            for (int row = 1; row < rows; row++)
            {
                for (int col = 1; col < cols; col++)
                {
                    int right = 0 - dungeon[row][col] + dungeon[row][col - 1];
                    int down = 0 - dungeon[row][col] + dungeon[row - 1][col];
                    int min = Math.Min(right, down);
                    dungeon[row][col] = min;
                }
            }


            return dungeon[rows - 1][cols - 1] + 1;
        }
        #endregion

        #region 1422. Maximum Score After Splitting a String
        public int MaxScore(string s)
        {
            int one = 0;
            foreach (char c in s)
            {
                if (c == '1')
                {
                    one++;
                }
            }

            if (one == 0 || one == s.Length) return s.Length - 1;
            int zero = 0;
            if (s[0] == '0')
            {
                zero = 1;
            }
            else
            {
                one--;
            }

            int result = zero + one;

            for (int i = 1; i < s.Length - 1; i++)
            {
                char c = s[i];
                if (c == '0')
                {
                    zero++;
                }
                else
                {
                    one--;
                }

                result = Math.Max(result, zero + one);
            }

            return result;
        }
        #endregion

        #region 1769. Minimum Number of Operations to Move All Balls to Each Box
        public int[] MinOperations(string boxes)
        {
            int[] result = new int[boxes.Length];
            int leftSum = 0, rightSum = 0, leftone = 0, rightone = 0;

            for (int i = 0; i < boxes.Length ; i++)
            {
                leftSum += leftone;
                result[i] += leftSum;
                if (boxes[i]=='1') leftone++;

                int k = boxes.Length - 1 - i;
                rightSum += rightone;
                result[k] += rightSum;
                if(boxes[k] == '1') rightone++;
            }

            return result;
        }
        public int[] MinOperations_1(string boxes)
        {
            int[] result = new int[boxes.Length];
            int[] frontsum = new int[boxes.Length];
            int[] rearsum = new int[boxes.Length];
            int onecount = 0;
            if (boxes[0] == '1') onecount++;
            for (int i = 1; i < boxes.Length; i++)
            {
                frontsum[i] = frontsum[i - 1] + onecount;

                if (boxes[i] == '1') onecount++;
            }

            onecount = 0;
            if (boxes[boxes.Length - 1] == '1') onecount++;

            for (int i = boxes.Length - 2; i >= 0; i--)
            {
                rearsum[i] = rearsum[i + 1] + onecount;
                if (boxes[i] == '1') onecount++;
            }

            for (int i = 0; i < result.Length; i++)
            {
                result[i] = frontsum[i] + rearsum[i];
            }

            return result;
        }
        #endregion

        #region 1930. Unique Length-3 Palindromic Subsequences
        public int CountPalindromicSubsequence(string s)
        {
            int[] first = new int[26];
            int[] last = new int[26];
            for (int i = 0; i < s.Length; i++)
            {
                first[i] = -1;
                last[i] = -1;
            }

            for (int i = 0; i < s.Length; i++)
            {
                int index = s[i] - 'a';

                if (first[index] == -1)
                {
                    first[index] = i;
                }
                last[index] = i;
            }
            int count = 0;
            for (int i = 0; i < 26; i++)
            {
                if (first[i] != last[i] && first[i] != -1)
                {
                    HashSet<char> set = new HashSet<char>();
                    for (int j = first[i] + 1; j < last[i]; j++)
                    {
                        set.Add(s[j]);
                    }
                    count += set.Count;
                }
            }
            return count;
        }
        #endregion

        #region 2270. Number of Ways to Split Array
        public int WaysToSplitArray(int[] nums)
        {
            int count = 0;
            long sum = 0;

            for (int i = 0; i < nums.Length; i++)
            {
                sum += nums[i];
            }

            long prefixSum = 0;

            for (int i = 0; i < nums.Length - 1; i++)
            {
                prefixSum += nums[i];
                sum -= nums[i];
                if (prefixSum >= sum) count++;
            }

            return count;
        }
        #endregion

        #region 2381. Shifting Letters II

        public string ShiftingLetters(string s, int[][] shifts)
        {
            int n = s.Length;
            int[] diffArray = new int[n]; // Initialize a difference array with all elements set to 0.

            // Process each shift operation
            foreach (int[] shift in shifts)
            {
                if (shift[2] == 1)
                { // If direction is forward (1)
                    diffArray[shift[0]]++; // Increment at the start index
                    if (shift[1] + 1 < n)
                    {
                        diffArray[shift[1] + 1]--; // Decrement at the end+1 index
                    }
                }
                else
                { // If direction is backward (0)
                    diffArray[shift[0]]--; // Decrement at the start index
                    if (shift[1] + 1 < n)
                    {
                        diffArray[shift[1] + 1]++; // Increment at the end+1 index
                    }
                }
            }

            StringBuilder result = new StringBuilder(s);
            int numberOfShifts = 0;

            // Apply the shifts to the string
            for (int i = 0; i < n; i++)
            {
                numberOfShifts = (numberOfShifts + diffArray[i]) % 26; // Update cumulative shifts, keeping within the alphabet range
                if (numberOfShifts < 0) numberOfShifts += 26; // Ensure non-negative shifts

                // Calculate the new character by shifting `s[i]`
                char shiftedChar = (char)('a' +
                    ((s[i] - 'a' + numberOfShifts) % 26));
                result[i] = shiftedChar;
            }

            return result.ToString();
        }
        public string ShiftingLetters_2(string s, int[][] shifts)
        {
            char[] chars = new char[s.Length];
            int[] charPos = new int[chars.Length];
            charPos[0] = s[0] - 'a';
            for (int i = 1; i < s.Length; i++)
            {
                charPos[i] = s[i] - s[i - 1];
            }

            foreach (int[] shift in shifts)
            {
                int startIndex = shift[0];
                int endIndex = shift[1];
                int direction = shift[2];


                if (direction == 0)
                {
                    charPos[startIndex]--;
                    if (endIndex + 1 < s.Length)
                    {
                        charPos[endIndex + 1]++;
                    }
                }
                else
                {
                    charPos[startIndex]++;
                    if (endIndex + 1 < s.Length)
                    {
                        charPos[endIndex + 1]--;
                    }
                }
            }
            int index = 0;
            if (charPos[0] < 0)
            {
                index = charPos[0] % 26;
                index += 26;
            }
            else
            {
                index = charPos[0] % 26;
            }

            chars[0] = (char)('a' + index);
            for (int i = 1; i < chars.Length; i++)
            {
                chars[i] = (char)((chars[i - 1] + charPos[i]) % 26);
            }
            return new string(chars);
        }
        public string ShiftingLetters_1(string s, int[][] shifts)
        {
            char[] chars = s.ToCharArray();
            foreach (int[] shift in shifts)
            {
                updateArray1(chars, shift[0], shift[1], shift[2] == 0);
            }
            return new string(chars);
        }
        private void updateArray1(char[] chars, int startIndex, int endIndex, bool backward)
        {
            for (; startIndex <= endIndex; startIndex++)
            {
                if (backward)
                {
                    if (chars[startIndex] == 'a')
                    {
                        chars[startIndex] = 'z';
                    }
                    else
                    {
                        chars[startIndex]--;
                    }
                }
                else
                {
                    if (chars[startIndex] == 'z')
                    {
                        chars[startIndex] = 'a';
                    }
                    else
                    {
                        chars[startIndex]++;
                    }
                }
            }
        }
        #endregion

        #region 2559. Count Vowel Strings in Ranges
        public int[] VowelStrings(string[] words, int[][] queries)
        {
            HashSet<char> vowels = new HashSet<char>() { 'a', 'e', 'i', 'o', 'u' };
            int[] preCount = new int[words.Length];
            bool[] vowelString = new bool[words.Length];
            int initialCount = 0;
            for (int i = 0; i < words.Length; i++)
            {
                char first = words[i][0];
                char last = words[i][words[i].Length - 1];
                if (vowels.Contains(first) && vowels.Contains(last))
                {
                    initialCount++;
                    vowelString[i] = true;
                }
                preCount[i] = initialCount;
            }

            int[] result = new int[queries.Length];

            for (int i = 0; i < queries.Length; i++)
            {
                result[i] = preCount[queries[i][1]] - preCount[queries[i][0]];
                if (vowelString[queries[i][0]])
                {
                    result[i] += 1;
                }
            }

            return result;
        }
        #endregion
    }
}