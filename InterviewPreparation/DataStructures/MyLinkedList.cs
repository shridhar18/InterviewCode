using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewPreparation.DataStructures
{
    public class MyLinkedList
    {
        public MyNode head;
        public void append(int value)
        {
            //Check if head is null
            if (head ==null)
            {
                head = new MyNode(value);
                return;
            }

            //Add next node
            MyNode current = head;
            while (current.Next != null)
            {
                current = current.Next;
            }
            current.Next = new MyNode(value); //new node
        }

        public void prepend(int value)
        {
            MyNode prenode  = new MyNode(value);
            prenode.Next = head;
            head = prenode;
        }

        public void delete(int value)
        {
            if (head == null) return;
            if(head.Value == value)
            {
                head = head.Next;
                return;
            }

            MyNode current = head;
            while (current.Next != null)
            {
                if(current.Next.Value == value)
                {
                    current.Next = current.Next.Next;
                    return;
                }
                current = current.Next;
            }
        }

        public int nodeCount()
        {
            int count = 1;
            MyNode current = head;
            while (current.Next !=null)
            {
                ++count;
                current = current.Next;
            }
            return count;
        }
    }


    public class MyNode
    {
        public MyNode Next {get; set;}

        public int Value { get; set; }

        public MyNode(int value)
        {
            this.Next = null;
            this.Value = value;
        }

    }


    public class Stack
    {
        public MyNode top;

        internal virtual void pop()
        {
            if (top != null)
            {
                //MyNode item = top.Value;
                top = top.Next;
            }
        }
        internal virtual void Push(int value)
        {
            //Last in first out
            MyNode t = new MyNode(value);
            t.Next = top;
            top = t;
        }

        internal virtual void Append(int value)
        {
            //Like Enqueue (First in first out)
            MyNode current = this.top;
            if (current == null) this.top = new MyNode(value);
            else
            {
                while (current.Next != null)
                {
                    current = current.Next;
                }
                current.Next = new MyNode(value);
            }
        }
    }
}
