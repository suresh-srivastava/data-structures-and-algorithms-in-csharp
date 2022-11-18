//Copyright (C) Suresh Kumar Srivastava - All Rights Reserved
//DSA Masterclass courses are available on CourseGalaxy.com

//UndirectedWeightedGraph.cs : Program to create minimum spanning tree using Kruskal's algorithm.

using System;

namespace UndirectedWeightedGraph
{
    class Vertex
    {
        public String name;
        public int father;

        public Vertex(String name)
        {
            this.name = name;
        }
    }//End of class Vertex

    class Edge
    {
	    public int u;
		public int v;
		public int wt;

        public Edge(){}
        public Edge(int u, int v, int wt)
        {
            this.u = u;
            this.v = v;
            this.wt = wt;
        }

    }//End of class Edge

    class QueueNode
    {
        public Edge info;  
        public QueueNode link;
    
        public QueueNode(Edge edge) 
	    {
		    info = edge;
		    link = null;
	    }
    }//End of QueueNode

    class PriorityQueue
    {
        private QueueNode front;
	
	    public PriorityQueue()
	    {
		    front = null;
	    }//End of PriorityQueue()

	    public bool IsEmpty()
	    {
	    	return (front == null);
	    }//End of IsEmpty()

	    public void Enqueue(Edge edge)
	    {
		    QueueNode temp, ptr;
		
		    temp = new QueueNode(edge);

		    //Queue is empty or element to be added has priority more than first element
		    if(IsEmpty() || edge.wt < front.info.wt)
		    {
			    temp.link = front;
			    front = temp;
		    }
		    else
		    {
			    ptr = front;
			    while(ptr.link!=null && ptr.link.info.wt<=edge.wt)
			    	ptr = ptr.link;
			    temp.link = ptr.link;
			    ptr.link = temp;
		    }
	    }//End of Enqueue()

	    public Edge Dequeue()
	    {
		    Edge edge;

		    if(IsEmpty())
            {
		      throw new System.Exception("Queue Underflow");
            }
		    else
		    {
			    edge = front.info;
			    front = front.link;
		    }

		    return edge;
	    }//End of Dequeue()

    }//End of class PriorityQueue

    class UndirectedWeightedGraph
    {
        private readonly int maxSize = 30;
        private int nVertices;
        private int nEdges;
        private int[,] adj;
        private Vertex[] vertexList;
        private Edge[] treeEdges;
		int NIL;

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

        private void KruskalsAlgorithm()
        {
	        int count = 0;	//Number of edges in the tree

	        PriorityQueue edgeQueue = new PriorityQueue();

	        //Inserting all the edges in priority queue
	        for(int u=0; u<nVertices; u++)
	        {
		        for(int v=u; v<nVertices; v++)
		        {
			        if(IsAdjacent(u,v))
			        {
				        edgeQueue.Enqueue(new Edge(u,v,adj[u,v]));
			        }
		        }
	        }

	        //Initialize the father of vertices to NIL
	        for(int i=0; i<nVertices; i++)
	        {
		        vertexList[i].father = NIL;
	        }

	        int v1, v2, v1Root=NIL, v2Root=NIL;
	        Edge edge = new Edge();

	        while(!edgeQueue.IsEmpty() && count < nVertices-1)
	        {
		        edge = edgeQueue.Dequeue();

		        v1 = edge.u;
		        v2 = edge.v;

		        while(v1!=NIL)
		        {
			        v1Root = v1;
			        v1 = vertexList[v1].father;
		        }

		        while(v2!=NIL)
		        {
			        v2Root = v2;
			        v2 = vertexList[v2].father;
		        }

		        if(v1Root != v2Root)	//Include the edge in tree
		        {
			        treeEdges[++count] = new Edge(edge.u, edge.v, edge.wt);
			        vertexList[v2Root].father = v1Root;
		        }

	        }//End of while

	        treeEdges[count+1]=null;

	        if(count < nVertices-1)
	        {
		        throw new System.Exception("Graph is not connected, spanning tree is not possible.");
	        }

        }//End of KruskalsAlgorithm()

        public void MinimumSpanningTree()
        {
	        int treeWeight=0;

	        KruskalsAlgorithm();

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
                uwGraph.InsertVertex("6");
                uwGraph.InsertVertex("7");
                uwGraph.InsertVertex("8");

                uwGraph.InsertEdge("0","1",9);
                uwGraph.InsertEdge("0","3",4);
                uwGraph.InsertEdge("0","4",2);
                uwGraph.InsertEdge("1","2",10);
                uwGraph.InsertEdge("1","4",8);
                uwGraph.InsertEdge("2","4",7);
                uwGraph.InsertEdge("2","5",5);
                uwGraph.InsertEdge("3","4",3);
                uwGraph.InsertEdge("3","6",18);
                uwGraph.InsertEdge("4","5",6);
                uwGraph.InsertEdge("4","6",11);
                uwGraph.InsertEdge("4","7",12);
                uwGraph.InsertEdge("4","8",15);
                uwGraph.InsertEdge("5","8",16);
                uwGraph.InsertEdge("6","7",14);
                uwGraph.InsertEdge("7","8",20);

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

		        uwGraph.MinimumSpanningTree();

            }//End of try
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }//End of Main()
    }//End of class UndirectedWeightedGraphDemo
}//End of namespace UndirectedWeightedGraph
