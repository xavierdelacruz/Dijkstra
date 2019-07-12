using System;
using System.Collections.Generic;

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

            // Following Pseudocode from here
            // http://www.gitta.info/Accessibiliti/en/html/Dijkstra_learningObject1.html

            IDictionary<Vertex, int> distance = new Dictionary<Vertex, int>();
            IDictionary<Vertex, Edge> previousNode = new Dictionary<Vertex, Edge>();
            IList<Vertex> graphVertices = new List<Vertex>();

            foreach (var vertex in graph.Vertices)
            {
                distance[vertex] = int.MaxValue;
                previousNode[vertex] = null;
                graphVertices.Add(vertex);
            }

            distance[start] = 0;

            while (graphVertices.Count > 0)
            {

            }
            return null;
        }
    }
}
