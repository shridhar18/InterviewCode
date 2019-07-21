using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewPreparation.Problems
{
    class CloningGraph
    {
        public UndirectedGraphNode cloneGraph(UndirectedGraphNode node)
        {
            return this.clone(node, new Dictionary<UndirectedGraphNode, UndirectedGraphNode>());
        }

        private UndirectedGraphNode clone(UndirectedGraphNode node, Dictionary<UndirectedGraphNode, UndirectedGraphNode> map)
        {
            if (node == null)
                return null;

            UndirectedGraphNode cloned = new UndirectedGraphNode(node.label);
            map.Add(node, cloned);

            foreach(UndirectedGraphNode u in node.neighbors)
            {
                if (map.ContainsKey(u))
                {
                    cloned.neighbors.Add(u);
                }
                else
                {
                    cloned.neighbors.Add(this.clone(u, map));
                }
            }

            return cloned;
        }
    }

  public class UndirectedGraphNode 
  {
      public int label;
      public IList<UndirectedGraphNode> neighbors;
      public UndirectedGraphNode(int x)
      { 
          label = x;
          neighbors = new List<UndirectedGraphNode>(); 
      }
  };
}
