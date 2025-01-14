﻿namespace Leetcode2025.Tests
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
            var result =leetcode.ShortestPalindrome(s);
            Assert.AreEqual("dcbabcd", result);
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

        #region 1930. Unique Length-3 Palindromic Subsequences
        [TestMethod]
        public void CountPalindromicSubsequenceTest()
        {
            string s = "after";
            var result = leetcode.CountPalindromicSubsequence(s);
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
            Assert.AreEqual("kme",result);
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
    }
}
