using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewPreparation.Problems
{
    class ThreeSumAndSortings
    {
        public List<List<int>> threeSum(int[] m, int k)
        {
            Array.Sort(m);
            List<List<int>> triplets = new List<List<int>>();

            for (int i = 0; i < m.Length - 2; i++)
            {
                int sum = m[i];
                int s = i + 1, e = m.Length - 1;

                while ( s < e)
                {
                    sum = m[i] + m[s] + m[e];

                    if (sum == k)
                    {
                        List<int> t = new List<int>();
                        t.Add(m[i]);
                        t.Add(m[s]);
                        t.Add(m[e]);

                        triplets.Add(t);
                        s++;
                        e--;
                    }
                    else if (sum < k)
                    {
                        s++;
                    }
                    else if (sum > k)
                    {
                        e--;
                    }
                }
            }

            return triplets;
        }
    }
}
