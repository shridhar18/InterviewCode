using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewPreparation.DataStructures
{
    class LinkedList
    {
        public Node head;

        public int length;

        public LinkedList()
        {
            head = null;
            length = 0;
        }

        public void printAll()
        {
            Node current = this.head;
            while (current != null)
            {
                Console.Write(current.Value + ", ");
                current = current.Next;
            }
            Console.WriteLine();
        }

        public void print(Node n)
        {
            Node current = n;
            while (current != null)
            {
                Console.Write(current.Value + ", ");
                current = current.Next;
            }
            Console.WriteLine();
        }

        public void insert(int id)
        {
            Node node = new Node(id);
            if (this.head == null)
                head = node;
            else
            {
                Node current = head;
                while (current.Next != null)
                {
                    current = current.Next;
                }

                current.Next = node;
            }

            this.length++;
        }

        public void insert(Node node)
        {
            if (this.head == null)
                head = node;
            else
            {
                Node current = head;
                while (current.Next != null)
                {
                    current = current.Next;
                }

                current.Next = node;
            }

            this.length++;
        }

        public Node delete(int id)
        {
            Node current = this.head;
            if (current == null)
                return null;
            else if (current.Value == id)
            {
                this.head = current.Next;
                this.length--;
                return current;
            }

            Node previous = null;
            while (current.Next != null)
            {
                previous = current;
                current = current.Next;
                if (current.Value == id)
                {
                    previous.Next = current.Next;
                    this.length--;
                    return current;
                }                    
            }

            return null;
        }

        public void deleteDupsNoMemory()
        {
            Node c = this.head;

            while (c != null)
            {
                Node next = c;
                while (next != null && next.Next != null)
                {
                    if (c.Value == next.Next.Value)
                    {
                        next.Next = next.Next.Next;
                        this.length--;
                    }
                    next = next.Next;
                }

                c = c.Next;
            }
        }

        public void deleteDupsWithMemory()
        {
            Node current = this.head;

            Hashtable hashTable = new Hashtable();

            while (current != null && current.Next != null)
            {
                hashTable.Add(current.Value, true);
                if (hashTable.ContainsKey(current.Next.Value))
                {
                    current.Next = current.Next.Next;
                    this.length--;
                }

                current = current.Next;
            }
        }

        public Node kthElementFromLast(int k)
        {
            Node kth = this.head, current = this.head;
            int i = 0;
            while (i != k && current != null)
            {
                current = current.Next;
                i++;
            }

            while (current != null)
            {
                current = current.Next;
                kth = kth.Next;
            }

            if (i < k)
                return null;

            return kth;
        }

        public bool deleteNode(Node n)
        {
            if (n == null || n.Next == null)
                return false;

            n.Value = n.Next.Value;
            n.Next = n.Next.Next;
            return true;
        }

        public Node partitionX(Node head, int x)
        {
            Node bXH = null;
            Node bX = null;
            Node aXH = null;
            Node aX = null;

            while (head != null)
            {
                Node nxt = head;
                head = head.Next;
                nxt.Next = null;


                if (nxt.Value < x)
                {
                    if (bXH == null)
                    {
                        bXH = nxt;
                        bX = nxt;
                    }
                    else
                    {
                        bX.Next = nxt;
                        bX = nxt;
                    }
                }
                else
                {
                    if (aXH == null)
                    {
                        aXH = nxt;
                        aX = nxt;
                    }
                    else
                    {
                        aX.Next = nxt;
                        aX = nxt;
                    }
                }
            }

            if (bXH == null)
                bX = bXH = aXH;
            else
                bX.Next = aXH;

            this.head = bXH;

            return bXH;
        }

        // need to implement if unequal lists
        public Node addLists(Node n1, Node n2, int c)
        {
            if (n1 == null && n2 == null && c == 0)
                return null;

            
            int value = c;
            if (n1 != null)
                value += n1.Value;
            if (n2 != null)
                value += n2.Value;

            Node result = new Node(value % 10);

            if (n1 != null || n2 != null)
            {
                Node next = addLists(n1 == null? null: n1.Next, n2 == null? null:n2.Next, value >= 10 ? 1:0);

                result.Next = next;
            }

            return result;

        }

        // need to implement if unequal lists
        public int addListsInReverse(Node n1, Node n2, Node result)
        {
            Node prev = new Node(0);
            int carry = 0;

            

            if (n1.Next != null || n2.Next != null)
            {
                if (result == null)
                    this.head = prev;
                else
                    result.Next = prev;

                carry = addListsInReverse(n1 == null ? null : n1.Next, n2 == null ? null : n2.Next, prev);

                if (n1 != null)
                    carry += n1.Value;
                if (n2 != null)
                    carry += n2.Value;

                prev.Value = carry % 10;

            }

            if (n1.Next == null && n2.Next == null)
            {
                if (n1 != null)
                    carry += n1.Value;
                if (n2 != null)
                    carry += n2.Value;

                prev.Value = carry % 10;

                result.Next = prev;
            }

            return carry >= 10 ? 1 : 0;

        }

        public Node hasLoop(Node start)
        {
            Node slow = start;
            Node fast = start;

            while (fast != null && fast.Next != null)
            {
                slow = slow.Next;
                fast = fast.Next.Next;

                if (slow == fast)
                    break;
                 
            }

            if (fast == null || fast.Next == null)
                return null;

            slow = start;
            while (slow != fast)
            {
                slow = slow.Next;
                fast = fast.Next;
            }

            return fast;
        }

        public bool isPalindromeIterative(Node head)
        {
            Node s = head;
            Node f = head;

            Stack<int> stk = new Stack<int>();

            while (f != null && f.Next != null)
            {
                stk.push(s.Value);
                s = s.Next;
                f = f.Next.Next;
            }

            if (f != null)
            {
                s = s.Next;
            }

            while (s != null)
            {
                if (stk.pop().data != s.Value)
                    return false;

                s = s.Next;
            }

            return true;
        }

        public bool isPalindromeRecursive()
        {
            ResultPalnidrome r = LinkedList.recursivePalin(this.head, this.length);

            return r.result;
        }

        public static ResultPalnidrome recursivePalin(Node n, int len)
        {
            if (n == null || len == 0)
                return new ResultPalnidrome(null, true);
            else if (len == 1)
                return new ResultPalnidrome(n.Next, true);
            else if (len == 2)
                return new ResultPalnidrome(n.Next.Next, n.Value == n.Next.Value);

            ResultPalnidrome res = LinkedList.recursivePalin(n.Next, len-2);

            if (!res.result || res.node == null)
                return res;
            else
            {
                res.result = res.node.Value == n.Value;
                res.node = res.node.Next;

                return res;
            }
        }
    }

    public class ResultPalnidrome
    {
        public Node node;
        public bool result;

        public ResultPalnidrome(Node n, bool b)
        {
            this.node = n;
            this.result = b;
        }
    }




    public class Node
    {
        public Node Next { get; set; }
        public int Value { get; set; }

        public Node(int value)
        {
            this.Next = null;
            this.Value = value;
        }
    }  
}
