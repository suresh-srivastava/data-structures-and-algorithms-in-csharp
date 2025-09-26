//PQueue.cs : Program to implement priority queue using linked list.

using System;

namespace PQueueDemo
{
    class Node
    {
	    public int info;
	    public int priority;
	    public Node link;

	    public Node(int data, int priority)
	    {
		    info = data;
		    this.priority = priority;
		    link = null;
	    }
    }//End of class Node

    class PQueue
    {
	    private Node front;

	    public PQueue()
	    {
		    front = null;
	    }//End of PQueue()

	    public bool IsEmpty()
	    {
	        return (front == null);
	    }//End of IsEmpty()
	
	    public void Enqueue(int data, int priority)
	    {
		    Node temp, p;

		    temp = new Node(data, priority);

		    //Queue is empty or element to be added has priority more than first element
		    if(IsEmpty() || priority < front.priority)
		    {
			    temp.link = front;
			    front = temp;
		    }
		    else
		    {
			    p = front;
			    while(p.link!=null && p.link.priority<=priority)
				    p = p.link;
			    temp.link = p.link;
			    p.link = temp;
		    }
	    }//End of Enqueue()
	
	    public int Dequeue()
	    {
		    int retValue;

		    if(IsEmpty())
			    throw new Exception("Queue is empty");
		    else 
		    {
			    retValue = front.info;
			    front = front.link;
		    }

		    return retValue;
	    }//End of Dequeue()	
	
	    public int Peek()
	    {
		    if(IsEmpty())
			    throw new Exception("Queue is empty");

		    return front.info;
	    }//End of Peek()	
	
	    public void Display()
	    {
		    Node p;

		    if(!IsEmpty())
		    {
                Console.WriteLine("Priority, Data Item");
			    p = front;
			    while(p != null)
			    {
				    Console.WriteLine(p.priority + ", " + p.info);
				    p = p.link;
			    }
		    }
		    else
			    Console.WriteLine("Queue is empty");

	    }//End of Display()	
	
	    public int Size()
	    {
		    Node p;
		    int count = 0;

		    p = front;
		    while(p != null)
		    {
			    count++;
			    p = p.link;
		    }

		    return count;
	    }//End of Size()	

    }//End of class PQueue

    class PQueueDemo
    {
        static void Main(string[] args)
        {
		    PQueue pq = new PQueue();

		    try
		    {
			    pq.Enqueue(20,2);
			    pq.Enqueue(10,1);
			    pq.Enqueue(50,4);
			    pq.Enqueue(30,3);

                Console.WriteLine("Queue Items :");
			    pq.Display();
			    Console.WriteLine("Front Item : " + pq.Peek());
			    Console.WriteLine("Total Items : " + pq.Size());

			    Console.WriteLine("Deleted Item : " + pq.Dequeue());
			    Console.WriteLine("Queue Items :");
			    pq.Display();

			    pq.Enqueue(40,5);

			    Console.WriteLine("Queue Items :");
			    pq.Display();

			    Console.WriteLine("Deleted Item : " + pq.Dequeue());
			    Console.WriteLine("Deleted Item : " + pq.Dequeue());
			    Console.WriteLine("Deleted Item : " + pq.Dequeue());
			    Console.WriteLine("Deleted Item : " + pq.Dequeue());
			
			    Console.WriteLine("Queue Items :");
			    pq.Display();

		    }//End of try
		    catch(Exception e)
		    {
			    Console.WriteLine(e.Message);
		    }
        }//End of Main()
    }//End of class PQueueDemo
}//End of namespace PQueueDemo
