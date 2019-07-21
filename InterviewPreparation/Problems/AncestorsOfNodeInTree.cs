using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewPreparation.Problems
{
    class TNode
    {
        public int data;
        public List<TNode> children;

        public TNode(int data)
        {
            this.data = data;
            this.children = new List<TNode>();
        }

        public void addChild(int c)
        {
            this.children.Add(new TNode(c));
        }
    }

    class AncestorsOfNodeInTree 
    {
        public TNode head;

        public bool printAncestors(TNode node, int t)
        {
            if (node == null)
                return false;
            if (node.data == t)
                return true;

            foreach (TNode tn in node.children)
            {
                if (this.printAncestors(tn, t))
                {
                    Console.Write(node.data + "->"); 
                    return true;
                }
            }

            return false;
        }
    }
}
