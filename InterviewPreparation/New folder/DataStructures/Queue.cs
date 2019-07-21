using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewPreparation.DataStructures
{
    class Queue<T>
    {
        public GenericNode<T> head;
        public GenericNode<T> tail;

        public int count;

        public Queue()
        {
            this.head = null;
            this.tail = null;
            count = 0;
        }

        public void enqueue(T data)
        {
            GenericNode<T> node = new GenericNode<T>(data);
            if (this.head == null)
            {
                this.head = node;
                this.tail = node;
            }
            else
            {
                this.tail.next = node;
                this.tail = node;
            }

            this.count++;
        }

        public GenericNode<T> dequeue()
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
    }
}
