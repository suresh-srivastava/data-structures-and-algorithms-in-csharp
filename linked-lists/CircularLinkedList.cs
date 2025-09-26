//CircularLinkedList.cs : Program of Circular linked list.

using System;

namespace CircularLinkedListDemo
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

    class CircularLinkedList
    {
        private Node last;

        public CircularLinkedList()
        {
            last = null;
        }//End of CircularLinkedList()

        public CircularLinkedList(CircularLinkedList list)
        {
            if (list.last == null)
                last = null;
            else
            {
                Node p1, p2;

                p1 = list.last.link;
                p2 = last = new Node(p1.info);
                last.link = last;
                p1 = p1.link;

                while (p1 != list.last.link)
                {
                    Node temp = new Node(p1.info);
                    temp.link = p2.link;
                    p2.link = temp;
                    p2 = p2.link;
                    last = p2;
                    p1 = p1.link;
                }
            }//End of else
        }//End of copy constructor	

        public bool IsEmpty()
        {
            return (last == null);
        }//End of IsEmpty()

        public void Display()
	    {
		    Node p;

		    if(!IsEmpty())
		    {
			    p = last.link;
			    do
			    {
				    Console.WriteLine(p.info);
				    p = p.link;
			    }while(p != last.link);
		    }
		    else
                Console.WriteLine("List is empty");
	    }//End of Display()

        public void InsertAtBeginning(int data)
        {
            Node temp;

            temp = new Node(data);
            if (IsEmpty())
            {
                last = temp;
                last.link = temp;
            }
            else
            {
                temp.link = last.link;
                last.link = temp;
            }

        }//End of InsertAtBeginning()	

        public void InsertAtEnd(int data)
        {
            Node temp;

            temp = new Node(data);

            if (IsEmpty())
            {
                last = temp;
                last.link = temp;
            }
            else
            {
                temp.link = last.link;
                last.link = temp;
                last = temp;
            }
        }//End of InsertAtEnd()	

        public void InsertBefore(int data, int nodeData)
	    {
		    Node p, temp;

		    p = last;

		    if(IsEmpty())
			    Console.WriteLine("List is empty");
		    else if(p.link.info == nodeData) //nodeData is in first node
		    {
			    temp = new Node(data);
			    temp.link = p.link;
			    p.link = temp;
		    }
		    else
		    {
			    p = last.link;
			    do
			    {
				    if(p.link.info == nodeData)
				    {
					    temp = new Node(data);
					    temp.link = p.link;
					    p.link = temp;
					    break;
				    }
				    p = p.link;
			    }while(p != last.link);

			    if(p == last.link)
				    Console.WriteLine("Item " + nodeData + " is not in the list");

		    }//End of else
	    }//End of InsertBefore()

        public void InsertAfter(int data, int nodeData)
	    {
		    Node p, temp;

		    if(IsEmpty())
			    Console.WriteLine("List is empty");
		    else
		    {
			    p = last.link;
			    do
			    {
				    if(p.info == nodeData)
				    {
					    temp = new Node(data);
					    temp.link = p.link;
					    p.link = temp;
					    if(p == last)
						    last = temp;
					    break;
				    }
				    p = p.link;
			    }while(p != last.link);

			    if(p == last.link)
				    Console.WriteLine("Item " + nodeData + " is not in the list");

		    }//End of else
	    }//End of InsertAfter()	

        public void InsertAtPosition(int data, int position)
	    {
		    Node p, temp;

		    p = last;

		    if(IsEmpty())
		    {
			    if(position == 1)
			    {
				    temp = new Node(data);
				    last = temp;
				    last.link = temp;
			    }
			    else
				    Console.WriteLine("Item cannot be inserted at position : " + position);
		    }
		    else if(position == 1)
		    {
			    temp = new Node(data);
			    temp.link = last.link;
			    last.link = temp;
		    }
		    else
		    {
			    p = last.link;
			    int index = 1;
			    do
			    {
				    if(index == position-1)
				    {
					    temp = new Node(data);
					    temp.link = p.link;
					    p.link = temp;
					    if(p == last)
						    last = temp;
					    p = p.link;
					    break;
				    }
				    index++;
				    p = p.link;
			    }while(p != last.link);

			    if(p == last.link)
				    Console.WriteLine("Item cannot be inserted at position : " + position);

		    }//End of else

	    }//End of InsertAtPosition()	

        public void DeleteAtBeginning()
	    {
		    if(IsEmpty())
			    Console.WriteLine("List is empty");
		    else if(last.link == last) //List has only one node
			    last = null;
		    else 
                last.link = last.link.link;
	    }//End of DeleteAtBeginning()	

        public void DeleteAtEnd()
	    {
		    Node p;

		    if(IsEmpty())
			    Console.WriteLine("List is empty");
		    else if(last.link == last) //List has only one node
			    last = null;
		    else
		    {
			    p = last.link;
			    while(p.link != last)
				    p = p.link;

			    p.link = last.link;
			    last = p;
		    }
	    }//End of DeleteAtEnd()	

        public void DeleteNode(int nodeData)
	    {
		    Node p;

		    if(IsEmpty())
			    Console.WriteLine("List is empty");
		    else if(last.link.info == nodeData) //Deletion of first node
		    {
			    if(last.link == last) //List has only one node
				    last = null;
			    else 
                    last.link = last.link.link;
		    }
		    else //Deletion in between or at the end
		    {
			    p = last.link;

			    while(p.link != last.link)
			    {
				    if(p.link.info == nodeData)
					    break;
				    p = p.link;
			    }
			    if(p.link == last.link)
				    Console.WriteLine(nodeData + " not found in list");
			    else
			    {
				    if(p.link == last)
					    last = p;
				    p.link = p.link.link;
			    }
		    }//End of else
	    }//End of DeleteNode()

        public void DeleteAtPosition(int position)
	    {
		    Node p;

		    if(IsEmpty())
			    Console.WriteLine("List is empty");
		    else if(position == 1) //Deletion of first node
		    {
			    if(last.link == last) //List has only one node
				    last = null;
			    else 
                    last.link = last.link.link;
		    }
		    else //Deletion in between or at the end
		    {
			    p = last.link;
			    int index = 1;

			    while(p.link != last.link)
			    {
				    if(index == position-1)
					    break;
				    index++;
				    p = p.link;
			    }
			    if(p.link == last.link)
				    Console.WriteLine("Node cannot be deleted at position : " + position);
			    else
			    {
				    if(p.link == last)
					    last = p;
				    p.link = p.link.link;
			    }
		    }//End of else
	    }//End of DeleteAtPosition()

        public void Reverse()
	    {
		    Node prev, p, next;

		    if(IsEmpty())
			    Console.WriteLine("List is empty");
		    else
		    {
			    p = last.link;
			    prev = last;

			    while(p.link != last.link)
			    {
				    next = p.link;
				    p.link = prev;
				    prev = p;
				    p = next;
			    }
			    last = p.link;
			    last.link = p;
			    p.link = prev;

		    }
	    }//End of Reverse()	

        public void Concatenate(CircularLinkedList list)
        {
            Node p;

            if (last == null)
            {
                last = list.last;
                list.last = null;
            }
            else if (list.last != null)
            {
                p = last.link;
                last.link = list.last.link;
                list.last.link = p;
                last = list.last;

                list.last = null;
            }
        }//End of Concatenate()	

    }//End of class CircularLinkedList

    class CircularLinkedListDemo
    {
        static void Main(string[] args)
        {
		    CircularLinkedList list1 = new CircularLinkedList();

		    //Create the List
		    list1.InsertAtBeginning(10);
		    list1.InsertAtEnd(30);
		    list1.InsertAfter(50,30);
		    list1.InsertAtPosition(20,2);
		    list1.InsertBefore(40,50);
		
		    Console.WriteLine("List1 Items after insertion :");
		    list1.Display();

		    CircularLinkedList list2 = new CircularLinkedList(list1);
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
		
		    CircularLinkedList list4 = new CircularLinkedList();
		    CircularLinkedList list5 = new CircularLinkedList();

		    list4.InsertAtEnd(10);
		    list4.InsertAtEnd(20);
		    list4.InsertAtEnd(30);
		    list4.InsertAtEnd(40);
		    list4.InsertAtEnd(50);

		    Console.WriteLine("List4 Items :");
		    list4.Display();

		    list5.InsertAtEnd(5);
		    list5.InsertAtEnd(15);
		    list5.InsertAtEnd(25);
		    list5.InsertAtEnd(35);
		    list5.InsertAtEnd(45);

		    Console.WriteLine("List5 Items :");
		    list5.Display();

		    list4.Concatenate(list5);

            Console.WriteLine("List4 Items after concatenation :");
		    list4.Display();
        }//End of Main()
    }//End of class CircularLinkedListDemo
}//End of namespace CircularLinkedListDemo
