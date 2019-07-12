using System;
using System.Collections.Generic;

namespace Dijkstra_s_Algorithm
{
    public class Graph
    {
        public List<Vertex> Vertices { get; set; }
        public List<Edge> Edges { get; set; }

        public Graph(IList<Vertex> vertices, IList<Edge> edges)
        {
            if (vertices == null)
            {
                Vertices = new List<Vertex>();
            }

            if (edges == null)
            {
                Edges = new List<Edge>();
            }
        }

        /// <summary>
        /// Basic operation on adding a new vertex
        /// </summary>
        /// <param name="vertexValue"></param>
        /// <returns></returns>
        public Vertex AddVertex(int vertexValue)
        {
            var vertex = new Vertex(vertexValue);
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
        /// Adds an edge to the graph. Requires a start and end vertex.
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <param name="cost"></param>
        /// <param name="isUsed"></param>
        /// <returns></returns>
        public Edge AddEdge(Vertex start, Vertex end, int cost, bool isUsed)
        {
            if (start == null || end == null)
            {
                throw new ArgumentNullException("Adding edge failed since start or end vertices are null.");
            }

            var edge = new Edge(start, end, cost, isUsed);
            Edges.Add(edge);
            return edge;
        }

        /// <summary>
        /// Removes an edge from the graph.
        /// </summary>
        /// <param name="edge"></param>
        public void RemoveEdge(Edge edge)
        {
            if (Edges.Contains(edge))
            {
                Edges.Remove(edge);
            }
            else
            {
                throw new NullReferenceException("The edge specified cannot be found during removal.");
            }
        }

        /// <summary>
        /// Checks if an edge has a vertex at its START
        /// </summary>
        /// <param name="vertex"></param>
        /// <returns></returns>
        public bool HasVertexStartEdge(Vertex vertex)
        {
            return Edges.Exists(x => x.StartVertex.Equals(vertex));
        }

        /// <summary>
        /// Checks if an edge has a vertex at its END
        /// </summary>
        /// <param name="vertex"></param>
        /// <returns></returns>
        public bool HasVertexEndEdge(Vertex vertex)
        {
            return Edges.Exists(x => x.EndVertex.Equals(vertex));
        }
    }
}
