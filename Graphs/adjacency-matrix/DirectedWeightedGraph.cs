//Copyright (C) Suresh Kumar Srivastava - All Rights Reserved
//DSA Masterclass courses are available on CourseGalaxy.com

//DirectedWeightedGraph.cs : Program for directed graph with weight on edge using adjacency matrix.

using System;

namespace DirectedWeightedGraph
{
    class Vertex
    {
        public String name;

        public Vertex(String name)
        {
            this.name = name;
        }
    }//End of class Vertex

    class DirectedWeightedGraph
    {
        private readonly int maxSize = 30;
        private int nVertices;
        private int nEdges;
        private int[,] adj;
        private Vertex[] vertexList;

        public DirectedWeightedGraph()
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
        }//End of DirectedWeightedGraph()

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

        public void InsertEdge(String source, String destination, int weight)
        {
            int u = GetIndex(source);
            int v = GetIndex(destination);

            if(u == v)
                Console.WriteLine("Not a valid edge");
            else if(adj[u,v] != 0)
                Console.WriteLine("Edge already present");
            else
            {
                adj[u,v] = weight;
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

        public int GetOutdegree(String vertex)
        {
            int u = GetIndex(vertex);

            int outdegree = 0;
            for(int v=0; v<nVertices; v++)
            {
                if(adj[u,v] != 0)
                    outdegree++;
            }

            return outdegree;
        }//End of GetOutdegree()

        public int GetIndegree(String vertex)
        {
            int u = GetIndex(vertex);

            int indegree = 0;
            for(int v=0; v<nVertices; v++)
            {
                if(adj[v,u] != 0)
                    indegree++;
            }

            return indegree;
        }//End of GetIndegree()

    }//End of class DirectedWeightedGraph

    class DirectedWeightedGraphDemo
    {
        static void Main(string[] args)
        {
            DirectedWeightedGraph dwGraph = new DirectedWeightedGraph();

            try
            {
                //Creating the graph, inserting the vertices and edges
                dwGraph.InsertVertex("0");
                dwGraph.InsertVertex("1");
                dwGraph.InsertVertex("2");
                dwGraph.InsertVertex("3");

                dwGraph.InsertEdge("0","3",1);
                dwGraph.InsertEdge("1","2",2);
                dwGraph.InsertEdge("2","3",3);
                dwGraph.InsertEdge("3","1",4);
                dwGraph.InsertEdge("0","2",5);

                //Display the graph
                dwGraph.Display();
                Console.WriteLine();

                //Deleting an edge
                dwGraph.DeleteEdge("0","2");

                //Display the graph
                dwGraph.Display();

                //Check if there is an edge between two vertices
                Console.WriteLine("Edge exist : " + (dwGraph.EdgeExists("2","3") ? "True" : "False"));

                //Display Indegree and Outdegree of a vertex
                Console.WriteLine("Outdegree : " + dwGraph.GetOutdegree("3"));
                Console.WriteLine("Indegree : " + dwGraph.GetIndegree("3"));

            }//End of try
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }//End of Main()
    }//End of class DirectedGraphDemo
}//End of namespace DirectedWeightedGraph
