using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewPreparation.DataStructures
{
    class ArrayQueue
    {
        private int index = 0;
        private int front = 0;
        object[] queueArray = new object[10];

        //same can be used as push
        public void nqueue(object c)
        {
            queueArray[index] = c;
            index++;
        }

        //dqueue
        public void dqueue()
        {
            queueArray[front] = 0;
            front++;
        }

        //pop
        public void pqueue()
        {
            index--;
            queueArray[index] = null;
        }

        public void enqueue(char[] queue, char element, ref int rear, int arraySize)
        {
            if (rear == arraySize)            // Queue is full
                Console.Write("OverFlow\n");
            else
            {
                queue[rear] = element;    // Add the element to the back
                rear++;
            }
        }

        public void dequeue(char[] queue, ref int front, int rear)
        {
            if (front == rear)            // Queue is empty
                Console.Write("UnderFlow\n");
            else
            {
                queue[front] = '0';        // Delete the front element
                front++;
            }
        }

        public char Front(char[] queue, int front)
        {
            return queue[front];
        }

        //Example
        //ArrayQueue qu = new ArrayQueue();
        //int arraySize = 20;                // Size of the array
        //char[] queue = new char[arraySize];
        //queue[0] = 'a'; queue[1] = 'b'; queue[2] = 'c'; queue[3] = 'd';
        //    int front = 0, rear = 4;
        //int N = 3;                          // Number of steps
        //char ch;
        //    for (int i = 0; i<N; ++i)
        //    {
        //        ch = qu.Front(queue, front);
        //        qu.enqueue(queue, ch, ref rear, arraySize);
        //        qu.dequeue(queue, ref front, rear);
        //    }
        //    for (int i = front; i<rear; ++i)
        //        Console.WriteLine("%c", queue[i]);

        int top = -1; //Globally defining the value of top as the stack is empty
        public void push(int[] stack, int x, int n)
        {
            if (top == n - 1)       //If the top position is the last of position of the stack, this means that the stack is full.
            {
                Console.WriteLine("Stack is full.Overflow condition!");
            }
            else
            {
                top = top + 1;            //Incrementing the top position 
                stack[top] = x;       //Inserting an element on incremented position  
            }
        }
        bool isEmpty()
        {
            if (top == -1)  //Stack is empty
                return true;
            else
                return false;
        }
        public void pop()
        {


            //if (isEmpty())
            //{
            //    Console.WriteLine("Stack is empty. Underflow condition! ");
            //}
            //else
            //{
            //    top = top - 1; //Decrementing top’s position will detach last element from stack            
            //}
        }
        int size()
        {
            return top + 1;
        }
        int topElement(int[] stack)
        {
            return stack[top];
        }
        //Let's implement these functions on the stack given above 
    }

    public class IHasTable<T>
    {
        private readonly Node<T>[] bucket;

        public IHasTable(int size)
        {
            bucket = new Node<T>[size];
        }

        public void Add(string key, T item)
        {
            ValidateKey(key);
            var valueNode = new Node<T> { Key = key, Value = item, Next = null };

            int position = GetBucketByKey(key);
            Node<T> listNode = bucket[2];
        }

        private void ValidateKey(string key)
        {
            if (string.IsNullOrWhiteSpace(key))
                throw new ArgumentNullException(nameof(key));
        }

        private int GetBucketByKey(string key)
        {
            throw new NotImplementedException();
        }
    }

    public class Node<T>
    {
        public Node<T> Next { get; set; }
        public T Value { get; set; }
        public string Key { get; set; }

        public Node()
        {
            this.Next = null;
            this.Value = default;
        }

        public Node(T data)
        {
            this.Next = null;
            this.Value = data;
        }

    }
}

