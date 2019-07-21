using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewPreparation.Problems
{
    class Solution
    {
        public static int[] getMinimumUniqueSum(string[] arr)
        {
            int a, b;
            int[] ret = new int[arr.Length];

            for (int i = 0; i < arr.Length; i++)
            {
                int x = Int32.Parse(arr[i].Split(' ')[0]);
                int y = Int32.Parse(arr[i].Split(' ')[1]);
                if (y > x)
                {
                    a = x;
                    b = y;
                }
                else
                {
                    a = y;
                    b = x;
                }


                for (int z = a; z <= b; z++)
                {
                    if (Solution.hasSquareRoot(z))
                        ret[i]++;

                }


            }
            return ret;

        }

            static bool hasSquareRoot(int i)
            {
                int k = i;

                for (int j = 2; j < i; )
                {
                    if (k % (j * j) == 0)
                    {
                        k = k / j / j;
                    }

                    else
                        j++;

                }

                return k == 1;

            }

       public static string getLexNextString(string s)
            {
                char[] a = s.ToCharArray();
                char[] b = s.ToCharArray(); 
                int[] alpha = new int[26];
                int i = a.Length - 2;

                while (i >= 0)
                {
                    if ((int)a[i + 1] <= (int)a[i])
                    {
                        b = Solution.reposition(b, i);
                    }
                    else
                    {
                        char t = a[i];
                        for (int x = i+1; x < a.Length; x++) {
                            if (t < b[x])
                            {
                                b[i] = b[x];
                                b[x] = t;
                            }
                        }
                            break;
                    }
                    i--;
                }

                return new string(b);
            }

       static char[] reposition(char[] b, int p)
       {
           char t = b[p];
           int i = p;
           for (; i < b.Length-1; i++)
           {
               if (t > b[i+1])
               {
                   b[i] = b[i+1];
               }
               else
               {
                   break;
               }
           }
           b[i] = t;

           return b;

       }
    }
}
