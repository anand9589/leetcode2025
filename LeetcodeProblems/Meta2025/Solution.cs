﻿
using Common;

namespace Meta2025
{
    public class Solution
    {
        /// <summary>
        /// m = l1.length, n = l2.length
        /// Time Complexity O Max(m,n)
        /// Space Complexity O Max(m,n)
        /// </summary>
        /// <param name="l1"></param>
        /// <param name="l2"></param>
        /// <returns></returns>

        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            int carry = 0;
            ListNode dummy = new ListNode(-1, null);

            ListNode temp = dummy;

            while (l1 != null && l2 != null)
            {
                int n = l1.val + l2.val + carry;
                if (n > 9) carry = 1;
                temp.next = new ListNode(n % 10);
                temp = temp.next;
                l1 = l1.next;
                l2 = l2.next;
            }

            while (l1 != null)
            {
                int n = l1.val +  carry;
                if (n > 9) carry = 1;
                temp.next = new ListNode(n % 10);
                temp = temp.next;
                l1=l1.next;
            }

            while ( l2 != null)
            {
                int n = l2.val + carry;
                if (n > 9) carry = 1;
                temp.next = new ListNode(n % 10);
                temp = temp.next;
                l2=l2.next;
            }
            if (carry == 1)
            {
                temp.next = new ListNode(1);
            }

            return dummy.next;
        }

        /// <summary>
        /// TC : O(N)
        /// SC : O(N)
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public int[] TwoSum(int[] nums, int target)
        {
            Dictionary<int, int> keys = new Dictionary<int, int>();
            keys.Add(nums[0], 0);
            for (int i = 1; i < nums.Length; i++)
            {
                int key = nums[i];
                int reqKey = target - key;
                if (keys.ContainsKey(reqKey))
                {
                    return new int[] { i, keys[reqKey] };
                }
                keys[key] = i;
            }
            return new int[] { -1, -1 };
        }

        public bool BinarySearch(int[] arr, int key)
        {
            if (arr.Length == 0) return false;
            int low = 0, high = arr.Length - 1;

            while (low <= high)
            {
                int mid = (low + high) / 2;
                if (arr[mid] == key) return true;
                if (arr[mid] < key) low = mid + 1;
                else high = mid - 1;
            }

            return false;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="arr"></param>
        public void HeapSort(int[] arr)
        {
            HeapSort(arr, arr.Length - 1);
        }

        public void HeapSort(int[] arr, int endIndex)
        {
            while (endIndex > 0)
            {
                heapify(arr, 0, endIndex);
                arr.Swap(0, endIndex);
                endIndex--;
            }
        }

        private void heapify(int[] arr, int index, int endIndex)
        {
            int left = 2 * index + 1;

            if (left > endIndex) return;

            int right = left + 1;
            if (right > endIndex)
            {
                if (arr[left] > arr[index])
                {
                    arr.Swap(left, index);
                }
                return;
            }
            heapify(arr, left, endIndex);
            heapify(arr, right, endIndex);
            if (arr[left] < arr[right])
            {
                left = right;
            }

            if (arr[left] > arr[index])
            {
                arr.Swap(left, index);
            }


            //HeapSort(arr, endIndex - 1);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="arr"></param>
        public void QuickSort(int[] arr)
        {
            QuickSort(arr, 0, arr.Length - 1);
        }
        /// <summary>
        /// TC O(N^2)
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        public void QuickSort(int[] arr, int startIndex, int endIndex)
        {
            if (startIndex >= endIndex) return;
            if (startIndex == endIndex - 1)
            {
                if (arr[startIndex] > arr[endIndex])
                {
                    arr.Swap(startIndex, endIndex);
                }
                return;
            }

            int pivot = arr[endIndex];
            int pivotIndex = startIndex;
            for (int i = startIndex; i < endIndex; i++)
            {
                if (arr[i] <= pivot)
                {
                    arr.Swap(i, pivotIndex);
                    pivotIndex++;
                }
            }
            arr.Swap(pivotIndex, endIndex);

            QuickSort(arr, startIndex, pivotIndex - 1);
            QuickSort(arr, pivotIndex + 1, endIndex);
        }

        /// <summary>
        /// Merge Sort
        /// TC O(NlogN)
        /// SC O(N)
        /// </summary>
        /// <param name="arr"></param>
        public void MergeSort(int[] arr)
        {
            MergeSort(arr, 0, arr.Length - 1);
        }
        /// <summary>
        /// TC O(logN)
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        public void MergeSort(int[] arr, int startIndex, int endIndex)
        {
            if (startIndex == endIndex) return;

            if (startIndex == endIndex - 1)
            {
                if (arr[startIndex] > arr[endIndex])
                {
                    arr.Swap(startIndex, endIndex);
                }
                return;
            }

            int midIndex = (startIndex + endIndex) / 2;
            MergeSort(arr, startIndex, midIndex);
            MergeSort(arr, midIndex + 1, endIndex);
            Merge(arr, startIndex, midIndex, endIndex);
        }
        /// <summary>
        /// TC O(N)
        /// SC O(N)
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="startIndex"></param>
        /// <param name="midIndex"></param>
        /// <param name="endIndex"></param>
        public void Merge(int[] arr, int startIndex, int midIndex, int endIndex)
        {

            if (arr[midIndex] > arr[midIndex + 1])
            {
                int[] arr1 = new int[midIndex - startIndex + 1];
                int[] arr2 = new int[endIndex - midIndex];
                int index = -1;

                while (++index < arr1.Length && index < arr2.Length)
                {
                    arr1[index] = arr[startIndex + index];
                    arr2[index] = arr[midIndex + index + 1];
                }

                while (index < arr1.Length)
                {
                    arr1[index] = arr[startIndex + index];
                    index++;
                }
                while (index < arr2.Length)
                {
                    arr2[index] = arr[midIndex + index + 1];
                    index++;
                    index++;
                }

                int index1 = 0;
                int index2 = 0;

                while (index1 < arr1.Length && index2 < arr2.Length)
                {
                    if (arr1[index1] < arr2[index2])
                    {
                        arr[startIndex] = arr1[index1];
                        index1++;
                    }
                    else
                    {
                        arr[startIndex] = arr2[index2];
                        index2++;
                    }
                    startIndex++;
                }

                while (index1 < arr1.Length)
                {
                    arr[startIndex++] = arr1[index1++];
                }

                while (index2 < arr2.Length)
                {
                    arr[startIndex++] = arr2[index2++];
                }
            }
        }

        /// <summary>
        /// Insertion Sort
        /// TC O(N^2)
        /// SP O(1)
        /// </summary>
        /// <param name="arr"></param>
        public void InsertionSort(int[] arr)
        {
            for (int i = 1; i < arr.Length; i++)
            {
                int curr = arr[i];

                int j = i - 1;
                while (j >= 0 && arr[j] > curr)
                {
                    arr.Swap(j, j + 1);
                    j--;
                }
                arr[j + 1] = curr;
            }
        }


        /// <summary>
        /// Bubble Sort
        /// TC O(N^2)
        /// SP O(1)
        /// </summary>
        /// <param name="arr"></param>
        public void BubbleSort(int[] arr)
        {
            bool needToSort = true;

            while (needToSort)
            {
                needToSort = false;
                for (int i = 1; i < arr.Length; i++)
                {
                    if (arr[i] < arr[i - 1])
                    {
                        arr.Swap(i, i - 1);
                        needToSort = true;
                    }
                }
            }
        }

        /// <summary>
        /// Selection Sort
        /// Time Complexity O(N^2)
        /// Space Complexity O(1)
        /// </summary>
        /// <param name="arr">Array to Sort</param>
        public void SelectionSort(int[] arr)
        {
            for (int i = 0; i < arr.Length - 1; i++)
            {
                int indexToSwap = i;
                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[j] < arr[indexToSwap])
                    {
                        indexToSwap = j;
                    }
                }
                arr.Swap(indexToSwap, i);
            }
        }

        public IList<int> FindWordsContaining(string[] words, char x)
        {
            List<int> res = new List<int>();
            int n = words.Length;
            for (int i = 0; i < n; i++)
            {
                if (words[i].Contains(x))
                {
                    res.Add(i);
                }
            }
            return res;
        }

        public int MaxRemoval(int[] nums, int[][] queries)
        {
            Array.Sort(queries, (a, b) => a[0] - b[0]);

            PriorityQueue<(int r, int c), int> availableQueue = new PriorityQueue<(int r, int c), int>(Comparer<int>.Create((x, y) => y - x));
            PriorityQueue<int, int> usedQueue = new PriorityQueue<int, int>();
            int left = 0, right = 0;

            int queryIndex = 0;
            int count = 0;

            for (int i = 0; i < nums.Length; i++)
            {
                int curr = nums[i];

                if (curr == 0) continue;

                while (usedQueue.TryPeek(out int ele, out int p) && ele < i)
                {
                    usedQueue.Dequeue();
                    count++;
                }

                if (usedQueue.Count >= curr) continue;
                while (queryIndex < queries.Length && queries[queryIndex][0] <= i)
                {
                    left = queries[queryIndex][0];
                    right = queries[queryIndex][1];
                    availableQueue.Enqueue((left, right), right);
                    queryIndex++;
                }

                int diff = curr - usedQueue.Count;

                while (availableQueue.Count > 0 && diff-- > 0)
                {
                    (left, right) = availableQueue.Dequeue();
                    if (right >= i)
                    {
                        usedQueue.Enqueue(right, right);
                    }
                }
                if (usedQueue.Count < curr) return -1;
            }

            return queries.Length - (count + usedQueue.Count);
        }
        public int MaxRemoval2(int[] nums, int[][] queries)
        {
            Array.Sort(queries, new Comparer3362());

            int k = 0;

            while (k < nums.Length && nums[k] == 0)
            {
                k++;
            }

            if (k == nums.Length) return queries.Length;
            Span<int> span = new int[nums.Length + 1];
            int count = 0;
            int diff = 0;

            for (int i = 0; i < queries.Length; i++)
            {
                int l = queries[i][0];
                int r = queries[i][1];
                span[l]++;
                span[r + 1]--;
                if (l <= k)
                {

                }
                if (r < k)
                {
                    count++;
                }
                else
                {
                    diff++;

                    if (diff >= nums[k])
                    {
                        while (k < nums.Length && nums[k] <= diff)
                        {
                            k++;
                            diff += span[k];
                        }
                        if (k == nums.Length)
                        {
                            count += queries.Length - i - 1;
                            break;
                        }
                    }
                }
            }
            return k == nums.Length ? count : -1;
        }

        public int MaxRemoval1(int[] nums, int[][] queries)
        {
            Array.Sort(queries, new Comparer3362());

            int k = 0;

            while (k < nums.Length && nums[k] == 0)
            {
                k++;
            }

            if (k == nums.Length) return queries.Length;
            Span<int> span = new int[nums.Length + 1];
            int count = 0;
            int diff = 0;

            for (int i = 0; i < queries.Length; i++)
            {
                int l = queries[i][0];
                int r = queries[i][1];
                span[l]++;
                span[r + 1]--;
                if (r < k)
                {
                    count++;
                }
                else
                {
                    diff++;

                    if (diff >= nums[k])
                    {
                        while (k < nums.Length && nums[k] <= diff)
                        {
                            k++;
                            diff += span[k];
                        }
                        if (k == nums.Length)
                        {
                            count += queries.Length - i - 1;
                            break;
                        }
                    }
                }
            }
            return k == nums.Length ? count : -1;
        }

        public int MinZeroArray(int[] nums, int[][] queries)
        {
            int k = 0;
            while (k < nums.Length && nums[k] == 0)
            {
                k++;
            }

            if (k == nums.Length) return 0;

            Span<int> span = new int[nums.Length + 1];

            //int diffIndex = 0;
            int diff = 0;
            for (int i = 0; i < queries.Length; i++)
            {
                int l = queries[i][0];
                int r = queries[i][1];
                int w = queries[i][2];

                span[l] += w;
                span[r + 1] -= w;

                if (l <= k && k <= r)
                {

                    diff += w;

                    if (diff >= nums[k])
                    {
                        while (k < nums.Length && nums[k] <= diff)
                        {
                            k++;
                            diff += span[k];
                        }
                    }

                    if (k == nums.Length)
                        return i + 1;
                }


            }

            return -1;
        }

        public int MinZeroArray1(int[] nums, int[][] queries)
        {
            int k = 0;
            while (k < nums.Length && nums[k] == 0)
            {
                k++;
            }

            if (k == nums.Length) return 0;

            Span<int> span = new int[nums.Length + 1];

            int diffIndex = k;
            int diff = 0;
            for (int i = 0; i < queries.Length; i++)
            {
                int l = queries[i][0];
                int r = queries[i][1];
                int w = queries[i][2];

                span[l] += w;
                span[r + 1] -= w;

                if (diffIndex >= l && diffIndex <= r)
                {
                    diff += w;
                }

                if (l <= k)
                {

                    //diff += w;

                    if (diff >= nums[k])
                    {
                        while (k < nums.Length && nums[k] <= diff)
                        {
                            k++;
                            diff += span[diffIndex];
                            diffIndex++;
                        }
                    }

                    //if (k == nums.Length && diff)
                    //    return i + 1;
                }


            }

            return -1;
        }

        public bool IsZeroArray(int[] nums, int[][] queries)
        {
            Span<int> diff = stackalloc int[nums.Length + 1];

            foreach (int[] query in queries)
            {
                diff[query[0]]++;
                diff[query[1] + 1]--;
            }

            int d = 0;

            for (int i = 0; i < nums.Length; i++)
            {
                d += diff[i];

                if (d < nums[i]) return false;
            }
            return true;
        }

        public bool IsZeroArray1(int[] nums, int[][] queries)
        {
            int[] diff = new int[nums.Length + 1];

            foreach (int[] query in queries)
            {
                diff[query[0]]++;
                diff[query[1] + 1]--;
            }

            int d = 0;

            for (int i = 0; i < nums.Length; i++)
            {
                d += diff[i];

                if (d < nums[i]) return false;
            }
            return true;
        }
    }
}
