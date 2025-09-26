//Queue.cs : Program to implement queue using array.

using System;

namespace QueueDemo
{
    class Queue
    {
	    private static readonly int MaxSize = 5;
	    private	int[] queueArray;
	    private	int front;
	    private int rear;
	
	    public Queue()
	    {
		    queueArray = new int[MaxSize];
		    front = -1;
		    rear = -1;
	    }//End of Queue()

	    public bool IsEmpty()
	    {
		    return (front==-1 || front==rear+1);
	    }//End of IsEmpty()

	    public bool IsFull()
	    {
		    return (rear == MaxSize-1);
	    }//End of IsFull()
	
	    public void Enqueue(int data)
	    {
		    if(IsFull())
                Console.WriteLine("Queue Overflow");
		    else
		    {
			    if(front == -1)
				    front = 0;

			    rear = rear+1;
			    queueArray[rear] = data;
		    }
	    }//End of Enqueue()
	
	    public int Dequeue()
	    {
		    if(IsEmpty())
			    throw new Exception("Queue is empty");

		    return queueArray[front++];
	    }//End of Dequeue()	
	
	    public int Peek()
	    {
		    if(IsEmpty())
			    throw new Exception("Queue is empty");

		    return queueArray[front];
	    }//End of Peek()
	
	    public void Display()
	    {
            Console.WriteLine("Front = " + front + "	rear = " + rear);

		    if(IsEmpty())
			    Console.WriteLine("Queue is empty");
		    else
			    for(int i=front; i<=rear; i++)
				    Console.WriteLine(queueArray[i]);
	    }//End of display()

	    public int Size()
	    {
		    int retValue=0;

		    if(!IsEmpty())
			    retValue = rear-front+1;

		    return retValue;
	    }//End of Size()

    }//End of class Queue

    class QueueDemo
    {
        static void Main(string[] args)
        {
		    Queue qu = new Queue();

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
    }//End of class QueueDemo
}//End of namespace QueueDemo
