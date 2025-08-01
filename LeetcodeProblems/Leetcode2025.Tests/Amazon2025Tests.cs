using Amazon2025;

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
}
