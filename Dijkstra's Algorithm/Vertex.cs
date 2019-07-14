using System.Collections.Generic;

namespace Dijkstra_s_Algorithm
{
    public class Vertex
    {
        internal string Name { get; set; }
        internal int Weight { get; set; }       
        internal List<Vertex> Edges { get; set; }
        internal int Heuristic { get; set; }

        public Vertex(string name, int? vertexWeight, int? heuristic)
        {
            Name = name;
            Weight = vertexWeight ?? 0;
            Edges = new List<Vertex>();
            Heuristic = heuristic ?? 0;
        }
    }
}