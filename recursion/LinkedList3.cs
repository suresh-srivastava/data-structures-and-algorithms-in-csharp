//LinkedList3.cs : Program to display the elements of a single linked list.

using System;

namespace LinkedList3Demo
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

        private void Display(Node p)
	    {
		    if(p == null)
			    return;

		    Console.WriteLine(p.info);
		    Display(p.link);
	    }//End of Display()

        public void Display()
        {
            Display(start);
        }//End of Display()	

    }//End of class SingleLinkedList

    class LinkedList3Demo
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

        }//End of Main()
    }//End of class LinkedList3Demo
}//End of namespace LinkedList3Demo