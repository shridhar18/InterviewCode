using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewPreparation.ArraysStrings
{
    class DynamicProgramming
    {
        public static int MinEditDistance(string s1, string s2, int l1, int l2)
        {
            if (l1 == 0 )
            {
                return l2;
            }
            if(l2 == 0)
                return l1;

            if (s1[l1 - 1] == s2[l2 - 1])
            {
                return MinEditDistance(s1, s2, l1-1, l2-1);
            }
            else
            {
                return 1 + minVal(
                            MinEditDistance(s1, s2, l1, l2-1),
                            MinEditDistance(s1, s2, l1-1, l2),
                            MinEditDistance(s1, s2, l1-1, l2-1)
                        );
            }

        }

        public static int MinEditDistanceDP(string s1, string s2, int l1, int l2)
        {
            int[,] dp= new int[l1+1, l2+1];

            for(int i = 0; i<= l1; i++)
            {
                for (int j = 0; j <= l2; j++)
                {
                    if (i == 0)
                        dp[i, j] = j;
                    else if (j == 0)
                        dp[i, j] = i;

                    else if (s1[i - 1] == s2[j - 1])
                        dp[i, j] = dp[i - 1, j - 1];
                    else
                    {
                        dp[i, j] = 1 + minVal(dp[i-1, j], dp[i,j-1], dp[i-1,j-1]);
                    }
                }
            }

            return dp[l1, l2];
        }

        static int minVal(int x, int y, int z)
        {
            if (x < y && x < z)
                return x;
            else if (y < x && y < z)
                return y;
            else 
                return z;
        }


        public static int minCostPathinMatrix(int[,] c, int m, int n)
        {
            if (m < 0 || n < 0)
                return -1;
            else if (m == 0 && n == 0)
            {
                return c[m, n];
            }
            else
            {
                return minVal(
                        minCostPathinMatrix(c, m-1, n),
                        minCostPathinMatrix(c, m, n-1),
                        minCostPathinMatrix(c, m-1, n-1)
                    ) + c[m, n];
            }
        }

        public static int minCostPathinMatrixDP(int[,] c, int m, int n)
        {
            int[,] dp = new int[m + 1, n + 1];

            dp[0,0] = c[0,0];

            for (int i = 1; i <= m; i++)
            {
                dp[i, 0] = dp[i - 1, 0] + c[i, 0];
            }
            for (int j = 1; j <= n; j++)
            {
                dp[0, j] = dp[0, j-1] + c[0, j];
            }
            for (int i = 1; i <= m; i++)
            {
                for (int j = 1; j <= n; j++)
                {
                    dp[i, j] = minVal(dp[i - 1, j], dp[i, j - 1], dp[i - 1, j - 1]) + c[i, j];
                }
            }

            return dp[m, n];
        }

        //Trapping Rain Water
        public static int rainWaterTrapped(int[] c)
        {
            int[] l = new int[c.Length];
            int[] r = new int[c.Length];
            int water = 0;

            l[0] = c[0];
            for (int i = 1; i < c.Length; i++)
            {
                l[i] = Math.Max(l[i - 1], c[i]);
            }

            r[c.Length-1] = c[c.Length-1];
            for (int i = c.Length-2; i >= 0; i--)
            {
                r[i] = Math.Max(r[ i + 1], c[i]);
            }

            for (int i = 0; i < c.Length; i++)
            {
                water += Math.Min(l[i], r[i]) - c[i];
            }

            return water;
        }

        //Minimum number of jumps to reach end

        //public static int minJumpsToEnd()
        
        // coin chnage count
        public static int coinChangeDP(int[] a, int sum)
        {
            int[] dp = new int[sum+1];

            dp[0] = 1;

            for (int i = 0; i < a.Length; i++)
            {
                for (int j = a[i]; j <= sum; j++)
                {
                    a[j] += a[j - a[i]];
                }
            }
            return a[sum];
        }

        public static int longestIncreasinSequence(int[] m)
        {
            int[] lis = new int[m.Length];
            int maxLen = 1;

            for (int i = 0; i < m.Length; i++)
            {
                lis[i] = 1;
            }

            for (int i = 1; i < m.Length; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    if (m[i] > m[j])
                    {
                        if (lis[i] < lis[j] + 1)
                        {
                            lis[i] = lis[j] + 1;
                            if (maxLen < lis[i])
                                maxLen = lis[i];
                        }
                    }
                }
            }
            return maxLen;
        }

        public static int longestCommonSequence(string s1, string s2)
        {
            if (s1.Length == 0 || s2.Length == 0)
            {
                return 0;
            }
            else if (s1[s1.Length - 1] == s2[s2.Length - 1])
            {
                return longestCommonSequence(s1.Substring(0, s1.Length - 1), s2.Substring(0, s2.Length - 1)) + 1;
            }
            else
            {
                return Math.Max(longestCommonSequence(s1.Substring(0, s1.Length - 1), s2), longestCommonSequence(s1, s2.Substring(0, s2.Length - 1)));
            }

        }

        public static int binomialCoefficients(int n, int k)
        {
            int[,] c = new int[n + 1, k + 1];

            for (int i = 0; i <= n; i++)
            {
                for (int j = 0; j <= Math.Min(i, k); j++)
                {
                    if (j == 0 || j == i)
                    {
                        c[i, j] = 1;

                    }
                    else
                    {
                        c[i, j] = c[i - 1, j - 1] + c[i - 1, j];
                    }
                }
            }

            return c[n, k];
        }

        public static int knapsack(int[] v, int[] w, int wt, int n)
        {
            if (n == 0 || wt == 0)
                return 0;
            else if (w[n - 1] > wt)
                return knapsack(v, w, wt, n - 1);
            else
            {
                return Math.Max(v[n - 1] + knapsack(v, w, wt - w[n - 1], n - 1), knapsack(v, w, wt, n - 1));
            }
        }

        public static int knapsackDP(int[] v, int[] w, int wt, int n)
        {
            int[,] dp = new int[n + 1, wt + 1];

            for (int i = 0; i <= n; i++)
            {
                for (int j = 0; j <= wt; j++)
                {
                    if (i == 0 || j == 0)
                    {
                        dp[i, j] = 0;
                    }
                    else if (w[i - 1] <= j)
                    {
                        dp[i, j] = Math.Max(v[i - 1] + dp[i - 1, j - w[i - 1]], dp[i - 1, j]);
                    }
                    else
                    {
                        dp[i, j] = dp[i - 1, j];
                    }
                }
            }

            return dp[n, wt];
        }

        public static int eggDropTrials(int n, int k)
        {
            int[,] trials = new int[n + 1, k + 1];

            for (int i = 1; i <= n; i++)
            {
                trials[i, 0] = 0;
                trials[i, 1] = 1;
            }

            for (int i = 1; i <= k; i++)
            {
                trials[1, i] = i;
            }

            for (int i = 2; i <= n; i++)
            {
                for (int j = 2; j <= k; j++)
                {
                    trials[i, j] = int.MaxValue;
                    for (int x = 1; x <= j; x++)
                    {
                        int res = 1 + Math.Max(trials[i - 1, x - 1], trials[i, j - x]);

                        if (trials[i, j] > res)
                            trials[i, j] = res;
                    }
                }
            }

            return trials[n, k];
        }

        public static int LongPalinSubSeq(string x, int i, int j)
        {
            if (i == j)
                return 1;
            else if (x[i] == x[j] && j == i + 1)
                return 2;
            else if (x[i] == x[j] && j > i + 1)
                return LongPalinSubSeq(x, i + 1, j - 1) + 2;
            else
                return Math.Max(LongPalinSubSeq(x, i + 1, j), LongPalinSubSeq(x, i, j - 1));
        }

        public static int LongPalinSubSeqDP(string x)
        {
            int n = x.Length;
            int[,] dp = new int[n, n];
            for (int i = 0; i < n; i++)
            {
                dp[i, i] = 1;
            }

            for (int l = 2; l <= n; l++)
            {
                for (int i = 0; i < n - l + 1; i++)
                {
                    int j = i + l - 1;
                    if (x[i] == x[j] && j == i + 1)
                        dp[i, j] = 2;
                    else if (x[i] == x[j] && j > i + 1)
                        dp[i, j] = dp[i + 1, j - 1] + 2;
                    else
                        dp[i, j] = Math.Max(dp[i + 1, j], dp[i, j - 1]);
                }
            }

            return dp[0, n - 1];
        }

        public static int LongestPalindromeSubstringEasy(string arr)
        {
            int longest_substring = 1;
            for (int i = 0; i < arr.Length; i++)
            {
                int x, y;
                int palindrome;
                x = i;
                y = i + 1;
                palindrome = 0;
                while (x >= 0 && y < arr.Length && arr[x] == arr[y])
                {
                    x--;
                    y++;
                    palindrome += 2;
                }
                longest_substring = Math.Max(longest_substring, palindrome);
                x = i - 1;
                y = i + 1;
                palindrome = 1;
                while (x >= 0 && y < arr.Length && arr[x] == arr[y])
                {
                    x--;
                    y++;
                    palindrome += 2;
                }
                longest_substring = Math.Max(longest_substring, palindrome);
            }
            return longest_substring;
        }

    }
}
