//LinkedList4.cs : Program to display the elements of a single linked list in reverse order.

using System;

namespace LinkedList4Demo
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

        private void Rdisplay(Node p)
	    {
		    if(p == null)
			    return;

		    Rdisplay(p.link);
		    Console.WriteLine(p.info);
	    }//End of Rdisplay()

        public void Rdisplay()
        {
            Rdisplay(start);
        }//End of Rdisplay()

    }//End of class SingleLinkedList

    class LinkedList4Demo
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

            Console.WriteLine("List Items in reverse order :");
    	    singleLinkedList.Rdisplay(); 

        }//End of Main()
    }//End of class LinkedList4Demo
}//End of namespace LinkedList4Demo
