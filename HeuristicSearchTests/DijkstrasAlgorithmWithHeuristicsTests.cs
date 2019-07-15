﻿using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Dijkstra_s_Algorithm.Tests
{

    [TestClass()]
    public class DijkstrasAlgorithmWithHeuristicsTests
    {
        Tuple<Graph, Vertex> graphWithHeuristics;
        Tuple<Graph, Vertex> graphWithoutHeuristics;
        Tuple<Graph, Vertex> graphWithCycle;

        Tuple<Graph, Vertex> NonHeuristicSetup()
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

            var result = new Tuple<Graph, Vertex>(graph, vertexA);
            return result;
        }

        Tuple<Graph, Vertex> HeuristicSetup()
        {
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

            var result = new Tuple<Graph, Vertex>(graphWithHeuristics, vertexAWithHeuristics);
            return result;
        }

        [TestInitialize()]
        public void Setup()
        {
            graphWithoutHeuristics = NonHeuristicSetup();
            graphWithHeuristics = HeuristicSetup();
        }

        [TestMethod()]
        public void BasicTestWithoutHeuristics()
        {
            var tuple = graphWithoutHeuristics;
            var search = new DijkstrasAlgorithmWithHeuristics();
            var results = search.SearchForShortestPath(tuple.Item1, tuple.Item2);
            Assert.AreEqual(3, results.Count);
        }

        [TestMethod()]
        public void BasicTestWithHeuristics()
        {
            var tuple = graphWithHeuristics;
            var search = new DijkstrasAlgorithmWithHeuristics();
            var results = search.SearchForShortestPath(tuple.Item1, tuple.Item2);
            Assert.AreEqual(5, results.Count);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException), "Input graph is null.")]
        public void TestNonHeuristicGraph()
        {
            var tupleWithoutHeuristics = graphWithoutHeuristics;
            var search = new DijkstrasAlgorithmWithHeuristics();
            var results = search.SearchForShortestPath(null, tupleWithoutHeuristics.Item2);        
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException), "Input graph is null.")]
        public void TestHeuristicGraph()
        {
            var tupleWithHeuristics = graphWithHeuristics;
            var search = new DijkstrasAlgorithmWithHeuristics();
            var results = search.SearchForShortestPath(null, tupleWithHeuristics.Item2);
        }

        [TestMethod()]
        public void CheckOrderWithoutHeuristicTest()
        {
            var tuple = graphWithoutHeuristics;
            var search = new DijkstrasAlgorithmWithHeuristics();
            var results = search.SearchForShortestPath(tuple.Item1, tuple.Item2);
            Assert.AreEqual(3, results.Count);

            Assert.AreEqual("E", results[0].Name);
            Assert.AreEqual("G", results[1].Name);
            Assert.AreEqual("Z", results[2].Name);
        }

        [TestMethod()]
        public void CheckOrderWithHeuristicTest()
        {
            var tuple = graphWithHeuristics;
            var search = new DijkstrasAlgorithmWithHeuristics();
            var results = search.SearchForShortestPath(tuple.Item1, tuple.Item2);
            Assert.AreEqual(5, results.Count);

            Assert.AreEqual("B", results[0].Name);
            Assert.AreEqual("C", results[1].Name);
            Assert.AreEqual("F", results[2].Name);
            Assert.AreEqual("G", results[3].Name);
            Assert.AreEqual("Z", results[4].Name);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException), "Specified start or end vertices are null.")]
        public void NullStartNodeNonHeuristicGraph()
        {

            var tupleWithoutHeuristics = graphWithoutHeuristics;
            var search = new DijkstrasAlgorithmWithHeuristics();
            var results = search.SearchForShortestPath(tupleWithoutHeuristics.Item1, null);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException), "Specified start or end vertices are null.")]
        public void NullStartNodeHeuristicGraph()
        {
            var tupleWithHeuristics = graphWithHeuristics;
            var search = new DijkstrasAlgorithmWithHeuristics();
            var results = search.SearchForShortestPath(tupleWithHeuristics.Item1, null);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException), "No start vertex has been found in the input graph.")]
        public void WrongStartVertexNonHeuristicGraph()
        {

            var tupleWithoutHeuristics = graphWithoutHeuristics;
            var goodVertex = new Vertex("Z", 0, null, true);
            var badVertex = new Vertex("OMEGALUL", 0, new List<Edge>() { new Edge(12, goodVertex) });
            var search = new DijkstrasAlgorithmWithHeuristics();
            var results = search.SearchForShortestPath(tupleWithoutHeuristics.Item1, badVertex);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException), "No start vertex has been found in the input graph.")]
        public void WrongStartVertexHeuristicGraph()
        {
            var tupleWithHeuristics = graphWithHeuristics;
            var goodVertex = new Vertex("Z", 0, null, true);
            var badVertex = new Vertex("OMEGALUL", 12, new List<Edge>() { new Edge(12, goodVertex) });
            var search = new DijkstrasAlgorithmWithHeuristics();
            var results = search.SearchForShortestPath(tupleWithHeuristics.Item1, badVertex);
        }
    }
}