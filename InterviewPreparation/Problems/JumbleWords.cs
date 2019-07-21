using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewPreparation.Problems
{
    class JumbleWords
    {
        char[,] m;
        List<Result> results;
        char[] w;
        public JumbleWords(char[] word)
        {
            m = new char[5, 5];
            this.results = new List<Result>();
            this.w = new char[word.Length];
            word.CopyTo(this.w, 0);

            m[0, 0] = 'a';
            m[0, 1] = 'f';
            m[0, 2] = 'k';
            m[0, 3] = 'c';
            m[0, 4] = 'z';
            m[1, 0] = 'b';
            m[1, 1] = 'f';
            m[1, 2] = 'k';
            m[1, 3] = 'a';
            m[1, 4] = 'x';
            m[2, 0] = 'b';
            m[2, 1] = 'c';
            m[2, 2] = 'a';
            m[2, 3] = 't';
            m[2, 4] = 'a';
            m[3, 0] = 'o';
            m[3, 1] = 'a';
            m[3, 2] = 'h';
            m[3, 3] = 'y';
            m[3, 4] = 'c';
            m[4, 0] = 'q';
            m[4, 1] = 'm';
            m[4, 2] = 'c';
            m[4, 3] = 'x';
            m[4, 4] = 'z';
        }

        public List<Result> findWords(char[] word)
        {
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    Console.Write(this.m[i, j] + ",");
                    if (this.m[i, j] == word[0])
                    {
                        Result r = new Result(this.w.Length);
                        
                        this.findJumble(i, j, 0, r);
                    }                        
                }
                Console.WriteLine();
            }

            return this.results;
        }

        public Result checkForWordX(int x, int y, char[] word)
        {
            if (y + word.Length > this.m.GetLength(1))
                return null;

            Result r = new Result(word.Length);
            r.word[0] = new Coords(x, y);

            for (int i = y + 1, j = 1; j < word.Length; j++, i++)
            {
                if (this.m[x, i] != word[j])
                    return null;
                else
                    r.word[j] = new Coords(x, i);
            }

            return r;
        }

        public Result checkForWordY(int x, int y, char[] word)
        {
            if (x + word.Length > this.m.GetLength(0))
                return null;

            Result r = new Result(word.Length);
            r.word[0] = new Coords(x, y);

            for (int i = x + 1, j = 1; j < word.Length; j++, i++)
            {
                if (this.m[i, y] != word[j])
                    return null;
                else
                    r.word[j] = new Coords(i, y);
            }

            return r;
        }

        public void findJumble(int i, int j, int x, Result r)
        {
            if (i >= this.m.GetLength(1) || i < 0 || j >= this.m.GetLength(0) || j < 0 || x >= this.w.Length )
                return;
            if (this.m[i, j] == this.w[x])
            {
                r.word[x] = new Coords(i, j);
                if (x == this.w.Length - 1)
                {
                    this.results.Add(r);
                }
                else
                {
                    this.findJumble(i - 1, j, x + 1, r);
                    this.findJumble(i + 1, j, x + 1, r);
                    this.findJumble(i, j - 1, x + 1, r);
                    this.findJumble(i, j + 1, x + 1, r);
                    
                }
            }

            return;
        }
    }

    public class Result
    {
        public Coords[] word;

        public Result(int x)
        {
            this.word = new Coords[x];
        }
    }

    public class Coords
    {
        int x;
        int y;

        public Coords(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }
}
