using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewPreparation.DataStructures
{
    class Graph<T> where T : IComparable<T>
    {
        public List<GraphNode<T>> nodeSet = null;

        public Graph(List<GraphNode<T>> nodeSet)
        {
            if (nodeSet == null)
                this.nodeSet = new List<GraphNode<T>>();
            else
                this.nodeSet = nodeSet;
        }

        public void addNode(GraphNode<T> node)
        {
            this.nodeSet.Add(node);
        }

        public void addNode(T value)
        {
            this.nodeSet.Add(new GraphNode<T>(value, null));
        }

        public void addDirectedEdge(GraphNode<T> from, GraphNode<T> to, int cost)
        {
            from.Neighbors.Add(to);
            from.Costs.Add(cost);
        }

        public void addUndirectedEdge(GraphNode<T> from, GraphNode<T> to, int cost)
        {
            this.addDirectedEdge(from, to, cost);
            this.addDirectedEdge(to, from, cost);
        }

        public bool contains(T value)
        {
            return this.nodeSet.Find((node)=> { return node.data.CompareTo(value) == 0; }) != null;
        }

        public bool remove(T value)
        {
            GraphNode<T> rNode = this.nodeSet.Find((node) => { return node.data.CompareTo(value) == 0; });

            if (rNode == null)
                return false;

            this.nodeSet.Remove(rNode);

            foreach (GraphNode<T> aNode in this.nodeSet)
            {
                int index = aNode.Neighbors.IndexOf(rNode);
                if (index != -1)
                {
                    aNode.Neighbors.RemoveAt(index);
                    aNode.Costs.RemoveAt(index);
                }
            }

            return true;
        }

        public GraphNode<T> getNode(T value)
        {
            return this.nodeSet.Find((node) => { return node.data.CompareTo(value) == 0; });
        }

        public bool DFS(GraphNode<T> node, T x)
        {
            System.Collections.Generic.Stack<GraphNode<T>> st = new System.Collections.Generic.Stack<GraphNode<T>>();
            HashSet<GraphNode<T>> visited = new HashSet<GraphNode<T>>();

            st.Push(node);

            while (st.Count > 0)
            {
                GraphNode<T> n = st.Pop();
                visited.Add(n);
                Console.Write(n.data + "->");
                if (n.data.Equals(x))
                {
                    return true;
                }
                else
                {
                    foreach (GraphNode<T> a in n.neighbors)
                    {
                        if(!visited.Contains(a))
                        st.Push(a);
                    }
                }
            }

            return false;
        }

        public bool BFS(GraphNode<T> node, T x)
        {
            System.Collections.Generic.Queue<GraphNode<T>> st = new System.Collections.Generic.Queue<GraphNode<T>>();
            HashSet<GraphNode<T>> visited = new HashSet<GraphNode<T>>();

            st.Enqueue(node);

            while (st.Count > 0)
            {
                GraphNode<T> n = st.Dequeue();
                visited.Add(n);
                Console.Write(n.data + "->");
                if (n.data.Equals(x))
                {
                    return true;
                }
                else
                {
                    foreach (GraphNode<T> a in n.neighbors)
                    {
                        if (!visited.Contains(a))
                            st.Enqueue(a);
                    }
                }
            }

            return false;
        }
    }

    public class GraphNode<T>
    {
        public T data;
        public List<GraphNode<T>> neighbors = null;
        public List<int> costs;

        public GraphNode(T data, List<GraphNode<T>> neighbors)
        {
            this.data = data;
            this.neighbors = neighbors;
        }

        public T Value { get; set; }

        public List<GraphNode<T>> Neighbors
        {
            get
            {
                if (this.neighbors == null)
                    this.neighbors = new List<GraphNode<T>>();

                return this.neighbors;
            }
        }

        public List<int> Costs
        {
            get
            {
                if (costs == null)
                    costs = new List<int>();

                return costs;
            }
        }
    }



}
