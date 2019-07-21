using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewPreparation.DataStructures
{
    public class StackWithMin
    {
        public NodeWithMin head;

        public int count;

        public StackWithMin()
        {
            this.head = null;
            count = 0;
        }

        public void push(int data)
        {
            int minVal = Math.Min(data, this.min());
            NodeWithMin node = new NodeWithMin(data, minVal);
            node.next = this.head;

            this.head = node;
            this.count++;
        }

        public int min()
        {
            if (this.head == null)
                return Int16.MinValue;
            else
                return this.peek().min;
        }

        public NodeWithMin pop()
        {
            NodeWithMin node = this.head;
            if (this.head != null)
            {
                this.head = this.head.next;
                node.next = null;
                this.count--;
            }

            return node;
        }

        public NodeWithMin peek()
        {
            return this.head;
        }

    }
}
