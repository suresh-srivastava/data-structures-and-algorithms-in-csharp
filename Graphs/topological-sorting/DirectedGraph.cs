//Copyright (C) Suresh Kumar Srivastava - All Rights Reserved
//DSA Masterclass courses are available on CourseGalaxy.com

//DirectedGraph.cs : Program for topological sorting of directed acyclic graph.

using System;
using System.Collections.Generic;

namespace DirectedGraph
{
    class Vertex
    {
	    public String name;

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

        //Returns number of edges coming to a vertex
        private int GetIndegree(int vertex)
        {
            int indegree = 0;
            for(int v=0; v<nVertices; v++)
                if(adj[v,vertex]!=0)
                    indegree++;

            return indegree;
        }//End of GetIndegree()

        public void TopologicalOrder()
        {
	        int[] topoOrder = new int[maxSize];
            int[] indegree = new int[maxSize];
	        Queue<int> q = new Queue<int>();
	        int v, count;

	        //Get the indegree of each vertex
	        for(v=0; v<nVertices; v++)
	        {
		        indegree[v] = GetIndegree(v);
		        if(indegree[v] == 0)
			        q.Enqueue(v);
	        }

	        count=0;
	        while(q.Count!=0 && count<nVertices)
	        {
		        v = q.Dequeue();

		        topoOrder[++count] = v;	//Add vertex v to topoOrder array

		        //Delete all the edges going from vertex v
		        for(int i=0; i<nVertices; i++)
		        {
			        if(adj[v,i]!=0)
			        {
				        adj[v,i] = 0;
				        indegree[i] = indegree[i]-1;
				        if(indegree[i] == 0)
					        q.Enqueue(i);
			        }
		        }

	        }//End of while

	        if(count < nVertices)
	        {
		        throw new System.Exception("Graph contains cycle. Topological order is not possible.");
	        }

	        Console.WriteLine("Vertices in topological order are :");
	        for(int i=1; i<=count; i++)
		        Console.Write(topoOrder[i] + " ");
            Console.WriteLine();

        }//End of TopologicalOrder()

    }//End of class DirectedGraph

    class DirectedGraphDemo
    {
        static void Main(string[] args)
        {
            DirectedGraph dGraph = new DirectedGraph();

            try
            {
                //Creating the graph, inserting the vertices and edges
                //Graph without cycle
                dGraph.InsertVertex("0");
                dGraph.InsertVertex("1");
                dGraph.InsertVertex("2");
                dGraph.InsertVertex("3");
                dGraph.InsertVertex("4");
                dGraph.InsertVertex("5");
                dGraph.InsertVertex("6");

                dGraph.InsertEdge("0","1");
                dGraph.InsertEdge("0","5");
                dGraph.InsertEdge("1","4");
                dGraph.InsertEdge("1","5");
                dGraph.InsertEdge("2","1");
                dGraph.InsertEdge("2","3");
                dGraph.InsertEdge("3","1");
                dGraph.InsertEdge("3","4");
                dGraph.InsertEdge("4","5");
                dGraph.InsertEdge("6","4");
                dGraph.InsertEdge("6","5");

                //Graph with cycle
                //dGraph.InsertVertex("0");
                //dGraph.InsertVertex("1");
                //dGraph.InsertVertex("2");
                //dGraph.InsertVertex("3");
                //dGraph.InsertVertex("4");

                //dGraph.InsertEdge("0","1");
                //dGraph.InsertEdge("0","2");
                //dGraph.InsertEdge("1","3");
                //dGraph.InsertEdge("2","4");
                //dGraph.InsertEdge("3","0");
                //dGraph.InsertEdge("3","4");

                //Display the graph
                dGraph.Display();

                dGraph.TopologicalOrder();

            }//End of try
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }//End of Main()
    }//End of class DirectedGraphDemo
}//End of namespace DirectedGraph
