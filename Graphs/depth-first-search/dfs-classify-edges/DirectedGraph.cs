//Copyright (C) Suresh Kumar Srivastava - All Rights Reserved
//DSA Masterclass courses are available on CourseGalaxy.com

//DirectedGraph.cs : Program for traversing a directed graph through DFS using recursion and classify all the edges in graph.

using System;

namespace DirectedGraph
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

    class DirectedGraph
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
            FINISHED = 2;

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
	        vertexList[vertex].state = VISITED;
	        vertexList[vertex].discoveryTime = ++time;

	        for(int i=0; i<nVertices; i++)
	        {
		        //Checking for adjacent vertices with INITIAL state
		        if(IsAdjacent(vertex,i))
		        {
			        if(vertexList[i].state==INITIAL)
			        {
				        Console.WriteLine("Tree Edge - (" + vertexList[vertex].name + "-" + vertexList[i].name + ")");
				        Dfs(i);
			        }
			        else if(vertexList[i].state==VISITED)
			        {
				        Console.WriteLine("Back Edge - (" + vertexList[vertex].name + "-" + vertexList[i].name + ")");
			        }
			        else if(vertexList[vertex].discoveryTime < vertexList[i].discoveryTime)
			        {
				        Console.WriteLine("Forward Edge - (" + vertexList[vertex].name + "-" + vertexList[i].name + ")");
			        }
			        else
			        {
				        Console.WriteLine("Cross Edge - (" + vertexList[vertex].name + "-" + vertexList[i].name + ")");
			        }
		        }
	        }//End of for

	        vertexList[vertex].state = FINISHED;
	        vertexList[vertex].finishingTime = ++time;

        }//End of Dfs()

        public void DfsClassifyEdges()
        {
	        //Initially all the vertices will have INITIAL state
	        for(int i=0; i<nVertices; i++)
	        {
		        vertexList[i].state = INITIAL;
	        }

	        time = 0;

	        for(int v=0; v<nVertices; v++)
	        {
		        if(vertexList[v].state == INITIAL)
			        Dfs(v);
	        }

            Console.WriteLine();
        }//End of DfsClassifyEdges()

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
		        dGraph.InsertVertex("10");
		        dGraph.InsertVertex("11");
		        dGraph.InsertVertex("12");
		        dGraph.InsertVertex("13");
		        dGraph.InsertVertex("14");
		        dGraph.InsertVertex("15");

		        dGraph.InsertEdge("0","1");
		        dGraph.InsertEdge("0","2");
		        dGraph.InsertEdge("0","3");
		        dGraph.InsertEdge("1","2");
		        dGraph.InsertEdge("3","2");
		        dGraph.InsertEdge("4","1");
		        dGraph.InsertEdge("4","5");
		        dGraph.InsertEdge("4","6");
		        dGraph.InsertEdge("4","7");
		        dGraph.InsertEdge("5","6");
		        dGraph.InsertEdge("6","3");
		        dGraph.InsertEdge("6","9");
		        dGraph.InsertEdge("7","8");
		        dGraph.InsertEdge("8","4");
		        dGraph.InsertEdge("8","5");
		        dGraph.InsertEdge("8","9");
		        dGraph.InsertEdge("9","5");
		        dGraph.InsertEdge("10","11");
		        dGraph.InsertEdge("10","14");
		        dGraph.InsertEdge("11","8");
		        dGraph.InsertEdge("11","12");
		        dGraph.InsertEdge("11","14");
		        dGraph.InsertEdge("11","15");
		        dGraph.InsertEdge("12","15");
		        dGraph.InsertEdge("13","10");
		        dGraph.InsertEdge("14","13");
		        dGraph.InsertEdge("14","15");

		        //Display the graph
		        dGraph.Display();
                Console.WriteLine();

		        //classify all the edges in graph
		        dGraph.DfsClassifyEdges();

            }//End of try
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }//End of Main()
    }//End of class DirectedGraphDemo
}//End of namespace DirectedGraph
