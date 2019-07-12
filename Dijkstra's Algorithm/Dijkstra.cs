using System;

namespace Dijkstra_s_Algorithm
{
    public class Dijkstra
    {
        public Dijkstra()
        {
        }

        public Path SearchForShortestPath(Graph graph, Vertex start, Vertex end)
        {
            if (graph == null)
            {
                throw new ArgumentNullException("Input graph is null.");
            }

            if (start == null || end == null)
            {
                throw new ArgumentNullException("Specified start or end vertices are null.");
            }

            if (!graph.HasVertex(start) || !graph.HasVertex(end))
            {
                throw new ArgumentNullException("No start vertex has been found in the input graph.");
            }

            return null;
        }
    }
}
