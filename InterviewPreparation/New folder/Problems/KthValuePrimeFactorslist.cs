using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewPreparation.Problems
{
    class KthValuePrimeFactorslist
    {
        List<int> lst;
        Queue<int>[] q = new Queue<int>[3];

        public KthValuePrimeFactorslist()
        {
            lst = new List<int>();
            lst.Add(1);

            q[0] = new Queue<int>();
            q[0].Enqueue(3);
            q[1] = new Queue<int>();
            q[1].Enqueue(5);
            q[2] = new Queue<int>();
            q[2].Enqueue(7);
        }

        public int findKthVlaue(int k)
        {
            int c = 1;
            int minVal = 1;
            while (c < k)
            {
                int minValQ = this.minValuedQ();
                minVal = q[minValQ].Dequeue();
                lst.Add(minVal);
                c++;

                Console.Write("->" + minVal);
                if (minValQ == 0)
                {
                    q[0].Enqueue(minVal * 3);
                    q[1].Enqueue(minVal * 5);
                    q[2].Enqueue(minVal * 7);
                }
                else if (minValQ == 1)
                {
                    q[1].Enqueue(minVal * 5);
                    q[2].Enqueue(minVal * 7);
                }
                else if (minValQ == 2)
                {
                    q[2].Enqueue(minVal * 7);
                }
            }

            return minVal;
        }

        public int minValuedQ()
        {
            int a = q[0].Peek();
            int b = q[1].Peek();
            int c = q[2].Peek();

            int val = a;
            int nQ = 0;
            if (val > b)
            {
                val = b;
                nQ = 1;
            }

            if (val > c)
            {
                nQ = 2;
            }

            return nQ;
        }
        

    }
}
