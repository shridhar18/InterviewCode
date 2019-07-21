using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewPreparation.DataStructures
{
    public class Stack<T>
    {
        public GenericNode<T> head;

        public int count;

        public Stack()
        {
            this.head = null;
            count = 0;
        }

        public void push(T data)
        {
            GenericNode<T> node = new GenericNode<T>(data);
            node.next = this.head;

            this.head = node;
            this.count++;
        }

        public GenericNode<T> pop()
        {
            GenericNode<T> node = this.head;
            if (this.head != null)
            {
                this.head = this.head.next;
                node.next = null;
                this.count--;
            }
                
            return node;
        }

        public GenericNode<T> popAt(int x)
        {
            int s = this.count;
            GenericNode<T> node = this.head;

            while (node != null && s-1 > x)
            {
                node = node.next;
                s--;
            }

            if (node == null && node.next == null)
                return null;
            GenericNode<T> n = node.next;
            node.next = node.next.next;
            this.count--;

            return n;
        }

        public GenericNode<T> peek()
        {
            return this.head;
        }
    }
    
}
