using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewPreparation.Problems
{
    class Sorting
    {

        public void mergeSortRecursive(int[] arr)
        {
            int[] helper = new int[arr.Length];
            mergeSort(arr, helper, 0, arr.Length);

            for (int a = 0; a < arr.Length; a++)
            {
                Console.Write(arr[a] + "->");
            }
        }

        void mergeSort(int[] arr, int[] help, int low, int high)
        {
            if (low < high)
            {
                int mid = (low + high) / 2;
                mergeSort(arr, help, low, mid);
                mergeSort(arr, help, mid + 1, high);

                merge(arr, help, low, mid, high);
            }
        }

        void merge(int[] arr, int[] help, int low, int mid, int high)
        {
            for (int i = low; i <= high; i++)
            {
                help[i] = arr[i];
            }

            int left = low;
            int right = mid + 1;
            int curr = low;

            while (left <= mid && right <= high)
            {
                if (help[left] < help[right])
                {
                    arr[curr] = help[left];
                    left++;
                } 
                else
                {
                    arr[curr] = help[right];
                    right++;
                }
                curr++;
            }

            for (int j = left; j <= mid; j++)
            {
                arr[curr] = help[curr];
                curr++;
            }

        }


    }
}
