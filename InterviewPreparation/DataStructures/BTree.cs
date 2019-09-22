using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewPreparation.DataStructures
{
    public class TNode
    {
        public int item;
        public TNode leftc;
        public TNode rightc;

        public TNode(int data)
        {
            this.item = data;
        }
        public void display()
        {
            Console.Write("[");
            Console.Write(item);
            Console.Write("]");
        }
    }
    public class Tree
    {
        //https://www.sanfoundry.com/csharp-program-binary-search-tree-linked-list/
        public TNode root;

        //Recursive usinh while
        public void Insert(int id)
        {
            TNode newTNode = new TNode(id);
            //newTNode.item = id;
            if (root == null)
                root = newTNode;
            else
            {
                TNode current = root;
                TNode parent;
                while (true)
                {
                    parent = current;
                    if (id < current.item)
                    {
                        current = current.leftc;
                        if (current == null)
                        {
                            parent.leftc = newTNode;
                            return;
                        }
                    }
                    else
                    {
                        current = current.rightc;
                        if (current == null)
                        {
                            parent.rightc = newTNode;
                            return;
                        }
                    }
                }
            }
        }

        //OR By recusive method way.
        public void InsertByRec(int id)
        {
            // 1. If the tree is empty, return a new, single TNode 
            if (root == null)
            {
                root = new TNode(id);
                return;
            }
            // 2. Otherwise, recur down the tree 
            InsertTRec(root, new TNode(id));
        }

        private void InsertTRec(TNode root, TNode newTNode)
        {
            if (root == null)
                root = newTNode;

            if (newTNode.item < root.item)
            {
                if (root.leftc == null)
                    root.leftc = newTNode;
                else
                    InsertTRec(root.leftc, newTNode);

            }
            else
            {
                if (root.rightc == null)
                    root.rightc = newTNode;
                else
                    InsertTRec(root.rightc, newTNode);
            }
        }

        public void Preorder(TNode Root)
        {
            if (Root != null)
            {
                Console.Write(Root.item + " ");
                Preorder(Root.leftc);
                Preorder(Root.rightc);
            }
        }
        public void Inorder(TNode Root)
        {
            if (Root != null)
            {
                Inorder(Root.leftc);
                Console.Write(Root.item + " ");
                Inorder(Root.rightc);
            }
        }
        public void Postorder(TNode Root)
        {
            if (Root != null)
            {
                Postorder(Root.leftc);
                Postorder(Root.rightc);
                Console.Write(Root.item + " ");
            }
        }
    }

    //public class BTNode
    //{
    //    public int Data { get; set; }
    //    public BTNode Left { get; set; }
    //    public BTNode Right { get; set; }
    //    public BTNode()
    //    {

    //    }
    //    public BTNode(int data)
    //    {
    //        this.Data = data;
    //    }
    //}
    //public class BTree
    //{
    //    private BTNode _root;
    //    public BTree()
    //    {
    //        _root = null;
    //    }
    //    public void Insert(int data)
    //    {
    //        // 1. If the tree is empty, return a new, single TNode 
    //        if (_root == null)
    //        {
    //            _root = new BTNode(data);
    //            return;
    //        }
    //        // 2. Otherwise, recur down the tree 
    //        InsertRec(_root, new BTNode(data));
    //    }
    //    private void InsertRec(BTNode root, BTNode newTNode)
    //    {
    //        if (root == null)
    //            root = newTNode;

    //        if (newTNode.Data < root.Data)
    //        {
    //            if (root.Left == null)
    //                root.Left = newTNode;
    //            else
    //                InsertRec(root.Left, newTNode);

    //        }
    //        else
    //        {
    //            if (root.Right == null)
    //                root.Right = newTNode;
    //            else
    //                InsertRec(root.Right, newTNode);
    //        }
    //    }
    //    private void DisplayTree(BTNode root)
    //    {
    //        if (root == null) return;

    //        DisplayTree(root.Left);
    //        System.Console.Write(root.Data + " ");
    //        DisplayTree(root.Right);
    //    }
    //    public void DisplayTree()
    //    {
    //        DisplayTree(_root);
    //    }

    //}
}
