using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewPreparation.DataStructures
{
    class BinaryTreeV0<T> where T: IComparable<T>
    {
        public T data;
        public BinaryTreeV0<T> leftTree;
        public BinaryTreeV0<T> rightTree { get; set; }

        public BinaryTreeV0(T data)
        {
            this.data = data;
            this.leftTree = null;
            this.rightTree = null;
        }

        public void Insert(T item)
        {
            T cNode = this.data;
            if (cNode.CompareTo(item) > 0)
            {
                if (this.leftTree == null)
                {
                    this.leftTree = new BinaryTreeV0<T>(item);
                }
                else
                {
                    this.leftTree.Insert(item);
                }
            }
            else
            {
                if (this.rightTree == null)
                {
                    this.rightTree = new BinaryTreeV0<T>(item);
                }
                else
                {
                    this.rightTree.Insert(item);
                }
            }
        }

        public void walkTree()
        {
            if (this.leftTree != null)
                this.leftTree.walkTree();

            Console.Write(this.data.ToString() +", ");

            if (this.rightTree != null)
                this.rightTree.walkTree();
        }

        public bool isBalanced()
        {
            if (this.checkHeight(this) == -1)
                return false;
            else
                return true;
        }

        public int checkHeight(BinaryTreeV0<T> bTree)
        {
            if (bTree == null)
                return 0;

            int leftHeight = this.checkHeight(bTree.leftTree);
            if (leftHeight == -1)
                return -1;

            int rightHeight = this.checkHeight(bTree.rightTree);
            if (rightHeight == -1)
                return -1;

            int heightDiff = leftHeight - rightHeight;

            if (heightDiff > 1 || heightDiff < -1)
                return -1;

            return (rightHeight > leftHeight ? rightHeight : leftHeight) + 1;
        }

        public bool contains(T value)
        {
            BinaryTreeV0<T> b = this;

            while (b != null)
            {
                if (b.data.CompareTo(value) == 0)
                    return true;
                else if (b.data.CompareTo(value) > 0)
                    b = b.leftTree;
                else if (b.data.CompareTo(value) < 0)
                    b = b.rightTree;
            }

            return false;
        }

        public bool remove(T value)
        {
            if (this == null)
                return false;
            BinaryTreeV0<T> current = this;
            BinaryTreeV0<T> parent = null;

            int result = current.data.CompareTo(value);

            while (result != 0)
            {
                if (result > 0)
                {
                    parent = current;
                    current = current.leftTree;
                }
                else if (result < 0)
                {
                    parent = current;
                    current = current.rightTree;
                }

                if (current == null)
                    return false;
                else
                    result = current.data.CompareTo(value);
            }

            // CASE I : if no right child
            if (current.rightTree == null)
            {
                if (parent == null)
                {
                    this.data = current.data;
                    this.leftTree = current.leftTree;
                    this.rightTree = current.rightTree;
                }
                else
                {
                    if (parent.data.CompareTo(current.data) > 0)
                    {
                        parent.leftTree = current.leftTree;
                    }
                    else
                    {
                        parent.rightTree = current.leftTree;
                    }
                }
            }

            //Case II: single right child
            else if (current.rightTree.leftTree == null)
            {
                if (parent == null)
                {
                    this.data = current.rightTree.data;
                    this.leftTree = current.leftTree;
                    this.rightTree = current.rightTree.rightTree;
                }
                else
                {
                    if (parent.data.CompareTo(current.data) > 0)
                    {
                        parent.leftTree = current.rightTree;
                        current.rightTree.leftTree = current.leftTree;
                    }
                    else
                    {
                        parent.rightTree = current.rightTree;
                        current.rightTree.leftTree = current.leftTree;
                    }
                }
            }

            // CASE III : current child has left child
            else if (current.rightTree.leftTree != null)
            {
                BinaryTreeV0<T> leftMostChild = current.rightTree.leftTree, leftMostParent = current.rightTree;
                while (leftMostChild.leftTree != null)
                {
                    leftMostParent = leftMostChild;
                    leftMostChild = leftMostChild.leftTree;
                }

                if (parent == null)
                {
                    leftMostParent.leftTree = leftMostChild.rightTree;
                    this.data = leftMostChild.data;
                    this.leftTree = current.leftTree;
                    this.rightTree = current.rightTree;
                }
                else
                {
                    leftMostParent.leftTree = leftMostChild.rightTree;
                    leftMostChild.leftTree = current.leftTree;
                    leftMostChild.rightTree = current.rightTree;

                    if (parent.data.CompareTo(current.data) > 0)
                    {
                        parent.leftTree = leftMostChild;
                    }
                    else
                    {
                        parent.rightTree = leftMostChild;
                    }
                }
            }
            return true;

        }
    }
}
