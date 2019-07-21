using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewPreparation.Problems
{
    class BSTFromSortedArray
    {
        public BSTNode<int> head;

        public BSTFromSortedArray()
        {
            this.head = null;
        }

        private BSTNode<int> createMinimalBST(int[] arr, int start, int end)
        {
            if (start > end)
                return null;

            int mid = (start + end) / 2;

            BSTNode<int> n = new BSTNode<int>(arr[mid]);
            n.left = this.createMinimalBST(arr, start, mid - 1);
            n.right = this.createMinimalBST(arr, mid + 1, end);

            return n;
        }

        public void createMinBSTFromArray(int[] arr)
        {
            this.head = this.createMinimalBST(arr, 0, arr.Length-1);
        }
    }

    public class BSTNode<T>
    {
        public T data;
        public BSTNode<T> left;
        public BSTNode<T> right;

        public BSTNode()
        {
            this.left = null;
            this.right = null;
        }

        public BSTNode(T value)
        {
            this.data = value;
            this.left = null;
            this.right = null;
        }

        public void walkTree()
        {
            Console.Write(this.data.ToString() + ", ");
            if (this.left != null)
                this.left.walkTree();

            

            if (this.right != null)
                this.right.walkTree();

            
        }
    }
}
