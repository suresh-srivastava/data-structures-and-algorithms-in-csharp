//BinarySearch.cs : Program of binary search in an array

using System;

namespace BinarySearchDemo
{
    class BinarySearchDemo
    {
	    static int BinarySearch(int[] arr, int n, int item)
	    {
		    int low=0, up=n-1, mid;

		    while(low <= up)
		    {
			    mid = (low+up)/2;
			    if(item > arr[mid])
				    low = mid+1;	//Search in right half
			    else if(item < arr[mid])
				    up = mid-1;		//Search in left half
			    else
				    return mid;
		    }

		    return -1;
	    }//End of BinarySearch()

        static void Main(string[] args)
        {
		    int[] arr = {2, 9, 16, 19, 29, 36, 41, 67, 85, 96};
		    int item = 29;
		
		    int index = BinarySearch(arr, arr.Length, item);

		    if(index==-1)
			    Console.WriteLine(item + " not found in array");
		    else
                Console.WriteLine(item + " found at position " + index);
        }//End of Main()
    }//End of class BinarySearchDemo
}//End of namespace BinarySearchDemo
