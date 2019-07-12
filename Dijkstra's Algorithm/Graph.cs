using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dijkstra_s_Algorithm
{
    public class Graph
    {
        public IList<Vertex> Vertices { get; set; }
        public IList<Edge> Edges { get; set; }

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
    }
}
