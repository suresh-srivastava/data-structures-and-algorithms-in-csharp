//LinkedList1.cs : Program to get the length of a single linked list.

using System;

namespace LinkedList1Demo
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

    class SingleLinkedList
    {
        private Node start;

        public SingleLinkedList()
        {
            start = null;
        }//End of SingleLinkedList()

        public bool IsEmpty()
        {
            return start == null;
        }//End of IsEmpty()	

        public void InsertAtBeginning(int data)
        {
            Node temp;

            temp = new Node(data);
            if (!IsEmpty())
                temp.link = start;

            start = temp;
        }//End of InsertAtBeginning()	

        public void Display()
	    {
		    Node p;

		    if(IsEmpty())
		    {
			    Console.WriteLine("List is empty");
		    }
		    else
		    {
			    p = start;
			    while(p != null)
			    {
                    Console.WriteLine(p.info);
				    p = p.link;
			    }
		    }
	    }//End of Display()	

        private int Length(Node p)
        {
            if(p == null)
                return 0;

            return (1 + Length(p.link));
        }//End of Length()

        public int Length()
        {
            return Length(start);
        }//End of Length()

    }//End of class SingleLinkedList

    class LinkedList1Demo
    {
        static void Main(string[] args)
        {
    	    SingleLinkedList singleLinkedList = new SingleLinkedList();

    	    singleLinkedList.InsertAtBeginning(50);
    	    singleLinkedList.InsertAtBeginning(40);
    	    singleLinkedList.InsertAtBeginning(30);
    	    singleLinkedList.InsertAtBeginning(20);
    	    singleLinkedList.InsertAtBeginning(10);

    	    Console.WriteLine("List Items :");
    	    singleLinkedList.Display();

            Console.WriteLine("Length of list is : " + singleLinkedList.Length()); 
        }//End of Main()
    }//End of class LinkedList1Demo
}//End of namespace LinkedList1Demo
