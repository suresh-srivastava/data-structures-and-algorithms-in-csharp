//SingleLinkedListH.cs : Program of single linked list with header node.

using System;

namespace SingleLinkedListHDemo
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

    class SingleLinkedListH
    {
        private Node head;

        public SingleLinkedListH()
        {
            head = new Node(0);
        }//End of SingleLinkedListH()

        public SingleLinkedListH(SingleLinkedListH list)
        {
            Node p1, p2;
            p1 = list.head;
            p2 = head = new Node(p1.info);
            p1 = p1.link;

            while (p1 != null)
            {
                p2.link = new Node(p1.info);
                p2 = p2.link;
                p1 = p1.link;
            }
        }//End of copy constructor	

        public bool IsEmpty()
        {
            return (head.link == null);
        }//End of IsEmpty()

        public void Display()
	    {
		    Node p;

		    if(!IsEmpty())
		    {
			    p = head.link;
			    while(p != null)
			    {
				    Console.WriteLine(p.info);
				    p = p.link;
			    }
		    }
		    else
                Console.WriteLine("List is empty");
	    }//End of Display()

        public void InsertAtBeginning(int data)
        {
            Node temp;

            temp = new Node(data);
            temp.link = head.link;
            head.link = temp;
        }//End of InsertAtBeginning()	

        public void InsertAtEnd(int data)
        {
            Node p, temp;

            temp = new Node(data);

            p = head;
            while (p.link != null)
                p = p.link;
            p.link = temp;

        }//End of InsertAtEnd()	

        public void InsertBefore(int data, int nodeData)
	    {
		    Node p, temp;

		    p = head;

		    if(IsEmpty())
			    Console.WriteLine("List is empty");
		    else
		    {
			    //Find reference to predecessor of node containing nodeData
			    while(p.link != null)
			    {
				    if(p.link.info == nodeData)
				    {
					    temp = new Node(data);
					    temp.link = p.link;
					    p.link = temp;

					    break;
				    }
				    p = p.link;
			    }

			    if(p.link == null)
                    Console.WriteLine("Item " + nodeData + " is not in the List");

		    }//End of else

	    }//End of InsertBefore()	

        public void InsertAfter(int data, int nodeData)
	    {
		    Node p, temp;

		    p = head.link;
		    if(IsEmpty())
			    Console.WriteLine("List is empty");
		    else
		    {
			    while(p != null)
			    {
				    if(p.info == nodeData)
				    {
					    temp = new Node(data);
					    temp.link = p.link;
					    p.link = temp;
					    break;
				    }
				    p = p.link;
			    }

			    if(p == null)
				    Console.WriteLine("Item " + nodeData + " is not in the list");

		    }//End of else
	    }//End of InsertAfter()	

        public void InsertAtPosition(int data, int position)
	    {
		    Node p, temp;

		    if(position == 1)
		    {
			    temp = new Node(data);
			    temp.link = head.link;
			    head.link = temp;
		    }
		    else
		    {
			    p = head.link;
			    int index = 1;
			    while(p!=null && index < position-1) //Find a reference to (position-1)th node
			    {
				    p = p.link;
				    index++;
			    }

			    if(p!=null && position>0)
			    {
				    temp = new Node(data);
				    temp.link = p.link;
				    p.link = temp;
			    }
			    else
				    Console.WriteLine("Item cannot be inserted at position : " + position);

		    }//End of else

	    }//End of InsertAtPosition()

        public void DeleteAtBeginning()
	    {
		    if(IsEmpty())
			    Console.WriteLine("List is empty");
		    else 
                head.link = head.link.link;
	    }//End of DeleteAtBeginning()	

        public void DeleteAtEnd()
	    {
		    Node p;

		    p = head;

		    if(IsEmpty())
			    Console.WriteLine("List is empty");
		    else
		    {
			    while(p.link.link != null)
				    p = p.link;

			    p.link = null;
		    }
	    }//End of DeleteAtEnd()	

        public void DeleteNode(int nodeData)
	    {
		    Node p;

		    p = head;
		    if(IsEmpty())
			    Console.WriteLine("List is empty");
		    else
		    {
			    while(p.link != null)
			    {
				    if(p.link.info == nodeData)
					    break;
				    p = p.link;
			    }

                if(p.link == null)
                    Console.WriteLine(nodeData + " not found in list");
			    else
				    p.link = p.link.link;
		    }//End of else
	    }//End of DeleteNode()	

        public void DeleteAtPosition(int position)
	    {
		    Node p;

		    p = head.link;

		    if(IsEmpty())
			    Console.WriteLine("List is empty");
		    else if(position == 1)
			    head.link = p.link;
		    else
		    {
			    int index = 1;

			    while(p.link!=null && index < position-1)
			    {
				    p = p.link;
				    index++;
			    }

			    if(p.link!=null && position>0)
				    p.link = p.link.link;
			    else
				    Console.WriteLine("Node cannot be deleted at position : " + position);
		    }//End of else

	    }//End of DeleteAtPosition()

        public void Reverse()
	    {
		    Node prev, p, next;

		    if(IsEmpty())
			    Console.WriteLine("List is empty");
		    else
		    {
			    p = head.link;
			    prev = null;

			    while(p != null)
			    {
				    next = p.link;
				    p.link = prev;
				    prev = p;
				    p = next;
			    }
			    head.link = prev;
		    }
	    }//End of Reverse()	


    }//End of class SingleLinkedListH

    class SingleLinkedListHDemo
    {
        static void Main(string[] args)
        {
		    SingleLinkedListH list1 = new SingleLinkedListH();

		    //Create the List
		    list1.InsertAtBeginning(10);
		    list1.InsertAtEnd(30);
		    list1.InsertAfter(50,30);
		    list1.InsertAtPosition(20,2);
		    list1.InsertBefore(40,50);

		    Console.WriteLine("List1 Items after insertion :");
		    list1.Display();

		    SingleLinkedListH list2 = new SingleLinkedListH(list1);
		    Console.WriteLine("List2 Items after using copy constructor :");
		    list2.Display();
		
		    list1.DeleteAtBeginning();
		    list1.DeleteAtEnd();
		    list1.DeleteNode(30);
		    list1.DeleteAtPosition(2);

		    Console.WriteLine("List1 Items after deletion :");
		    list1.Display();

		    list2.Reverse();
		    Console.WriteLine("List2 Items after reverse :");
		    list2.Display();
            }//End of Main()
    }//End of class SingleLinkedListHDemo
}//End of namespace SingleLinkedListHDemo
