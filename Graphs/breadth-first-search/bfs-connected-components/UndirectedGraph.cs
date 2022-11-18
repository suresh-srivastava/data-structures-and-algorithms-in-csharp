﻿//Copyright (C) Suresh Kumar Srivastava - All Rights Reserved
//DSA Masterclass courses are available on CourseGalaxy.com

//UndirectedGraph.cs : Program to find connected components in an undirected graph.

using System;
using System.Collections.Generic;

namespace UndirectedGraph
{
    class Vertex
    {
        public String name;
        public int state;
        public int componentNumber;

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
        int WAITING;
        int VISITED;

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
            WAITING = 1;
            VISITED = 2;

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

        private void Bfs(int vertex, int cn)
        {
	        Queue<int> bfsQueue = new Queue<int>();

	        //Inserting the start vertex into queue and changing its state to WAITING
	        bfsQueue.Enqueue(vertex);
	        vertexList[vertex].state = WAITING;

	        while(bfsQueue.Count != 0)
	        {
		        //Deleting front element from the queue and changing its state to VISITED
		        vertex = bfsQueue.Dequeue();
		        vertexList[vertex].state = VISITED;
		        vertexList[vertex].componentNumber = cn;

		        //Looking for the adjacent vertices of the deleted element, and from these insert only those vertices into the
		        //queue which are in the INITIAL state. Change the state of all these inserted vertices from INITIAL to WAITING
		        for(int i=0; i<nVertices; i++)
		        {
			        //Checking for adjacent vertices with INITIAL state
			        if(IsAdjacent(vertex,i) && vertexList[i].state==INITIAL)
			        {
				        bfsQueue.Enqueue(i);
				        vertexList[i].state = WAITING;
			        }
		        }
	        }//End of while

        }//End of Bfs()

        public void ConnectedComponent()
        {
	        int componentNumber = 0;
	        //Initially all the vertices will have INITIAL state
	        for(int i=0; i<nVertices; i++)
	        {
		        vertexList[i].state = INITIAL;
	        }

	        componentNumber++;
	        Bfs(0, componentNumber);	//Start BFS from vertex 0

	        for(int v=0; v<nVertices; v++)
	        {
		        if(vertexList[v].state == INITIAL)
		        {
			        componentNumber++;
			        Bfs(v, componentNumber);
		        }
	        }

	        Console.WriteLine("Number of connected components = " + componentNumber);

	        if(componentNumber == 1)
	        {
		        Console.WriteLine("Graph is connected");
	        }
	        else
	        {
		        Console.WriteLine("Graph is not connected");
		        for(int v=0; v<nVertices; v++)
		        {
			        Console.WriteLine(vertexList[v].name + " -> Component Number : " + vertexList[v].componentNumber);
		        }
	        }

        }//End of ConnectedComponent()

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

                //uGraph.InsertEdge("0","1");
                //uGraph.InsertEdge("0","3");
                //uGraph.InsertEdge("1","2");
                //uGraph.InsertEdge("1","4");
                //uGraph.InsertEdge("1","5");
                //uGraph.InsertEdge("2","3");
                //uGraph.InsertEdge("2","5");
                //uGraph.InsertEdge("3","6");
                //uGraph.InsertEdge("4","7");
                //uGraph.InsertEdge("5","6");
                //uGraph.InsertEdge("5","7");
                //uGraph.InsertEdge("5","8");
                //uGraph.InsertEdge("6","9");
                //uGraph.InsertEdge("7","8");
                //uGraph.InsertEdge("8","9");

                //Not Connected Graph
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
                uGraph.InsertVertex("10");
                uGraph.InsertVertex("11");
                uGraph.InsertVertex("12");
                uGraph.InsertVertex("13");
                uGraph.InsertVertex("14");

                uGraph.InsertEdge("0","1");
                uGraph.InsertEdge("0","3");
                uGraph.InsertEdge("1","2");

                uGraph.InsertEdge("4","5");
                uGraph.InsertEdge("4","7");
                uGraph.InsertEdge("4","8");
                uGraph.InsertEdge("5","6");
                uGraph.InsertEdge("5","8");
                uGraph.InsertEdge("6","9");
                uGraph.InsertEdge("7","8");
                uGraph.InsertEdge("8","9");

                uGraph.InsertEdge("10","11");
                uGraph.InsertEdge("10","13");
                uGraph.InsertEdge("10","14");
                uGraph.InsertEdge("11","12");
                uGraph.InsertEdge("12","13");
                uGraph.InsertEdge("13","14");

                //Display the graph
                uGraph.Display();
                Console.WriteLine();

                //Find the connected components of graph
                uGraph.ConnectedComponent();

            }//End of try
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }//End of Main()
    }//End of class UndirectedGraphDemo
}//End of namespace UndirectedGraph
