using System;
using System.Collections.Generic;

namespace Dijkstra_s_Algorithm
{
    public class Graph
    {
        public List<Vertex> Vertices { get; set; }

        public Graph(List<Vertex> vertices)
        {
            if (vertices == null)
            {
                Vertices = new List<Vertex>();
            }
        }

        /// <summary>
        /// Basic operation on adding a new vertex
        /// </summary>
        /// <param name="vertexValue"></param>
        /// <returns></returns>
        public Vertex AddVertex(string name, int vertexValue, int? heuristic)
        {
            var vertex = new Vertex(name, vertexValue, heuristic);
            Vertices.Add(vertex);
            return vertex;
        }

        /// <summary>
        /// Remove a vertex
        /// </summary>
        /// <param name="vertex"></param>
        public void RemoveVertex(Vertex vertex)
        {
            if (Vertices.Contains(vertex))
            {
                Vertices.Remove(vertex);
            }
            else
            {
                throw new NullReferenceException("The vertex specified cannot be found during removal.");
            }
        }

        /// <summary>
        /// Returns true if vertex is in graph.
        /// </summary>
        /// <param name="vertex"></param>
        /// <returns></returns>
        public bool HasVertex(Vertex vertex)
        {
            return Vertices.Contains(vertex);
        }
    }
}
