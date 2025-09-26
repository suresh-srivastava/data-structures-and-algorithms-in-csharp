//QuickSort.cs : Program of sorting using quick sort.

using System;

namespace QuickSortDemo
{
    class QuickSortDemo
    {
	    static int Partition(int[] arr, int low, int up)
	    {	
		    int pivot = arr[low];

		    int i = low+1;	//moves from left to right
		    int j = up;		//moves from right to left

		    int temp;
		
		    while(i <= j)
		    {
			    while(arr[i]<pivot && i<up)
				    i++;
			
			    while(arr[j] > pivot)	
				    j--;
			
			    if(i < j)	//swap arr[i] and arr[j]
			    {
				    temp = arr[i];
				    arr[i] = arr[j];
				    arr[j] = temp;
				    i++;
				    j--;
			    }
			    else	//found proper place for pivot
				    i++;
		    }//End of while

		    //Proper place for pivot is j
		    arr[low] = arr[j];
		    arr[j] = pivot;
		
		    return j;
	    }//End of Partition()

	    //Recursive QuickSort()
	    static void QuickSort(int[] arr, int low, int up )
	    {
		    if(low >= up)
			    return;

		    int pivotloc = Partition(arr,low,up);
		    QuickSort(arr,low,pivotloc-1); //process left sublist
		    QuickSort(arr,pivotloc+1,up);  //process right sublist
	    }//End of QuickSort()

	    static void QuickSort(int[] arr, int n)
	    {
		    QuickSort(arr, 0, n-1);
	    }//End of QuickSort()

        static void Main(string[] args)
        {
		    int[] arr = {48, 44, 19, 59, 72, 80, 42, 65, 82, 8, 95, 68};

		    Console.WriteLine("Unsorted list is :"); 
		    for(int i=0; i<arr.Length; i++)
			    Console.Write(arr[i] + " ");
		    Console.WriteLine();

		    QuickSort(arr,arr.Length);
		
		    Console.WriteLine("Sorted list is :");
		    for(int i=0; i<arr.Length; i++)
                Console.Write(arr[i] + " ");
		    Console.WriteLine();
        }//End of Main()
    }//End of class QuickSortDemo
}//End of namespace QuickSortDemo
