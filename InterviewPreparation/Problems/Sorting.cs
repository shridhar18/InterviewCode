using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewPreparation.Problems
{
    class Sorting
    {

        public void print(int[] arr)
        {
            LinkedList<int> ls = new LinkedList<int>();

            List<int> li = new List<int>();
           

            for (int a = 0; a < arr.Length; a++)
            {
                Console.Write(arr[a] + "->");
            }
        }

        // Merge Sort
        public void mergeSortRecursive(int[] arr)
        {
            int[] helper = new int[arr.Length];
            mergeSort(arr, helper, 0, arr.Length-1);

            print(arr);
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
                if (help[left] <= help[right])
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
                arr[curr] = help[j];
                curr++;
            }
        }

        // Quick Sort
        public void quickSorting(int[] arr)
        {
            quickSort(arr, 0, arr.Length-1);
            print(arr);
        }

        void quickSort(int[] arr, int left, int right)
        {
            int index = partition(arr, left, right);
            if (left < index - 1)
            {
                quickSort(arr, left, index - 1);
            }
            if (index < right)
            {
                quickSort(arr, index, right);
            }
        }

        int partition(int[] arr, int left, int right)
        {
            int pivot = arr[(left + right) / 2];

            while(left <= right)
            {
                while (arr[left] < pivot) left++;

                while (arr[right] > pivot) right--;

                if (left <= right)
                {
                    swap(arr, left, right);
                    left++;
                    right--;
                }
            }

            return left;
        }

        void swap(int[] arr, int l, int r)
        {
            int t = arr[l];
            arr[l] = arr[r];
            arr[r] = t;
        }

        // Radix sort
        void countingSort(int[] arr, int e)
        {
            int[] help = new int[arr.Length];
            int[] c = new int[10];

            for (int i = 0; i < arr.Length; i++)
            {
                int t = (arr[i] / e) % 10;
                c[t]++;
            }

            for (int i = 1; i < 10; i++)
            {
                c[i] += c[i - 1];
            }

            for (int i = arr.Length - 1; i >= 0; i--)
            {
                int t = (arr[i] / e) % 10;
                c[t]--;
                help[c[t]] = arr[i];
            }

            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = help[i];
            }
        }

        int findMax(int[] arr)
        {
            int max = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if(max < arr[i])
                max = arr[i];
            }

            return max;
        }

        public void RadixSort(int[] arr)
        {
            int m = findMax(arr);
            for (int i = 0 ; m > 0;  m = m/10, i++)
            {
                countingSort(arr, (int)Math.Pow(10,i));
            }

            print(arr);
        }

        //public void Merging two unsorted arrays in sorted order(int[] arr)
        //{
        //    int m = findMax(arr);
        //    for (int i = 0; m > 0; m = m / 10, i++)
        //    {
        //        countingSort(arr, (int)Math.Pow(10, i));
        //    }

        //    print(arr);
        //}

    }
}
