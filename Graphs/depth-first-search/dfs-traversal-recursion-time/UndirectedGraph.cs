﻿//Copyright (C) Suresh Kumar Srivastava - All Rights Reserved
//DSA Masterclass courses are available on CourseGalaxy.com

//UndirectedGraph.cs : Program for traversing an undirected graph through DFS using recursion.
//Visiting only those vertices that are reachable from start vertex
//Visiting all vertices
//Finding discovery time and finishing time of each vertex

using System;

namespace UndirectedGraph
{
    class Vertex
    {
        public String name;
        public int state;
        public int discoveryTime;
        public int finishingTime;

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
        int INITIAL;
        int VISITED;
        int FINISHED;
        static int time;

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

            INITIAL = 0;
            VISITED = 1;
            FINISHED = 2;

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

        private void Dfs(int vertex)
        {
	        Console.Write(vertex + " ");
	        vertexList[vertex].state = VISITED;
	        vertexList[vertex].discoveryTime = ++time;

	        for(int i=0; i<nVertices; i++)
	        {
		        //Checking for adjacent vertices with INITIAL state
		        if(IsAdjacent(vertex,i) && vertexList[i].state==INITIAL)
		        {
			        Dfs(i);
		        }
	        }

	        vertexList[vertex].state = FINISHED;
	        vertexList[vertex].finishingTime = ++time;

        }//End of Dfs()

        public void DfsTraversal(String vertexName)
        {
	        //Initially all the vertices will have INITIAL state
	        for(int i=0; i<nVertices; i++)
	        {
		        vertexList[i].state = INITIAL;
	        }

	        time = 0;

	        Dfs(GetIndex(vertexName));

            Console.WriteLine();

        }//End of DfsTraversal()

        public void DfsTraversalAll(String vertexName)
        {
	        //Initially all the vertices will have INITIAL state
	        for(int i=0; i<nVertices; i++)
	        {
		        vertexList[i].state = INITIAL;
	        }

	        time = 0;

	        Dfs(GetIndex(vertexName));

	        for(int v=0; v<nVertices; v++)
	        {
		        if(vertexList[v].state == INITIAL)
			        Dfs(v);
	        }

            Console.WriteLine();

	        for(int v=0; v<nVertices; v++)
	        {
		        Console.Write("Vertex : " + v);
		        Console.Write("  Discovery Time : " + vertexList[v].discoveryTime);
		        Console.WriteLine("  Finishing Time : " + vertexList[v].finishingTime);
	        }

        }//End of DfsTraversalAll()

    }//End of class UndirectedGraph

    class UndirectedGraphDemo
    {
        static void Main(string[] args)
        {
            UndirectedGraph uGraph = new UndirectedGraph();

            try
            {
                //Creating the graph, inserting the vertices and edges
                //Connected Graph
                uGraph.InsertVertex("0");
                uGraph.InsertVertex("1");
                uGraph.InsertVertex("2");
                uGraph.InsertVertex("3");
                uGraph.InsertVertex("4");
                uGraph.InsertVertex("5");
                uGraph.InsertVertex("6");
                uGraph.InsertVertex("7");
                uGraph.InsertVertex("8");
                uGraph.InsertVertex("9");

                uGraph.InsertEdge("0","1");
                uGraph.InsertEdge("0","3");
                uGraph.InsertEdge("1","2");
                uGraph.InsertEdge("1","4");
                uGraph.InsertEdge("1","5");
                uGraph.InsertEdge("2","3");
                uGraph.InsertEdge("2","5");
                uGraph.InsertEdge("3","6");
                uGraph.InsertEdge("4","7");
                uGraph.InsertEdge("5","6");
                uGraph.InsertEdge("5","7");
                uGraph.InsertEdge("5","8");
                uGraph.InsertEdge("6","9");
                uGraph.InsertEdge("7","8");
                uGraph.InsertEdge("8","9");

                //Not Connected Graph
                //uGraph.InsertVertex("0");
                //uGraph.InsertVertex("1");
                //uGraph.InsertVertex("2");
                //uGraph.InsertVertex("3");
                //uGraph.InsertVertex("4");
                //uGraph.InsertVertex("5");
                //uGraph.InsertVertex("6");
                //uGraph.InsertVertex("7");
                //uGraph.InsertVertex("8");
                //uGraph.InsertVertex("9");
                //uGraph.InsertVertex("10");
                //uGraph.InsertVertex("11");
                //uGraph.InsertVertex("12");
                //uGraph.InsertVertex("13");
                //uGraph.InsertVertex("14");

                //uGraph.InsertEdge("0","1");
                //uGraph.InsertEdge("0","2");
                //uGraph.InsertEdge("0","3");
                //uGraph.InsertEdge("2","3");

                //uGraph.InsertEdge("4","5");
                //uGraph.InsertEdge("4","6");
                //uGraph.InsertEdge("4","7");
                //uGraph.InsertEdge("4","8");
                //uGraph.InsertEdge("5","7");
                //uGraph.InsertEdge("6","8");
                //uGraph.InsertEdge("6","9");

                //uGraph.InsertEdge("10","11");
                //uGraph.InsertEdge("10","12");
                //uGraph.InsertEdge("10","13");
                //uGraph.InsertEdge("11","12");
                //uGraph.InsertEdge("11","13");
                //uGraph.InsertEdge("11","14");
                //uGraph.InsertEdge("13","14");

                //Display the graph
                uGraph.Display();
                Console.WriteLine();

                //DFS traversal visiting only those vertices that are reachable from start vertex
                uGraph.DfsTraversal("0");

                //DFS traversal visiting all the vertices
                uGraph.DfsTraversalAll("0");

            }//End of try
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }//End of Main()
    }//End of class UndirectedGraphDemo
}//End of namespace UndirectedGraph
