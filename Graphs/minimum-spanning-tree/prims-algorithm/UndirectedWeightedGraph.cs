//Copyright (C) Suresh Kumar Srivastava - All Rights Reserved
//DSA Masterclass courses are available on CourseGalaxy.com

//UndirectedWeightedGraph.cs : Program to create minimum spanning tree using prim's algorithm.

using System;

namespace UndirectedWeightedGraph
{
    class Vertex
    {
        public String name;
        public int status;
        public int predecessor;
        public int length;

        public Vertex(String name)
        {
            this.name = name;
        }
    }//End of class Vertex

    class Edge
    {
	    public int u;
		public int v;

        public Edge(int u, int v)
        {
            this.u = u;
            this.v = v;
        }
    }//End of class Edge

    class UndirectedWeightedGraph
    {
        private readonly int maxSize = 30;
        private int nVertices;
        private int nEdges;
        private int[,] adj;
        private Vertex[] vertexList;
        private Edge[] treeEdges;
		private int TEMPORARY;
		private int PERMANENT;
		private int INFINITY;
		private int NIL;

        public UndirectedWeightedGraph()
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

            treeEdges = new Edge[maxSize];
            TEMPORARY = 0;
            PERMANENT = 1;
            INFINITY = 9999;
            NIL = -1;

        }//End of UndirectedWeightedGraph()

        public void InsertVertex(String vertexName)
        {
            vertexList[nVertices++] = new Vertex(vertexName);
        }//End of InsertVertex()

        private int GetIndex(String vertexName)
        {
            for (int i = 0; i < nVertices; i++)
            {
                if (vertexName == vertexList[i].name)
                    return i;
            }

            throw new System.Exception("Invalid Vertex");
        }//End of GetIndex()

        public void InsertEdge(String source, String destination, int weight)
        {
            int u = GetIndex(source);
            int v = GetIndex(destination);

            if (u == v)
                Console.WriteLine("Not a valid edge");
            else if(adj[u, v] != 0)
                Console.WriteLine("Edge already present");
            else
            {
                adj[u,v] = weight;
                adj[v,u] = weight;
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
            return (adj[u, v] != 0);
        }//End of IsAdjacent()

        //Returns the temporary vertex with minimum value of length,
        //Returns NIL if no temporary vertex left or all temporary vertices left have length INFINITY
        private int GetMinimumTemporary()
        {
	        int min = INFINITY;
	        int k = NIL;

	        for(int i=0; i<nVertices; i++)
	        {
		        if(vertexList[i].status==TEMPORARY && vertexList[i].length<min)
		        {
			        min = vertexList[i].length;
			        k=i;
		        }
	        }

	        return k;

        }//End of GetMinimumTemporary()

        private void PrimsAlgorithm(int r)
        {
	        int count = 0;	//Number of edges in the tree

	        //Make all vertices temporary
	        for(int i=0; i<nVertices; i++)
	        {
		        vertexList[i].status = TEMPORARY;
		        vertexList[i].predecessor = NIL;
		        vertexList[i].length = INFINITY;
	        }

	        //Make pathLength of source vertex equal to 0
	        vertexList[r].length = 0;

	        while(true)
	        {
		        //Search for temporary vertex with minimum pathLength and make it current vertex
		        int current = GetMinimumTemporary();

		        if(current == NIL)
		        {
			        if(count == nVertices-1)
			        {
				        break;	//No temporary vertex left
			        }
			        else		//Temporary vertices left with length INFINITY
			        {
				        throw new System.Exception("Graph is not connected, spanning tree is not possible.");
			        }
		        }

		        //Make current vertex PERMANENT
		        vertexList[current].status = PERMANENT;

		        //Insert the edge (vertexList[current]->predecessor,current) into the tree,
		        //except when the current vertex is root
		        if(current != r)
		        {
                    treeEdges[++count] = new Edge(vertexList[current].predecessor,current);
		        }

		        for(int v=0; v<nVertices; v++)
		        {
			        //Checks for adjacent temporary vertices
			        if(IsAdjacent(current,v) && vertexList[v].status==TEMPORARY)
			        {
				        if((adj[current,v]) < vertexList[v].length)
				        {
					        vertexList[v].predecessor = current;	//Relabel
					        vertexList[v].length = adj[current,v];
				        }
			        }
		        }//End of for
	        }//End of while

        }//End of PrimsAlgorithm()

        public void MinimumSpanningTree(String root)
        {
	        int r = GetIndex(root);
	        int treeWeight=0;

	        PrimsAlgorithm(r);

	        Console.WriteLine("Root vertex : " + root);

	        Console.WriteLine("Minimum Spanning Tree Edges :");
	        for(int i=1; i<=nVertices-1; i++)
	        {
		        Console.WriteLine("Edge - (" + treeEdges[i].u + "-" + treeEdges[i].v + ")");
		        treeWeight += adj[treeEdges[i].u,treeEdges[i].v];
	        }

	        Console.WriteLine("Minimum Spanning Tree Weight : " + treeWeight);

        }//End of MinimumSpanningTree()

    }//End of class UndirectedWeightedGraph

    class UndirectedWeightedGraphDemo
    {
        static void Main(string[] args)
        {
            UndirectedWeightedGraph uwGraph = new UndirectedWeightedGraph();

            try
            {
		        //Creating the graph, inserting the vertices and edges
		        //Connected graph
                uwGraph.InsertVertex("0");
                uwGraph.InsertVertex("1");
                uwGraph.InsertVertex("2");
                uwGraph.InsertVertex("3");
                uwGraph.InsertVertex("4");
                uwGraph.InsertVertex("5");

                uwGraph.InsertEdge("0","1",6);
                uwGraph.InsertEdge("0","2",2);
                uwGraph.InsertEdge("0","3",3);
                uwGraph.InsertEdge("0","4",10);
                uwGraph.InsertEdge("1","3",11);
                uwGraph.InsertEdge("1","5",9);
                uwGraph.InsertEdge("2","3",14);
                uwGraph.InsertEdge("2","4",8);
                uwGraph.InsertEdge("3","4",7);
                uwGraph.InsertEdge("3","5",5);
                uwGraph.InsertEdge("4","5",4);

		        //Not connected graph
                //uwGraph.InsertVertex("0");
                //uwGraph.InsertVertex("1");
                //uwGraph.InsertVertex("2");
                //uwGraph.InsertVertex("3");
                //uwGraph.InsertVertex("4");
                //uwGraph.InsertVertex("5");
                //uwGraph.InsertVertex("6");
                //uwGraph.InsertVertex("7");

                //uwGraph.InsertEdge("0","1",6);
                //uwGraph.InsertEdge("0","2",3);
                //uwGraph.InsertEdge("0","3",8);
                //uwGraph.InsertEdge("1","4",9);
                //uwGraph.InsertEdge("2","3",7);
                //uwGraph.InsertEdge("2","4",5);
                //uwGraph.InsertEdge("3","4",4);

                //uwGraph.InsertEdge("5","6",2);
                //uwGraph.InsertEdge("5","7",8);
                //uwGraph.InsertEdge("6","7",5);

		        //Display the graph
		        uwGraph.Display();
                Console.WriteLine();

		        uwGraph.MinimumSpanningTree("0");

            }//End of try
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }//End of Main()
    }//End of class UndirectedWeightedGraphDemo
}//End of namespace UndirectedWeightedGraph
