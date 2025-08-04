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
        int[] basket1 = {4,2,2,2};
        int[] basket2 = { 1, 4, 1, 2 };
        var k = solution.MinCost(basket1, basket2);
    }
    #endregion
}
