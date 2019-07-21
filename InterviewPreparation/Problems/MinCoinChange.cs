using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewPreparation.Problems
{
    class MinCoinChange
    {
        public static int getMinCoinChange(int[] c, int n)
        {
            int[] dp = new int[n + 1];
            for (int x = 0; x <= n; x++)
                dp[x] = n+1;
            dp[0] = 0;

            for (int i = 1; i <= n; i++)
            {
                    for (int j = 0; j < c.Length; j++)
                    {
                        if (i >= c[j])
                        {
                            dp[i] = Math.Min(dp[i], dp[i - c[j]] + 1);
                        }
                    }
            }

            return dp[n] > n ? -1 : dp[n];
        }
    }
}
