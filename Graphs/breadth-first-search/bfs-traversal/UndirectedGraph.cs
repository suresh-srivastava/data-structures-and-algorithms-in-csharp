//Copyright (C) Suresh Kumar Srivastava - All Rights Reserved
//DSA Masterclass courses are available on CourseGalaxy.com

//UndirectedGraph.cs : Program for traversing an undirected graph through BFS.
//Visiting only those vertices that are reachable from start vertex.
//Visiting all vertices.
//Finding graph is connected or not connected.

using System;
using System.Collections.Generic;

namespace UndirectedGraph
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

    class UndirectedGraph
    {
        private readonly int maxSize = 30;
        private int nVertices;
        private int nEdges;
        private int[,] adj;
        private Vertex[] vertexList;

        private int INITIAL;
        private int WAITING;
        private int VISITED;

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

        public bool IsConnected()
        {
	        bool connected = true;

	        //Initially all the vertices will have INITIAL state
	        for(int i=0; i<nVertices; i++)
	        {
		        vertexList[i].state = INITIAL;
	        }

	        Bfs(0);	//Start traversal from vertex 0

	        for(int v=0; v<nVertices; v++)
	        {
		        if(vertexList[v].state == INITIAL)
		        {
			        connected = false;
			        break;
		        }
	        }

	        return connected;

        }//End of IsConnected()

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
                //uGraph.InsertEdge("0","3");
                //uGraph.InsertEdge("1","2");

                //uGraph.InsertEdge("4","5");
                //uGraph.InsertEdge("4","7");
                //uGraph.InsertEdge("4","8");
                //uGraph.InsertEdge("5","6");
                //uGraph.InsertEdge("5","8");
                //uGraph.InsertEdge("6","9");
                //uGraph.InsertEdge("7","8");
                //uGraph.InsertEdge("8","9");

                //uGraph.InsertEdge("10","11");
                //uGraph.InsertEdge("10","13");
                //uGraph.InsertEdge("10","14");
                //uGraph.InsertEdge("11","12");
                //uGraph.InsertEdge("12","13");
                //uGraph.InsertEdge("13","14");

                //Display the graph
                uGraph.Display();
                Console.WriteLine();

                //BFS traversal visiting only those vertices that are reachable from start vertex
                uGraph.BfsTraversal("4");

                //BFS traversal visiting all the vertices
                uGraph.BfsTraversalAll("0");

                //Find out that graph is conncted or not connected
                if(uGraph.IsConnected())
                    Console.WriteLine("Graph is connected");
                else
                    Console.WriteLine("Graph is not connected");

            }//End of try
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }//End of Main()
    }//End of class UndirectedGraphDemo
}//End of namespace UndirectedGraph
