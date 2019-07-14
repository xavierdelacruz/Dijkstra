using System;
using System.Collections.Generic;
using System.Linq;
using Wintellect.PowerCollections;

namespace Dijkstra_s_Algorithm
{
    public class Dijkstra
    {
        public Dijkstra()
        {
        }

        public List<Vertex> SearchForShortestPath(Graph graph, Vertex start, Vertex end)
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
            IDictionary<Vertex, Vertex> previous = new Dictionary<Vertex, Vertex>();
            IDictionary<Vertex, int> distance = new Dictionary<Vertex, int>();
            IList<Vertex> priorityQueue = new List<Vertex>();

            foreach (var vertex in graph.Vertices)
            {
                distance[vertex] = int.MaxValue;
                previous[vertex] = null;
                priorityQueue.Add(vertex);
            }

            distance[start] = 0;
            List<Vertex> path = new List<Vertex>();

            while (priorityQueue.Any())
            {
                priorityQueue.OrderBy(x => distance[x] + x.Heuristic).ToList(); ;
                var currentSmallestVertex = priorityQueue.First();
                priorityQueue.Remove(currentSmallestVertex);

                if (currentSmallestVertex == end)
                {                 
                    foreach (var nodes in previous)
                    {
                        path.Add(currentSmallestVertex);
                    }
                    break;
                }

                foreach (var neighbour in currentSmallestVertex.Edges.OrderBy(x => x.Weight))
                    //graph.Vertices.Find(x => x == currentSmallestVertex).Edges)
                {
                    var alt = distance[currentSmallestVertex] + neighbour.Weight + neighbour.Heuristic;
                    if (alt < distance[neighbour])
                    {
                        distance[neighbour] = alt;
                        previous[neighbour] = currentSmallestVertex;
                    }
                }
            }
            return path;
        }
    }
}
