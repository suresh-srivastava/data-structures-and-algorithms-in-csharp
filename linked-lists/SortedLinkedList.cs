//SortedLinkedList.cs : Program of sorted linked list.

using System;

namespace SortedLinkedListDemo
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

    class SortedLinkedList
    {
        private Node start;

        public SortedLinkedList()
        {
            start = null;
        }//End of SortedLinkedList()

        public bool IsEmpty()
        {
            return (start == null);
        }//End of IsEmpty()

        public void Display()
	    {
		    Node p;

		    if(!IsEmpty())
		    {
			    p = start;
			    while(p != null)
			    {
				    Console.WriteLine(p.info);
				    p = p.link;
			    }
		    }
		    else
                Console.WriteLine("List is empty");
	    }//End of Display()

        public int Find(int nodeData)
        {
            Node p = start;
            int position = 0;

            while (p != null && p.info <= nodeData)
            {
                position++;
                if (p.info == nodeData)
                    return position;
                p = p.link;
            }

            return 0;
        }//End of Find()

        public void Insert(int data)
        {
            Node p, temp;

            temp = new Node(data);

            //List empty or new node to be inserted before first node
            if (IsEmpty() || data < start.info)
            {
                temp.link = start;
                start = temp;
            }
            else
            {
                p = start;
                while (p.link != null && p.link.info < data)
                    p = p.link;
                temp.link = p.link;
                p.link = temp;
            }
        }//End of Insert()

    }//End of class SortedLinkedList

    class SortedLinkedListDemo
    {
        static void Main(string[] args)
        {
    	    SortedLinkedList list = new SortedLinkedList();

    	    list.Insert(10);
    	    list.Insert(20);
    	    list.Insert(15);
    	    list.Insert(40);
    	    list.Insert(50);

    	    Console.WriteLine("List Items :");
    	    list.Display();

            Console.WriteLine("Find(40) = " + list.Find(40)); 
        }//End of Main()
    }//End of class SortedLinkedListDemo
}//End of namespace SortedLinkedListDemo
