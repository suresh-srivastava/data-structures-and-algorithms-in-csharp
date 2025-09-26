//ShellSort.cs : Program of sorting using shell sort.

using System;

namespace ShellSortDemo
{
    class ShellSortDemo
    {
	    static void ShellSort(int[] arr, int n)
	    {
		    int i,j,k;
		    int incr = 5; //maximum increment (odd value)
		
		    while(incr >= 1)
		    {
			    for(i=incr; i<n; i++)
			    {
				    k=arr[i];
				    for(j=i-incr; j>=0 && k<arr[j]; j=j-incr)
					    arr[j+incr]=arr[j];
				    arr[j+incr]=k;
			    }//End of for
			    incr=incr-2;	//Decrease the increment
		    }//End of while

	    }//End of ShellSort()

        static void Main(string[] args)
        {
		    int[] arr = {19, 63, 2, 6, 7, 10, 1, 18, 9, 4, 45, 3, 5, 17, 16, 12, 56};

		    Console.WriteLine("Unsorted list is :"); 
		    for(int i=0; i<arr.Length; i++)
			    Console.Write(arr[i] + " ");
		    Console.WriteLine();

		    ShellSort(arr,arr.Length);
		
		    Console.WriteLine("Sorted list is :"); 
		    for(int i=0; i<arr.Length; i++)
                Console.Write(arr[i] + " ");
		    Console.WriteLine();
        }//End of Main()
    }//End of class ShellSortDemo
}//End of namespace ShellSortDemo
