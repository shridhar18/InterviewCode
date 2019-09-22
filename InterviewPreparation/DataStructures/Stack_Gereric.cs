using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewPreparation.DataStructures
{
    public class Stack_Gereric<T>
    {
        GenericNode<T> head;
        public int count;

        public Stack_Gereric()
        {
            head = null;
            count = 0;
        }

        //prepend 
        public void Push(T data)
        {
            GenericNode<T> node = new GenericNode<T>(data);
            node.next = head;
            head = node;

            count++;
        }

        /// <summary>
        /// Append. (Usefull enque in case queq)
        /// </summary>
        /// <param name="data"></param>
        public void Append(T data)
        {
            if (head == null)
            {
                head = new GenericNode<T>(data);
            }
            else
            {
                GenericNode<T> current = head;
                //while (current != null)
                //{
                //    if (current.next == null)
                //    {
                //        current.next = new GenericNode<T>(data);
                //        break;
                //    }
                //    current = current.next;
                //}
                while (current.next !=null)
                {
                    current = current.next;
                }
                current.next = new GenericNode<T>(data);
            }

            count++;
        }

        //Return next node(the same can be used for dequeue)
        public void POP ()
        {
            ////GenericNode<T> node = head;
            //if(head != null)
            //{
            //    head = head.next;
            //    //node.next = null;
            //    count--;
            //}

            //return head; 
            //Or
            //if (head != null && head.next != null)
            //{
            //    head = head.next;
            //    count--;
            //}
            //Or
            GenericNode<T> current = head;
            if (current != null && current.next != null)
            {
                current = current.next;
                count--;
            }
            head = current;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x">position of node. 1 is being first node, n is last node</param>
        /// <returns></returns>
        public void POPAT(int x)
        {
            GenericNode<T> current = head;
            int pointer = count;

            while (current != null & pointer - 1 > x)
            {
                current = current.next;
                pointer--;
            }
            if (current != null && current.next != null)
            {
                current.next = current.next.next;
                count--;
            }
            //GenericNode<T> node = head;
            //int pointer = count;

            //while (node != null && pointer - 1 > x)
            //{
            //    pointer--;
            //    node = node.next;
            //}

            //if (node == null && node.next == null) return null;
            //GenericNode<T> n = node.next;
            //node.next = node.next.next;
            //count--;

            //return n;
        }

        public GenericNode<T> Peek()
        {
            return head;
        }    
    }
}
