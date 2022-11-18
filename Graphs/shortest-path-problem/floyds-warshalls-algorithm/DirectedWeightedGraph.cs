//Copyright (C) Suresh Kumar Srivastava - All Rights Reserved
//DSA Masterclass courses are available on CourseGalaxy.com

//DirectedWeightedGraph.cs : Program to find shortest path matrix by Modified Warshall's (Floyd) algorithm.

using System;

namespace DirectedWeightedGraph
{
    class Vertex
    {
        public String name;

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
		private int[,] D; //Shortest Path Matrix
		private int[,] Pred; //Predecessor Matrix
		int INFINITY;

        public DirectedWeightedGraph()
        {
            adj = new int[maxSize,maxSize];
            vertexList = new Vertex[maxSize];
            D = new int[maxSize,maxSize];
            Pred = new int[maxSize,maxSize];
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

        private void Display(int[,] mat)
        {
            for(int i=0; i<nVertices; i++)
            {
     	        for(int j=0; j<nVertices; j++)
			        Console.Write(mat[i,j] + " ");
                Console.WriteLine();
            }
        }//End of Display()

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

        private void FloydWarshallsAlgorithm(int s)
        {
	        //Getting D(-1), Pred(-1)
	        for(int i=0; i<nVertices; i++)
	        {
		        for(int j=0; j<nVertices; j++)
		        {
			        if(adj[i,j] == 0)
			        {
				        D[i,j] = INFINITY;
				        Pred[i,j] = -1;
			        }
			        else
			        {
				        D[i,j] = adj[i,j];
				        Pred[i,j] = i;
			        }
		        }
	        }//End of for

	        //Getting D(k), Pred(k)
	        for(int k=0; k<nVertices; k++)
	        {
		        for(int i=0; i<nVertices; i++)
		        {
			        for(int j=0; j<nVertices; j++)
			        {
				        if(D[i,k]+D[k,j] < D[i,j])
				        {
					        D[i,j] = D[i,k]+D[k,j];
					        Pred[i,j] = Pred[k,j];
				        }
			        }
		        }
	        }//End of for

	        //Finding negative cycle
	        for(int i=0; i<nVertices; i++)
	        {
		        if(D[i,i] < 0)
		        {
			        throw new System.Exception("There is negative cycle in graph.");
		        }
	        }

	        Console.WriteLine("Shortest Path Matrix :");
	        Display(D);
	        Console.WriteLine("\nPredecessor Matrix :");
	        Display(Pred);

        }//End of FloydWarshallsAlgorithm()

        private void FindPath(int s, int v)
        {
	        int[] path = new int[maxSize]; //stores the shortest path
	        int count=-1;			       //number of vertices in the shortest path			

	        if(D[s,v] == INFINITY)
	        {
		        Console.WriteLine("No path");
	        }
	        else
	        {
		        do
		        {
			        path[++count] = v;
			        v = Pred[s,v];
		        }while(v!=s);

		        path[++count] = s;
		        Console.Write("Shortest Path : ");
		        for(int i=count; i>=0; i--)
			        Console.Write(path[i] + " ");
                Console.WriteLine();
	        }

        }//End of FindPath()

        public void FindPaths(String source)
        {
	        int s = GetIndex(source);

	        FloydWarshallsAlgorithm(s);

	        Console.WriteLine("Source : " + source);

	        for(int v=0; v<nVertices; v++)
	        {
		        Console.WriteLine("Destination : " + vertexList[v].name);
		        FindPath(s, v);
		        Console.WriteLine("Shortest Distance : " + D[s,v]);
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

                dwGraph.InsertEdge("0","1",2);
                dwGraph.InsertEdge("0","3",9);
                dwGraph.InsertEdge("1","0",3);
                dwGraph.InsertEdge("1","2",4);
                dwGraph.InsertEdge("1","3",7);
                dwGraph.InsertEdge("2","1",6);
                dwGraph.InsertEdge("2","3",2);
                dwGraph.InsertEdge("3","0",14);
                dwGraph.InsertEdge("3","2",4);

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
