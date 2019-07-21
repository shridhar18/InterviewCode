using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewPreparation.ArraysStrings
{
    class StringProblems
    {
        //swap number wiyhout using any additional variable
        public static int[] swapnumbers(int[] num)
        {
            for (int i=0; i < num.Length -1; i+=2)
            {
                num[i] = num[i] + num[i + 1];
                num[i + 1] = num[i] - num[i + 1];
                num[i] = num[i] - num[i + 1];
            }

            return num;

        }

        //FibonacciSequence
        public static int FibonacciSequence(int num)
        {
            //First Solution
            //int pre = 1;
            //int ne = 1;
            //int fb = 1;
            //for (int i = 2; i < num; i++)
            //{
            //    fb = pre + ne;
            //    pre = ne;
            //    ne = fb;
            //}

            //return fb;

            //Second
            if (num <= 1)
                return num;

            return FibonacciSequence(num - 2) + FibonacciSequence(num - 1);

        }
        // Implement an algorithm to determine if a string has all unique characters. 
        // What if you cannot use additional data structures?
        public static bool hasUniqueCharacters(string s)
        {
            //if (s.Length > 256)
            //    return false;

            //char[] c = s.ToArray();
            //Boolean[] b = new Boolean[256];

            //for (int i = 0; i < c.Length; i++)
            //{
            //    int value = (int)c[i];
            //    if (b[value])
            //    {
            //        return false;
            //    }
            //    else
            //    {
            //        b[value] = true;
            //    }
            //}
            //Seond Solution
            if (s.Length > 256 || s == null) return false;
            Boolean[] chars = new Boolean[256];

            foreach (var item in s)
            {
                int asc = (int)item;
                if (chars[asc]) return false;
                else chars[asc] = true;
            }
            return true;
        }

        public static bool isPermutation_WithSort(string s1, string s2)
        {
            if (s1.Length != s2.Length)
                return false;
         
            char[] c1 = s1.ToArray();
            char[] c2 = s2.ToArray();

            Array.Sort(c1);
            Array.Sort(c2);

            return String.Equals(new String(c1), new String(c2));
        }

        public static bool isPermutation_WithOutSort(string s1, string s2)
        {
            if (s1.Length != s2.Length)
                return false;

            char[] c1 = s1.ToArray();
            char[] c2 = s2.ToArray();

            int[] letter = new int[256];

            for (int i = 0; i < c1.Length; i++)
            {
                int ch1 = (int)c1[i];
                int ch2 = (int)c2[i];

                letter[ch1]++;
                letter[ch2]--;

                //Console.WriteLine(letter[ch1]);
            }

            for (int i = 0; i < letter.Length; i++)
            {
                if (letter[i] != 0)
                    return false;
            }

            return true;
        }

        public static char[] replaceSpaces(char[] c, int len)
        {
            int sc = 0;
            for (int i = 0; i < len; i++)
            {
                if (c[i] == ' ')
                    sc++;
            }

            if (sc == 0)
                return c;

            int newC = len + sc * 2;

            for (int i = newC - 1, j = len - 1; i >= 0; i--, j--)
            {
                if (c[j] == ' ')
                {
                    c[i] = '0';
                    c[--i] = '2';
                    c[--i] = '%';
                }
                else
                {
                    c[i] = c[j];
                }
            }

            return c;
        }

        public static string compressString(string s)
        {
            char[] c = s.ToArray();
            string s2 = "";
            int count = 1;
            char pc = c[0];

            for (int i = 1; i < s.Length; i++)
            {
                if (c[i] == pc)
                    count++;
                else
                {
                    s2 += pc + count.ToString();
                    pc = c[i];
                    count = 1;
                }
            }

            s2 += pc + count.ToString();
            return s2.Length >= s.Length ? s : s2;
        }

        public static void setMatrixRowColumnZeros(int[,] m)
        {
            bool[] r = new bool[m.GetLength(0)];
            bool[] c = new bool[m.GetLength(1)];

            for (int i = 0; i < m.GetLength(0); i++)
            {
                for (int j = 0; j < m.GetLength(1); j++)
                {
                    if (m[i, j] == 0)
                    {
                        r[i] = true;
                        c[j] = true;
                    }
                }
            }

            for (int i = 0; i < m.GetLength(0); i++)
            {
                for (int j = 0; j < m.GetLength(1); j++)
                {
                    if (r[i] || c[j])
                        m[i, j] = 0;
                }
            }

            for (int i = 0; i < m.GetLength(0); i++)
            {
                for (int j = 0; j < m.GetLength(1); j++)
                {
                    Console.Write(m[i, j] + " ");
                }
                Console.WriteLine();
            }
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

        public static void rotateMatrix180(int[,] matrix, int n)
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
                    // save left
                    int left = matrix[last - offset, first];

                    // bottom -> top
                    matrix[first, i] = matrix[last, last - offset];

                    // top -> bottom
                    matrix[last, last - offset] = top;

                    // right -> left 
                    matrix[last - offset, first] = matrix[i, last];

                    // left -> right
                    matrix[i, last] = left;
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

        public static string reverseWordsString(string s)
        {
            char[] c = StringProblems.reverseString(s.ToCharArray(), 0, s.ToCharArray().Length - 1);

            if (!c.Contains(' '))
                return c.ToString();

            for (int i = 0; i < c.Length; i++)
            {
                int j = i;
                for (j = i; j < c.Length; j++)
                {
                    if (c[j] == ' ')
                        break;
                }

                c = StringProblems.reverseString(c, i, j - 1);
                i = j;
            }

            return c.ToString();
        }

        public static char[] reverseString(char[] c, int s, int e)
        {
            for (int i = s, j = e; i <= (e + s) / 2; i++, j--)
            {
                char x = c[i];
                c[i] = c[j];
                c[j] = x;
            }

            return c;
        }

        private static string reversestring2(string str)
        {
            char[] chars = str.ToCharArray();
            string str22 = "";
            for (int i = chars.Length - 1; i >= 0; i--)
            {
                str22 += chars[i];
            }

            return str22;
        }

        public static char findFirstNonRepeatedChar(string s)
        {
            char[] c = s.ToArray();
            Hashtable hashTable = new Hashtable();
            char res = ' ';

            for (int i = 0; i < c.Length; i++)
            {
                if (hashTable.ContainsKey(c[i]))
                {
                    hashTable[c[i]] = false;
                }
                else
                {
                    hashTable.Add(c[i], true);
                }
            }

            for (int i = 0; i < c.Length; i++)
            {
                if (hashTable[c[i]].Equals(true))
                {
                    res = c[i];
                    break;
                }
            }

            return res;
        }

        public static string removeSpecifiedCharsfromString(string src, string rem)
        {
            char[] r = rem.ToArray();
            Hashtable hash = new Hashtable();

            for (int i = 0; i < r.Length; i++)
            {
                if (!hash.ContainsKey(r[i]))
                {
                    hash.Add(r[i], true);
                }
            }

            char[] s = src.ToArray();
            int j = 0, k = 0;

            for (j = 0, k = 0; j < s.Length; j++)
            {
                if (!hash.ContainsKey(s[j]))
                {
                    s[k++] = s[j];
                }
            }
            for (; k < s.Length; k++)
            {
                s[k] = ' ';
            }
            return new string(s).TrimEnd();
        }

        public static int convertStringToInt(string s)
        {
            char[] c = s.ToArray();
            int value = 0;
            for (int i = 0; i < c.Length; i++)
            {
                if (c[i] == '-' && i == 0)
                    continue;
                else if (c[i] - '0' <= 9 && c[i] - '0' >= 0)
                    value = value * 10 + (c[i] - '0');
                else
                    return 0;
            }

            if (c[0] == '-')
                value *= -1;

            return value;
        }

        public static void permute(string str)
        {
            char[] inS = str.ToArray();
            int length = inS.Length;
            bool[] used = new bool[length];
            StringBuilder outS = new StringBuilder();
            StringProblems.doPermute(inS, outS, used, length, 0);
        }

        private static void doPermute(char[] ins, StringBuilder outs, bool[] used, int length, int level)
        {
            if (level == length)
            {
                Console.WriteLine(outs.ToString());
                return;
            }

            for (int i = 0; i < length; ++i)
            {
                if (used[i])
                    continue;
                outs.Append(ins[i]);
                used[i] = true;
                doPermute(ins, outs, used, length, level + 1);
                used[i] = false;
                outs.Length = outs.Length - 1;
            }
        }

        public static void combinations(string str)
        {
            int length = str.Length; char[] instr = str.ToCharArray();
            StringBuilder outstr = new StringBuilder();
            StringProblems.doCombinations(instr, outstr, length, 0, 0);
        }

        private static void doCombinations(char[] instr, StringBuilder outstr, int length, int level, int start)
        {
            for (int i = start; i < length; i++)
            {
                outstr.Append(instr[i]);
                Console.WriteLine(outstr);

                if (i < length - 1)
                {
                    doCombinations(instr, outstr, length, level + 1, i + 1);
                }

                outstr.Length = outstr.Length - 1;
            }
        }

        public static int numtoDevideToPerfectSquare(int n)
        {
            int t = n;
            int f = 2;
            int sqFactors = 1;
            int nonSqFactors = 1;
            while (t > 1)
            {
                if (t % f == 0)
                {
                    t = t / f;
                    if (t % f == 0)
                    {
                        sqFactors *= f;
                        t = t / f;
                    }
                    else
                    {
                        nonSqFactors *= f;
                    }
                }
                else
                {
                    f++;
                }
            }

            return nonSqFactors;
        }

        public static int longestCommonSubstring(string s1, string s2)
        {
            if (s1.Length == 0 || s2.Length == 0)
                return 0;

            int[,] m = new int[s1.Length, s2.Length];
            int maxLen = 0;

            for (int i = 0; i < s1.Length; i++)
            {
                for (int j = 0; j < s2.Length; j++)
                {
                    if (s1[i] != s2[j])
                        m[i, j] = 0;
                    else
                    {
                        if (i == 0 || j == 0)
                        {
                            m[i, j] = 1;
                        }
                        else
                        {
                            m[i, j] = 1 + m[i - 1, j - 1];
                        }

                        if (m[i, j] > maxLen)
                        {
                            maxLen = m[i, j];
                        }
                    }
                }
            }

            return maxLen;
        }

        public static string longestPalindrome(string s)
        {
            int min = 1;
            string palin = "";

            for (int i = 0; i < s.Length; i++)
            {
                for (int j = 1; j < s.Length - i - 1; j++)
                {
                    if (s[i] == s[s.Length - j])
                    {
                        string s1 = s.Substring(i, s.Length - j - i);
                        string s2 = new string(s1.Reverse().ToArray());

                        if (s1 == s2 && s1.Length > min)
                        {
                            palin = s1;
                            min = s1.Length;
                        }
                    }
                }
            }

            return palin;
        }

        public static List<string> getConsecutiveLettersinString(string s)
        {
            List<string> cs = new List<string>();

            for (int i = 0; i < s.Length; i++)
            {
                int k = i;
                for (int j = i + 1; j < s.Length; j++)
                {
                    if (s[k] < s[j])
                    {
                        cs.Add(s.Substring(i, j - i + 1));
                        k++;
                    }
                    else
                    {
                        break;
                    }
                }
            }
            return cs;
        }

        public static char GetMaximumConsecutiveRepeatingCharacter(string str)
        {
            int count = 0;
            char c = str[0];

            //First way
            //for (int i = 0; i < str.Length; i++)
            //{
            //    int count2 = 1;
            //    for (int j = i + 1; j < str.Length; j++)
            //    {
            //        if (str[i] != str[j])
            //        {
            //            break;
            //        }
            //        count2++;
            //    }
            //    if (count2 > count)
            //    {
            //        count = count2;
            //        c = str[i];
            //    }
            //}

            //Second way
            Hashtable hs = new Hashtable();
            foreach (var item in str)
            {
                if (hs.ContainsKey(item))
                {
                    hs[item] = (int)hs[item]+1;
                    if ((int)hs[item] > count)
                    {
                        count = (int)hs[item];
                    }
                }
                else
                {
                    hs.Add(item, 1);
                }
            }

            foreach (DictionaryEntry e in hs)
            {
                if ((int)e.Value == count)
                {
                    //get the "index" with e.Key
                    c = (char)e.Key; 
                }
            }


            return c;
        }


        public static void printMatrixSpirally(int[,] s, int n, int m)
        {
            int rS = 0, cS = 0, rL = n - 1, cL = m - 1, c = 0;

            while (rS <= rL && cS <= cL)
            {
                for (int i = cS; i <= cL; i++)
                {
                    Console.Write(s[rS, i] + "->");
                    c++;
                }
                Console.WriteLine();
                for (int i = rS + 1; i <= rL; i++)
                {
                    Console.Write(s[i, cL] + "->"); c++;
                }

                if (rL != rS)
                {
                    Console.WriteLine();
                    for (int i = cL - 1; i >= cS; i--)
                    {
                        Console.Write(s[rL, i] + "->"); c++;
                    }
                }

                if (cS != cL)
                {
                    Console.WriteLine();
                    for (int i = rL - 1; i >= rS; i--)
                    {
                        Console.Write(s[i, cS] + "->"); c++;
                    }
                }
                Console.WriteLine();
                rL--;
                rS++;
                cL--;
                cS++;
            }
            Console.WriteLine(c);
        }

        public static int maxProductSubArray(int[] a)
        {
            if (a.Length == 0)
                return 0;
            int maxPre = a[0], minPre = a[0], maxSF = a[0];
            int maxH, minH;

            for (int i = 1; i < a.Length; i++)
            {
                maxH = Math.Max(Math.Max(maxPre * a[i], minPre * a[i]), a[i]);
                minH = Math.Min(Math.Min(maxPre * a[i], minPre * a[i]), a[i]);
                maxSF = Math.Max(maxSF, maxH);
                maxPre = maxH;
                minPre = minH;
            }

            return maxSF;
        }

        public static string removeKDigitsForLeastValue(string s, int k)
        {
            if (k >= s.Length)
                return "0";
            char[] a = s.ToArray();
            for (int i = 0; i < k; i++)
            {
                int max = -1;
                int maxIndex = 0;
                for (int j = 0; j < a.Length; j++)
                {
                    if (a[j] == '-')
                        continue;
                    if (max < int.Parse(a[j].ToString()))
                    {
                        max = int.Parse(a[j].ToString());
                        maxIndex = j;
                    }
                    else
                    {
                        a[maxIndex] = '-';
                        break;
                    }

                }
            }

            string x = "";

            foreach (char c in a)
            {
                if (c != '-')
                    x = x + c.ToString();
            }

            return x;
        }

        public static string IsAnagram(string s1, string s2)//O(n) (stop->pots, silent-> listen)
        {
            if (string.IsNullOrEmpty(s1) & string.IsNullOrEmpty(s2))
            {
                return "0";
            }
            else if (s1.Length != s2.Length)
            {
                return "0";
            }
            else
            {
                char[] char1 = s1.ToLower().ToCharArray();
                char[] char2 = s2.ToLower().ToCharArray();

                s1 = s1.ToLower();
                s2 = s2.ToLower();

                foreach (char c in s1)
                {
                    if (!s2.Contains(c)) return "0";
                }

                //Array.Sort(s1.ToLower().ToCharArray());
                //Array.Sort(s2.ToLower().ToCharArray());
                //if (s1== s2) return "1";
                return "1";
            }

        }

        public static int[] BubbleSort(int[] ar)  //O(n2)
        {
            int temp = 0;
            for (int i = 0; i < ar.Length; i++)
            {
                for (int j = i + 1; j < ar.Length; j++)
                {
                    if (ar[i] > ar[j])
                    {
                        temp = ar[i];
                        ar[i] = ar[j];
                        ar[j] = temp;
                    }
                }
            }
            //for (int i = ar.Length - 1; i > 0; i--)
            //{
            //    for (int j = 0; j < i; j++)
            //    {
            //        if (ar[i] < ar[j])
            //        {
            //            temp = ar[i];
            //            ar[i] = ar[j];
            //            ar[j] = temp;
            //        }
            //    }
            //}

            return ar;
        }

        //https://leetcode.com/problems/longest-palindrome/description/
        public static string Palindrome(string s) //O(n) (redivider, deified, noon, civic, radar)
        {
            //redivider, deified, noon, civic, radar, level, rotor, kayak, reviver, racecar, redder, madam, and refer

            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] != s[s.Length - 1 - i])
                {
                    return "0";
                }
            }

            return "1";
        }

        /// <summary>
        /// String and 2nd string to match the pattern, KMP substring search
        /// </summary>
        /// <param name="text"></param>
        /// <param name="pattern"></param>
        /// <returns></returns>
        public static Boolean hasSubstringPattern(string text, string pattern)
        {
            int i = 0;
            int j = 0;
            int k = 0;
            while (i < text.Length && j < pattern.Length)
            {
                if (text[i] == pattern[j])
                {
                    i++;
                    j++;
                }
                else
                {
                    j = 0;
                    k++;
                    i = k;
                }
            }
            if (j == pattern.Length)
            {
                return true;
            }
            return false;
        }

        // print wave pattern of a given string
        // This is a modified code of
        // https://www.geeksforgeeks.org/print-concatenation-of-zig-zag-string-form-in-n-rows/
        // Function that takes string and zigzag offset
        public static char[,] PrintWavePattern(string s, int n)
        {
            // Get length of the string
            int len = s.Length;
            // Create a 2d character array
            char[,] a = new char[len, len];

            if (n < 1) return null;
            //if offset is 1
            if (n == 1)
            {
                int i = 0;
                foreach (var item in s)
                {
                    a[0, i] = item;
                    i++;
                }
                // simply print the strin and return
                return a;
            }

            // for counting the rows of the ZigZag
            //int row = 0;
            bool down = false;

            //for (int i = 0; i < len; i++)
            //{
            //    // put characters in the matrix
            //    a[row, i] = s[i];
            //    // You have reached the bottom
            //    if (row == n - 1)
            //    {
            //        down = false;
            //    }
            //    else if (row == 0)
            //    {
            //        down = true;
            //    }
            //    if (down) { row++; }
            //    else { row--; };
            //}

            int r = 0;
            char[,] b = new char[n, s.Length];
            down = false;
            for (int i = 0; i < s.Length; i++)
            {
                b[r, i] = s[i];
                if (r == n - 1)
                {
                    down = false;
                }
                else if (r ==0) down = true;
                if (down) r++; else r--;
            }

            return b;
        }
        //Recursive function to return HCF(Highest Common Factor)/gcd(Greatest Common Divisor)) of a and b for, 
        //smaller number is subtracted from a bigger number.
        public static int GCD(int a, int b)
        {
            // Everything divides 0 
            if (a == 0 || b == 0)
                return 0;
            // base case
            if (a == b)
                return a;

            // a is greater
            if (a > b) return GCD(a - b, b);
            return GCD(a, b - a);
        }

        public static int ReverseNumber(int n)
        {
            int left = n;
            int rev = 0;
            while (left > 0)
            {
                rev = rev * 10 + left % 10;
                left = left / 10;  //left = Math.floor(left / 10); 
            }
            return rev;

            //string Str, reversestring = "";
            //int Length;
            //Console.Write("Enter A String : ");
            //Str = Console.ReadLine();
            //Length = Str.Length - 1;
            //while (Length >= 0)
            //{
            //    reversestring = reversestring + Str[Length];
            //    Length--;
            //}
        }

        public static string ReverseWords(string s)
        {
            s = s.Trim();
            if (s.Length == 0) return "";
            string result = "";
            Stack st = new Stack();

            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] != ' ')
                {
                    result += s[i];
                }
                else
                {
                    if (result.Length > 0)
                    {
                        st.Push(result);
                        st.Push(" ");
                        result = "";
                    }
                }
                if (s.Length - 1 == i)
                {
                    st.Push(result);
                    result = "";
                }
            }

            while (st.Count > 0)
            {
                result += st.Pop();
            }
            return result;
        }

        public static int Fib(int n)
        {
            if (n <= 1)
            {
                return n;
            }
            else
            {
                return Fib(n - 1) + Fib(n - 2);
            }
        }

        //public static Hashtable GetCharacters(string input)
        //{
        //    Hashtable hashtable = new Hashtable();

        //    foreach (char s in input)
        //    {
        //        if (hashtable.has = "One")
        //            hashtable.Add(1, s);


        //    }

        //    return null;
        //}

        public static void GetCharacters(string input)
        {
            int[] c = new int[26];

            foreach (var s in input)
            {
                c[s - 'a']++;
            }

            int i = 'a' - 0;
            foreach (int s in c)
            {
                Console.WriteLine("{0} -> {1}", (char)i++, s);
            }

            //string input = "csharpstar";

            //while (input.Length > 0)
            //{
            //    Console.Write(input[0] + " : ");
            //    int count = 0;
            //    for (int j = 0; j < input.Length; j++)
            //    {
            //        if (input[0] == input[j])
            //        {
            //            count++;
            //        }
            //    }
            //    Console.WriteLine(count);
            //    input = input.Replace(input[0].ToString(), string.Empty);
            //}
            //Console.ReadLine();

        }

        /// <summary>
        /// Assusmeing all the string is in lower case
        /// https://www.geeksforgeeks.org/print-characters-frequencies-order-occurrence/
        /// </summary>
        /// <param name="input"></param>
        public static void PrintLettersInSortedOrder(string input)
        {
            string newIntput = input.ToLower();
            int[] c = new int[26];

            foreach (var s in newIntput)
            {
                c[s - 'a']++;
            }

            int i = 'a';
            foreach (int s in c)
            {
                Console.WriteLine("{0}: {1}", (char)i++, s);
            }
        }

        public static int[] Findstartend(int[] arr, int target)
        {
            //finish your code here
            int[] i = new int[2];
            bool flag = false;

            for (int k = 0; k < arr.Length; k++)
            {
                if (arr[k] == target && !flag)
                {
                    i[0] = k;
                    i[1] = k;
                    flag = true;
                }
                else if (arr[k] == target && flag)
                {
                    i[1] = k;
                }
            }

            return i;
        }

        public static bool FindDistinctIndices(int[] arr, int location)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("k");

            Hashtable hs = new Hashtable();
            for (int i = 0; i < arr.Length; i++)
            {
                if (!hs.ContainsKey(arr[i]))
                {
                    hs.Add(arr[i], i);
                }
                else if (i - (int)hs[arr[i]] <= location) return true;
                else
                {
                    hs[arr[i]] = i;
                }
            }
            return false;
        }

        public static int FindAndSecondMinimumElement(int[] arr)
        {
            int first = int.MaxValue;
            int second = int.MaxValue;
            if (arr.Length == 0) return 0;
            
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i]< first)
                {
                    second = first;
                    first = arr[i];
                }
                else if  (arr[i] < second && arr[i] != first)
                {
                    second = arr[i];
                }
            }
            return second; 
        }

        /// <summary>
        /// Assuming array should be sorted in order, Iterative
        /// </summary>
        /// <param name="inputArray"></param>
        /// <param name="key">find the key</param>
        /// <returns></returns>
        public static int BinarySearchIterative(int[] inputArray, int key)
        {
            int max = inputArray.Length - 1;
            int min = 0;
            Array.Sort(inputArray);

            while (min <= max)
            {
                int mid = (max + min) / 2;
                if (key == inputArray[mid])
                {
                    return ++mid;
                }
                else if (key < inputArray[mid])
                {
                    max = mid - 1;
                }
                else
                {
                    min = mid + 1;
                }
            }
            return 0;
        }
        public static int Factorial(int input)
        {
            if (input == 0)
                return 1; // Recursive break; 
            if (input < 0)
                return -1;

            return input * Factorial(input - 1);
        }


        //smallest element out of the Array
        public static int SmallestInt(int[] arr)
        {
            if (arr == null || arr.Length == 0)
                throw new Exception("arr can't be null or empty");

            int min = arr[0];
            for (int i = 1; i < arr.Length; i++)
            {
                if (arr[i] < min)
                    min = arr[i];
            }

            return min;
        }

        public static ArrayList FindSubstringIndex(string str, string subStr)
        {
            ArrayList ar = new ArrayList();
            int index1 = 0;
            int index2 = 0;
            bool flag = false;
            while (index1 < str.Length-1)
            {
                if (str[index1] == subStr[index2]) {
                    flag = false;
                    if (index2 == subStr.Length - 1)
                    {
                        ar.Add(index1 - (subStr.Length - 1));
                        index2 = 0;
                        flag = true;
                    }
                    if (!flag) index2++;
                }
                index1++;
            }
            
            return ar;
        }

        public static int[] rvereseArray(int[] arr, int start, int end)
        {
            while (start < end)
            {
                int temp = arr[start];
                arr[start] = arr[end];
                arr[end] = temp;
                start++;
                end--;
            }

            return arr;
        }

        public static bool CheckParenthesis(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return true;

            Stack<char> stack = new Stack<char>();

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '(' || input[i] == '{' || input[i] == '[')
                {
                    stack.Push(input[i]);
                }
                else if (input[i] == ')' || input[i] == '}' || input[i] == ']')
                {
                    if (stack.Count <= 0)
                        return false;

                    if (!IsMatching(stack.Pop(), input[i]))
                    {
                        return false;
                    }
                        
                }
            }

            return stack.Count > 0 ? false : true;
        }
        private static bool IsMatching(char char1, char char2)
        {
            if (char1 == '(' && char2 == ')')
                return true;
            else if (char1 == '{' && char2 == '}')
                return true;
            else if (char1 == '[' && char2 == ']')
                return true;
            else
                return false;
        }

        //internal static bool areParenthesisBalanced(string exp)
        //{
        //    /* Declare an empty character stack */
        //    Stack st = new Stack();

        //    /* Traverse the given expression to  
        //       check matching parenthesis */
        //    for (int i = 0; i < exp.Length; i++)
        //    {

        //        /*If the exp[i] is a starting  
        //          parenthesis then push it*/
        //        if (exp[i] == '{' || exp[i] == '(' || exp[i] == '[')
        //        {
        //            st.Push(exp[i]);
        //        }

        //        /* If exp[i] is an ending parenthesis  
        //           then pop from stack and check if the  
        //           popped parenthesis is a matching pair*/
        //        if (exp[i] == '}' || exp[i] == ')' || exp[i] == ']')
        //        {

        //            /* If we see an ending parenthesis without  
        //               a pair then return false*/
        //            if (st.Empty)
        //            {
        //                return false;
        //            }

        //            /* Pop the top element from stack, if  
        //               it is not a pair parenthesis of character  
        //               then there is a mismatch. This happens for  
        //               expressions like {(}) */
        //            else if (!isMatchingPair(st.Pop() , exp[i]))
        //            {
        //                return false;
        //            }
        //        }

        //    }

        //    /* If there is something left in expression  
        //       then there is a starting parenthesis without  
        //       a closing parenthesis */

        //    if (st.Empty)
        //    {
        //        return true; //balanced
        //    }
        //    else
        //    { //not balanced
        //        return false;
        //    }
        //}

        ////are matching left and right Parenthesis */
        //internal static bool isMatchingPair(char character1, char character2)
        //{
        //    if (character1 == '(' && character2 == ')')
        //    {
        //        return true;
        //    }
        //    else if (character1 == '{' && character2 == '}')
        //    {
        //        return true;
        //    }
        //    else if (character1 == '[' && character2 == ']')
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}

        public static bool ValidTicTacToe(char[,] arr, char X, char O)
        {
            Hashtable hs = new Hashtable();
            bool xflag = false;
            bool yflag = false;
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                //Case if both has win vertical
                if (arr[i,0] == X && arr[i, 1] == X && arr[i, 2] == X)
                {
                    xflag = true;
                }
                if (arr[i, 0] == O && arr[i, 1] == O && arr[i, 2] == O)
                {
                    yflag = true;
                }

                //Case if both has win horizontal
                if (arr[0, i] == X && arr[1, i] == X && arr[2, i] == X)
                {
                    xflag = true;
                }
                if (arr[0, i] == O && arr[1, i] == O && arr[2, i] == O)
                {
                    yflag = true;
                }

                //Diagonal check
                if (arr[0, 0] == X && arr[1, 1] == X && arr[2, 2] == X)
                {
                    xflag = true;
                }
                if (arr[2, 0] == O && arr[1, 1] == O && arr[0, 2] == O)
                {
                    yflag = true;
                }

            }

            if (xflag && yflag) return false;
            if (xflag && !yflag) return true;
            if (!xflag && yflag) return true;

            return false;

        }


    }
}