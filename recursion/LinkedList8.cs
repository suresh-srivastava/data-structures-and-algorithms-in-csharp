//LinkedList8.cs : Program to reverse a single linked list.

using System;

namespace LinkedList8Demo
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

        private Node Reverse(Node p)
        {
            Node temp;

            if(p.link == null)
                return p;

            temp = Reverse(p.link);
            p.link.link = p;
            p.link = null;

            return temp;
        }//End of Reverse()

        public void Reverse()
        {
            start = Reverse(start);
        }//End of Reverse()


    }//End of class SingleLinkedList

    class LinkedList8Demo
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

    	    singleLinkedList.Reverse();

    	    Console.WriteLine("After reverse, list items are :");
    	    singleLinkedList.Display();
        }//End of Main()
    }//End of class LinkedList8Demo
}//End of namespace LinkedList8Demo
