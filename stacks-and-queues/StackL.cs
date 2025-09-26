//StackL.cs : Program to implement stack using linked list.

using System;

namespace StackLDemo
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

    class StackL
    {
	    private Node top;

	    public StackL()
	    { 
		    top = null;
	    }//End of StackL()
    
	    public bool IsEmpty()
	    {
		    return (top == null);
	    }//End of IsEmpty()
    
	    public void Push(int data)
	    {
		    Node temp;

		    temp = new Node(data);
		    if(!IsEmpty())
			    temp.link = top;

		    top = temp;
	    }//End of Push()
    
	    public int Pop()
	    {
		    int retValue;

		    if(IsEmpty())
			    throw new Exception("Stack is empty");
		    else 
		    {
			    retValue = top.info;
			    top = top.link;
		    }

		    return retValue;
	    }//End of Pop()
    
	    public int Peek()
	    {
		    if(IsEmpty())
			    throw new Exception("Stack is empty");

		    return top.info;
	    }//End of Peek()

	    public void Display()
	    {
		    Node p;

		    if(!IsEmpty())
		    {
			    p = top;
			    while(p != null)
			    {
				    Console.WriteLine(p.info);
				    p = p.link;
			    }
		    }
		    else
                Console.WriteLine("Stack is empty");

	    }//End of Display()

	    public int Size()
	    {
		    Node p;
		    int count = 0;

		    p = top;
		    while(p != null)
		    {
			    count++;
			    p = p.link;
		    }

		    return count;
	    }//End of Size()
    
    }//End of class StackL

    class StackLDemo
    {
        static void Main(string[] args)
        {
		    StackL st = new StackL();

		    try
		    {
			    st.Push(1);
			    st.Push(2);
			    st.Push(3);
			    st.Push(4);

			    Console.WriteLine("Stack Items :");
			    st.Display();
			    Console.WriteLine("Top Item : " + st.Peek());
			    Console.WriteLine("Total items : " + st.Size());

			    Console.WriteLine("Popped Item : " + st.Pop());
			    Console.WriteLine("Stack Items :");
			    st.Display();

			    st.Push(4);
			    st.Push(5);

			    Console.WriteLine("Stack Items :");
			    st.Display();

			    Console.WriteLine("Popped Item : " + st.Pop());
			    Console.WriteLine("Popped Item : " + st.Pop());
			    Console.WriteLine("Popped Item : " + st.Pop());
			    Console.WriteLine("Popped Item : " + st.Pop());
			    Console.WriteLine("Popped Item : " + st.Pop());

			    Console.WriteLine("Stack Items :");
			    st.Display();

		    }//End of try
		    catch(Exception e)
		    {
                Console.WriteLine(e.Message);
		    }
            }//End of Main()
    }//End of class StackLDemo
}//End of namespace StackLDemo
