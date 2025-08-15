
namespace Leetcode2025
{
    public class MemoizationSolution
    {
        #region 464. Can I Win
        int[] playerA, playerB;
        public bool CanIWin(int maxChoosableInteger, int desiredTotal)
        {
            if (desiredTotal <= maxChoosableInteger) return true;

            int total = maxChoosableInteger * (maxChoosableInteger + 1) / 2;

            if(total < desiredTotal) return false;

            var memo = new Dictionary<int, bool>();

            return dfs464(0, memo, desiredTotal, maxChoosableInteger);
        }

        private bool dfs464(int used, Dictionary<int, bool> memo, int desiredTotal, int maxChoosableInteger)
        {
            if(memo.ContainsKey(used)) return memo[used];    

            for(int i = 1;i<= maxChoosableInteger; i++)
            {
                int bit = 1 << i;
                if ((used & bit) == 0) { 
                    if(i>=desiredTotal)
                    {
                        memo[used] = true; return true;
                    }

                    if(!dfs464(used|bit,memo, desiredTotal-i, maxChoosableInteger))
                    {
                        memo[used]=true; return true;                        
                    }

                }
            }
            memo[used] = false;
            return false;
        }
        #endregion
    }
}
