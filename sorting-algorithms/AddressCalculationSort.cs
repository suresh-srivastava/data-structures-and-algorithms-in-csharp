//AddressCalculationSort.cs : Program of sorting using address calculation sort.

using System;

namespace AddressCalculationSortDemo
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

        public Node GetStart()
        {
            return start;
        }//End of GetStart()	

        private bool IsEmpty()
        {
            return start == null;
        }//End of IsEmpty()

        public void Insert(int data)
        {
            Node temp = new Node(data);

            //List empty or new node to be inserted before first node
            if (IsEmpty() || data < start.info)
            {
                temp.link = start;
                start = temp;
            }
            else
            {
                Node p = start;
                while (p.link != null && p.link.info < data)
                    p = p.link;
                temp.link = p.link;
                p.link = temp;
            }
        }//End of Insert()

    }//End of class SortedLinkedList

    class AddressCalculationSortDemo
    {
	    static int HashFn(int x, int large)
	    {
		    float temp;
	        temp = (float)x / large;
	        return (int)(temp * 5);
	    }//End of HashFn()	
	
	    static void AddressCalculationSort(int[] arr, int n)
	    {
		    int i;
		
		    SortedLinkedList[] list = new SortedLinkedList[6];
		    for(i=0; i<6; i++)
			    list[i] = new SortedLinkedList();

		    int large = 0;
	        for(i=0; i<n; i++)
	        {
			    if(arr[i] > large)
				    large = arr[i];
	        }

		    int x;
		    for(i=0; i<n; i++)
		    {
			    x = HashFn(arr[i],large);
			    list[x].Insert(arr[i]);
		    }

	       //Elements of linked lists are copied to array
	       Node p;
	       i = 0;
	       for(int j=0; j<=5; j++)
	       {
			    p = list[j].GetStart();
	            while(p != null)
	            {
				    arr[i++] = p.info;
	                p = p.link;
			    }
	        }//End of for
	    }//End of AddressCalculationSort()

        static void Main(string[] args)
        {
		    int[] arr = {194, 289, 566, 432, 654, 98, 232, 415, 345, 276, 532, 254, 165, 965, 476};

		    Console.WriteLine("Unsorted list is :"); 
		    for(int i=0; i<arr.Length; i++)
			    Console.Write(arr[i] + " ");
		    Console.WriteLine();

		    AddressCalculationSort(arr,arr.Length);
		
		    Console.WriteLine("Sorted list is :");
		    for(int i=0; i<arr.Length; i++)
                Console.Write(arr[i] + " ");
		    Console.WriteLine();
        }
    }//End of class AddressCalculationSortDemo
}//End of namespace AddressCalculationSortDemo
