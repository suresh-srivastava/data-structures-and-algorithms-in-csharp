//Copyright (C) Suresh Kumar Srivastava - All Rights Reserved
//DSA Masterclass courses are available on CourseGalaxy.com

//UndirectedGraph.cs : Program for undirected graph using adjacency matrix.

using System;

namespace UndirectedGraph
{
    class Vertex
    {
        public String name;

        public Vertex(String name)
        {
            this.name = name;
        }
    }//End of class Vertex

    class UndirectedGraph
    {
        private readonly int maxSize = 30;
        private int nVertices;
        private int nEdges;
        private int[,] adj;
        private Vertex[] vertexList;

        public UndirectedGraph()
        {
            adj = new int[maxSize,maxSize];
            vertexList = new Vertex[maxSize];
            nVertices = 0;
            nEdges = 0;

            for(int i=0; i<maxSize; i++)
            {
                for(int j=0; j<maxSize; j++)
                {
                    adj[i,j] = 0;
                }
            }
        }//End of UndirectedGraph()

        public void InsertVertex(String vertexName)
        {
            vertexList[nVertices++] = new Vertex(vertexName);
        }//End of InsertVertex()

        private int GetIndex(String vertexName)
        {
            for(int i=0; i<nVertices; i++)
            {
                if(vertexName == vertexList[i].name)
                    return i;
            }

            throw new System.Exception("Invalid Vertex");
        }//End of GetIndex()

        public void InsertEdge(String source, String destination)
        {
            int u = GetIndex(source);
            int v = GetIndex(destination);

            if(u == v)
                Console.WriteLine("Not a valid edge");
            else if(adj[u,v] != 0)
                Console.WriteLine("Edge already present");
            else
            {
                adj[u,v] = 1;
                adj[v,u] = 1;
                nEdges++;
            }
        }//End of InsertEdge()

        public void DeleteEdge(String source, String destination)
        {
            int u = GetIndex(source);
            int v = GetIndex(destination);

            if(adj[u,v] != 0)
            {
                adj[u,v] = 0;
                adj[v,u] = 0;
                nEdges--;
            }
            else
            {
                Console.WriteLine("Edge doesn't exist");
            }
        }//End of DeleteEdge()

        public void Display()
        {
            for(int i=0; i<nVertices; i++)
            {
                for(int j=0; j<nVertices; j++)
                    Console.Write(adj[i,j] + " ");
                Console.WriteLine();
            }
        }//End of Display()

        private bool IsAdjacent(int u, int v)
        {
            return (adj[u,v] != 0);
        }//End of IsAdjacent()

        public bool EdgeExists(String source, String destination)
        {
            return IsAdjacent(GetIndex(source), GetIndex(destination));
        }//End of EdgeExists()

        public int GetDegree(String vertex)
        {
            int u = GetIndex(vertex);

            int degree = 0;
            for(int v=0; v<nVertices; v++)
            {
                if(adj[u,v] != 0)
                    degree++;
            }

            return degree;
        }//End of GetDegree()

    }//End of class UndirectedGraph

    class UndirectedGraphDemo
    {
        static void Main(string[] args)
        {
            UndirectedGraph uGraph = new UndirectedGraph();

            try
            {
                //Creating the graph, inserting the vertices and edges
                uGraph.InsertVertex("0");
                uGraph.InsertVertex("1");
                uGraph.InsertVertex("2");
                uGraph.InsertVertex("3");

                uGraph.InsertEdge("0","3");
                uGraph.InsertEdge("1","2");
                uGraph.InsertEdge("2","3");
                uGraph.InsertEdge("3","1");
                uGraph.InsertEdge("0","2");

                //Display the graph
                uGraph.Display();
                Console.WriteLine();

                //Deleting an edge
                uGraph.DeleteEdge("0","2");

                //Display the graph
                uGraph.Display();

                //Check if there is an edge between two vertices
                Console.WriteLine("Edge exist : " + (uGraph.EdgeExists("2","3") ? "True" : "False"));

                //Display Indegree and Outdegree of a vertex
                Console.WriteLine("Degree : " + uGraph.GetDegree("3"));

            }//End of try
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }//End of Main()
    }//End of class UndirectedGraphDemo
}//End of namespace UndirectedGraph
