using Amazon2025;
using Common;

namespace Leetcode2025.Tests;

[TestClass]
public class Amazon2025Tests
{
    Solution solution;
    [TestInitialize]
    public void Initialize()
    {
        solution = new Solution();
    }


    [TestMethod]
    public void Test()
    {
    }

    #region 118. Pascal's Triangle

    [TestMethod]
    public void GenerateTest()
    {
        int numRows = 6;
        var k = solution.Generate(numRows);
    }
    #endregion


    #region 904. Fruit Into Baskets


    [TestMethod]
    public void TotalFruitTest()
    {
        int[] fruits = { 0, 1, 2, 2 };
        var k = solution.TotalFruit(fruits);
    }
    #endregion

    #region 2106. Maximum Fruits Harvested After at Most K Steps

    [TestMethod]
    public void MaxTotalFruitsTest()
    {
        string s = "[[2,8],[6,3],[8,6]]";
        int[][] arr = Helper.GetMultiDimensionalArrayBasedOnString(s);
        int startPos = 5;
        int k = 4;

        var t = solution.MaxTotalFruits(arr, startPos, k);
    }

    [TestMethod]
    public void MaxTotalFruitsTest1()
    {
        string s = "[[0,9],[4,1],[5,7],[6,2],[7,4],[10,9]]";
        int[][] arr = Helper.GetMultiDimensionalArrayBasedOnString(s);
        int startPos = 5;
        int k = 4;

        var t = solution.MaxTotalFruits(arr, startPos, k);
    }
    #endregion


    #region 2561. Rearranging Fruits

    [TestMethod]
    public void MinCostTest()
    {
        int[] basket1 = { 4, 2, 2, 2 };
        int[] basket2 = { 1, 4, 1, 2 };
        var k = solution.MinCost(basket1, basket2);
    }
    #endregion


    #region 3363. Find the Maximum Number of Fruits Collected
    [TestMethod]
    public void MaxCollectedFruitsTest()
    {
        string s = "[[1,2,3,4],[5,6,8,7],[9,10,11,12],[13,14,15,16]]";
        int[][] fruits = Helper.GetMultiDimensionalArrayBasedOnString(s);
        var k = solution.MaxCollectedFruits(fruits);
        Assert.AreEqual(100, k);
    }
    [TestMethod]
    public void MaxCollectedFruitsTest1()
    {
        string s = "[[1,1],[1,1]]";
        int[][] fruits = Helper.GetMultiDimensionalArrayBasedOnString(s);
        var k = solution.MaxCollectedFruits(fruits);
        Assert.AreEqual(4, k);
    }
    #endregion
    #region 3477. Fruits Into Baskets II

    [TestMethod]
    public void NumOfUnplacedFruitsTest()
    {
        int[] fruits1 = { 63,40,1 };
        int[] fruits2 = { 59,93,20 };
        var k = solution.NumOfUnplacedFruits(fruits1, fruits2);
        Assert.AreEqual(0, k);
    }

    [TestMethod]
    public void NumOfUnplacedFruitsTest2()
    {
        int[] fruits1 = { 4,2,5};
        int[] fruits2 = { 3,5,4 };
        var k = solution.NumOfUnplacedFruits(fruits1, fruits2);
        Assert.AreEqual(1, k);
    }

    [TestMethod]
    public void NumOfUnplacedFruitsTest1()
    {
        int[] fruits1 = { 3, 6, 1, 3, 6, 8, 3, 6, 1, 4, 3, 2, 1 };
        int[] fruits2 = { 6, 4, 7, 8, 4, 7, 9, 5, 1, 3, 4, 4, 1 };
        var k = solution.NumOfUnplacedFruits(fruits1, fruits2);
    }
    #endregion
}
