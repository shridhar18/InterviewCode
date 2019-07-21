using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewPreparation.DynamicProgramming
{
    class DynamicProgramming
    {
        int max_ref = 1;
        int _lis(int[] arr, int n)
        {
            // base case
            if (n == 1)
                return 1;

            // 'max_ending_here' is length of LIS ending with arr[n-1]
            int res, max_ending_here = 1;

            /* Recursively get all LIS ending with arr[0], arr[1] ...
               arr[n-2]. If   arr[i-1] is smaller than arr[n-1], and
               max ending with arr[n-1] needs to be updated, then
               update it */
            for (int i = 1; i < n; i++)
            {
                res = _lis(arr, i);
                if (arr[i - 1] < arr[n - 1] && res + 1 > max_ending_here)
                    max_ending_here = res + 1;
            }

            // Compare max_ending_here with the overall max. And
            // update the overall max if needed
            if (max_ref < max_ending_here)
                max_ref = max_ending_here;

            // Return length of LIS ending with arr[n-1]
            return max_ending_here;
        }

        public int Lis()
        {
            int[] arr = { 10, 22, 18, 20, 33, 21, 50, 41, 60 };
            int n = arr.Length;
            // The max variable holds the result
            int max = 1;
            Console.WriteLine("Length of lis is {0}", this._lis(arr, n));
            

            // returns max
            return max;
        }


        public static void MinCostPathRecursive()
        {
            int[,] cost = new int[,] { { 2, 33, 63, 24 }, 
                                       { 22, 62, 13, 45 }, 
                                       { 12, 42, 13, 64 }, 
                                       { 22, 52, 63, 34 } };
            Console.Write("min cost recursive {0}", _minPathCostRec(0, 0, 4, cost));
            Console.Write("min cost DP {0}", _minPathCostDP(4, cost));
        }

        static int _minPathCostRec(int i, int j, int n, int[,] cost)
        {
            if(i >= n || j >= n)
            {
                return int.MaxValue;

            }
            else if(i == n-1 && j == n-1)
            {
                return cost[i,j];
            }
            else
            {
                return cost[i, j] + Min(_minPathCostRec(i, j + 1, n, cost), _minPathCostRec(i+1, j + 1, n, cost), _minPathCostRec(i+1, j, n, cost));
            }
        }

        static int _minPathCostDP(int n, int[,] cost)
        {
            int[,] dp = new int[n, n];

            dp[0, 0] = cost[0, 0];

            for(int i=1;i<n;i++)
            {
                dp[i, 0] = dp[i-1, 0] + cost[i, 0];
            }

            for (int i = 1; i < n; i++)
            {
                dp[0, i] = dp[0, i - 1] + cost[0, i];
            }

            for (int i = 1; i < n; i++)
            {
                for(int j =1; j< n;j++)
                {
                    dp[i, j] = cost[i, j] + Min(dp[i - 1, j], dp[i, j - 1], dp[i - 1, j - 1]);
                }
            }

            return dp[n-1, n-1];
        }

        static int Min(int x, int y, int z)
        {
            if (x < y && x < z)
                return x;
            else if (y < x && y < z)
                return y;
            else
                return z;
        }
    }
}
