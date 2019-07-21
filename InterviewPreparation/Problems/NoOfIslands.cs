using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewPreparation.Problems
{
    class NoOfIslands
    {
        int Rows;
        int Cols;
        int[,] place;

        public NoOfIslands()
        {
            this.Rows = 5;
            this.Cols = 5;
            this.place = new int[,] {   {1, 1, 0, 0, 0},
                                        {0, 1, 0, 0, 1},
                                        {1, 0, 0, 1, 1},
                                        {0, 1, 0, 0, 0},
                                        {1, 0, 1, 0, 1}};
        }

        public int countIslands()
        {
            int count = 0;
            bool[,] visited = new bool[this.Rows, this.Cols];

            for (int i = 0; i < this.Rows; i++)
            {
                for (int j = 0; j < this.Cols; j++)
                {
                    if (this.place[i, j] == 1 && !visited[i, j])
                    {
                        this.DFS(i, j, visited);
                        count++;
                    }
                }
            }

            return count;
        }

        void DFS(int r, int c, bool[,] visited)
        {
            int[] rI = new int[] { -1, -1, -1, 0, 0, 1, 1, 1 };
            int[] cI = new int[] { -1, 0, 1, -1, 1, -1, 0, 1 };

            visited[r, c] = true;

            for (int k = 0; k < 8; k++)
            {
                if (this.isSafe(r + rI[k], c + cI[k], visited))
                {
                    this.DFS(r + rI[k], c + cI[k], visited);
                }
            }
        }

        bool isSafe(int r, int c, bool[,] visited)
        {
            return r >= 0 && c >= 0 && r < this.Rows && c < this.Cols && !visited[r, c] && this.place[r, c] == 1;
        }
    }
}
