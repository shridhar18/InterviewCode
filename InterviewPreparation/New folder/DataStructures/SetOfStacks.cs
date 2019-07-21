using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewPreparation.DataStructures
{
    class SetOfStacks
    {
        public List<DataStructures.Stack<int>> stacks = new List<Stack<int>>();
        public int capacity;

        public SetOfStacks(int capacity)
        {
            this.capacity = capacity;
        }

        public Stack<int> getLastStack()
        {
            if (this.stacks.Count == 0)
                return null;

            return this.stacks[this.stacks.Count - 1];
        }

        public void push(int v)
        {
            Stack<int> st = this.getLastStack();
            if (st != null && st.count != this.capacity)
                st.push(v);
            else
            {
                st = new Stack<int>();
                st.push(v);

                this.stacks.Add(st);
            }
        }

        public GenericNode<int> pop()
        {
            Stack<int> st = this.getLastStack();
            GenericNode<int> node = null;

            if (st != null)
                node =  st.pop();

            if (st.count == 0)
                this.stacks.RemoveAt(this.stacks.Count-1);

            return node;
        }

        public GenericNode<int> popAt(int stkIndex)
        {
            if (stkIndex > this.stacks.Count)
                return null;
            if (stkIndex == this.stacks.Count)
                return this.pop();

            Stack<int> st = this.stacks[stkIndex - 1];
            int inx = stkIndex;
            GenericNode<int> node = st.pop();

            while (inx < this.stacks.Count)
            {
                Stack<int> st1 = this.stacks[inx];

                st.push(st1.popAt(1).data);

                st = st1;
                ++inx;
            }

            return node;
        }
    }
}
