using System.Reflection.Metadata.Ecma335;

namespace Leetcode2025.Tests
{
    [TestClass]
    public sealed class Leetcode2025Tests
    {

        #region Initialize
        Leetcode2025 leetcode;
        [TestInitialize]
        public void TestInitialize()
        {
            this.leetcode = new Leetcode2025();
        }
        #endregion

        #region Input Read
        private int[][] getMultiDimensionalArray(string str)
        {
            str = str.Trim('[');
            str = str.Trim(']');
            string[] strings = str.Split("],[");
            int[][] result = new int[strings.Length][];
            for (int i = 0; i < strings.Length; i++)
            {
                result[i] = Array.ConvertAll(strings[i].Split(","), int.Parse);
            }

            return result;
        }
        #endregion

        [TestMethod]
        public void Test()
        {
        }

        #region 153. Find Minimum in Rotated Sorted Array
        [TestMethod]
        public void FindMinTest()
        {
            int[] nums = { 4, 5, 6, 7, 0, 1, 2 };

            int result = leetcode.FindMin_153(nums);

            Assert.AreEqual(0, result);
        }
        [TestMethod]
        public void FindMinTest1()
        {
            int[] nums = { 2, 1 };

            int result = leetcode.FindMin_153(nums);

            Assert.AreEqual(1, result);
        }
        [TestMethod]
        public void FindMinTest2()
        {
            int[] nums = { 4, 5, 1, 2, 3 };

            int result = leetcode.FindMin_153(nums);

            Assert.AreEqual(1, result);
        }
        [TestMethod]
        public void FindMinTest3()
        {
            int[] nums = { 5, 1, 2, 3, 4 };

            int result = leetcode.FindMin_153(nums);

            Assert.AreEqual(1, result);
        }
        #endregion

        #region 154. Find Minimum in Rotated Sorted Array II
        [TestMethod]
        public void FindMinTest4()
        {
            int[] nums = { 2, 2, 2, 0, 1 };
            var result = leetcode.FindMin(nums);
            Assert.AreEqual(0, result);
        }
        [TestMethod]
        public void FindMinTest5()
        {
            int[] nums = { -1, -1, -1, -1 };
            var result = leetcode.FindMin(nums);
            Assert.AreEqual(-1, result);
        }
        #endregion

        #region 174. Dungeon Game
        [TestMethod]
        public void CalculateMinimumHPTest()
        {
            string str = "[[-2,-3,3],[-5,-10,1],[10,30,-5]]";

            int[][] dungeon = getMultiDimensionalArray(str);

            var res = leetcode.CalculateMinimumHP(dungeon);

            Assert.AreEqual(7, res);
        }
        [TestMethod]
        public void CalculateMinimumHPTest1()
        {
            string str = "[[0]]";

            int[][] dungeon = getMultiDimensionalArray(str);

            var res = leetcode.CalculateMinimumHP(dungeon);

            Assert.AreEqual(1, res);
        }
        [TestMethod]
        public void CalculateMinimumHPTest2()
        {
            string str = "[[2,3,3],[5,10,1],[10,30,5]]";

            int[][] dungeon = getMultiDimensionalArray(str);

            var res = leetcode.CalculateMinimumHP(dungeon);

            Assert.AreEqual(1, res);
        }
        [TestMethod]
        public void CalculateMinimumHPTest3()
        {
            string str = "[[-200]]";

            int[][] dungeon = getMultiDimensionalArray(str);

            var res = leetcode.CalculateMinimumHP(dungeon);

            Assert.AreEqual(201, res);
        }
        [TestMethod]
        public void CalculateMinimumHPTest4()
        {
            string str = "[[1,-3,3],[0,-2,0],[-3,-3,-3]]";

            int[][] dungeon = getMultiDimensionalArray(str);

            var res = leetcode.CalculateMinimumHP(dungeon);

            Assert.AreEqual(3, res);
        }
        #endregion

        #region 214. Shortest Palindrome

        [TestMethod]
        public void ShortestPalindromeTest()
        {
            string s = "abcd";
            var result = leetcode.ShortestPalindrome(s);
            Assert.AreEqual("dcbabcd", result);
        }
        #endregion

        #region 218. The Skyline Problem

        [TestMethod]
        public void GetSkylineTest()
        {
            string test = "[[2,9,10],[3,7,15],[5,12,12],[15,20,10],[19,24,8]]";
            int[][] buildings = getMultiDimensionalArray(test);

            var result = leetcode.GetSkyline(buildings);



        }
        #endregion

        #region 407. Trapping Rain Water II

        [TestMethod]
        public void TrapRainWaterTest()
        {
            string s = "[[1,4,3,1,3,2],[3,2,1,3,2,4],[2,3,3,2,3,1]]";
            int[][] heightMap = getMultiDimensionalArray(s);
            var k = leetcode.TrapRainWater(heightMap);
            Assert.AreEqual(4, k);
        }

        [TestMethod]
        public void TrapRainWaterTest1()
        {
            string s = "[[12,13,1,12],[13,4,13,12],[13,8,10,12],[12,13,12,12],[13,13,13,13]]";
            int[][] heightMap = getMultiDimensionalArray(s);
            var k = leetcode.TrapRainWater(heightMap);
            Assert.AreEqual(14, k);
        }

        [TestMethod]
        public void TrapRainWaterTest2()
        {
            string s = "[[78,16,94,36],[87,93,50,22],[63,28,91,60],[64,27,41,27],[73,37,12,69],[68,30,83,31],[63,24,68,36]]";
            int[][] heightMap = getMultiDimensionalArray(s);
            var k = leetcode.TrapRainWater(heightMap);
            Assert.AreEqual(44, k);
        }

        [TestMethod]
        public void TrapRainWaterTest3()
        {
            string s = "[[1,4,3,1,3,2],[3,2,1,3,2,4],[2,3,3,2,3,1]]";
            int[][] heightMap = getMultiDimensionalArray(s);
            var k = leetcode.TrapRainWater(heightMap);
            Assert.AreEqual(4, k);
        }

        [TestMethod]
        public void TrapRainWaterTest4()
        {
            string s = "[[5,5,5,1],[5,1,1,5],[5,1,5,5],[5,2,5,8]]";
            int[][] heightMap = getMultiDimensionalArray(s);
            var k = leetcode.TrapRainWater(heightMap);
            Assert.AreEqual(4, k);
        }
        #endregion


        #region 827. Making A Large Island

        [TestMethod]
        public void LargestIslandTest()
        {
            string s = "[[1,1],[1,1]]";
            int[][] grid = getMultiDimensionalArray(s);
            var result = leetcode.LargestIsland(grid);
            Assert.AreEqual(4, result);
        }
        #endregion

        #region 1718. Construct the Lexicographically Largest Valid Sequence

        [TestMethod]
        public void ConstructDistancedSequenceTest()
        {
            var result = leetcode.ConstructDistancedSequence(3);
            
        }
        #endregion

        #region 1726. Tuple with Same Product

        [TestMethod]
        public void TupleSameProductTest()
        {
            int[] nums = { 2, 3, 4, 6 };
            var result = leetcode.TupleSameProduct(nums);
            Assert.AreEqual(8, result);
        }

        [TestMethod]
        public void TupleSameProductTest1()
        {
            int[] nums = { 1, 2, 4, 5, 10 };
            var result = leetcode.TupleSameProduct(nums);
            Assert.AreEqual(16, result);
        }

        [TestMethod]
        public void TupleSameProductTest2()
        {
            int[] nums = { 2, 3, 4, 6, 8, 12 };
            var result = leetcode.TupleSameProduct(nums);
            Assert.AreEqual(40, result);
        }

        [TestMethod]
        public void TupleSameProductTest3()
        {
            int[] nums = { 1, 2, 4, 8, 16, 32, 64, 128, 256, 512, 1024, 2048, 4096, 8192 };
            var result = leetcode.TupleSameProduct(nums);
            Assert.AreEqual(1288, result);
        }
        #endregion

        #region 1769. Minimum Number of Operations to Move All Balls to Each Box

        [TestMethod]
        public void MinOperationsTest()
        {
            string s = "110";
            var res = leetcode.MinOperations(s);
        }

        [TestMethod]
        public void MinOperationsTest1()
        {
            string s = "001011";
            var res = leetcode.MinOperations(s);
        }
        #endregion

        #region 1910. Remove All Occurrences of a Substring

        [TestMethod]
        public void RemoveOccurrencesTest()
        {
            string s = "daabcbaabcbc";
            string part = "abc";
            var res = leetcode.RemoveOccurrences(s,part);
            Assert.AreEqual("dab", res);
        }
        #endregion

        #region 1930. Unique Length-3 Palindromic Subsequences
        [TestMethod]
        public void CountPalindromicSubsequenceTest()
        {
            string s = "after";
            var result = leetcode.CountPalindromicSubsequence(s);
        }

        #endregion

        #region 2017. Grid Game


        [TestMethod]
        public void GridGameTest()
        {
            string s = "[[1,3,1,15],[1,3,3,1]]";
            int[][] grid = getMultiDimensionalArray(s);
            var result = leetcode.GridGame(grid);
            Assert.AreEqual(7, result);
        }
        #endregion


        #region 2342. Max Sum of a Pair With Equal Sum of Digits //18,43,36,13,7

        [TestMethod]
        public void MaximumSumTest()
        {
            int[] arr = { 18, 43, 36, 13, 7 };
            var result = leetcode.MaximumSum(arr);
            Assert.AreEqual(54, result);
        }
        #endregion

        #region 2349. Design a Number Container System
        private NumberContainers GetNumberContainer()
        {
            return new NumberContainers();
        }

        [TestMethod]
        public void NumberContainersTest1()
        {
            var n = GetNumberContainer();
            int findIndex = n.Find(10);
            Assert.AreEqual(-1, findIndex);
            n.Change(2, 10);
            n.Change(1, 10);
            n.Change(3, 10);
            n.Change(5, 10);
            findIndex = n.Find(10);
            Assert.AreEqual(1, findIndex);
            n.Change(1, 20);
            findIndex = n.Find(10);
            Assert.AreEqual(2, findIndex);
        }
        #endregion

        #region 2381. Shifting Letters II

        [TestMethod]
        public void ShiftingLettersTest1()
        {
            string s = "abc";
            string shiftsstring = "[[0,1,0],[0,1,0],[0,1,0],[0,1,0],[0,1,0],[0,1,0],[0,1,0],[0,1,0],[0,1,0],[0,1,0],[0,1,0],[0,1,0],[0,1,0],[0,1,0],[0,1,0],[0,1,0],[0,1,0],[1,2,1],[0,2,1]]";
            int[][] shifts = getMultiDimensionalArray(shiftsstring);
            var result = leetcode.ShiftingLetters(s, shifts);
            Assert.AreEqual("kme", result);
        }

        [TestMethod]
        public void ShiftingLettersTest2()
        {
            string s = "dztz";
            string shiftsstring = "[[0,0,0],[1,1,1]]";
            int[][] shifts = getMultiDimensionalArray(shiftsstring);
            var result = leetcode.ShiftingLetters(s, shifts);
            Assert.AreEqual("catz", result);
        }

        [TestMethod]
        public void ShiftingLettersTest3()
        {
            string s = "xuwdbdqik";
            string shiftsstring = "[[4,8,0],[4,4,0],[2,4,0],[2,4,0],[6,7,1],[2,2,1],[0,2,1],[8,8,0],[1,3,1]]";
            int[][] shifts = getMultiDimensionalArray(shiftsstring);
            var result = leetcode.ShiftingLetters(s, shifts);
            Assert.AreEqual("ywxcxcqii", result);
        }
        #endregion

        #region 2425. Bitwise XOR of All Pairings
        [TestMethod]
        public void XorAllNumsTest()
        {
            int[] nums1 = { 8, 6, 29, 2, 26, 16, 15, 29 };
            int[] nums2 = { 24, 12, 12 };
            var k = leetcode.XorAllNums(nums1, nums2);
        }

        #endregion

        #region 2658. Maximum Number of Fish in a Grid

        [TestMethod]
        public void FindMaxFishTest()
        {
            string s = "[[0],[7]]";
            int[][] grid = getMultiDimensionalArray(s);
            var res = leetcode.FindMaxFish(grid);
        }
        #endregion

        #region 2661. First Completely Painted Row or Column
        [TestMethod]
        public void FirstCompleteIndexTest()
        {
            int[] arr = { 1, 4, 5, 2, 6, 3 };
            string s = "[[4,3,5],[1,2,6]]";
            int[][] mat = getMultiDimensionalArray(s);
            var result = leetcode.FirstCompleteIndex(arr, mat);
            Assert.AreEqual(1, result);
        }
        #endregion

        #region 2698. Find the Punishment Number of an Integer

        [TestMethod]
        public void PunishmentNumberTest()
        {
            int n = 10;
            var result = leetcode.PunishmentNumber(n);
            Assert.AreEqual(182, result);
        }
        #endregion

        #region 2948. Make Lexicographically Smallest Array by Swapping Elements

        [TestMethod]
        public void LexicographicallySmallestArrayTest()
        {
            int[] nums = { 1, 5, 3, 9, 8 };
            int limit = 2;
            var result = leetcode.LexicographicallySmallestArray(nums, limit);
        }
        #endregion

        #region 3042. Count Prefix and Suffix Pairs I
        [TestMethod]
        public void CountPrefixSuffixPairsTest()
        {
            string[] words = { "a", "aba", "ababa", "aa" };
            var result = leetcode.CountPrefixSuffixPairs(words);
            Assert.AreEqual(4, result);
        }
        [TestMethod]
        public void CountPrefixSuffixPairsTest1()
        {
            string[] words = { "pa", "papa", "ma", "mama" };
            var result = leetcode.CountPrefixSuffixPairs(words);
            Assert.AreEqual(2, result);
        }
        [TestMethod]
        public void CountPrefixSuffixPairsTest2()
        {
            string[] words = { "bb", "bb" };
            var result = leetcode.CountPrefixSuffixPairs(words);
            Assert.AreEqual(1, result);
        }
        #endregion

        #region 3066. Minimum Operations to Exceed Threshold Value II

        [TestMethod]
        public void MinOperationsTest_()
        {
            int[] arr = { 1000000000, 999999999, 1000000000, 999999999, 1000000000, 999999999 };
            int k = 1000000000;
            var result = leetcode.MinOperations(arr, k);
            Assert.AreEqual(2,result);
        }
        #endregion

        #region 3160. Find the Number of Distinct Colors Among the Balls
        [TestMethod]
        public void QueryResultsTest()
        {
            int limit = 4;
            string s = "[[0,1],[1,2],[2,2],[3,4],[4,5]]";
            int[][] queries = getMultiDimensionalArray(s);
            var res = leetcode.QueryResults(limit, queries);
        }

        #endregion

        #region 3417. Zigzag Grid Traversal With Skip

        [TestMethod]
        public void ZigzagTraversalTest()
        {
            string s = "[[1,2],[3,4]]";
            int[][] arr = getMultiDimensionalArray(s);

            var result = leetcode.ZigzagTraversal(arr);
        }
        #endregion

        #region 3418. Maximum Amount of Money Robot Can Earn
        [TestMethod]
        public void MaximumAmountTest()
        {
            string s = "[[0,1,-1],[1,-2,3],[2,-3,4]]";
            int[][] coins = getMultiDimensionalArray(s);
            var result = leetcode.MaximumAmount(coins);
            Assert.AreEqual(8, result);
        }
        #endregion
    }
}
