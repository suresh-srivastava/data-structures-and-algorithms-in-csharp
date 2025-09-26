//SelectionSort.cs : Program of sorting using selection sort.

using System;

namespace SelectionSortDemo
{
    class SelectionSortDemo
    {
	    static void SelectionSort(int[] arr, int n)
	    {
		    int min, temp;

		    for(int i=0; i<n-1; i++)
		    {
			    //Find the index of smallest element
			    min = i;
			    for(int j=i+1; j<n; j++)
			    {
				    if(arr[min] > arr[j])
					    min = j;
			    }

			    if(i != min)
			    {
				    temp = arr[i];
				    arr[i] = arr[min];
				    arr[min] = temp ;
			    }
		    }//End of for
	    }//End of SelectionSort()

        static void Main(string[] args)
        {
		    int[] arr = {82, 42, 49, 8, 25, 52, 36, 93, 59, 15};

		    Console.WriteLine("Unsorted list is :"); 
		    for(int i=0; i<arr.Length; i++)
			    Console.Write(arr[i] + " ");
		    Console.WriteLine();

		    SelectionSort(arr,arr.Length);
		
		    Console.WriteLine("Sorted list is :"); 
		    for(int i=0; i<arr.Length; i++)
                Console.Write(arr[i] + " ");
		    Console.WriteLine();

        }//End of Main()
    }//End of class SelectionSortDemo
}//End of namespace SelectionSortDemo
