//Deque.cs : Program to implement deque using circular array.

using System;

namespace DequeDemo
{
    class Deque
    {
	    private static readonly int MaxSize = 5;
	    private int[] queueArray;
	    private int front;
	    private int rear;

	    public Deque()
	    {
		    queueArray = new int[MaxSize];
		    front = -1;
		    rear = -1; 
	    }//End of Deque()
	
	    public bool IsEmpty()
	    {
		    return (front == -1);
	    }//End of IsEmpty()
	
	    public bool IsFull()
	    {
		    return ((front==0 && rear==MaxSize-1) || (front==rear+1));
	    }//End of IsFull()	
	
	    public void InsertFrontEnd(int data)
	    {
		    if(IsFull())
                Console.WriteLine("Queue Overflow");
		    else
		    {
			    if(front == -1) //If queue is initially empty
			    {
				    front = 0;
				    rear = 0;
			    }
			    else if(front == 0)
				    front = MaxSize-1;
			    else
				    front = front-1;

			    queueArray[front] = data;
		    }
	    }//End of InsertFrontEnd()	
	
	    public void InsertRearEnd(int data)
	    {
		    if(IsFull())
                Console.WriteLine("Queue Overflow");
		    else
		    {
			    if(front == -1) //If queue is initially empty
			    {
				    front = 0;
				    rear = 0;
			    }
			    else if(rear == MaxSize-1) //rear is at last position of queue
				    rear = 0;
			    else
				    rear = rear+1;

			    queueArray[rear] = data;
		    }
	    }//End of InsertRearEnd()	
	
	    public int DeleteFrontEnd()
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
	    }//End of DeleteFrontEnd()	
	
	    public int DeleteRearEnd()
	    {
		    int retValue;

		    if(IsEmpty())
			    throw new Exception("Queue is empty");
		    else
		    {
			    retValue = queueArray[rear];

			    if(front == rear) //queue has only one element
			    {
				    front = -1;
				    rear = -1;
			    }
			    else if(rear == 0)
				    rear = MaxSize-1;
			    else
				    rear = rear-1;
		    }

		    return retValue;
	    }//End of DeleteRearEnd()
	
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
	
    }//End of class Deque

    class DequeDemo
    {
        static void Main(string[] args)
        {
		    Deque dq = new Deque();

		    try
		    {
			    dq.InsertFrontEnd(2);
			    dq.InsertFrontEnd(1);
			    dq.InsertRearEnd(3);
			    dq.InsertRearEnd(4);

                Console.WriteLine("Queue Items :");
			    dq.Display();
			    Console.WriteLine("Total items : " + dq.Size());

			    Console.WriteLine("Deleted Item from front : " + dq.DeleteFrontEnd());
			    Console.WriteLine("Deleted Item from Rear : " + dq.DeleteRearEnd());
			    Console.WriteLine("Queue Items :");
			    dq.Display();

			    dq.InsertFrontEnd(5);
			    dq.InsertFrontEnd(6);

			    Console.WriteLine("Queue Items :");
			    dq.Display();

			    dq.InsertRearEnd(7);	

			    Console.WriteLine("Deleted Item : " + dq.DeleteFrontEnd());
			    Console.WriteLine("Deleted Item : " + dq.DeleteRearEnd());
			    Console.WriteLine("Deleted Item : " + dq.DeleteFrontEnd());
			    Console.WriteLine("Deleted Item : " + dq.DeleteRearEnd());
			    Console.WriteLine("Deleted Item : " + dq.DeleteFrontEnd());

			    Console.WriteLine("Queue Items :");
			    dq.Display();

		    }//End of try
		    catch(Exception e)
		    {
			    Console.WriteLine(e.Message);
		    }
        }//End of Main()
    }//End of class DequeDemo
}//End of namespace DequeDemo
