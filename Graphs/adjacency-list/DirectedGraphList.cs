//Copyright (C) Suresh Kumar Srivastava - All Rights Reserved
//DSA Masterclass courses are available on CourseGalaxy.com

//DirectedGraphList.cs : Program for directed graph using adjacency list.

using System;

namespace DirectedGraphList
{
    class VertexNode
    {
	    public String name;
        public VertexNode nextVertex;
        public EdgeNode firstEdge;

	    public VertexNode(String name)
        {
            this.name = name;
            nextVertex = null;
            firstEdge = null;
        }
    }//End of class VertexNode

    class EdgeNode
    {
	    public VertexNode endVertex;
        public EdgeNode nextEdge;

	    public EdgeNode(VertexNode v)
        {
            this.endVertex = v;
            nextEdge = null;
        }
    }//End of class EdgeNode

    class DirectedGraphList
    {
	    private int nVertices;
        public int nEdges;
	    public VertexNode start;

        public DirectedGraphList()
        {
	        nVertices = 0;
	        nEdges = 0;
	        start = null;
        }//End of DirectedGraphList()

        public void InsertVertex(String vertexName)
        {
	        VertexNode ptr, temp;
	        bool vertexFound = false;

	        ptr = start;

	        if(ptr == null)
	        {
		        temp = new VertexNode(vertexName);
		        start = temp;
		        nVertices++;
	        }
	        else
	        {
		        while(ptr.nextVertex != null)
		        {
			        if(ptr.name == vertexName)
			        {
				        vertexFound = true;
				        break;
			        }
			        ptr = ptr.nextVertex;
		        }//End of while

		        if(vertexFound || ptr.name==vertexName)
		        {
			        Console.WriteLine("Vertex already present");
		        }
		        else
		        {
			        temp = new VertexNode(vertexName);
			        ptr.nextVertex = temp;
			        nVertices++;
		        }
	        }//End of else

        }//End of InsertVertex()

        private VertexNode FindVertex(String vertexName)
        {
            VertexNode ptr = start;

            while(ptr != null)
            {
		        if(ptr.name == vertexName)
                    break;

		        ptr = ptr.nextVertex;
            }

            return ptr;
        }//End of FindVertex()

        public void InsertEdge(String source, String destination)
        {
	        VertexNode u, v;
	        EdgeNode edgePtr, temp;

	        bool edgeFound = false;

	        if(source == destination)
	        {
		        Console.WriteLine("Inavlid Edge : source and destination vertices are same");
	        }
	        else
	        {
		        u = FindVertex(source);
		        v = FindVertex(destination);

		        if(u == null)
		        {
                    Console.WriteLine("Source vertex not present, first insert vertex " + source);
		        }
		        else if(v == null)
		        {
			        Console.WriteLine("Destination vertex not present, first insert vertex " + destination);
		        }
		        else
		        {
			        if(u.firstEdge == null)
			        {
				        temp = new EdgeNode(v);
				        u.firstEdge = temp;
				        nEdges++;
			        }
			        else
			        {
				        edgePtr = u.firstEdge;

				        while(edgePtr.nextEdge != null)
				        {
					        if(edgePtr.endVertex.name == v.name)
					        {
						        edgeFound = true;
						        break;
					        }

					        edgePtr = edgePtr.nextEdge;
				        }//End of while

				        if(edgeFound || edgePtr.endVertex.name==destination)
				        {
					        Console.WriteLine("Edge already present");
				        }
				        else
				        {
					        temp = new EdgeNode(v);
					        edgePtr.nextEdge = temp;
					        nEdges++;
				        }
			        }//End of else
		        }//End of else
	        }//End of else

        }//End of InsertEdge()

        public void DeleteVertex(String vertexName)
        {
	        DeleteFromEdgeLists(vertexName);
	        DeleteFromVertexList(vertexName);
        }//End of DeleteVertex()

        //Delete incoming edges
        private void DeleteFromEdgeLists(String vertexName)
        {
	        VertexNode vertexPtr;
	        EdgeNode edgePtr;

	        vertexPtr = start;

	        while(vertexPtr != null)
	        {
		        if(vertexPtr.firstEdge != null)
		        {
			        if(vertexPtr.firstEdge.endVertex.name == vertexName)
			        {
				        vertexPtr.firstEdge = vertexPtr.firstEdge.nextEdge;
				        nEdges--;
				        continue;
			        }

			        edgePtr = vertexPtr.firstEdge;
			        while(edgePtr.nextEdge != null)
			        {
				        if(edgePtr.nextEdge.endVertex.name == vertexName)
				        {
					        edgePtr.nextEdge = edgePtr.nextEdge.nextEdge;
					        nEdges--;
					        continue;
				        }
				        edgePtr = edgePtr.nextEdge;
			        }
		        }//End of if

		        vertexPtr = vertexPtr.nextVertex;
	        }//End of while
        }//End of DeleteFromEdgeLists()

        //Delete outgoing edges and vertex
        private void DeleteFromVertexList(String vertexName)
        {
	        VertexNode vertexPtr, tempVertex=null;
            EdgeNode edgePtr;

	        if(start == null)
	        {
		        Console.WriteLine("No vertices to be deleted");
		        return;
	        }

	        if(start.name == vertexName)
	        {
		        tempVertex = start;
		        start = start.nextVertex;
	        }
	        else	//vertex to be deleted is in between or at last
	        {
		        vertexPtr = start;
		        while(vertexPtr.nextVertex != null)
		        {
			        if(vertexPtr.nextVertex.name == vertexName)
				        break;
			        vertexPtr = vertexPtr.nextVertex;
		        }

		        if(vertexPtr.nextVertex != null)
		        {
			        tempVertex = vertexPtr.nextVertex;
			        vertexPtr.nextVertex = vertexPtr.nextVertex.nextVertex;
		        }
		        else
		        {
			        Console.WriteLine("Vertex not found");
		        }
	        }//End of else

	        if(tempVertex != null)
	        {
		        edgePtr = tempVertex.firstEdge;
		        while(edgePtr != null)
		        {
			        edgePtr = edgePtr.nextEdge;
			        nEdges--;
		        }

		        nVertices--;
	        }

        }//End of DeleteFromVertexList()

        public void DeleteEdge(String source, String destination)
        {
	        VertexNode vertexPtr;
	        EdgeNode edgePtr;

	        vertexPtr = FindVertex(source);

	        if(vertexPtr == null)
	        {
		        Console.WriteLine("Edge not found");
	        }
	        else
	        {
		        edgePtr = vertexPtr.firstEdge;

		        if(edgePtr == null)
		        {
			        Console.WriteLine("Edge not found");
		        }
		        else
		        {
			        if(edgePtr.endVertex.name == destination)
			        {
				        vertexPtr.firstEdge = edgePtr.nextEdge;
				        nEdges--;
			        }
			        else
			        {
				        while(edgePtr.nextEdge != null)
				        {
					        if(edgePtr.nextEdge.endVertex.name == destination)
					        {
						        break;
					        }
					        edgePtr = edgePtr.nextEdge;
				        }

				        if(edgePtr.nextEdge == null)
				        {
					        Console.WriteLine("Edge not found");
				        }
				        else
				        {
					        edgePtr.nextEdge = edgePtr.nextEdge.nextEdge;
					        nEdges--;
				        }
			        }//End of else
		        }//End of else
	        }//End of else

        }//End of DeleteEdge()

        public void Display()
        {
	        VertexNode vertexPtr;
	        EdgeNode edgePtr;

	        vertexPtr = start;

	        while(vertexPtr != null)
	        {
		        Console.WriteLine("Vertex : " + vertexPtr.name);

		        edgePtr = vertexPtr.firstEdge;
		        while(edgePtr != null)
		        {
			        Console.WriteLine("Edge : " + vertexPtr.name + " -> " + edgePtr.endVertex.name);
			        edgePtr = edgePtr.nextEdge;
		        }

		        vertexPtr = vertexPtr.nextVertex;
	        }
        }//End of Display()

        public bool EdgeExists(String source, String destination)
        {
	        VertexNode vertexPtr;
	        EdgeNode edgePtr;
	        bool edgeFound = false;

	        vertexPtr = FindVertex(source);

	        if(vertexPtr != null)
	        {
		        edgePtr = vertexPtr.firstEdge;
		        while(edgePtr != null)
		        {
			        if(edgePtr.endVertex.name == destination)
			        {
				        edgeFound = true;
				        break;
			        }
			        edgePtr = edgePtr.nextEdge;
		        }
	        }

	        return edgeFound;
        }//End of EdgeExists()

        public int GetOutdegree(String vertex)
        {
	        VertexNode vertexPtr;
	        EdgeNode edgePtr;
	        int outdegree = 0;

	        vertexPtr = FindVertex(vertex);
	        if(vertexPtr == null)
		        throw new System.Exception("Invalid Vertex");

	        edgePtr = vertexPtr.firstEdge;
	        while(edgePtr != null)
	        {
		        outdegree++;
		        edgePtr = edgePtr.nextEdge;
	        }

	        return outdegree;
        }//End of GetOutdegree()

        public int GetIndegree(String vertex)
        {
	        VertexNode vertexPtr;
	        EdgeNode edgePtr;
	        int indegree = 0;

	        if(FindVertex(vertex) == null)
		        throw new System.Exception("Invalid Vertex");

	        vertexPtr = start;
	        while(vertexPtr != null)
	        {
		        edgePtr = vertexPtr.firstEdge;
		        while(edgePtr != null)
		        {
			        if(edgePtr.endVertex.name == vertex)
			        {
				        indegree++;
			        }
			        edgePtr = edgePtr.nextEdge;
		        }
		        vertexPtr = vertexPtr.nextVertex;
	        }

	        return indegree;
        }//End of GetIndegree()

    }//End of class DirectedGraphList

    class DirectedGraphListDemo
    {
        static void Main(string[] args)
        {
            DirectedGraphList dGraph = new DirectedGraphList();

            try
            {
		        //Creating the graph, inserting the vertices and edges
		        dGraph.InsertVertex("0");
		        dGraph.InsertVertex("1");
		        dGraph.InsertVertex("2");
		        dGraph.InsertVertex("3");

		        dGraph.InsertEdge("0","3");
		        dGraph.InsertEdge("1","2");
		        dGraph.InsertEdge("2","3");
		        dGraph.InsertEdge("3","1");
		        dGraph.InsertEdge("0","2");

		        //Display the graph
		        dGraph.Display();
                Console.WriteLine();

		        //Deleting an edge
		        dGraph.DeleteEdge("0","2");

		        //Display the graph
		        dGraph.Display();
                Console.WriteLine();

		        //Deleting a vertex
		        dGraph.DeleteVertex("0");

		        //Display the graph
		        dGraph.Display();

		        //Check if there is an edge between two vertices
		        Console.WriteLine("Edge exist : " + (dGraph.EdgeExists("2","3") ? "True" : "False"));

		        //Display Indegree and Outdegree of a vertex
		        Console.WriteLine("Outdegree : " + dGraph.GetOutdegree("3"));
		        Console.WriteLine("Indegree : " + dGraph.GetIndegree("3"));

            }//End of try
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }//End of Main()
    }//End of class DirectedGraphListDemo
}//End of namespace DirectedGraphList
