//Copyright (C) Suresh Kumar Srivastava - All Rights Reserved
//DSA Masterclass courses are available on CourseGalaxy.com

//UndirectedGraph.cs : Program for traversing an undirected graph through DFS using recursion and finding out that graph is 
//cyclic or not

using System;

namespace UndirectedGraph
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
        bool hasCycle;

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
	        vertexList[vertex].state = VISITED;

	        for(int i=0; i<nVertices; i++)
	        {
		        if(IsAdjacent(vertex,i) && vertexList[vertex].predecessor!=i)
		        {
			        if(vertexList[i].state == INITIAL)
			        {
				        //Its Tree Edge
				        vertexList[i].predecessor = vertex;
				        Dfs(i);
			        }
			        else if(vertexList[i].state == VISITED)
			        {
				        //Its Back Edge
				        hasCycle = true;
			        }

		        }//End of if
	        }//End of for

	        vertexList[vertex].state = FINISHED;

        }//End of Dfs()

        public bool IsCyclic()
        {
	        //Initially all the vertices will have INITIAL state
	        for(int i=0; i<nVertices; i++)
	        {
		        vertexList[i].state = INITIAL;
	        }

	        hasCycle = false;

	        for(int v=0; v<nVertices; v++)
	        {
		        if(vertexList[v].state == INITIAL)
			        Dfs(v);
	        }

	        return hasCycle;
        }//End of IsCyclic()

    }//End of class UndirectedGraph

    class UndirectedGraphDemo
    {
        static void Main(string[] args)
        {
            UndirectedGraph uGraph = new UndirectedGraph();

            try
            {
		        //Creating the graph, inserting the vertices and edges
		        //Graph is acyclic
                //uGraph.InsertVertex("0");
                //uGraph.InsertVertex("1");
                //uGraph.InsertVertex("2");
                //uGraph.InsertVertex("3");
                //uGraph.InsertVertex("4");
                //uGraph.InsertVertex("5");

                //uGraph.InsertEdge("0","1");
                //uGraph.InsertEdge("1","3");
                //uGraph.InsertEdge("2","3");
                //uGraph.InsertEdge("3","4");
                //uGraph.InsertEdge("4","5");

		        //Graph is cyclic
                uGraph.InsertVertex("0");
                uGraph.InsertVertex("1");
                uGraph.InsertVertex("2");
                uGraph.InsertVertex("3");
                uGraph.InsertVertex("4");
                uGraph.InsertVertex("5");

                uGraph.InsertEdge("0","1");
                uGraph.InsertEdge("0","2");
                uGraph.InsertEdge("1","3");
                uGraph.InsertEdge("2","3");
                uGraph.InsertEdge("3","4");
                uGraph.InsertEdge("4","5");

		        //Display the graph
		        uGraph.Display();
                Console.WriteLine();

		        if(uGraph.IsCyclic())
			        Console.WriteLine("Graph is Cyclic");
		        else
			        Console.WriteLine("Graph is Acyclic");

            }//End of try
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }//End of Main()
    }//End of class UndirectedGraphDemo
}//End of namespace UndirectedGraph
