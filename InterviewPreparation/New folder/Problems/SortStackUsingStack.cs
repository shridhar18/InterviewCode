using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewPreparation.Problems
{
    class SortStackUsingStack
    {
        Stack<int> st;

        public SortStackUsingStack()
        {
            st = new Stack<int>(10);
            st.Push(10);
            st.Push(1);
            st.Push(140);
            st.Push(103);
            st.Push(17);
            st.Push(18);
            st.Push(23);
            st.Push(1078);
            st.Push(104);
            st.Push(100);
        }

        public Stack<int> sortStack()
        {
            Stack<int> x = this.st;
            Stack<int> y = new Stack<int>();

            while (x.Count > 0)
            {
                int t = x.Pop();

                if (y.Count == 0 || y.Peek() >= t)
                {
                    y.Push(t);
                }
                else if (y.Peek() < t)
                {
                    while (y.Count != 0 && y.Peek() < t)
                    {
                        x.Push(y.Pop());
                    }
                    y.Push(t);
                }
            }

            return y;
        }

        public void printStack(Stack<int> a)
        {
            while (a.Count != 0)
            {
                Console.Write("->"+ a.Pop());
            }
        }
    }
}
