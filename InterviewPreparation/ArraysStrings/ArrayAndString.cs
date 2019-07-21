using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace InterviewPreparation.ArraysStrings
{
    class ArrayAndString
    {
        public static bool HasuniqueCharacters(string s)
        {
            bool[] asi = new bool[256];
            foreach (char c in s)
            {
                int value = (int)c;
                if (asi[value])
                {
                    return false;
                }
                else
                {
                    asi[value] = true;
                }
            }

            //Hashtable hs = new Hashtable();
            //ArrayList ar = new ArrayList();
            //foreach (char c in s)
            //{
            //    if (!hs.ContainsKey(c))
            //    {
            //        //!ar.Contains(c)
            //        ar.Add(c);
            //        hs.Add(c, 0);
            //    }
            //    else
            //    {
            //        return false; 
            //    }
            //}
            return true;
        }

        public static string ReverseString(char[] input, int start, int end)
        {
            //char[] result = new char[input.Length];
            //for (int i = input.Length - 1, j=0; i >= 0; i--, j++)
            //{
            //    result[j] = input[i];
            //}

            //char[] result = new char[end - start];
            for (int i = start, j = end; i <= (end + start) / 2; i++, j--)
            {
                char temp = input[i];
                input[i] = input[j];
                input[j] = temp;
            }

            //return input;
            return new string(input);
        }

        public static string RemoveDuplicateChar(string input)
        {
            string result = "";
            if (input == null) return "";
            result = result + input[0];

            for (int i = 0; i < input.Length; i++)
            {
                bool flag = true;
                for (int j = 0; j < result.Length; j++)
                {
                    if (input[i] == result[j])
                    {
                        flag = false;
                        break;
                    }
                }
                if (flag) result = result + input[i];
            }
            return result;
        }

        //both words should have the same length n char
        public static bool IsAnagrams(string input1, string input2)
        {
            int[] char1 = new int[256];
            int[] char2 = new int[256];
            if (input1.Length != input2.Length) return false;
            if (input1 == null || input2 == null) return false;

            if (input1.Length < 2) return false;

            for (int i = 0; i < input1.Length; i++)
            {
                char1[input1[i]]++;
                char2[input2[i]]++;
            }

            for (int i = 0; i < 256; i++)
            {
                if (char1[i] != char2[i])
                {
                    return false;
                }
            }

            return true;
        }

        public static char getMaxOccuringChar(String str)
        {
            //most repeated character 
            // Create array to keep the count of 
            // individual characters and  
            // initialize the array as 0 
            int[] count = new int[256];

            // Construct character count array 
            // from the input string. 
            int len = str.Length;
            for (int i = 0; i < len; i++)
                count[str[i]]++;

            int max = -1; // Initialize max count 
            char result = ' '; // Initialize result 

            // Traversing through the string and  
            // maintaining the count of each character 
            for (int i = 0; i < len; i++)
            {
                if (max < count[str[i]])
                {
                    max = count[str[i]];
                    result = str[i];
                }
            }

            return result;
        }

        /// <summary>
        /// Replce Spce with %20
        /// </summary>
        /// <param name="input1"></param>
        /// <returns></returns>
        public static string ReplaceSpaces(string input1)
        {
            int i = 0;
            int j = 0;
            int t = 0;

            foreach (char s in input1)
            {
                if (s == ' ')
                {
                    t = t + 2;
                }
            }

            char[] c = new char[input1.Length + t];

            while (j < input1.Length)
            {
                if (input1[j] == ' ')
                {
                    c[i] = '%';
                    ++i;
                    c[i] = '2';
                    ++i;
                    c[i] = '0';

                }
                else
                {
                    c[i] = input1[j];
                }
                ++i;
                j++;
            }

            return new string(c);
        }

        public static string ReplaceSpaces2(string input1)
        {
            int newlength = 0;
            //find total length
            for (int i = 0; i < input1.Length; i++)
            {
                if (input1[i] == ' ') {
                    newlength = newlength + 2;
                }
            }

            newlength = newlength + input1.Length;

            char[] c = new char[newlength];

            newlength = 0;
            for (int i = 0; i < input1.Length; i++)
            {
                if (input1[i] != ' ')
                {
                    c[newlength] = input1[i];
                    newlength++;
                }
                else
                {
                    c[newlength] = '0';
                    newlength++;
                    c[newlength] = '2';
                    newlength++;
                    c[newlength] = '%';
                    newlength++;
                }
            }

            int[,] mat = {{10, 20, 30, 40},
                          {15, 25, 35, 45},
                          {27, 29, 37, 48},
                          {32, 33, 39, 50},
                          {36, 37, 41, 55} };

            Searching2DSortedMatrix(mat, 29);
            
            return new string(c);
        }
        
        public static void rotateMatrix90(int[,] matrix, int n)
        {
            for (int layer = 0; layer < n / 2; ++layer)
            {
                int first = layer;
                int last = n - 1 - layer;

                for (int i = first; i < last; ++i)
                {
                    int offset = i - first;
                    // save top 
                    int top = matrix[first, i];
                    // left -> top II 
                    matrix[first, i] = matrix[last - offset, first];
                    // bottom -> left 
                    matrix[last - offset, first] = matrix[last, last - offset];
                    // right -> bottom 
                    matrix[last, last - offset] = matrix[i, last];
                    // top -> right 
                    matrix[i, last] = top;
                }
            }

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }
        }

        public static void rotateMatrix90(int[,] matrix)
        {
            int[,] result = new int[matrix.GetLength(0), matrix.GetLength(1)];


            int col = matrix.GetLength(1) - 1;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int row = 0;
                for (int j = 0; j < matrix.GetLength(0); j++)
                {
                    result[row, col] = matrix[i, j];
                    ++row;
                }
                --col;
            }

            //print (optional)
            //for (int i = 0; i < matrix.GetLength(0); i++)
            //{
            //    for (int j = 0; j < matrix.GetLength(1); j++)
            //    {
            //        Console.Write(result[i, j] + " ");
            //    }
            //    Console.WriteLine();
            //}
        }

        public static void rotateMatrix90WithLAyer(int[,] matrix, int layer)
        {
            if (layer > matrix.GetLength(0)) layer = matrix.GetLength(0);

            int[,] result = new int[matrix.GetLength(0), matrix.GetLength(1)];

            int col = layer - 1;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int row = 0;
                for (int j = 0; j < matrix.GetLength(0); j++)
                {
                    if (col >= 0 && row <= layer - 1)
                    {
                        result[row, col] = matrix[i, j];
                    }
                    else
                    {
                        result[i, j] = matrix[i, j];
                    }
                    ++row;
                }
                --col;
            }

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(result[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
        public static void rotateMatrix_90(int[,] matrix, int n)
        {
            for (int layer = 0; layer < n / 2; ++layer)
            {
                int first = layer;
                int last = n - 1 - layer;

                for (int i = first; i < last; ++i)
                {
                    int offset = i - first;
                    // save top 
                    int top = matrix[first, i];
                    // left -> top II 
                    matrix[first, i] = matrix[last - offset, first];
                    // bottom -> left 
                    matrix[last - offset, first] = matrix[last, last - offset];
                    // right -> bottom 
                    matrix[last, last - offset] = matrix[i, last];
                    // top -> right 
                    matrix[i, last] = top;
                }
            }

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }
        }

        public static void setZeros(int[,] matrix)
        {
            int[] row = new int[matrix.GetLength(0)];
            int[] column = new int[matrix.GetLength(1)];
            // Store the row and column index with value 0 
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == 0)
                    {
                        row[i] = 1;
                        column[j] = 1;
                    }
                }
            }
            // Set arr[i][j] to 0 if either row i or column j has a 0 
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if ((row[i] == 1 || column[j] == 1))
                    {
                        matrix[i, j] = 0;
                    }
                }
            }

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }
        }

        public static bool isRotation(string str1, string str2)
        {
            if (str1.Length != str2.Length) return false;
            if ((str1 + str2).IndexOf(str2) > -1) return true;

            return false;

        }

        public static bool Searching2DSortedMatrix(int[,] mat, int x)
        {
            int i = 0;
            int j = mat.GetLength(1) - 1;

            while (i < mat.GetLength(0) && j >= 0)
            {
                if (mat[i, j] == x)
                {
                    Console.WriteLine($"found {i}, {j} ");
                    return true;
                }
                else if (mat[i, j] > x)
                {
                    j--;
                }
                else
                {
                    i++;
                }
            }

            Console.WriteLine("Number not found");

            return false;
        }

        private static bool findsumofPairElementOfArray_Sorted()
        {
            //it is sorted
            //It can be done by quardratic or Binary (O(Log (N)))
            int[] num1 = new int[] { 1, 3, 5, 7, 9 };
            int[] num2 = { 1, 3, 3, 4, 6, 7, 9, 12 };
            int[] num3 = { 1, 3, 3, 4, 4 };
            int sum = 8;

            int low = 0;
            int heigh = num3.Length - 1;
            //Linear, the efficient way
            while (low < heigh)
            {
                if (num3[low] + num3[heigh] == sum)
                {
                    return true;
                }
                if (num3[low] + num3[heigh] > sum)
                    heigh--;
                else
                    low++;
            }

            //if not sorted then sort first and then search that that is n log(n)
            //what is better way to find for unsorted array
            return false;
        }

        private static bool findsumofPairElementOfArray_UnSorted()
        {
            //unSorted list
            int[] num1 = new int[] { 3, 1, 7, 5, 9 };
            int[] num2 = { 6, 4, 3, 4, 7, 9, 12 };
            int[] num3 = { 4, 3, 3, 4 };
            HashSet<int> hs = new HashSet<int>();
            int sum = 8;
            int lastone = 0;
            //Linear
            for (int i = 0; i < num2.Length; i++)
            {
                if (num2[0] > sum) return false;
                if (hs.Contains(num2[i]))
                {
                    if (hs.Contains(num2[i]) && num2[i] != lastone)
                    {
                        return true;
                    }
                }
                else
                {
                    hs.Add(sum - num2[i]);
                    lastone = sum - num2[i];
                }
            }
            return false;
        }

        public static int BinarySearchIterativeSorted_Recursive(int[] inputArray, int key, int min, int max)
        {
            //Sorted list
            //O (Log n);
            int mid = (min + max) / 2;

            if (key == inputArray[mid])
                return mid++;
            if (key < inputArray[mid])
            {
                mid--;
                return BinarySearchIterativeSorted_Recursive(inputArray, key, min, mid);
            }
            mid++;
            return BinarySearchIterativeSorted_Recursive(inputArray, key, mid, max);
        }

        public static int[] MergeTwoSortedArraysIntoOneSortedAArray(int[] arr1, int[] arr2)
        {
            int[] res = new int[arr1.Length + arr2.Length];
            int i = 0, j = 0, k = 0;
            while (i < arr1.Length && j < arr2.Length)
            {
                if (arr1[i] < arr2[j])
                {
                    res[k] = arr1[i];
                    i++;
                    k++;
                }
                else
                {
                    res[k] = arr2[j];
                    j++;
                    k++;
                }
            }

            while (i < arr1.Length)
            {
                res[k] = arr1[i++];
                k++;
            }
            while (j < arr2.Length)
            {
                res[k] = arr2[j++];
                k++;
            }

            return res;
        }

        public static int[] allNegativeCharactersLeftAndPositiveRight(int[] arr)
        {
            int i = 0;
            int[] res = new int[arr.Length];
            int j = 0;
            while (i < arr.Length)
            {
                if (arr[i] < 0)
                {
                    res[j] = arr[i];
                    j++;
                }
                i++;
            }
            i = 0;
            while (j < res.Length && i < arr.Length)
            {
                if (arr[i] >= 0)
                {
                    res[j] = arr[i];
                    j++;
                }
                i++;
            }
            return res;
        }

        public static int[] Segregate0sonleftsideand1sonrightsideofthearray(int[] arr)
        {
            int i = 0;
            int[] res = new int[arr.Length];
            int j = 0;
            //One Way
            //while (i < arr.Length)
            //{
            //    if (arr[i] == 0)
            //    {
            //        res[j] = arr[i];
            //        j++;
            //    }
            //    i++;
            //}
            //while (j < res.Length)
            //{
            //    res[j] = 1;
            //    j++;
            //}
            //Second Way
            int k = arr.Length - 1;
            while (i < arr.Length)
            {
                if (arr[i] == 1)
                {
                    res[k] = arr[i];
                    k--;
                }
                i++;
            }
            return res;
        }

        public static bool findPairDifference(int[] arr, int n)
        {
            //Sample
            //new int[] { 9, 29, 10, 2, 50, 24, 100 }, 50)
            int i = 0;
            int j = 1;
            while (i < arr.Length && j < arr.Length)
            {
                if (i != j && arr[j] - arr[i] == n)
                {
                    Console.WriteLine(arr[i] + " & " + arr[j]);
                    return true;
                }
                else if (arr[j] - arr[i] < n)
                {
                    j++;
                }
                else
                {
                    i++;
                }
            }

            //for (int i = 0; i < arr.Length; i++)
            //{
            //    for (int j = 1; j < arr.Length; j++)
            //    {
            //        if (arr[i] - arr[j] == n)
            //        {
            //            return true;
            //        }
            //    }
            //}

            //int re = 0;
            //Hashtable hs = new Hashtable();
            //for (int i = 0; i < arr.Length; i++)
            //{
            //    re = n - arr[i]; 
            //    if (hs.ContainsValue(re))
            //    {
            //        return true;
            //    }
            //    else
            //    {
            //        hs.Add(i, arr[i]);
            //    }
            //}

            return false;
        }

        public static bool findPairSum_unSorted(int[] arr, int sum)
        {
            //arr = new int[] { 1, -1, 25, 25, 27, 4, 8};
            //arr = new int[] { -1, 25, 24, 2, 35, 15 };
            arr = new int[] { 2, 25, 10, 35, -1, 5, 10, -6, 15, -4, 4 };
            sum = 11;
            
            //Find Difference of 2 numbers
            Dictionary<int, int> di = new Dictionary<int, int>();
            int i = 0;
            if (arr[i] == sum || arr[i] > sum) return false;
            int first = 0;
            int second = 0;
            while (i < arr.Length)
            {
                if (!di.ContainsValue(arr[i]) && !di.ContainsKey(arr[i]))
                {
                    if ((arr[i] - sum) < 0)
                    {
                        di.Add(arr[i], -(arr[i] - sum));
                    }
                    else {
                        di.Add(arr[i], arr[i] - sum);
                    }
                    
                }
                else if (di.ContainsValue(arr[i]))
                {
                    first = arr[i];
                    second = di.FirstOrDefault(x => x.Value == arr[i]).Key;
                    return true;
                }
                i++;
            }

            //Find Sum of 2 numbers
            di = new Dictionary<int, int>();
            i = 0;
            if (arr[i] == sum || arr[i] > sum) return false;
            first = 0;
            second = 0;
            while (i < arr.Length)
            {
                if (!di.ContainsValue(arr[i]) && !di.ContainsKey(arr[i]))
                {
                    di.Add(arr[i], sum - arr[i]);
                }
                else if (di.ContainsValue(arr[i]))
                {
                    first = arr[i];
                    second = di.FirstOrDefault(x => x.Value == arr[i]).Key;
                    return true;
                }
                i++;
            }

            return false;
        }
        
        public static int LargestSumContiguousSubarray(int[] a)
        {
            int max = 0;
            int sum = 0;

            foreach (int item in a)
            {
                sum = sum + item;
                if (sum > max) max = sum;
                if (sum < 0) sum = 0;
            }

            return max;
        }

        public static int FinalSum(int[] a)
        {
            //Problem is not known
            int tempSum = 0;
            int finalSum = 0;

            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] > 0)
                {
                    tempSum = a[i] + tempSum;
                }
                else
                {
                    if (tempSum > finalSum)
                    {
                        finalSum = tempSum;
                    }
                }

            }

            return finalSum;
        }

        public static char[] reversestringwithoutSpecialChar(char[] str)
        {
            // Initialize left and right pointers  
            int r = str.Length - 1, l = 0;

            // Traverse string from both ends until  
            // 'l' and 'r'  
            while (l < r)
            {
                // Ignore special characters  
                if (!char.IsLetter(str[l]))
                    l++;
                else if (!char.IsLetter(str[r]))
                    r--;

                // Both str[l] and str[r] are not spacial  
                else
                {
                    char tmp = str[l];
                    str[l] = str[r];
                    str[r] = tmp;
                    l++;
                    r--;
                }
            }
            return str;
        }

        public static string reversestringwithoutSpecialChar2() {
            String str = "a,b$c";
            char[] res = new char[str.Length];
            char[] special = new char[]{ '$', ',', '*', '@', '#', '%', '&'};

            int k = 0;
            bool iscontinue = false;
            for (int i=str.Length-1; i >= 0;  i--)
            {
                iscontinue = false;
                for (int j = 0; j < special.Length; j++)
                {
                    if (str[i] == special[j])
                    {
                        res[i] = str[i];
                        iscontinue = true;
                        k++;
                        break;
                    }
                }
                if (iscontinue) continue;
                res[k] = str[i];
                k++;
            }
            reversestringwithoutSpecialChar3();
            return new string(res);
        }

        public static string reversestringwithoutSpecialChar3()
        {
            String str = "a,b$c";
            char[] chars = str.ToCharArray();
            int l = 0;
            int r = chars.Length-1;
            char temp;
            while (l < r)
            {
                if (!char.IsLetterOrDigit(chars[l]))
                {
                    l++;
                }
                else if (!char.IsLetterOrDigit(chars[r]))
                {
                    r++;
                }
                else
                {
                    temp = chars[l];
                    chars[l] = chars[r];
                    chars[r] = temp;
                    l++;
                    r--;
                }
                
            }

            return new string(chars);
        }
    }

    public class Node
    {
        public int data;
        public Node left, right;

        public Node(int item)
        {
            data = item;
            left = right = null;
        }
    }

    public class BinaryTree
    {
        //Root of the Binary Tree  
        public Node root;
        /* can give min and max value according to your code or  
        can write a function to find min and max value of tree. */

        /* returns true if given search tree is binary  
         search tree (efficient version) */
        public virtual bool BST
        {
            get
            {
                return isBSTUtil(root, int.MinValue, int.MaxValue);
            }
        }

        /* Returns true if the given tree is a BST and its  
          values are >= min and <= max. */
        public virtual bool isBSTUtil(Node node, int min, int max)
        {
            /* an empty tree is BST */
            if (node == null)
            {
                return true;
            }

            /* false if this node violates the min/max constraints */
            if (node.data < min || node.data > max)
            {
                return false;
            }

            /* otherwise check the subtrees recursively  
            tightening the min/max constraints */
            // Allow only distinct values  
            return (isBSTUtil(node.left, min, node.data - 1) && isBSTUtil(node.right, node.data + 1, max));
        }

        /* Driver program to test above functions */
        //public static void Main(string[] args)
        //{
        //    BinaryTree tree = new BinaryTree();
        //    tree.root = new Node(4);
        //    tree.root.left = new Node(2);
        //    tree.root.right = new Node(5);
        //    tree.root.left.left = new Node(1);
        //    tree.root.left.right = new Node(3);

        //    if (tree.BST)
        //    {
        //        Console.WriteLine("IS BST");
        //    }
        //    else
        //    {
        //        Console.WriteLine("Not a BST");
        //    }
        //}
    }

}
