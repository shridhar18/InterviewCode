using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewPreparation.DataStructures
{
    public class TreeNode<T>
    {
        public T data;
        public List<TreeNode<T>> children;

        public TreeNode()
        {
            children = new List<TreeNode<T>>(2);
        }

        public TreeNode(T value)
        {
            this.data = value;
            this.children = new List<TreeNode<T>>(2);
            this.children.Add(default(TreeNode<T>));
            this.children.Add(default(TreeNode<T>));
        }

        public void addChild(T value)
        {
            TreeNode<T> ch = new TreeNode<T>(value);

            this.children.Add(ch);
        }
    }
}
