//Stack.cs : Program to implement stack using array.

using System;

namespace StackDemo
{
    class Stack
    {
        private static readonly int MaxSize = 5;
	    private	int[] stackArray;
	    private int top;

	    public Stack()
	    {
            stackArray = new int[MaxSize];
		    top = -1;
	    }//End of Stack()
	
	    public bool IsEmpty()
	    {
		    return (top == -1);
	    }//End of IsEmpty()	
	
	    public bool IsFull()
	    {
            return (top == MaxSize-1);
	    }//End of IsFull()
	
	    public void Push(int data)
	    {
		    if(IsFull())
			    Console.WriteLine("Stack Overflow");
		    else
		    {
			    top++;
			    stackArray[top] = data;
		    }
	    }//End of Push()
	
	    public int Pop()
	    {
		    if(IsEmpty())
			    throw new Exception("Stack is empty");

		    int retValue = stackArray[top];
		    top = top-1;

		    return retValue;
	    }//End of Pop()
	
	    public int Peek()
	    {
		    if(IsEmpty())
			    throw new Exception("Stack is empty");

		    return stackArray[top];
	    }//End of Peek()

	    public int Size()
	    {
		    return (top+1);
	    }//End of Size()

	    public void Display()
	    {
		    if(IsEmpty())
			    Console.WriteLine("Stack is empty");
		    else
			    for(int i=top; i>=0; i--)
                    Console.WriteLine(stackArray[i]);
	    }//End of Display()	
	
    }//End of class Stack

    class StackDemo
    {
        static void Main(string[] args)
        {
		    Stack st = new Stack();
		
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
    }//End of class StackDemo
}//End of namespace StackDemo
