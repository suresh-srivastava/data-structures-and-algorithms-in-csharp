//Copyright (C) Suresh Kumar Srivastava - All Rights Reserved
//DSA Masterclass courses are available on CourseGalaxy.com

//DirectedWeightedGraph.cs : Program to find shortest paths using Bellman Ford algorithm.

using System;
using System.Collections.Generic;

namespace DirectedWeightedGraph
{
    class Vertex
    {
        public String name;
        public int predecessor;
        public int pathLength;
        public bool inQueue;

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
        int INFINITY;
        int NIL;

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

            INFINITY = 9999;
            NIL = -1;

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

        private void BellmanFordAlgorithm(int s)
        {
	        Queue<int> qu = new Queue<int>();
	        int current;
	        int k=0;

	        //Make all vertices temporary
	        for(int i=0; i<nVertices; i++)
	        {
		        vertexList[i].predecessor = NIL;
		        vertexList[i].pathLength = INFINITY;
		        vertexList[i].inQueue = false;
	        }

	        //Make pathLength of source vertex equal to 0
	        vertexList[s].pathLength = 0;
	        qu.Enqueue(s);
	        vertexList[s].inQueue = true;

	        while(qu.Count != 0)
	        {
		        //Search for temporary vertex with minimum pathLength and make it current vertex
		        current = qu.Dequeue();
		        vertexList[current].inQueue = false;

		        if(s == current)
			        k++;

		        if(k > nVertices)	//Negative cycle reachable from source vertex
		        {
                    throw new System.Exception("There is negative cycle in graph.");
		        }

		        for(int v=0; v<nVertices; v++)
		        {
			        //Checks for adjacent temporary vertices
			        if(IsAdjacent(current,v))
			        {
				        if((vertexList[current].pathLength + adj[current,v]) < vertexList[v].pathLength)
				        {
					        vertexList[v].predecessor = current;	//Relabel
					        vertexList[v].pathLength = vertexList[current].pathLength + adj[current,v];
					        if(vertexList[v].inQueue == false)
					        {
						        qu.Enqueue(v);
						        vertexList[v].inQueue = true;
					        }
				        }
			        }//End of if
		        }//End of for
	        }//End of while

        }//End of BellmanFordAlgorithm()

        private void FindPath(int s, int v)
        {
	        int[] path = new int[maxSize];	//stores the shortest path*
	        int shortestDistance=0; 	    //length of shortest path
	        int count=0;			        //number of vertices in the shortest path
	        int u;

	        //Store the full path in the array path
	        while(v!=s)
	        {
		        count++;
		        path[count] = v;
		        u = vertexList[v].predecessor;
		        shortestDistance += adj[u,v];
		        v = u;
	        }

	        count++;
	        path[count] = s;
	        Console.Write("Shortest Path : ");
	        for(int i=count; i>=1; i--)
		        Console.Write(path[i] + " ");
            Console.WriteLine();
	        Console.WriteLine("Shortest Distance : " + shortestDistance);

        }//End of FindPath()

        public void FindPaths(String source)
        {
	        int s = GetIndex(source);

	        BellmanFordAlgorithm(s);

	        Console.WriteLine("Source : " + source);

	        for(int v=0; v<nVertices; v++)
	        {
		        Console.WriteLine("Destination : " + vertexList[v].name);
		        if(vertexList[v].pathLength == INFINITY)
			        Console.WriteLine("There is no path from " + source + " to vertex " + vertexList[v].name);
		        else
			        FindPath(s, v);
	        }

        }//End of FindPaths()

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
		        dwGraph.InsertVertex("4");
		        dwGraph.InsertVertex("5");
		        dwGraph.InsertVertex("6");
		        dwGraph.InsertVertex("7");

		        dwGraph.InsertEdge("0","1",8);
		        dwGraph.InsertEdge("0","2",9);
		        dwGraph.InsertEdge("0","4",7);
		        dwGraph.InsertEdge("1","5",9);
		        dwGraph.InsertEdge("2","0",5);
		        dwGraph.InsertEdge("2","1",-4);
		        dwGraph.InsertEdge("2","3",3);
		        dwGraph.InsertEdge("3","1",3);
		        dwGraph.InsertEdge("3","2",6);
		        dwGraph.InsertEdge("3","5",4);
		        dwGraph.InsertEdge("4","7",16);
		        dwGraph.InsertEdge("5","0",4);
		        dwGraph.InsertEdge("5","6",-8);
		        dwGraph.InsertEdge("5","7",5);
		        dwGraph.InsertEdge("6","3",5);
		        dwGraph.InsertEdge("6","7",2);

		        //Graph with negative cycle
		        //dwGraph.InsertVertex("0");
		        //dwGraph.InsertVertex("1");
		        //dwGraph.InsertVertex("2");
		        //dwGraph.InsertVertex("3");
		        //dwGraph.InsertVertex("4");

		        //dwGraph.InsertEdge("0","1",2);
		        //dwGraph.InsertEdge("0","2",7);
		        //dwGraph.InsertEdge("1","3",-9);
		        //dwGraph.InsertEdge("2","4",6);
		        //dwGraph.InsertEdge("3","0",4);
		        //dwGraph.InsertEdge("3","4",5);

		        //Display the graph
		        dwGraph.Display();
                Console.WriteLine();

		        dwGraph.FindPaths("0");

            }//End of try
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }//End of Main()
    }//End of class DirectedGraphDemo
}
