using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms.Chapter4_Graph
{
    class DijkstraAllPairShortestPath
    {
        private DijkstraShortestPath[] all;

        public DijkstraAllPairShortestPath(EdgeWeightedDirectedGraph graph)
        {
            all=new DijkstraShortestPath[graph.VertexCount];
            for (int i = 0; i < graph.VertexCount; i++)
            {
                all[i]=new DijkstraShortestPath(graph,i);
            }
        }

        public IEnumerable<DirectedEdge> Path(int s, int t)
        {
            return all[s].PathTo(t);
        }

        public double Distance(int s, int t)
        {
            return all[s].DistTo[t];
        }
    }
}
