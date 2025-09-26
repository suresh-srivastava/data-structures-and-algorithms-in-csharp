//LinkedList7.cs : Program to delete the last node of a single linked list.

using System;

namespace LinkedList7Demo
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
            if(!IsEmpty())
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
                while (p != null)
                {
                    Console.WriteLine(p.info);
                    p = p.link;
                }
            }
        }//End of Display()	

        private Node DelAtEnd(Node p)
        {
            if(p.link == null)
            {
                return null;
            }

            p.link = DelAtEnd(p.link);

            return p;
        }//End of DelAtEnd()

        public void DelAtEnd()
        {
            start = DelAtEnd(start);
        }//End of DelAtEnd()

    }//End of class SingleLinkedList

    class LinkedList7Demo
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

    	    singleLinkedList.DelAtEnd();

    	    Console.WriteLine("After deletion of last node, list items are :");
    	    singleLinkedList.Display();
        }//End of Main()
    }//End of class LinkedList7Demo
}//End of namespace LinkedList7Demo
