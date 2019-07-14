using System;
using System.Collections.Generic;

namespace Dijkstra_s_Algorithm
{
    class Program
    {
        static void Main(string[] args)
        {
            var graph = new Graph();
            var vertexZ = new Vertex("Z", 0, null, true);
            var vertexI = new Vertex("I", 0, new List<Edge> { new Edge(12, vertexZ) });
            var vertexH = new Vertex("H", 0, new List<Edge> { new Edge(10, vertexI) });
            var vertexG = new Vertex("G", 0, new List<Edge> { new Edge(9, vertexH), new Edge(13, vertexI), new Edge(7, vertexZ) });
            var vertexF = new Vertex("F", 0, new List<Edge> { new Edge(7, vertexG) });
            var vertexE = new Vertex("E", 0, new List<Edge> { new Edge(7, vertexF), new Edge(7, vertexG) });
            var vertexD = new Vertex("D", 0, new List<Edge> { new Edge(4, vertexE) });
            var vertexC = new Vertex("C", 0, new List<Edge> { new Edge(4, vertexD), new Edge(11, vertexF) });
            var vertexB = new Vertex("B", 0, new List<Edge> { new Edge(6, vertexC) });
            var vertexA = new Vertex("A", 0, new List<Edge> { new Edge(4, vertexE), new Edge(5, vertexB) });

            graph.AddVertex(vertexA);
            graph.AddVertex(vertexB);
            graph.AddVertex(vertexC);
            graph.AddVertex(vertexD);
            graph.AddVertex(vertexE);
            graph.AddVertex(vertexF);
            graph.AddVertex(vertexG);
            graph.AddVertex(vertexH);
            graph.AddVertex(vertexI);
            graph.AddVertex(vertexZ);

            var search = new DijkstrasAlgorithmWithHeuristics();
            var startVertex = vertexA;
            var results = search.SearchForShortestPath(graph, startVertex);
            results.Reverse();

            Console.WriteLine($"Shortest Path from {startVertex.Name} a goal:");
            Console.Write(startVertex.Name);
            foreach (var vertex in results)
            {
                Console.Write(" -> " + vertex.Name);
            }
            Console.WriteLine();

            var searchWithEnd = new DijkstrasAlgorithmWithHeuristics();
            var startVertexWithEnd = vertexA;
            var endVertex = vertexZ;
            var resultsWithEnd = searchWithEnd.SearchForShortestPath(graph, startVertex);
            resultsWithEnd.Reverse();

            Console.WriteLine($"Shortest Path from {startVertexWithEnd.Name} to {endVertex.Name}:");
            Console.Write(startVertexWithEnd.Name);
            foreach (var vertex in resultsWithEnd)
            {
                Console.Write(" -> " + vertex.Name);
            }
            Console.WriteLine();

            var graphWithHeuristics = new Graph();
            var vertexZWithHeuristics = new Vertex("Z", 0, null, true);
            var vertexIWithHeuristics = new Vertex("I", 7, new List<Edge> { new Edge(12, vertexZWithHeuristics) });
            var vertexHWithHeuristics = new Vertex("H", 3, new List<Edge> { new Edge(10, vertexIWithHeuristics) });
            var vertexGWithHeuristics = new Vertex("G", 1, new List<Edge> { new Edge(9, vertexHWithHeuristics), new Edge(13, vertexIWithHeuristics), new Edge(7, vertexZWithHeuristics) });
            var vertexFWithHeuristics = new Vertex("F", 2, new List<Edge> { new Edge(7, vertexGWithHeuristics) });
            var vertexEWithHeuristics = new Vertex("E", 40, new List<Edge> { new Edge(7, vertexFWithHeuristics), new Edge(7, vertexGWithHeuristics) });
            var vertexDWithHeuristics = new Vertex("D", 2, new List<Edge> { new Edge(4, vertexEWithHeuristics) });
            var vertexCWithHeuristics = new Vertex("C", 2, new List<Edge> { new Edge(4, vertexDWithHeuristics), new Edge(11, vertexFWithHeuristics) });
            var vertexBWithHeuristics = new Vertex("B", 1, new List<Edge> { new Edge(6, vertexCWithHeuristics) });
            var vertexAWithHeuristics = new Vertex("A", 0, new List<Edge> { new Edge(4, vertexEWithHeuristics), new Edge(5, vertexBWithHeuristics) });

            graphWithHeuristics.AddVertex(vertexAWithHeuristics);
            graphWithHeuristics.AddVertex(vertexBWithHeuristics);
            graphWithHeuristics.AddVertex(vertexCWithHeuristics);
            graphWithHeuristics.AddVertex(vertexDWithHeuristics);
            graphWithHeuristics.AddVertex(vertexEWithHeuristics);
            graphWithHeuristics.AddVertex(vertexFWithHeuristics);
            graphWithHeuristics.AddVertex(vertexGWithHeuristics);
            graphWithHeuristics.AddVertex(vertexHWithHeuristics);
            graphWithHeuristics.AddVertex(vertexIWithHeuristics);
            graphWithHeuristics.AddVertex(vertexZWithHeuristics);

            var searchWithHeuristics = new DijkstrasAlgorithmWithHeuristics();
            var startVertexWithHeuristics = vertexAWithHeuristics;
            var endVertexWithHeuristics = vertexZWithHeuristics;
            var resultsWithHeuristics = searchWithHeuristics.SearchForShortestPath(graphWithHeuristics, startVertexWithHeuristics, endVertexWithHeuristics);
            resultsWithHeuristics.Reverse();

            Console.WriteLine($"Shortest Path from {startVertexWithHeuristics.Name} to {endVertexWithHeuristics.Name} with Heuristics:");
            Console.Write(startVertexWithHeuristics.Name);
            foreach (var vertex in resultsWithHeuristics)
            {
                Console.Write(" -> " + vertex.Name);
            }
            Console.ReadLine();
        }
    }
}
