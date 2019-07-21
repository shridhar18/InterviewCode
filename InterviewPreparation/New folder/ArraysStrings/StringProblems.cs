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
        // Implement an algorithm to determine if a string has all unique characters. 
        // What if you cannot use additional data structures?
        public static bool hasUniqueCharacters(string s)
        {
            if (s.Length > 256)
                return false;

            char[] c = s.ToArray();
            Boolean[] b = new Boolean[256];

            for (int i = 0; i < c.Length; i++)
            {
                int value = (int)c[i];
                if (b[value])
                {
                    return false;
                }
                else
                {
                    b[value] = true;
                }
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
                    if (m[i,j] == 0)
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
                        m[i,j] = 0;
                }
            }

            for (int i = 0; i < m.GetLength(0); i++)
            {
                for (int j = 0; j < m.GetLength(1); j++)
                {
                    Console.Write(m[i,j] + " ");
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
                    int top = matrix[first,i]; 
                    // left -> top II 
                    matrix[first,i] = matrix[last - offset, first]; 
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

                c = StringProblems.reverseString(c, i, j-1);
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
            bool [] used = new bool[length];
            StringBuilder outS = new StringBuilder(); 
            StringProblems.doPermute( inS, outS, used, length, 0);
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
                outs.Append( ins[i] );
                used[i] = true;
                doPermute( ins, outs, used, length, level + 1);
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

    }
}
