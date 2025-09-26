//LinkedList6.cs : Program to insert a node at the end of a single linked list.

using System;

namespace LinkedList6Demo
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

        private Node InsertAtEnd(Node p, int data)
        {
            Node temp;

            if(p == null)
            {
                temp = new Node(data);
                return temp;
            }

            p.link = InsertAtEnd(p.link, data);

            return p;
        }//End of InsertAtEnd()

        public void InsertAtEnd(int data)
        {
            start = InsertAtEnd(start, data);
        }//End of InsertAtEnd()

    }//End of class SingleLinkedList

    class LinkedList6Demo
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

    	    int data = 75;
    	    singleLinkedList.InsertAtEnd(data);

    	    Console.WriteLine("After inserting " + data + " at the end, list items are :");
    	    singleLinkedList.Display();
        }//End of Main()
    }//End of class LinkedList6Demo
}//End of namespace LinkedList6Demo
