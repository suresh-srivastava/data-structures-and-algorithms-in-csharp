//MergeSortLinkedList.cs : Program of sorting using merge sort on linked list.

using System;

namespace MergeSortLinkedListDemo
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
            return (start == null);
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
		    Node ptr;

		    if(!IsEmpty())
		    {
			    ptr = start;
			    while(ptr != null)
			    {
				    Console.Write(ptr.info + " ");
				    ptr = ptr.link;
			    }
			    Console.WriteLine();
		    }
		    else
                Console.WriteLine("List is empty");
	    }//End of Display()	

        private Node Merge(Node p1, Node p2)
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
                    pM = pM.link;
                    p1 = p1.link;
                }
                else
                {
                    pM.link = p2;
                    pM = pM.link;
                    p2 = p2.link;
                }
            }//End of while

            if (p1 == null)
                pM.link = p2;
            else
                pM.link = p1;

            return startM;
        }//End of Merge()	

        Node DivideList(Node p)
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

        private Node MergeSortRec(Node listStart)
        {
            if (listStart == null || listStart.link == null) //if list empty or has one element
                return listStart;

            //if more than one element
            Node start1 = listStart;
            Node start2 = DivideList(listStart);
            start1 = MergeSortRec(start1);
            start2 = MergeSortRec(start2);
            Node startM = Merge(start1, start2);
            return startM;
        }//End of MergeSortRec()

        public void MergeSort()
        {
            start = MergeSortRec(start);
        }//End of MergeSort()	

    }//End of class SingleLinkedList

    class MergeSortLinkedListDemo
    {
        static void Main(string[] args)
        {
		    SingleLinkedList list = new SingleLinkedList();

		    //Create the List
		    list.InsertAtBeginning(3);
		    list.InsertAtBeginning(56);
		    list.InsertAtBeginning(21);
		    list.InsertAtBeginning(4);
		    list.InsertAtBeginning(64);
		    list.InsertAtBeginning(92);
		    list.InsertAtBeginning(42);
		    list.InsertAtBeginning(30);
		    list.InsertAtBeginning(89);
		    list.InsertAtBeginning(5);
		    list.InsertAtBeginning(8);

		    Console.WriteLine("List items :");
		    list.Display();

		    list.MergeSort();

		    Console.WriteLine("List items after merge sort on list :");
		    list.Display();
        }//End of Main()
    }//End of class MergeSortLinkedListDemo
}//End of namespace MergeSortLinkedListDemo
