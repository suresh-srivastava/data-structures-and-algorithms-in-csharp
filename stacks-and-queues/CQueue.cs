//CQueue.cs : Program to implement circular queue using array.

using System;

namespace CQueueDemo
{
    class CQueue
    {
	    private static readonly int MaxSize = 5;
	    private int[] queueArray;
	    private	int front;
	    private int rear;

	    public CQueue()
	    { 
		    queueArray = new int[MaxSize];
		    front = -1;
		    rear = -1; 
	    }//End of CQueue()
	
	    public bool IsEmpty()
	    {
		    return (front == -1);
	    }//End of IsEmpty()

	    public bool IsFull()
	    {
		    return ((front==0 && rear==MaxSize-1) || (front==rear+1));
	    }//End of IsFull()
	
	    public void Enqueue(int num)
	    {
		    if(IsFull())
		    {
                Console.WriteLine("Queue Overflow");
		    }
		    else
		    {
			    if(front == -1)
				    front = 0;

			    if(rear == MaxSize-1) //rear is at last position of queue
				    rear = 0;
			    else
				    rear = rear+1;

			    queueArray[rear] = num;
		    }
	    }//End of Enqueue()	
	
	    public int Dequeue()
	    {
		    int retValue;

		    if(IsEmpty())
			    throw new Exception("Queue is empty");
		    else
		    {
			    retValue = queueArray[front];

			    if(front == rear) //queue has only one element
			    {
				    front = -1;
				    rear = -1;
			    }
			    else if(front == MaxSize-1)
				    front = 0;
			    else
				    front = front+1;
		    }

		    return retValue;
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
		    {
			    int i = front;
			    if(front <= rear)
			    {
				    while(i <= rear)
					    Console.WriteLine(queueArray[i++]);
			    }
			    else
			    {
				    while(i <= MaxSize-1)
					    Console.WriteLine(queueArray[i++]);
				
				    i=0;
				    while(i <= rear)
					    Console.WriteLine(queueArray[i++]);
			    }
		    }
	    }//End of Display()
	
	    public int Size()
	    {
		    if(IsEmpty())
			    return 0;

		    if(IsFull())
			    return MaxSize-1;

		    int i = front;
		    int sz = 0;

		    if(front <= rear)
		    {
			    while(i <= rear)
			    {
				    sz++;
				    i++;
			    }
		    }
		    else
		    {
			    while(i <= MaxSize-1)
			    {
				    sz++;
				    i++;
			    }

			    i = 0;
			    while(i <= rear)
			    {
				    sz++;
				    i++;
			    }
		    }

		    return sz;
	    }//End of Size()

    }//End of class CQueue

    class CQueueDemo
    {
        static void Main(string[] args)
        {
		    CQueue cq = new CQueue();

		    try
		    {
			    cq.Enqueue(1);
			    cq.Enqueue(2);
			    cq.Enqueue(3);
			    cq.Enqueue(4);

                Console.WriteLine("Queue Items :");
			    cq.Display();
			    Console.WriteLine("Front Item : " + cq.Peek());
			    Console.WriteLine("Total items : " + cq.Size());

			    Console.WriteLine("Deleted Item : " + cq.Dequeue());
			    Console.WriteLine("Deleted Item : " + cq.Dequeue());
			    Console.WriteLine("Queue Items :");
			    cq.Display();

			    cq.Enqueue(5);
			    cq.Enqueue(6);

			    Console.WriteLine("Queue Items :");
			    cq.Display();

			    cq.Enqueue(7);

			    Console.WriteLine("Deleted Item : " + cq.Dequeue());
			    Console.WriteLine("Deleted Item : " + cq.Dequeue());
			    Console.WriteLine("Deleted Item : " + cq.Dequeue());
			    Console.WriteLine("Deleted Item : " + cq.Dequeue());
			    Console.WriteLine("Deleted Item : " + cq.Dequeue());
			
			    Console.WriteLine("Queue Items :");
			    cq.Display();

		    }//End of try
		    catch(Exception e)
		    {
			    Console.WriteLine(e.Message);
		    }
        }//End of Main()
    }//End of class CQueueDemo
}//End of namespace CQueueDemo
