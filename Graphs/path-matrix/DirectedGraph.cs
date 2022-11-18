//Copyright (C) Suresh Kumar Srivastava - All Rights Reserved
//DSA Masterclass courses are available on CourseGalaxy.com

//DirectedGraph.cs : Program to find out the path matrix by powers of adjacency matrix.

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

        public void PathMatrix()
        {
            int[,] adjp, x, temp;
            int[,] path;

            adjp = new int[maxSize,maxSize];
            x = new int[maxSize,maxSize];
            temp = new int[maxSize,maxSize];
            path = new int[maxSize,maxSize];

	        //Initialize x
            for(int i=0; i<nVertices; i++)
            {
     	        for(int j=0; j<nVertices; j++)
		        {
			        x[i,j] = 0;
		        }
            }

	        //Initially adjp and x is equal to adj
            for(int i=0; i<nVertices; i++)
            {
     	        for(int j=0; j<nVertices; j++)
		        {
			        x[i,j] = adjp[i,j] = adj[i,j];
		        }
            }

	        //Get the matrix x by adding all the adjp
	        for(int p=2; p<=nVertices; p++)
	        {
		        //adjp(1...n) x adj
		        for(int i=0; i<nVertices; i++)
		        {
			        for(int j=0; j<nVertices; j++)
			        {
				        temp[i,j]=0;
				        for(int k=0; k<nVertices; k++)
				        {
					        temp[i,j] = temp[i,j] + adjp[i,k]*adj[k,j];
				        }
			        }
		        }

		        //Now adjp will be equal to temp
		        for(int i=0; i<nVertices; i++)
		        {
     		        for(int j=0; j<nVertices; j++)
			        {
				        adjp[i,j] = temp[i,j];
			        }
		        }

		        //x = adjp1 + adjp2 + ...... + adjpn
		        for(int i=0; i<nVertices; i++)
		        {
     		        for(int j=0; j<nVertices; j++)
			        {
				        x[i,j] = x[i,j] + adjp[i,j];
			        }
		        }
	        }//End of for

	        //Display x
	        Console.WriteLine("x matrix is :");
            for(int i=0; i<nVertices; i++)
            {
     	        for(int j=0; j<nVertices; j++)
		        {
			        Console.Write(x[i,j] + " ");
		        }
                Console.WriteLine();
            }

	        //Assign values to path matrix
            for(int i=0; i<nVertices; i++)
            {
     	        for(int j=0; j<nVertices; j++)
		        {
			        if(x[i,j] == 0)
				        path[i,j] = 0;
			        else
				        path[i,j] = 1;
		        }
            }

	        //Display path matrix
	        Console.WriteLine("Path matrix is :");
            for(int i=0; i<nVertices; i++)
            {
     	        for(int j=0; j<nVertices; j++)
                    Console.Write(path[i,j] + " ");
                Console.WriteLine();
            }

        }//End of PathMatrix()

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
                dGraph.PathMatrix();
            }//End of try
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }//End of Main()
    }//End of class DirectedGraphDemo
}//End of namespace DirectedGraph
