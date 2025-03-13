using System.Security.Cryptography;
using System.Text;

namespace Leetcode2025
{
    public class Leetcode2025
    {
        #region 128. Longest Consecutive Sequence
        public int LongestConsecutive(int[] nums)
        {
            if (nums.Length <= 1) return nums.Length;
            UnionFind128 unionFind128 = new UnionFind128(nums.Length);
            Dictionary<int, int> map = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                if (!map.ContainsKey(nums[i]))
                {
                    map[nums[i]] = i;

                    if (map.ContainsKey(nums[i] - 1))
                    {
                        unionFind128.Union(i, map[nums[i] - 1]);
                    }

                    if (map.ContainsKey(nums[i] + 1))
                    {
                        unionFind128.Union(i, map[nums[i] + 1]);
                    }
                }
            }


            return unionFind128.GetMaxSize();
        }

        internal class UnionFind128
        {
            int[] parent;
            int[] rank;
            int[] size;
            int maxSize = 1;

            public UnionFind128(int n)
            {
                parent = new int[n];
                rank = new int[n];
                size = new int[n];

                for (int i = 0; i < n; i++)
                {
                    parent[i] = i;
                    rank[i] = 1;
                    size[i] = 1;
                }
            }

            internal void Union(int x, int y)
            {
                int parentX = Find(x);
                int parentY = Find(y);

                if (parentX != parentY)
                {
                    if (rank[parentX] > rank[parentY])
                    {
                        parent[parentY] = parentX;
                        size[parentX] += size[parentY];
                        maxSize = Math.Max(maxSize, size[parentX]);
                    }
                    else if (rank[parentX] < rank[parentY])
                    {
                        parent[parentX] = parentY;
                        size[parentY] += size[parentX];
                        maxSize = Math.Max(maxSize, size[parentY]);
                    }
                    else
                    {
                        parent[parentY] = parentX;
                        size[parentX] += size[parentY];
                        rank[parentX]++;
                        maxSize = Math.Max(maxSize, size[parentX]);
                    }
                }
            }

            internal int Find(int x)
            {
                if (parent[x] == x) return x;

                return parent[x] = Find(parent[x]);
            }

            internal int GetMaxSize()
            {
                return maxSize;
            }
        }
        #endregion

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
            int rows = dungeon.Length;
            int cols = dungeon[0].Length;
            int[,] dp = new int[rows, cols];

            dp[rows - 1, cols - 1] = dungeon[rows - 1][cols - 1];
            if (dp[rows - 1, cols - 1] > 0)
            {
                dp[rows - 1, cols - 1] = 0;
            }
            for (int row = rows - 2; row >= 0; row--)
            {
                int curr = dungeon[row][cols - 1] + dp[row + 1, cols - 1];

                if (curr > 0)
                {
                    curr = 0;
                }
                dp[row, cols - 1] = curr;
            }
            for (int col = cols - 2; col >= 0; col--)
            {
                int curr = dungeon[rows - 1][col] + dp[rows - 1, col + 1];

                if (curr > 0)
                {
                    curr = 0;
                }
                dp[rows - 1, col] = curr;
            }
            for (int row = rows - 2; row >= 0; row--)
            {
                for (int col = cols - 2; col >= 0; col--)
                {
                    int max = Math.Max(dp[row + 1, col], dp[row, col + 1]);

                    int curr = dungeon[row][col] + max;

                    if (curr > 0)
                    {
                        curr = 0;
                    }

                    dp[row, col] = curr;
                }
            }

            if (dp[0, 0] <= 0)
            {
                dp[0, 0] = (dp[0, 0] * -1) + 1;
            }

            return dp[0, 0];
        }
        public int CalculateMinimumHP_NotWorking(int[][] dungeon)
        {
            int[,] dpHP = new int[dungeon.Length, dungeon[0].Length];
            int[,] dpSum = new int[dungeon.Length, dungeon[0].Length];

            int x = dungeon[0][0];
            int hp = 1;
            if (x < 0)
            {
                hp = (x * -1) + 1;
            }
            dpHP[0, 0] = hp;
            dpSum[0, 0] = x;

            for (int row = 1; row < dungeon.Length; row++)
            {
                dpSum[row, 0] = dpSum[row - 1, 0] + dungeon[row][0];
                if (dpSum[row, 0] < dpSum[row - 1, 0] && dpSum[row, 0] < 0)
                {
                    dpHP[row, 0] = (dpSum[row, 0] * -1) + 1;
                }
                else
                {
                    dpHP[row, 0] = dpHP[row - 1, 0];
                }
            }

            for (int col = 1; col < dungeon[0].Length; col++)
            {
                dpSum[0, col] = dpSum[0, col - 1] + dungeon[0][col];

                if (dpSum[0, col] < dpSum[0, col - 1] && dpSum[0, col] < 0)
                {
                    dpHP[0, col] = (dpSum[0, col] * -1) + 1;
                }
                else
                {
                    dpHP[0, col] = dpHP[0, col - 1];
                }
            }

            for (int row = 1; row < dungeon.Length; row++)
            {
                for (int col = 1; col < dungeon[row].Length; col++)
                {
                    int topSum = dpSum[row - 1, col] + dungeon[row][col];
                    int topHP = dpHP[row - 1, col];
                    int leftSum = dpSum[row, col - 1] + dungeon[row][col];
                    int leftHP = dpHP[row, col - 1];

                    if (dungeon[row][col] < 0)
                    {
                        if (topSum < 0)
                        {
                            topHP = (topSum * -1) + 1;
                        }

                        if (leftSum < 0)
                        {
                            leftHP = (leftSum * -1) + 1;
                        }
                    }

                    if (leftHP == topHP)
                    {
                        dpSum[row, col] = Math.Max(leftSum, topSum);
                        dpHP[row, col] = leftHP;
                    }
                    else if (leftHP < topHP)
                    {
                        dpSum[row, col] = leftSum;
                        dpHP[row, col] = leftHP;
                    }
                    else
                    {
                        dpSum[row, col] = topSum;
                        dpHP[row, col] = topHP;
                    }
                }
            }

            return dpHP[dungeon.Length - 1, dungeon[0].Length - 1];
        }

        public int CalculateMinimumHP3(int[][] dungeon)
        {
            bool[,] visited = new bool[dungeon.Length, dungeon[0].Length];
            PriorityQueue<(int row, int col, int sum, int hp), int> pq = new PriorityQueue<(int row, int col, int sum, int hp), int>(Comparer<int>.Create((a, b) => b - a));

            int hp = 1;
            if (dungeon[0][0] < 0)
            {
                hp = (dungeon[0][0] * -1) + 1;
            }
            pq.Enqueue((0, 0, dungeon[0][0], hp), dungeon[0][0]);
            while (pq.Count > 0)
            {
                var dq = pq.Dequeue();
                if (dq.row == dungeon.Length - 1 && dq.col == dungeon[0].Length - 1) return dq.hp;

                visited[dq.row, dq.col] = true;
                enqueue(pq, dungeon, visited, dq.row + 1, dq.col, dq.sum, dq.hp);
                enqueue(pq, dungeon, visited, dq.row, dq.col + 1, dq.sum, dq.hp);
            }
            return 1;
        }

        private void enqueue(PriorityQueue<(int row, int col, int sum, int hp), int> pq, int[][] dungeon, bool[,] visited, int row, int col, int sum, int hp)
        {
            if (row == dungeon.Length || col == dungeon[0].Length || visited[row, col])
                return;

            sum += dungeon[row][col];

            if (sum < 0)
            {
                int currHp = (sum * -1) + 1;

                hp = Math.Max(hp, currHp);
            }
            pq.Enqueue((row, col, sum, hp), sum);
        }

        public int CalculateMinimumHP_TLE(int[][] dungeon)
        {
            PriorityQueue<(int row, int col, int sum, int hp), int> pq = new PriorityQueue<(int row, int col, int sum, int hp), int>(Comparer<int>.Create((a, b) => b - a));

            int hp = 1;
            if (dungeon[0][0] < 0)
            {
                hp = (dungeon[0][0] * -1) + 1;
            }
            pq.Enqueue((0, 0, dungeon[0][0], hp), dungeon[0][0]);

            while (pq.Count > 0)
            {
                var dq = pq.Dequeue();
                if (dq.row == dungeon.Length - 1 && dq.col == dungeon[0].Length - 1) return dq.hp;
                enqueue(pq, dungeon, dq.row + 1, dq.col, dq.sum, dq.hp);
                enqueue(pq, dungeon, dq.row, dq.col + 1, dq.sum, dq.hp);
            }
            return 1;
        }

        private void enqueue(PriorityQueue<(int row, int col, int sum, int hp), int> pq, int[][] dungeon, int row, int col, int sum, int hp)
        {
            if (row == dungeon.Length || col == dungeon[0].Length) return;

            sum += dungeon[row][col];

            if (sum < 0)
            {
                int currHp = (sum * -1) + 1;

                hp = Math.Max(hp, currHp);
            }
            pq.Enqueue((row, col, sum, hp), sum);
        }

        public int CalculateMinimumHP_2(int[][] dungeon)
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

        #region 214. Shortest Palindrome
        public string ShortestPalindrome(string s)
        {
            int index = s.Length - 1;
            while (index >= 0)
            {
                if (s[0] == s[index])
                {
                    int left = 0, right = index;

                    while (left < right && s[left] == s[right])
                    {
                        left++;
                        right--;
                    }

                    if (left >= right)
                    {
                        break;
                    }

                }
                index--;
            }

            if (index < s.Length - 1)
            {
                string ss = s.Substring(index + 1);

                return new string(ss.Reverse().ToArray()) + s;
            }

            return s;
        }

        public string ShortestPalindrome1(string s)
        {
            int len = s.Length;
            char[] chars = new char[len];
            for (int i = 0; i < s.Length; i++)
            {
                chars[i] = s[len - 1 - i];
            }

            bool[,] palindromeMatrix = new bool[len, len];

            for (int i = 0; i < len - 1; i++)
            {
                palindromeMatrix[i, i] = true;
                palindromeMatrix[i + 1, i] = true;
            }

            palindromeMatrix[len - 1, len - 1] = true;
            int col = 1;
            while (col < len)
            {
                int curCol = col;
                for (int row = 0; row < len && curCol < len; row++)
                {
                    if (chars[row] == chars[curCol] && palindromeMatrix[row + 1, curCol - 1])
                    {
                        palindromeMatrix[row, curCol] = true;
                    }
                    curCol++;
                }
                col++;
            }

            if (palindromeMatrix[0, len - 1]) return s;

            int index = len - 1;

            for (int k = 1; k < len; k++)
            {
                if (palindromeMatrix[k, len - 1])
                {
                    index = k;
                    break;
                }
            }

            StringBuilder sb = new StringBuilder();
            int kIndex = 0;
            while (kIndex < index)
            {
                sb.Append(chars[kIndex++]);
            }

            sb.Append(s);

            return sb.ToString();
        }
        #endregion

        #region 218. The Skyline Problem
        public IList<IList<int>> GetSkyline(int[][] buildings)
        {
            IList<IList<int>> result = new List<IList<int>>();

            PriorityQueue<(int left, int right, int height), (int left, int height)> pq = new PriorityQueue<(int left, int right, int height), (int left, int height)>(Comparer<(int left, int height)>.Create((x, y) =>
            {
                if (x.left == y.left)
                {
                    return y.height - x.height;
                }

                return x.left - y.left;
            }));

            //SortedSet<int> set = new SortedSet<int>();

            foreach (int[] building in buildings)
            {
                pq.Enqueue((building[0], building[1], building[2]), (building[0], building[2]));
            }
            var top = pq.Peek();
            result.Add(new List<int> { top.left, top.height });


            //for(int node = 1; node<buildings.Length; node++)
            //{
            //    if()
            //}


            return result;
        }
        #endregion

        #region 407. Trapping Rain Water II
        public int TrapRainWater(int[][] heightMap)
        {
            int result = 0;

            int rows = heightMap.Length;
            int cols = heightMap[0].Length;

            int[,] dp = new int[rows, cols];
            for (int row = 0; row < rows; row++)
            {
                dp[row, 0] = -1;
                dp[row, cols - 1] = -1;
            }

            for (int col = 1; col < cols - 1; col++)
            {
                dp[0, col] = -1;
                dp[rows - 1, col] = -1;
            }

            PriorityQueue<(int row, int col), int> pq = new PriorityQueue<(int row, int col), int>(Comparer<int>.Create((x, y) => y - x));
            for (int row = 1; row < rows - 1; row++)
            {
                for (int col = 1; col < cols - 1; col++)
                {
                    pq.Enqueue((row, col), heightMap[row][col]);
                }
            }

            while (pq.Count > 0)
            {

            }

            return result;
        }

        public int TrapRainWater2(int[][] heightMap)
        {
            int result = 0;
            int rows = heightMap.Length;
            int cols = heightMap[0].Length;

            int[,] dp = new int[rows, cols];
            for (int row = 0; row < rows; row++)
            {
                dp[row, 0] = -1;
                dp[row, cols - 1] = -1;
            }

            for (int col = 1; col < cols - 1; col++)
            {
                dp[0, col] = -1;
                dp[rows - 1, col] = -1;
            }

            PriorityQueue<(int row, int col), int> pq = new PriorityQueue<(int row, int col), int>(Comparer<int>.Create((x, y) => y - x));
            for (int row = 1; row < rows - 1; row++)
            {
                for (int col = 1; col < cols - 1; col++)
                {
                    pq.Enqueue((row, col), heightMap[row][col]);
                }
            }

            while (pq.Count > 0)
            {
                (int row, int col) = pq.Dequeue();

                int topGreatElement = getTopLargestElement1(dp, heightMap, row, col);
                if (topGreatElement == -1)
                {
                    dp[row, col] = -1;
                    continue;
                }
                int bottomGreatElement = getBottomLargestElement2(dp, heightMap, row, col);
                if (bottomGreatElement == -1)
                {
                    dp[row, col] = -1;
                    continue;
                }
                int leftGreatElement = getLeftLargestElement3(dp, heightMap, row, col);
                if (leftGreatElement == -1)
                {
                    dp[row, col] = -1;
                    continue;
                }
                int rightGreatElement = getRightLargestElement4(dp, heightMap, row, col);
                if (rightGreatElement == -1)
                {
                    dp[row, col] = -1;
                    continue;
                }

                int min = Math.Min(topGreatElement, Math.Min(bottomGreatElement, Math.Min(leftGreatElement, rightGreatElement)));

                dp[row, col] = min;
                result += (min - heightMap[row][col]);
            }



            return result;
        }

        private int getTopLargestElement1(int[,] dp, int[][] heightMap, int row, int col)
        {
            int curIndex = row;
            while (--curIndex >= 0 && dp[curIndex, col] == 0)
            {
            }

            if (curIndex > 0)
            {
                return dp[curIndex, col];
            }

            if (curIndex == 0)
            {
                if (heightMap[row][col] < heightMap[0][col]) return heightMap[0][col];
            }

            return -1;
        }

        private int getBottomLargestElement2(int[,] dp, int[][] heightMap, int row, int col)
        {
            int curIndex = row;
            while (++curIndex < heightMap.Length && dp[curIndex, col] == 0)
            {
            }

            if (curIndex < heightMap.Length - 1)
            {
                return dp[curIndex, col];
            }

            if (curIndex == heightMap.Length - 1)
            {
                if (heightMap[row][col] < heightMap[heightMap.Length - 1][col]) return heightMap[heightMap.Length - 1][col];
            }

            return -1;
        }

        private int getLeftLargestElement3(int[,] dp, int[][] heightMap, int row, int col)
        {
            int curIndex = col;
            while (--curIndex >= 0 && dp[row, curIndex] == 0)
            {
            }

            if (curIndex > 0) return dp[curIndex, col];

            if (curIndex == 0)
            {
                if (heightMap[row][col] < heightMap[row][0]) return heightMap[row][0];
            }

            return -1;
        }

        private int getRightLargestElement4(int[,] dp, int[][] heightMap, int row, int col)
        {
            int curIndex = col;
            while (++curIndex < heightMap[0].Length && dp[row, curIndex] == 0)
            {
            }

            if (curIndex < heightMap[0].Length - 1) return dp[row, curIndex];

            if (curIndex == heightMap[0].Length - 1)
            {
                if (heightMap[row][col] < heightMap[row][heightMap[0].Length - 1]) return heightMap[row][heightMap[0].Length - 1];
            }

            return -1;
        }

        public int TrapRainWater1(int[][] heightMap)
        {
            int rows = heightMap.Length;
            int cols = heightMap[0].Length;

            if (rows <= 2 || cols <= 2) return 0;
            int[][] nextLargestArrayRows = new int[heightMap.Length][];
            int[][] nextLargestArrayCols = new int[heightMap[0].Length][];
            int[][] prevLargestArrayRows = new int[heightMap.Length][];
            int[][] prevLargestArrayCols = new int[heightMap[0].Length][];

            for (int row = 0; row < rows; row++)
            {
                nextLargestArrayRows[row] = getNextLargestElement(heightMap[row]);
                prevLargestArrayRows[row] = getPrevLargestElement(heightMap[row]);
            }

            for (int col = 0; col < cols; col++)
            {
                nextLargestArrayCols[col] = getNextLargestElement(heightMap, col);
                prevLargestArrayCols[col] = getPrevLargestElement(heightMap, col);
            }

            int[,] dp = new int[rows, cols];
            int sum = 0;
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    if (row == 0 || col == 0 || row == rows - 1 || col == cols - 1)
                    {
                        dp[row, col] = -1;
                    }
                    else
                    {
                        int topIndex = prevLargestArrayCols[col][row];
                        int bottomIndex = nextLargestArrayCols[col][row];
                        int leftIndex = prevLargestArrayRows[row][col];
                        int rightIndex = nextLargestArrayRows[row][col];

                        if (topIndex == -1 || bottomIndex == -1 || leftIndex == -1 || rightIndex == -1) { dp[row, col] = -1; }
                        else
                        {

                            int val = heightMap[topIndex][col];

                            val = Math.Min(val, heightMap[bottomIndex][col]);
                            val = Math.Min(val, heightMap[row][leftIndex]);
                            val = Math.Min(val, heightMap[row][rightIndex]);

                            dp[row, col] = val;
                        }
                    }
                }
            }
            bool[,] visited = new bool[rows, cols];
            Dictionary<int, List<(int row, int col)>> map = new Dictionary<int, List<(int row, int col)>>();

            for (int row = 1; row < rows - 1; row++)
            {
                for (int col = 1; col < cols - 1; col++)
                {
                    if (dp[row, col] > 0 && !visited[row, col])
                    {

                        map[-1] = new List<(int row, int col)>();
                        int min = traverse(dp, visited, map[-1], row, col, rows, cols);
                        if (map.ContainsKey(min))
                        {
                            map[min].AddRange(map[-1]);
                        }
                        else
                        {
                            map[min] = new List<(int row, int col)>(map[-1]);
                        }
                    }
                    else
                    {
                        visited[row, col] = true;
                    }
                }
            }
            map.Remove(-1);

            foreach (var key in map.Keys)
            {
                foreach ((int row, int col) in map[key])
                {
                    sum += (key - heightMap[row][col]);
                }
            }

            return sum;
        }
        private int traverse(int[,] dp, bool[,] visited, List<(int row, int col)> list, int row, int col, int rows, int cols)
        {
            int min = dp[row, col];
            visited[row, col] = true;
            Queue<(int row, int col)> q = new Queue<(int row, int col)>();
            q.Enqueue((row, col));

            while (q.Count > 0)
            {
                var dq = q.Dequeue();
                list.Add((dq.row, dq.col));

                min = Math.Min(min, addInQ(q, dp, visited, dq.row - 1, dq.col, rows, cols));

                min = Math.Min(min, addInQ(q, dp, visited, dq.row + 1, dq.col, rows, cols));

                min = Math.Min(min, addInQ(q, dp, visited, dq.row, dq.col - 1, rows, cols));

                min = Math.Min(min, addInQ(q, dp, visited, dq.row, dq.col + 1, rows, cols));
            }

            return min;
        }
        private int addInQ(Queue<(int row, int col)> q, int[,] dp, bool[,] visited, int row, int col, int rows, int cols)
        {
            if (row <= 0 || col <= 0 || row >= rows || col >= cols || visited[row, col] || dp[row, col] == -1) return int.MaxValue;

            visited[row, col] = true;
            q.Enqueue((row, col));
            return dp[row, col];
        }
        private int[] getNextLargestElement(int[] arr)
        {
            int[] result = new int[arr.Length];
            Stack<int> stack = new Stack<int>();
            int currIndex = arr.Length - 1;
            result[currIndex] = -1;
            stack.Push(currIndex);
            while (--currIndex >= 0)
            {
                while (stack.Count > 0 && arr[stack.Peek()] <= arr[currIndex])
                {
                    stack.Pop();
                }

                if (stack.Count == 0)
                {
                    result[currIndex] = -1;
                    stack.Push(currIndex);
                }
                else
                {
                    result[currIndex] = stack.Peek();
                }
            }
            return result;
        }
        private int[] getPrevLargestElement(int[] arr)
        {
            int[] result = new int[arr.Length];
            Stack<int> stack = new Stack<int>();
            int currIndex = 0;
            result[currIndex] = -1;
            stack.Push(currIndex);
            while (++currIndex < arr.Length)
            {
                while (stack.Count > 0 && arr[stack.Peek()] <= arr[currIndex])
                {
                    stack.Pop();
                }

                if (stack.Count == 0)
                {
                    result[currIndex] = -1;
                    stack.Push(currIndex);
                }
                else
                {
                    result[currIndex] = stack.Peek();
                }
            }
            return result;
        }
        private int[] getNextLargestElement(int[][] heightMap, int col)
        {
            int[] result = new int[heightMap.Length];
            Stack<int> stack = new Stack<int>();
            int currIndex = heightMap.Length - 1;
            result[currIndex] = -1;
            stack.Push(currIndex);
            while (--currIndex >= 0)
            {
                while (stack.Count > 0 && heightMap[stack.Peek()][col] <= heightMap[currIndex][col])
                {
                    stack.Pop();
                }

                if (stack.Count == 0)
                {
                    result[currIndex] = -1;
                    stack.Push(currIndex);
                }
                else
                {
                    result[currIndex] = stack.Peek();
                }
            }
            return result;
        }
        private int[] getPrevLargestElement(int[][] heightMap, int col)
        {
            int[] result = new int[heightMap.Length];
            Stack<int> stack = new Stack<int>();
            int currIndex = 0;
            result[currIndex] = -1;
            stack.Push(currIndex);
            while (++currIndex < heightMap.Length)
            {
                while (stack.Count > 0 && heightMap[stack.Peek()][col] <= heightMap[currIndex][col])
                {
                    stack.Pop();
                }

                if (stack.Count == 0)
                {
                    result[currIndex] = -1;
                    stack.Push(currIndex);
                }
                else
                {
                    result[currIndex] = stack.Peek();
                }
            }
            return result;

        }
        #endregion

        #region 684. Redundant Connection
        public int[] FindRedundantConnection(int[][] edges)
        {
            UnionFind684 unionFind684 = new UnionFind684(edges.Length);

            foreach (int[] edge in edges)
            {
                if (!unionFind684.Union(edge[0] - 1, edge[1] - 1))
                {
                    return edge;
                }
            }
            return [];
        }

        internal class UnionFind684
        {
            int[] parent;
            int[] rank;
            public UnionFind684(int size)
            {
                parent = new int[size];
                rank = new int[size];

                for (int i = 0; i < size; i++)
                {
                    parent[i] = i;
                    rank[i] = 1;
                }
            }

            internal bool Union(int x, int y)
            {
                int parentX = Find(x);
                int parentY = Find(y);

                if (parentX == parentY) return false;

                if (rank[parentX] > rank[parentY])
                {
                    parent[parentY] = parentX;
                    rank[parentX]++;
                }
                else
                {
                    parent[parentX] = parentY;
                    rank[parentY]++;
                }

                return true;
            }

            internal int Find(int x)
            {
                if (parent[x] == x) return x;

                return parent[x] = Find(parent[x]);
            }

        }
        #endregion

        #region 802. Find Eventual Safe States
        public IList<int> EventualSafeNodes(int[][] graph)
        {
            IList<int> result = new List<int>();
            int[] outgoing = new int[graph.Length];
            List<int>[] incoming = new List<int>[graph.Length];
            for (int i = 0; i < graph.Length; i++)
            {
                incoming[i] = new List<int>();
            }
            Queue<int> q = new Queue<int>();
            for (int i = 0; i < graph.Length; i++)
            {
                if (graph[i].Length == 0)
                {
                    q.Enqueue(i);
                }
                else
                {
                    outgoing[i] = graph[i].Length;
                    foreach (int j in graph[i])
                    {
                        incoming[j].Add(i);
                    }
                }
            }

            while (q.Count > 0)
            {
                int safe = q.Dequeue();

                foreach (int i in incoming[safe])
                {
                    outgoing[i]--;
                    if (outgoing[i] == 0)
                    {
                        q.Enqueue(i);
                    }
                }

            }

            for (int i = 0; i < outgoing.Length; i++)
            {
                if (outgoing[i] == 0)
                {
                    result.Add(i);
                }
            }

            return result;
        }
        #endregion

        #region 827. Making A Large Island
        public int LargestIsland(int[][] grid)
        {
            IList<(int row, int col)> zerosSet = new List<(int row, int col)>();
            Dictionary<int, int> mapArea = new Dictionary<int, int>();
            int result = 0;
            int currCounter = 2;
            for (int row = 0; row < grid.Length; row++)
            {
                for (int col = 0; col < grid.Length; col++)
                {
                    if (grid[row][col] == 1)
                    {
                        int areaCount = getLandAreaCount(grid, row, col, currCounter);
                        result = Math.Max(result, areaCount);
                        mapArea.Add(currCounter, areaCount);
                        currCounter++;
                    }
                    else if (grid[row][col] == 0)
                    {
                        zerosSet.Add((row, col));
                    }
                }
            }

            if (result == 0) return 1;

            foreach ((int row, int col) in zerosSet)
            {
                int cur = 1;
                HashSet<int> neighbors = new HashSet<int>();

                if (row - 1 >= 0 && grid[row - 1][col] > 0) neighbors.Add(grid[row - 1][col]);
                if (row + 1 < grid.Length && grid[row + 1][col] > 0) neighbors.Add(grid[row + 1][col]);
                if (col - 1 >= 0 && grid[row][col - 1] > 0) neighbors.Add(grid[row][col - 1]);
                if (col + 1 < grid.Length && grid[row][col + 1] > 0) neighbors.Add(grid[row][col + 1]);

                foreach (var neighbor in neighbors)
                {
                    cur += mapArea[neighbor];
                }
                result = Math.Max((int)cur, result);
            }

            return result;
        }

        private int getLandAreaCount(int[][] grid, int row, int col, int currCounter)
        {
            int count = 0;
            Queue<(int row, int col)> q = new Queue<(int, int)>();
            q.Enqueue((row, col));
            grid[row][col] = currCounter;
            while (q.Count > 0)
            {
                count++;
                var dq = q.Dequeue();

                enqueue(q, dq.row + 1, dq.col, grid, currCounter);
                enqueue(q, dq.row - 1, dq.col, grid, currCounter);
                enqueue(q, dq.row, dq.col + 1, grid, currCounter);
                enqueue(q, dq.row, dq.col - 1, grid, currCounter);

            }

            return count;
        }

        private void enqueue(Queue<(int row, int col)> q, int row, int col, int[][] grid, int currCounter)
        {
            if (row < 0 || row >= grid.Length || col < 0 || col >= grid.Length || grid[row][col] != 1) return;

            grid[row][col] = currCounter;
            q.Enqueue((row, col));
        }
        #endregion

        #region 873. Length of Longest Fibonacci Subsequence
        public int LenLongestFibSubseq(int[] arr)
        {
            int n = arr.Length;
            int[,] dp = new int[n, n];
            int maxLen = 0;

            for (int curr = 2; curr < n; curr++)
            {
                int start = 0;
                int end = curr - 1;

                while (start < end)
                {
                    int pairSum = arr[start] + arr[end];

                    if (pairSum > arr[curr])
                    {
                        end--;
                    }
                    else if (pairSum < arr[curr])
                    {
                        start++;
                    }
                    else
                    {
                        dp[end, curr] = dp[start, end] + 1;
                        maxLen = Math.Max(dp[end, curr], maxLen);
                        end--;
                        start++;
                    }
                }
            }

            return maxLen == 0 ? 0 : maxLen + 2;
        }
        #endregion

        #region 889. Construct Binary Tree from Preorder and Postorder Traversal
        public TreeNode ConstructFromPrePost(int[] preorder, int[] postorder)
        {
            return ConstructFromPrePost(preorder, postorder, 0, preorder.Length - 1, 0, postorder.Length - 1);
        }

        private TreeNode ConstructFromPrePost(int[] preorder, int[] postorder, int start1, int end1, int start2, int end2)
        {

            TreeNode root = null;

            if (start1 <= end1)
            {
                root = new TreeNode(preorder[start1]);

                if (start1 != end1)
                {
                    if (preorder[start1 + 1] == postorder[end2 - 1])
                    {
                        root.left = ConstructFromPrePost(preorder, postorder, start1 + 1, end1, start2, end2 - 1);
                    }
                    else
                    {
                        int rightIndex = getIndexFromBack(preorder, end1, start1, postorder[end2 - 1]);
                        int leftIndex = getIndexFromFront(postorder, end2, start2, preorder[start1 + 1]);

                        root.left = ConstructFromPrePost(preorder, postorder, start1 + 1, rightIndex - 1, start2, leftIndex);
                        root.right = ConstructFromPrePost(preorder, postorder, rightIndex, end1, leftIndex + 1, end2 - 1);

                    }
                }

            }
            return root;
        }

        private int getIndexFromBack(int[] arr, int end, int start, int searchValue)
        {
            for (int i = end; i >= start; i--)
            {
                if (arr[i] == searchValue) return i;
            }
            return -1;
        }

        private int getIndexFromFront(int[] arr, int end, int start, int searchValue)
        {
            for (int i = start; i <= end; i++)
            {
                if (arr[i] == searchValue) return i;
            }
            return -1;
        }
        #endregion

        #region 916. Word Subsets
        public IList<string> WordSubsets(string[] words1, string[] words2)
        {
            int[] arr = new int[26];
            HashSet<string> set = new HashSet<string>(words2);
            foreach (var word in set)
            {
                int[] temp = new int[26];
                foreach (char c in word)
                {
                    temp[c - 'a']++;
                    arr[c - 'a'] = Math.Max(arr[c - 'a'], temp[c - 'a']);
                }
            }

            IList<string> list = new List<string>();
            foreach (string word in words1)
            {
                int[] temp = new int[26];
                foreach (char c in word)
                {
                    temp[c - 'a']++;
                }
                bool isAdd = true;
                for (int i = 0; i < 26; i++)
                {
                    if (temp[i] < arr[i])
                    {
                        isAdd = false;
                        break;
                    }
                }
                if (isAdd) list.Add(word);
            }
            return list;
        }
        #endregion

        #region 1028. Recover a Tree From Preorder Traversal
        public TreeNode RecoverFromPreorder(string traversal)
        {
            int currIndex = 0;
            int currNodeValue = traversal[0] - '0';

            while (++currIndex < traversal.Length && char.IsDigit(traversal[currIndex]))
            {
                currNodeValue *= 10;

                currNodeValue += (traversal[currIndex] - '0');
            }

            TreeNode root = new TreeNode(currNodeValue);
            root.left = RecoverFromPreorder(traversal, 1, ref currIndex);
            root.right = RecoverFromPreorder(traversal, 1, ref currIndex);

            return root;
        }

        private TreeNode RecoverFromPreorder(string traversal, int level, ref int index)
        {
            if (index == traversal.Length) return null;
            int dashCount = 1;

            while (traversal[++index] == '-')
            {
                dashCount++;
            }
            TreeNode node = null;
            if (dashCount == level)
            {
                int currNodeValue = traversal[index] - '0';
                while (++index < traversal.Length && char.IsDigit(traversal[index]))
                {
                    currNodeValue *= 10;
                    currNodeValue += (traversal[index] - '0');
                }

                node = new TreeNode(currNodeValue);

                node.left = RecoverFromPreorder(traversal, level + 1, ref index);
                node.right = RecoverFromPreorder(traversal, level + 1, ref index);
            }
            else
            {
                index -= dashCount;
            }

            return node;
        }
        private TreeNode RecoverFromPreorder1(string traversal, int level, ref int index)
        {
            if (index == traversal.Length) return null;
            int curr = traversal[index] - '0';

            while (++index < traversal.Length && char.IsDigit(traversal[index]))
            {
                curr *= 10;
                curr += (traversal[index] - '0');
            }
            TreeNode treeNode = new TreeNode(curr);
            if (index < traversal.Length && traversal[index] == '-')
            {
                int dashCount = 1;
                while (traversal[++index] == '-')
                {
                    dashCount++;
                }
                if (dashCount == level + 1)
                {
                    treeNode.left = RecoverFromPreorder(traversal, level + 1, ref index);

                    if (index < traversal.Length && traversal[index] == '-')
                    {
                        dashCount = 1;
                        while (traversal[++index] == '-')
                        {
                            dashCount++;
                        }

                        if (dashCount == level + 1)
                        {

                            treeNode.right = RecoverFromPreorder(traversal, level + 1, ref index);
                        }

                    }
                }
                else
                {
                    index -= dashCount;
                }
            }
            return treeNode;
        }
        #endregion

        #region 1079. Letter Tile Possibilities
        public int NumTilePossibilities(string tiles)
        {
            int[] chars = new int[26];

            foreach (char c in tiles)
            {
                chars[c - 'A']++;
            }
            return NumTilePossibilities(chars);
        }

        private int NumTilePossibilities(int[] chars)
        {
            int totalCount = 0;

            for (int curr = 0; curr < 26; curr++)
            {
                if (chars[curr] == 0) continue;

                totalCount++;
                chars[curr]--;
                totalCount += NumTilePossibilities(chars);
                chars[curr]++;
            }

            return totalCount;
        }

        public int NumTilePossibilities_1(string tiles)
        {
            HashSet<string> set = new HashSet<string>();
            bool[] used = new bool[tiles.Length];

            NumTilePossibilities_Recursion_1(tiles, set, used, new StringBuilder());

            return set.Count - 1;
        }

        private void NumTilePossibilities_Recursion_1(string tiles, HashSet<string> set, bool[] used, StringBuilder stringBuilder)
        {
            set.Add(stringBuilder.ToString());

            for (int curr = 0; curr < tiles.Length; curr++)
            {
                if (!used[curr])
                {
                    used[curr] = true;
                    NumTilePossibilities_Recursion_1(tiles, set, used, stringBuilder.Append(tiles[curr]));
                    used[curr] = false;
                    stringBuilder.Remove(stringBuilder.Length - 1, 1);
                }
            }
        }
        #endregion

        #region 1092. Shortest Common Supersequence 
        public string ShortestCommonSupersequence(string str1, string str2)
        {
            int str1Length = str1.Length;
            int str2Length = str2.Length;

            string[] prevRow = new string[str2Length + 1];
            for (int col = 0; col <= str2Length; col++)
            {
                prevRow[col] = str2.Substring(0, col);
            }

            for (int row = 1; row <= str1Length; row++)
            {
                string[] currRow = new string[str2Length + 1];
                currRow[0] = str1.Substring(0, row);

                for (int col = 1; col <= str2Length; col++)
                {
                    if (str1[row - 1] == str2[col - 1])
                    {
                        currRow[col] = prevRow[col - 1] + str1[row - 1];
                    }
                    else
                    {
                        string pickS1 = prevRow[col];
                        string pickS2 = currRow[col - 1];

                        currRow[col] = (pickS1.Length < pickS2.Length)
                            ? pickS1 + str1[row - 1]
                            : pickS2 + str2[col - 1];
                    }
                }
                prevRow = currRow;
            }

            return prevRow[str2Length];
        }
        #endregion

        #region 1143. Longest Common Subsequence
        public int LongestCommonSubsequence(string text1, string text2)
        {
            int rows = text1.Length;
            int cols = text2.Length;

            int[,] dp = new int[rows + 1, cols + 1];

            for (int row = 1; row <= rows; row++)
            {
                for (int col = 1; col <= cols; col++)
                {
                    if (text1[row - 1] == text2[col - 1])
                    {
                        dp[row, col] = 1 + dp[row - 1, col - 1];
                    }
                    else
                    {
                        dp[row, col] = Math.Max(dp[row - 1, col], dp[row, col - 1]);
                    }
                }
            }

            return dp[rows, cols];
        }
        public int LongestCommonSubsequence_Recursion(string text1, string text2)
        {
            return LongestCommonSubsequence_Recursion(text1, text2, 0, 0);
        }

        private int LongestCommonSubsequence_Recursion(string text1, string text2, int indexText1, int indexText2)
        {
            if (indexText1 == text1.Length || indexText2 == text2.Length) return 0;

            if (text1[indexText1] == text2[indexText2]) return 1 + LongestCommonSubsequence_Recursion(text1, text2, indexText1 + 1, indexText2 + 1);

            return Math.Max(LongestCommonSubsequence_Recursion(text1, text2, indexText1, indexText2 + 1), LongestCommonSubsequence_Recursion(text1, text2, indexText1 + 1, indexText2));
        }
        #endregion

        #region 1267. Count Servers that Communicate
        public int CountServers1(int[][] grid)
        {
            int rows = grid.Length;
            int cols = grid[0].Length;
            int count = 0;
            bool[,] visited = new bool[rows, cols];
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    if (!visited[row, col])
                    {
                        visited[row, col] = true;
                        if (grid[row][col] == 1)
                        {
                            Queue<(int, int)> q = new Queue<(int, int)>();
                            q.Enqueue((row, col));
                            count += enqueue_servers1(q, grid, visited);
                        }
                    }
                }
            }
            return count;
        }

        private int enqueue_servers1(Queue<(int, int)> q, int[][] grid, bool[,] visited)
        {
            int count = 0;

            while (q.Count > 0)
            {
                (int row, int col) = q.Dequeue();

                for (int i = 0; i < grid.Length; i++)
                {
                    if (!visited[i, col] && grid[i][col] == 1)
                    {
                        count++;
                        visited[i, col] = true;
                        q.Enqueue((i, col));
                    }
                }

                for (int i = 0; i < grid[row].Length; i++)
                {
                    if (!visited[row, i] && grid[row][i] == 1)
                    {
                        count++;
                        visited[row, i] = true;
                        q.Enqueue((row, i));
                    }
                }
            }

            return count == 0 ? count : count + 1;
        }
        #endregion

        #region 1358. Number of Substrings Containing All Three Characters
        public int NumberOfSubstrings(string s)
        {
            int a = -1, b = -1, c = -1;
            int total = 0;

            for (int i = 0; i < s.Length; i++)
            {
                switch (s[i])
                {
                    case 'a':
                        a = i;
                        break;
                    case 'b':
                        b = i;
                        break;
                    default:
                        c = i;
                        break;
                }

                total += 1 + Math.Min(a, Math.Min(b, c));
            }

            return total;
        }
        #endregion

        #region 1368. Minimum Cost to Make at Least One Valid Path in a Grid

        public int MinCost(int[][] grid)
        {
            int rows = grid.Length;
            int cols = grid[0].Length;

            int[][] directions = { new int[] { 0, 1 }, new int[] { 0, -1 }, new int[] { 1, 0 }, new int[] { -1, 0 } };

            bool[][] visited = new bool[rows][];
            for (int row = 0; row < rows; row++)
            {
                visited[row] = new bool[cols];
            }

            Queue<(int row, int col, int cost)> q = new Queue<(int row, int col, int cost)>();
            Queue<(int row, int col, int cost)> stack = new Queue<(int row, int col, int cost)>();
            q.Enqueue((0, 0, 0));

            while (q.Count > 0)
            {
                while (q.Count > 0)
                {
                    var dq = q.Dequeue();
                    if (dq.row < 0 || dq.col < 0 || dq.row >= rows || dq.col >= cols) continue;
                    if (dq.row == rows - 1 && dq.col == cols - 1) { return dq.cost; }
                    visited[dq.row][dq.col] = true;
                    int dir = grid[dq.row][dq.col] - 1;

                    for (int i = 0; i < directions.Length; i++)
                    {
                        if (i == dir)
                        {
                            addInQ(q, visited, dq.row + directions[dir][0], dq.col + directions[dir][1], dq.cost);
                        }
                        else
                        {
                            addInQ(stack, visited, dq.row + directions[i][0], dq.col + directions[i][1], dq.cost + 1);
                        }
                    }
                }

                while (stack.Count > 0)
                {
                    var dq = q.Dequeue();

                    if (visited[dq.row][dq.col]) continue;

                    q.Enqueue(dq);
                    break;
                }
            }



            return rows + cols - 2;
        }

        private void addInStack(Stack<(int row, int col, int cost)> stack, bool[][] visited, int row, int col, int cost)
        {
            if (row < 0 || col < 0 || row >= visited.Length || col >= visited[row].Length || visited[row][col]) return;
            stack.Push((row, col, cost));
        }

        private void addInQ(Queue<(int row, int col, int cost)> q, bool[][] visited, int row, int col, int cost)
        {
            if (row < 0 || col < 0 || row >= visited.Length || col >= visited[row].Length || visited[row][col]) return;

            q.Enqueue((row, col, cost));
        }
        #endregion

        #region 1400. Construct K Palindrome Strings
        public bool CanConstruct(string s, int k)
        {
            if (s.Length < k) return false;
            if (s.Length == k) return true;

            int[] arr = new int[26];

            int oddFreq = 0;

            foreach (char c in s)
            {
                arr[c - 'a']++;
            }

            for (int i = 0; i < 26; i++)
            {
                oddFreq += (arr[i] % 2);
            }

            return oddFreq <= k;
        }

        public bool CanConstruct_1(string s, int k)
        {
            // Handle edge cases
            if (s.Length < k) return false;
            if (s.Length == k) return true;

            // Initialize oddCount as an integer bitmask
            int oddCount = 0;

            // Update the bitmask for each character in the string
            foreach (char chr in s)
            {
                oddCount ^= 1 << (chr - 'a');
            }

            // Return if the number of odd frequencies is less than or equal to k
            return BitCount(oddCount) <= k;
        }
        private static int BitCount(int n)
        {
            var count = 0;
            while (n != 0)
            {
                count++;
                n &= (n - 1); //walking through all the bits which are set to one
            }

            return count;
        }
        #endregion

        #region 1408. String Matching in an Array
        public IList<string> StringMatching(string[] words)
        {
            IList<string> result = new List<string>();
            for (int i = 0; i < words.Length; i++)
            {
                for (int j = 0; j < words.Length; j++)
                {
                    if (i == j) continue;

                    if (words[j].Contains(words[j]))
                    {
                        result.Add(words[j]);
                        break;
                    }
                }
            }


            return result;
        }
        #endregion

        #region 1415. The k-th Lexicographical String of All Happy Strings of Length n
        public string GetHappyString(int n, int k)
        {
            Queue<string> queue = new Queue<string>();
            queue.Enqueue("a");
            queue.Enqueue("b");
            queue.Enqueue("c");

            while (queue.Count > 0)
            {
                string s = queue.Dequeue();

                if (s.Length < n)
                {
                    char last = s[s.Length - 1];
                    switch (last)
                    {
                        case 'a':
                            queue.Enqueue(s + 'b');
                            queue.Enqueue(s + 'c');
                            break;
                        case 'b':
                            queue.Enqueue(s + 'a');
                            queue.Enqueue(s + 'c');
                            break;
                        case 'c':
                            queue.Enqueue(s + 'a');
                            queue.Enqueue(s + 'b');
                            break;
                        default:
                            break;
                    }
                }
                else
                {

                    k--;
                    if (k == 0)
                    {
                        return s;
                    }
                }
            }
            return string.Empty;
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

        #region 1462. Course Schedule IV

        public IList<bool> CheckIfPrerequisite(int numCourses, int[][] prerequisites, int[][] queries)
        {
            IList<bool> result = new List<bool>();

            Dictionary<int, HashSet<int>> map = new Dictionary<int, HashSet<int>>();

            for (int i = 0; i < numCourses; i++)
            {
                map.Add(i, new HashSet<int>());
            }

            foreach (int[] prerequisite in prerequisites)
            {
                map[prerequisite[1]].Add(prerequisite[0]);
            }

            for (int i = 0; i < numCourses; i++)
            {
                bool[] visited = new bool[numCourses];
                Queue<int> queue = new Queue<int>();

                visited[i] = true;

                foreach (var course in map[i])
                {
                    visited[course] = true;
                    queue.Enqueue(course);
                }

                while (queue.Count > 0)
                {
                    var dq = queue.Dequeue();

                    foreach (var course in map[dq])
                    {
                        if (!visited[course])
                        {
                            visited[course] = true;
                            queue.Enqueue(course);
                            map[i].Add(course);
                        }
                    }
                }
            }

            foreach (var query in queries)
            {
                result.Add(map[query[1]].Contains(query[0]));
            }

            return result;
        }

        public IList<bool> CheckIfPrerequisite_1(int numCourses, int[][] prerequisites, int[][] queries)
        {
            IList<bool> result = new List<bool>();

            Dictionary<int, HashSet<int>> map = new Dictionary<int, HashSet<int>>();

            for (int i = 0; i < numCourses; i++)
            {
                map.Add(i, new HashSet<int>());
            }

            foreach (int[] prerequisite in prerequisites)
            {
                map[prerequisite[1]].Add(prerequisite[0]);
            }

            foreach (int[] query in queries)
            {
                //result.Add(map[query[1]].Contains(query[0]));

                if (map[query[1]].Contains(query[0]))
                {
                    result.Add(true);
                }
                else
                {
                    bool[] visited = new bool[numCourses];
                    visited[query[1]] = true;
                    Queue<int> q = new Queue<int>();
                    foreach (int course in map[query[1]])
                    {
                        q.Enqueue(course);
                        visited[course] = true;
                    }

                    while (q.Count > 0)
                    {
                        var dq = q.Dequeue();

                        foreach (int course in map[dq])
                        {
                            if (!visited[course])
                            {
                                visited[course] = true;
                                q.Enqueue(course);
                                map[query[1]].Add(course);
                            }
                        }
                    }


                    result.Add(map[query[1]].Contains(query[0]));
                }
            }

            return result;
        }
        #endregion

        #region 1524. Number of Sub-arrays With Odd Sum
        public int NumOfSubarrays(int[] arr)
        {
            int MOD = 1_000_000_007;
            int count = 0, prefixSum = 0;

            int oddCount = 0, evenCount = 1;

            foreach (int num in arr)
            {
                prefixSum += num;

                if (prefixSum % 2 == 0)
                {
                    count += oddCount;
                    evenCount++;
                }
                else
                {
                    count += evenCount;
                    oddCount++;
                }

                count %= MOD;
            }

            return count;
        }
        #endregion

        #region 1718. Construct the Lexicographically Largest Valid Sequence
        public int[] ConstructDistancedSequence(int n)
        {
            int[] result = new int[n * 2 - 1];

            bool[] used = new bool[n + 1];

            ConstructDistancedSequence_BackTrack(0, result, used, n);


            return result;
        }

        private bool ConstructDistancedSequence_BackTrack(int currentIndex, int[] result, bool[] used, int n)
        {
            if (currentIndex == result.Length) return true;

            if (result[currentIndex] != 0)
            {
                return ConstructDistancedSequence_BackTrack(currentIndex + 1, result, used, n);
            }

            for (int i = n; i >= 1; i--)
            {
                if (used[i]) continue;

                used[i] = true;

                result[currentIndex] = i;

                if (i == 1)
                {
                    if (ConstructDistancedSequence_BackTrack(currentIndex + 1, result, used, n))
                    {
                        return true;
                    }
                }
                else if (currentIndex + i < result.Length && result[currentIndex + i] == 0)
                {
                    result[currentIndex + i] = i;
                    if (ConstructDistancedSequence_BackTrack(currentIndex + 1, result, used, n))
                    {
                        return true;
                    }
                    result[currentIndex + i] = 0;
                }

                result[currentIndex] = 0;
                used[i] = false;
            }

            return false;
        }
        #endregion

        #region 1726. Tuple with Same Product
        public int TupleSameProduct(int[] nums)
        {
            Dictionary<int, HashSet<string>> map = new Dictionary<int, HashSet<string>>();
            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = 0; j < nums.Length; j++)
                {
                    if (i == j) continue;
                    string s = i < j ? $"{i}:{j}" : $"{j}:{i}";
                    int product = nums[i] * nums[j];

                    if (!map.ContainsKey(product))
                    {
                        map.Add(product, new HashSet<string>());
                    }
                    map[product].Add(s);
                }
            }
            int result = 0;
            foreach (var key in map.Keys)
            {
                int i = 1;

                while (i < map[key].Count)
                {
                    result += (i * 8);
                    i++;
                }
            }
            return result;
        }
        #endregion

        #region 1749. Maximum Absolute Sum of Any Subarray
        public int MaxAbsoluteSum(int[] nums)
        {
            int minPrefixSum = 0;
            int maxrefixSum = 0;
            int prefixSum = 0;

            for (int i = 0; i < nums.Length; i++)
            {
                prefixSum += nums[i];

                minPrefixSum = Math.Min(minPrefixSum, prefixSum);
                maxrefixSum = Math.Max(maxrefixSum, prefixSum);
            }

            return maxrefixSum - minPrefixSum;
        }
        #endregion

        #region 1752. Check if Array Is Sorted and Rotated
        public bool Check(int[] nums)
        {
            int curr = nums[0];

            for (int i = 1; i < nums.Length; i++)
            {
                if (curr > nums[i])
                {
                    if (nums[i] > nums[0]) return false;

                    return Check(nums, i);
                }
                curr = nums[i];
            }
            return true;
        }

        private bool Check(int[] nums, int i)
        {
            int curr = nums[i++];
            for (; i < nums.Length; i++)
            {
                if (curr > nums[i] || nums[i] > nums[0]) return false;
            }

            return true;
        }
        #endregion

        #region 1765. Map of Highest Peak
        public int[][] HighestPeak(int[][] isWater)
        {
            int rows = isWater.Length;
            int cols = isWater[0].Length;

            int[][] result = new int[rows][];
            Queue<(int row, int col, int peak)> q = new Queue<(int row, int col, int peak)>();
            for (int row = 0; row < rows; row++)
            {
                result[row] = new int[cols];
                for (int col = 0; col < cols; col++)
                {
                    if (isWater[row][col] == 1)
                    {
                        result[row][col] = 0;
                        q.Enqueue((row, col, 0));
                    }
                    else
                    {
                        result[row][col] = -1;
                    }
                }
            }

            while (q.Count > 0)
            {
                (int row, int col, int peak) = q.Dequeue();
                peak += 1;
                enqueue(q, result, row + 1, col, peak);
                enqueue(q, result, row - 1, col, peak);
                enqueue(q, result, row, col + 1, peak);
                enqueue(q, result, row, col - 1, peak);
            }
            return result;
        }

        private void enqueue(Queue<(int row, int col, int peak)> q, int[][] result, int row, int col, int peak)
        {
            if (row < 0 || col < 0 || row >= result.Length || col >= result[row].Length || result[row][col] != -1) return;
            q.Enqueue((row, col, peak));
            result[row][col] = peak;
        }

        #endregion

        #region 1769. Minimum Number of Operations to Move All Balls to Each Box
        public int[] MinOperations(string boxes)
        {
            int[] result = new int[boxes.Length];
            int leftSum = 0, rightSum = 0, leftone = 0, rightone = 0;

            for (int i = 0; i < boxes.Length; i++)
            {
                leftSum += leftone;
                result[i] += leftSum;
                if (boxes[i] == '1') leftone++;

                int k = boxes.Length - 1 - i;
                rightSum += rightone;
                result[k] += rightSum;
                if (boxes[k] == '1') rightone++;
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

        #region 1780. Check if Number is a Sum of Powers of Three
        public bool CheckPowersOfThree(int n)
        {
            while (n > 0)
            {
                if (n % 3 == 2)
                {
                    return false;
                }
                n /= 3;
            }
            return true;
        }
        #endregion

        #region 1790. Check if One String Swap Can Make Strings Equal
        public bool AreAlmostEqual(string s1, string s2)
        {
            char c1 = ' ', c2 = ' ';
            bool maxSwapSet = false;

            for (int i = 0; i < s1.Length; i++)
            {
                if (s1[i] != s2[i])
                {

                    if (c1 == ' ')
                    {
                        c1 = s1[i];
                        c2 = s2[i];
                    }

                    if (maxSwapSet || c1 != s2[i] || c2 != s1[i]) return false;
                    maxSwapSet = true;
                }
            }
            if (c1 != ' ' && !maxSwapSet)
            {
                return false;
            }
            return true;
        }
        #endregion

        #region 1800. Maximum Ascending Subarray Sum
        public int MaxAscendingSum(int[] nums)
        {
            int maxSum = nums[0];
            int currSum = nums[0];
            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[i] > nums[i - 1])
                {
                    currSum += nums[i];
                }
                else
                {
                    maxSum = Math.Max(maxSum, currSum);
                    currSum = nums[i];
                }
            }

            return Math.Max(maxSum, currSum);
        }
        #endregion

        #region 1910. Remove All Occurrences of a Substring
        public string RemoveOccurrences(string s, string part)
        {
            int[] kmpLPS = computeLongestPrefixSuffix(part);
            Stack<char> charStack = new Stack<char>();
            int[] patternIndexes = new int[s.Length + 1];


            for (
                int strIndex = 0, patternIndex = 0;
                strIndex < s.Length;
                strIndex++
            )
            {
                char currentChar = s[strIndex];
                charStack.Push(currentChar);

                if (currentChar == part[patternIndex])
                {
                    patternIndexes[charStack.Count] = ++patternIndex;

                    if (patternIndex == part.Length)
                    {
                        int remainingLength = part.Length;
                        while (remainingLength != 0)
                        {
                            charStack.Pop();
                            remainingLength--;
                        }

                        patternIndex = charStack.Count == 0
                            ? 0
                            : patternIndexes[charStack.Count];
                    }
                }
                else
                {
                    if (patternIndex != 0)
                    {
                        strIndex--;
                        patternIndex = kmpLPS[patternIndex - 1];
                        charStack.Pop();
                    }
                    else
                    {
                        patternIndexes[charStack.Count] = 0;
                    }
                }
            }

            StringBuilder result = new StringBuilder();
            while (charStack.Count > 0)
            {
                result.Append(charStack.Pop());
            }

            char[] arr = result.ToString().ToCharArray().Reverse().ToArray();

            return new string(arr);
        }

        private int[] computeLongestPrefixSuffix(string pattern)
        {
            int[] lps = new int[pattern.Length];

            for (int current = 1, prefixLength = 0; current < pattern.Length;)
            {
                if (pattern[current] == pattern[prefixLength])
                {
                    lps[current] = ++prefixLength;
                    current++;
                }
                else if (prefixLength != 0)
                {
                    prefixLength = lps[prefixLength - 1];
                }
                else
                {
                    lps[current] = 0;
                    current++;
                }
            }
            return lps;
        }

        public string RemoveOccurrences_1(string s, string part)
        {
            Stack<(int, int)> stack = new Stack<(int, int)>();
            StringBuilder sb = new StringBuilder();

            int i = 0;
            while (i < s.Length)
            {
                if (s[i] == part[0])
                {
                    //q.Push(j);
                    int cnt = 1;
                    int j = i;
                    StringBuilder sb2 = new StringBuilder();
                    sb2.Append(s[i]);
                    while (j + cnt < s.Length && cnt < part.Length)
                    {
                        sb2.Append(s[j + cnt]);
                        if (s[j + cnt] == part[cnt])
                        {
                            cnt++;
                        }
                        else
                        {
                            break;
                        }
                    }
                    if (cnt == part.Length)
                    {
                        if (stack.Count > 0)
                        {
                            var ss = stack.Pop();
                            sb.Remove(sb.Length - ss.Item2, ss.Item2);
                            i = ss.Item1;
                        }
                        else
                        {
                            i += part.Length;
                        }
                    }
                    else
                    {
                        stack.Push((i, cnt));
                        sb.Append(part.Substring(0, cnt));
                        i++;
                    }
                }
                else
                {
                    sb.Append(s[i]);
                    i++;
                }
            }

            return sb.ToString();
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

        #region 1980. Find Unique Binary String
        public string FindDifferentBinaryString(string[] nums)
        {
            HashSet<string> set = new HashSet<string>(nums);

            Stack<string> stack = new Stack<string>();
            stack.Push("0");
            stack.Push("1");

            while (stack.Count > 0)
            {
                var pop = stack.Pop();

                if (pop.Length < nums.Length)
                {
                    stack.Push(pop + '0');
                    stack.Push(pop + '1');
                }
                else
                {
                    if (!set.Contains(pop)) return pop;
                }
            }
            return string.Empty;
        }
        #endregion

        #region 2017. Grid Game
        public long GridGame(int[][] grid)
        {
            long row1Sum = 0;

            for (int i = 0; i < grid[0].Length; i++)
            {
                row1Sum += grid[0][i];
            }

            long currR1 = row1Sum - grid[0][0];
            long currR2 = 0;

            long result = Math.Max(currR1, currR2);
            for (int i = 1; i < grid[0].Length; i++)
            {
                currR1 -= grid[0][i];
                currR2 += grid[1][i - 1];
                result = Math.Min(result, Math.Max(currR1, currR2));
            }
            return result;
        }
        public long GridGame2(int[][] grid)
        {
            long firstRowSum = 0;
            foreach (int num in grid[0])
            {
                firstRowSum += num;
            }
            long secondRowSum = 0;
            long minimumSum = long.MaxValue;
            for (int turnIndex = 0; turnIndex < grid[0].Length; ++turnIndex)
            {
                firstRowSum -= grid[0][turnIndex];
                // Find the minimum maximum value out of firstRowSum and
                // secondRowSum.
                minimumSum = Math.Min(
                    minimumSum,
                    Math.Max(firstRowSum, secondRowSum)
                );
                secondRowSum += grid[1][turnIndex];
            }
            return minimumSum;
        }
        public long GridGame1(int[][] grid)
        {
            int cols = grid[0].Length;
            long[,] dp = new long[2, cols];
            dp[0, 0] = grid[0][0];
            dp[1, 0] = grid[0][0] + grid[1][0];
            for (int i = 1; i < cols; i++)
            {
                dp[0, i] = dp[0, i - 1] + grid[0][i];

                dp[1, i] = grid[1][i] + Math.Max(dp[0, i], dp[1, i - 1]);
            }

            int col = cols - 1;
            int row = 1;
            while (col > 0)
            {
                grid[row][col] = 0;
                long top = dp[0, col];
                long left = dp[1, col - 1];

                if (top > left)
                {
                    row = 0;
                    break;
                }
                col--;
            }

            if (row == 0)
            {
                while (col >= 0)
                {
                    grid[row][col--] = 0;
                }
            }
            else if (col == 0)
            {
                grid[0][col] = 0;
                grid[1][col] = 0;
            }
            dp = new long[2, cols];
            dp[1, 0] = grid[1][0];
            for (int i = 1; i < cols; i++)
            {
                dp[0, i] = dp[0, i - 1] + grid[0][i];

                dp[1, i] = grid[1][i] + Math.Max(dp[0, i], dp[1, i - 1]);
            }
            return dp[1, cols - 1];
        }
        #endregion

        #region 2116. Check if a Parentheses String Can Be Valid
        public bool CanBeValid1(string s, string locked)
        {
            int len = s.Length;
            if (locked[0] == ')' || len % 2 == 1 || locked[len - 1] == '(') return false;

            int counter = 0;
            foreach (char c in s)
            {
                //if()
            }
            return counter == 0;
        }


        public bool canBeValid(string s, string locked)
        {
            int len = s.Length;
            if (locked[0] == ')' || len % 2 == 1 || locked[len - 1] == '(') return false;

            int o = 0, u = 0;

            // Iterate through the string to handle '(' and ')'.
            for (int i = 0; i < len; i++)
            {
                if (locked[i] == '0')
                {
                    u++;
                }
                else if (s[i] == '(')
                {
                    o++;
                }
                else if (s[i] == ')')
                {
                    if (o > 0)
                    {
                        o--;
                    }
                    else if (u > 0)
                    {
                        u--;
                    }
                    else
                    {
                        return false;
                    }
                }
            }

            // Match remaining open brackets with unlocked characters.
            int balance = 0;
            for (int i = len - 1; i >= 0; i--)
            {
                if (locked[i] == '0')
                {
                    balance--;
                    u--;
                }
                else if (s[i] == '(')
                {
                    balance++;
                    o--;
                }
                else if (s[i] == ')')
                {
                    balance--;
                }
                if (balance > 0)
                {
                    return false;
                }
                if (u == 0 && o == 0)
                {
                    break;
                }
            }

            if (o > 0)
            {
                return false;
            }

            return true;
        }

        #endregion

        #region 2127. Maximum Employees to Be Invited to a Meeting
        public int MaximumInvitations(int[] favorite)
        {
            return 0;
        }
        #endregion

        #region 2161. Partition Array According to Given Pivot
        public int[] PivotArray(int[] nums, int pivot)
        {
            int lIndex = 0;
            int rIndex = nums.Length - 1;
            int[] result = new int[nums.Length];
            for (int i = 0, j = nums.Length - 1; i < nums.Length; i++, j--)
            {
                if (nums[i] < pivot)
                {
                    result[lIndex++] = nums[i];
                }

                if (nums[j] > pivot)
                {
                    result[rIndex--] = nums[j];
                }
            }

            while (lIndex <= rIndex)
            {
                result[lIndex] = pivot;
                lIndex++;
                rIndex--;
            }

            return result;
        }
        public int[] PivotArray2(int[] nums, int pivot)
        {
            int[] result = new int[nums.Length];
            int pivotCount = 0;
            Queue<int> queue = new Queue<int>();
            int indexToInsert = -1;

            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] == pivot)
                {
                    pivotCount++;
                }
                else if (pivot < nums[i])
                {
                    queue.Enqueue(nums[i]);
                }
                else
                {
                    result[++indexToInsert] = nums[i];
                }
            }

            while (pivotCount-- > 0)
            {
                result[++indexToInsert] = pivot;
            }

            while (queue.Count > 0)
            {
                result[++indexToInsert] = queue.Dequeue();
            }

            return result;
        }
        public int[] PivotArray1(int[] nums, int pivot)
        {
            List<int> result = new List<int>();
            int indexToInsert = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] == pivot)
                {
                    result.Insert(indexToInsert, pivot);
                }
                else if (nums[i] < pivot)
                {
                    result.Insert(indexToInsert, nums[i]);
                    indexToInsert++;
                }
                else
                {
                    result.Add(nums[i]);
                }
            }

            return result.ToArray();
        }
        #endregion

        #region 2185. Counting Words With a Given Prefix
        public int PrefixCount(string[] words, string pref)
        {
            int count = 0;

            foreach (var word in words)
            {
                if (word.StartsWith(pref)) count++;
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

        #region 2342. Max Sum of a Pair With Equal Sum of Digits
        public int MaximumSum(int[] nums)
        {
            int result = -1;

            Dictionary<int, int[]> numberMap = new Dictionary<int, int[]>();

            foreach (int n in nums)
            {
                int sumOfDigit = sumOFDigit(n);

                if (numberMap.ContainsKey(sumOfDigit))
                {
                    if (numberMap[sumOfDigit][0] < n)
                    {
                        numberMap[sumOfDigit][1] = numberMap[sumOfDigit][0];
                        numberMap[sumOfDigit][0] = n;
                    }
                    else if (numberMap[sumOfDigit][1] < n)
                    {
                        numberMap[sumOfDigit][1] = n;
                    }

                    result = Math.Max(result, numberMap[sumOfDigit][0] + numberMap[sumOfDigit][1]);
                }
                else
                {
                    numberMap[sumOfDigit] = new int[] { n, 0 };
                }
            }

            return result;
        }
        private int sumOFDigit(int number)
        {
            int sum = 0;

            while (number > 0)
            {
                sum += number % 10;
                number /= 10;
            }

            return sum;
        }
        #endregion

        #region 2364. Count Number of Bad Pairs
        public long CountBadPairs(int[] nums)
        {
            long badPairs = 0;
            Dictionary<int, int> diffCount = new Dictionary<int, int>();

            for (int pos = 0; pos < nums.Length; pos++)
            {
                int diff = pos - nums[pos];
                diffCount.TryGetValue(diff, out int goodPairsCount);
                badPairs += pos - goodPairsCount;
                diffCount[diff] = goodPairsCount + 1;
            }

            return badPairs;
        }
        #endregion

        #region 2375. Construct Smallest Number From DI String
        public string SmallestNumber(string pattern)
        {
            StringBuilder result = new StringBuilder();
            Stack<int> numStack = new Stack<int>();

            // Iterate through the pattern
            for (int index = 0; index <= pattern.Length; index++)
            {
                // Push the next number onto the q
                numStack.Push(index + 1);

                // If 'I' is encountered or we reach the end, pop all q elements
                if (index == pattern.Length || pattern[index] == 'I')
                {
                    while (numStack.Count > 0)
                    {
                        result.Append(numStack.Pop());
                    }
                }
            }

            return result.ToString();
        }
        #endregion

        #region 2379. Minimum Recolors to Get K Consecutive Black Blocks
        public int MinimumRecolors(string blocks, int k)
        {
            int result = 0;
            int i = -1;
            while (++i < k)
            {
                if (blocks[i] == 'W')
                {
                    result++;
                }
            }
            if (result > 0)
            {
                int curr = result;

                while (i < blocks.Length)
                {
                    if (blocks[i] != blocks[i - k])
                    {
                        if (blocks[i] == 'B')
                        {
                            curr--;
                            result = Math.Min(result, curr);
                        }
                        else
                        {
                            curr++;
                        }
                    }
                    i++;
                }
            }

            return result;
        }
        #endregion

        #region 2381. Shifting Letters II

        public string ShiftingLetters_3(string s, int[][] shifts)
        {
            int n = s.Length;
            int[] diffArray = new int[n]; // Initialize a difference array with all elements set to 0.

            // Process each shift operation
            foreach (int[] shift in shifts)
            {
                if (shift[2] == 1)
                { // If direction is forward (1)
                    diffArray[shift[0]]++; // Increment at the start wordIndex
                    if (shift[1] + 1 < n)
                    {
                        diffArray[shift[1] + 1]--; // Decrement at the end+1 wordIndex
                    }
                }
                else
                { // If direction is backward (0)
                    diffArray[shift[0]]--; // Decrement at the start wordIndex
                    if (shift[1] + 1 < n)
                    {
                        diffArray[shift[1] + 1]++; // Increment at the end+1 wordIndex
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

                // Calculate the new character by shifting `s[row]`
                char shiftedChar = (char)('a' +
                    ((s[i] - 'a' + numberOfShifts) % 26));
                result[i] = shiftedChar;
            }

            return result.ToString();
        }
        public string ShiftingLetters(string s, int[][] shifts)
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
                index += charPos[i];

                index %= 26;
                if (index < 0)
                {
                    index += 26;
                }
                chars[i] = (char)(index + 'a');
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

        #region 2425. Bitwise XOR of All Pairings
        public int XorAllNums(int[] nums1, int[] nums2)
        {
            int count = 0;
            Dictionary<int, int> freq = new Dictionary<int, int>();

            foreach (int n in nums1)
            {
                if (freq.ContainsKey(n))
                {
                    freq[n] += nums2.Length;
                }
                else
                {
                    freq[n] = nums2.Length;
                }
            }
            foreach (int n in nums2)
            {
                if (freq.ContainsKey(n))
                {
                    freq[n] += nums1.Length;
                }
                else
                {
                    freq[n] = nums1.Length;
                }
            }

            foreach (var key in freq.Keys)
            {
                if (freq[key] % 2 == 1)
                {
                    count ^= key;
                }
            }
            return count;
        }
        #endregion

        #region 2429. Minimize XOR
        private int GetSetBit(int n)
        {
            int count = 0;
            while (n > 0)
            {
                count += (n & 1);
                n >>= 1;
            }
            return count;
        }
        private bool[] GetBinary(int n)
        {
            List<bool> list = new List<bool>();

            while (n > 0)
            {
                list.Insert(0, (n & 1) == 1);
                n >>= 1;
            }

            return list.ToArray();
        }
        private int GetInt(bool[] binaryList)
        {
            int result = 0;
            int k = 1;
            for (int i = binaryList.Length - 1; i >= 0; i--)
            {
                if (binaryList[i])
                {
                    result += k;
                }
                k *= 2;
            }
            return result;
        }
        public int MinimizeXor(int num1, int num2)
        {
            int result = 0;
            int setBitCount = GetSetBit(num2);
            bool[] bitSets = GetBinary(num1);

            bool[] newNum = new bool[32];

            for (int i = 0; i < bitSets.Length && setBitCount > 0; i++)
            {
                if (bitSets[i])
                {
                    newNum[32 - bitSets.Length + i] = true;
                    setBitCount--;
                }
            }
            int k = 31;
            while (setBitCount > 0)
            {
                if (!newNum[k])
                {
                    newNum[k] = true;
                    setBitCount--;
                }
                k--;
            }


            result = GetInt(newNum);

            return result;
        }
        #endregion

        #region 2460. Apply Operations to an Array
        public int[] ApplyOperations(int[] nums)
        {
            int zero = 0;
            int i = 0;
            for (; i < nums.Length - 1; i++)
            {
                if (nums[i] == 0)
                {
                    zero++;
                }
                else if (nums[i] == nums[i + 1])
                {
                    nums[i - zero] = nums[i] + nums[i];
                    nums[i + 1] = 0;
                    i++;
                    zero++;
                }
                else
                {
                    nums[i - zero] = nums[i];
                    nums[i] = 0;
                }
            }
            if (nums[i] != 0)
            {
                nums[i - zero] = nums[i];
                nums[i] = 0;
            }
            return nums;
        }

        public int[] ApplyOperations1(int[] nums)
        {

            for (int i = 0; i < nums.Length - 1; i++)
            {
                if (nums[i] == nums[i + 1])
                {
                    nums[i] = nums[i] + nums[i];
                    nums[i + 1] = 0;
                    i++;
                }
            }

            int leftZero = 0;

            int k = 0;

            while (k < nums.Length && nums[k] != 0)
            {
                k++;
            }

            if (k < nums.Length)
            {
                leftZero = k;

                while (++k < nums.Length)
                {
                    if (nums[k] > 0)
                    {
                        nums[leftZero++] = nums[k];
                        nums[k] = 0;
                    }
                }
            }

            return nums;
        }
        #endregion

        #region 2467. Most Profitable Path in a Tree
        public int MostProfitablePath(int[][] edges, int bob, int[] amount)
        {
            Dictionary<int, List<int>> map = new Dictionary<int, List<int>>();

            for (int i = 0; i < amount.Length; i++)
            {
                map[i] = new List<int>();
            }

            foreach (int[] edge in edges)
            {
                map[edge[0]].Add(edge[1]);
                map[edge[1]].Add(edge[0]);
            }

            bool[] visited = new bool[amount.Length];
            int[] bobPath = getBobPath(map, visited, bob);
            int n = bobPath.Length / 2;
            for (int i = n; i < bobPath.Length; i++)
            {
                amount[bobPath[i]] = 0;
            }
            if (bobPath.Length % 2 == 0)
            {
                amount[bobPath[n - 1]] /= 2;
            }
            visited = new bool[amount.Length];

            int res = int.MinValue;
            visited[0] = true;
            Queue<(int, int)> q = new Queue<(int, int)>();


            q.Enqueue((0, amount[0]));

            while (q.Count > 0)
            {
                var top = q.Dequeue();
                bool leaf = true;
                foreach (int neighbor in map[top.Item1])
                {
                    if (!visited[neighbor])
                    {
                        visited[neighbor] = true;
                        leaf = false;
                        int amt = top.Item2 + amount[neighbor];
                        q.Enqueue((neighbor, amt));
                    }
                }
                if (leaf)
                {
                    res = Math.Max(res, top.Item2);
                }

            }

            return res;
        }

        private int[] getBobPath(Dictionary<int, List<int>> map, bool[] visited, int bob)
        {
            Stack<int> stack = new Stack<int>();
            stack.Push(bob);
            visited[bob] = true;
            bool found = false;
            while (!found)
            {
                int top = stack.Peek();
                bool leaf = true;
                foreach (int neighbor in map[top])
                {
                    if (!visited[neighbor])
                    {
                        leaf = false;
                        visited[neighbor] = true;
                        if (neighbor == 0)
                        {
                            found = true;
                        }
                        else
                        {
                            stack.Push(neighbor);
                        }
                        break;
                    }
                }
                if (found) { break; }
                if (leaf) { stack.Pop(); }
            }

            return stack.ToArray();
        }
        #endregion

        #region 2493. Divide Nodes Into the Maximum Number of Groups
        public int MagnificentSets(int n, int[][] edges)
        {
            IList<int>[] adjList = new IList<int>[n];
            int[] colors = new int[n];
            for (int i = 0; i < n; i++)
            {
                adjList[i] = new List<int>();
                colors[i] = -1;
            }

            foreach (int[] edge in edges)
            {
                adjList[edge[0] - 1].Add(edge[1] - 1);
                adjList[edge[1] - 1].Add(edge[0] - 1);
            }

            for (int node = 0; node < n; node++)
            {
                if (colors[node] != -1) continue;

                colors[node] = 0;

                if (!isBipartite(adjList, node, colors)) return -1;
            }

            int[] distances = new int[n];
            for (int node = 0; node < n; node++)
            {
                distances[node] = getLongestShortestPath(adjList, node, n);
            }
            int maxNumberOfGroups = 0;
            bool[] visited = new bool[n];
            for (int node = 0; node < n; node++)
            {
                if (visited[node]) continue;
                maxNumberOfGroups += getNumberOfGroupsForComponent(
                    adjList,
                    node,
                    distances,
                    visited
                );
            }

            return maxNumberOfGroups;
        }

        private int getNumberOfGroupsForComponent(IList<int>[] adjList, int node, int[] distances, bool[] visited)
        {
            int maxNumberOfGroups = distances[node];
            visited[node] = true;

            foreach (int neighbor in adjList[node])
            {
                if (visited[neighbor]) continue;
                maxNumberOfGroups = Math.Max(
                    maxNumberOfGroups,
                    getNumberOfGroupsForComponent(
                        adjList,
                        neighbor,
                        distances,
                        visited
                    )
                );
            }
            return maxNumberOfGroups;
        }

        private int getLongestShortestPath(IList<int>[] adjList, int srcNode, int n)
        {
            Queue<int> queue = new Queue<int>();
            bool[] visited = new bool[n];
            queue.Enqueue(srcNode);
            visited[srcNode] = true;
            int distance = 0;

            while (queue.Count > 0)
            {
                int numOfNodesInLayer = queue.Count;
                for (int i = 0; i < numOfNodesInLayer; i++)
                {
                    int currentNode = queue.Dequeue();

                    foreach (int neighbor in adjList[currentNode])
                    {
                        if (visited[neighbor]) continue;
                        visited[neighbor] = true;
                        queue.Enqueue(neighbor);
                    }
                }
                distance++;
            }

            return distance;
        }

        private bool isBipartite(IList<int>[] adjList, int node, int[] colors)
        {
            foreach (int neighbor in adjList[node])
            {
                if (colors[neighbor] == colors[node]) return false;

                if (colors[neighbor] != -1) continue;

                colors[neighbor] = (colors[node] + 1) % 2;

                if (!isBipartite(adjList, neighbor, colors)) return false;
            }

            return true;
        }
        #endregion

        #region 2529. Maximum Count of Positive Integer and Negative Integer
        public int MaximumCount(int[] nums)
        {
            int negCount = 0, posCount = 0;

            int low = 0;
            int high = nums.Length - 1;
            if (nums[low] >= 0)
            {
                high = getMaximumPOSCount(nums, 0, high);
            }
            else if (nums[high] <= 0)
            {
                low = getMaximumNEGCount(nums, 0, high);
            }
            else
            {
                while (low < high)
                {
                    int mid = (low + high) / 2;

                    if (nums[mid] == 0)
                    {
                        low = low == mid ? mid - 1 : getMaximumNEGCount(nums, low, mid - 1);
                        high = high == mid ? mid + 1 : getMaximumPOSCount(nums, mid + 1, high);
                        break;
                    }
                    else if (nums[mid] < 0)
                    {
                        low = mid + 1;
                    }
                    else
                    {
                        high = mid - 1;
                    }
                }

            }

            while (low >= 0 && nums[low] >= 0)
            {
                low--;
            }
            negCount = low + 1;

            while (high < nums.Length && nums[high] <= 0)
            {
                high++;
            }
            posCount = nums.Length - high;

            return Math.Max(posCount, negCount);
        }

        private int getMaximumPOSCount(int[] nums, int low, int high)
        {
            if (nums[high] <= 0) return high;
            if (low == high || nums[low] > 0) return low;

            int mid = (low + high) / 2;
            if (nums[mid] == 0) return getMaximumPOSCount(nums, mid + 1, high);

            return getMaximumPOSCount(nums, low, mid - 1);
        }

        private int getMaximumNEGCount(int[] nums, int low, int high)
        {
            if (nums[low] >= 0) return low;
            if (low == high || nums[high] < 0) return high;
            int mid = (low + high) / 2;

            if (nums[mid] == 0) return getMaximumNEGCount(nums, low, mid - 1);

            return getMaximumNEGCount(nums, mid + 1, high);
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

        #region 2579. Count Total Number of Colored Cells
        public long ColoredCells1(int n)
        {
            if (n == 1) return 1;

            return ((n - 1) * 4) + ColoredCells1(n - 1);
        }
        public long ColoredCells(int n)
        {
            // 1 + (4 * 1) + (4*2) + (4*3) + ... + (4*(n-1))
            // 1 + 4  * (1 + n-1)
            // calculation of 1 + (n-1) == (n * n-1) / 2
            return 1 + (long)n * (n - 1) * 2;
        }
        #endregion

        #region 2657. Find the Prefix Common Array of Two Arrays 
        public int[] FindThePrefixCommonArray(int[] A, int[] B)
        {
            int[] result = new int[A.Length];
            int[] common = new int[A.Length];
            int count = 0;
            for (int i = 0; i < A.Length; i++)
            {
                if (A[i] == B[i])
                {
                    common[A[i] - 1] = 2;
                    count++;
                }
                else
                {
                    common[A[i] - 1]++;
                    common[B[i] - 1]++;
                    if (common[A[i] - 1] == 2) count++;
                    if (common[B[i] - 1] == 2) count++;
                }
                result[i] = count;
            }

            return result;
        }
        public int[] FindThePrefixCommonArray2(int[] A, int[] B)
        {
            int[] result = new int[A.Length];
            HashSet<int> setA = new HashSet<int>();
            HashSet<int> setB = new HashSet<int>();
            HashSet<int> set = new HashSet<int>();
            for (int i = 0; i < A.Length; i++)
            {
                setA.Add(A[i]);
                setB.Add(B[i]);

                if (setA.Contains(B[i]))
                {
                    set.Add(B[i]);
                }

                if (setB.Contains(A[i]))
                {
                    set.Add(A[i]);
                }
                result[i] = set.Count;
            }

            return result;
        }
        public int[] FindThePrefixCommonArray1(int[] A, int[] B)
        {
            int[] result = new int[A.Length];
            int count = 0;
            int[] commonPrefix = new int[A.Length];
            for (int i = 0; i < A.Length; i++)
            {
                commonPrefix[A[i] - 1]++;
                commonPrefix[B[i] - 1]++;
                if (A[i] == B[i])
                {
                    count++;
                }
                else
                {
                    if (commonPrefix[A[i] - 1] == 2)
                    {
                        count++;
                    }
                    else if (commonPrefix[B[i] - 1] == 2)
                    {
                        count++;
                    }
                }
                result[i] = count;
            }
            return result;
        }
        #endregion

        #region 2658. Maximum Number of Fish in a Grid
        public int FindMaxFish(int[][] grid)
        {
            int rows = grid.Length;
            int cols = grid[0].Length;

            int totalCells = rows * cols;

            int[] parent = new int[totalCells];
            int[] componentSize = new int[totalCells];
            int[] totalFish = new int[totalCells];

            for (int cellIndex = 0; cellIndex < totalCells; cellIndex++)
            {
                parent[cellIndex] = cellIndex;
                componentSize[cellIndex] = 1;
            }

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    int cellIndex = row * cols + col;
                    totalFish[cellIndex] = grid[row][col];
                }
            }

            int[] dRow = { 0, 0, 1, -1 };
            int[] dCol = { 1, -1, 0, 0 };

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    if (grid[row][col] > 0)
                    {
                        int cellIndex = row * cols + col;

                        for (int dir = 0; dir < 4; dir++)
                        {
                            int nRow = row + dRow[dir];
                            int nCol = col + dCol[dir];

                            if (nRow >= 0 && nCol >= 0 && nRow < rows && nCol < cols && grid[nRow][nCol] > 0)
                            {
                                int nIndex = nRow * cols + nCol;

                                union(parent, componentSize, totalFish, cellIndex, nIndex);
                            }
                        }

                    }
                }
            }

            int result = 0;

            for (int cellIndex = 0; cellIndex < totalCells; cellIndex++)
            {
                if (findParent(parent, cellIndex) == cellIndex)
                {
                    result = Math.Max(result, totalFish[cellIndex]);
                }
            }

            return result;
        }

        private int findParent(int[] parent, int cellIndex)
        {
            if (parent[cellIndex] == cellIndex) return cellIndex;

            return parent[cellIndex] = findParent(parent, parent[cellIndex]);
        }

        private void union(int[] parent, int[] componentSize, int[] totalFish, int cellIndex1, int cellIndex2)
        {
            int root1 = findParent(parent, cellIndex1);
            int root2 = findParent(parent, cellIndex2);

            if (root1 != root2)
            {
                if (componentSize[root1] < componentSize[root2])
                {
                    int temp = root1;
                    root1 = root2;
                    root2 = temp;
                }
                parent[root2] = root1;
                componentSize[root1] += componentSize[root2];
                totalFish[root1] += totalFish[root2];
            }
        }

        public int FindMaxFish_1(int[][] grid)
        {
            int result = 0;
            bool[,] visited = new bool[grid.Length, grid[0].Length];

            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid[i].Length; j++)
                {
                    if (grid[i][j] != 0 && !visited[i, j])
                    {
                        Queue<(int row, int col)> q = new Queue<(int row, int col)>();
                        q.Enqueue((i, j));
                        visited[i, j] = true;
                        int curFish = 0;
                        while (q.Count > 0)
                        {
                            var dq = q.Dequeue();

                            curFish += grid[dq.row][dq.col];

                            enqueue(q, grid, visited, dq.row + 1, dq.col);
                            enqueue(q, grid, visited, dq.row, dq.col + 1);
                            enqueue(q, grid, visited, dq.row - 1, dq.col);
                            enqueue(q, grid, visited, dq.row, dq.col - 1);
                        }
                        result = Math.Max(result, curFish);
                    }
                }
            }

            return result;


        }

        private void enqueue(Queue<(int row, int col)> q, int[][] grid, bool[,] visited, int row, int col)
        {
            if (row < 0 || col < 0 || row >= grid.Length || col >= grid[row].Length || visited[row, col] || grid[row][col] == 0) return;
            q.Enqueue((row, col));
            visited[row, col] = true;
        }
        #endregion

        #region 2661. First Completely Painted Row or Column
        public int FirstCompleteIndex(int[] arr, int[][] mat)
        {
            int rows = mat.Length;
            int cols = mat[0].Length;

            (int row, int col)[] map = new (int row, int col)[arr.Length + 1];

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    map[mat[row][col]] = (row, col);
                }
            }
            int k = 0;
            foreach (var item in map)
            {
                Console.WriteLine($"{k++} {item.row}      {item.col}");
            }
            int[] rowDP = new int[rows];
            int[] colDP = new int[cols];
            for (int i = 0; i < arr.Length; i++)
            {
                (int row, int col) = map[arr[i]];

                rowDP[row]++;
                if (rowDP[row] == cols) return i;
                colDP[col]++;
                if (colDP[col] == rows) return i;
            }
            return 0;
        }
        #endregion

        #region 2683. Neighboring Bitwise XOR
        public bool DoesValidArrayExist(int[] derived)
        {
            int res = 0;
            foreach (int i in derived)
            {
                res ^= i;
            }
            return res == 0;
        }
        #endregion

        #region 2570. Merge Two 2D Arrays by Summing Values
        public int[][] MergeArrays(int[][] nums1, int[][] nums2)
        {
            List<int[]> list = new List<int[]>();
            int index1 = 0;
            int index2 = 0;

            while (index1 < nums1.Length && index2 < nums2.Length)
            {
                if (nums1[index1][0] == nums2[index2][0])
                {
                    list.Add(new int[] { nums1[index1][0], nums1[index1][1] + nums2[index2][1] });
                    index1++;
                    index2++;
                }
                else if (nums1[index1][0] < nums2[index2][0])
                {
                    list.Add(nums1[index1]);
                    index1++;
                }
                else
                {
                    list.Add(nums2[index2]);
                    index2++;
                }
            }

            while (index1 < nums1.Length)
            {
                list.Add(nums1[index1]);
                index1++;
            }

            while (index2 < nums2.Length)
            {
                list.Add(nums2[index2]);
                index2++;
            }

            return list.ToArray();
        }
        #endregion

        #region 2698. Find the Punishment Number of an Integer
        public int PunishmentNumber(int n)
        {
            int result = 0;

            for (int num = 1; num <= n; num++)
            {
                int sq = num * num;
                string numString = sq.ToString();

                int[][] mem = new int[numString.Length][];
                for (int i = 0; i < mem.Length; i++)
                {
                    mem[i] = new int[num + 1];
                    Array.Fill(mem[i], -1);
                }

                if (isPunishmentNumber(0, 0, numString, num, mem))
                {
                    result += sq;
                }

            }

            return result;
        }

        private bool isPunishmentNumber(int startIndex, int sum, string numString, int target, int[][] mem)
        {
            if (startIndex == numString.Length) return sum == target;

            if (sum > target) return false;

            if (mem[startIndex][sum] != -1) return mem[startIndex][sum] == 1;

            bool partitionFound = false;

            for (int currIndex = startIndex; currIndex < numString.Length; currIndex++)
            {
                string currString = numString.Substring(startIndex, currIndex - startIndex + 1);

                int addend = int.Parse(currString);

                partitionFound = partitionFound || isPunishmentNumber(currIndex + 1, sum + addend, numString, target, mem);

                if (partitionFound)
                {
                    mem[startIndex][sum] = 1;
                    return true;
                }
            }
            mem[startIndex][sum] = 0;
            return false;
        }
        #endregion

        #region 2948. Make Lexicographically Smallest Array by Swapping Elements
        public int[] LexicographicallySmallestArray(int[] nums, int limit)
        {
            PriorityQueue<int, int> pq = new PriorityQueue<int, int>();

            for (int i = 0; i < nums.Length; i++)
            {
                pq.Enqueue(i, nums[i]);
            }
            int[] result = new int[nums.Length];

            while (pq.Count > 0)
            {
                int curIndex = pq.Dequeue();
                int curNum = nums[curIndex];

                List<int> lstNums = new List<int>() { curNum };
                List<int> indexes = new List<int>() { curIndex };

                while (pq.Count > 0 && nums[pq.Peek()] - curNum <= limit)
                {
                    curIndex = pq.Dequeue();
                    curNum = nums[curIndex];
                    lstNums.Add(curNum);
                    indexes.Add(curIndex);
                }

                indexes.Sort();
                for (int i = 0; i < lstNums.Count; i++)
                {
                    result[indexes[i]] = lstNums[i];
                }
            }

            return result;
        }
        public int[] LexicographicallySmallestArray_1(int[] nums, int limit)
        {

            for (int i = 0; i < nums.Length; i++)
            {
                bool noChange = true;

                for (int j = i + 1; j < nums.Length; j++)
                {
                    if (nums[i] > nums[j] && nums[i] - nums[j] <= limit)
                    {
                        noChange = false;
                        int temp = nums[i];
                        nums[i] = nums[j];
                        nums[j] = temp;
                        break;
                    }
                }
                if (!noChange)
                {
                    i--;
                }
            }

            return nums;

        }
        #endregion

        #region 2965. Find Missing and Repeated Values
        public int[] FindMissingAndRepeatedValues(int[][] grid)
        {
            int n = grid.Length;
            int totalNums = n * n;
            int duplicate = -1;
            HashSet<int> map = new HashSet<int>();
            int i = 0;
            while (++i <= totalNums)
            {
                map.Add(i);
            }

            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    if (!map.Contains(grid[row][col]))
                    {
                        duplicate = grid[row][col];
                    }
                    else
                    {
                        map.Remove(grid[row][col]);
                    }
                }
            }

            return new int[] { duplicate, map.First() };
        }
        #endregion

        #region 3042. Count Prefix and Suffix Pairs I
        public int CountPrefixSuffixPairs(string[] words)
        {
            int count = 0;
            Trie suffixTrie = new Trie('.');
            Trie prefixTrie = new Trie('.');
            int wordIndex = 0;
            foreach (string word in words)
            {
                suffixTrie.Insert(word, word.Length - 1, wordIndex, true);
                prefixTrie.Insert(word, 0, wordIndex);
                wordIndex++;
            }
            wordIndex = 0;
            foreach (string word in words)
            {
                HashSet<int> prefixIndex = prefixTrie.GetIndexes(word, 0);
                HashSet<int> suffixIndex = suffixTrie.GetIndexes(word, word.Length - 1, true);

                foreach (var item in suffixIndex)
                {
                    if (item <= wordIndex || !prefixIndex.Contains(item)) continue;
                    count++;
                }
                wordIndex++;
            }

            return count;
        }

        class Trie
        {
            public char C { get; set; }
            public HashSet<int> Indexes { get; set; }
            public Trie[] Childrens { get; set; }

            public Trie(char c)
            {
                C = c;
                Indexes = new HashSet<int>();
                Childrens = new Trie[26];
            }

            public void Insert(string word, int index, int wordIndex, bool reverseFlag = false)
            {
                if ((reverseFlag && index < 0) || (!reverseFlag && index == word.Length)) return;
                int childIndex = word[index] - 'a';
                if (Childrens[childIndex] == null)
                {
                    Childrens[childIndex] = new Trie(word[index]);
                }
                Childrens[childIndex].Indexes.Add(wordIndex);
                index = reverseFlag ? index - 1 : index + 1;
                Childrens[childIndex].Insert(word, index, wordIndex, reverseFlag);
            }

            public HashSet<int> GetIndexes(string word, int index, bool reverseFlag = false)
            {
                if ((!reverseFlag && index == word.Length - 1) || (reverseFlag && index == 0))
                {
                    if (Childrens[word[index] - 'a'] != null) return Childrens[word[index] - 'a'].Indexes;
                    return new HashSet<int>();
                }
                return Childrens[word[index] - 'a'].GetIndexes(word, reverseFlag ? index - 1 : index + 1, reverseFlag);
            }
        }

        public int CountPrefixSuffixPairs_1(string[] words)
        {
            int count = 0;

            for (int i = 0; i < words.Length - 1; i++)
            {
                for (int j = i + 1; j < words.Length; j++)
                {
                    count += isPrefixAndSuffix_1(words[i], words[j]);
                }
            }

            return count;
        }

        private int isPrefixAndSuffix_1(string v1, string v2)
        {
            if (v2.StartsWith(v1) && v2.EndsWith(v1)) return 1;
            return 0;
        }
        #endregion

        #region 3066. Minimum Operations to Exceed Threshold Value II
        public int MinOperations(int[] nums, int k)
        {
            int counter = 0;

            PriorityQueue<int, int> pq = new PriorityQueue<int, int>();

            for (int i = 0; i < nums.Length; i++)
            {
                pq.Enqueue(nums[i], nums[i]);
            }

            while (pq.Count > 0 && pq.Peek() < k)
            {
                int n1 = pq.Dequeue();
                int n2 = pq.Count > 0 ? pq.Dequeue() : k;

                long newNumber = n1 * 2;
                newNumber += n2;
                if (newNumber < k)
                {
                    pq.Enqueue((int)newNumber, (int)newNumber);
                }
                counter++;
            }

            return counter;
        }
        #endregion

        #region 3105. Longest Strictly Increasing or Strictly Decreasing Subarray
        public int LongestMonotonicSubarray(int[] nums)
        {
            int maxLength = 1;
            int incrLength = 1;
            int decrLength = 1;
            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[i] == nums[i - 1])
                {
                    maxLength = Math.Max(maxLength, Math.Max(incrLength, decrLength));
                    incrLength = 1;
                    decrLength = 1;
                }
                else if (nums[i] > nums[i - 1])
                {
                    maxLength = Math.Max(maxLength, decrLength);
                    incrLength++;
                    decrLength = 1;
                }
                else
                {
                    maxLength = Math.Max(maxLength, incrLength);
                    incrLength = 1;
                    decrLength++;
                }
            }


            return Math.Max(maxLength, Math.Max(incrLength, decrLength));
        }

        #endregion

        #region 3160. Find the Number of Distinct Colors Among the Balls
        public int[] QueryResults(int limit, int[][] queries)
        {
            int[] result = new int[queries.Length];
            Dictionary<int, int> ballMap = new Dictionary<int, int>();
            Dictionary<int, int> colorMap = new Dictionary<int, int>();
            int currentCount = 0;
            for (int i = 0; i < queries.Length; i++)
            {
                int ball = queries[i][0];
                int color = queries[i][1];

                if (ballMap.ContainsKey(ball))
                {
                    int ballOldColor = ballMap[ball];
                    colorMap[ballOldColor]--;
                    if (colorMap[ballOldColor] == 0)
                    {

                        currentCount--;
                    }
                }

                ballMap[ball] = color;
                if (!colorMap.ContainsKey(color) || colorMap[color] == 0)
                {
                    colorMap[color] = 1;
                    currentCount++;
                }
                else
                {
                    colorMap[color]++;
                }

                result[i] = currentCount;
            }

            return result;
        }

        public int[] QueryResults1(int limit, int[][] queries)
        {
            int[] result = new int[queries.Length];
            int[] balls = new int[limit + 1];
            Dictionary<int, int> colorMap = new Dictionary<int, int>();
            int currentCount = 0;
            for (int i = 0; i < queries.Length; i++)
            {
                int ball = queries[i][0];
                int color = queries[i][1];

                if (balls[ball] != 0)
                {
                    int ballOldColor = balls[ball];
                    colorMap[ballOldColor]--;
                    if (colorMap[ballOldColor] == 0)
                    {
                        currentCount--;
                    }
                }

                balls[ball] = color;
                if (!colorMap.ContainsKey(color) || colorMap[color] == 0)
                {
                    colorMap[color] = 1;
                    currentCount++;
                }
                else
                {
                    colorMap[color]++;
                }

                result[i] = currentCount;
            }

            return result;
        }

        #endregion

        #region 3174. Clear Digits
        public string ClearDigits(string s)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(s[0]);
            int index = 1;
            while (index < s.Length)
            {
                if (char.IsDigit(s[index]))
                {
                    stringBuilder.Remove(stringBuilder.Length - 1, 1);
                }
                else
                {
                    stringBuilder.Append(s[index]);
                }
                index++;
            }
            return stringBuilder.ToString();
        }
        #endregion

        #region 3208. Alternating Groups II
        public int NumberOfAlternatingGroups(int[] colors, int k)
        {
            int length = colors.Length;
            int result = 0;
            int alternatingElementsCount = 1;
            int lastColor = colors[0];

            for (int index = 1; index < length; index++)
            {
                if (colors[index] == lastColor)
                {
                    alternatingElementsCount = 1;
                    lastColor = colors[index];
                    continue;
                }

                alternatingElementsCount++;

                if (alternatingElementsCount >= k)
                {
                    result++;
                }

                lastColor = colors[index];
            }

            for (int index = 0; index < k - 1; index++)
            {
                if (colors[index] == lastColor)
                    break;

                alternatingElementsCount++;

                if (alternatingElementsCount >= k)
                {
                    result++;
                }

                lastColor = colors[index];
            }

            return result;
        }
        #endregion

        #region 3223. Minimum Length of String After Operations
        public int MinimumLength(string s)
        {
            int[] chars = new int[26];
            int reduce = 0;
            foreach (char c in s)
            {
                chars[c - 'a']++;
                if (chars[c - 'a'] == 3)
                {
                    reduce += 2;
                    chars[c - 'a'] = 1;
                }
            }
            return 0;
        }
        #endregion

        #region 3306. Count of Substrings Containing Every Vowel and K Consonants II
        public long CountOfSubstrings2(string word, int k)
        {
            return AtLeastK(word, k) - AtLeastK(word, k + 1);
        }

        private long AtLeastK(string word, int k)
        {
            long numValidSubstrings = 0;
            int start = 0, end = 0;
            Dictionary<char, int> vowelCount = new Dictionary<char, int>();
            int consonantCount = 0;

            while (end < word.Length)
            {
                char newLetter = word[end];

                if (IsVowel(newLetter))
                {
                    if (!vowelCount.ContainsKey(newLetter))
                    {
                        vowelCount[newLetter] = 0;
                    }
                    vowelCount[newLetter]++;
                }
                else
                {
                    consonantCount++;
                }

                while (vowelCount.Count == 5 && consonantCount >= k)
                {
                    numValidSubstrings += word.Length - end;
                    char startLetter = word[start];

                    if (IsVowel(startLetter))
                    {
                        vowelCount[startLetter]--;
                        if (vowelCount[startLetter] == 0)
                        {
                            vowelCount.Remove(startLetter);
                        }
                    }
                    else
                    {
                        consonantCount--;
                    }

                    start++;
                }

                end++;
            }

            return numValidSubstrings;
        }

        private bool IsVowel(char c)
        {
            return c == 'a' || c == 'e' || c == 'i' || c == 'o' || c == 'u';
        }

        public long CountOfSubstrings(string word, int k)
        {
            long result = 0;
            int c = 0, a = 0, e = 0, i = 0, o = 0, u = 0, index = -1, startIndex = 0;
            HashSet<char> vowels = new HashSet<char>();
            while (++index < word.Length)
            {
                switch (word[index])
                {
                    case 'a':
                        a++;
                        vowels.Add('a');
                        if (c == k && vowels.Count == 5)
                        {
                            result++;
                        }
                        break;
                    case 'e':
                        e++;
                        vowels.Add('e');
                        if (c == k && vowels.Count == 5)
                        {
                            result++;
                        }
                        break;
                    case 'i':
                        i++;
                        vowels.Add('e');
                        if (c == k && vowels.Count == 5)
                        {
                            result++;
                        }
                        break;
                    case 'o':
                        o++;
                        vowels.Add('o');
                        if (c == k && vowels.Count == 5)
                        {
                            result++;
                        }
                        break;
                    case 'u':
                        vowels.Add('u');
                        u++;
                        break;
                    default:
                        c++;
                        if (c == k && vowels.Count == 5)
                        {
                            result++;
                        }
                        else if (c > k)
                        {
                            while (c >= k && vowels.Count == 5)
                            {
                                switch (word[startIndex])
                                {
                                    case 'a':
                                        a--;
                                        if (a == 0)
                                        {
                                            vowels.Remove('a');
                                        }
                                        break;

                                    case 'e':
                                        e--;
                                        if (e == 0)
                                        {
                                            vowels.Remove('e');
                                        }
                                        break;
                                    case 'i':
                                        i--;
                                        if (i == 0)
                                        {
                                            vowels.Remove('i');
                                        }
                                        break;
                                    case 'o':
                                        o--;
                                        if (o == 0)
                                        {
                                            vowels.Remove('o');
                                        }
                                        break;
                                    case 'u':
                                        u--;
                                        if (u == 0)
                                        {
                                            vowels.Remove('u');
                                        }
                                        break;
                                    default:
                                        c--;
                                        if (vowels.Count == 5)
                                        {
                                            result++;
                                        }
                                        break;
                                }
                            }
                        }
                        break;
                }


            }
            if (c == k)
            {
                while (c == k && a > 0 && e > 0 && i > 0 && o > 0 && u > 0)
                {
                    result++;
                    switch (word[startIndex])
                    {
                        case 'a':
                            a--;
                            break;
                        case 'e':
                            e--;
                            break;
                        case 'i':
                            i--;
                            break;
                        case 'o':
                            o--;
                            break;
                        case 'u':
                            u--;
                            break;
                        default:
                            c--;
                            break;
                    }
                    startIndex++;
                }
            }
            return result;
        }
        #endregion

        #region 3356. Zero Array Transformation II


        public int MinZeroArray(int[] nums, int[][] queries)
        {
            int n = nums.Length, left = 0, right = queries.Length;

            if (!currentIndexZero(nums, queries, right)) return -1;
            while (left <= right)
            {
                int middle = left + (right - left) / 2;
                if (currentIndexZero(nums, queries, middle))
                {
                    right = middle - 1;
                }
                else
                {
                    left = middle + 1;
                }
            }

            return left;
        }

        private bool currentIndexZero(int[] nums, int[][] queries, int k)
        {
            int n = nums.Length, sum = 0;
            int[] differenceArray = new int[n + 1];

            // Process query
            for (int queryIndex = 0; queryIndex < k; queryIndex++)
            {
                int left = queries[queryIndex][0], right =
                    queries[queryIndex][1], val = queries[queryIndex][2];

                // Process start and end of range
                differenceArray[left] += val;
                differenceArray[right + 1] -= val;
            }

            // Check if zero array can be formed
            for (int numIndex = 0; numIndex < n; numIndex++)
            {
                sum += differenceArray[numIndex];
                if (sum < nums[numIndex]) return false;
            }
            return true;
        }

        public int MinZeroArray_1(int[] nums, int[][] queries)
        {
            int res = 0;
            HashSet<int> set = new HashSet<int>();
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] == 0)
                {
                    set.Add(i);
                }
            }
            for (int j = 0; j < queries.Length; j++)
            {
                if (set.Count == nums.Length)
                {
                    return j;
                }

                int l = queries[j][0];
                int r = queries[j][1];
                int v = queries[j][2];
                for (int i = l; i <= r; i++)
                {
                    nums[i] = Math.Max(0, nums[i] - v);
                    if (nums[i] == 0)
                    {
                        set.Add(i);
                    }
                }
            }


            return set.Count == nums.Length ? queries.Length : -1;
        }
        #endregion

        #region 3417. Zigzag Grid Traversal With Skip
        public IList<int> ZigzagTraversal(int[][] grid)
        {
            int rows = grid.Length;
            int cols = grid[0].Length;
            IList<int> result = new List<int>();
            int col = 0;
            for (int row = 0; row < rows; row++)
            {
                if (row % 2 == 0)
                {
                    for (; col < cols; col += 2)
                    {
                        result.Add(grid[row][col]);
                    }
                    if (col == cols)
                    {
                        col = cols - 1;
                    }
                    else
                    {
                        col = cols - 2;
                    }
                }
                else
                {
                    for (; col >= 0; col -= 2)
                    {
                        result.Add(grid[row][col]);
                    }

                    if (col == -1)
                    {
                        col = 0;
                    }
                    else
                    {
                        col = 1;
                    }
                }
            }
            return result;
        }

        public IList<int> ZigzagTraversal1(int[][] grid)
        {
            int rows = grid.Length;
            int cols = grid[0].Length;
            int[] arr = new int[rows * cols];
            int index = 0;
            for (int row = 0; row < rows; row++)
            {
                if (row % 2 == 0)
                {
                    for (int col = 0; col < cols; col++)
                    {
                        arr[index++] = grid[row][col];
                    }
                }
                else
                {
                    for (int col = cols - 1; col >= 0; col--)
                    {
                        arr[index++] = grid[row][col];
                    }
                }
            }
            IList<int> result = new List<int>();
            index = 0;
            while (index < arr.Length)
            {
                result.Add(arr[index]);
                index += 2;
            }
            return result;
        }
        #endregion

        #region 3418. Maximum Amount of Money Robot Can Earn
        public int MaximumAmount(int[][] coins)
        {
            int rows = coins.Length;
            int cols = coins[0].Length;
            (int sum, int l1, int l2)[,] dp = new (int sum, int l1, int l2)[rows, cols];
            int sum = coins[0][0];
            int l1 = 0;
            int l2 = 0;
            if (sum < 0)
            {
                sum = 0;
                l1 = sum;
            }
            dp[0, 0] = (sum, l1, l2);
            for (int row = 1; row < rows; row++)
            {
                (sum, l1, l2) = dp[row - 1, 0];
                update(coins, dp, sum, l1, l2, row, 0);
            }

            for (int col = 1; col < cols; col++)
            {
                (sum, l1, l2) = dp[0, col - 1];
                update(coins, dp, sum, l1, l2, 0, col);
            }


            for (int row = 1; row < rows; row++)
            {
                for (int col = 1; col < cols; col++)
                {
                    int currVal = coins[row][col];
                    if (currVal >= 0)
                    {

                    }
                    else
                    {

                    }
                }
            }

            return dp[rows - 1, cols - 1].sum;// - dp[rows - 1, cols - 1].l1 - dp[rows - 1, cols - 1].l2;
        }

        private static void update(int[][] coins, (int sum, int l1, int l2)[,] dp, int sum, int l1, int l2, int row, int col)
        {
            if (coins[row][col] < 0)
            {
                if (coins[row][col] < l1)
                {
                    sum += l2;
                    l2 = l1;
                    l1 = coins[row][col];
                }
                else if (coins[row][col] < l2)
                {
                    sum += l2;
                    l2 = coins[row][col];
                }
                else
                {
                    sum += coins[row][col];
                }
            }
            else
            {
                sum += coins[row][col];
            }

            dp[row, col] = (sum, l1, l2);
        }

        public int MaximumAmount1(int[][] coins)
        {
            int rows = coins.Length;
            int cols = coins[0].Length;
            (int sum, int lastElement1, int lastElement2)[,] dp = new (int sum, int lastElement1, int lastElement2)[rows, cols];
            int coin = coins[rows - 1][cols - 1];
            int l1 = 0;
            int l2 = 0;

            if (coin < 0)
            {
                l1 = coin;
            }

            dp[rows - 1, cols - 1] = (coin, l1, l2);
            int row = rows - 2;
            int col = cols - 1;
            for (; row >= 0; row--)
            {
                updateRowCol(coins, dp, row, col, row + 1, col);
            }
            row = rows - 1;
            col = cols - 2;
            for (; col >= 0; col--)
            {
                updateRowCol(coins, dp, row, col, row, col + 1);
            }

            row = rows - 2;


            for (; row >= 0; row--)
            {
                col = cols - 2;
                for (; col >= 0; col--)
                {
                    var fromDown = dp[row + 1, col];
                    var fromRight = dp[row, col + 1];
                    int downSum = fromDown.sum;// - fromDown.lastElement1 - fromDown.lastElement2;
                    int rightSum = fromRight.sum;// - fromRight.lastElement1 - fromRight.lastElement2;

                    if (downSum > rightSum)
                    {
                        updateRowCol(coins, dp, row, col, row + 1, col);
                    }
                    else
                    {
                        updateRowCol(coins, dp, row, col, row, col + 1);

                    }
                }
            }

            int result = dp[0, 0].sum;
            l1 = dp[0, 0].lastElement1;
            if (l1 < 0)
            {
                result -= l1;
                l2 = dp[0, 0].lastElement2;
                if (l2 < 0)
                {
                    result -= l2;
                }
            }

            return result;
        }

        private void updateRowCol(int[][] coins, (int sum, int lastElement1, int lastElement2)[,] dp, int currRow, int currCol, int oldRow, int oldCol)
        {
            int coin = coins[currRow][currCol];
            int l1 = dp[oldRow, oldCol].lastElement1;
            int l2 = dp[oldRow, oldCol].lastElement2;

            if (coin < 0)
            {
                if (coin < l1)
                {
                    l2 = l1;
                    l1 = coin;
                }
                else if (coin < l2)
                {
                    l2 = coin;
                }
            }

            coin += dp[oldRow, oldCol].sum;

            dp[currRow, currCol] = (coin, l1, l2);
        }
        #endregion

        #region 3477. Fruits Into Baskets II
        public int NumOfUnplacedFruits(int[] fruits, int[] baskets)
        {
            int unplaced = 0;
            Stack<int> stack = new Stack<int>();
            for (int i = fruits.Length - 1; i >= 0; i--)
            {
                stack.Push(baskets[i]);
            }


            Stack<int> stack1 = new Stack<int>();
            for (int i = 0; i < fruits.Length; i++)
            {
                if (fruits[i] <= stack.Peek())
                {
                    stack.Pop();
                }
                else
                {
                    bool placed = false;
                    stack1.Push(stack.Pop());
                    while (stack.Count > 0)
                    {
                        if (fruits[i] <= stack.Peek())
                        {
                            placed = true;
                            stack.Pop();
                            break;
                        }
                        else
                        {
                            stack1.Push(stack.Pop());
                        }
                    }

                    if (!placed)
                    {
                        unplaced++;
                    }

                    while (stack1.Count > 0)
                    {
                        stack.Push(stack1.Pop());
                    }

                }
            }
            return unplaced;
        }
        #endregion

        #region 3478. Choose K Elements With Maximum Sum
        public long[] FindMaxSum(int[] nums1, int[] nums2, int k)
        {
            PriorityQueue<(int index, int n1, int n2), int> pq = new PriorityQueue<(int index, int n1, int n2), int>();

            for (int i = 0; i < nums1.Length; i++)
            {
                pq.Enqueue((i, nums1[i], nums2[i]), nums1[i]);
            }
            PriorityQueue<long, long> kpq = new PriorityQueue<long, long>();
            long currSum = 0;

            var top = pq.Dequeue();
            currSum = top.n2;

            kpq.Enqueue(currSum, currSum);
            long[] result = new long[nums1.Length];
            result[top.index] = 0;
            int lastPriority = top.n1;
            long lastSum = 0;
            while (pq.Count > 0)
            {
                var dq = pq.Dequeue();
                if (lastPriority == dq.n1)
                {
                    result[dq.index] = lastSum;
                }
                else
                {
                    result[dq.index] = currSum;
                    lastPriority = dq.n1;
                    lastSum = currSum;
                }


                if (kpq.Count < k)
                {
                    currSum += dq.n2;
                    kpq.Enqueue(dq.n2, dq.n2);
                }
                else
                {
                    if (kpq.Peek() < dq.n2)
                    {
                        currSum -= kpq.Dequeue();
                        currSum += dq.n2;
                        kpq.Enqueue(dq.n2, dq.n2);
                    }
                }
            }

            return result;
        }
        #endregion

        #region Sum of Variable Length Subarrays
        public int SubarraySum(int[] nums)
        {
            int sum = nums[0];

            int[] prefixsum = new int[nums.Length];
            prefixsum[0] = nums[0];
            for (int i = 1; i < nums.Length; i++)
            {
                prefixsum[i] = prefixsum[i - 1] + nums[i];

                int startIndex = Math.Max(0, i - nums[i]);

                if (startIndex == 0)
                {
                    sum += prefixsum[i];
                }
                else
                {
                    sum += (prefixsum[i] - prefixsum[startIndex - 1]);
                }
            }
            return sum;
        }
        #endregion

        #region Count Partitions with Even Sum Difference
        public int CountPartitions(int[] nums)
        {
            int partions = 0;

            int[] presum = new int[nums.Length];
            presum[0] = nums[0];

            for (int i = 1; i < nums.Length; i++)
            {
                presum[i] = presum[i - 1] + nums[i];
            }

            int total = presum[presum.Length - 1];

            for (int i = 0; i < nums.Length; i++)
            {
                int diff = presum[i] - (total - presum[i]);
                if (diff % 2 == 0) partions++;
            }

            return partions;
        }
        #endregion

        #region Count Mentions Per User
        public int[] CountMentions(int numberOfUsers, IList<IList<string>> events)
        {
            int[] result = new int[numberOfUsers];
            int[] offlineUser = new int[numberOfUsers];
            Array.Fill(offlineUser, -1);
            Queue<(int, int)> offlineQueue = new Queue<(int, int)>();
            foreach (var item in events)
            {
                int t = int.Parse(item[1]);
                if (item[0] == "MESSAGE")
                {

                }
                else
                {

                }
            }


            return result;
        }
        #endregion

        #region 547. Number oF Provinces
        public int FindCircleNum(int[][] isConnected)
        {
            UnionFind547 unionFind547 = new UnionFind547(isConnected.Length);
            int n = isConnected.Length;
            for (int i = 0; i < isConnected.Length; i++)
            {
                for (int j = i + 1; j < isConnected.Length; j++)
                {
                    if (isConnected[i][j] == 1 && unionFind547.Find(i) != unionFind547.Find(j))
                    {
                        n--;
                        unionFind547.Union(i, j);
                    }

                }
            }
            return n;
        }
        class UnionFind547
        {
            int[] parent;
            int[] rank;
            public UnionFind547(int size)
            {
                parent = new int[size];
                rank = new int[size];
                for (int i = 0; i < size; i++)
                {
                    parent[i] = i;
                    rank[i] = 1;
                }
            }

            internal void Union(int x, int y)
            {
                int parentX = Find(x);
                int parentY = Find(y);

                if (parentX != parentY)
                {
                    if (rank[parentX] > rank[parentY])
                    {
                        parent[parentY] = parentX;
                    }
                    else if (rank[parentX] < rank[parentY])
                    {
                        parent[parentX] = parentY;
                    }
                    else
                    {
                        parent[parentX] = parentY;
                        rank[parentY]++;
                    }
                }
            }

            internal int Find(int x)
            {
                if (parent[x] == x) return x;

                return Find(parent[x]);
            }

        }
        #endregion

        #region weekly contest 438
        public bool HasSameDigits1(string s)
        {
            if (s.Length == 2)
            {
                return s[0] == s[1];
            }

            char[] chars = new char[s.Length - 1];

            for (int i = 1; i < s.Length; i++)
            {
                int n1 = s[i] - '0';
                int n2 = s[i - 1] - '0';


                chars[i - 1] = (char)(((n1 + n2) % 10) + '0');

            }

            return HasSameDigits1(new string(chars));
        }

        public bool HasSameDigits(string s)
        {
            while (s.Length > 1)
            {
                bool allSame = true;
                for (int i = 1; i < s.Length; i++)
                {
                    if (s[i] != s[i - 1])
                    {
                        allSame = false;
                        break;
                    }
                }
                if (allSame) return true;

                char[] newS = new char[s.Length - 1];
                for (int i = 1; i < s.Length; i++)
                {
                    newS[i - 1] = (char)(((s[i] - '0' + s[i - 1] - '0') % 10) + '0');
                }

                s = new string(newS);
            }

            return true;
        }

        public long MaxSum(int[][] grid, int[] limits, int k)
        {
            if (k == 0) return 0;
            PriorityQueue<int, int>[] map = new PriorityQueue<int, int>[grid.Length];
            for (int i = 0; i < grid.Length; i++)
            {
                map[i] = new PriorityQueue<int, int>();
                int maxSize = Math.Min(limits[i], k);
                if (maxSize > 0)
                {
                    for (int j = 0; j < grid[i].Length; j++)
                    {
                        int curr = grid[i][j];
                        if (map[i].Count < maxSize)
                        {
                            map[i].Enqueue(curr, curr);
                        }
                        else if (map[i].Peek() < curr)
                        {
                            map[i].Dequeue();
                            map[i].Enqueue(curr, curr);
                        }
                    }
                }
            }

            PriorityQueue<int, int> pq = new PriorityQueue<int, int>();

            for (int i = 0; i < grid.Length; i++)
            {
                while (map[i].Count > 0)
                {
                    int curr = map[i].Dequeue();
                    if (pq.Count < k)
                    {
                        pq.Enqueue(curr, curr);
                    }
                    else if (pq.Peek() < curr)
                    {
                        pq.Dequeue();
                        pq.Enqueue(curr, curr);
                    }
                }
            }

            long result = 0;
            while (pq.Count > 0)
            {
                result += pq.Dequeue();
            }
            return result;
        }

        public int MaxDistance(int side, int[][] points, int k)
        {

            int left = 0, right = side;

            while (left < right)
            {
                int mid = (left + right + 1) / 2;
                if (CanSelectKPoints(points, k, mid))
                {
                    left = mid;
                }
                else
                {
                    right = mid - 1;
                }
            }

            return left;
        }

        private bool CanSelectKPoints(int[][] points, int k, int minDist)
        {
            List<int[]> selected = new List<int[]>();

            foreach (var point in points)
            {
                if (selected.Count == 0 || IsValid(selected, point, minDist))
                {
                    selected.Add(point);
                    if (selected.Count == k) return true;
                }
            }

            return false;
        }

        private bool IsValid(List<int[]> selected, int[] candidate, int minDist)
        {
            foreach (var p in selected)
            {
                int dist = Math.Abs(p[0] - candidate[0]) + Math.Abs(p[1] - candidate[1]);
                if (dist < minDist) return false;
            }
            return true;
        }

        public int MaxDistance1(int side, int[][] points, int k)
        {
            int left = 0, right = side;

            while (left < right)
            {
                int mid = (left + right + 1) / 2;
                if (IsFeasible1(points, k, mid))
                {
                    left = mid;
                }
                else
                {
                    right = mid - 1;
                }
            }

            return left;
        }

        private bool IsFeasible1(int[][] points, int k, int d)
        {
            return CanSelectPoints1(points, new List<int[]>(), 0, k, d);
        }

        private bool CanSelectPoints1(int[][] points, List<int[]> selected, int index, int k, int minDist)
        {
            if (selected.Count == k) return true;
            if (index >= points.Length) return false;

            for (int i = index; i < points.Length; i++)
            {
                if (IsValidSelection1(selected, points[i], minDist))
                {
                    selected.Add(points[i]);
                    if (CanSelectPoints1(points, selected, i + 1, k, minDist)) return true;
                    selected.RemoveAt(selected.Count - 1);
                }
            }
            return false;
        }

        private bool IsValidSelection1(List<int[]> selected, int[] candidate, int minDist)
        {
            foreach (var p in selected)
            {
                int dist = Math.Abs(p[0] - candidate[0]) + Math.Abs(p[1] - candidate[1]);
                if (dist < minDist) return false;
            }
            return true;
        }
        #endregion
    }

    public class NumberContainers
    {
        Dictionary<int, PriorityQueue<int, int>> numberIndexMap;
        Dictionary<int, int> indexNumberMap;
        public NumberContainers()
        {
            numberIndexMap = new Dictionary<int, PriorityQueue<int, int>>();
            indexNumberMap = new Dictionary<int, int>();
        }

        public void Change(int index, int number)
        {
            if (indexNumberMap.ContainsKey(index))
            {
                int curIndex = index;
                int oldNumber = indexNumberMap[curIndex];

                if (numberIndexMap[oldNumber].Peek() == curIndex)
                {
                    numberIndexMap[oldNumber].Dequeue();
                }
            }

            indexNumberMap[index] = number;

            if (!numberIndexMap.ContainsKey(number))
            {
                numberIndexMap[number] = new PriorityQueue<int, int>();
            }
            numberIndexMap[number].Enqueue(index, index);
        }

        public int Find(int number)
        {
            if (numberIndexMap.ContainsKey(number) && numberIndexMap[number].Count > 0)
            {
                while (indexNumberMap[numberIndexMap[number].Peek()] != number)
                {
                    numberIndexMap[number].Dequeue();

                    if (numberIndexMap[number].Count == 0)
                    {
                        return -1;
                    }
                }

                return numberIndexMap[number].Peek();

            }
            return -1;
        }
    }

    #region 1352. Product of the Last K Numbers
    //public class ProductOfNumbers
    //{
    //    int size = -1;
    //    public ProductOfNumbers()
    //    {

    //    }

    //    public void Add(int num)
    //    {

    //    }

    //    public int GetProduct(int k)
    //    {

    //    }
    //}
    public class ProductOfNumbers1
    {
        List<int> numbers;
        public ProductOfNumbers1()
        {
            numbers = new List<int>();
        }

        public void Add(int num)
        {
            numbers.Add(num);
        }

        public int GetProduct(int k)
        {
            int index = numbers.Count - 1;
            int product = numbers[index--];
            while (--k > 0)
            {
                product *= numbers[index--];
            }
            return product;
        }
    }
    #endregion


    #region 1261. Find Elements in a Contaminated Binary Tree
    public class FindElements
    {
        HashSet<int> numbers;

        public FindElements(TreeNode root)
        {
            numbers = new HashSet<int>();
            root.val = 0;

            recover(root);
        }

        private void recover(TreeNode root)
        {
            int curr = root.val;
            numbers.Add(curr);
            curr *= 2;
            if (root.left != null)
            {
                root.left.val = curr + 1;
                recover(root.left);
            }

            if (root.right != null)
            {
                root.right.val = curr + 2;
                recover(root.right);
            }
        }

        public bool Find(int target)
        {
            return numbers.Contains(target);
        }
    }
    #endregion
}