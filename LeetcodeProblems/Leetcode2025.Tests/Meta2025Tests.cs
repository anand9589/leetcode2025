using Common;
using Meta2025;

namespace Leetcode2025.Tests;

[TestClass]
public class Meta2025Tests
{
    Solution solution;
    [TestInitialize]
    public void Initialize()
    {
        solution = new Solution();
    }


    #region Input Read
    private int[][] getMultiDimensionalArray(string str)
    {
        return Helper.GetMultiDimensionalArrayBasedOnString(str);
    }
    #endregion

    [TestMethod]
    public void Test()
    {
    }
    [TestMethod]
    public void AddTwoNumbersTest()
    {
        int[] arr1 = Helper.GenerateArray(0, 9, 3);
        int[] arr2 = Helper.GenerateArray(0, 9, 3);
        ListNode list1 = Helper.GenerateListNode(arr1);
        ListNode list2 = Helper.GenerateListNode(arr2);

        ListNode list3 = solution.AddTwoNumbers(list1,list2);
    }

    [TestMethod]
    public void ListNodeTest()
    {
        int[] arr = Helper.GenerateArray(0, 9, 5);
        ListNode node = Helper.GenerateListNode(arr);
    }


    [TestMethod]
    public void BinarySearchTest()
    {
        int[] arr = Helper.GenerateArray();
        int key = arr[5000];
        //Random random = new Random();
        //int key = random.Next(int.MinValue, int.MaxValue);

        Array.Sort(arr);


        int x = Array.BinarySearch(arr, key);
        
        if (x < 0)
        {
            Assert.IsFalse(solution.BinarySearch(arr, key));
        }
        else
        {
            Assert.IsTrue(solution.BinarySearch(arr, key));
        }
       
    }
    [TestMethod]
    public void HeapSortTest()
    {
        int[] a = Helper.GenerateArray(-100000, 1000000, 1000);

        Assert.IsFalse(Helper.IsSortedArray(a));
        solution.HeapSort(a);

        Assert.IsTrue(Helper.IsSortedArray(a));
    }

    [TestMethod]
    public void QuickSortTest()
    {
        int[] a = Helper.GenerateArray(-100000, 1000000, 1000);

        Assert.IsFalse(Helper.IsSortedArray(a));
        solution.QuickSort(a);

        Assert.IsTrue(Helper.IsSortedArray(a));
    }

    [TestMethod]
    public void MergeSortTest()
    {
        int[] a = Helper.GenerateArray(-100000, 1000000, 1000);

        Assert.IsFalse(Helper.IsSortedArray(a));
        solution.MergeSort(a);

        Assert.IsTrue(Helper.IsSortedArray(a));
    }

    [TestMethod]
    public void InsertionSortTest()
    {
        int[] a = Helper.GenerateArray(-100000, 1000000, 1000);

        Assert.IsFalse(Helper.IsSortedArray(a));
        solution.InsertionSort(a);

        Assert.IsTrue(Helper.IsSortedArray(a));
    }

    [TestMethod]
    public void BubbleSortTest()
    {
        int[] a = Helper.GenerateArray(-100000, 1000000, 1000);

        Assert.IsFalse(Helper.IsSortedArray(a));
        solution.BubbleSort(a);

        Assert.IsTrue(Helper.IsSortedArray(a));
    }

    [TestMethod]
    public void SelectionSortTest()
    {
        int[] a = Helper.GenerateArray(-100000,1000000,1000);

        Assert.IsFalse(Helper.IsSortedArray(a));
        solution.SelectionSort(a);

        Assert.IsTrue(Helper.IsSortedArray(a));
    }

    [TestMethod]
    public void MaxRemovalTest()
    {
        int[] nums = { 4, 5 };
        int[][] queries = getMultiDimensionalArray("[[1,1],[0,1],[0,1],[0,1],[1,1],[0,0]]");

        var actual = solution.MaxRemoval(nums, queries);
        Assert.AreEqual(0, actual);
    }

    [TestMethod]
    public void MaxRemovalTest6()
    {
        int[] nums = { 0,0,3 };
        int[][] queries = getMultiDimensionalArray("[[0,2],[1,1],[0,0],[0,0]]");

        var actual = solution.MaxRemoval(nums, queries);
        Assert.AreEqual(-1, actual);
    }

    [TestMethod]
    public void MaxRemovalTest5()
    {
        int[] nums = { 0, 0, 1, 1, 0 };
        int[][] queries = getMultiDimensionalArray("[[3,4],[0,2],[2,3]]");

        var actual = solution.MaxRemoval(nums, queries);
        Assert.AreEqual(2, actual);
    }

    [TestMethod]
    public void MaxRemovalTest4()
    {
        int[] nums = { 1,2 };
        int[][] queries = getMultiDimensionalArray("[[1,1],[0,0],[1,1],[1,1],[0,1],[0,0]]");

        var actual = solution.MaxRemoval(nums, queries);
        Assert.AreEqual(4, actual);
    }

    [TestMethod]
    public void MaxRemovalTest3()
    {
        int[] nums = {2,0,2 };
        int[][] queries = getMultiDimensionalArray("[[0,2],[0,2],[1,1]]");

        var actual = solution.MaxRemoval(nums, queries);
        Assert.AreEqual(1, actual);
    }

    [TestMethod]
    public void MaxRemovalTest1()
    {
        int[] nums = { 1, 1, 1, 1 };
        int[][] queries = getMultiDimensionalArray("[[1,3],[0,2],[1,3],[1,2]]");

        var actual = solution.MaxRemoval(nums, queries);
        Assert.AreEqual(2, actual);
    }

    [TestMethod]
    public void MaxRemovalTest2()
    {
        int[] nums = { 1, 2, 3, 4 };
        int[][] queries = getMultiDimensionalArray("[[0,3]]");

        var actual = solution.MaxRemoval(nums, queries);
        Assert.AreEqual(-1, actual);
    }

    [TestMethod]
    public void IsZeroArrayTest1()
    {
        int[] nums = { 1, 0, 1 };
        int[][] queries = { new int[] { 0, 2 } };

        Assert.IsTrue(solution.IsZeroArray(nums, queries));
    }

    [TestMethod]
    public void MinZeroArrayTest1()
    {
        int[] nums = { 2, 0, 2 };
        int[][] queries = { new int[] { 0, 2, 1 }, new int[] { 0, 2, 1 }, new int[] { 1, 1, 3 } };

        Assert.IsTrue(solution.MinZeroArray(nums, queries).Equals(2));
    }

    [TestMethod]
    public void MinZeroArrayTest2()
    {
        int[] nums = { 4, 3, 2, 1 };
        int[][] queries = { new int[] { 1,3,2 }, new int[] { 0, 2, 1 } };

        Assert.IsTrue(solution.MinZeroArray(nums, queries).Equals(-1));
    }

    [TestMethod]
    public void MinZeroArrayTest3()
    {
        int[] nums = { 0,10 };
        int[][] queries = getMultiDimensionalArray("[[0,1,2],[0,0,2],[0,1,2],[1,1,4],[0,1,3],[1,1,4],[0,1,2],[0,1,2],[0,1,2],[0,0,2],[1,1,2],[0,0,2],[0,0,3],[1,1,3],[0,0,5]]");

        Assert.IsTrue(solution.MinZeroArray(nums, queries).Equals(5));
    }
}
