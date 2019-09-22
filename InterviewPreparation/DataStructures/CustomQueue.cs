using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewPreparation.DataStructures
{
    class CustomQueue<T>
    {
        public GenericNode<T> head;
        public GenericNode<T> tail;

        public int count;

        public CustomQueue()
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
            if (this.head != null)
            {
                this.head = this.head.next;
                this.count--;
            }
            return this.head;
        }
    }
}
