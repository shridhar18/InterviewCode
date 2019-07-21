using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewPreparation.DataStructures
{
    class BinaryTree<T> where T : IComparable<T>
    {
        public TreeNode<T> head { get; set; }

        public BinaryTree()
        {
            this.head = null;
        }

        public void Insert(T item)
        {
            TreeNode<T> n = new TreeNode<T>(item);

            System.Collections.Queue q = new System.Collections.Queue();
            if (this.head == null)
            {
                this.head = n;
                return;
            }
            q.Enqueue(this.head);
            while (q.Count != 0)
            {
                TreeNode<T> node = (TreeNode<T>)q.Dequeue();
                if (node.children[0] == null)
                {
                    node.children[0] = n;
                    return;
                }
                else
                    q.Enqueue(node.children[0]);

                if (node.children[1] == null)
                {
                    node.children[1] = n;
                    return;
                }
                else
                    q.Enqueue(node.children[1]);
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

        public void preorderTraversal(TreeNode<T> node)
        {
            Console.Write(node.data.ToString() + ", ");

            if (node.children[0] != null)
                this.preorderTraversal(node.children[0]);

            if (node.children[1] != null)
                this.preorderTraversal(node.children[1]);
        }

        public void BFSTraversal()
        {
            System.Collections.Queue q = new System.Collections.Queue();
            if (this.head == null)
                return;

            q.Enqueue(this.head);

            while (q.Count != 0)
            {
                TreeNode<T> node = (TreeNode<T>)q.Dequeue();
                Console.Write(node.data + ", ");

                if (node.children[0] != null)
                    q.Enqueue(node.children[0]);
                if (node.children[1] != null)
                    q.Enqueue(node.children[1]);
            }
        }

        //public TreeNode<T> inorderSuccessor(TreeNode<T> n)
        //{
        //    if (n == null)
        //        return null;

        //    if (n.children[1] != null)
        //    {
        //        n = n.children[1];
        //        while (n.children[0] != null)
        //            n = n.children[0];

        //        return n;
        //    }
        //    else
        //    {

        //    }
        //}

        // print all paths with sum x

        public int depth(TreeNode<T> n)
        {
            if (n == null)
                return 0;
            else
                return 1 + Math.Max(this.depth(n.children[0]), this.depth(n.children[1]));
        }

        
    }
}
