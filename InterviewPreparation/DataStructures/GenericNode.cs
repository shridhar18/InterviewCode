using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewPreparation.DataStructures
{
    public class GenericNode<T>
    {
        //public T data;
        //public GenericNode<T> next;

        public T data { get; set; }
        public GenericNode<T> next { get; set; }

        public GenericNode()
        {
            next = null;
        }

        public GenericNode(T value)
        {
            this.data = value;
            this.next = null;
        }
    }
}
