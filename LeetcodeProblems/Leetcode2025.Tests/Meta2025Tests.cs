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
    public void RecoverTreeTest()
    {
        TreeNode treeNode = new TreeNode(1,
                                        new TreeNode(3, null,
                                        new TreeNode(2)));

        solution.RecoverTree(treeNode);
    }
    [TestMethod]
    public void NumTreesTest()
    {
        int n = 3;
        var res = solution.NumTrees(n);
        Assert.AreEqual(5, res);
    }
    [TestMethod]
    public void ReverseBetweenTest()
    {
        int[] arr = {1,2,3,4,5};
        ListNode node = Helper.GenerateListNode(arr);
        var k = solution.ReverseBetween(node, 2, 4);
    }

    [TestMethod]
    public void SubsetsWithDupTest()
    {
        int[] arr = {1, 2, 3, 4};
        var l = solution.SubsetsWithDup(arr);
    }

    [TestMethod]
    public void MergeTest3()
    {
        int[] arr1 = { 4, 0, 0, 0, 0, 0 };
        int m = 1;
        int[] arr2 = { 1, 2, 3, 5, 6 };
        int n = 5;
        solution.Merge(arr1, m, arr2, n);

        int[] arr3 = { 1, 2, 3, 4, 5, 6 };
        CollectionAssert.AreEqual(arr1, arr3);
    }

    [TestMethod]
    public void MergeTest2()
    {
        int[] arr1 = { 1, 2, 3, 0, 0, 0 };
        int m = 3;
        int[] arr2 = { 2, 5, 6 };
        int n = 3;
        solution.Merge(arr1, m, arr2, n);
        int[] arr3 = { 1, 2, 2, 3, 5, 6 };
        CollectionAssert.AreEqual(arr1, arr3);
    }

    [TestMethod]
    public void MergeTest1()
    {
        int[] arr1 = { 2, 0 };
        int m = 1;
        int[] arr2 = { 1 };
        int n = 1;
        solution.Merge(arr1, m, arr2, n);
        int[] arr3 = { 1, 2 };
        CollectionAssert.AreEqual(arr1, arr3);
    }

    [TestMethod]
    public void MergeTest()
    {
        int[] arr1 = { 0 };
        int m = 0;
        int[] arr2 = { 1 };
        int n = 1;
        solution.Merge(arr1, m, arr2, n);

        int[] arr3 = { 1 };
        CollectionAssert.AreEqual(arr1, arr3);
    }

    [TestMethod]
    public void PartitionTest()
    {
        int[] arr = { 1, 4, 3, 2, 5, 2 };
        ListNode node = Helper.GenerateListNode(arr);

        solution.Partition(node, 3);
    }
    [TestMethod]
    public void MaximalRectangleTest()
    {
        int[][] matrix = getMultiDimensionalArray("[[1,0,1, 0 , 0 ],[ 1 , 0 , 1 , 1 , 1 ],[ 1 , 1 , 1 , 1 ,\"1\"],[\"1\",\"0\",\"0\",\"1\",\"0\"]]");
    }

    [TestMethod]
    public void LargestRectangleAreaTest1()
    {
        int[] heights = { 2, 1, 5, 6, 2, 3, 1 };
        var res = solution.LargestRectangleArea(heights);
        Assert.AreEqual(10, res);
    }

    [TestMethod]
    public void LargestRectangleAreaTest()
    {
        int[] heights = { 2, 1, 5, 6, 2, 3 };
        var res = solution.LargestRectangleArea(heights);
        Assert.AreEqual(10, res);
    }

    [TestMethod]
    public void ExistTest()
    {
        char[][] board = new char[][]
        {
            new char[]{ 'A','B','C','E'},
            new char[]{ 'S','F','C','S'},
            new char[]{ 'A','B','C','E'},
            new char[]{ 'A','D','E','E'}
        };
        string word = "ABCB";
        Assert.IsFalse(solution.Exist(board, word));
    }

    [TestMethod]
    public void SearchMatrixTest1()
    {
        int[][] matrix = getMultiDimensionalArray("[[1,3,5,7],[10,11,16,20],[23,30,34,60]]");
        int target = 13;
        Assert.IsFalse(solution.SearchMatrix(matrix, target));
    }

    [TestMethod]
    public void SearchMatrixTest()
    {
        int[][] matrix = getMultiDimensionalArray("[[1,3,5,7],[10,11,16,20],[23,30,34,60]]");
        int target = 3;
        Assert.IsTrue(solution.SearchMatrix(matrix, target));
    }

    [TestMethod]
    public void MySqrtTest1()
    {
        int x = 100;
        var res = solution.MySqrt(x);
        Assert.AreEqual(10, res);
    }

    [TestMethod]
    public void MySqrtTest()
    {
        int x = 99;
        var res = solution.MySqrt(x);
        Assert.AreEqual(9, res);
    }

    [TestMethod]
    public void UniquePathsWithObstaclesTest1()
    {
        int[][] obstacleGrid = getMultiDimensionalArray("[[0,1],[0,0]]");
        var res = solution.UniquePathsWithObstacles(obstacleGrid);
        Assert.AreEqual(1, res);
    }

    [TestMethod]
    public void UniquePathsWithObstaclesTest()
    {
        int[][] obstacleGrid = getMultiDimensionalArray("[[0,0,0],[0,1,0],[0,0,0]]");
        var res = solution.UniquePathsWithObstacles(obstacleGrid);
        Assert.AreEqual(2, res);
    }

    [TestMethod]
    public void UniquePathsTest1()
    {
        int m = 3;
        int n = 2;

        var res = solution.UniquePaths(m, n);
        Assert.AreEqual(3, res);
    }

    [TestMethod]
    public void UniquePathsTest()
    {
        int m = 3;
        int n = 7;

        var res = solution.UniquePaths(m, n);
        Assert.AreEqual(28, res);
    }

    [TestMethod]
    public void InsertTest3()
    {
        int[][] arr = new int[2][]
        {
            new int [] {11,23},
            new int [] {36,49}
        };
        int[] arr1 = new int[] { 7, 10 };

        solution.Insert(arr, arr1);
    }

    [TestMethod]
    public void InsertTest2()
    {
        int[][] arr = new int[2][]
        {
            new int [] {1,3},
            new int [] {6,9}
        };
        int[] arr1 = new int[] { 4, 8 };

        solution.Insert(arr, arr1);
    }

    [TestMethod]
    public void InsertTest1()
    {
        int[][] arr = new int[2][]
        {
            new int [] {1,3},
            new int [] {6,9}
        };
        int[] arr1 = new int[] { 7, 8 };

        solution.Insert(arr, arr1);
    }

    [TestMethod]
    public void InsertTest()
    {
        int[][] arr = new int[2][]
        {
            new int [] {1,3},
            new int [] {6,9}
        };
        int[] arr1 = new int[] { 2, 5 };

        solution.Insert(arr, arr1);
    }

    [TestMethod]
    public void SnakesAndLaddersTest3()
    {
        int[][] board = getMultiDimensionalArray("[[-1,1,1,1],[-1,7,1,1],[16,1,1,1],[-1,1,9,1]]");
        solution.SnakesAndLadders(board);
    }

    [TestMethod]
    public void SnakesAndLaddersTest2()
    {
        int[][] board = getMultiDimensionalArray("[[1,1,-1],[1,1,1],[-1,1,1]]");
        solution.SnakesAndLadders(board);
    }

    [TestMethod]
    public void SnakesAndLaddersTest1()
    {
        int[][] board = getMultiDimensionalArray("[[-1,-1,-1],[-1,9,8],[-1,8,9]]");
        solution.SnakesAndLadders(board);
    }

    [TestMethod]
    public void SnakesAndLaddersTest()
    {
        int[][] board = getMultiDimensionalArray("[[-1,-1,-1,-1,-1,-1],[-1,-1,-1,-1,-1,-1],[-1,-1,-1,-1,-1,-1],[-1,35,-1,-1,13,-1],[-1,-1,-1,-1,-1,-1],[-1,15,-1,-1,-1,-1]]");
        solution.SnakesAndLadders(board);
    }

    [TestMethod]
    public void PermuteUniqueTest()
    {
        int[] nums = { 1, 2, 1, 1, 3, 2 };
        var res = solution.PermuteUnique(nums);
    }

    [TestMethod]
    public void ClosestMeetingNodeTest1()
    {
        int[] edges = { 4, 4, 8, -1, 9, 8, 4, 4, 1, 1 };
        int node1 = 5;
        int node2 = 6;

        var res = solution.ClosestMeetingNode(edges, node1, node2);
        Assert.AreEqual(1, res);
    }

    [TestMethod]
    public void ClosestMeetingNodeTest()
    {
        int[] edges = { 5, 4, 5, 4, 3, 6, -1 };
        int node1 = 0;
        int node2 = 1;

        var res = solution.ClosestMeetingNode(edges, node1, node2);
        Assert.AreEqual(-1, res);
    }

    [TestMethod]
    public void PermuteTest()
    {
        int[] arr = { 1, 2, 3, 4, 5 };
        solution.Permute(arr);
    }

    [TestMethod]
    public void TrapTest()
    {
        int[] arr = { 0, 1, 0, 2, 1, 0, 1, 3, 2, 1, 2, 1 };
        var res = solution.Trap(arr);
        Assert.AreEqual(res, 6);
    }

    [TestMethod]
    public void CombinationSumTest()
    {
        int[] candidates = { 2, 3, 6, 7 };
        int target = 7;
        var res = solution.CombinationSum(candidates, target);
    }

    [TestMethod]
    public void SearchTest1()
    {
        int[] nums = { 2, 3, 4, 5, 1 };
        solution.Search(nums, 1);
    }

    [TestMethod]
    public void SearchTest()
    {
        int[] nums = { 3, 1 };
        solution.Search(nums, 0);
    }

    [TestMethod]
    public void MaxTargetNodesTest3()
    {
        int[][] edges1 = getMultiDimensionalArray("[[0,1],[0,2],[2,3],[2,4]]");
        int[][] edges2 = getMultiDimensionalArray("[[0,1],[0,2],[0,3],[2,7],[1,4],[4,5],[4,6]]");
        solution.MaxTargetNodes(edges1, edges2);
    }

    [TestMethod]
    public void FirstMissingPositiveTest()
    {
        int[] arr = { 1, 2, 0, 4, 3, 3, 6, 5, 5, 9 };
        var res = solution.FirstMissingPositive(arr);
        Assert.AreEqual(7, res);
    }

    [TestMethod]
    public void NextPermutationTest()
    {
        int[] arr = { 1, 2, 3 };
        solution.NextPermutation(arr);
    }

    [TestMethod]
    public void NextPermutationTest5()
    {
        int[] arr = { 2, 3, 1 };
        solution.NextPermutation(arr);
    }
    [TestMethod]
    public void NextPermutationTest1()
    {
        int[] arr = { 3, 2, 1 };
        solution.NextPermutation(arr);
    }

    [TestMethod]
    public void NextPermutationTest2()
    {
        int[] arr = { 1, 5, 1 };
        solution.NextPermutation(arr);
    }

    [TestMethod]
    public void NextPermutationTest3()
    {
        int[] arr = Helper.GenerateArray(1, 88, 8);
        Debug.WriteLine(string.Join(", ", arr));
        solution.NextPermutation(arr);
        Debug.WriteLine(string.Join(", ", arr));
    }

    [TestMethod]
    public void NextPermutationTest4()
    {
        int[] arr = { 6, 9, 8 };
        //Debug.WriteLine(string.Join(", ", arr));
        solution.NextPermutation(arr);
        //Debug.WriteLine(string.Join(", ", arr));
    }
    [TestMethod]
    public void StrStrTest1()
    {
        string haystack = "sadsadbut";
        string needle = "sadbut";
        var actual = solution.StrStr(haystack, needle);
        Assert.AreEqual(3, actual);
    }
    [TestMethod]
    public void StrStrTest()
    {
        string haystack = "sadbutsad";
        string needle = "sad";
        var actual = solution.StrStr(haystack, needle);
        Assert.AreEqual(0, actual);
    }



    [TestMethod]
    public void ReverseKGroupT()
    {
        int[] arr = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        ListNode node = Helper.GenerateListNode(arr);
        solution.ReverseKGroup(node, 3);
    }

    [TestMethod]
    public void ReverseNodes()
    {
        int[] arr = { 1, 2, 3, 4, 5 };
        ListNode node = Helper.GenerateListNode(arr);
        solution.ReverseNodes(node);
    }
    [TestMethod]
    public void MaxTargetNodesTest()
    {
        int[][] edges1 = getMultiDimensionalArray("[[0,1],[0,2],[2,3],[2,4]]");
        int[][] edges2 = getMultiDimensionalArray("[[0,1],[0,2],[0,3],[2,7],[1,4],[4,5],[4,6]]");
        solution.MaxTargetNodes(edges1, edges2, 2);
    }

    [TestMethod]
    public void SwapPairsTest1()
    {
        int[] arr = { 1, 2, 3, 4, 5 };
        ListNode node = Helper.GenerateListNode(arr);
        solution.SwapPairs(node);
    }

    [TestMethod]
    public void SwapPairsTest()
    {
        int[] arr = Helper.GenerateArray(40, 90, 10);
        ListNode node = Helper.GenerateListNode(arr);
        solution.SwapPairs(node);
    }

    [TestMethod]
    public void GenerateParenthesisTest()
    {
        var k = solution.GenerateParenthesis(3);
    }

    [TestMethod]
    public void MergeKListsTest()
    {
        ListNode[] listNodes = new ListNode[10];
        for (int i = 0; i < 10; i++)
        {
            Random random = new Random();
            int k = random.Next(2, 13);

            int[] arr = Helper.GenerateArray(10, 100, k);
            ListNode listNode = Helper.GenerateListNode(arr);
            listNodes[i] = listNode;
        }
        solution.MergeKLists(listNodes);
    }

    [TestMethod]
    public void LargestPathValueTest1()
    {
        string colors = "nnllnzznn";
        int[][] edges = getMultiDimensionalArray("[[0,1],[1,2],[2,3],[2,4],[3,5],[4,6],[3,6],[5,6],[6,7],[7,8]]");
        var actual = solution.LargestPathValue(colors, edges);
        Assert.AreEqual(5, actual);
    }

    [TestMethod]
    public void LargestPathValueTest()
    {
        string colors = "abaca";
        int[][] edges = getMultiDimensionalArray("[[0,1],[0,2],[2,3],[3,4]]");
        var actual = solution.LargestPathValue(colors, edges);
        Assert.AreEqual(3, actual);
    }

    [TestMethod]
    public void ThreeSumTest()
    {
        int[] arr = { -1, 0, 1, 2, -1, -4 };
        var res = solution.ThreeSum(arr);
    }

    [TestMethod]
    public void ReverseTest2()
    {
        int x = int.MaxValue;
        var actual = solution.Reverse(x);
        Assert.AreEqual(0, actual);
    }

    [TestMethod]
    public void ReverseTest1()
    {
        int x = -6743897;
        var actual = solution.Reverse(x);
        x = -x;
        int expected = int.Parse(new string(x.ToString().Reverse().ToArray()));
        expected = -expected;
        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void ReverseTest()
    {
        int x = 6743897;
        var actual = solution.Reverse(x);
        int expected = int.Parse(new string(x.ToString().Reverse().ToArray()));
        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void ConvertTest()
    {
        string s = "Paypalishiring";
        var result = solution.Convert(s, 3);
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
