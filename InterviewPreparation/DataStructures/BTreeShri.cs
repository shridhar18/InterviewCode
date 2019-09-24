using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewPreparation.DataStructures
{
    public class TNode_S<T>
    {
        public T Data { get; set; }
        public TNode_S<T> Left { get; set; }
        public TNode_S<T> Right { get; set; }

        public TNode_S()
        {
        }

        public TNode_S(T data)
        {
            this.Data = data;
        }

    }
    public class Tree_S
    {
        public TNode_S<int> root;

        public void Insert(int data)
        {
            if (root== null)
            {
                root = new TNode_S<int>(data);
                return;
            }
            InsertRec(root, new TNode_S<int>(data));
        }

        private void InsertRec(TNode_S<int> root, TNode_S<int> newNode)
        {
            if (newNode.Data < root.Data)
            {
                if (root.Left == null)
                {
                    root.Left = newNode;
                }
                else
                {
                    InsertRec(root.Left, newNode);
                }
            }
            else
            {
                if (root.Right == null)
                {
                    root.Right = newNode;
                }
                else
                {
                    InsertRec(root.Right, newNode);
                }
            }
        }

        public void Preorder(TNode_S<int> Root)
        {
            if (Root != null)
            {
                Console.Write(Root.Data + " ");
                Preorder(Root.Left);
                Preorder(Root.Right);
            }
        }
        public void Inorder(TNode_S<int> Root)
        {
            if (Root != null)
            {
                Inorder(Root.Left);
                Console.Write(Root.Data + " ");
                Inorder(Root.Right);
            }
        }
        public void Postorder(TNode_S<int> Root)
        {
            if (Root != null)
            {
                Postorder(Root.Left);
                Postorder(Root.Right);
                Console.Write(Root.Data + " ");
            }
        }
    }
}