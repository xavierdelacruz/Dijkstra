using System;
using System.Collections.Generic;
using System.Linq;

namespace Dijkstra_s_Algorithm
{
    public class Path
    { 
        protected List<Edge> pathEdges { get; }
        public int EdgeCount => pathEdges.Count;
        public int PathCost => pathEdges.Sum(x => x.EdgeCost);

        public Path(List<Edge> edges)
        {
            if (edges == null)
            {
                throw new ArgumentNullException("Edges passed into Path is null.");
            }

            if (edges.Count.Equals(0))
            {
                throw new Exception("List of edges is empty. Cannot make a path from it.");
            }

            pathEdges = edges;
        }
    }
}
