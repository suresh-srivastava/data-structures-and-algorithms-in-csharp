//DoublyLinkedList.cs : Program of Doubly linked list.

using System;

namespace DoublyLinkedListDemo
{
    class Node
    {
        public int info;
        public Node prev;
        public Node next;

        public Node(int data)
        {
            info = data;
            prev = null;
            next = null;
        }
    }//End of class Node

    class DoublyLinkedList
    {
        private Node start;

        public DoublyLinkedList()
        {
            start = null;
        }//End of DoublyLinkedList()

        public DoublyLinkedList(DoublyLinkedList list)
        {
            if (list.start == null)
                start = null;
            else
            {
                Node p1, p2, previous;

                p1 = list.start;
                p2 = start = new Node(p1.info);
                previous = null;

                p1 = p1.next;

                while (p1 != null)
                {
                    p2.next = new Node(p1.info);
                    p2.prev = previous;
                    previous = p2;
                    p2 = p2.next;
                    p1 = p1.next;
                }
                p2.prev = previous;
            }
        }//End of copy constructor	

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
				    p = p.next;
			    }
		    }
		    else
			    Console.WriteLine("List is empty");
	    }//End of Display()

        public int Size()
        {
            Node p;
            int count = 0;

            p = start;
            while (p != null)
            {
                count++;
                p = p.next;
            }

            return count;
        }//End of Size()	

        public int Find(int nodeData)
        {
            Node p = start;
            int position = 0;

            while (p != null)
            {
                position++;
                if (p.info == nodeData)
                    return position;
                p = p.next;
            }

            return 0;
        }//End of Find()	

        public void InsertAtBeginning(int data)
        {
            Node temp;

            temp = new Node(data);
            if (!IsEmpty())
            {
                temp.next = start;
                start.prev = temp;
            }

            start = temp;
        }//End of InsertAtBeginning()	

        public void InsertAtEnd(int data)
        {
            Node p, temp;

            temp = new Node(data);

            if (IsEmpty())
                start = temp;
            else
            {
                p = start;
                while (p.next != null)
                    p = p.next;

                p.next = temp;
                temp.prev = p;
            }
        }//End of InsertAtEnd()	

        public void InsertBefore(int data, int nodeData)
	    {
		    Node p, temp;

		    if(IsEmpty())
			    Console.WriteLine("List is empty");
		    else if(start.info == nodeData) //nodeData is in first node
		    {
	            temp = new Node(data);
	            temp.next = start;
	            start.prev = temp;
	            start = temp;
		    }
		    else
		    {
			    p = start.next;
			    while(p != null)
			    {
				    if(p.info == nodeData)
				    {
					    temp = new Node(data);
					    temp.prev = p.prev;
					    temp.next = p;
					    p.prev.next = temp;
					    p.prev = temp;
					    break;
				    }

				    p = p.next;
			    }

			    if(p == null)
				    Console.WriteLine("Item " + nodeData + " is not in the List");

		    }//End of else
	    }//End of InsertBefore()	

        public void InsertAfter(int data, int nodeData)
	    {
		    Node p, temp;

		    if(IsEmpty())
			    Console.WriteLine("List is empty");
		    else
		    {
			    p = start;
			    while(p != null)
			    {
				    if(p.info == nodeData)
				    {
					    temp = new Node(data);
					    temp.prev = p;
					    temp.next = p.next;
					    if(p.next != null)
						    p.next.prev = temp; //should not be done when p refers to last node
					    p.next = temp;

					    break;
				    }
				    p = p.next;
			    }

			    if(p == null)
                    Console.WriteLine("Item " + nodeData + " is not in the list");

		    }//End of else
	    }//End of InsertAfter()	

        public void InsertAtPosition(int data, int position)
	    {
		    Node temp, p;

		    if(position == 1)
		    {
			    temp = new Node(data);
			    if(!IsEmpty())
			    {
				    temp.next = start;
				    start.prev = temp;
			    }
			    start = temp;
		    }
		    else
		    {
			    p = start;
			    int index = 1;
			    while(p != null && index < position-1) //Find a reference to (position-1)th node
			    {
				    p = p.next;
				    index++;
			    }

			    if(p!=null && position>0)
			    {
				    temp = new Node(data);
				    temp.prev = p;
				    temp.next = p.next;
				    if(p.next != null)
					    p.next.prev = temp; //should not be done when p refers to last node
				    p.next = temp;
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
		    {
			    if(start.next == null) //If list has only 1 node
				    start = null;
			    else
			    {
				    start = start.next;
				    start.prev = null;
			    }
		    }
	    }//End of DeleteAtBeginning()	

        public void DeleteAtEnd()
	    {
		    Node p;

		    if(IsEmpty())
                Console.WriteLine("List is empty");
		    else
		    {
			    p = start;
			    while(p.next != null)
				    p = p.next;

			    if(p.prev != null)
				    p.prev.next = null;
			    else
				    start = null;
		    }
	    }//End of DeleteAtEnd()	

        public void DeleteNode(int nodeData)
	    {
		    Node p;

		    if(IsEmpty())
			    Console.WriteLine("List is empty");
		    else
		    {
			    p = start;
			    while(p.next != null)
			    {
				    if(p.info == nodeData)
					    break;
	        
				    p = p.next;
			    }

			    if(p.info == nodeData)
			    {
				    if(p.next == null)
				    {
					    if(p.prev == null) //First and only node
						    start = null;
					    else
						    p.prev.next = null; //Last node
				    }
				    else
				    {
					    if(p.prev == null) //First node
					    {
						    p.next.prev = null;
						    start = p.next;
					    }
					    else //Node in between
					    {
						    p.prev.next = p.next;
						    p.next.prev = p.prev;
					    }
				    }

			    }//End of if
			    else
                    Console.WriteLine(nodeData + " not found in list");

		    }//End of else

	    }//End of DeleteNode()	

        public void DeleteAtPosition(int position)
	    {
	        Node p;

		    if(IsEmpty())
			    Console.WriteLine("List is empty");
		    else
		    {
			    p = start;
			    int index = 1;
			    while(p.next != null)
			    {
				    if(index == position)
					    break;
	        
				    index++;
				    p = p.next;
			    }

			    if(position == 1)
			    {
				    if(p.next == null) //First node of only node in list
					    start = null;
				    else //First node of more than one node in list
				    {
					    p.next.prev = null;
					    start = p.next;
				    }

			    }
			    else if(index == position)
			    {
				    if(p.next == null)
					    p.prev.next = null;
				    else
				    {
					    p.next.prev = p.prev;
					    p.prev.next = p.next;
				    }
			    }
			    else
                    Console.WriteLine("Node cannot be deleted at position : " + position);

		    }//End of else

	    }//End of DeleteAtPosition()	

        public void Reverse()
	    {
	        Node p, temp;

		    if(IsEmpty())
                Console.WriteLine("List is empty");
		    else
		    {
			    p = start;
			    while(p.next != null)
			    {
				    temp = p.next;
				    p.next = p.prev;
				    p.prev = temp;
				    p = temp;
			    }

			    p.next = p.prev;
			    p.prev = null;
			    start = p;
		    }
	    }//End of Reverse()	

    }//End of class DoublyLinkedList

    class DoublyLinkedListDemo
    {
        static void Main(string[] args)
        {
    	    DoublyLinkedList list1 = new DoublyLinkedList();

    	    //Create the List
    	    list1.InsertAtBeginning(10);
    	    list1.InsertAtEnd(30);
    	    list1.InsertAfter(50,30);
    	    list1.InsertAtPosition(20,2);
    	    list1.InsertBefore(40,50);

    	    Console.WriteLine("List1 Items after insertion :");
    	    list1.Display();

    	    Console.WriteLine("Total items : " + list1.Size());
    	    Console.WriteLine("Find(40) = " + list1.Find(40));
    	
    	    DoublyLinkedList list2 = new DoublyLinkedList(list1);
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
    }//End of class DoublyLinkedListDemo
}//End of namespace DoublyLinkedListDemo
