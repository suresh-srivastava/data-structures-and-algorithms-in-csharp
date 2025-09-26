//SingleLinkedList.cs : Program of Single linked list.

using System;

namespace SingleLinkedListDemo
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

        public SingleLinkedList(SingleLinkedList list)
        {
            if (list.start == null)
                start = null;
            else
            {
                Node p1, p2;
                p1 = list.start;
                p2 = start = new Node(p1.info);
                p1 = p1.link;

                while(p1 != null)
                {
                    p2.link = new Node(p1.info);
                    p2 = p2.link;
                    p1 = p1.link;
                }
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
				    p = p.link;
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
            while(p != null)
            {
                count++;
                p = p.link;
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
                p = p.link;
            }

            return 0;
        }//End of Find()	

        public void InsertAtBeginning(int data)
        {
            Node temp;

            temp = new Node(data);
            if (!IsEmpty())
                temp.link = start;

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
                while (p.link != null)
                    p = p.link;

                p.link = temp;
            }
        }//End of InsertAtEnd()

        public void InsertBefore(int data, int nodeData)
	    {
		    Node p, temp;

		    p = start;

		    if(IsEmpty())
			    Console.WriteLine("List is empty");
		    else if(p.info == nodeData) //nodeData is in first node
		    {
			    temp = new Node(data);
			    temp.link = p;
			    start = temp;
		    }
		    else
		    {
			    //Get the reference to predecessor of node containing nodeData
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

		    p = start;
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
			    temp.link = start;
			    start = temp;
		    }
		    else
		    {
			    p = start;
			    int index = 1;
			    while(p!=null && index < position-1) //Get the reference to (position-1)th node
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
			    start = start.link;
	    }//End of DeleteAtBeginning()	

        public void DeleteAtEnd()
	    {
		    Node p;

		    p = start;

		    if(IsEmpty())
			    Console.WriteLine("List is empty");
		    else if(p.link == null)
			    start = p.link;
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

		    p = start;
		    if(IsEmpty())
			    Console.WriteLine("List is empty");
		    else if(p.info == nodeData) //Deletion of first node
			    start = p.link;
		    else //Deletion in between or at the end
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

		    p = start;

		    if(IsEmpty())
			    Console.WriteLine("List is empty");
		    else if(position == 1)
			    start = start.link;
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
			    p = start;
			    prev = null;

			    while(p != null)
			    {
				    next = p.link;
				    p.link = prev;
				    prev = p;
				    p = next;
			    }
			    start = prev;
		    }
	    }//End of Reverse()	

        public void SelectionSortExchangeData()
        {
            Node p, q;
            int temp;

            p = start;

            for (p = start; p.link != null; p = p.link)
            {
                for (q = p.link; q != null; q = q.link)
                {
                    if (p.info > q.info)
                    {
                        temp = p.info;
                        p.info = q.info;
                        q.info = temp;
                    }
                }
            }
        }//End of SelectionSortExchangeData()	

        public void SelectionSortExchangeLinks()
        {
            Node p, q, r, s, temp;

            for (r = p = start; p.link != null; r = p, p = p.link)
            {
                for (s = q = p.link; q != null; s = q, q = q.link)
                {
                    if (p.info > q.info)
                    {
                        temp = p.link;
                        p.link = q.link;
                        q.link = temp;
                        if (p != start)
                            r.link = q;
                        s.link = p;
                        if (p == start)
                            start = q;
                        temp = p;
                        p = q;
                        q = temp;
                    }//End of if
                }//End of for
            }//End of for
        }//End of SelectionSortExchangeLinks()	

        public void BubbleSortExchangeData()
        {
            Node p, q = null, end;
            int temp;

            for (end = null; end != start.link; end = q)
            {
                for (p = start; p.link != end; p = p.link)
                {
                    q = p.link;
                    if (p.info > q.info)
                    {
                        temp = p.info;
                        p.info = q.info;
                        q.info = temp;
                    }
                }
            }
        }//End of BubbleSortExchangeData()

        public void BubbleSortExchangeLinks()
        {
            Node p, q = null, r, end, temp;

            for (end = null; end != start.link; end = q)
            {
                for (r = p = start; p.link != end; r = p, p = p.link)
                {
                    q = p.link;
                    if (p.info > q.info)
                    {
                        p.link = q.link;
                        q.link = p;
                        if (p != start)
                            r.link = q;
                        else
                            start = q;

                        //Rearranging the position of p and q for next pass
                        temp = p;
                        p = q;
                        q = temp;
                    }//End of if
                }//End of for
            }//End of for
        }//End of BubbleSortExchangeLinks()	

        public void MergeLists1(SingleLinkedList list, SingleLinkedList mergedList)
        {
            mergedList.start = Merge1(start, list.start);
        }//End of MergeLists1()

        //Merging 2 lists to another new list
        private Node Merge1(Node p1, Node p2)
        {
            Node startM;

            if (p1.info <= p2.info)
            {
                startM = new Node(p1.info);
                p1 = p1.link;
            }
            else
            {
                startM = new Node(p2.info);
                p2 = p2.link;
            }

            Node pM = startM;

            while (p1 != null && p2 != null)
            {
                if (p1.info <= p2.info)
                {
                    pM.link = new Node(p1.info);
                    p1 = p1.link;
                }
                else
                {
                    pM.link = new Node(p2.info);
                    p2 = p2.link;
                }
                pM = pM.link;
            }

            //Second list is finished. Add the elements of first list.
            while (p1 != null)
            {
                pM.link = new Node(p1.info);
                p1 = p1.link;
                pM = pM.link;
            }

            //First list is finished. Add the elements of second list.
            while (p2 != null)
            {
                pM.link = new Node(p2.info);
                p2 = p2.link;
                pM = pM.link;
            }

            return startM;
        }//End of Merge1()	

        public void MergeLists2(SingleLinkedList list, SingleLinkedList mergedList)
        {
            mergedList.start = Merge2(start, list.start);
            start = null;
            list.start = null;
        }//End of MergeLists2()

        //Merging lists by exchanging links
        private Node Merge2(Node p1, Node p2)
        {
            Node startM;

            if (p1.info <= p2.info)
            {
                startM = p1;
                p1 = p1.link;
            }
            else
            {
                startM = p2;
                p2 = p2.link;
            }

            Node pM = startM;

            while (p1 != null && p2 != null)
            {
                if (p1.info <= p2.info)
                {
                    pM.link = p1;
                    p1 = p1.link;
                    pM = pM.link;
                }
                else
                {
                    pM.link = p2;
                    p2 = p2.link;
                    pM = pM.link;
                }
            }

            //Second list is finished. Add the remaining elements of first list
            if (p1 != null)
                pM.link = p1;

            //First list is finished. Add the remaining elements of second list
            if (p2 != null)
                pM.link = p2;

            return startM;
        }//End of Merge2()	

        public void MergeSort()
        {
            start = MergeSortRec(start);
        }//End of MergeSort()

        private Node MergeSortRec(Node listStart)
        {
            //If the list is empty or has only one node
            if (listStart == null || listStart.link == null)
                return listStart;

            //If more than one element
            Node start1 = listStart;
            Node start2 = DivideList(listStart);
            start1 = MergeSortRec(start1);
            start2 = MergeSortRec(start2);
            Node startM = Merge2(start1, start2);

            return startM;
        }//End of MergeSortRec()

        private Node DivideList(Node p)
        {
            Node q = p.link.link;

            while (q != null && q.link != null)
            {
                p = p.link;
                q = q.link.link;
            }

            Node start2 = p.link;
            p.link = null;

            return start2;
        }//End of DivideList()	

        public void Concatenate(SingleLinkedList list)
        {
            if (start == null)
            {
                start = list.start;
                return;
            }

            if (list.start == null)
                return;

            Node p = start;
            while (p.link != null)
                p = p.link;

            p.link = list.start;
            list.start = null;
        }//End of Concatenate()

        public void InsertCycle(int nodeData)
	    {
		    Node p, prev, cycleP;

		    cycleP = null;

		    if(start==null || start.link==null)
			    Console.WriteLine("Cycle cannot be inserted");
		    else
		    {
			    p = start;
			    prev = start;
			    while(p != null)
			    {
				    if(p.info == nodeData)
				    {
					    cycleP = p;
				    }
				    prev = p;
				    p = p.link;
			    }

			    if(cycleP != null)
			    {
				    Console.WriteLine("cycleP.info : " + cycleP.info);
				    prev.link = cycleP;

				    //Display the list
				    p = start;
				    while(p != cycleP)
				    {
					    Console.WriteLine("p.info = " + p.info);
					    p = p.link;
				    }

				    p = cycleP;
				    do
				    {
					    Console.WriteLine("p.info = " + p.info);
					    p = p.link;
				    }while(p != cycleP);
			    }//End of if
			    else
				    Console.WriteLine(nodeData + " is not found in the list");
		    }//End of else
	    }//End of InsertCycle()

        private Node FindCycle()
	    {
		    Node slowP, fastP;

		    if(start==null || start.link==null)
			    return null;
		    else
		    {
			    slowP = start;
			    fastP = start;

			    while(fastP!=null && fastP.link!=null)
			    {
				    slowP = slowP.link;
				    fastP = fastP.link.link;

				    if(slowP == fastP)
				    {
					    Console.WriteLine("slowP and fastP meets here");
					    Console.WriteLine("slowP.info = " + slowP.info);
					    Console.WriteLine("fastP.info = " + fastP.info);

					    return slowP;
				    }
			    }//End of while

			    return null;
		    }//End of else

	    }//End of FindCycle()

        public bool HasCycle()
        {
            if(FindCycle() != null)
                return true;
            else
                return false;
        }//End of HasCycle()

        public void RemoveCycle()
	    {
		    Node p, p1, p2;

		    p = FindCycle();

		    if(p == null)
			    Console.WriteLine("There is no cycle in list.");
		    else
		    {
			    Console.WriteLine("Node where cycle was detected : " + p.info);
			    p1 = p;
			    p2 = p;

			    //Find the length of cycle
			    int cycleLength = 0;
			    do
			    {
				    cycleLength++;
				    p1 = p1.link;
			    }while(p1 != p2);

			    Console.WriteLine("Cycle Length : " + cycleLength);

			    //Find the remaining length
			    int remLength = 0;
			    p1 = start;
			    while(p1 != p2)
			    {
				    remLength++;
				    p1 = p1.link;
				    p2 = p2.link;
			    }

			    Console.WriteLine("Remaining Length : " + remLength);

			    int listLength = cycleLength + remLength;

			    Console.WriteLine("The List is :");
			    p1 = start;
			    for(int i=1; i<=listLength-1; i++)
			    {
				    Console.WriteLine(p1.info);
				    p1 = p1.link;
			    }
                Console.WriteLine(p1.info);
			    p1.link = null;
		    }
	    }//End of RemoveCycle()	

    }//End of class SingleLinkedList

    class SingleLinkedListDemo
    {
        static void Main(string[] args)
        {
		    SingleLinkedList list1 = new SingleLinkedList();

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
		
		    SingleLinkedList list2 = new SingleLinkedList(list1);
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
		
		    SingleLinkedList list3 = new SingleLinkedList();
		    list3.InsertAtEnd(20);
		    list3.InsertAtEnd(10);
		    list3.InsertAtEnd(50);
		    list3.InsertAtEnd(30);
		    list3.InsertAtEnd(40);

		    Console.WriteLine("List3 Items :");
		    list3.Display();		
		
		    SingleLinkedList list4 = new SingleLinkedList(list3);
		    list4.SelectionSortExchangeData();
		    Console.WriteLine("List4 Items after selection sort (exchange data) :");
		    list4.Display();		
		
		    SingleLinkedList list5 = new SingleLinkedList(list3);
		    list5.SelectionSortExchangeLinks();
		    Console.WriteLine("List5 Items after selection sort (exchange links) :");
		    list5.Display();
		
		    SingleLinkedList list6 = new SingleLinkedList(list3);
		    list6.BubbleSortExchangeData();
		    Console.WriteLine("List6 Items after bubble sort (exchange data) :");
		    list6.Display();

		    SingleLinkedList list7 = new SingleLinkedList(list3);
		    list7.BubbleSortExchangeLinks();
		    Console.WriteLine("List7 Items after bubble sort (exchange links) :");
		    list7.Display();
		
		    SingleLinkedList list8 = new SingleLinkedList();
		    SingleLinkedList list9 = new SingleLinkedList();
		    SingleLinkedList list10 = new SingleLinkedList();
		    SingleLinkedList list11 = new SingleLinkedList();		
		
		    list8.InsertAtEnd(10);
		    list8.InsertAtEnd(20);
		    list8.InsertAtEnd(30);
		    list8.InsertAtEnd(40);
		    list8.InsertAtEnd(50);

		    Console.WriteLine("List8 Items :");
		    list8.Display();

		    list9.InsertAtEnd(15);
		    list9.InsertAtEnd(25);
		    list9.InsertAtEnd(30);
		    list9.InsertAtEnd(45);
		    list9.InsertAtEnd(55);

		    Console.WriteLine("List9 Items :");
		    list9.Display();

		    list8.MergeLists1(list9, list10);
		    Console.WriteLine("List10 Items - Mergeing 2 Lists to another new list :");
		    list10.Display();

		    list8.MergeLists2(list9, list11);
		    Console.WriteLine("List11 Items - Merged List (exchange links) :");
		    list11.Display();		
		
		    SingleLinkedList list12 = new SingleLinkedList();

		    list12.InsertAtEnd(10);
		    list12.InsertAtEnd(5);
		    list12.InsertAtEnd(20);
		    list12.InsertAtEnd(15);
		    list12.InsertAtEnd(30);
		    list12.InsertAtEnd(25);
		    list12.InsertAtEnd(40);
		    list12.InsertAtEnd(35);

		    Console.WriteLine("List12 Items :");
		    list12.Display();

		    list12.MergeSort();

		    Console.WriteLine("List12 Items after merge sort :");
		    list12.Display();		
		
		    SingleLinkedList list13 = new SingleLinkedList();
		    SingleLinkedList list14 = new SingleLinkedList();

		    list13.InsertAtEnd(10);
		    list13.InsertAtEnd(20);
		    list13.InsertAtEnd(30);
		    list13.InsertAtEnd(40);
		    list13.InsertAtEnd(50);

		    Console.WriteLine("List13 Items :");
		    list13.Display();

		    list14.InsertAtEnd(5);
		    list14.InsertAtEnd(15);
		    list14.InsertAtEnd(25);
		    list14.InsertAtEnd(35);
		    list14.InsertAtEnd(45);

		    Console.WriteLine("List14 Items :");
		    list14.Display();

		    list13.Concatenate(list14);

		    Console.WriteLine("List13 Items after concatenation :");
		    list13.Display();		
		
		    SingleLinkedList list15 = new SingleLinkedList();

		    list15.InsertAtEnd(10);
		    list15.InsertAtEnd(20);
		    list15.InsertAtEnd(30);
		    list15.InsertAtEnd(40);
		    list15.InsertAtEnd(50);
		    list15.InsertAtEnd(60);
		    list15.InsertAtEnd(70);
		    list15.InsertAtEnd(80);

		    Console.WriteLine("Finding a cycle and its removal in list :");
		    Console.WriteLine("find(40) = " + list15.Find(40));
		    list15.InsertCycle(40);
		    Console.WriteLine("Has cycle : " + (list15.HasCycle() ? "True" : "False"));
		    list15.RemoveCycle();
            Console.WriteLine("Has cycle : " + (list15.HasCycle() ? "True" : "False"));
        }//End of Main()
    }//End of class SingleLinkedListDemo
}//End of namespace SingleLinkedListDemo
