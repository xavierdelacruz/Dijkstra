using System;

namespace Dijkstra_s_Algorithm
{
    public class Edge
    {
        public Vertex StartVertex { get; set; }
        public Vertex EndVertex { get; set; }
        public int EdgeCost { get; set; }
        public bool IsUsed { get; set; }

        public Edge(Vertex start, Vertex end, int cost = 0, bool isUsed = false)
        {
            if (start == null || end == null)
            {
                throw new ArgumentNullException("Start and End vertices have been provided null values.");
            }

            StartVertex = start;
            EndVertex = end;
            EdgeCost = cost;
            IsUsed = isUsed;
        }
    }
}
