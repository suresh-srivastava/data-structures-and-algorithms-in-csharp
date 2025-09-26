//InsertionSort.cs : Program of sorting using insertion sort.

using System;

namespace InsertionSortDemo
{
    class InsertionSortDemo
    {
	    static void InsertionSort(int[] arr, int n)
	    {
		    int i,j,k;

		    for(i=1; i<n; i++)
		    {
			    k = arr[i];
			    for(j=i-1; j>=0 && arr[j]>k; j--)
				    arr[j+1] = arr[j];
			    arr[j+1] = k;
		    }//End of for
	    }//End of InsertionSort()

        static void Main(string[] args)
        {
		    int[] arr = {82, 42, 49, 8, 25, 52, 36, 93, 59, 15};

		    Console.WriteLine("Unsorted list is :"); 
		    for(int i=0; i<arr.Length; i++)
			    Console.Write(arr[i] + " ");
		    Console.WriteLine();

		    InsertionSort(arr,arr.Length);
		
		    Console.WriteLine("Sorted list is :"); 
		    for(int i=0; i<arr.Length; i++)
                Console.Write(arr[i] + " ");
		    Console.WriteLine();
        }
    }//End of class InsertionSortDemo
}//End of namespace InsertionSortDemo
