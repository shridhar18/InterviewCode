using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterviewPreparation.DataStructures;

namespace InterviewPreparation.Problems
{
    public class TowersOfHanoi
    {
        int c = 3;
        public Tower[] towers;

        public TowersOfHanoi(int n)
        {
            towers = new Tower[this.c];

            for (int i = 0; i < c; i++)
            {
                this.towers[i] = new Tower(i+1);
            }

            for (int i = n; i > 0; i--)
            {
                this.towers[0].s.push(i);
            }
        }

        public void moveTop(Tower o, Tower d)
        {
            int data = o.s.pop().data;
            d.s.push(data);
            Console.WriteLine("Disk: "+ data + " is moved from "+ o.num + " to " + d.num);
        }

        public void moveDisks(int n, Tower o, Tower d, Tower b)
        {
            if (n == 1)
            {
                this.moveTop(o, d);
            }
            else if (n == 2)
            {
                this.moveTop(o, b);
                this.moveTop(o, d);
                this.moveTop(b, d);
            }
            else if (n > 2)
            {
                this.moveDisks(n-1, o, b, d);

                this.moveTop(o, d);

                this.moveDisks(n - 1, b, d, o);
            }
        }
    }

    public class Tower
    {
        public DataStructures.Stack<int> s;
        public int num;

        public Tower(int n)
        {
            this.s = new DataStructures.Stack<int>();
            this.num = n;
        }

        public void print()
        {
            this.printTower(this.s.head);
        }

        public void printTower(GenericNode<int> head)
        {
            if (head != null)
            {
                Console.WriteLine(head.data);
                this.printTower(head.next);
            }

            
        }

        public void printTowerReverse(GenericNode<int> head)
        {
            if (head == null)
                Console.Write(";");
            if (head.next != null)
            {
                printTowerReverse(head.next);
            }

            Console.WriteLine(head.data);
        }

    }
}
