using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterviewPreparation.DataStructures;

namespace InterviewPreparation.Problems
{
    class SubTree<T> where T: IComparable<T>
    {
        public bool containsTree(TreeNode<T> lt, TreeNode<T> st)
        {
            if (st == null)
                return true;

            return this.subTree(lt, st);
        }

        public bool subTree(TreeNode<T> t1, TreeNode<T> t2)
        {
            if (t1 == null)
                return false;
            if (t1.data.CompareTo(t2.data) == 0 && this.matchTree(t1, t2))
                return true;

            return this.subTree(t1.children[0], t2) || this.subTree(t1.children[1], t2);
        }

        public bool matchTree(TreeNode<T> t1, TreeNode<T> t2)
        {
            if (t1 == null && t2 == null)
                return true;
            else if (t1 == null || t2 == null)
                return false;
            else if (t1.data.CompareTo(t2.data) != 0)
                return false;

            return this.matchTree(t1.children[0], t2.children[0]) && this.matchTree(t1.children[1], t2.children[1]);
        }
    }
}
