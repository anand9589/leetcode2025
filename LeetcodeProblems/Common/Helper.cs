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
                array[i] = r.Next(min,max);
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
    }
}
