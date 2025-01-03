namespace Leetcode2025
{
    public class Leetcode2025
    {


        #region 2559. Count Vowel Strings in Ranges
        public int[] VowelStrings(string[] words, int[][] queries)
        {
            HashSet<char> vowels = new HashSet<char>() { 'a', 'e', 'i', 'o', 'u' };
            int[] preCount = new int[words.Length];
            bool[] vowelString = new bool[words.Length];
            int initialCount = 0;
            for (int i = 0; i < words.Length; i++)
            {
                char first = words[i][0];
                char last = words[i][words[i].Length - 1];
                if (vowels.Contains(first) && vowels.Contains(last))
                {
                    initialCount++;
                    vowelString[i] = true;
                }
                preCount[i] = initialCount;
            }

            int[] result = new int[queries.Length];

            for (int i = 0; i < queries.Length; i++)
            {
                result[i] = preCount[queries[i][1]] - preCount[queries[i][0]];
                if (vowelString[queries[i][0]])
                {
                    result[i] += 1;
                }
            }

            return result;
        }
        #endregion
    }
}