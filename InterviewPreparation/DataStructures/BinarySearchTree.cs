using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewPreparation.DataStructures
{
    class BinarySearchTree<T> where T : IComparable<T>
    {
        public TreeNode<T> head { get; set; }
        
        public BinarySearchTree()
        {
            this.head = null;
        }

        public void Insert(T item)
        {
            TreeNode<T> n = new TreeNode<T>(item);
            if (this.head == null)
            {
                this.head = n;
                return;
            }
                

            TreeNode<T> cNode = this.head;
            

            while (cNode != null)
            {
                if (cNode.data.CompareTo(item) >= 0)
                {
                    if (cNode.children[0] == null)
                    {
                        cNode.children[0] = n;
                        return;
                    }
                    else
                        cNode = cNode.children[0];
                }
                else if(cNode.data.CompareTo(item) < 0)
                {
                    if (cNode.children[1] == null)
                    {
                        cNode.children[1] = n;
                        return;
                    }
                        
                    else
                        cNode = cNode.children[1];
                }
            }
        }

        public void InorderTraversal(TreeNode<T> node)
        {
            if (node.children[0] != null)
                this.InorderTraversal(node.children[0]);

            Console.Write(node.data.ToString() + ", ");

            if (node.children[1] != null)
                this.InorderTraversal(node.children[1]);
        }

        public bool isBalanced()
        {
            if (this.checkHeight(this.head) == -1)
                return false;
            else
                return true;
        }

        public int checkHeight(TreeNode<T> bTree)
        {
            if (bTree == null)
                return 0;

            int leftHeight = this.checkHeight(bTree.children[0]);
            if (leftHeight == -1)
                return -1;

            int rightHeight = this.checkHeight(bTree.children[1]);
            if (rightHeight == -1)
                return -1;

            int heightDiff = leftHeight - rightHeight;

            if (heightDiff > 1 || heightDiff < -1)
                return -1;

            return (rightHeight > leftHeight ? rightHeight : leftHeight) + 1;
        }

        public bool contains(T value)
        {
            return this.containsInSubTree(this.head, value);
        }

        public bool containsInSubTree(TreeNode<T> node, T value)
        {
            TreeNode<T> b = node;

            while (b != null)
            {
                if (b.data.CompareTo(value) == 0)
                    return true;
                else if (b.data.CompareTo(value) > 0)
                    b = b.children[0];
                else if (b.data.CompareTo(value) < 0)
                    b = b.children[1];
            }

            return false;
        }

        public bool remove(T value)
        {
            if (this == null)
                return false;
            TreeNode<T> current = this.head;
            TreeNode<T> parent = null;

            int result = current.data.CompareTo(value);

            while (result != 0)
            {
                if (result > 0)
                {
                    parent = current;
                    current = current.children[0];
                }
                else if (result < 0)
                {
                    parent = current;
                    current = current.children[1];
                }

                if (current == null)
                    return false;
                else
                    result = current.data.CompareTo(value);
            }

            // CASE I : if no right child

            if (current.children[1] == null)
            {
                if (parent == null)
                {
                    this.head.data = current.data;
                    this.head.children[0] = current.children[0];
                    this.head.children[1] = current.children[1];
                }
                else
                {
                    if (parent.data.CompareTo(current.data) > 0)
                    {
                        parent.children[0] = current.children[0];
                    }
                    else
                    {
                        parent.children[1] = current.children[1];
                    }
                }
            }

            //Case II: single right child

            else if (current.children[1].children[0] == null)
            {
                if (parent == null)
                {
                    this.head.data = current.children[1].data;
                    this.head.children[0] = current.children[0];
                    this.head.children[1] = current.children[1].children[1];
                }
                else
                {
                    if (parent.data.CompareTo(current.data) > 0)
                    {
                        parent.children[0] = current.children[1];
                        current.children[1].children[0] = current.children[0];
                    }
                    else
                    {
                        parent.children[1] = current.children[1];
                        current.children[1].children[0] = current.children[0];
                    }
                }
            }

            // CASE III : current child has left child

            else if (current.children[1].children[0] != null)
            {
                TreeNode<T> leftMostChild = current.children[1].children[0], leftMostParent = current.children[1];
                while (leftMostChild.children[0] != null)
                {
                    leftMostParent = leftMostChild;
                    leftMostChild = leftMostChild.children[0];
                }

                if (parent == null)
                {
                    leftMostParent.children[0] = leftMostChild.children[1];
                    this.head.data = leftMostChild.data;
                    this.head.children[0] = current.children[0];
                    this.head.children[1] = current.children[1];
                }
                else
                {
                    leftMostParent.children[0] = leftMostChild.children[1];
                    leftMostChild.children[0] = current.children[0];
                    leftMostChild.children[1] = current.children[1];

                    if (parent.data.CompareTo(current.data) > 0)
                    {
                        parent.children[0] = leftMostChild;
                    }
                    else
                    {
                        parent.children[1] = leftMostChild;
                    }
                }
            }
            return true;

        }

        public void BFSTraversal()
        {
            System.Collections.Queue q = new System.Collections.Queue();
            if (this.head == null)
                return;

            q.Enqueue(this.head);

            while (q.Count != 0)
            {
                TreeNode<T> node = (TreeNode<T>) q.Dequeue();
                Console.Write(node.data + ", ");

                if (node.children[0] != null)
                    q.Enqueue(node.children[0]);
                if (node.children[1] != null)
                    q.Enqueue(node.children[1]);
            }
        }

        // print nodes in each level before going to their children
        public List<GenericNode<T>> LevelOrderTraversal()
        {
            List<GenericNode<T>> al = new List<GenericNode<T>>();
            System.Collections.Queue q = new System.Collections.Queue();
            if (this.head == null)
                return al;

            int level = 0;
            q.Enqueue(this.head);
            while (q.Count != 0)
            {
                level = q.Count;
                GenericNode<T> lHead = null, lCurr = null;

                while (level > 0)
                {
                    TreeNode<T> node = (TreeNode<T>)q.Dequeue();
                    GenericNode<T> n = new GenericNode<T>(node.data);

                    if (lHead == null)
                    {
                        lHead = n;
                        lCurr = n;
                    }
                    else
                    {
                        lCurr.next = n;
                        lCurr = lCurr.next;
                    }

                    if (node.children[0] != null)
                        q.Enqueue(node.children[0]);
                    if (node.children[1] != null)
                        q.Enqueue(node.children[1]);

                    level--;
                }
                al.Add(lHead);
            }

            this.printLOT(al);
            return al;

        }

        public void printLOT(List<GenericNode<T>> al)
        {
            foreach (GenericNode<T> node in al)
            {
                GenericNode<T> n = node;
                while (n != null)
                {
                    Console.Write("->" + n.data.ToString());
                    n = n.next;
                }
                Console.WriteLine();
            }
        }

        // find the common ancestor of two nodes
        public TreeNode<T> commonAncestor(TreeNode<T> node, T v1, T v2)
        {
            TreeNode<T> n = new TreeNode<T>();
            if (node == null)
                return n;
            else if ((this.containsInSubTree(node.children[0], v1) && this.containsInSubTree(node.children[1], v2)) || (this.containsInSubTree(node.children[1], v1) && this.containsInSubTree(node.children[0], v2)))
                return node;
            else if (this.containsInSubTree(node.children[0], v1) && this.containsInSubTree(node.children[0], v2))
                return this.commonAncestor(node.children[0], v1, v2);
            else if (this.containsInSubTree(node.children[1], v1) && this.containsInSubTree(node.children[1], v2))
                return this.commonAncestor(node.children[1], v1, v2);
            else
                return n;
        }

        public void morrisTravesrsal(TreeNode<T> node)
        {
            TreeNode<T> c = node;

            while (c != null)
            {
                if (c.children[0] == null)
                {
                    Console.Write(c.data + "->");
                    c = c.children[1];
                }
                else
                {
                    TreeNode<T> p = c.children[0];

                    while (p.children[1] != null && p.children[1] != c)
                    {
                        p = p.children[1];
                    }

                    if (p.children[1] == null)
                    {
                        p.children[1] = c;
                        c = c.children[0];
                    }
                    else
                     {
                        p.children[1] = null;
                        Console.Write(c.data + "->");
                        c = c.children[1];
                    }
                }
            }
        }

    }
}
