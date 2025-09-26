//QueueL.cs : Program to implement queue using linked list.

using System;

namespace QueueLDemo
{
    class Node
    {
	    public int info;
	    public Node link;

	    public Node(int data)
	    {
		    info = data;
		    link = null;
	    }
    }//End of class Node

    class QueueL
    {
	    private Node front;
	    private Node rear;

	    public QueueL()
	    {
		    front = null;
		    rear = null;
	    }//End of QueueL()

	    public bool IsEmpty()
	    {
		    return (front == null);
	    }//End of IsEmpty()

	    public void Enqueue(int data)
	    {
		    Node temp;

		    temp = new Node(data);

		    if(IsEmpty()) //If queue is empty
			    front = temp;
		    else
			    rear.link = temp;

		    rear = temp;
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
			    p = front;
			    while(p != null)
			    {
                    Console.WriteLine(p.info);
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
		
    }//End of class QueueL

    class QueueLDemo
    {
        static void Main(string[] args)
        {
		    QueueL qu = new QueueL();

		    try
		    {
			    qu.Enqueue(1);
			    qu.Enqueue(2);
			    qu.Enqueue(3);
			    qu.Enqueue(4);

                Console.WriteLine("Queue Items :");
			    qu.Display();
			    Console.WriteLine("Front Item : " + qu.Peek());
			    Console.WriteLine("Total items : " + qu.Size());

			    Console.WriteLine("Deleted Item : " + qu.Dequeue());
			    Console.WriteLine("Queue Items :");
			    qu.Display();

			    qu.Enqueue(5);

			    Console.WriteLine("Queue Items :");
			    qu.Display();

			    Console.WriteLine("Deleted Item : " + qu.Dequeue());
			    Console.WriteLine("Deleted Item : " + qu.Dequeue());
			    Console.WriteLine("Deleted Item : " + qu.Dequeue());
			    Console.WriteLine("Deleted Item : " + qu.Dequeue());
			
			    Console.WriteLine("Queue Items :");
			    qu.Display();

		    }//End of try
		    catch(Exception e)
		    {
			    Console.WriteLine(e.Message);
		    }
        }//End of Main()
    }//End of class QueueLDemo
}//End of namespace QueueLDemo
