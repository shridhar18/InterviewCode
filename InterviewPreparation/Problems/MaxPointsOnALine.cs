using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewPreparation.Problems
{
    class MaxPointsOnALine
    {
        int GCD(int num1, int num2)
        {
            int Remainder;

            while (num2 != 0)
            {
                Remainder = num1 % num2;
                num1 = num2;
                num2 = Remainder;
            }

            return num1;
        }
        
        public int getMaxPointsonLine(Point[] pts)
        {
            int max = 0, currMax = 0;

            Dictionary<Slope, int> sMap;
            int samepoints = 0;

            foreach (Point p in pts)
            {
                samepoints = 0;
                currMax = 0;
                sMap = new Dictionary<Slope, int>();
                foreach (Point p1 in pts)
                {
                    if (p.equal(p1))
                        samepoints++;
                    else
                    {
                        int g = this.GCD(p1.y - p.y, p1.x - p.x);
                        Slope s = new Slope((p1.y - p.y) / g, (p1.x - p.x) / g);

                        int a = 0;
                        sMap.TryGetValue(s, out a);
                        //int a = sMap.ContainsKey(s) ? sMap.TryGetValue(s, out a) : 0;
                        sMap[s] = (a + 1);

                        currMax = Math.Max(sMap[s], currMax);
                    }
                }

                max = Math.Max(currMax, samepoints + currMax);
            }

            return max;
        }

    }

    public class Point
    {
        public int x, y;

        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public bool equal(Point p)
        {
            return p.x == this.x && p.y == this.y;
        }
    }

    class Slope
    {
        public int x, y;

        public Slope(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }
}
