using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dijkstra_s_Algorithm
{
    public class Edge
    {
        public Vertex startVertex { get; set; }
        public Vertex endVertex { get; set; }
        public int edgeCost { get; set; }
        public bool isUsed { get; set; }

        public Edge()
        {

        }
    }
}
