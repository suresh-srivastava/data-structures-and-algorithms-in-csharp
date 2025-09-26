//BubbleSort.cs : Program of sorting using bubble sort.

using System;

namespace BubbleSortDemo
{
    class BubbleSortDemo
    {
	    static void BubbleSort(int[] arr, int n)
	    {
		    int temp, xchanges;

		    for(int i=0; i<n-1 ;i++)
		    {
			    xchanges = 0;
			    for(int j=0; j<n-1-i; j++)
			    {
				    if(arr[j] > arr[j+1])
				    {
					    temp = arr[j];
					    arr[j] = arr[j+1];
					    arr[j+1] = temp;
					    xchanges++;
				    }
			    }
			    if(xchanges == 0) //If list is sorted
				    break;
		    }//End of for
	    }//End of BubbleSort()

        static void Main(string[] args)
        {
		    int[] arr = {40, 20, 50, 60, 30, 10, 90, 97, 70, 80};

		    Console.WriteLine("Unsorted list is :"); 
		    for(int i=0; i<arr.Length; i++)
			    Console.Write(arr[i] + " ");
		    Console.WriteLine();

		    BubbleSort(arr,arr.Length);
		
		    Console.WriteLine("Sorted list is :"); 
		    for(int i=0; i<arr.Length; i++)
			    Console.Write(arr[i] + " ");
		    Console.WriteLine();
        }//End of Main()
    }//End of class BubbleSortDemo
}//End of namespace BubbleSortDemo
