//Copyright (C) Suresh Kumar Srivastava - All Rights Reserved
//DSA Masterclass courses are available on CourseGalaxy.com

//UndirectedGraph.cs : Program for traversing an undirected graph through DFS using recursion and classify all the edges in graph.

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
        private int INITIAL;
        private int VISITED;
        private int FINISHED;

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
				        vertexList[i].predecessor = vertex;
				        Console.WriteLine("Tree Edge - (" + vertexList[vertex].name + "," + vertexList[i].name + ")");

				        Dfs(i);
			        }
			        else if(vertexList[i].state == VISITED)
			        {
				        Console.WriteLine("Back Edge - (" + vertexList[vertex].name + "," + vertexList[i].name + ")");
			        }

		        }//End of if
	        }//End of for

	        vertexList[vertex].state = FINISHED;

        }//End of Dfs()

        public void DfsClassifyEdges()
        {
	        //Initially all the vertices will have INITIAL state
	        for(int i=0; i<nVertices; i++)
	        {
		        vertexList[i].state = INITIAL;
	        }

	        for(int v=0; v<nVertices; v++)
	        {
		        if(vertexList[v].state == INITIAL)
			        Dfs(v);
	        }

            Console.WriteLine();
        }//End of DfsClassifyEdges()

    }//End of class UndirectedGraph

    class UndirectedGraphDemo
    {
        static void Main(string[] args)
        {
            UndirectedGraph uGraph = new UndirectedGraph();

            try
            {
		        //Creating the graph, inserting the vertices and edges
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
		        uGraph.InsertEdge("0","2");
		        uGraph.InsertEdge("0","3");
		        uGraph.InsertEdge("2","3");

		        uGraph.InsertEdge("4","5");
		        uGraph.InsertEdge("4","6");
		        uGraph.InsertEdge("4","7");
		        uGraph.InsertEdge("4","8");
		        uGraph.InsertEdge("5","7");
		        uGraph.InsertEdge("6","8");
		        uGraph.InsertEdge("6","9");

		        uGraph.InsertEdge("10","11");
		        uGraph.InsertEdge("10","12");
		        uGraph.InsertEdge("10","13");
		        uGraph.InsertEdge("11","12");
		        uGraph.InsertEdge("11","13");
		        uGraph.InsertEdge("11","14");
		        uGraph.InsertEdge("13","14");

		        //Display the graph
		        uGraph.Display();
                Console.WriteLine();

		        //classify all the edges in graph
		        uGraph.DfsClassifyEdges();

            }//End of try
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }//End of Main()
    }//End of class UndirectedGraphDemo
}//End of namespace UndirectedGraph
