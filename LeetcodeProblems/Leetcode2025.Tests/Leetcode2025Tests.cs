namespace Leetcode2025.Tests
{
    [TestClass]
    public class Leetcode2025Tests
    {
        Leetcode2025 leetcode;
        [TestInitialize]
        public void TestInitialize()
        {
            this.leetcode = new Leetcode2025();
        }

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
            int[] nums = { 2,1 };

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
    }
}