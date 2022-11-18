//Copyright (C) Suresh Kumar Srivastava - All Rights Reserved
//DSA Masterclass courses are available on CourseGalaxy.com

//DirectedGraph.cs : Program for traversing a directed graph through DFS using recursion and finding out that graph is 
//cyclic or not

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
        private int INITIAL;
        private int VISITED;
        private int FINISHED;
        private static int time;
        private bool hasCycle;

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
				        //Its Tree Edge
				        Dfs(i);
			        }
			        else if(vertexList[i].state==VISITED)
			        {
				        //Its Back Edge
				        hasCycle = true;
			        }
		        }
	        }//End of for

	        vertexList[vertex].state = FINISHED;
	        vertexList[vertex].finishingTime = ++time;

        }//End of Dfs()

        public bool IsCyclic()
        {
	        //Initially all the vertices will have INITIAL state
	        for(int i=0; i<nVertices; i++)
	        {
		        vertexList[i].state = INITIAL;
	        }

	        time = 0;
	        hasCycle = false;

	        for(int v=0; v<nVertices; v++)
	        {
		        if(vertexList[v].state == INITIAL)
			        Dfs(v);
	        }

	        return hasCycle;
        }//End of IsCyclic()

    }//End of class DirectedGraph

    class DirectedGraphDemo
    {
        static void Main(string[] args)
        {
            DirectedGraph dGraph = new DirectedGraph();

            try
            {
		        //Creating the graph, inserting the vertices and edges
		        //Graph is acyclic
                //dGraph.InsertVertex("0");
                //dGraph.InsertVertex("1");
                //dGraph.InsertVertex("2");
                //dGraph.InsertVertex("3");

                //dGraph.InsertEdge("0","1");
                //dGraph.InsertEdge("0","2");
                //dGraph.InsertEdge("0","3");
                //dGraph.InsertEdge("1","2");
                //dGraph.InsertEdge("3","2");

		        //Graph is cyclic
                dGraph.InsertVertex("0");
                dGraph.InsertVertex("1");
                dGraph.InsertVertex("2");
                dGraph.InsertVertex("3");

                dGraph.InsertEdge("0","1");
                dGraph.InsertEdge("0","2");
                dGraph.InsertEdge("1","2");
                dGraph.InsertEdge("2","3");
                dGraph.InsertEdge("3","0");

		        //Display the graph
		        dGraph.Display();
                Console.WriteLine();

		        if(dGraph.IsCyclic())
			        Console.WriteLine("Graph is Cyclic");
		        else
			        Console.WriteLine("Graph is Acyclic");

            }//End of try
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }//End of Main()
    }//End of class DirectedGraphDemo
}//End of namespace DirectedGraph
