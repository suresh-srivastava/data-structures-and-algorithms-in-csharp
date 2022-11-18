//Copyright (C) Suresh Kumar Srivastava - All Rights Reserved
//DSA Masterclass courses are available on CourseGalaxy.com

//DirectedGraph.cs : Program for traversing a directed graph through DFS and finding the tree edges.

using System;
using System.Collections.Generic;

namespace DirectedGraph
{
    class Vertex
    {
	    public String name;
        public int state;
        public int predecessor;

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
        private int VISITED;
        private int NIL;

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
            VISITED = 1;
            NIL = -1;

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

        private void Dfs(int vertex)
        {
	        Stack<int> dfsStack = new Stack<int>();

	        //Push the start vertex into stack
	        dfsStack.Push(vertex);

	        while(dfsStack.Count != 0)
	        {
		        vertex = dfsStack.Pop();

		        if(vertexList[vertex].state == INITIAL)
		        {
			        vertexList[vertex].state = VISITED;
		        }

		        //Looking for the adjacent vertices of the popped element, and from these push only those vertices into the stack
		        //which are in the INITIAL state.
		        for(int i=nVertices-1; i>=0; i--)
		        {
			        //Checking for adjacent vertices with INITIAL state
			        if(IsAdjacent(vertex,i) && vertexList[i].state==INITIAL)
			        {
				        dfsStack.Push(i);
				        vertexList[i].predecessor = vertex;
			        }
		        }
	        }//End of while

            Console.WriteLine();

        }//End of Dfs()

        public void DfsTraversalAll(String vertexName)
        {
	        //Initially all the vertices will have INITIAL state
	        for(int i=0; i<nVertices; i++)
	        {
		        vertexList[i].state = INITIAL;
		        vertexList[i].predecessor = NIL;
	        }

	        Dfs(GetIndex(vertexName));

	        for(int v=0; v<nVertices; v++)
	        {
		        if(vertexList[v].state == INITIAL)
			        Dfs(v);
	        }

        }//End of DfsTraversalAll()

        public void DfsTreeEdges(String vertexName)
        {
	        DfsTraversalAll(vertexName);

	        for(int v=0; v<nVertices; v++)
	        {
                Console.WriteLine("Vertex : " + v + " , Predecessor : " + vertexList[v].predecessor);
	        }

	        int u;
	        for(int v=0; v<nVertices; v++)
	        {
		        u = vertexList[v].predecessor;
                if (vertexList[v].predecessor != -1)
                    Console.WriteLine("Tree Edge - (" + vertexList[u].name + "," + vertexList[v].name + ")");
	        }

        }//End of DfsTreeEdges()

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
		        dGraph.InsertVertex("9");

		        dGraph.InsertEdge("0","1");
		        dGraph.InsertEdge("0","3");
		        dGraph.InsertEdge("1","2");
		        dGraph.InsertEdge("1","4");
		        dGraph.InsertEdge("1","5");
		        dGraph.InsertEdge("2","3");
		        dGraph.InsertEdge("2","5");
		        dGraph.InsertEdge("3","6");
		        dGraph.InsertEdge("4","7");
		        dGraph.InsertEdge("5","6");
		        dGraph.InsertEdge("5","7");
		        dGraph.InsertEdge("5","8");
		        dGraph.InsertEdge("6","9");
		        dGraph.InsertEdge("7","8");
		        dGraph.InsertEdge("8","9");

		        //Display the graph
		        dGraph.Display();
                Console.WriteLine();

		        //DFS traversal visiting all the vertices and finding the tree edges
		        dGraph.DfsTreeEdges("0");

            }//End of try
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }//End of Main()
    }//End of class DirectedGraphDemo
}//End of namespace DirectedGraph
