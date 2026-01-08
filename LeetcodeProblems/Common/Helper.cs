namespace Common
{
    public static class Helper
    {

        public static int[][] GetMultiDimensionalArrayBasedOnString(string str)
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

        public static void Swap(this int[] a, int index1, int index2)
        {
            if (index1 < a.Length && index2 < a.Length)
            {
                int temp = a[index1];
                a[index1] = a[index2];
                a[index2] = temp;
            }
        }

        public static int[] GenerateArray(int min = int.MinValue, int max = int.MaxValue, int length = 100000)
        {

            int[] array = new int[length];
            Random r = new Random();
            for (int i = 0; i < length; i++)
            {
                array[i] = r.Next(min, max);
            }
            return array;
        }

        public static bool IsSortedArray(int[] array)
        {
            if (array != null && array.Length > 0)
            {
                int curr = array[0];
                for (int i = 1; i < array.Length; i++)
                {
                    if (curr > array[i]) return false;

                    curr = array[i];
                }
            }
            return true;
        }

        public static ListNode GenerateListNode(int[] array)
        {
            ListNode node = new ListNode(-1, null);

            ListNode temp = node;

            for (int i = 0; i < array.Length; i++)
            {
                temp.next = new ListNode(array[i]);
                temp = temp.next;
            }
            return node.next;
        }

        public static int?[] GetIntArray(string s)
        {
            string[] strings = s.Trim('[', ']').Split(',');

            int?[] ints = new int?[strings.Length];
            for (int i = 0; i < strings.Length; i++)
            {
                if (strings[i] == "null") continue;
                ints[i] = int.Parse(strings[i]);
            }

            return ints;
        }

        public static TreeNode GetTreeNode(string s)
        {
            TreeNode node = null;

            int?[] elements = GetIntArray(s);
            int currIndex = 0;
            Queue<TreeNode> nodes = new Queue<TreeNode>();
            if (elements?.Length > 0 && elements[currIndex].HasValue)
            {
                node = GetTreeNode(elements, currIndex);
                nodes.Enqueue(node);
            }
            while (nodes.Count > 0 && ++currIndex < elements?.Length)
            {
                var dq = nodes.Dequeue();
                if (elements.Length > currIndex && elements[currIndex].HasValue)
                {
                    dq.left = GetTreeNode(elements, currIndex);
                    nodes.Enqueue(dq.left);
                }
                if (elements.Length > ++currIndex && elements[currIndex].HasValue)
                {
                    dq.right = GetTreeNode(elements, currIndex);
                    nodes.Enqueue(dq.right);
                }
            }
            return node;
        }

        public static TreeNode GetTreeNode(int?[] elements, int index, out int nextIndex)
        {
            nextIndex = index + 2;
            TreeNode node = null;
            if (elements != null && elements.Length >= index && elements[index].HasValue)
            {
                node = new TreeNode(elements[index].Value);
                if (elements.Length >= index + 1 && elements[index + 1].HasValue)
                {
                    node.left = new TreeNode(elements[index + 1].Value);
                }
                if (elements.Length >= index + 2 && elements[index + 2].HasValue)
                {
                    node.right = new TreeNode(elements[index + 2].Value);
                }
            }

            return node;
        }

        public static TreeNode GetTreeNode(int?[] elements, int index)
        {
            TreeNode node = null;
            if (elements != null && elements.Length > index && elements[index].HasValue)
            {
                node = new TreeNode(elements[index].Value);
            }

            return node;
        }
    }
}
