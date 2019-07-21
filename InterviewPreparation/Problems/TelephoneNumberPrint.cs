using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewPreparation.Problems
{
    class TelephoneNumberPrint
    {
        public char[][] phn;

        public TelephoneNumberPrint()
        {
            phn = new char[10][];
            phn[2] = new char[] { 'A', 'B', 'C' };
            phn[3] = new char[] { 'D', 'E', 'F' };
            phn[4] = new char[] { 'G', 'H', 'I' };
            phn[5] = new char[] { 'J', 'K', 'L' };
            phn[6] = new char[] { 'M', 'N', 'O' };
            phn[7] = new char[] { 'P', 'Q', 'R', 'S' };
            phn[8] = new char[] { 'T', 'U', 'V' };
            phn[9] = new char[] { 'W', 'X', 'Y', 'Z' };

        }
        public void printTelephoneNumbers(int[] num)
        {
            int[] factors = new int[num.Length+1];
            factors[num.Length] = 1;
            factors[num.Length-1] = this.phn[num[num.Length-1]].Length;
            for (int i = num.Length-2; i >= 0 ; i--)
            {
                factors[i] = factors[i + 1] * this.phn[num[i]].Length;
            }

            for (int i = 0; i < factors[0]; i++)
            {
                string s = "";
                for (int j = num.Length -1; j >= 0; j--)
                {
                    s = phn[num[j]][(i % factors[j]) / factors[j+1]].ToString() + s;
                }
                //string s = phn[num[0]][(i % factors[0]) / factors[1]].ToString() + phn[num[1]][(i % factors[1]) / factors[2]].ToString() + phn[num[2]][(i% factors[2]) / 1].ToString();
                Console.WriteLine(i + " :"+ s);
            }
        }

        public char getCharKey(int telephoneKey, int place)
        {
            return this.phn[telephoneKey][place];
        }
    }
}
