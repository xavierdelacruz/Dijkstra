using System.Collections.Generic;

namespace Dijkstra_s_Algorithm
{
    public class Vertex
    {
        internal string Name { get; set; }
        internal int Value { get; set; }       
        internal List<Vertex> Edges { get; set; }

        public Vertex(string name, int? vertexValue)
        {
            Name = name;
            Value = vertexValue ?? 0;
            Edges = new List<Vertex>();
        }
    }
}