using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterviewPreparation.DataStructures;

namespace InterviewPreparation.Problems
{
    class ShortestPath
    {
        public Graph<string> airlines;
        public Dictionary<string, int> distance;
        public Dictionary<string, string> route;
        public List<string> q;

        public ShortestPath(Graph<string> airlines)
        {
            this.airlines = airlines;
            this.distance = new Dictionary<string, int>();
            this.route = new Dictionary<string, string>();
            this.q = new List<string>();
        }

        public void initialize()
        {
            foreach (GraphNode<string> g in this.airlines.nodeSet)
            {
                this.distance.Add(g.data, int.MaxValue);
                this.route.Add(g.data, null);
                this.q.Add(g.data);
            }
        }

        public string getNearestCityInQ()
        {
            int l = -1;
            string lCity = null;
            foreach (string city in this.q)
            {
                if ((l == -1 || this.distance[city] <= l))
                {
                    l = this.distance[city];
                    lCity = city;
                }
            }
            return lCity;
        }

        public void buildTables(string from, string to)
        {
            this.initialize();
            this.distance[from] = 0;

            while (this.q.Count != 0)
            {
                string lCity = this.getNearestCityInQ();
                int lDist = this.distance[lCity];
                this.q.Remove(lCity);

                GraphNode<string> aNode = this.airlines.getNode(lCity);

                for (int i = 0; i < aNode.Neighbors.Count; i++)
                {
                    string nCity = aNode.Neighbors[i].data;
                    int dist = aNode.Costs[i];

                    if (this.distance[nCity] > dist + lDist)
                    {
                        this.distance[nCity] = dist + lDist;
                        this.route[nCity] = lCity;
                    }
                }
            }

            string tempCity = to;
            string route = to;

            while (this.route[tempCity] != null)
            {
                tempCity = this.route[tempCity];
                route = tempCity + " -> " + route;
            }
            
            Console.WriteLine("Shortest Distance: "+ this.distance[to]);
            Console.WriteLine("Shortet Path: "+ route);
        }
    }
}
