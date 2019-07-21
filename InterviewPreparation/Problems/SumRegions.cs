using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewPreparation.Problems
{
    class SumRegions
    {
        public int[,] sumRegions;

        public SumRegions(int[,] matrix) {
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            
            sumRegions = new int[n+1, m+1];
            int sum = 0;

            for (int i = 0; i < n; i++)
            {
                sum = 0;
                for (int j = 0; j < m; j++)
                {
                    sum += matrix[i,j];
                    if (i >= 1 && j >= 1)
                    {
                        sumRegions[i, j] = sum + sumRegions[i - 1, j] - sumRegions[i - 1, j - 1];
                    }
                    else
                    {
                        sumRegions[i, j] = sum + sumRegions[i - 1, j];
                    }
                }
            }
        }
    
        public int getSumRegion(int row1, int col1, int row2, int col2) {
            return sumRegions[row2, col2] - sumRegions[row1, col2] - sumRegions[row2, col1] + sumRegions[row1, col1];
        }
    }
}
