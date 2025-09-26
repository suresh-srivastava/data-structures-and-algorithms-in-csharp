//LinkedList5.cs : Program to find an element in a single linked list.

using System;

namespace LinkedList5Demo
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

        private bool Search(Node p, int data)
        {
            if(p == null)
                return false;

            if(p.info == data)
                return true;

            return Search(p.link, data);
        }//End of Search()

        public bool Search(int data)
        {
            return Search(start, data);
        }//End of Search()

    }//End of class SingleLinkedList

    class LinkedList5Demo
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

    	    int nodeData = 40;

    	    Console.WriteLine("List node " + nodeData + " found : " + (singleLinkedList.Search(nodeData) ? "True" : "False"));
        }//End of Main()
    }//End of class LinkedList5Demo
}//End of namespace LinkedList5Demo
