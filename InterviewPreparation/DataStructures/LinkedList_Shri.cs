using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewPreparation.DataStructures
{
    public class LinkedList_New
    {
        public Node head;
        public Node head2;

        public void append(int data)
        {
            if (head == null)
            {
                head = new Node(data);
                return;
            }

            Node current = head;
            while (current.Next != null)
            {
                current = current.Next;
            }

            current.Next = new Node(data);
        }
        public void append(Node node)
        {
            if (head == null) { head = node; return; }
            Node cuurent = head;
            while (cuurent.Next != null)
            {
                cuurent = cuurent.Next;
            }
            cuurent.Next = node;
        }

        public void preappend(int data)
        {
            //Push new node
            Node current = new Node(data); ;
            current.Next = head;
            head = current;
        }

        public void delete(int data)
        {
            if (head == null) return;
            if (head.Value == data)
            {
                //very first node
                head = head.Next;
                return;
            }

            Node current = head;
            while (current.Next != null)
            {
                if (current.Next.Value == data)
                {
                    current.Next = current.Next.Next;
                    //current.Next = null; if want stop link  here
                    // return head if return type
                    return;
                }
                current = current.Next;
            }
        }

        public void delete()
        {
            if (head != null)
            {
                head = head.Next;
            }
        }

        public int nodeCount()
        {
            int count = 0;
            if (head == null) return 0;

            count = 1;
            Node current = head;
            while (current.Next != null)
            {
                count++;
                current = current.Next;
            }

            return count;
        }

        internal virtual void remove_duplicates()
        {
            //O(N2)//Remove without memory
            //Node nd1 = null, nd2 = null;
            //nd1 = head;
            //while (nd1 != null && nd1.Next !=null)
            //{
            //    nd2 = nd1;
            //    while (nd2 != null && nd2.Next != null)
            //    {
            //        if (nd1.Data == nd2.Next.Data)
            //        {
            //            nd2.Next = nd2.Next.Next;
            //        }
            //        else
            //        {
            //            nd2 = nd2.Next;
            //        }
            //    }
            //    nd1 = nd1.Next;
            //}
            //O(N)//Remove with memory

            Node current = head;
            Node pre = null;
            Hashtable hs = new Hashtable();

            while (current != null)
            {
                if (hs.ContainsKey(current.Value))
                {
                    pre.Next = current.Next;
                }
                else
                {
                    hs.Add(current.Value, current.Value);
                    pre = current;

                }
                current = current.Next;
            }
        }

        public Node FindNthToLastElement(Node node, int n)
        {
            //Implement an algorithm to find the nth to last element of a singly linked list 
            Node current = head;
            Node follower = head;
            if (current == null || current.Next == null) return current;

            //NthtoLast
            for (int i = 0; i < n; i++)
            {
                if (current.Next != null)
                {
                    current = current.Next;
                }
                else if (current == null) return null;
            }
            //NthfromLast
            follower = head;
            int n2 = this.nodeCount();
            for (int i = 0; i < n2 - n; i++)
            {
                if (follower.Next != null) follower = current.Next;
                else if (follower == null) return null;
            }

            return follower;
        }

        public bool deleteNode(Node n)
        {
            if (n == null || n.Next == null) return false;

            n.Value = n.Next.Value;
            n.Next = n.Next.Next;
            return true;
        }

        public void SortLinkList()
        {
            //Bouble Sort
            head = new Node(10);
            head.Next = new Node(4);
            head.Next.Next = new Node(3);
            head.Next.Next.Next = new Node(15);
            head.Next.Next.Next.Next = new Node(10);
            head.Next.Next.Next.Next.Next = new Node(25);

            Node i, j;
            int temp = 0;
            for (i = head; i.Next != null; i = i.Next)
            {
                for (j = i.Next; j != null; j = j.Next)
                {
                    if (i.Value > j.Value)
                    {
                        temp = i.Value;
                        i.Value = j.Value;
                        j.Value = temp;
                    }
                }
            }

            //seocnd way
            //Node newnode1, newnode2;
            //newnode1 = head;
            //int temp1 = 0;
            //int count = this.nodeCount();
            //for (int k = 0; k < count; k++)
            //{
            //    newnode2 = newnode1;
            //    for (int l = k + 1; l < count; l++)
            //    {
            //        newnode2 = newnode2.Next;
            //        if (newnode1.Value > newnode2.Value)
            //        {
            //            temp1 = newnode1.Value;
            //            newnode1.Value = newnode2.Value;
            //            newnode2.Value = temp1;
            //        }
            //    }
            //    newnode1 = newnode1.Next;
            //}

        }

        public bool mergeNodes(Node n1, Node n2)
        {
            head = new Node(10);
            head.Next = new Node(4);
            head.Next.Next = new Node(3);
            head.Next.Next.Next = new Node(15);
            head.Next.Next.Next.Next = new Node(10);
            head.Next.Next.Next.Next.Next = new Node(25);

            head2 = new Node(2);
            head2.Next = new Node(9);
            head2.Next.Next = new Node(7);
            head2.Next.Next.Next = new Node(5);
            head2.Next.Next.Next.Next = new Node(11);
            head2.Next.Next.Next.Next.Next = new Node(6);

            while (head2 != null)
            {
                Node nd = new Node(head2.Value);
                nd.Next = head;
                head = nd;
                head2 = head2.Next;
            }
            return true;
        }

        public Node addTwoNumbers(Node l1, Node l2)
        {
            //LinkedList_New trn1 = new LinkedList_New();
            //trn1.append(new Node(1));
            //trn1.append(2);
            //trn1.append(3);

            //LinkedList_New trn2 = new LinkedList_New();
            //trn2.append(new Node(4));
            //trn2.append(5);
            //trn2.append(6);

            //LinkedList_New trn3 = new LinkedList_New();
            //trn3.addTwoNumbers(trn1.head, trn2.head);

            Node dummyHead = new Node(0);
            Node p = l1, q = l2, curr = dummyHead;
            int carry = 0;
            while (p != null || q != null)
            {
                int x = (p != null) ? p.Value : 0;
                int y = (q != null) ? q.Value : 0;
                int sum = carry + x + y;
                carry = sum / 10;
                curr.Next = new Node(sum % 10);
                curr = curr.Next;
                if (p != null) p = p.Next;
                if (q != null) q = q.Next;
            }
            if (carry > 0)
            {
                curr.Next = new Node(carry);
            }
            return dummyHead.Next;
        }
    }
    //public class Node {
    //    public Node Next { get; set; }
    //    public int Data { get; set; }

    //    public Node(int data)
    //    {
    //        this.Next = null;
    //        this.Data = data;
    //    }
    //}

}
