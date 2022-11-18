//Copyright (C) Suresh Kumar Srivastava - All Rights Reserved
//DSA Masterclass courses are available on CourseGalaxy.com

//DirectedGraph.cpp : Program to find out the path matrix using warshall's algorithm.

using System;

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

        public void WarshallsAlgorithm()
        {
	        int[,] P = new int[maxSize,maxSize];

	        //Initializing P(-1)
	        for(int i=0; i<nVertices; i++)
	        {
		        for(int j=0; j<nVertices; j++)
		        {
			        P[i,j] = adj[i,j];
		        }
	        }

	        //P0,P1......Pn-1
	        for(int k=0; k<nVertices; k++)
	        {
		        for(int i=0; i<nVertices; i++)
		        {
			        for(int j=0; j<nVertices; j++)
			        {
				        P[i,j] = ((P[i,j]!=0) || (P[i,k]!=0 && P[k,j]!=0 )) ? 1 : 0 ;
			        }
		        }

		        //Display P
		        Console.WriteLine("P" + k + " :");
		        for(int i=0; i<nVertices; i++)
		        {
     		        for(int j=0; j<nVertices; j++)
				        Console.Write(P[i,j] + " ");
                    Console.WriteLine();
		        }

	        }//End of for

        }//End of WarshallsAlgorithm()

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

                dGraph.InsertEdge("0","1");
                dGraph.InsertEdge("0","3");
                dGraph.InsertEdge("1","0");
                dGraph.InsertEdge("1","2");
                dGraph.InsertEdge("1","3");
                dGraph.InsertEdge("2","3");
                dGraph.InsertEdge("3","0");
                dGraph.InsertEdge("3","2");

                //Display the graph
                dGraph.Display();
                Console.WriteLine();

                Console.WriteLine("Find the path matrix :");
                dGraph.WarshallsAlgorithm();

            }//End of try
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }//End of Main()
    }//End of class DirectedGraphDemo
}//End of namespace DirectedGraph
