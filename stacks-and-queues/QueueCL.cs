//QueueCL.cs : Program to implement queue using circular linked list.

using System;

namespace QueueCLDemo
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

    class QueueCL
    {
	    private Node rear;

	    public QueueCL()
	    {
		    rear = null;
	    }//End of QueueCL()

	    public bool IsEmpty()
	    {
		    return (rear == null);
	    }//End of IsEmpty()

	    public void Enqueue(int data)
	    {
		    Node temp;

		    temp = new Node(data);

		    if(IsEmpty()) //If queue is empty
		    {
			    rear = temp;
			    temp.link = rear;
		    }
		    else
		    {
			    temp.link = rear.link;
			    rear.link = temp;
			    rear = temp;
		    }
		
	    }//End of Enqueue()

	    public int Dequeue()
	    {
		    int retValue;

		    if(IsEmpty())
			    throw new Exception("Queue is empty");

		    if(rear.link == rear) //If only one element
		    {
			    retValue = rear.info;
			    rear = null;
		    }
		    else
		    {
			    retValue = rear.link.info;
			    rear.link = rear.link.link;
		    }

		    return retValue;
	    }//End of Dequeue()

	    public int Peek()
	    {
		    if(IsEmpty())
			    throw new Exception("Queue is empty");

		    return rear.link.info;
	    }//End of Peek()

	    public void Display()
	    {
		    Node p;

		    if(!IsEmpty())
		    {
			    p = rear.link;
			    do
			    {
                    Console.WriteLine(p.info);
				    p = p.link;
			    }while(p != rear.link);
		    }
		    else
			    Console.WriteLine("Queue is empty");

	    }//End of Display()

	    public int Size()
	    {
		    Node p;
		    int count = 0;

		    if(!IsEmpty())
		    {
			    p = rear.link;
			    do
			    {
				    count++;
				    p = p.link;
			    }while(p != rear.link);
		    }

		    return count;
	    }//End of Size()	
	
    }//End of class QueueCL

    class QueueCLDemo
    {
        static void Main(string[] args)
        {
		    QueueCL qu = new QueueCL();

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
    }//End of class QueueCLDemo
}//End of namespace QueueCLDemo
