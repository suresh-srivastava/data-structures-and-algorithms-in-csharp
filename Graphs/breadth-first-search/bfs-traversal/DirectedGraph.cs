﻿//Copyright (C) Suresh Kumar Srivastava - All Rights Reserved
//DSA Masterclass courses are available on CourseGalaxy.com

//DirectedGraph.cs : Program for traversing a directed graph through BFS.
//Visiting only those vertices that are reachable from start vertex.
//Visiting all vertices

using System;
using System.Collections.Generic;

namespace DirectedGraph
{
    class Vertex
    {
        public String name;
        public int state;

        public Vertex(String name)
        {
            this.name = name;
        }
    }//End of class Vertex

    class DirectedGraph
    {
        private readonly int maxSize = 30;
        private int nVertices;
        private int nEdges;
        private int[,] adj;
        private Vertex[] vertexList;

        private int INITIAL;
        private int WAITING;
        private int VISITED;

        public DirectedGraph()
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

        }//End of DirectedGraph()

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

        private void Bfs(int vertex)
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

		        Console.Write(vertex + " ");

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

            Console.WriteLine();

        }//End of Bfs()

        public void BfsTraversal(String vertexName)
        {
	        //Initially all the vertices will have INITIAL state
	        for(int i=0; i<nVertices; i++)
	        {
		        vertexList[i].state = INITIAL;
	        }

	        Bfs(GetIndex(vertexName));
        }//End of BfsTraversal()

        public void BfsTraversalAll(String vertexName)
        {
	        //Initially all the vertices will have INITIAL state
	        for(int i=0; i<nVertices; i++)
	        {
		        vertexList[i].state = INITIAL;
	        }

	        Bfs(GetIndex(vertexName));

	        for(int v=0; v<nVertices; v++)
	        {
		        if(vertexList[v].state == INITIAL)
			        Bfs(v);
	        }

        }//End of BfsTraversalAll()

    }//End of class DirectedGraph

    class DirectedGraphDemo
    {
        static void Main(string[] args)
        {
            DirectedGraph dGraph = new DirectedGraph();

            try
            {
                //Creating the graph, inserting the vertices and edges
                dGraph.InsertVertex("0");
                dGraph.InsertVertex("1");
                dGraph.InsertVertex("2");
                dGraph.InsertVertex("3");
                dGraph.InsertVertex("4");
                dGraph.InsertVertex("5");
                dGraph.InsertVertex("6");
                dGraph.InsertVertex("7");
                dGraph.InsertVertex("8");

                dGraph.InsertEdge("0","1");
                dGraph.InsertEdge("0","3");
                dGraph.InsertEdge("0","4");
                dGraph.InsertEdge("1","2");
                dGraph.InsertEdge("2","5");
                dGraph.InsertEdge("3","4");
                dGraph.InsertEdge("3","6");
                dGraph.InsertEdge("4","5");
                dGraph.InsertEdge("4","7");
                dGraph.InsertEdge("6","4");
                dGraph.InsertEdge("6","7");
                dGraph.InsertEdge("7","5");
                dGraph.InsertEdge("7","8");

                //Display the graph
                dGraph.Display();
                Console.WriteLine();

                //BFS traversal visiting only those vertices that are reachable from start vertex
                dGraph.BfsTraversal("4");

                //BFS traversal visiting all the vertices
                dGraph.BfsTraversalAll("0");

            }//End of try
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }//End of Main()
    }//End of class DirectedGraphDemo
}//End of namespace DirectedGraph
