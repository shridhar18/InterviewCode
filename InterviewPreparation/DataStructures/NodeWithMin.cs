using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewPreparation.DataStructures
{
    public class NodeWithMin
    {
        public NodeWithMin next { get; set; }
        public int value { get; set; }
        public int min { get; set; }

        public NodeWithMin(int value, int min)
        {
            this.next = null;
            this.value = value;
            this.min = min;
        }
    }
}
