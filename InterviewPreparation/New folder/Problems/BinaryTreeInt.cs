using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterviewPreparation.DataStructures;

namespace InterviewPreparation.Problems
{
    class BinaryTreeInt: BinaryTree<int>
    {
        public void findSum(TreeNode<int> n, int sum, int[] path, int level)
        {
            if (n == null)
                return;

            path[level] = n.data;
            int t = 0;

            for (int i = level; i >= 0; i--)
            {
                t += path[i];
                if (t == sum)
                    this.printPath(path, i, level);
            }

            findSum(n.children[0], sum, path, level + 1);
            findSum(n.children[1], sum, path, level + 1);

        }

        public void findPaths(int sum)
        {
            int depth = this.depth(this.head);
            int[] path = new int[depth];
            this.findSum(this.head, sum, path, 0 );

        }

        public void printPath(int[] path, int s, int e)
        {
            for (int i = s; i <= e; i++)
            {
                Console.Write("->" + path[i]);
            }
            Console.WriteLine();
        }
    }
}
