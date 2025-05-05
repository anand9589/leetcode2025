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

        #region 763. Partition Labels

        [TestMethod]
        public void PartitionLabelsTest()
        {
            string s = "eccbbbbdec";
            var result = leetcode.PartitionLabels(s);
        }

        [TestMethod]
        public void PartitionLabelsTest1()
        {
            string s = "ababcbacadefegdehijhklij";
            var result = leetcode.PartitionLabels(s);
        }

        [TestMethod]
        public void PartitionLabelsTest2()
        {
            string s = "abc";
            var result = leetcode.PartitionLabels(s);
        }
        #endregion


        #region 790. Domino and Tromino Tiling

        [TestMethod]
        public void NumTilingsTest()
        {
            Assert.AreEqual(24, leetcode.NumTilings(5));
        }

        [TestMethod]
        public void NumTilingsTest1()
        {
            Assert.AreEqual(5, leetcode.NumTilings(3));
        }

        [TestMethod]
        public void NumTilingsTest2()
        {
            Assert.AreEqual(11, leetcode.NumTilings(4));
        }

        [TestMethod]
        public void NumTilingsTest3()
        {
            Assert.AreEqual(312342182, leetcode.NumTilings(30));
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

        #region 889. Construct Binary Tree from Preorder and Postorder Traversal
        [TestMethod]
        public void ConstructFromPrePostTest()
        {
            int[] preOrder = { 2, 4, 5, 1, 3 };
            int[] postOrder = { 1, 5, 3, 4, 2 };
            var result = leetcode.ConstructFromPrePost(preOrder, postOrder);
        }
        #endregion

        #region MaxSumText
        [TestMethod]
        public void MaxSumText()
        {
            string s = "[[1,2],[3,4]]";
            int[][] arr = getMultiDimensionalArray(s);
            int[] limit = { 1, 2 };
            int k = 2;
            var result = leetcode.MaxSum(arr, limit, k);
        }
        #endregion


        #region 1007. Minimum Domino Rotations For Equal Row

        [TestMethod]
        public void MinDominoRotationsTest()
        {
            int[] tops = { 2, 1, 2, 4, 2, 2 };
            int[] bottoms = { 5, 2, 6, 2, 3, 2 };

            var result = leetcode.MinDominoRotations(tops, bottoms);
            Assert.AreEqual(2, result);
        }
        #endregion

        #region 1028. Recover a Tree From Preorder Traversal

        [TestMethod]
        public void RecoverFromPreorderTest()
        {
            string traversal = "1-2--3--4-5--6--7";
            var result = leetcode.RecoverFromPreorder(traversal);
        }

        [TestMethod]
        public void RecoverFromPreorderTest1()
        {
            string traversal = "1-2--3---4-5--6---7";
            var result = leetcode.RecoverFromPreorder(traversal);
        }

        [TestMethod]
        public void RecoverFromPreorderTest2()
        {
            string traversal = "1-401--349---90--88";
            var result = leetcode.RecoverFromPreorder(traversal);
        }
        #endregion

        #region 1261. Find Elements in a Contaminated Binary Tree

        [TestMethod]
        public void FindElementsTest()
        {
            FindElements findElements = new FindElements(
                new TreeNode(-1,
                    null,
                    new TreeNode(-1, new TreeNode(-1, new TreeNode(-1)))));

            findElements.Find(2);
            findElements.Find(3);
            findElements.Find(4);
            findElements.Find(5);
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
            var res = leetcode.RemoveOccurrences(s, part);
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

        #region 1976. Number of Ways to Arrive at Destination
        [TestMethod]
        public void CountPathsTest()
        {
            int n = 7;
            int[][] roads = getMultiDimensionalArray("[[0,6,7],[0,1,2],[1,2,3],[1,3,3],[6,3,3],[3,5,1],[6,5,1],[2,5,1],[0,4,5],[4,6,2]]");
            var result= leetcode.CountPaths(n, roads);
            Assert.AreEqual(4, result);
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


        #region 2071. Maximum Number of Tasks You Can Assign

        [TestMethod]
        public void MaxTaskAssignTest()
        {
            int[] tasks = { 5, 9, 8, 5, 9 }; //9 9 8 5 5
            int[] workers = { 1, 6, 4, 2, 6 };//6 6 4 2 1
            int pills = 1;
            int strength = 5;

            var result = leetcode.MaxTaskAssign(tasks, workers, pills, strength);
            Assert.AreEqual(3, result);
        }
        #endregion
        #region 2140. Solving Questions With Brainpower

        [TestMethod]
        public void MostPointsTest()
        {
            int[][] questions = getMultiDimensionalArray("[[3,2],[4,3],[4,4],[2,5]]");
            var result = leetcode.MostPoints(questions);
            Assert.AreEqual(5, result);
        } 
        #endregion

        #region 2226. Maximum Candies Allocated to K Children

        [TestMethod]
        public void MaximumCandiesTest()
        {
            int[] candies = { 5, 8, 6 };
            long k = 3;
            var result = leetcode.MaximumCandies(candies, k);
            Assert.AreEqual(5, result);
        }


        [TestMethod]
        public void MaximumCandiesTest1()
        {
            int[] candies = { 2, 5 };
            long k = 11;
            var result = leetcode.MaximumCandies(candies, k);
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void MaximumCandiesTest2()
        {
            int[] candies = { 5, 8, 6 };
            long k = 4;
            var result = leetcode.MaximumCandies(candies, k);
            Assert.AreEqual(4, result);
        }
        #endregion

        #region 2338. Count the Number of Ideal Arrays
        [TestMethod]
        public void IdealArraysTest()
        {
            int n = 2;
            int maxValue = 5;
            var result = leetcode.IdealArrays(n, maxValue);
            Assert.AreEqual(10, result);
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

        #region 2379. Minimum Recolors to Get K Consecutive Black Blocks

        [TestMethod]
        public void MinimumRecolorsTest()
        {
            string s = "WBWBBBW";
            int k = 2;
            var result = leetcode.MinimumRecolors(s, k);
            Assert.AreEqual(result, k);
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

        #region 2401. Longest Nice Subarray

        [TestMethod]
        public void LongestNiceSubarrayTest()
        {
            int[] nums = { 135745088, 609245787, 16, 2048, 2097152 };
            var res = leetcode.LongestNiceSubarray(nums);
            Assert.AreEqual(3,res);
        }

        [TestMethod]
        public void LongestNiceSubarrayTest1()
        {
            int[] nums = { 84139415, 693324769, 614626365, 497710833, 615598711, 264, 65552, 50331652, 1, 1048576, 16384, 544, 270532608, 151813349, 221976871, 678178917, 845710321, 751376227, 331656525, 739558112, 267703680 };
            var res = leetcode.LongestNiceSubarray(nums);
            Assert.AreEqual(8, res);
        }
        #endregion


        #region 2503. Maximum Number of Points From Grid Queries


        [TestMethod]
        public void MaxPointsTest()
        {
            int[][] grid = getMultiDimensionalArray("[1,2,3],[2,5,7],[3,5,1]]");
            int[] queries = { 5, 6, 2 };
            var result = leetcode.MaxPoints(grid, queries);
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

        #region 2460. Apply Operations to an Array

        [TestMethod]
        public void ApplyOperationsTest()
        {
            int[] nums = { 1, 2, 2, 2, 2, 1, 1, 0 };
            var result = leetcode.ApplyOperations(nums);
        }

        [TestMethod]
        public void ApplyOperationsTest1()
        {
            int[] nums = { 0, 1, 0, 1 };
            var result = leetcode.ApplyOperations(nums);
        }
        #endregion

        #region 2467. Most Profitable Path in a Tree


        [TestMethod]
        public void MostProfitablePathTest()
        {
            string s = "[[0,1],[1,2],[1,3],[3,4]]";
            int[][] edges = getMultiDimensionalArray(s);
            int bob = 3;
            int[] amount = { -2, 4, 2, -4, 6 };

            var result = leetcode.MostProfitablePath(edges, bob, amount);
        }


        [TestMethod]
        public void MostProfitablePathTest1()
        {
            string s = "[[0,1]]";
            int[][] edges = getMultiDimensionalArray(s);
            int bob = 1;
            int[] amount = { -7280, 2350 };

            var result = leetcode.MostProfitablePath(edges, bob, amount);
        }


        [TestMethod]
        public void MostProfitablePathTest2()
        {
            string s = "[[0,2],[0,4],[1,3],[1,2]]";
            int[][] edges = getMultiDimensionalArray(s);
            int bob = 1;
            int[] amount = { 3958, -9854, -8334, -9388, 3410 };

            var result = leetcode.MostProfitablePath(edges, bob, amount);
        }
        #endregion


        #region 2551. Put Marbles in Bags

        [TestMethod]
        public void PutMarblesTest()
        {
            int[] weights = { 1, 3, 5, 1 };
            int k = 2;
            var result = leetcode.PutMarbles(weights, k);
            Assert.AreEqual(4, result);
        }
        #endregion

        #region 2529. Maximum Count of Positive Integer and Negative Integer


        [TestMethod]
        public void MaximumCountTest()
        {
            int[] nums = { -1996, -1996, -1996, -1995, -1994, -1993, -1993, -1992, -1990, -1990, -1987, -1986, -1983, -1983, -1981, -1981, -1981, -1980, -1980, -1979, -1977, -1971, -1971, -1969, -1969, -1969, -1968, -1966, -1965, -1965, -1964, -1964, -1962, -1962, -1960, -1958, -1955, -1953, -1952, -1945, -1939, -1938, -1931, -1931, -1927, -1926, -1922, -1920, -1920, -1919, -1917, -1914, -1913, -1912, -1911, -1909, -1906, -1905, -1905, -1905, -1903, -1903, -1902, -1899, -1896, -1895, -1893, -1893, -1893, -1891, -1890, -1890, -1884, -1883, -1882, -1872, -1868, -1865, -1855, -1854, -1854, -1854, -1850, -1849, -1842, -1840, -1840, -1839, -1836, -1834, -1828, -1827, -1826, -1825, -1823, -1822, -1821, -1820, -1815, -1804, -1804, -1803, -1803, -1803, -1801, -1797, -1796, -1794, -1793, -1793, -1790, -1786, -1783, -1780, -1774, -1774, -1774, -1770, -1766, -1764, -1763, -1763, -1762, -1758, -1757, -1757, -1756, -1753, -1746, -1745, -1740, -1731, -1721, -1720, -1717, -1716, -1714, -1713, -1712, -1711, -1711, -1709, -1704, -1694, -1694, -1692, -1691, -1690, -1690, -1690, -1687, -1686, -1684, -1682, -1680, -1679, -1678, -1675, -1674, -1672, -1669, -1664, -1663, -1662, -1661, -1658, -1652, -1648, -1646, -1645, -1644, -1642, -1642, -1640, -1636, -1635, -1630, -1629, -1628, -1624, -1623, -1622, -1621, -1620, -1620, -1619, -1619, -1619, -1618, -1617, -1613, -1611, -1608, -1607, -1607, -1603, -1603, -1601, -1601, -1596, -1588, -1587, -1583, -1582, -1582, -1581, -1580, -1578, -1576, -1576, -1576, -1575, -1572, -1570, -1567, -1566, -1566, -1566, -1563, -1561, -1559, -1552, -1552, -1546, -1545, -1543, -1543, -1540, -1539, -1539, -1538, -1536, -1535, -1534, -1532, -1527, -1527, -1525, -1523, -1523, -1517, -1517, -1517, -1516, -1515, -1512, -1511, -1510, -1507, -1505, -1503, -1501, -1500, -1496, -1496, -1495, -1495, -1494, -1491, -1489, -1486, -1486, -1486, -1484, -1483, -1480, -1479, -1477, -1476, -1475, -1462, -1459, -1451, -1450, -1450, -1447, -1447, -1445, -1444, -1443, -1442, -1440, -1439, -1437, -1433, -1433, -1427, -1426, -1421, -1419, -1419, -1417, -1417, -1416, -1405, -1399, -1391, -1388, -1386, -1384, -1384, -1384, -1380, -1379, -1377, -1376, -1375, -1374, -1373, -1373, -1371, -1369, -1368, -1367, -1366, -1365, -1365, -1349, -1349, -1347, -1345, -1344, -1343, -1342, -1341, -1341, -1338, -1337, -1337, -1332, -1330, -1328, -1325, -1324, -1318, -1318, -1316, -1313, -1309, -1303, -1296, -1296, -1295, -1295, -1292, -1287, -1284, -1282, -1281, -1279, -1275, -1275, -1272, -1270, -1267, -1257, -1257, -1254, -1249, -1241, -1240, -1239, -1238, -1227, -1223, -1223, -1221, -1221, -1220, -1220, -1218, -1215, -1210, -1210, -1209, -1207, -1206, -1203, -1201, -1199, -1199, -1194, -1188, -1185, -1174, -1172, -1172, -1171, -1171, -1167, -1163, -1156, -1154, -1153, -1148, -1147, -1147, -1143, -1143, -1140, -1139, -1137, -1137, -1132, -1131, -1130, -1126, -1125, -1125, -1121, -1118, -1114, -1112, -1112, -1112, -1111, -1105, -1102, -1099, -1097, -1088, -1084, -1083, -1082, -1081, -1074, -1073, -1072, -1072, -1071, -1071, -1068, -1067, -1058, -1056, -1055, -1055, -1053, -1052, -1052, -1048, -1048, -1044, -1043, -1041, -1039, -1036, -1031, -1030, -1030, -1020, -1019, -1017, -1014, -1014, -1014, -1010, -1006, -1005, -1003, -1003, -999, -998, -995, -995, -994, -994, -993, -993, -991, -991, -989, -986, -984, -983, -982, -982, -980, -980, -978, -972, -968, -968, -959, -955, -955, -953, -950, -949, -949, -949, -947, -945, -942, -936, -931, -927, -926, -923, -922, -922, -921, -921, -918, -916, -913, -911, -909, -908, -908, -905, -904, -901, -901, -894, -891, -886, -882, -882, -881, -871, -867, -865, -864, -863, -863, -863, -862, -862, -858, -851, -851, -851, -849, -849, -842, -840, -839, -832, -824, -822, -820, -818, -818, -817, -816, -814, -814, -811, -810, -809, -805, -799, -798, -797, -796, -795, -793, -789, -784, -784, -781, -776, -776, -773, -769, -766, -762, -761, -761, -760, -760, -759, -758, -758, -756, -756, -756, -755, -755, -753, -751, -751, -751, -749, -738, -738, -736, -736, -736, -734, -728, -724, -722, -719, -718, -717, -715, -714, -713, -711, -706, -698, -697, -692, -690, -688, -688, -687, -686, -686, -682, -680, -679, -678, -673, -672, -667, -665, -664, -656, -656, -650, -643, -643, -643, -641, -641, -638, -635, -634, -631, -626, -625, -623, -622, -621, -617, -617, -610, -610, -605, -600, -600, -594, -590, -586, -586, -582, -577, -574, -572, -570, -570, -566, -564, -562, -562, -561, -558, -555, -553, -552, -551, -550, -545, -543, -536, -535, -532, -522, -520, -518, -516, -516, -514, -514, -513, -511, -508, -507, -507, -507, -505, -504, -502, -492, -491, -491, -488, -485, -476, -464, -459, -459, -456, -455, -451, -448, -445, -437, -437, -437, -430, -430, -430, -428, -428, -426, -426, -424, -424, -418, -418, -417, -417, -413, -412, -411, -411, -410, -410, -405, -404, -402, -401, -400, -394, -394, -393, -392, -389, -386, -383, -380, -380, -378, -371, -371, -369, -366, -366, -365, -359, -358, -354, -347, -347, -346, -345, -334, -334, -333, -332, -331, -330, -329, -329, -329, -328, -327, -325, -323, -318, -316, -315, -313, -312, -311, -310, -309, -308, -304, -299, -296, -291, -287, -283, -283, -280, -279, -275, -270, -266, -264, -262, -261, -261, -258, -256, -254, -253, -249, -245, -242, -240, -238, -236, -233, -230, -227, -227, -221, -218, -213, -209, -205, -200, -196, -196, -193, -189, -182, -180, -179, -172, -172, -168, -165, -162, -157, -156, -156, -153, -150, -148, -146, -142, -142, -141, -140, -140, -140, -138, -135, -131, -130, -127, -124, -123, -117, -116, -111, -107, -106, -105, -94, -92, -89, -88, -88, -85, -85, -83, -81, -80, -79, -78, -77, -74, -73, -65, -63, -62, -60, -58, -58, -55, -51, -48, -46, -43, -43, -42, -33, -31, -29, -22, -21, -17, -16, -16, -12, -10, -7, -1, 0, 0, 1, 3, 4, 4, 9, 12, 12, 16, 18, 21, 21, 26, 29, 30, 32, 34, 35, 35, 35, 35, 37, 40, 42, 44, 47, 47, 48, 51, 51, 52, 59, 63, 67, 68, 68, 72, 73, 74, 74, 80, 81, 82, 83, 84, 93, 94, 103, 108, 108, 115, 117, 117, 117, 120, 120, 124, 125, 126, 127, 127, 133, 134, 135, 136, 136, 144, 148, 150, 151, 156, 156, 164, 178, 178, 179, 185, 187, 187, 189, 191, 192, 194, 199, 199, 207, 208, 211, 217, 219, 220, 221, 232, 238, 242, 250, 251, 255, 256, 256, 257, 260, 262, 265, 266, 266, 269, 273, 275, 281, 282, 286, 286, 295, 299, 303, 303, 304, 305, 307, 308, 311, 314, 314, 316, 316, 318, 319, 321, 321, 322, 322, 324, 326, 327, 327, 332, 334, 335, 337, 344, 352, 359, 361, 363, 365, 368, 368, 368, 369, 370, 370, 373, 379, 383, 384, 388, 388, 391, 399, 399, 400, 401, 402, 402, 404, 404, 407, 409, 409, 413, 413, 416, 420, 421, 425, 426, 426, 427, 436, 438, 439, 442, 449, 452, 470, 473, 476, 477, 479, 487, 488, 491, 493, 495, 496, 497, 497, 498, 499, 499, 501, 507, 514, 519, 519, 521, 523, 525, 529, 542, 545, 549, 552, 553, 555, 556, 556, 556, 563, 563, 563, 564, 565, 566, 568, 568, 568, 572, 573, 576, 576, 577, 581, 581, 582, 587, 587, 589, 589, 594, 595, 604, 607, 610, 612, 613, 614, 617, 620, 622, 622, 624, 625, 628, 631, 633, 633, 635, 639, 644, 646, 647, 648, 649, 651, 653, 656, 659, 660, 662, 667, 670, 672, 673, 676, 677, 678, 679, 685, 685, 685, 687, 690, 692, 693, 694, 694, 695, 696, 702, 702, 702, 703, 703, 704, 707, 709, 709, 711, 711, 711, 714, 714, 714, 719, 719, 720, 723, 724, 726, 728, 730, 731, 733, 733, 737, 741, 742, 750, 751, 753, 754, 755, 756, 761, 762, 763, 764, 765, 765, 768, 771, 773, 774, 775, 777, 780, 784, 786, 787, 787, 788, 789, 790, 796, 796, 797, 804, 807, 812, 812, 815, 817, 818, 820, 820, 821, 826, 833, 842, 842, 848, 852, 854, 860, 867, 869, 870, 870, 871, 872, 877, 879, 882, 883, 890, 891, 892, 894, 899, 901, 901, 905, 906, 907, 909, 914, 916, 920, 921, 922, 923, 924, 924, 927, 928, 929, 929, 932, 932, 933, 934, 935, 937, 938, 945, 948, 950, 953, 953, 958, 962, 965, 966, 966, 966, 968, 968, 971, 971, 975, 979, 980, 982, 983, 988, 990, 991, 992, 992, 1002, 1003, 1003, 1004, 1011, 1011, 1011, 1016, 1018, 1019, 1022, 1026, 1026, 1030, 1037, 1037, 1040, 1049, 1050, 1050, 1051, 1051, 1053, 1053, 1057, 1058, 1067, 1067, 1083, 1090, 1094, 1103, 1104, 1105, 1105, 1109, 1111, 1115, 1115, 1116, 1119, 1126, 1130, 1134, 1139, 1140, 1142, 1143, 1148, 1154, 1155, 1157, 1158, 1158, 1162, 1163, 1164, 1164, 1165, 1170, 1170, 1174, 1177, 1179, 1181, 1181, 1182, 1184, 1185, 1190, 1191, 1192, 1194, 1194, 1194, 1194, 1198, 1200, 1200, 1201, 1202, 1204, 1206, 1206, 1206, 1208, 1210, 1212, 1214, 1217, 1220, 1223, 1224, 1226, 1230, 1230, 1234, 1235, 1237, 1238, 1238, 1241, 1245, 1247, 1248, 1248, 1248, 1251, 1251, 1255, 1255, 1257, 1263, 1263, 1269, 1270, 1272, 1275, 1276, 1280, 1280, 1281, 1288, 1291, 1292, 1294, 1298, 1299, 1303, 1303, 1306, 1307, 1310, 1310, 1311, 1313, 1313, 1317, 1324, 1325, 1327, 1328, 1329, 1333, 1334, 1334, 1334, 1335, 1335, 1335, 1338, 1338, 1341, 1342, 1344, 1348, 1349, 1356, 1357, 1357, 1361, 1363, 1364, 1370, 1373, 1374, 1376, 1377, 1377, 1378, 1382, 1383, 1385, 1392, 1400, 1401, 1405, 1409, 1411, 1414, 1415, 1417, 1418, 1418, 1422, 1425, 1425, 1426, 1426, 1426, 1427, 1428, 1430, 1430, 1433, 1438, 1439, 1441, 1443, 1445, 1454, 1455, 1455, 1457, 1458, 1463, 1464, 1465, 1468, 1470, 1475, 1477, 1477, 1478, 1478, 1478, 1479, 1479, 1480, 1480, 1482, 1483, 1484, 1489, 1490, 1491, 1493, 1493, 1495, 1497, 1501, 1502, 1506, 1508, 1510, 1516, 1517, 1518, 1519, 1519, 1520, 1520, 1520, 1520, 1522, 1525, 1526, 1529, 1530, 1534, 1540, 1540, 1544, 1545, 1545, 1546, 1547, 1548, 1554, 1556, 1557, 1558, 1560, 1561, 1568, 1573, 1574, 1574, 1578, 1578, 1578, 1579, 1580, 1583, 1584, 1584, 1586, 1587, 1589, 1597, 1599, 1600, 1601, 1603, 1607, 1609, 1610, 1613, 1614, 1617, 1618, 1619, 1622, 1624, 1627, 1627, 1628, 1631, 1632, 1636, 1638, 1642, 1645, 1646, 1647, 1652, 1653, 1660, 1660, 1662, 1664, 1667, 1672, 1676, 1677, 1677, 1680, 1685, 1687, 1688, 1690, 1693, 1694, 1694, 1700, 1704, 1704, 1705, 1708, 1708, 1709, 1710, 1710, 1711, 1718, 1723, 1730, 1731, 1731, 1732, 1734, 1734, 1735, 1736, 1737, 1739, 1740, 1743, 1744, 1745, 1750, 1750, 1752, 1756, 1757, 1759, 1766, 1769, 1769, 1771, 1773, 1777, 1778, 1780, 1780, 1780, 1782, 1787, 1787, 1790, 1793, 1794, 1799, 1800, 1802, 1803, 1806, 1808, 1812, 1813, 1813, 1814, 1815, 1816, 1817, 1819, 1822, 1824, 1827, 1830, 1831, 1832, 1832, 1835, 1836, 1837, 1844, 1846, 1849, 1849, 1850, 1851, 1853, 1854, 1856, 1861, 1862, 1866, 1867, 1869, 1871, 1872, 1877, 1880, 1880, 1881, 1888, 1888, 1894, 1899, 1899, 1901, 1903, 1904, 1906, 1908, 1911, 1915, 1915, 1916, 1916, 1920, 1922, 1930, 1930, 1933, 1939, 1939, 1942, 1946, 1947, 1948, 1951, 1953, 1957, 1957, 1961, 1962, 1962, 1963, 1965, 1970, 1974, 1975, 1976, 1981, 1983, 1988, 1989, 1990, 1991, 1991, 1992, 1998, 1998, 1998, 1998 };
            var res = leetcode.MaximumCount(nums);
            Assert.AreEqual(897, res);
        }
        [TestMethod]
        public void MaximumCountTest1()
        {
            int[] nums = { -2, -1, -1, 1, 2, 3 };
            var res = leetcode.MaximumCount(nums);
            Assert.AreEqual(3, res);
        }
        [TestMethod]
        public void MaximumCountTest2()
        {
            int[] nums = { -3, -2, -1, 0, 0, 1, 2 };
            var res = leetcode.MaximumCount(nums);
            Assert.AreEqual(3, res);
        }
        [TestMethod]
        public void MaximumCountTest3()
        {
            int[] nums = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            var res = leetcode.MaximumCount(nums);
            Assert.AreEqual(0, res);
        }
        [TestMethod]
        public void MaximumCountTest4()
        {
            int[] nums = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };
            var res = leetcode.MaximumCount(nums);
            Assert.AreEqual(2000, res);
        }
        #endregion

        #region 2594. Minimum Time to Repair Cars


        [TestMethod]
        public void RepairCarsTest()
        {
            int[] ranks = { 4, 2, 3, 1 };
            int cars = 10;
            var result = leetcode.RepairCars(ranks, cars);
            Assert.AreEqual(16, result);
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


        #region 2799. Count Complete Subarrays in an Array


        [TestMethod]
        public void CountCompleteSubarraysTest()
        {
            int[] nums = { 1, 3, 1, 2, 2 };
            var result = leetcode.CountCompleteSubarrays    (nums);
            Assert.AreEqual(4, result);
        }

        [TestMethod]
        public void CountCompleteSubarraysTest1()
        {
            int[] nums = { 5,5,5,5 };
            var result = leetcode.CountCompleteSubarrays(nums);
            Assert.AreEqual(10, result);
        }
        #endregion

        #region 2873. Maximum Value of an Ordered Triplet I


        [TestMethod]
        public void MaximumTripletValueTest()
        {
            int[] nums = { 1000000, 1, 1000000 };
            var result = leetcode.MaximumTripletValue(nums);
            Assert.AreEqual(result, 999999000000);
        }


        [TestMethod]
        public void MaximumTripletValueTest1()
        {
            int[] nums = { 8, 6, 3, 13, 2, 12, 19, 5, 19, 6, 10, 11, 9 };
            var result = leetcode.MaximumTripletValue(nums);
            Assert.AreEqual(result, 266);
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
            Assert.AreEqual(2, result);
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

        #region 3169. Count Days Without Meetings


        [TestMethod]
        public void CountDaysTest()
        {
            int days = 5;
            int[][] meetings = getMultiDimensionalArray("[[2,4],[1,3]]");
            var result = leetcode.CountDays(days, meetings);
            Assert.AreEqual(1, result);
        }
        #endregion

        #region 3306. Count of Substrings Containing Every Vowel and K Consonants II


        [TestMethod]
        public void CountOfSubstringsTest()
        {
            string word = "ieaouqqieaouqq";
            int k = 1;
            var res = leetcode.CountOfSubstrings(word, k);
            Assert.AreEqual(3, res);
        }


        [TestMethod]
        public void CountOfSubstringsTest1()
        {
            string word = "iqeaouqi";
            int k = 2;
            var res = leetcode.CountOfSubstrings(word, k);
            Assert.AreEqual(3, res);
        }
        #endregion

        #region 3356. Zero Array Transformation II

        [TestMethod]
        public void MinZeroArrayTest()
        {
            string s = "[[0,2,1],[0,2,1],[1,1,3]]";
            int[][] queries = getMultiDimensionalArray(s);
            int[] nums = { 2, 0, 2 };
            var res = leetcode.MinZeroArray(nums, queries);
            Assert.AreEqual(2, res);
        }

        [TestMethod]
        public void MinZeroArrayTest1()
        {
            string s = "[[0,0,1],[0,0,1],[0,0,1],[0,0,1],[0,2,1],[0,2,1],[1,1,3]]";
            int[][] queries = getMultiDimensionalArray(s);
            int[] nums = { 2, 0, 2 };
            var res = leetcode.MinZeroArray(nums, queries);
            Assert.AreEqual(6, res);
        }
        #endregion


        #region 3396. Minimum Number of Operations to Make Elements in Array Distinct


        [TestMethod]
        public void MinimumOperationsTest()
        {
            int[] nums = { 1, 2, 3, 4, 2, 3, 3, 5, 7 };
            var result = leetcode.MinimumOperations(nums);
            Assert.AreEqual(2, result);
        }


        [TestMethod]
        public void MinimumOperationsTest1()
        {
            int[] nums = { 4, 5, 6, 4, 4 };
            var result = leetcode.MinimumOperations(nums);
            Assert.AreEqual(2, result);
        }


        [TestMethod]
        public void MinimumOperationsTest2()
        {
            int[] nums = { 10, 12, 12, 6, 6 };
            var result = leetcode.MinimumOperations(nums);
            Assert.AreEqual(2, result);
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
