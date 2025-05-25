using Common;
using Meta2025;
using System.Diagnostics;

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
    public void LongestPalindromeTest1()
    {
        string[] words = { "lc", "cl", "gg", "gg", "gg", "gg", "gg", "gg", "gg", "gg" };
        var result = solution.LongestPalindrome(words);
        Assert.AreEqual(6, result);
    }

    [TestMethod]
    public void LongestPalindromeTest()
    {
        string[] words = { "lc", "cl", "gg" };
        var result = solution.LongestPalindrome(words);
        Assert.AreEqual(6, result);
    }

    [TestMethod]
    public void FindMedianSortedArraysTest7()
    {
        int[] arr2 = { 2, 3, 9, 19, 19 };
        int[] arr1 = { 2, 4, 5, 7, 13 };

        //int[] arr = arr1.Concat(arr2).ToArray();

        //Array.Sort(arr);

        //double expected = arr[12];

        //Array.Sort(arr1);
        //Array.Sort(arr2);

        double actual = solution.FindMedianSortedArrays(arr1, arr2);

        Assert.AreEqual(6, actual);
    }

    [TestMethod]
    public void FindMedianSortedArraysTest6()
    {
        int[] arr2 = { 2 };
        int[] arr1 = { 1, 3 };

        //int[] arr = arr1.Concat(arr2).ToArray();

        //Array.Sort(arr);

        //double expected = arr[12];

        //Array.Sort(arr1);
        //Array.Sort(arr2);

        double actual = solution.FindMedianSortedArrays(arr1, arr2);

        Assert.AreEqual(2.0000, actual);
    }

    [TestMethod]
    public void FindMedianSortedArraysTest5()
    {
        int[] arr2 = { 2 };
        int[] arr1 = { 1, 3 };

        //int[] arr = arr1.Concat(arr2).ToArray();

        //Array.Sort(arr);

        //double expected = arr[12];

        //Array.Sort(arr1);
        //Array.Sort(arr2);

        double actual = solution.FindMedianSortedArrays(arr1, arr2);

        Assert.AreEqual(2.0000, actual);
    }
    [TestMethod]
    public void FindMedianSortedArraysTest4()
    {
        int[] arr2 = { 11, 14, 18, 21, 27 };
        int[] arr1 = { };

        //int[] arr = arr1.Concat(arr2).ToArray();

        //Array.Sort(arr);

        //double expected = arr[12];

        //Array.Sort(arr1);
        //Array.Sort(arr2);

        double actual = solution.FindMedianSortedArrays(arr1, arr2);

        Assert.AreEqual(18, actual);
    }

    [TestMethod]
    public void FindMedianSortedArraysTest3()
    {
        int[] arr2 = { 11, 14, 18, 21, 27 };
        int[] arr1 = { 13, 16, 19, 21 };

        //int[] arr = arr1.Concat(arr2).ToArray();

        //Array.Sort(arr);

        //double expected = arr[12];

        //Array.Sort(arr1);
        //Array.Sort(arr2);

        double actual = solution.FindMedianSortedArrays(arr1, arr2);

        Assert.AreEqual(18, actual);
    }

    [TestMethod]
    public void FindMedianSortedArraysTest2()
    {
        int[] arr2 = Helper.GenerateArray(0, 20, 5);
        int[] arr1 = Helper.GenerateArray(0, 20, 5);

        int[] arr = arr1.Concat(arr2).ToArray();

        Array.Sort(arr);


        Array.Sort(arr1);
        Array.Sort(arr2);
        Debug.WriteLine(string.Join(' ', arr1));
        Debug.WriteLine(string.Join(' ', arr2));
        Debug.WriteLine(string.Join(' ', arr));


        double expected = (double)(arr[4] + arr[5]) / 2;
        Debug.WriteLine(expected);
        double actual = solution.FindMedianSortedArrays(arr1, arr2);
        Debug.WriteLine(actual);
        Assert.AreEqual(expected, actual);
    }
    [TestMethod]
    public void FindMedianSortedArraysTest1()
    {
        int[] arr2 = { 3, 4 };
        int[] arr1 = { 1, 2 };

        //int[] arr = arr1.Concat(arr2).ToArray();

        //Array.Sort(arr);

        //double expected = arr[12];

        //Array.Sort(arr1);
        //Array.Sort(arr2);

        double actual = solution.FindMedianSortedArrays(arr1, arr2);

        Assert.AreEqual(2.5000, actual);
    }

    [TestMethod]
    public void FindMedianSortedArraysTest()
    {
        int[] arr2 = Helper.GenerateArray(-50, 50, 5);
        int[] arr1 = Helper.GenerateArray(51, 80, 10);

        int[] arr = arr1.Concat(arr2).ToArray();

        Array.Sort(arr);

        double expected = arr[7];

        Array.Sort(arr1);
        Array.Sort(arr2);

        double actual = solution.FindMedianSortedArrays(arr1, arr2);

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void LengthOfLongestSubstringTest2()
    {
        string s = "abba";
        var result = solution.LengthOfLongestSubstring(s);
        Assert.AreEqual(2, result);
    }

    [TestMethod]
    public void LengthOfLongestSubstringTest1()
    {
        string s = "aab";
        var result = solution.LengthOfLongestSubstring(s);
        Assert.AreEqual(2, result);
    }

    [TestMethod]
    public void LengthOfLongestSubstringTest()
    {
        string s = "abcabcbb";
        var result = solution.LengthOfLongestSubstring(s);
        Assert.AreEqual(3, result);
    }

    [TestMethod]
    public void AddTwoNumbersTest()
    {
        int[] arr1 = Helper.GenerateArray(0, 9, 3);
        int[] arr2 = Helper.GenerateArray(0, 9, 3);
        ListNode list1 = Helper.GenerateListNode(arr1);
        ListNode list2 = Helper.GenerateListNode(arr2);

        ListNode list3 = solution.AddTwoNumbers(list1, list2);
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
        int[] a = Helper.GenerateArray(-100000, 1000000, 1000);

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
        int[] nums = { 0, 0, 3 };
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
        int[] nums = { 1, 2 };
        int[][] queries = getMultiDimensionalArray("[[1,1],[0,0],[1,1],[1,1],[0,1],[0,0]]");

        var actual = solution.MaxRemoval(nums, queries);
        Assert.AreEqual(4, actual);
    }

    [TestMethod]
    public void MaxRemovalTest3()
    {
        int[] nums = { 2, 0, 2 };
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
        int[][] queries = { new int[] { 1, 3, 2 }, new int[] { 0, 2, 1 } };

        Assert.IsTrue(solution.MinZeroArray(nums, queries).Equals(-1));
    }

    [TestMethod]
    public void MinZeroArrayTest3()
    {
        int[] nums = { 0, 10 };
        int[][] queries = getMultiDimensionalArray("[[0,1,2],[0,0,2],[0,1,2],[1,1,4],[0,1,3],[1,1,4],[0,1,2],[0,1,2],[0,1,2],[0,0,2],[1,1,2],[0,0,2],[0,0,3],[1,1,3],[0,0,5]]");

        Assert.IsTrue(solution.MinZeroArray(nums, queries).Equals(5));
    }
}
